using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MatchStutsViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplayGameStuts { get; set; } = Control.Instance.IsDisplayGameStuts.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<string> TeamRight { get; set; } = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<int> SetLeft { get; set; } = Control.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Control.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<int> PointLeft { get; set; } = Control.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Control.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //ゲーム統計
        public ReactiveProperty<int> GameLeftTeamPoint { get; set; } = Control.Instance.GameLeftTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamPoint { get; set; } = Control.Instance.GameRightTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Control.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Control.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamAttackPoint { get; set; } = Control.Instance.GameLeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamAttackPoint { get; set; } = Control.Instance.GameRightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamBlockPoint { get; set; } = Control.Instance.GameLeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamBlockPoint { get; set; } = Control.Instance.GameRightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        public ReactiveProperty<int> GameLeftTeamOpponentError { get; set; } = Control.Instance.GameLeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamOpponentError { get; set; } = Control.Instance.GameRightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}
