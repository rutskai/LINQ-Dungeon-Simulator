# Dungeon Crawler

> Juego de mazmorras por consola desarrollado en **C#** y hecho con **LINQ**. Explora habitaciones generadas proceduralmente, combate enemigos, visita tiendas, enfrenta un jefe final y guarda tu progreso entre sesiones.

---

## Tabla de Contenido

- Características
- Cómo iniciar el proyecto
- Requisitos
- Estructura del Proyecto
- Arquitectura
- Flujo del Juego
- Mecánicas
- Sistema de Guardado
- Utilidades

---

##  Características

-  Mazmorras generadas proceduralmente con enemigos, objetos y eventos aleatorios
-  Sistema de combate por turnos contra enemigos y jefe final
-  Inventario con objetos de rareza **Común**, **Raro** y **Épico**
-  Tienda interactiva con armas, pociones y mejoras permanentes
-  Eventos aleatorios: trampas, puzzles, fuentes, mercaderes y emboscadas
-  Guardado y carga de partidas persistente en **JSON**
-  Estadísticas finales detalladas al terminar la partida
-  Interfaz enriquecida con colores y efecto **typewriter**

---

## ⚙️ Requisitos

- .NET 7 o superior
- Consola con soporte de colores ANSI (Windows Terminal recomendado)

---

## Cómo iniciar el proyecto

1. Clona o descarga el repositorio
2. Abre una terminal en la carpeta raíz del proyecto
Ejecuta:
```
dotnet run
```


---

## 📁 Estructura del Proyecto

```
DungeonCrawler/
├── Models/          # Entidades del juego (Player, Enemy, Item, Room, Game)
├── Data/            # Datos estáticos (enemigos, items, eventos, tienda)
├── Generators/      # Generación procedural de mazmorras y partidas
├── Functions/       # Mecánicas: combate, tienda, eventos, flujo de juego
├── MenuManager/     # Pantallas y menús de interfaz
├── MenuHelpers/     # Soporte para menús y opciones
├── Save/            # Sistema de guardado/carga en JSON
└── Utils/           # Utilidades: Typewriter, inputs, pausas
```

---

## Arquitectura

### Models
| Clase | Propiedades destacadas |
|-------|----------------------|
| `Player` | `Name`, `Health`, `BaseDamage`, `Gold`, `Inventory`, `DefeatedEnemies` |
| `Enemy` | `Name`, `Health`, `Attack`, `Type`, `GoldReward` |
| `Item` | `Name`, `Type`, `Value`, `Rarity` |
| `Room` | `Id`, `Enemies`, `Items`, `Event` |
| `Game` | `Player`, `Rooms`, `CurrentRoomIndex`, `IsGameOver` |

### Functions
| Clase | Responsabilidad |
|-------|----------------|
| `GameFlow` | Ciclo principal de la partida (`MainGameLoop`, `LoadGameLoop`) |
| `Fight` | Combate por turnos jugador vs enemigos |
| `Boss` | Combate con el jefe final |
| `RoomAction` | Orquesta combate, recogida de objetos y eventos |
| `RoomEventHandler` | Aplica efectos de eventos de sala |
| `Shop` | Tienda interactiva con efectos inmediatos |
| `EndGame` | Estadísticas y pantalla final |

### Save
| Clase | Responsabilidad |
|-------|----------------|
| `SaveManager` | Guardar, cargar, eliminar y consultar partidas |
| `SaveData` | Modelo serializable del estado del juego |
| `ItemDTO` / `EnemyDTO` | DTOs para serialización JSON |

---

## Flujo del Juego

```
WelcomeScreen → Menú Principal → Nueva Partida / Cargar Partida
                                          ↓
                               ┌─── RunLoop ───────────────────┐
                               │  Mostrar stats                │
                               │  Mostrar habitación           │
                               │  Combate (si hay enemigos)    │
                               │  Recoger objetos              │
                               │  Evento de sala               │
                               │  Tienda (cada 2 habitaciones) │
                               │  💾 Guardado automático       │
                               │  Avanzar habitación           │
                               └───────────────────────────────┘
                                          ↓
                               Última habitación → Jefe Final
                                          ↓
                               Pantalla Final + Estadísticas
```

---

## Mecánicas

### Combate
- Turnos alternados jugador ↔ enemigo
- Daño aleatorio basado en `BaseDamage` / `Attack`
- Al derrotar enemigos se gana **Gold** según `GoldReward`
- Si `Health ≤ 0` → partida terminada

### Generación de Mazmorra
- **1–3 enemigos** por habitación (aleatorio)
- **0–1 objetos** por habitación (aleatorio)
- Evento aleatorio por sala (trampa, puzzle, fuente, mercader, emboscada)
- **Última habitación**: siempre Boss Fight, sin objetos ni enemigos normales

### Eventos de Sala
| Evento | Efecto |
|--------|--------|
| Healing Fountain | +30 vida |
| Merchant | +2 daño base |
| Trap | -10 vida |
| Puzzle | +15 vida |
| Ambush | Escape seguro |
| Boss Fight | Jefe final |

### Tienda
Aparece cada **2 habitaciones**. Ofrece 4 artículos aleatorios del catálogo:
-  **Armas** → aumentan daño base según rareza
-  **Pociones** → restauran vida (20 / 40 / 70 HP)
-  **Mejoras** → +3 daño base permanente

---

## 💾 Sistema de Guardado

- Guardado **automático** al salir de cada habitación
- Archivo: `savegame.json` en el directorio de ejecución
- Al terminar la partida (victoria o derrota) el guardado se **elimina automáticamente**
- Desde el menú se puede **cargar** o **eliminar** la partida guardada

---

## Utilidades

| Clase | Función |
|-------|---------|
| `Typewriter` | Efecto máquina de escribir con velocidades configurables (`Fast`, `Normal`, `Slow`, `Dramatic`) y `FlushInput()` para limpiar buffer |
| `Input` | Lectura segura del nombre del jugador |
| `InputOption` | Lectura recursiva de opciones numéricas con validación |
| `Confirmation` | Validación recursiva de respuestas `s/n` |
| `Continue` | Pausa entre habitaciones |

