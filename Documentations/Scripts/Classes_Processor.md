# Definitions for Processor Controller

| Base Commit |
| :-: |
| b58c557 |

## MovingStatus

```cs
[System.Serializable] public enum MovingStatus {}
```

Expresses current moving status of Processor.

* `Idle`: Idle.
* `Rotating`: Rotating at changes heading position (after arrived intermediate passing point).
* `Forwarding`: Forwarding
* `Backwarding`: Backwarding when heading position's point type is destination(`PositionPointType.Destination`).
* `BackwardRotating`: Rotating for backwarding when heading position's point type is destination(`PositionPointType.Destination`).

General scenario of changing MovingStatus:
1. Idle  
2. Rotating: Changed by changing heading position method.  
3. Forwarding: Changed by rotating handler method after done rotating.  
4. Rotating, Forwarding, ...: Repeat &lt;2.&gt; and &lt;3.&gt;
5. BackwardRotating: Changed by forwarding handler method when heading position's point type is destination.
6. Backwarding: Changed by rotating handler method after done rotating(BackwardRotating).
7. Repeat until heading position list is empty.

## PositionPoint

```cs
[System.Serializable] public enum PositionPointType {}
```

Expresses heading position is passing point or destination.

* `Passing`
* `Destination`

## PositionPoint
```cs
[System.Serializable] public class PositionPoint {}
```

Expresses heading position.

### Variables

* `public Vector2 position`: Position 2-dim vector projected onto xz-plane. If need, conversion to 3-dim vector internally and automatically.
* `public PositionPointType pointType`
