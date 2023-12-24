import time
import queue

# TOP BOTTOM RIGHT LEFT
ROW = 5
COL = 5

class Node:
    def __init__(self):
        self.row = 0
        self.col = 0
        self.wall = [True, True, True, True]
        self.nev = False

class Leaf:
    def __init__(self, val, row, col):
        self.val = val
        self.row = row
        self.col = col


celler = [[Node() for _ in range(COL)] for _ in range(ROW)]

trips = []
cur = (0, 0)

cell = [
    [4, 3, 2, 3, 4],
    [3, 2, 1, 2, 3],
    [2, 1, 0, 1, 2],
    [3, 2, 1, 2, 3],
    [4, 3, 2, 3, 4]
]

retTrip = [[Node() for _ in range(COL)] for _ in range(ROW)]

def wallSaver(temp, a):
    for i in range(4):
        if not a[i]:
            celler[temp[0]][temp[1]].wall[i] = False
            print("wall save krha hu bro")

def printGrid(a, b):
    for i in range(ROW):
        for j in range(COL):
            if i == a and j == b:
                print(f"{cell[i][j]}.", end=' ')
            else:
                print(cell[i][j], end=' ')
        print()

def printAns():
    a = "\nPRINT THE ANSWER\n"
    for char in a:
        print(char, end='')
        time.sleep(0.1)

    ans = [[False] * ROW for _ in range(COL)]
    if not trips:
        print("No path available")
    trips.reverse()
    for it in trips:
        ans[it[0]][it[1]] = True
        time.sleep(1.5)
        for ut in ans:
            for wt in ut:
                if not wt:
                    print("  ", end='')
                    continue
                print("1 ", end='')
            print()
        print()

    for i in range(ROW):
        for j in range(COL):
            if not retTrip[i][j].nev:
                print("  ", end='')
                continue
            print(f"{retTrip[i][j].nev} ", end='')
        print()
    print()

def getCurCell():
    return cur

def moveTop():
    cur[0] -= 1

def moveDown():
    cur[0] += 1

def moveLeft():
    cur[1] -= 1

def moveRight():
    cur[1] += 1

def queken(q, pr):
    vr = []

    print(str(pr[0])+' '+str(pr[1])+" queken",end="")
    # print(pr,end="")

    if celler[pr[0]][pr[1]].wall[0]:
        vr.append(Leaf(cell[pr[0] - 1][pr[1]], pr[0] - 1, pr[1]))

    if celler[pr[0]][pr[1]].wall[1]:
        vr.append(Leaf(cell[pr[0] + 1][pr[1]], pr[0] + 1, pr[1]))

    if celler[pr[0]][pr[1]].wall[2]:
        vr.append(Leaf(cell[pr[0]][pr[1]+1], pr[0] , pr[1]+1))

    if celler[pr[0]][pr[1]].wall[3]:
        vr.append(Leaf(cell[pr[0]][pr[1]-1], pr[0], pr[1]-1))

    minValue = float('inf')
    for it in vr:
        minValue = min(it.val, minValue)

    if minValue != float('inf') and cell[pr[0]][pr[1]] <= minValue:
        cell[pr[0]][pr[1]] = minValue + 1
        for it in vr:
            q.put([it.row, it.col])
        print("minValue:", minValue)

def bringOut(a):
    for i in range(4):
        if a[i]:
            break
    if i == 0:
        return cell[cur[0] - 1][cur[1]]
    if i == 1:
        return cell[cur[0] + 1][cur[1]]
    if i == 2:
        return cell[cur[0]][cur[1] + 1]
    if i == 3:
        return cell[cur[0]][cur[1] - 1]

def qNeeded(pr):
    v = []
    if celler[pr[0]][pr[1]].wall[0]:
        v.append(cell[pr[0] - 1][pr[1]])
    if celler[pr[0]][pr[1]].wall[1]:
        v.append(cell[pr[0] + 1][pr[1]])
    if celler[pr[0]][pr[1]].wall[2]:
        v.append(cell[pr[0]][pr[1] + 1])
    if celler[pr[0]][pr[1]].wall[3]:
        v.append(cell[pr[0]][pr[1] - 1])

    if len(v) == 1:
        print("q madhe single element aahe")
        return False

    firstElement = v[0]
    for i in range(1, len(v)):
        if v[i] != firstElement:
            print("False fekt aahe ithe -> ~q Need")
            return False

    return True

