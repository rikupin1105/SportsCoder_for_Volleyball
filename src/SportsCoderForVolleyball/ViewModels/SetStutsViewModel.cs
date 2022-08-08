using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SetStutsViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplaySetStuts { get; set; } = Control.Instance.IsDisplaySetStuts.ObserveProperty(x => x.Value).ToReactiveProperty();

        //セット
        public ReactiveProperty<int> Set { get; set; } = Control.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();

        //獲得セット
        public ReactiveProperty<int> SetLeft { get; set; } = Control.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Control.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //チーム名
        public ReactiveProperty<string> TeamRight { get; set; } = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();

        //点数
        public ReactiveProperty<int> PointLeft { get; set; } = Control.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Control.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //サーブポイント
        public ReactiveProperty<int> LeftTeamServePoint { get; set; } = Control.Instance.LeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServePoint { get; set; } = Control.Instance.RightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //アタックポイント
        public ReactiveProperty<int> LeftTeamAttackPoint { get; set; } = Control.Instance.LeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamAttackPoint { get; set; } = Control.Instance.RightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //ブロックポイント
        public ReactiveProperty<int> LeftTeamBlockPoint { get; set; } = Control.Instance.LeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamBlockPoint { get; set; } = Control.Instance.RightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //サーブポイント
        public ReactiveProperty<int> LeftTeamServeError { get; set; } = Control.Instance.LeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServeError { get; set; } = Control.Instance.RightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //相手のミス
        public ReactiveProperty<int> LeftTeamOpponentError { get; set; } = Control.Instance.LeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamOpponentError { get; set; } = Control.Instance.RightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}