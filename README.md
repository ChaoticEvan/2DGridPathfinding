# 2DGridPathfinding

## Problem

In a 100 by 100 2-D grid world, there is a starting point A on one side of the grid, and an
ending point B on the other side of the grid. The objective is to get from point A to point B.
Each grid space can be in a state of ["Blank", "Speeder", "Lava", "Mud"]. You start out with 100
points of health and 250 moves. Below is a mapping of how much your health and moves are
affected by landing on a grid space.

```JSON
[
    "Blank": {"Health": 0, "Moves": -1},
    "Speeder": {"Health": -5, "Moves": 0},
    "Lava": {"Health": -50, "Moves": -10},
    "Mud": {"Health": -10, "Moves": -5},
]
```

Build an application in any language (no UI necessary, terminal output is great), that checks
whether (a) The grid world level is solvable for a given grid world level to get from point A to
point B, and (b) What the most efficient route is to get across if it is solvable, in order to
minimize health damage and moves it takes to get from point A to point B.
