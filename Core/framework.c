// CCore/framework.c
#include "framework.h"

FRAMEWORK_API void Window(const char* title, int w, int h)
{
	SDL_Window* window = NULL;
	SDL_Renderer* renderer = NULL;

	int result = SDL_Init(SDL_INIT_VIDEO | SDL_INIT_EVENTS);

	if (result < 0) {
		SDL_Log("SDL_Init error: %s", SDL_GetError());
		return -1;
	}

	window = SDL_CreateWindow(title, w, h, 0);

	if (window == NULL) {
		SDL_Log("SDL_CreateWindow error: %s", SDL_GetError());
		return -2;
	}

	renderer = SDL_CreateRenderer(window, NULL);
	if (renderer == NULL) {
		SDL_Log("SDL_CreateRenderer error: %s", SDL_GetError());
		return -3;
	}

	SDL_Log("Window Initialized successfully");

	SDL_Event event;
	int quit = 0;
	while (!quit) {
		while (SDL_PollEvent(&event))
		{
			switch (event.type)
			{
				case SDL_EVENT_QUIT:
					SDL_Log("SDL EVENT QUIT");
					quit = 1;
					break;	
			}
		}

		SDL_SetRenderDrawColor(renderer, 0, 0, 0xff, 0xff);
		SDL_RenderClear(renderer);
		SDL_RenderPresent(renderer);
		SDL_Delay(1);
	}

	SDL_DestroyRenderer(renderer);
	SDL_DestroyWindow(window);
	SDL_Quit();

	SDL_Log("Window Closed");
}

