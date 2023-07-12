#include <bits/stdc++.h>
#include<windows.h>
using namespace std;
//TOP BOTTOM RIGHT LEFT
#define ROW 5
#define COL 5

  struct node{
     int row,col;
     bool right=true,left=true,top=true,bottom=true;
     int wall[4]={true,true,true,true};
  };

  node celler[5][5];

  pair<int,int>cur={0,0};

  int cell[5][5]={
    {4,3,2,3,4},
    {3,2,1,2,3},
    {2,1,0,1,2},
    {3,2,1,2,3},
    {4,3,2,3,4}
  };

  void wallSaver(pair<int,int>temp,bool a[4]){
    for(int i=0;i<4;i++){
       if(!a[i]){
          celler[temp.first][temp.second].wall[i]=false;
          cout<<"yahape aya tha mai\n";
       }
    }
  }

  void print(int a,int b){
    // system("cls");
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

void queken(queue<pair<int,int>>&q,pair<int,int>pr){
  vector<pair<int,pair<int,int>>>vr;

  if(celler[pr.first][pr.second].wall[0]){ //celler se test krre
    vr.push_back({cell[pr.first-1][pr.second],{pr.first-1,pr.second}});
  }
  if(celler[pr.first][pr.second].wall[1]){
    vr.push_back({cell[pr.first+1][pr.second],{pr.first+1,pr.second}});
  }
  if(celler[pr.first][pr.second].wall[2]){
    vr.push_back({cell[pr.first][pr.second+1],{pr.first,pr.second+1}});
  }
  if(celler[pr.first][pr.second].wall[3]){
    vr.push_back({cell[pr.first][pr.second-1],{pr.first,pr.second-1}});
  }

  for(auto it: vr){
    cout<<it.first<<'|'<<it.second.first<<" , "<<it.second.second<<endl;
    int minValue=INT_MAX;
      if(celler[it.second.first][it.second.second].wall[0]){ //celler se test krre
        if(cell[it.second.first][it.second.second]<=cell[it.second.first-1][it.second.second]){
          minValue=min(cell[it.second.first-1][it.second.second],minValue);
          // q.push({it.second.first-1,it.second.second});
        }
      }
      if(celler[it.second.first][it.second.second].wall[1]){
        if(cell[it.second.first][it.second.second]<=cell[it.second.first+1][it.second.second]){
          minValue=min(cell[it.second.first+1][it.second.second],minValue);
          // q.push({it.second.first+1,it.second.second});
        }
      }
      if(celler[it.second.first][it.second.second].wall[2]){
        if(cell[it.second.first][it.second.second]<=cell[it.second.first][it.second.second+1]){
          minValue=min(cell[it.second.first][it.second.second+1],minValue);
          // q.push({it.second.first,it.second.second+1});
        }
      }
      if(celler[it.second.first][it.second.second].wall[3]){
        if(cell[it.second.first][it.second.second]<=cell[it.second.first][it.second.second-1]){
          minValue=min(cell[it.second.first][it.second.second-1],minValue);
          // q.push({it.second.first,it.second.second-1});
        }
      }
    
    if(minValue!=INT_MAX && cell[it.second.first][it.second.second]<=minValue){
      cell[it.second.first][it.second.second]=minValue+1;
    }

  }
  
}

int bringout(bool a[4]){
    int i;
    for(i=0;i<4;i++){
        if(a[i]){
            break;
        }
    }
    if(i==0){
        return cell[cur.first-1][cur.second];
    }
    if(i==1){
        return cell[cur.first+1][cur.second];
    }
    if(i==2){
        return cell[cur.first][cur.second+1];
    }
    if(i==3){
        return cell[cur.first][cur.second-1];
    }
}

void solve(){
  queue<pair<int,int>>q;
  q.push(cur);   
  
  bool a[4];
  while(true){
        print(cur.first,cur.second);
        pair<int, int> next={cur.first,cur.second};
        int minVal = cell[cur.first][cur.second];
        cout << "possible directions to go: ";
        cin>>a[0]>>a[1]>>a[2]>>a[3]; //take input from ultrasonic sensor

        if(a[0]){
            if(cell[cur.first][cur.second]>cell[cur.first-1][cur.second]){
            q.push({cur.first -1, cur.second});
                minVal=cell[cur.first-1][cur.second];
                next={cur.first-1,cur.second};
            }
        }

        if (a[1]){ 
          if(cell[cur.first][cur.second]>cell[cur.first+1][cur.second]){
          q.push({cur.first +1, cur.second});
            minVal=cell[cur.first+1][cur.second];
            next={cur.first+1,cur.second};
            cout<<"mi itthe alo hoto\n";
          }
        }

        if(a[2])
        {
          if(cell[cur.first][cur.second]>cell[cur.first][cur.second+1]){
          q.push({cur.first, cur.second+1});
              minVal=cell[cur.first][cur.second+1];
              next={cur.first,cur.second+1};
          }
        }

        if (a[3]){ 
          if(cell[cur.first][cur.second]>cell[cur.first][cur.second-1]){
              q.push({cur.first, cur.second - 1}); //incase lahan value asel tarch
              minVal=cell[cur.first][cur.second-1];
              next={cur.first,cur.second-1};
          }
        }

        wallSaver(cur,a);

        while(!q.empty()){
          pair<int,int>temp=q.front();
          q.pop();
          queken(q,temp);
        }

        
        if(cell[cur.first][cur.second]==minVal){
            cout<<"game hogya bro!\n";
            cell[cur.first][cur.second]=bringout(a)+1;
        }   //buts works correctly,altough review

        cout<<next.first<<" "<<next.second<<endl;
        cur=next;

        
  }
}

int main()
{

  for(int i=0;i<ROW;i++){
      celler[0][i].wall[0]=false;
      celler[ROW-1][i].wall[1]=false;
      celler[i][ROW-1].wall[2]=false;
      celler[i][0].wall[3]=false;
  }
  // while(true){
  //   int a,b; cin>>a>>b;
  //   for(auto it: celler[a][b].wall){
  //     cout<<it<< " ";
  //   } cout<<endl;
  // }

  pair<int,int>src={4,0};
  cur=src;
  solve();

  return 0;
}
