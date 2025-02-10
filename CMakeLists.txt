cmake_minimum_required(VERSION 3.21)
project(Ayur LANGUAGES C CSharp)

include(FetchContent)

# Fetch SDL3
FetchContent_Declare(
    SDL
    GIT_REPOSITORY https://github.com/libsdl-org/SDL.git
    GIT_TAG release-3.2.4  # Change to the latest version if needed
)

# Ensure SDL is built properly
set(SDL_SHARED OFF CACHE BOOL "" FORCE)  # Disable shared SDL
set(SDL_STATIC ON CACHE BOOL "" FORCE)   # Enable static SDL
set(SDL_TEST OFF CACHE BOOL "" FORCE)    # Disable SDL test programs

FetchContent_MakeAvailable(SDL)

# Set output directories
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Add subdirectories
add_subdirectory(Core)
add_subdirectory(Framework)
