# Add the shared library for the core
add_library(AyurCore SHARED framework.c framework.h)

# Include SDL3 headers
target_include_directories(AyurCore PUBLIC ${SDL_SOURCE_DIR}/include)

# Link SDL3 with the core library
target_link_libraries(AyurCore PUBLIC SDL3-static)

# Set output properties for the shared library
set_target_properties(AyurCore PROPERTIES OUTPUT_NAME "Ayur")

# Post-build step: Copy the DLL to the runtime directory
add_custom_command(TARGET AyurCore POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
    COMMAND ${CMAKE_COMMAND} -E copy
    $<TARGET_FILE:AyurCore>
    ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
)
