# Ayur Framework

**Ayur** is a lightweight, simple 2D game development framework for C# inspired by p5.js and Processing.

## 🎯 Philosophy

- **Simplicity** - Minimal API, easy to learn and use
- **Performance** - Lightweight and fast using SDL3
- **Clarity** - Well-documented, readable code
- **Cross-Platform** - Works on Windows, Linux, and macOS

## ✨ What You Can Do

- Create 2D games and interactive graphics
- Draw shapes (rectangles, circles, lines)
- Load and render images
- Handle window events
- Use a simple game loop (Load, Update, Render)

## 🚀 Quick Start

```csharp
using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

public class MyGame : Game
{
    private RectangleShape box;

    public override void Load()
    {
        box = new RectangleShape(100, 100, 50, 50, AyurColor.Red);
    }

    public override void Update(float dt)
    {
        box.X += 100 * dt; // Move 100 pixels per second
    }

    public override void Render()
    {
        box.Render(Window.renderer);
    }
}

// In Program.cs
var game = new MyGame();
var runner = new GameRunner(game);
runner.Init("My Game", 800, 600, AyurColor.Black);
runner.Run();
```

## 📦 Requirements

- **.NET 8+** ([Download](https://dotnet.microsoft.com/download))
- **C# IDE** (Visual Studio, VS Code, Rider, etc.)
- SDL3 (automatically installed via NuGet)

## 📚 Documentation

- **[GETTINGSTARTED.md](./GETTINGSTARTED.md)** - Setup and first game tutorial
- **[DOCS.md](./DOCS.md)** - Complete API reference
- **[FEATURES.md](./FEATURES.md)** - What's implemented and what's planned

## 🏗️ Project Structure

```
Ayur/
├── Core/           # Game loop and window
├── Rendering/      # Graphics and colors
├── Rendering/Shapes/  # Drawable shapes
├── Program.cs      # Entry point
└── MyGame.cs       # Example game
```

## 💡 Key Features

✅ Simple Game Loop - Load, Update, Render lifecycle
✅ 60 FPS Frame Control - Smooth animations
✅ Basic Shapes - Rectangles, circles, lines
✅ Image Loading - PNG, JPG, BMP support
✅ Color System - Predefined and custom colors
✅ Cross-Platform - Windows, Linux, macOS

## 🎮 Example Games

Check out `MyGame.cs` for a working example with shapes and textures.

## 🔧 Development

```bash
# Clone the repository
git clone https://github.com/yourusername/Ayur.git
cd Ayur

# Restore dependencies
dotnet restore

# Run the example
dotnet run

# Build for release
dotnet build -c Release
```

## 📋 Supported Platforms

- ✅ **Windows** (10/11)
- ✅ **Linux** (Ubuntu, Fedora, Debian)
- ✅ **macOS** (Intel & Apple Silicon)

SDL3 handles platform-specific code automatically.

## 🌟 Why Ayur?

Unlike MonoGame or Godot, Ayur is:
- **Lighter** - No bloated editor or complex systems
- **Simpler** - Easier to understand the source code
- **Faster to learn** - Similar to p5.js but in C#
- **Perfect for** - Creative coding, prototyping, learning

## 📄 License

MIT License - Use freely in your projects

## 🤝 Contributing

We welcome contributions! Please keep in mind:
- Simplicity first
- No MonoGame-like complexity
- Good documentation
- Cross-platform support

## 📞 Support

- Check **DOCS.md** for API reference
- Review **GETTINGSTARTED.md** for setup
- Look at **MyGame.cs** for examples

---

Happy coding! 🎨
