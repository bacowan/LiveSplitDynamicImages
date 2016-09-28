#pragma once
#include "OBSApi.h"
#include <Windows.h>
#include <codecvt>
#include "WriteToken.h"
#include "Shlwapi.h"

class LiveSplitDynamicImages
{
public:
	//static const LPTSTR PIPE_NAME;
	LiveSplitDynamicImages();
	void handleMessages();
private:
	HANDLE pipeHandle;
	HANDLE connectToLiveSplit();
	XElement* source = NULL;
	void waitForPipe();
	void waitForFileToExist(String filename);
	char* readMessage(DWORD* messageSize);
	void handleSingleMessage(char* message, int messageLength);
	//CTSTR messageToString(unsigned char* message, int messageLength);
	void respondGlobalImageSources(CTSTR message, int messageLength);
	void getGlobalElements(List<XElement*>* elements);
	void changeImageFile(CTSTR message, int messageLength);
	void getElementNames(List<XElement*>* elements, List<CTSTR>* ret);
	void sendMessage(List<CTSTR>* message);
	void formatList(List<CTSTR>* list, char** message, DWORD* messageSize);
	DWORD getMessageSize(List<CTSTR>* list, int listLen);
	void extractSourceFromMessage(CTSTR* message, CTSTR* sourceName, int* nameLength, CTSTR* sourcePath, int messageLength);
	void updateImage();
	XElement* getSource();
};

#define BUFSIZE 512
#define PIPE_NAME TEXT("\\\\.\\pipe\\LiveSplitDynamicImagesPipe")
#define IMAGE_SOURCE_NAME TEXT("livesplit dynamic image")


#ifdef UNICODE
#define STR_TO_CTSTR(str) ((CTSTR)(str))
#else // TODO
#define STR_TO_CTSTR(str)
#endif