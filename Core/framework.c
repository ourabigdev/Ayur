// CCore/framework.c
#include "framework.h"

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

FRAMEWORK_API void BackgroundColor(int r, int g, int b, int a)
{
    Color c = {r, g, b, a};
    ClearBackground(c);
}

FRAMEWORK_API void SetFps(int FPS)
{
    SetTargetFPS(FPS);
}