def bringTheVal(val):
    v = []
    if celler[cur[0]][cur[1]].wall[0]:
        v.append(cell[cur[0] - 1][cur[1]])
    if celler[cur[0]][cur[1]].wall[1]:
        v.append(cell[cur[0] + 1][cur[1]])
    if celler[cur[0]][cur[1]].wall[2]:
        v.append(cell[cur[0]][cur[1] + 1])
    if celler[cur[0]][cur[1]].wall[3]:
        v.append(cell[cur[0]][cur[1] - 1])

    print("returning:", min(v))
    return min(v)

def solve():
    my_queue = queue.Queue()
    my_queue.put([cur[0],cur[1]])

    a = [True, True, True, True]
    while True:
        printGrid(cur[0], cur[1])

        next = (cur[0], cur[1])
        minVal = cell[cur[0]][cur[1]]
        print("possible directions to go: ", end='')
        a = list(map(int, input().split())) # take input from ultrasonic sensor
        wallSaver(cur, a)

        if qNeeded(cur):
            print("q kde kam assign:")
            while not my_queue.empty():
                temp = my_queue.get()
                print(temp[0])
                print()
                queken(my_queue, temp)
                
        else:
            while not my_queue.empty():
                my_queue.get()

        if bringTheVal(cell[cur[0]][cur[1]]) >= cell[cur[0]][cur[1]]:
            cell[cur[0]][cur[1]] = bringTheVal(cell[cur[0]][cur[1]]) + 1

        dir = ""
        if a[0]:
            if cell[cur[0]][cur[1]] > cell[cur[0] - 1][cur[1]]:
                my_queue.put([cur[0] - 1, cur[1]])
                minVal = cell[cur[0] - 1][cur[1]]
                next = (cur[0] - 1, cur[1])
                dir = "Top"

        if a[1]:
            if cell[cur[0]][cur[1]] > cell[cur[0] + 1][cur[1]]:
                my_queue.put([cur[0] + 1, cur[1]])
                minVal = cell[cur[0] + 1][cur[1]]
                next = (cur[0] + 1, cur[1])
                dir = "Bottom"

        if a[2]:
            if cell[cur[0]][cur[1]] > cell[cur[0]][cur[1] + 1]:
                my_queue.put([cur[0], cur[1] + 1])
                minVal = cell[cur[0]][cur[1] + 1]
                next = (cur[0], cur[1] + 1)
                dir = "Right"

        if a[3]:
            if cell[cur[0]][cur[1]] > cell[cur[0]][cur[1] - 1]:
                my_queue.put([cur[0], cur[1] - 1])
                minVal = cell[cur[0]][cur[1] - 1]
                next = (cur[0], cur[1] - 1)
                dir = "Left"

        print(next[0], next[1])
        if retTrip[next[0]][next[1]].nev:
            print("one detected")
            retTrip[cur[0]][cur[1]].nev = False
            trips.pop()
            print("pop krre")

        if dir=="Top":
            moveTop()
        elif dir=="Bottom":
            moveDown()
        elif dir=="Right":
            moveRight()
        else:
            moveLeft()
        
        if not retTrip[cur[0]][cur[1]].nev:
            trips.append((cur[0], cur[1]))
            print("push krre hai")
        retTrip[cur[0]][cur[1]].nev = not retTrip[cur[0]][cur[1]].nev

        if cell[cur[0]][cur[1]] == 0:
            printAns()
            break

        # ethically dedicate direction function should be called


if __name__ == "__main__": 
    for i in range(ROW):
        celler[0][i].wall[0] = False
        celler[ROW - 1][i].wall[1] = False
        celler[i][ROW - 1].wall[2] = False
        celler[i][0].wall[3] = False

    src = (4, 0)
    retTrip[src[0]][src[1]].nev = True
    trips.append(list(src))
    cur = list(src)
    solve()
