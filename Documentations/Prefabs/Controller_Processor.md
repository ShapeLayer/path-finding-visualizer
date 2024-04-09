# Processor Controller

| Base Commit |
| :-: |
| - |

## Structure

```cs
public Config_Processor config;
public List<PositionPoint> pointsHeading;
public List<PositionPoint> pointsPassed;
public MovingStatus movingStatus;
public PositionPoint processorHeading;
public GameObject displayModelObject;

public void AddPointHeading(PositionPoint position) {}
public void AddPointHeading(Vector position) {}
```

## Variables

### `config`

```cs
public Config_Processor config;
```

A configuration of Processor Controller.

### `pointsHeading`

```cs
List<PositionPoint> pointsHeading;
```

A Processor's heading points list.  

First element of this list is point that now heading.

### `pointsPassed`

```cs
List<PositionPoint> pointsPassed;
```

A Processor's passed points list.

### `movingStatus`

```cs
public MovingStatus movingStatus;
```

A Processor's moving status now.

### `processorHeading`

```cs
public PositionPoint processorHeading;
```

A Processor's heading point now.

### `displayModelObject`

```cs
public GameObject displayModelObject;
```

A child object that displays processor. Controller refers chilld GameObject automatically named `model`.  

For more information, refer &lt;model&gt; section at [Processor GameObject](./GameObject_Processor.md).

## Public Methods

### `AddPointHeading`

```cs
public void AddPointHeading(PositionPoint position) {}
public void AddPointHeading(Vector2 position) {}
```

Add heading point to heading points list right-side end. A wrapper of `List.Add()`.

### `RemovePointHeadingAt`

```cs
public void RemovePointHeadingAt(int idx) {}
```

Remove heading point from heading points list using index. A wrapper of `List.Remove()`.
