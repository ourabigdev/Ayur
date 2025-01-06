//spriteAnimation.c
#include "framework.h"

FRAMEWORK_API SpriteAnimation CreateSpriteAnimation(Texture2D atlas, int framePerSecond, Rectangle rectangles[], int length)
{
	SpriteAnimation spriteAnimation = {
		.atlas = atlas,
		.framePerSecond = framePerSecond,
		.rectanglesLength = length,
	};

	Rectangle* mem = (Rectangle*)malloc(sizeof(Rectangle) * length);
	if (mem == NULL) {
		TraceLog(LOG_FATAL, "No memory for CreateSpriteAnimation");
		spriteAnimation.rectanglesLength = 0;
		return spriteAnimation;
	}

	spriteAnimation.rectangles = mem;

	for (int i = 0; i < length; i++) {
		spriteAnimation.rectangles[i] = rectangles[i];
	}

	return spriteAnimation;
}

FRAMEWORK_API void DisposeSpriteAnimation(SpriteAnimation animation) {
	free(animation.rectangles);
}

FRAMEWORK_API Texture2D LoadSprite(const char* path)
{
	return LoadTexture(path);
}
