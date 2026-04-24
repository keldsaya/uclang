# uclang
Unity C Language — a lightweight, C-style framework layer for Unity that brings familiar low-level idioms into C# game development without sacrificing the Unity ecosystem.

## Philosophy

uclang is not a new language — it's a syntactic and semantic overlay built with C# structs, static utilities, and custom drawers. It lets you write game logic that feels like C, while running natively inside Unity.

> No wrappers for the sake of wrappers. Every include has a purpose.

## Core Modules

### `include.math_h`
C-style math utilities, vector/Quaternion types with implicit conversions to Unity types.

| Type | Description |
|------|-------------|
| `vec2`, `vec3` | Float vectors with `.mag()`, `.normalized()`, `dot`, `cross`, `lerp` |
| `vec2i`, `vec3i` | Integer vectors, convertible to `Vector2Int` / `Vector3Int` |
| `quat` | Quaternion with `.euler_angles`, `look_rotation`, `angle_axis`, operators |
| `math` | `min`, `max`, `clamp`, `clamp01`, `lerp`, `inv_lerp`, `step`, `pow`, `sin`, `cos`, `sqrt`, `abs`, `round` |
| `btoi` | Boolean-integer hybrid — implicitly converts to/from `bool` and `int`, supports `true`/`false` operators |

### `include.stdio_h`
Debug output with C printf style.
```
stdio.printf("Hello %s", "world!");
```

### `include.time_h`
Unity Time wrapped in C-style static properties.
```
float dt = time.delta;
float now = time.val;
time.scale = 0.5f;
```

### `include.input_h`
Raw input access.
```
if (input.key_down(KeyCode.R))
if (input.mouse(0))
float strafe = input.axis("Horizontal");
```
### `include.cursor_h`
Cursor state management.
```
cursor.state = cur_lock_mode.locked;
bool vis = cursor.visible;
```

### `include.app_h`
Application context.
```
if (app.is_playing && app.is_focus)
string savePath = app.persis_data;
```

## Custom Data Types
### `btoi`

A boolean that acts like an integer in expressions. Useful for low-level state flags.
```
btoi chambered = false;
chambered = 1;           /* true */
int value = chambered;   /* 1 */
if (chambered) { }       /* works as bool */
```

## Editor Integration
Custom property drawers for all vector types, quat (displayed as Euler angles), and btoi (toggle).
No extra setup — just attach a script and see clean vectors in the Inspector.

## [[LICENSE]]


