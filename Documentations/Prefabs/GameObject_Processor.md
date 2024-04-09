# Processor Prefab

| Base Commit |
| :-: |
| 964740d |

## Structure

```
- ProcessorWrapper
  - Processor
    - model
```

* ProcessorWrapper wraps Processor, visualizes Processor's path with Line Renderer.

* Do not move directly. ProcessorWrapper must be fixed in $(0, 0, 0)$.
  * During ProcessorWrapper attached LineRenderer, If move ProcessorWrapper, Visualized path will be moved also.

### Processor

* Processor's name must not be changed. ProcessorWrapper finds Processor object by name. If want to change name, also update configuration(`Config_Processor` Class).

### model
model is imported Blender model that displays arrow.

* model's name must not be changed. Processor finds model object by name. If want to change name, also update configuration(`Config_Processor` Class).

* Do not move directly. model must be fixed in $(0, 0, 0)$.
