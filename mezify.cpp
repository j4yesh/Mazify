#include <bits/stdc++.h>
#include<windows.h>
using namespace std;
//TOP BOTTOM RIGHT LEFT
#define ROW 5
#define COL 5

  struct node{
     int row,col;
     int wall[4]={true,true,true,true};
     bool nev=false;
  };
  vector<pair<int,int>> trips;
  node celler[ROW][COL];

  pair<int,int>cur={0,0};

  int cell[ROW][COL]={
    {4,3,2,3,4},
    {3,2,1,2,3},
    {2,1,0,1,2},
    {3,2,1,2,3},
    {4,3,2,3,4}
  };

  node retTrip[ROW][COL];

  void wallSaver(pair<int,int>temp,bool a[4]){
    for(int i=0;i<4;i++){
       if(!a[i]){
          celler[temp.first][temp.second].wall[i]=false;
          cout<<"wall save krha hu bro\n";
       }
    }
  }

  void print(int a,int b){
    // system("cls");
    for(int i=0;i<ROW;i++){
      for(int j=0;j<COL;j++){
        if(i==a&&j==b){
          cout<<cell[i][j]<<'.';
          continue;
        }
        cout<<cell[i][j]<<" ";
      }
      cout<<endl;
    }
  }

  void printAns(){
    string a="\nPRINT THE ANSWER\n";
    for(auto it: a){
      cout<<it;
      Sleep(100);
    }
    vector<vector<bool>>ans(ROW,vector<bool>(ROW,false));
    if(trips.empty()){
        cout<<"not path available\n";
    }
    ans[ROW-1][0]=true;
    for(auto it: trips){
      ans[it.first][it.second]=true;
      Sleep(1500);
      // system("cls");
      for(auto ut: ans){
        for(auto wt: ut){
               if(!wt){
                  cout<<"  ";
                  continue;
               }
             cout<<wt<<" ";
        }
        cout<<endl;
      }
    }
    for(int i=0;i<ROW;i++){
      for(int j=0;j<COL;j++){
        if(!retTrip[i][j].nev){
          cout<<"  ";
          continue;
        }
        cout<<retTrip[i][j].nev<<" ";
      }
      cout<<endl;
    }
    cout<<endl;
  
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
    // q.push({pr.first-1,pr.second});
  }
  if(celler[pr.first][pr.second].wall[1]){
    vr.push_back({cell[pr.first+1][pr.second],{pr.first+1,pr.second}});
    // q.push({pr.first+1,pr.second});
  }
  if(celler[pr.first][pr.second].wall[2]){
    vr.push_back({cell[pr.first][pr.second+1],{pr.first,pr.second+1}});
    // q.push({pr.first,pr.second+1});
  }
  if(celler[pr.first][pr.second].wall[3]){
    vr.push_back({cell[pr.first][pr.second-1],{pr.first,pr.second-1}});
    // q.push({pr.first,pr.second-1});
  }
  int minValue=INT_MAX;
  for(auto it: vr){
        minValue=min(it.first,minValue);
  }
    if(minValue!=INT_MAX && cell[pr.first][pr.second]<=minValue){
      cell[pr.first][pr.second]=minValue+1;
      for(auto it: vr){
        q.push({it.second.first,it.second.second});
      }
      cout<<"minValue: "<<minValue<<endl;
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

bool qNeeded(pair<int,int>pr){
  vector<int>v;

if(celler[pr.first][pr.second].wall[0]){
    v.push_back(cell[pr.first-1][pr.second]);
}
if(celler[pr.first][pr.second].wall[1]){
    v.push_back(cell[pr.first+1][pr.second]);
}
if(celler[pr.first][pr.second].wall[2]){
    v.push_back(cell[pr.first][pr.second+1]);
}
if(celler[pr.first][pr.second].wall[3]){
    v.push_back(cell[pr.first][pr.second-1]);
}

  if(v.size()==1){
    cout<<"q madhe single element aahe\n";
    return false;
  }
  int firstElement = v[0];
  for (int i = 1; i < v.size(); i++) {
      if (v[i] != firstElement) {
          cout<<" false fekt aahe ithe -> ~q Need\n";
          return false;
      }
  }  
  return true;
}

int bringTheval(int val){
   vector<int>v;
    if(celler[cur.first][cur.second].wall[0]){
        v.push_back(cell[cur.first-1][cur.second]);
    }
    if(celler[cur.first][cur.second].wall[1]){
        v.push_back(cell[cur.first+1][cur.second]);
    }
    if(celler[cur.first][cur.second].wall[2]){
        v.push_back(cell[cur.first][cur.second+1]);
    }
    if(celler[cur.first][cur.second].wall[3]){
        v.push_back(cell[cur.first][cur.second-1]);
    }

    cout<<"returning : "<<*min_element(v.begin(),v.end())<<'\n';
    return *min_element(v.begin(),v.end());
}

void solve(){
  queue<pair<int,int>>q;
  q.push(cur);   
  
  bool a[4]={true,true,true,true};
  while(true){
        print(cur.first,cur.second);

        pair<int, int> next={cur.first,cur.second};
        int minVal = cell[cur.first][cur.second];
        cout << "possible directions to go: ";
        cin>>a[0]>>a[1]>>a[2]>>a[3]; //take input from ultrasonic sensor
        wallSaver(cur,a);

        if(qNeeded(cur)){
          cout<<"q kde kam assign: \n";
          while(!q.empty()){
            pair<int,int>temp=q.front();
            queken(q,temp);
            q.pop();
          }
        }else{
          while(!q.empty())q.pop();
        }

        if(bringTheval(cell[cur.first][cur.second]>=cell[cur.first][cur.second])){
          cell[cur.first][cur.second]=bringTheval(cell[cur.first][cur.second])+1;
          // continue;
        }

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

        cout<<next.first<<" "<<next.second<<endl;
        if(retTrip[next.first][next.second].nev){
          cout<<"              one detected \n";
          retTrip[cur.first][cur.second].nev=false;
          trips.pop_back();
          cout<<" pop krre \n";
        }
        cur=next;
        if(!retTrip[cur.first][cur.second].nev){
          trips.push_back({cur.first,cur.second});
          cout<<" push krre hai\n";
        }
        retTrip[cur.first][cur.second].nev=~retTrip[cur.first][cur.second].nev;

        if(cell[cur.first][cur.second]==0){
          printAns();
          break;
        }
        //ethically dedicate direction function should called 

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
  retTrip[src.first][src.second].nev=true;
  cur=src;
  solve();

  return 0;
}
