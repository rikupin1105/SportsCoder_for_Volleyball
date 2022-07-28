using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsCoderForVolleyball.ViewModels
{
    public class ControlWindowViewModel : BindableBase
    {
        private IDialogService _dialogService;

        public ControlWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Control.Instance.SetService(_dialogService);

            new Views.MainWindow().Show();

            DisplayCommand.Subscribe(_ => Control.Instance.ScoreInfomation());
            TechnicalTimeoutCommand.Subscribe(_ => Control.Instance.TechnicalTimeOut());
            LeftTimeoutCommand.Subscribe(_ => Control.Instance.LeftTimeout());
            RightTimeoutCommand.Subscribe(_ => Control.Instance.RightTimeOut());
            GetSetDisplayCommand.Subscribe(_ => Control.Instance.SetInfomation());

            CourtChangeCommand.Subscribe(_ => Control.Instance.CourtChange());
            SettingCommand.Subscribe(_ => { _dialogService.Show("SettingDialog", new DialogParameters(), result => { }, "DialogWindow"); });

            LeftTeamServePointCommand.Subscribe(_ => Control.Instance.ServePoint(true));
            RightTeamServePointCommand.Subscribe(_ => Control.Instance.ServePoint(false));
            LeftTeamBlockPointCommand.Subscribe(_ => Control.Instance.BlockPoint(true));
            RightTeamBlockPointCommand.Subscribe(_ => Control.Instance.BlockPoint(false));
            LeftTeamAttackPointCommand.Subscribe(_ => Control.Instance.AttackPoint(true));
            RightTeamAttackPointCommand.Subscribe(_ => Control.Instance.AttackPoint(false));
            LeftTeamServeErrorCommand.Subscribe(_ => Control.Instance.ServeError(true));
            RightTeamServeErrorCommand.Subscribe(_ => Control.Instance.ServeError(false));

            PointLeft = Control.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            PointRight = Control.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            SetLeft = Control.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            SetRight = Control.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            TeamRight = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            TeamLeft = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            TimeOutRight = Control.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            TimeOutLeft = Control.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            IsLeftServe = Control.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();

            ColorCodeLeftTeam = Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
            ColorCodeRightTeam = Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();

            Set = Control.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();

            EnableLeftMinus = Control.Instance.EnableLeftMinus.ObserveProperty(x => x.Value).ToReactiveProperty();
            EnableRightMinus = Control.Instance.EnableRightMinus.ObserveProperty(x => x.Value).ToReactiveProperty();
            EnableLeftPlus = Control.Instance.EnableLeftPlus.ObserveProperty(x => x.Value).ToReactiveProperty();
            EnableRightPlus = Control.Instance.EnableRightPlus.ObserveProperty(x => x.Value).ToReactiveProperty();

        }
        public ReactiveProperty<int> Set { get; set; }

        public ReactiveCommand DisplayCommand { get; set; } = new();
        public ReactiveCommand TechnicalTimeoutCommand { get; set; } = new();
        public ReactiveCommand LeftTimeoutCommand { get; set; } = new();
        public ReactiveCommand RightTimeoutCommand { get; set; } = new();
        public ReactiveCommand PointPlusRightCommand { get; set; } = new();
        public ReactiveCommand PointPlusLeftCommand { get; set; } = new();
        public ReactiveCommand PointMinusRightCommand { get; set; } = new();
        public ReactiveCommand PointMinusLeftCommand { get; set; } = new();
        public ReactiveCommand CourtChangeCommand { get; set; } = new();
        public ReactiveCommand GetSetDisplayCommand { get; set; } = new();
        public ReactiveCommand SettingCommand { get; set; } = new();

        public ReactiveCommand LeftTeamServePointCommand { get; set; } = new();
        public ReactiveCommand RightTeamServePointCommand { get; set; } = new();
        public ReactiveCommand LeftTeamBlockPointCommand { get; set; } = new();
        public ReactiveCommand RightTeamBlockPointCommand { get; set; } = new();
        public ReactiveCommand LeftTeamAttackPointCommand { get; set; } = new();
        public ReactiveCommand RightTeamAttackPointCommand { get; set; } = new();

        public ReactiveCommand LeftTeamServeErrorCommand { get; set; } = new();
        public ReactiveCommand RightTeamServeErrorCommand { get; set; } = new();

        public ReactiveCommand LeftTeamErrorCommand { get; set; } = new();
        public ReactiveCommand RightTeamErrorCommand { get; set; } = new();

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



        public ReactiveProperty<int> PointLeft { get; set; }
        public ReactiveProperty<int> PointRight { get; set; }
        public ReactiveProperty<int> SetLeft { get; set; }
        public ReactiveProperty<int> SetRight { get; set; }
        public ReactiveProperty<string> TeamRight { get; set; }
        public ReactiveProperty<string> TeamLeft { get; set; }

        public ReactiveProperty<bool> EnableLeftMinus { get; set; }
        public ReactiveProperty<bool> EnableRightMinus { get; set; }

        public ReactiveProperty<bool> EnableLeftPlus { get; set; }
        public ReactiveProperty<bool> EnableRightPlus { get; set; }

        public ReactiveProperty<int> TimeOutRight { get; set; }
        public ReactiveProperty<int> TimeOutLeft { get; set; }

        public ReactiveProperty<bool> IsLeftServe { get; set; }

        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; }
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; }

    }
}
