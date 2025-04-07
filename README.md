# 🌿 Ayur Framework

**Ayur** is a lightweight, cross-platform **2D game** and **creative coding framework** built entirely in **C#** using **SDL3** (via a C# wrapper). It focuses on **ease of use**, **rapid development**, and **creative control**, while giving you the power to go low-level when needed.

> ⚠️ **Note:** Ayur is currently in very early development. Many features are still being implemented, and the API may change significantly as the framework evolves. Expect limited platform support and frequent updates as development progresses and knowledge grows.

---

## 🚀 Overview

- ✅ Written in **pure C#** — no C/C++ compilation needed
- 🔌 Built on **SDL3**, offering performance and portability
- ✨ Focused on **ease of use** (like Raylib), with power under the hood
- 💼 Designed for **games**, **tools**, and **creative coding**
- 🖠️ Development is active, evolving rapidly

---

## ✨ Features

Organized by development status:

### ✅ Almost Done

- 🪟 **Windowing Support**  
  Easy SDL3-based window creation and handling

- 🎨 **Color System**  
  Powerful `AyurColor` class with RGBA support (predefined colors coming soon)

### 🛠 In Progress

- 🫰 **Basic Event Handling**  
  SDL_QUIT working; more events like keyboard and mouse coming

- 🖼️ **Basic Image Loading**  
  Initial texture loading support using SDL_Surface and SDL_Texture

- 🎮 **Basic Input Handling**  
  Basic keyboard/mouse input is functional; expansion planned

### 🌱 Future Features

#### 🎮 Game & Rendering
- 🎞️ Animation system (sprite-based)
- 💡 Shader support (custom fragment & vertex shaders)
- 🧱 Vertex & Texture API (like SFML's vertex arrays)
- 🦨 Basic 3D support (via SDL3 GPU)

#### 🔌 Extensibility
- 🧍 Plugin/Extension system
- 🧠 Full customization via SDL3 or wrapper APIs (input maps, rendering hooks, etc.)

#### 🛠 Tools & Platform
- 🌐 Better cross-platform support (Linux, macOS)
- ⚙️ CLI tool to create/build/publish projects
- 🪟 Advanced window manipulation
- 🖼️ Advanced image manipulation & format support
- 🎮 Full input & event system (gamepad, remapping, etc.)

---

## 🧪 Example: Opening a Window

Here’s how easy it is to open a window with Ayur:

```csharp
using Ayur;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var window = new Window();
        if (!window.Init())
        {
            return;
        }

        if (!window.CreateWindowAndRender("hello", 800, 600, new AyurColor(100, 149, 237)))
        {
            return;
        }

        var loop = true;
        AyurEvent e;

        while (loop)
        {
            while (window.PollEvent(out e))
            {
                if (e.Type == AyurEventType.Quit)
                {
                    loop = false;
                }
            }

            window.Clear();
            window.Present();
        }

        window.Destroy();
        window.Quit();
    }
}
```

---

## 📦 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- C# IDE (e.g. Visual Studio, VS Code)
- SDL3 (included via C# wrapper — no native setup needed)

---

## 🛠️ Getting Started

### 🚟 Windows

1. **Install .NET 8**  
   https://dotnet.microsoft.com/en-us/download

2. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/ayur-framework.git
   cd ayur-framework
   ```

3. **Open in Visual Studio or VS Code**  
   Open the `.sln` file and build the solution.

4. **Run an example**
   ```bash
   dotnet run --project AyurCsharp/AyurCsharp.csproj
   ```

> 💡 Linux & macOS support will require manual work for now.

---

## 📌 Development Status

Ayur is still in **very early development**, and many features are yet to be implemented.  
The API is expected to **change frequently**, and may look very different in future releases.

> I'm still actively learning and experimenting to make Ayur as powerful and beginner-friendly as possible — thanks for your patience!

---

## 🤝 Contributing

Ayur is open-source and welcomes all contributors. You can:

- 🐛 Report bugs
- 💡 Suggest features
- 🔧 Submit pull requests

Every contribution counts!

---

## 👤 Core Contributor

Made with ❤️ by:

**[@ourabigdev (hatim)](https://github.com/ourabigdev)**  
Founder, Lead Developer, and Core Maintainer of Ayur Framework

---

## 📜 License

Released under the **MIT License**.  
Free to use, modify, and distribute.  
See [LICENSE](./LICENSE) for details.

---

