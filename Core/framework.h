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
#include <stdio.h>
#define SDL_MAIN_HANDLED
#include <SDL3/SDL.h>
#include <SDL3//SDL_main.h>


// Framework functions
FRAMEWORK_API void Window(const char* title, int w, int h);
FRAMEWORK_API void Quit();

#endif // FRAMEWORK_H
