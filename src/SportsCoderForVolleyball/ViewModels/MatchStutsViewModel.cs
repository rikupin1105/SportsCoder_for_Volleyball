using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MatchStutsViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayGameStuts { get; set; } = Data.Instance.IsDisplayGameStuts.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<string> TeamRight { get; set; } = Data.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Data.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<int> SetLeft { get; set; } = Data.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Data.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<int> PointLeft { get; set; } = Data.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Data.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //ゲーム統計
        public ReactiveProperty<int> GameLeftTeamPoint { get; set; } = Data.Instance.GameLeftTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamPoint { get; set; } = Data.Instance.GameRightTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Data.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Data.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamAttackPoint { get; set; } = Data.Instance.GameLeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamAttackPoint { get; set; } = Data.Instance.GameRightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamBlockPoint { get; set; } = Data.Instance.GameLeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamBlockPoint { get; set; } = Data.Instance.GameRightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamOpponentError { get; set; } = Data.Instance.GameLeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamOpponentError { get; set; } = Data.Instance.GameRightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}
