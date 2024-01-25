# Mezify
## Types of Mazes
[![N|Solid](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)

## Simulating bfs
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)

## Micro-Mouse maze generator
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)

## Simulating modified flood fill algorithm
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194756.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)

## Where does it need? how micro mouse robot look?
![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/micromouse-robot-2.jpg?raw=true)] 
![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/maxresdefault.jpg?raw=true)]

## Table of Content
  * [Introduction](#introduction)
  * [Installation](#installation)
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


## Directory Tree 
```
├── pickle
│   ├── model.pkl
├── static
│   ├── styles.css
├── templates
│   ├── index.html
├── Phishing URL Detection.ipynb
├── Procfile
├── README.md
├── app.py
├── feature.py
├── phishing.csv
├── requirements.txt
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
3. The flood fill algorithm is suitable for solving mazes. If needed, I can implement it on a physical robot







