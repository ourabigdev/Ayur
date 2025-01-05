# Add the shared library for the core
add_library(AmlilCore SHARED framework.c framework.h)

# Include Raylib headers
target_include_directories(AmlilCore PUBLIC ${raylib_SOURCE_DIR}/src)

# Link Raylib with the core library
target_link_libraries(AmlilCore PUBLIC raylib)

# Set output properties for the shared library
set_target_properties(AmlilCore PROPERTIES
    OUTPUT_NAME "Amlil"  # DLL/Shared library name
)

# Post-build step: Copy the DLL to the runtime directory
add_custom_command(TARGET AmlilCore POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
    COMMAND ${CMAKE_COMMAND} -E copy
    $<TARGET_FILE:AmlilCore>
    ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
)
