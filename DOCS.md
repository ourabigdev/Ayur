# Ayur Framework Documentation

## Overview

**Ayur** is a lightweight, simple 2D game development framework built on SDL3. Inspired by p5.js and Processing, it provides an intuitive API for creating interactive graphics and games in C# (.NET 10+).

## Philosophy

- **Simplicity**: Minimal API surface, easy to learn
- **Performance**: Lightweight and fast
- **Clarity**: Well-documented, readable code with inline comments
- **Safety**: .NET 10 nullable reference types prevent null errors

## Core Concepts

### Game Loop

Every Ayur game follows this lifecycle:

1. **Load()** - Called once at startup. Load resources here.
2. **Update(dt)** - Called every frame. Update game logic here.
3. **Render()** - Called every frame. Draw graphics here.

The `GameRunner` handles this automatically at 60 FPS.

### The Game Class

Create your game by inheriting from `Game`:

```csharp
public class MyGame : Game
{
    private RectangleShape? box;  // Nullable - initialized in Load()

    public override void Load() 
    { 
        box = new RectangleShape(0, 0, 50, 50, AyurColor.Red);
    }
    
    public override void Update(float dt) 
    { 
        box!.X += 100 * dt;  // ! asserts box is not null
    }
    
    public override void Render() 
    { 
        box?.Render(Window!.renderer);  // ?. safe null check
    }
}
```

**Important**: Fields initialized in `Load()` should be marked with `?` (nullable).

### Running Your Game

Use `GameRunner` to run your game:

```csharp
var game = new MyGame();
var runner = new GameRunner(game);
runner.Init("My Game", 800, 600, AyurColor.Black);
runner.Run();  // Blocks until window closes
```

---

## API Reference

### Colors (Ayur.Rendering)

#### AyurColor

Represents an RGBA color (Red, Green, Blue, Alpha).

```csharp
// Create custom color
var myColor = new AyurColor(255, 128, 0); // Orange
var transparent = new AyurColor(255, 0, 0, 128); // Red with 50% transparency

// Use predefined colors (8 available)
AyurColor.Red
AyurColor.Green
AyurColor.Blue
AyurColor.White
AyurColor.Black
AyurColor.Yellow
AyurColor.Cyan
AyurColor.Magenta
AyurColor.Gray
```

**Properties:**
- `r` - Red channel (0-255)
- `g` - Green channel (0-255)
- `b` - Blue channel (0-255)
- `a` - Alpha channel (0-255, 255=opaque)

### Shapes (Ayur.Rendering.Shapes)

All shapes inherit from `Shape` base class and require a renderer.

#### RectangleShape

Draw rectangles (filled or outlined).

```csharp
// Filled rectangle (default)
var rect = new RectangleShape(x: 50, y: 50, width: 200, height: 100, 
                              color: AyurColor.Blue, filled: true);

// Outlined rectangle
var outline = new RectangleShape(x: 50, y: 50, width: 200, height: 100, 
                                 color: AyurColor.Red, filled: false);

// Render
rect?.Render(Window!.renderer);
```

**Properties:**
- `X`, `Y` - Top-left position
- `Width`, `Height` - Size in pixels
- `Color` - Draw color
- `Filled` - True=filled, False=outline only

#### CircleShape

Draw filled circles.

```csharp
var circle = new CircleShape(x: 400, y: 300, radius: 50, color: AyurColor.Green);
circle?.Render(Window!.renderer);
```

**Properties:**
- `X`, `Y` - Center position
- `Radius` - Radius in pixels
- `Color` - Draw color

**Note:** Circles are rendered pixel-by-pixel using the midpoint circle algorithm. For small radii (<100px) this is fine. Larger circles may be slower.

#### LineShape

Draw lines between two points.

```csharp
var line = new LineShape(x1: 0, y1: 0, x2: 100, y2: 100, color: AyurColor.White);
line?.Render(Window!.renderer);
```

**Properties:**
- `X1`, `Y1` - Start point
- `X2`, `Y2` - End point
- `Color` - Line color

### Textures (Ayur.Rendering)

#### Texture

Load and render images.

```csharp
private Texture? sprite;

public override void Load()
{
    sprite = new Texture();
    if (!sprite.LoadFromFile("player.png", Window!.renderer, Window.window))
        Console.WriteLine("Failed to load image");
}

public override void Render()
{
    // Render at position (original size)
    sprite?.Render(100, 100);
    
    // Render at position with custom size
    sprite?.Render(100, 100, width: 64, height: 64);
}
```

**Methods:**
- `LoadFromFile(path, renderer, window)` - Load image, returns success/failure
- `Render(x, y)` - Draw at position (original size)
- `Render(x, y, width, height)` - Draw at position with custom size
- `GetWidth()` - Texture width in pixels
- `GetHeight()` - Texture height in pixels
- `IsLoaded()` - Check if texture is ready to render
- `Destroy()` - Free texture memory

**Supported formats:** PNG, JPG, BMP, and other formats supported by SDL3_image.

### Core Classes (Ayur.Core)

#### Game

Base class for your game. Override these methods:

```csharp
public override void Load()           { /* Load resources once */ }
public override void Update(float dt) { /* Update each frame */ }
public override void Render()         { /* Draw each frame */ }
```

