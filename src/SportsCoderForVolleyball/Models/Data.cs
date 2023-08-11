using Reactive.Bindings;
using System.Collections.Generic;

namespace SportsCoderForVolleyball.Models
{
    public class Data
    {
        public static Data Instance { get; } = new();
        public ReactiveCollection<string> History { get; set; } = new ReactiveCollection<string>() { "S" };

        public ReactiveProperty<List<Set>> Sets = new(new List<Set>());

        public Option Option { get; set; } = new();
        public Point Point { get; set; } = new();
        public Control Control { get; set; } = new();

        //セット統計
        public ReactiveProperty<int> LeftTeamServePoint = new(0);
        public ReactiveProperty<int> RightTeamServePoint = new(0);
        public ReactiveProperty<int> LeftTeamAttackPoint = new(0);
        public ReactiveProperty<int> RightTeamAttackPoint = new(0);
        public ReactiveProperty<int> LeftTeamBlockPoint = new(0);
        public ReactiveProperty<int> RightTeamBlockPoint = new(0);
        public ReactiveProperty<int> LeftTeamServeError = new(0);
        public ReactiveProperty<int> RightTeamServeError = new(0);
        public ReactiveProperty<int> LeftTeamError = new(0);
        public ReactiveProperty<int> RightTeamError = new(0);
        public ReactiveProperty<int> LeftTeamOpponentError = new(0);
        public ReactiveProperty<int> RightTeamOpponentError = new(0);

        //ゲーム統計
        public ReactiveProperty<int> GameLeftTeamPoint = new(0);
        public ReactiveProperty<int> GameRightTeamPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamServePoint = new(0);
        public ReactiveProperty<int> GameRightTeamServePoint = new(0);
        public ReactiveProperty<int> GameLeftTeamAttackPoint = new(0);
        public ReactiveProperty<int> GameRightTeamAttackPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamBlockPoint = new(0);
        public ReactiveProperty<int> GameRightTeamBlockPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamServeError = new(0);
        public ReactiveProperty<int> GameRightTeamServeError = new(0);
        public ReactiveProperty<int> GameLeftTeamError = new(0);
        public ReactiveProperty<int> GameRightTeamError = new(0);
        public ReactiveProperty<int> GameLeftTeamOpponentError = new(0);
        public ReactiveProperty<int> GameRightTeamOpponentError = new(0);



        public ReactiveProperty<bool> GuiEnable = new(true);

        //ルール
        public ReactiveProperty<int> TIMEOUT = new(2);
        public ReactiveProperty<int> SET = new(5);
        public ReactiveProperty<int> NEEDSET = new(3);
        public ReactiveProperty<int> POINT = new(25);
        public ReactiveProperty<int> LASTSETPOINT = new(15);
        public ReactiveProperty<bool> COURTCHANGE = new(true);

        public ReactiveProperty<bool> IsLeftFirstServe = new(true);



    }
}
