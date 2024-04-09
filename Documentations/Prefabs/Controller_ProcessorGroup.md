# ProcessorGroup Controller

| Base Commit |
| :-: |
| - |

## Requirements

* ProcessorGroup refers Processor Prefab. Processor Prefab must be referred manually at Unity Editor.  
  If not referred correctly, `InvalidFieldExistsException` will be throwed.

## Public Methods

### `AddNewProcessor`

```cs
public GameObject AddNewProcessor() {}
public GameObject AddNewProcessor(Vector3? initPosition, List<PositionPoint>? pointsHeading) {}
```

Add new Processor Prefab under the Processor Group(Group_Processors) Prefab that attatched this controller. And returns reference of generated Processor instance.  

If `initPosition` is `null`, Processor's initial position will be $(0, 0, 0)$.

If `pointsHeading` is `null`, Processor's heading position list will be empty.