**Properties:**
- `Window` - Access to window and renderer. May be null before Init() completes.
  ```csharp
  var renderer = Window!.renderer;  // ! asserts it's not null
  ```

#### GameRunner

Manages the main game loop.

```csharp
var runner = new GameRunner(game);

// Initialize window (must be called before Run())
if (!runner.Init("Title", width: 800, height: 600, backgroundColor: AyurColor.Black))
    return;  // Init failed

// Start game loop (blocks until window closes)
runner.Run();
```

**The game loop:**
1. Poll events (quit requests)
2. Call `game.Update(dt)`
3. Clear screen
4. Call `game.Render()`
5. Present frame
6. Limit to 60 FPS

#### Window (Internal)

Internal window management (accessed via `Game.Window`).

**Properties:**
- `window` - SDL3 window pointer (unsafe)
- `renderer` - SDL3 renderer pointer (unsafe)
- `BackgroundColor` - Background color

**Methods:**
- `Init()` - Initialize SDL3
- `CreateWindowAndRender()` - Create window and renderer
- `PollEvent()` - Poll next event
- `Clear()` - Clear screen
- `Present()` - Show frame
- `Destroy()` - Cleanup
- `Quit()` - Shutdown SDL3

---

## Example: Interactive Shape Demo

```csharp
using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

public class ShapeDemo : Game
{
    private RectangleShape? rect;
    private CircleShape? circle;
    private float moveX = 0;

    public override void Load()
    {
        rect = new RectangleShape(50, 50, 100, 100, AyurColor.Red);
        circle = new CircleShape(400, 300, 30, AyurColor.Blue);
    }

    public override void Update(float dt)
    {
        // Move rectangle
        moveX += 50 * dt; // Move 50 pixels per second
        if (moveX > 800) moveX = 0;
        rect!.X = moveX;
    }

    public override void Render()
    {
        rect?.Render(Window!.renderer);
        circle?.Render(Window.renderer);
    }
}
```

---

## Tips & Best Practices

1. **Keep Load() lightweight** - Only load what you need
2. **Use dt in Update()** - For frame-rate independent movement:
   ```csharp
   x += velocity * dt;  // Works at any frame rate
   ```
3. **Batch rendering** - Group similar draws together in Render()
4. **Debug with colors** - Use different colors to visualize areas
5. **Use nullable types** - Mark fields with `?` if initialized in Load()
6. **Check texture loading** - Always verify `IsLoaded()` before rendering

---

## Performance Considerations

- The framework runs at 60 FPS by default
- Avoid creating objects in Update() or Render() - create once in Load()
- Circle rendering uses pixel-by-pixel approach (acceptable for radius <100px)
- Use SDL3 renderer directly for advanced rendering needs
- Line rendering delegates to SDL3 (optimized)
- Rectangle rendering delegates to SDL3 (optimized)

---

## Nullable Reference Types (.NET 10)

Ayur uses .NET 10's nullable reference types for safety:

```csharp
// Nullable - can be null
private RectangleShape? box;    // OK to be null
internal Window? Window { get; set; }  // Can be null temporarily

// Non-nullable - cannot be null
private RectangleShape box;     // Must always have value

// Safety operators
box!.X = 100;      // ! (null-forgiving) - asserts it's not null
box?.Render();      // ?. (null-conditional) - safe if null

if (box?.IsValid() == true)  // ?. returns bool?
    // ...
```

This prevents null reference exceptions at compile time!

---

## Cross-Platform Notes

### Windows
- Fully supported (Windows 10/11, 64-bit and AnyCPU)
- SDL3 handles DirectX/Vulkan rendering automatically

### Linux
- Fully supported (Ubuntu, Fedora, Debian, etc.)
- SDL3 uses OpenGL or Wayland depending on system
- May need to install SDL3 dev libraries:
  ```bash
  sudo apt install libsdl3-dev libsdl3-image-dev
  ```

### macOS
- Fully supported (Intel & Apple Silicon)
- SDL3 uses Metal for rendering
- Works natively on both architectures

---

## Troubleshooting

**Q: Texture won't load**
- Check file path is correct (relative to working directory)
- Ensure image format is supported (PNG, JPG, BMP)
- Verify file exists and is readable
- Check console output for error messages

**Q: Game is slow**
- Check if you're creating objects every frame (move to Load())
- Reduce circle radius for better performance
- Profile your Update() method with Stopwatch

**Q: Colors look wrong**
- Ensure RGBA values are in 0-255 range
- Check alpha value (255 = opaque, 0 = transparent)
- Try pure colors first (Red, Green, Blue)

**Q: SDL library not found on Linux**
- Install SDL3 development files: `sudo apt install libsdl3-dev libsdl3-image-dev`
- Run `dotnet restore` again
- Verify .NET 10 is installed: `dotnet --version`

**Q: Nullable reference type warnings**
- Mark fields with `?` if initialized in Load() not constructor
- Use `?.` for safe null-conditional access
- Use `!` to assert non-null (use sparingly)
- Enable warnings: set `<Nullable>enable</Nullable>` in .csproj

---

## Next Steps

- See [FEATURES.md](./FEATURES.md) for what's implemented and planned
- Check [GETTINGSTARTED.md](./GETTINGSTARTED.md) for setup instructions
- View `MyGame.cs` for a working example with all code explained
- Browse the source code - every class has detailed comments!
