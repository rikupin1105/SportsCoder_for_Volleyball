using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SetStutsViewModel : BindableBase
    {
        public ReactiveProperty<bool> IsDisplaySetStuts { get; set; } = Data.Instance.IsDisplaySetStuts.ObserveProperty(x => x.Value).ToReactiveProperty();

        //セット
        public ReactiveProperty<int> Set { get; set; } = Data.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();

        //獲得セット
        public ReactiveProperty<int> SetLeft { get; set; } = Data.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Data.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //チーム名
        public ReactiveProperty<string> TeamRight { get; set; } = Data.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Data.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();

        //点数
        public ReactiveProperty<int> PointLeft { get; set; } = Data.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Data.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();

        //サーブポイント
        public ReactiveProperty<int> LeftTeamServePoint { get; set; } = Data.Instance.LeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServePoint { get; set; } = Data.Instance.RightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //アタックポイント
        public ReactiveProperty<int> LeftTeamAttackPoint { get; set; } = Data.Instance.LeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamAttackPoint { get; set; } = Data.Instance.RightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //ブロックポイント
        public ReactiveProperty<int> LeftTeamBlockPoint { get; set; } = Data.Instance.LeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamBlockPoint { get; set; } = Data.Instance.RightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //サーブポイント
        public ReactiveProperty<int> LeftTeamServeError { get; set; } = Data.Instance.LeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServeError { get; set; } = Data.Instance.RightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        
        //相手のミス
        public ReactiveProperty<int> LeftTeamOpponentError { get; set; } = Data.Instance.LeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamOpponentError { get; set; } = Data.Instance.RightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}