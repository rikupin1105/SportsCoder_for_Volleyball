using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System.Collections.Generic;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {

        }

        public ReactiveProperty<List<Set>> Sets { get; set; } = Control.Instance.Sets.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<List<Control.PointParSetInfomationSource>> PointParSetSource { get; set; } = Control.Instance.PointParSetSource.ObserveProperty(x => x.Value).ToReactiveProperty();

        //情報表示用
        public ReactiveProperty<bool> IsAnimation { get; set; } = Control.Instance.IsAnimation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; } = Control.Instance.IsDisplayTechnicalTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayLeftTimeout { get; set; } = Control.Instance.IsDisplayLeftTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightTimeout { get; set; } = Control.Instance.IsDisplayRightTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightSetPoint { get; set; } = Control.Instance.IsDisplayRightSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayRightMatchPoint { get; set; } = Control.Instance.IsDisplayRightMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayLeftSetPoint { get; set; } = Control.Instance.IsDisplayLeftSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayLeftMatchPoint { get; set; } = Control.Instance.IsDisplayLeftMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining { get; set; } = Control.Instance.IsDisplayTimeoutRemaining.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayGetSet { get; set; } = Control.Instance.IsDisplayGetSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayPointParSet { get; set; } = Control.Instance.IsDisplayPointParSet.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplaySetStuts { get; set; } = Control.Instance.IsDisplaySetStuts.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayGameStuts { get; set; } = Control.Instance.IsDisplayGameStuts.ObserveProperty(x => x.Value).ToReactiveProperty();

        //プレー統計表示
        public ReactiveProperty<bool> IsDisplayAttackPointInfomation { get; set; } = Control.Instance.IsDisplayAttackPointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayBlockPointInfomation { get; set; } = Control.Instance.IsDisplayBlockPointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayServePointInfomation { get; set; } = Control.Instance.IsDisplayServePointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation { get; set; } = Control.Instance.IsDisplayServeErrorInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();

        //UI部品
        public ReactiveProperty<int> Set { get; set; } = Control.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointLeft { get; set; } = Control.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Control.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = Control.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Control.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutRight { get; set; } = Control.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutLeft { get; set; } = Control.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsLeftServe { get; set; } = Control.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsRightServe { get; set; } = Control.Instance.IsRightServe.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BackGroundColor { get; set; } = Control.Instance.BackGroundColor.ObserveProperty(x => x.Value).ToReactiveProperty();

        //セット統計用
        public ReactiveProperty<int> LeftTeamServePoint { get; set; } = Control.Instance.LeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServePoint { get; set; } = Control.Instance.RightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamAttackPoint { get; set; } = Control.Instance.LeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamAttackPoint { get; set; } = Control.Instance.RightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamBlockPoint { get; set; } = Control.Instance.LeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamBlockPoint { get; set; } = Control.Instance.RightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamServeError { get; set; } = Control.Instance.LeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServeError { get; set; } = Control.Instance.RightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamError { get; set; } = Control.Instance.LeftTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamError { get; set; } = Control.Instance.RightTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamOpponentError { get; set; } = Control.Instance.LeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamOpponentError { get; set; } = Control.Instance.RightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();

        //ゲーム統計
        public ReactiveProperty<int> GameLeftTeamPoint { get; set; } = Control.Instance.GameLeftTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamPoint { get; set; } = Control.Instance.GameRightTeamPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Control.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Control.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamAttackPoint { get; set; } = Control.Instance.GameLeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamAttackPoint { get; set; } = Control.Instance.GameRightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamBlockPoint { get; set; } = Control.Instance.GameLeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamBlockPoint { get; set; } = Control.Instance.GameRightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServeError { get; set; } = Control.Instance.GameLeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServeError { get; set; } = Control.Instance.GameRightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamError { get; set; } = Control.Instance.GameLeftTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamError { get; set; } = Control.Instance.GameRightTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamOpponentError { get; set; } = Control.Instance.GameLeftTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamOpponentError { get; set; } = Control.Instance.GameRightTeamOpponentError.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}
