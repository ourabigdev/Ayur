// CCore/framework.h
#ifndef FRAMEWORK_H
#define FRAMEWORK_H

// Exported function
#ifdef _WIN32
#define FRAMEWORK_API __declspec(dllexport)
#else
#define FRAMEWORK_API
#endif

#include <stdlib.h>
#include <stdbool.h>
#include "raylib.h"

// Framework functions
FRAMEWORK_API void DrawCustomRectangle(int x, int y, int width, int height);
FRAMEWORK_API void Window(int width, int height, const char * title);
FRAMEWORK_API bool ShouldCloseWindow();
FRAMEWORK_API void Close();
FRAMEWORK_API void Begin();
FRAMEWORK_API void End();
FRAMEWORK_API void Clear(int r, int g, int b, int a);
FRAMEWORK_API void DrawFps(int x, int y);
FRAMEWORK_API void SetFps(int FPS);



#endif // FRAMEWORK_H
