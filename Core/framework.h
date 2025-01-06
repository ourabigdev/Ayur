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

//framework type
typedef struct AyurColor {
	unsigned char r;
	unsigned char g;
	unsigned char b;
	unsigned char a;
}AyurColor;

typedef struct SpriteAnimation {
	Texture2D atlas;
	int framePerSecond;
	Rectangle* rectangles;
	int rectanglesLength;
} SpriteAnimation;

// Framework functions
FRAMEWORK_API void Window(int width, int height, const char * title);
FRAMEWORK_API bool ShouldCloseWindow();
FRAMEWORK_API void Close();
FRAMEWORK_API void Begin(bool ShowFps);
FRAMEWORK_API void End();
FRAMEWORK_API void BackgroundColor(AyurColor color);
FRAMEWORK_API void SetFps(int FPS);
FRAMEWORK_API void DrawAnimation(SpriteAnimation animation, Rectangle dest, Vector2 origin, float rotation, Color tint);
FRAMEWORK_API void DisposeSpriteAnimation(SpriteAnimation animation);
FRAMEWORK_API Texture2D LoadSprite(const char* path);
FRAMEWORK_API SpriteAnimation CreateSpriteAnimation(Texture2D atlas, int framePerSecond, Rectangle rectangles[], int length);
FRAMEWORK_API typedef struct Color;

#endif // FRAMEWORK_H
