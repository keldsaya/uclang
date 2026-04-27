# uclang

**A Unity C# framework that makes game development feel like C.**

> *"Real programmers use unsafe code and like it."*

## Philosophy

This framework doesn't try to hide what's happening. No abstractions, no magic, no "design patterns" that add 17 layers between you and your game logic. Just functions, pointers, and structs that actually make sense.

- **Explicit over clever** - You want a string copy? Here's `strcpy` with actual pointers.
- **No allocations for the sake of it** - Use `snprintf` to build strings, not string concatenation that allocates every time.
- **C semantics** - `btoi` works like a real boolean-int. `true`, `false`, `1`, `0` — it's all the same.
- **Unity when you need it** - But wrapped in types that don't make you vomit. `vec3`, not `Vector3`. `quat`, not `Quaternion`.
- **Editor support** - Because even C programmers need nice inspectors.

## What's Inside

### Math (`include.math`)
```csharp
vec3 pos = new vec3(10, 5, 2);
vec3 dir = (target - pos).normalized();
float dist = vec3.dist(pos, target);

// Or do it the old way
float t = min(max((val - minVal) / (maxVal - minVal), 0f), 1f);

btoi isAlive = 1;    // true
btoi isDead = false; // 0
if (isAlive && !isDead) { /* ... */ }
```

### Input (`include.input`)
```csharp
if (input_key_down(KeyCode.Space)) {
    // jump
}

float horiz = input_axis_raw("Horizontal");  // no smoothing, just raw
```

### Console I/O (`include.stdio`)
```csharp
printf("Player %d at position %f, %f, %f", id, pos.x, pos.y, pos.z);
string msg = snprintf("Health: %d/%d", current, max);
```

### Quaternions (`include.math`)
```csharp
quat rotation = quat.euler(0, 90, 0);
quat lookAt = quat.look_rotation(forward, up);
vec3 rotatedPoint = lookAt * somePoint;
```

### Cursor Control (`include.cursor`)
```csharp
cur_state = cur_lock_mode_t.locked;  // FPS style
cur_visible = false;
```

### Application Info (`include.app`)
```csharp
if (app_is_focus) { /* game is in foreground */ }
string savePath = app_persis_data + "/save.dat";
```

## Setup

1. Copy the source folder into your Unity project's `Assets/uclang`
2. **IMPORTANT**: Enable unsafe code
   - Go to `Edit` → `Project Settings` → `Player` → `Other Settings`
   - Check `Allow 'unsafe' Code`

## Why?

Unity's C# APIs are fine. But sometimes you just want to write:

```csharp
vec3 velocity = velocity + gravity * time_delta;
```

Instead of:

```csharp
Vector3 velocity = velocity + Physics.gravity * Time.deltaTime;
```

And sometimes you want a boolean that acts like an integer because you're porting from C and you don't want to rewrite everything.

This framework is for:
- Game jammers who want to move fast
- C programmers forced to use Unity
- Anyone tired of `Mathf`, `Vector3.Distance`, and `Time.deltaTime` being in different namespaces
- People who think `using static` is a band-aid for a broken API

## Types

| Framework | Unity | Note |
|-----------|-------|------|
| `vec2` | `Vector2` | Float vector |
| `vec3` | `Vector3` | Float vector |
| `vec2i` | `Vector2Int` | Integer vector |
| `vec3i` | `Vector3Int` | Integer vector |
| `quat` | `Quaternion` | Rotation |
| `btoi` | `bool` | But acts like int too |

## Editor Support

All custom types have PropertyDrawers. They show up in the inspector exactly like their Unity counterparts.

- `vec2` → Vector2 field
- `vec3` → Vector3 field  
- `quat` → Euler angles (because who edits quaternions directly?)
- `btoi` → Toggle

## Notes

- The `strcpy` function uses actual unsafe pointers. Be careful.
- `strlen` takes a managed string but fixes it in memory. Works fine.
- `printf` outputs to `Debug.Log` — you're still in Unity land.
- Yes, `time_fixed_delta` has a setter. Change physics timestep at runtime.

---

*"C is quirky, flawed, and an enormous success."* — Dennis Ritchie

*This framework is too.*
