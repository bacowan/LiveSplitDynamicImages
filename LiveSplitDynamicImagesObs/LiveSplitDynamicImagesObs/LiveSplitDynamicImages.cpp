#include "LiveSplitDynamicImages.h"

LiveSplitDynamicImages::
LiveSplitDynamicImages()
{
	pipeHandle = connectToLiveSplit();
}

HANDLE
LiveSplitDynamicImages::connectToLiveSplit()
{
	HANDLE handle = INVALID_HANDLE_VALUE;
	while (handle == INVALID_HANDLE_VALUE)
	{
		//waitForPipe();
		handle = CreateFile(
			PIPE_NAME,
			GENERIC_READ | GENERIC_WRITE,
			0,				// no sharing
			NULL,			// default security attributes
			OPEN_EXISTING,	// opens existing pipe
			0,				// default attributes
			NULL);			// no template file
	}
	
	return handle;
}

// TODO: THIS DOESN'T resume when the pipe is created
void
LiveSplitDynamicImages::waitForPipe()
{
	waitForFileToExist(PIPE_NAME);
	WaitNamedPipe(PIPE_NAME, NMPWAIT_WAIT_FOREVER);
}

void
LiveSplitDynamicImages::waitForFileToExist(String fileName)
{
	// TODO: is there a more standard way to do this?
	if (!PathFileExists(fileName))
	{
		HANDLE fileChangeHandle = FindFirstChangeNotification(
			fileName,
			FALSE, // only monitor said file (not subdirectories)
			FILE_NOTIFY_CHANGE_LAST_WRITE);
		WaitForSingleObject(fileChangeHandle, INFINITE);
	}
}

void
LiveSplitDynamicImages::handleMessages()
{
	DWORD messageSize;
	while (1)
	{
		char* message = readMessage(&messageSize);
		handleSingleMessage(message, BUFSIZE);
		free(message);
	}
}

char*
LiveSplitDynamicImages::readMessage(DWORD* messageSize)
{
	BOOLEAN fSuccess = FALSE;
	char* message = (char*)calloc(BUFSIZE, sizeof(char));
	char messageBuffer[BUFSIZE];
	int offset = 0;
	while (!fSuccess)
	{
		fSuccess = ReadFile(
			pipeHandle,
			messageBuffer,
			BUFSIZE,
			messageSize,
			NULL);
		if (!fSuccess && GetLastError() != ERROR_MORE_DATA)
			break;
		memcpy_s(
			message + offset,
			BUFSIZE,
			messageBuffer,
			BUFSIZE);
		if (offset > 0)
			message = (char*)realloc(message, BUFSIZE*(offset+1));
		offset++;
	}
	return message;
}

void
LiveSplitDynamicImages::handleSingleMessage(char* message, int messageLength)
{
	WriteToken token = static_cast<WriteToken>(message[0]);
	CTSTR messageNoToken = STR_TO_CTSTR(message + 1); // doesn't work like that
	if (token == CHANGE_IMAGE_FILE)
		changeImageFile(messageNoToken, messageLength - 1);
	else if (token == REQUEST_GLOBAL_IMAGE_SOURCES)
		respondGlobalImageSources(messageNoToken, messageLength - 1);
}

void
LiveSplitDynamicImages::respondGlobalImageSources(CTSTR message, int messageLength)
{
	XElement* globalSourceList = OBSGetGlobalSourceListElement();
	List<XElement*> elements;
	globalSourceList->GetElementList(NULL, elements);
	List<CTSTR> elementNames;
	getElementNames(&elements, &elementNames);
	sendMessage(&elementNames);
}

void
LiveSplitDynamicImages::getElementNames(List<XElement*>* elements, List<CTSTR> *ret)
{
	for (unsigned int i = 0; i < elements->Num(); i++)
	{
		XElement* element = elements->GetElement(i);
		CTSTR path = element->GetElement(TEXT("data"))->GetString(TEXT("path"));
		if (path != NULL)
		{
			CTSTR str = element->GetName();
			ret->Add(str);
		}
	}
}

void
LiveSplitDynamicImages::sendMessage(List<CTSTR>* list)
{
	char* message;
	DWORD messageSize;
	formatList(list, &message, &messageSize);
	BOOL fSuccess = WriteFile(
		pipeHandle,
		message,
		messageSize,
		NULL,
		NULL);
}

void
LiveSplitDynamicImages::formatList(List<CTSTR>* list, char** message, DWORD* messageSize)
{
	int listLen = list->Num();
	*messageSize = getMessageSize(list, listLen);
	*message = new char[*messageSize]();//(char*)calloc(*messageSize, 1);
	int offset = 4;
	memcpy(*message, messageSize, 4);
	for (int i = 0; i < listLen; i++)
	{
		int strLen = ((String)(list->GetElement(i))).Length();
		memcpy(*message + offset, list->GetElement(i), strLen * 2);
		(*message)[offset + strLen * 2] = '\n';
		offset += (strLen + 1) * 2;
	}
}

DWORD
LiveSplitDynamicImages::getMessageSize(List<CTSTR>* list, int listLen)
{
	DWORD size = 0;
	for (int i = 0; i < listLen; i++)
		size += ((String)(list->GetElement(i))).Length();
	size += listLen; // listLen leaves room for the newline characters to seperate list items
	return size*2 + 4; // +4 leaves room for the dword do contain the message size
}

void
LiveSplitDynamicImages::changeImageFile(CTSTR message, int messageLength)
{
	if (!PathFileExists(message))
		return;
	CTSTR sourceName, sourcePath;
	int nameLength;

	if (source == NULL)
		source = getSource();
	source->SetString(TEXT("path"), message);
	updateImage();
}

void
LiveSplitDynamicImages::updateImage()
{
	ImageSource* imageSource = API->GetSceneImageSource(IMAGE_SOURCE_NAME);
	if (imageSource)
		imageSource->UpdateSettings();
}

XElement*
LiveSplitDynamicImages::getSource()
{
	XElement* sceneElement = API->GetSceneElement();
	if (sceneElement)
	{
		XElement* sources = sceneElement->GetElement(TEXT("sources")); // TODO: Use the same concept when displaying options to the user in livesplit
		if (sources)
		{
			XElement* imageElement = sources->GetElement(IMAGE_SOURCE_NAME);
			if (imageElement)
				return imageElement->GetElement(TEXT("data"));
		}
	}
}