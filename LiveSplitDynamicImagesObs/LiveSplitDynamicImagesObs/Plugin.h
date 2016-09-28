#pragma once
#include "OBSApi.h"
#include "LiveSplitDynamicImages.h"
extern "C" __declspec(dllexport) bool LoadPlugin();
extern "C" __declspec(dllexport) void UnloadPlugin();
extern "C" __declspec(dllexport) CTSTR GetPluginName();
extern "C" __declspec(dllexport) CTSTR GetPluginDescription();
DWORD WINAPI main(LPVOID lpParam);