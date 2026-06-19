# Getting Started with Ayur

Welcome to Ayur! This guide will help you set up your first game in minutes.

## Prerequisites

- **.NET 10 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **C# IDE** (Visual Studio, VS Code, or any C# editor)
- A terminal/command line

## Setup (5 minutes)

### Step 1: Clone or Download

```bash
git clone https://github.com/yourusername/Ayur.git
cd Ayur
```

### Step 2: Install Dependencies

Dependencies are automatically managed by NuGet. Just open the project in your IDE or run:

```bash
dotnet restore
```

### Step 3: Run the Example

```bash
dotnet run
```

You should see a window with shapes displayed!

---

## Create Your First Game

### Step 1: Create a New Game Class

Create a file called `FirstGame.cs`:

```csharp
using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

public class FirstGame : Game
{
    private RectangleShape? box;  // Nullable - initialized in Load()

    public override void Load()
    {
        // Create a red rectangle
        box = new RectangleShape(100, 100, 150, 150, AyurColor.Red, filled: true);
    }

    public override void Update(float dt)
    {
        // Move rectangle (moves 100 pixels per second to the right)
        box!.X += 100 * dt;  // ! tells compiler: trust me, box is not null
    }

    public override void Render()
    {
        // Draw the rectangle
        box?.Render(Window!.renderer);  // ?. safe null check
    }
}
```

### Step 2: Update Program.cs

Modify `Program.cs` to use your game:

```csharp
using Ayur.Core;
using Ayur.Rendering;

namespace Example;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var game = new FirstGame();  // Use your game
        var runner = new GameRunner(game);

        if (!runner.Init("My First Ayur Game", 800, 600, AyurColor.Black))
            return;

        runner.Run();
    }
}
```

### Step 3: Run It

```bash
dotnet run
```

You should see a red rectangle moving across the screen!

---

## Understanding Nullable References

.NET 10 uses **nullable reference types** for safety:

```csharp
// ? means "this can be null"
private RectangleShape? box;     // nullable
private RectangleShape rect;     // non-nullable (can't be null)

// ! tells compiler: trust me, it's not null here
box!.X = 100;                    // Assert it's not null

// ?. safely handles null
box?.Render(renderer);           // Won't call if box is null
```

This prevents null reference exceptions at compile time!

---

## Next: Draw More Shapes

Try adding different shapes:

```csharp
public class ShapesGame : Game
{
    private RectangleShape? rect;
    private CircleShape? circle;
    private LineShape? line;

    public override void Load()
    {
        // Rectangle
        rect = new RectangleShape(50, 50, 100, 100, AyurColor.Red);
        
        // Circle
        circle = new CircleShape(400, 300, 50, AyurColor.Blue);
        
        // Line
        line = new LineShape(0, 0, 800, 600, AyurColor.Green);
    }

    public override void Render()
    {
        rect?.Render(Window!.renderer);
        circle?.Render(Window.renderer);
        line?.Render(Window.renderer);
    }
}
```

---

## Common Patterns

### Moving Objects

```csharp
// Simple movement
box!.X += velocity * dt;
box.Y += verticalVelocity * dt;

// Bounce off walls
if (box.X < 0 || box.X > 800)
    velocity = -velocity;
```

### Using Colors

```csharp
var red = AyurColor.Red;
var custom = new AyurColor(255, 128, 0); // Orange
var transparent = new AyurColor(255, 0, 0, 128); // Semi-transparent red

shape!.Color = red; // Change color anytime
```

### Loading Images

```csharp
private Texture? playerSprite;

public override void Load()
{
    playerSprite = new Texture();
    playerSprite.LoadFromFile("Assets/player.png", Window!.renderer, Window.window);
}

public override void Render()
{
    if (playerSprite?.IsLoaded() == true)
    {
        playerSprite.Render(playerX, playerY);
    }
}
```

---

## Project Structure

```
Ayur/
├── Core/              # Game loop and window management
│   ├── Game.cs       # Base class for your game
│   ├── GameRunner.cs # Main loop (Poll events -> Update -> Render)
│   ├── Window.cs     # SDL3 window wrapper
│   └── AyurEvent.cs  # Event system
├── Rendering/        # Graphics
│   ├── AyurColor.cs  # RGBA color system with 8 presets
│   ├── Texture.cs    # Image loading and rendering
│   └── Shapes/       # Drawable shapes
│       ├── Shape.cs
│       ├── RectangleShape.cs
│       ├── CircleShape.cs
│       └── LineShape.cs
├── Program.cs        # Entry point
├── MyGame.cs         # Example game
└── README.md         # Overview
```

---

## Tips for Success

1. **Start simple** - Add one shape, get it working, then add more
2. **Use dt** - Always multiply movement by delta time for smooth animation
3. **Check your paths** - Image paths must be relative or absolute
4. **Use nullable types** - Mark fields with `?` if initialized in Load()
5. **Keep it small** - The best games start simple!

---

## Troubleshooting

**"DLL not found" or "SDL not found"**
- Run `dotnet restore` to install dependencies
- Make sure .NET 10+ is installed
- Run `dotnet --version` to check

**"Image won't load"**
- Check file path is correct (relative to working directory)
- Ensure image format is supported (PNG, JPG, BMP)
- Verify file permissions

**"Game is slow"**
- Avoid creating objects in Update() or Render()
- Profile your code
- Check Task Manager for CPU usage

**"Colors look weird"**
- RGBA values must be 0-255
- Alpha 255 = opaque, 0 = transparent
- Try using predefined colors first (Red, Blue, etc.)

**"Nullable reference type warnings"**
- Mark fields with `?` if they're not initialized in constructor
- Use `?.` for safe null-conditional access
- Use `!` to assert non-null (e.g., `Window!.renderer`)

---

## Next Steps

- 📚 Read [DOCS.md](./DOCS.md) for complete API reference
- 🎯 Check [FEATURES.md](./FEATURES.md) for what's available
- 🎮 Look at `MyGame.cs` for a working example
- 💡 Try building a simple game (bouncing ball, moving player, etc.)

---

## Get Help

- Check **DOCS.md** for API reference
- Review the example in **MyGame.cs**
- Look at the source code - it's simple and readable!
- All files have detailed comments

Happy coding! 🎨
