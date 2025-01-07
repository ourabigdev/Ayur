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

FRAMEWORK_API Texture2D LoadSprite(const char* path)
{
    return LoadTexture(path);
}

FRAMEWORK_API void DrawRect(Rect rectangle, AyurColor color)
{
    DrawRectangle(rectangle.posX, rectangle.posY, rectangle.width, rectangle.height, (Color){color.r, color.g, color.b, color.a});
}

