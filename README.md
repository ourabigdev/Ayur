# Ayur Framework

**Ayur** is a lightweight, simple 2D game development framework for C# (.NET 10+) inspired by p5.js and Processing.

## 🎯 Philosophy

- **Simplicity** - Minimal API, easy to learn and use
- **Performance** - Lightweight and fast using SDL3
- **Clarity** - Well-documented, readable code with inline comments
- **Safety** - .NET 10 nullable reference types prevent null errors
- **Cross-Platform** - Works on Windows, Linux, and macOS

## ✨ What You Can Do

- Create 2D games and interactive graphics
- Draw shapes (rectangles, circles, lines)
- Load and render images (PNG, JPG, BMP)
- Handle window events
- Use a simple game loop (Load, Update, Render) at 60 FPS

## 🚀 Quick Start

```csharp
using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

public class MyGame : Game
{
    private RectangleShape? box;  // Nullable - initialized in Load()

    public override void Load()
    {
        box = new RectangleShape(100, 100, 50, 50, AyurColor.Red);
    }

    public override void Update(float dt)
    {
        box!.X += 100 * dt; // Move 100 pixels per second
    }

    public override void Render()
    {
        box?.Render(Window!.renderer);
    }
}

// In Program.cs
var game = new MyGame();
var runner = new GameRunner(game);
runner.Init("My Game", 800, 600, AyurColor.Black);
runner.Run();
```

## 📦 Requirements

- **.NET 10+** ([Download](https://dotnet.microsoft.com/download))
- **C# IDE** (Visual Studio, VS Code, Rider, etc.)
- SDL3 (automatically installed via NuGet)

## 📚 Documentation

- **[GETTINGSTARTED.md](./GETTINGSTARTED.md)** - Setup and first game tutorial
- **[DOCS.md](./DOCS.md)** - Complete API reference
- **[FEATURES.md](./FEATURES.md)** - What's implemented and what's planned

## 🏗️ Project Structure

```
Ayur/
├── Core/
│   ├── Game.cs         # Base class - override Load/Update/Render
│   ├── GameRunner.cs   # Main loop (Poll -> Update -> Render)
│   ├── Window.cs       # SDL3 wrapper
│   └── AyurEvent.cs    # Event system
├── Rendering/
│   ├── AyurColor.cs    # RGBA colors with 8 presets
│   ├── Texture.cs      # Image loading
│   └── Shapes/
│       ├── Shape.cs
│       ├── RectangleShape.cs
│       ├── CircleShape.cs
│       └── LineShape.cs
├── Program.cs          # Entry point
└── MyGame.cs           # Example game (fully documented)
```

## 💡 Key Features

✅ **Simple Game Loop** - Load, Update, Render lifecycle
✅ **60 FPS Frame Control** - Smooth animations
✅ **Basic Shapes** - Rectangles, circles, lines
✅ **Image Loading** - PNG, JPG, BMP support
✅ **Color System** - 8 presets + custom colors
✅ **Cross-Platform** - Windows, Linux, macOS
✅ **Type-Safe** - .NET 10 nullable reference types
✅ **Well-Documented** - Every class has detailed comments

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

# Check version
dotnet --version  # Must be 10.0.0+
```

## 📋 Supported Platforms

- ✅ **Windows** (10/11, 64-bit and AnyCPU)
- ✅ **Linux** (Ubuntu, Fedora, Debian, etc.)
- ✅ **macOS** (Intel & Apple Silicon)

SDL3 handles platform-specific code automatically.

## 🌟 Why Ayur?

Unlike MonoGame or Godot, Ayur is:
- **Lighter** - No bloated editor or complex systems
- **Simpler** - Easier to understand the source code (~400 LOC)
- **Faster to learn** - Similar to p5.js but in C#
- **Perfect for** - Creative coding, prototyping, learning, game jams

## ⚙️ Technical Details

- **Language:** C# (.NET 10)
- **Graphics:** SDL3 (cross-platform rendering)
- **Images:** SDL3_image (PNG, JPG, BMP, etc.)
- **Frame Rate:** Fixed 60 FPS
- **Architecture:** Single-threaded, event-driven
- **Safety:** Nullable reference types enabled

## 📄 License

MIT License - Use freely in your projects

## 🤝 Contributing

We welcome contributions! Please keep in mind:
- Simplicity first - no complex abstractions
- No MonoGame-like patterns
- Good documentation with inline comments
- Cross-platform support (Windows/Linux/macOS)
- Type-safe (leverage nullable reference types)

## 📞 Support

- Check **DOCS.md** for API reference
- Review **GETTINGSTARTED.md** for setup
- Look at **MyGame.cs** for code examples
- Browse source code - it's simple and readable!
- All classes have detailed XML documentation comments

---

Happy coding! 🎨
