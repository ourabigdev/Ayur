# Add the C# executable project
add_executable(AmlilCSharp Program.cs Graphics.cs Core.cs AmlilColor.cs Colors.cs)

# Link the C# project with the core library
target_link_libraries(AmlilCSharp PRIVATE AmlilCore)

# Ensure the Amlil.dll is copied to the C# runtime directory
add_custom_command(TARGET AmlilCSharp POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
    COMMAND ${CMAKE_COMMAND} -E copy
    $<TARGET_FILE:AmlilCore>
    ${CMAKE_RUNTIME_OUTPUT_DIRECTORY}/Debug
)
