// CCore/framework.c
#include "framework.h"


#if defined(PLATFORM_DESKTOP)
#define GLSL_VERSION            330
#else   // PLATFORM_ANDROID, PLATFORM_WEB
#define GLSL_VERSION            100
#endif

// Example function for drawing
void DrawCustomRectangle(int x, int y, int width, int height) {
    DrawRectangle(x, y, width, height, RED);
}

FRAMEWORK_API void Window(int width, int height, const char* title)
{
    InitWindow(width, height, title);
}

FRAMEWORK_API bool ShouldCloseWindow()
{
    return WindowShouldClose();
}

FRAMEWORK_API void Close()
{
    CloseWindow();
}

FRAMEWORK_API void Begin()
{
    BeginDrawing();
}

FRAMEWORK_API void End()
{
    EndDrawing();
}

FRAMEWORK_API void Clear(int r, int g, int b, int a)
{
    ClearBackground((Color) { r, g, b, a });
}

FRAMEWORK_API void DrawFps(int x, int y)
{
    DrawFPS(x, y);
}

FRAMEWORK_API void SetFps(int FPS)
{
    SetTargetFPS(FPS);
}
