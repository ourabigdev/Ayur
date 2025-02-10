
# Ayur Framework 🌿

Ayur is a lightweight, **game development** and **creative coding** framework built on **Raylib** (for now). The core functionality is implemented in **C** for optimal performance, while the API is designed in **C#** for ease of use.

> **Note:** The framework is still in its early stages. We're currently working on a **switch to SDL3** (via the `SDL3_Switch` branch). The SDL3 GPU support will be used for future 3D features, but for now, the SDL3 version only supports windowing. 

---

## 🌟 Features

- **Core**: Written in **C** for performance (currently using Raylib for windowing and color support).
- **API**: Easy-to-use **C#** API for rapid development.
- **Lightweight**: Perfect for small games and creative coding.
- **Cross-platform**: Integrates seamlessly with **Visual Studio** and supports multiple platforms.
- **Future Plans**:
  - Improved **C# API**.
  - Custom rendering & shaders.
  - UI system.
  - Scene & Entity systems.
  - Full SDL3 support to replace Raylib entirely.

---

## 🔧 Requirements

- **CMake** (min. version 3.21)
- **C** and **C#** compilers.
- **Raylib** (automatically fetched during the build process for now).

---

## ⚙️ Setup Process

### Unix-Based Systems 🐧

1. **Install Dependencies**:
   ```bash
   sudo apt update
   sudo apt install build-essential cmake clang libglfw3-dev libgl1-mesa-dev
   ```

2. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

3. **Build the Framework**:
   ```bash
   mkdir build && cd build
   cmake ..
   make
   ```

4. **Run Example App**:
   ```bash
   dotnet run --project build/Framework/AyurCsharp.csproj
   ```

---

### Windows (Visual Studio) 🖥️

1. **Install Visual Studio**:
   - Download Visual Studio (Community Edition is fine).
   - Select the following workloads:
     - Desktop development with C++.
     - .NET Desktop development.

2. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

3. **Build the Framework**:
   ```bash
   mkdir build && cd build
   cmake .. -G "Visual Studio 17 2022"
   ```
   - Open `Ayur.sln` in Visual Studio.
   - Build the solution in **Debug** or **Release** mode.

4. **Run Example App**:
   - Locate the built executable and run it.

---

## 🤝 Contributions

Ayur is **open-source** and welcomes contributions! Feel free to:
- Fork the repo.
- Submit issues.
- Open pull requests.

---

## 📜 License

Ayur is released under the **MIT License**, allowing free usage, modification, and distribution. See the [LICENSE](https://github.com/ourabigdev/Ayur/blob/master/LICENSE) for more details.

---

## 👨‍💻 Developer

Developed and maintained by **ourabigdev** (hatim).
