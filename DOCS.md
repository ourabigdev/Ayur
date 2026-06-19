# Ayur Framework Documentation

## Overview

**Ayur** is a lightweight, simple 2D game development framework built on SDL3. Inspired by p5.js and Processing, it provides an intuitive API for creating interactive graphics and games in C#.

## Philosophy

- **Simplicity**: Minimal API surface, easy to learn
- **Performance**: Lightweight and fast
- **Clarity**: Well-documented, readable code

## Core Concepts

### Game Loop

Every Ayur game follows this lifecycle:

1. **Load()** - Called once at startup. Load resources here.
2. **Update(dt)** - Called every frame. Update game logic here.
3. **Render()** - Called every frame. Draw graphics here.

### The Game Class

Create your game by inheriting from `Game`:

```csharp
public class MyGame : Game
{
    public override void Load() { }
    public override void Update(float dt) { }
    public override void Render() { }
}
```

### Running Your Game

Use `GameRunner` to run your game:

```csharp
var game = new MyGame();
var runner = new GameRunner(game);
runner.Init("My Game", 800, 600, AyurColor.Black);
runner.Run();
```

---

## API Reference

### Colors (Ayur.Rendering)

#### AyurColor

Represents an RGBA color (Red, Green, Blue, Alpha).

```csharp
// Create custom color
var myColor = new AyurColor(255, 128, 0); // Orange

// Use predefined colors
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

### Shapes (Ayur.Rendering.Shapes)

#### RectangleShape

Draw rectangles (filled or outlined).

```csharp
// Filled rectangle
var rect = new RectangleShape(x: 50, y: 50, width: 200, height: 100, 
                               color: AyurColor.Blue, filled: true);

// Outlined rectangle
var outline = new RectangleShape(x: 50, y: 50, width: 200, height: 100, 
                                  color: AyurColor.Red, filled: false);

// Render
rect.Render(Window.renderer);
```

**Properties:**
- `X`, `Y` - Position
- `Width`, `Height` - Size
- `Color` - Draw color
- `Filled` - Fill or outline

#### CircleShape

Draw filled circles.

```csharp
var circle = new CircleShape(x: 400, y: 300, radius: 50, color: AyurColor.Green);
circle.Render(Window.renderer);
```

**Properties:**
- `X`, `Y` - Center position
- `Radius` - Circle radius
- `Color` - Draw color

#### LineShape

Draw lines between two points.

```csharp
var line = new LineShape(x1: 0, y1: 0, x2: 100, y2: 100, color: AyurColor.White);
line.Render(Window.renderer);
```

**Properties:**
- `X1`, `Y1` - Start point
- `X2`, `Y2` - End point
- `Color` - Line color

### Textures (Ayur.Rendering)

#### Texture

Load and render images.

```csharp
var texture = new Texture();
texture.LoadFromFile("image.png", Window.renderer, Window.window);

// Render at position
texture.Render(x: 100, y: 100);

// Render with custom size
texture.Render(x: 100, y: 100, width: 200, height: 150);

// Check if loaded
if (texture.IsLoaded())
    Console.WriteLine("Texture ready!");

// Get dimensions
int w = texture.GetWidth();
int h = texture.GetHeight();
```

**Supported formats:** PNG, JPG, BMP, and other formats supported by SDL3_image.

### Core Classes (Ayur.Core)

#### Game

Base class for your game. Override these methods:

```csharp
public override void Load()    { /* Load resources */ }
public override void Update(float dt) { /* Update logic */ }
public override void Render()  { /* Draw graphics */ }
```

Access the window via `Window` property:
```csharp
var renderer = Window.renderer;
var windowPtr = Window.window;
```

#### GameRunner

Manages the main game loop.

```csharp
var runner = new GameRunner(game);
runner.Init("Title", 800, 600, backgroundColor);
runner.Run(); // Blocks until game exits
```

#### Window

Internal window management (accessed via `Game.Window`).

**Properties:**
- `renderer` - SDL renderer pointer
- `window` - SDL window pointer
- `BackgroundColor` - Background color

---

## Example: Interactive Shape Demo

```csharp
using Ayur.Core;
using Ayur.Rendering;
using Ayur.Rendering.Shapes;

public class ShapeDemo : Game
{
    private RectangleShape rect;
    private CircleShape circle;
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
        rect.X = moveX;
    }

    public override void Render()
    {
        rect.Render(Window.renderer);
        circle.Render(Window.renderer);
    }
}
```

---

## Tips & Best Practices

1. **Keep Load() lightweight** - Only load what you need
2. **Use dt in Update()** - For frame-rate independent movement:
   ```csharp
   x += velocity * dt;
   ```
3. **Batch rendering** - Group similar draws together in Render()
4. **Debug with colors** - Use different colors to visualize areas
5. **Check texture loading** - Always verify `IsLoaded()` before rendering

---

## Performance Considerations

- The framework runs at 60 FPS by default
- Avoid creating objects in Update() or Render() - create once in Load()
- Circle rendering uses pixel-by-pixel approach (acceptable for small circles)
- Use SDL3 renderer directly for advanced rendering needs

---

## Cross-Platform Notes

### Windows
- Fully supported (Windows 10/11)
- SDL3 handles DirectX/Vulkan rendering automatically

### Linux
- Fully supported (Ubuntu, Fedora, Debian, etc.)
- SDL3 uses OpenGL or Wayland depending on system
- Install SDL3 dev libraries if needed:
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
- Check file path is correct
- Ensure image format is supported
- Verify file exists and is readable

**Q: Game is slow**
- Check if you're creating objects every frame
- Reduce circle radius for better performance
- Profile your Update() method

**Q: Colors look wrong**
- Ensure RGBA values are in 0-255 range
- Check alpha value (255 = opaque, 0 = transparent)

**Q: SDL library not found on Linux**
- Install SDL3 development files
- Run `dotnet restore` again

---

## Next Steps

- See [FEATURES.md](./FEATURES.md) for what's implemented and planned
- Check [GETTINGSTARTED.md](./GETTINGSTARTED.md) for setup instructions
- View `MyGame.cs` for a working example
