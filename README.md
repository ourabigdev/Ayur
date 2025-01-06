# Ayur Framework

Ayur is a lightweight framework built on top of the **Raylib** framework, designed for **simple game development** and **creative coding**. The core functionality, such as rendering, is implemented in **C** for optimal performance, while the framework itself is designed in **C#** to provide an easy-to-use API for developers. 

> **Note:** The framework is still in its very early stages of development. It might switch to **SDL 3** or **SDL 3 GPU** if necessary to enhance performance or functionality.

---

## Features

- Core rendering and low-level operations in **C**.
- High-level, developer-friendly API in **C#**.
- Lightweight and suitable for rapid game development and creative coding.
- Seamless integration with Visual Studio and cross-platform support.
- Easy integration with future NuGet packages (to be released).
- **Future planned features** include:
  - Better API for C#.
  - Custom rendering.
  - UI system.
  - Shaders support.
  - Scene system.
  - GameObject or entity system.
  - Cleaner, more extensible code.
  - NuGet package releases.

> **Note:** This framework is designed to be small and fast, inspired by frameworks like **p5.js** and **Little JS**, with the goal of creating a tool that's lightweight yet capable of supporting the creation of full games. Although it doesn't intend to be used for high-end 3D games or very large 2D games (though that may be possible in the future), it aims to make game development more accessible and fun. **3D support may be added in the future.**

---

## Requirements

- **CMake** (minimum version: 3.14).
- A compatible C and C# compiler.
- Raylib (automatically fetched during the build process).

---

## Setup Process

### For Unix-Based Systems

1. **Install Dependencies:**

   ```bash
   sudo apt update
   sudo apt install build-essential cmake clang libglfw3-dev libgl1-mesa-dev
   ```

2. **Clone the Repository:**

   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

3. **Build the Framework:**

   ```bash
   mkdir build && cd build
   cmake ..
   make
   ```

4. **Run the Example Application:**

    ```
    dotnet run --project build/Framework/AyurCsharp.csproj
    ```
---

### For Visual Studio (Windows)

1. **Install Visual Studio:**

   - Download and install Visual Studio (Community Edition is sufficient).
   - During installation, select the following workloads:
     - Desktop development with C++.
     - .NET Desktop development.

2. **Clone the Repository:**

   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

3. **Build the Framework:**

   ```bash
   mkdir build && cd build
   cmake .. -G "Visual Studio 17 2022"
   ```

   - Open the generated solution file (`Ayur.sln`) in Visual Studio.
   - Build the solution using the desired configuration (Debug/Release).

4. **Run the Example Application:**

   - Locate the built executable in the output directory and run it.

---

## Contributions

Ayur is open to contributions. Feel free to fork the repository, submit issues, or open pull requests. Contributions can include bug fixes, feature enhancements, or documentation improvements.

---

## License

Ayur is released under the MIT License, which allows you to freely use, modify, and distribute the framework. See the [LICENSE](https://github.com/ourabigdev/Ayur/blob/master/LICENSE) file for more details.

## Developer
Ayur is developed and maintained by ourabigdev(hatim).


