# Ayur Features

## ✅ Implemented

### Core
- **Game Loop** - Load, Update, Render lifecycle
- **Window Management** - Create windows with SDL3
- **Frame Rate Control** - 60 FPS frame limiting
- **Basic Events** - Quit event support
- **Cross-Platform** - Windows, Linux, macOS support via SDL3

### Rendering
- **Colors (AyurColor)** - RGBA color system with presets
- **Shapes**
  - Rectangles (filled and outlined)
  - Circles (filled)
  - Lines
- **Textures** - Load and render images (PNG, JPG, BMP, etc.)

### API Design
- Lightweight and simple
- Inspired by p5.js philosophy
- Minimal learning curve

---

## 🛠 In Progress / Planned

### Rendering
- Triangle shapes
- Polygon rendering
- Sprite batching for performance
- Text rendering
- Rotation and scaling

### Input
- Keyboard event support
- Mouse input (position, clicks, scroll)
- Gamepad/joystick support
- Input state polling

### Advanced Features
- Sprite animation system
- Basic 2D physics
- Sound support (basic audio playback)
- Particle system
- Camera/viewport system

### Quality of Life
- Shader support (custom vertex/fragment shaders)
- Better error messages
- Debug visualization tools
- Performance profiling

---

## 📋 Non-Goals

The following MonoGame-like features are intentionally NOT included:
- Complex component/entity systems
- Advanced physics engines
- 3D rendering
- Networking
- Full audio mixer
- Complex resource management
- Visual editor or IDE

**Why?** Ayur is designed to be **lightweight and simple**, not a full-featured engine. It's perfect for learning, prototyping, and creative coding—not AAA games.

---

## Contributing

Want to add a feature? Here's what we prioritize:
1. **Simplicity** - Does it add complexity? Probably no.
2. **Performance** - Is it fast and lightweight?
3. **Necessity** - Is it essential for game development?
4. **Consistency** - Does it fit Ayur's design philosophy?
5. **Cross-Platform** - Does it work on Windows, Linux, macOS?

Before implementing, open an issue to discuss!
