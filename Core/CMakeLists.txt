# Add the shared library for the core
add_library(AyurCore SHARED framework.c framework.h spriteAnimation.c)

# Include Raylib headers
target_include_directories(AyurCore PUBLIC ${raylib_SOURCE_DIR}/src)

# Link Raylib with the core library
target_link_libraries(AyurCore PUBLIC raylib)

# Set output properties for the shared library
set_target_properties(AyurCore PROPERTIES
    OUTPUT_NAME "Ayur"  # DLL/Shared library name
)

# Post-build step: Copy the DLL to the runtime directory
add_custom_command(TARGET AyurCore POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
    COMMAND ${CMAKE_COMMAND} -E copy
    $<TARGET_FILE:AyurCore>
    ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
)
