# Add the C# executable project
add_executable(AyurCSharp Program.cs Core.cs)

# Link the C# project with the core library
target_link_libraries(AyurCSharp PRIVATE AyurCore)

# Ensure the Ayur.dll is copied to the C# runtime directory
add_custom_command(TARGET AyurCSharp POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
    COMMAND ${CMAKE_COMMAND} -E copy
    $<TARGET_FILE:AyurCore>
    ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
)
