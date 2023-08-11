using Reactive.Bindings;

namespace SportsCoderForVolleyball.Shared
{
    public class UI
    {
        public static UI Instance { get; } = new();

        public ReactiveProperty<bool> IsDisplayScoreboard = new(true);

        //UI部品
        public ReactiveProperty<int> Set = new(1);
        public ReactiveProperty<string> TeamLeft = new("USA");
        public ReactiveProperty<string> TeamRight = new("JPN");
        public ReactiveProperty<int> PointLeft = new(0);
        public ReactiveProperty<int> PointRight = new(0);
        public ReactiveProperty<int> SetLeft = new(0);
        public ReactiveProperty<int> SetRight = new(0);
        public ReactiveProperty<int> TimeOutRight = new(0);
        public ReactiveProperty<int> TimeOutLeft = new(0);
        public ReactiveProperty<bool> IsLeftServe = new(true);
        public ReactiveProperty<bool> IsRightServe = new(false);
        public ReactiveProperty<bool> IsATeamLeft = new(true);
        public ReactiveProperty<string> ColorCodeLeftTeam = new("#ffffff");
        public ReactiveProperty<string> ColorCodeRightTeam = new("#000000");
        public ReactiveProperty<string> BackGroundColor = new("#00ff00");
    }
}