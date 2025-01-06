// CCore/framework.c
#include "framework.h"

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

FRAMEWORK_API void Begin(bool ShowFps)
{
    BeginDrawing();
    if (ShowFps) {
        DrawFPS(20, 20);
    }
}

FRAMEWORK_API void End()
{
    EndDrawing();
}

FRAMEWORK_API void BackgroundColor(AyurColor color)
{
    Color c = {color.r, color.g, color.b, color.a};
    ClearBackground(c);
}

FRAMEWORK_API void SetFps(int FPS)
{
    SetTargetFPS(FPS);
}

