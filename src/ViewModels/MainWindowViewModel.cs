using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsCoderForVolleyball.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            Sets = Control.Instance.Sets.ObserveProperty(x => x.Value).ToReactiveProperty();
            PointParSetSource = Control.Instance.PointParSetSource.ObserveProperty(x => x.Value).ToReactiveProperty();

            IsAnimation = Control.Instance.IsAnimation.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayTechnicalTimeout = Control.Instance.IsDisplayTechnicalTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayLeftTimeout = Control.Instance.IsDisplayLeftTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayRightTimeout = Control.Instance.IsDisplayRightTimeout.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayRightSetPoint = Control.Instance.IsDisplayRightSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayRightMatchPoint = Control.Instance.IsDisplayRightMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayLeftSetPoint = Control.Instance.IsDisplayLeftSetPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayLeftMatchPoint = Control.Instance.IsDisplayLeftMatchPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayTimeoutRemaining = Control.Instance.IsDisplayTimeoutRemaining.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayGetSet = Control.Instance.IsDisplayGetSet.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsDisplayPointParSet = Control.Instance.IsDisplayPointParSet.ObserveProperty(x => x.Value).ToReactiveProperty();

            PointLeft = Control.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            PointRight = Control.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            SetLeft = Control.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            SetRight = Control.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();

            TeamRight = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            TeamLeft = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();

            TimeOutRight = Control.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            TimeOutLeft = Control.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            Set = Control.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsLeftServe = Control.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();

            ColorCodeLeftTeam = Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
            ColorCodeRightTeam = Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();


            var a = Control.Instance.Sets.Value.Sum(x => x.ATeamServePoint);
        }

        public ReactiveProperty<List<Set>> Sets { get; set; }
        public ReactiveProperty<List<Control.PointParSetInfomationSource>> PointParSetSource { get; set; }

        //情報表示用
        public ReactiveProperty<bool> IsAnimation { get; set; }
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout { get; set; }
        public ReactiveProperty<bool> IsDisplayLeftTimeout { get; set; }
        public ReactiveProperty<bool> IsDisplayRightTimeout { get; set; }
        public ReactiveProperty<bool> IsDisplayRightSetPoint { get; set; }
        public ReactiveProperty<bool> IsDisplayRightMatchPoint { get; set; }
        public ReactiveProperty<bool> IsDisplayLeftSetPoint { get; set; }
        public ReactiveProperty<bool> IsDisplayLeftMatchPoint { get; set; }
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining { get; set; }
        public ReactiveProperty<bool> IsDisplayGetSet { get; set; }
        public ReactiveProperty<bool> IsDisplayPointParSet { get; set; }
        public ReactiveProperty<bool> IsDisplayServePointInfomation { get; set; } = Control.Instance.IsDisplayServePointInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation { get; set; } = Control.Instance.IsDisplayServeErrorInfomation.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsDisplaySetStuts { get; set; } = Control.Instance.IsDisplaySetStuts.ObserveProperty(x => x.Value).ToReactiveProperty();


        public ReactiveProperty<int> Set { get; set; }

        public ReactiveProperty<string> TeamRight { get; set; }
        public ReactiveProperty<string> TeamLeft { get; set; }
        public ReactiveProperty<int> PointLeft { get; set; }
        public ReactiveProperty<int> PointRight { get; set; }
        public ReactiveProperty<int> SetLeft { get; set; }
        public ReactiveProperty<int> SetRight { get; set; }
        public ReactiveProperty<int> TimeOutRight { get; set; }
        public ReactiveProperty<int> TimeOutLeft { get; set; }
        public ReactiveProperty<bool> IsLeftServe { get; set; }

        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; }
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; }

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
