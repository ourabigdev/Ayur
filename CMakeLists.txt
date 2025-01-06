cmake_minimum_required(VERSION 3.21)  # Use at least 3.21 to ensure compatibility

# Project definition
project(Ayur LANGUAGES C CSharp)

# Enable FetchContent for dependencies
include(FetchContent)

# Fetch Raylib
FetchContent_Declare(
    raylib
    GIT_REPOSITORY https://github.com/raysan5/raylib.git
    GIT_TAG 5.5  # Replace with the desired version if necessary
)

# Ensure dependencies are configured properly
set(FETCHCONTENT_QUIET OFF)  # Show progress during fetching
set(BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)  # Disable Raylib examples
set(BUILD_SHARED_LIBS OFF CACHE BOOL "" FORCE)  # Use static Raylib

FetchContent_MakeAvailable(raylib)

# Set output directories for libraries and executables
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

# Add subdirectories
add_subdirectory(Core)
add_subdirectory(Framework)
