cmake_minimum_required(VERSION 3.14)

# Project definition
project(Amlil LANGUAGES C CSharp)

# Enable FetchContent for dependencies
include(FetchContent)

# Fetch Raylib
FetchContent_Declare(
    raylib
    GIT_REPOSITORY https://github.com/raysan5/raylib.git
    GIT_TAG 5.5  # Replace with the latest version as needed
)
FetchContent_MakeAvailable(raylib)

# Set output directories for libraries and executables
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Add subdirectories
add_subdirectory(Core)
add_subdirectory(Framework)
