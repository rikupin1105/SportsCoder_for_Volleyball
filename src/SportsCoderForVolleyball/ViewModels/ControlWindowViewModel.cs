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
        private readonly IDialogService _dialogService;

        public ControlWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Data.Instance.Control.SetService(_dialogService);

            new Views.MainWindow().Show();

            DisplayCommand.Subscribe(_ => Option.InfomationScore());
            TechnicalTimeoutCommand.Subscribe(_ => Option.TechnicalTimeOut());
            LeftTimeoutCommand.Subscribe(_ => Option.LeftTimeout());
            RightTimeoutCommand.Subscribe(_ => Option.RightTimeOut());
            GetSetDisplayCommand.Subscribe(_ => Option.InfomationSet());

            CourtChangeCommand.Subscribe(_ => Data.Instance.Control.CourtChange());
            SettingCommand.Subscribe(_ => { _dialogService.Show("SettingDialog", new DialogParameters(), result => { }, "DialogWindow"); });

            LeftTeamServePointCommand.Subscribe(_ => Data.Instance.Point.ServePoint(true));
            RightTeamServePointCommand.Subscribe(_ => Data.Instance.Point.ServePoint(false));
            LeftTeamBlockPointCommand.Subscribe(_ => Data.Instance.Point.BlockPoint(true));
            RightTeamBlockPointCommand.Subscribe(_ => Data.Instance.Point.BlockPoint(false));
            LeftTeamAttackPointCommand.Subscribe(_ => Data.Instance.Point.AttackPoint(true));
            RightTeamAttackPointCommand.Subscribe(_ => Data.Instance.Point.AttackPoint(false));
            LeftTeamServeErrorCommand.Subscribe(_ => Data.Instance.Point.ServeError(true));
            RightTeamServeErrorCommand.Subscribe(_ => Data.Instance.Point.ServeError(false));
            LeftTeamErrorCommand.Subscribe(_ => Data.Instance.Point.Error(true));
            RightTeamErrorCommand.Subscribe(_ => Data.Instance.Point.Error(false));
            UndoCommand.Subscribe(_ => Data.Instance.Control.Undo());
            SwitchServerCommand.Subscribe(_ => Control.SwitchServer());

            //プレー統計
            StatisticsAttackPointCommand.Subscribe(_ => Option.InfomationAttackPoint());
            StatisticsBlockPointCommand.Subscribe(_ => Option.InfomationBlockPoint());
            StatisticsServePointCommand.Subscribe(_ => Option.InfomationServePoint());
            StatisticsServeErrorCommand.Subscribe(_ => Option.InfomationServeError());

            //色
            ColorCodeLeftTeam = Data.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
            ColorCodeRightTeam = Data.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        }
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
        public ReactiveCommand UndoCommand { get; set; } = new();
        public ReactiveCommand SwitchServerCommand { get; set; } = new();

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

        //統計ボタン
        public ReactiveCommand StatisticsAttackPointCommand { get; set; } = new();
        public ReactiveCommand StatisticsBlockPointCommand { get; set; } = new();
        public ReactiveCommand StatisticsServePointCommand { get; set; } = new();
        public ReactiveCommand StatisticsServeErrorCommand { get; set; } = new();
        public ReactiveCommand StatisticsNoIndicatedCommand { get; set; } = new();

        //セット統計用
        public ReactiveProperty<int> LeftTeamServePoint { get; set; } = Data.Instance.LeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServePoint { get; set; } = Data.Instance.RightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamAttackPoint { get; set; } = Data.Instance.LeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamAttackPoint { get; set; } = Data.Instance.RightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamBlockPoint { get; set; } = Data.Instance.LeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamBlockPoint { get; set; } = Data.Instance.RightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamServeError { get; set; } = Data.Instance.LeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamServeError { get; set; } = Data.Instance.RightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> LeftTeamError { get; set; } = Data.Instance.LeftTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> RightTeamError { get; set; } = Data.Instance.RightTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();

        //プレー統計表示
        public ReactiveProperty<int> GameLeftTeamServePoint { get; set; } = Data.Instance.GameLeftTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServePoint { get; set; } = Data.Instance.GameRightTeamServePoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamAttackPoint { get; set; } = Data.Instance.GameLeftTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamAttackPoint { get; set; } = Data.Instance.GameRightTeamAttackPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamBlockPoint { get; set; } = Data.Instance.GameLeftTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamBlockPoint { get; set; } = Data.Instance.GameRightTeamBlockPoint.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamServeError { get; set; } = Data.Instance.GameLeftTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamServeError { get; set; } = Data.Instance.GameRightTeamServeError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameLeftTeamError { get; set; } = Data.Instance.GameLeftTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> GameRightTeamError { get; set; } = Data.Instance.GameRightTeamError.ObserveProperty(x => x.Value).ToReactiveProperty();

        public ReactiveProperty<bool> GuiEnable { get; set; } = Data.Instance.GuiEnable.ObserveProperty(x => x.Value).ToReactiveProperty();


        //UI部品
        public ReactiveProperty<int> Set { get; set; } = Data.Instance.Set.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamRight { get; set; } = Data.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> TeamLeft { get; set; } = Data.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointLeft { get; set; } = Data.Instance.PointLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> PointRight { get; set; } = Data.Instance.PointRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetLeft { get; set; } = Data.Instance.SetLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> SetRight { get; set; } = Data.Instance.SetRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutRight { get; set; } = Data.Instance.TimeOutRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOutLeft { get; set; } = Data.Instance.TimeOutLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsLeftServe { get; set; } = Data.Instance.IsLeftServe.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> IsRightServe { get; set; } = Data.Instance.IsRightServe.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = Data.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = Data.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
    }
}