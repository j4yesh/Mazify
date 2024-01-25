# Mezify
## Types of Mazes
[![N|Solid](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)](https://raw.githubusercontent.com/j4yesh/Mazify/main/ScreenShots/Screenshot%202024-01-24%20194152.png)

## Simulating bfs
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194431.png?raw=true)

## Micro-Mouse maze generator
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)

## Simulating modified flood fill algorithm
[![N|Solid](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194756.png?raw=true)](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Screenshot%202024-01-24%20194625.png?raw=true)

## Table of Content
  * [Introduction](#introduction)
  * [Installation](#installation)
  * [Directory Tree](#directory-tree)
  * [Result](#result)
  * [Conclusion](#conclusion)

## Introduction

The Mezify is a Pathfinding simulator , a software designed to visualize various pathfinding
algorithms, offers an exceptional source of motivation for indivisuals passionate about
problem-solving algorithmic exploration. The ability to visualize these algorithms in real-time, as they navigate through complex enviroments and overcome obstacles,sparks a sence of exitement and curiosity. as well as for the persone who preparing for maze solving robotics competition like micro-mouse and technoxian etc. micro mouse simulator is very use full for them to understand algorithm. demostrating wall saving and manhatten distance. making the sequence of decision visible. how robot come back from dead end. and finally deciding the shortest path

# standard maze 
Algorithm like bfs , dfs and dijkshtra are not applicable in physics maze solving. which happen in robotics competions . but they are very use full in map nevigation , game development and basic computer network aspects.

# micro-mouse simulator
the section micro mouse simulator is made for physical maze solving. this algorithm (modified flood fill) works fine even if initially it does not know the graph. while developing "solver"
the independed game object is made. this is not linked with any other object but able to do raycast as ultrasonic/lidar sensor used in real life robot. so initially it does not have any 
idea about maze. this is self learning algorithm by memoizing the walls.


## Installation
This is purely made in Unity Engine. So just download and run Mazify.exe


## Installation

Install the dependencies and devDependencies and start the server.

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

![](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/62e132087fe3599fdd46ecb5.png?raw=true)
![](https://github.com/j4yesh/Mazify/blob/main/ScreenShots/Logo_C_sharp.svg.png?raw=true)

[<img target="_blank" src="https://upload.wikimedia.org/wikipedia/commons/8/84/Matplotlib_icon.svg" width=100>](https://matplotlib.org/)

## Result

| Algorithm               | Time Complexity                                              | Space Complexity                                     |
|-------------------------|--------------------------------------------------------------|-------------------------------------------------------|
| Backtracking            | O(3^(m*n)), because on every cell we have to try 3 different directions. | O(m*n), Maximum Depth of the recursion tree (auxiliary space). |
| Breadth First Search    | O(V + E), where V represents the number of vertices and E represents the number of edges in the graph. | O(V), where V represents the number of vertices in the graph. |
| Depth First Search      | O(V + E), where V represents the number of vertices and E represents the number of edges in the graph. | O(V), where V represents the number of vertices in the graph. |
| Flood fill      | O(N*M), where M represents the number of row and N represents the number of column. | O(N*M), where M represents the number of row and N represents the number of column. |
| Modified Flood fill      | O(N^3), where M represents the number of cell for side of maze, |O(N^2), where M represents the number of cell for side of maze,|







