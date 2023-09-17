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
    reverse(trips.begin(),trips.end());
    for(auto it: trips){
      ans[it.first][it.second]=true;
      Sleep(500);
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
      cout<<endl;
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
