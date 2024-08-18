# Mazify
## Types of Mazes
[![N|Solid](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)

## Simulating bfs
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)

## Micro-Mouse maze generator
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)

## Simulating modified flood fill algorithm
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194756.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)
The Micro-Mouse simulator is likely used in the context of educational and practical training for individuals interested in robotics, specifically for micromouse competitions. A micromouse is a small robotic vehicle that is designed to navigate through a maze.

## Where do we need it?
![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/maxresdefault.jpg?raw=true)]
![N|Solid](https://abiraworld.com/wp-content/uploads/2022/02/MAZE-SOLVER-ONE-3.png)]

## Table of Content
  * [Introduction](#introduction)
  * [Installation](#installation)
  * [How_to_control?](#How_to_control)
  * [Directory Tree](#directory-tree)
  * [Result](#result)
  * [Conclusion](#conclusion)

## Introduction

Mazify is a pathfinding simulator,  software designed to visualise various pathfinding algorithms, offers an exceptional source of motivation for indivisuals passionate about problem-solving algorithmic exploration. The ability to visualise these algorithms in real-time as they navigate through complex environments and overcome obstacles sparks a sense of excitement and curiosity. as well as for the person who is preparing for maze-solving robotics competitions like micro-mouse and technoxian, etc. The micro-mouse simulator is very useful for them to understand algorithms. demonstrating wall saving and manhattening distance. making the sequence of decisions visible. how robots come back from dead ends. and finally deciding the shortest path.




# standard maze 
Algorithms like BFS, DFS, and Dijkshtra are not applicable in physics maze solving. which happen in robotics competitions. but they are very useful in map navigation, game development, and basic computer network aspects.

# micro-mouse simulator
The section micro-mouse simulator is made for physical maze solving. This algorithm (modified flood fill) works fine, even if initially it does not know the graph. while developing "solver"
the independent game object is made. This is not linked to any other object but is able to do a raycast as an ultrasonic or lidar sensor used in a real-life robot. So initially, it does not have any
idea about mazes. This is a self-learning algorithm for memoizing the walls.


## Installation
This is purely made in Unity Engine. So just download and run Mazify.exe


## How to Control?
Standard Maze
1. while you are in the DRAW/ERASE scene. Hold the left mouse button and draw over the cells. If you want to erase, hold the right mouse button and move over the cells.
2. after drawing paths. or you can click on the generate maze button. This will generate an automatic maze. (Don't forget to increase speed from the top right corner.).
To set the source and destination, click on the SRC/DST button. To set the source cell, do left-click on the blue cell, and for the destination, do right-click on the blue cell.
3. Now click on any algorithm button, like BFs.

Micro-Mouse Simulator
1. Hold left-click and move over walls to make a wall. and to remove the wall, hold right-click.
2. You can also use the maze generator.
3. For a micro-mouse simulator, the source is always in the bottom-left cell. and destination is at the center of the maze.
4. Now click on the solver button.
4. Red walls show that walls were recognized by the robot. After solving the maze, click the aerrow button to nevigate each decision.


## Directory Tree 
```
├── Assets
├── ProjectSettings 
```

## Technologies Used

![](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Untitled-1.png?raw=true)

## Result

| Algorithm               | Time Complexity                                              | Space Complexity                                     |
|-------------------------|--------------------------------------------------------------|-------------------------------------------------------|
| Backtracking            | O(3^(m*n)), because on every cell we have to try 3 different directions. | O(m*n), Maximum Depth of the recursion tree (auxiliary space). |
| Breadth First Search    | O(V + E), where V represents the number of vertices and E represents the number of edges in the graph. | O(V), where V represents the number of vertices in the graph. |
| Depth First Search      | O(V + E), where V represents the number of vertices and E represents the number of edges in the graph. | O(V), where V represents the number of vertices in the graph. |
| Flood fill      | O(N*M), where M represents the number of row and N represents the number of column. | O(N*M), where M represents the number of row and N represents the number of column. |
| Modified Flood fill      | O(N^3), where M represents the number of cell for side of maze, |O(N^2), where M represents the number of cell for side of maze,|

## Conclusion
1. The final takeaway from the simulator is to explore various pathfinding algorithms. Also,  game engines are very useful when it comes to simulation.
4. Creating this simulator helped me learn a lot about various algorithms, and I came to know how actual navigation works based on logitude and latitude. how the maze solver robot makes a decision.
3. The Modified flood fill algorithm is suitable for solving mazes. If needed, anyone can surely implement it on a physical robot
