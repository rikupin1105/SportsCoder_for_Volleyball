﻿using Prism.Commands;
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

            Control.Instance.SetService(_dialogService);

            new Views.MainWindow().Show();

            DisplayCommand.Subscribe(_ => Control.Instance.InfomationScore());
            TechnicalTimeoutCommand.Subscribe(_ => Control.Instance.TechnicalTimeOut());
            LeftTimeoutCommand.Subscribe(_ => Control.Instance.LeftTimeout());
            RightTimeoutCommand.Subscribe(_ => Control.Instance.RightTimeOut());
            GetSetDisplayCommand.Subscribe(_ => Control.InfomationSet());

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
            LeftTeamErrorCommand.Subscribe(_ => Control.Instance.Error(true));
            RightTeamErrorCommand.Subscribe(_ => Control.Instance.Error(false));
            UndoCommand.Subscribe(_ => Control.Instance.Undo());
            SwitchServerCommand.Subscribe(_ => Control.SwitchServer());

            //プレー統計
            StatisticsAttackPointCommand.Subscribe(_ => Control.Instance.InfomationAttackPoint());
            StatisticsBlockPointCommand.Subscribe(_ => Control.Instance.InfomationBlockPoint());
            StatisticsServePointCommand.Subscribe(_ => Control.Instance.InfomationServePoint());
            StatisticsServeErrorCommand.Subscribe(_ => Control.Instance.InfomationServeError());

            //色
            ColorCodeLeftTeam = Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
            ColorCodeRightTeam = Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
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

        //プレー統計表示
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

        public ReactiveProperty<bool> GuiEnable { get; set; } = Control.Instance.GuiEnable.ObserveProperty(x => x.Value).ToReactiveProperty();


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
    }
}