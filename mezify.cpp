#include <bits/stdc++.h>
#include<windows.h>
using namespace std;
#define ed "\n"

pair<int,int>cur={0,0};


  int cell[5][5]={
    {4,3,2,3,4},
    {3,2,1,2,3},
    {2,1,0,1,2},
    {3,2,1,2,3},
    {4,3,2,3,4}
  };

  void print(int a,int b){
    system("cls");
    for(int i=0;i<5;i++){
      for(int j=0;j<5;j++){
        if(i==a&&j==b){
          cout<<cell[i][j]<<'.';
          continue;
        }
        cout<<cell[i][j]<<" ";
      }
      cout<<endl;
    }
  }

pair<int,int>getCurcell(){
  return cur;
}

void moveTop(){
  cur.first++;
}
void moveDown(){
  cur.first--;
}
void moveleft(){
  cur.second--;
}
void moveright(){
  cur.second++;
}

void solve(){
  queue<pair<int,int>>q;
  q.push(cur);   

  bool a=false;
  while(!q.empty()){
        print(cur.first,cur.second);
        pair<int, int> next;
        int minVal = cell[cur.first][cur.second];

        cout << "possible to go top? ";
        cin >> a;
        if(a){
            q.push({cur.first -1, cur.second});
            minVal = min(cell[cur.first -1][cur.second], minVal);
            if(minVal>cell[cur.first-1][cur.second]){
                minVal=cell[cur.first-1][cur.second];
                next={cur.first-1,cur.second};
            }
        }


        cout << "possible to go bottom? ";
        cin >> a;
        if (a){ 
          q.push({cur.first +1, cur.second});
          if(minVal>cell[cur.first+1][cur.second]){
            minVal=cell[cur.first+1][cur.second];
            next={cur.first+1,cur.second};
          }
        }


        cout << "possible to go left? ";
        cin >> a;
        if (a){ 
          q.push({cur.first, cur.second - 1});
          minVal = min(cell[cur.first ][cur.second-1], minVal);
          if(minVal>cell[cur.first][cur.second-1]){
              minVal=cell[cur.first][cur.second-1];
              next={cur.first,cur.second-1};
          }
        }


        cout << "possible to go right? ";
        cin >> a;
        if(a)
        {
          q.push({cur.first, cur.second+1});
          minVal = min(cell[cur.first ][cur.second+1], minVal);
          if(minVal>cell[cur.first][cur.second+1]){
              minVal=cell[cur.first][cur.second+1];
              next={cur.first,cur.second+1};
          }
        }

        cur=next;
        q.pop();
  }
}

int main()
{

  pair<int,int>src={4,0};
  cur=src;
  solve();

  return 0;
}
