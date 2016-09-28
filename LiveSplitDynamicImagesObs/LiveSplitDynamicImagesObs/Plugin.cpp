#include "Plugin.h"

HANDLE threadHandle;

bool LoadPlugin()
{
	threadHandle = CreateThread(
		NULL,	// default security attributes
		0,		// default stack size  
		main,
		NULL,	// no thread arguments
		0,		// default creation flags 
		NULL	// no thread identifier
		);
	return threadHandle != NULL;
}

DWORD WINAPI main(LPVOID lpParam)
{
	LiveSplitDynamicImages liveSplitDynamicImages;
	liveSplitDynamicImages.handleMessages();
	return 0;
}

void UnloadPlugin()
{
	TerminateThread(threadHandle, 0);
}

CTSTR GetPluginName()
{
	return TEXT("Live Split Dynamic Images");
}

CTSTR GetPluginDescription()
{
	return TEXT("This plugin communicates with LiveSplit to change a displayed image depending on how the split changes.");
}