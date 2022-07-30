﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SettingDialogViewModel : BindableBase, IDialogAware
    {
        public SettingDialogViewModel()
        {
            SubmitCommand.Subscribe(_ =>
            {
                Control.Instance.POINT.Value = int.Parse(ComboPoint.Value);
                Control.Instance.SET.Value = int.Parse(ComboSet.Value);
                Control.Instance.NEEDSET.Value = (int.Parse(ComboSet.Value) - 1) /2 + 1;
                Control.Instance.LASTSETPOINT.Value = int.Parse(ComboLastSet.Value);
                Control.Instance.COURTCHANGE.Value = CourtChange.Value;

                Control.Instance.TIMEOUT.Value = TimeOut.Value;

                Control.Instance.TeamLeft.Value = ATeamName.Value;
                Control.Instance.TeamRight.Value = BTeamName.Value;

                Control.Instance.ColorCodeLeftTeam.Value = ATeamColorCode.Value;
                Control.Instance.ColorCodeRightTeam.Value = BTeamColorCode.Value;

                Control.Instance.BackGroundColor.Value = BackGroundColor.Value;

                if (Server.Value == "左")
                {
                    Control.Instance.IsLeftServe.Value = true;
                    Control.Instance.IsRightServe.Value = false;

                    Control.Instance.IsLeftFirstServe.Value = true;
                }
                else
                {
                    Control.Instance.IsLeftServe.Value = false;
                    Control.Instance.IsRightServe.Value = true;

                    Control.Instance.IsLeftFirstServe.Value = false;
                }

                RequestClose.Invoke(null);
            });
        }

        public ReactiveCommand SubmitCommand { get; } = new();

        //設定
        public ReactiveProperty<string> ATeamName { get; set; } = Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BTeamName { get; set; } = Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> Set { get; set; } = Control.Instance.SET.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<int> Point { get; set; } = Control.Instance.POINT.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<int> LastSetPoint { get; set; } = Control.Instance.LASTSETPOINT.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> CourtChange { get; set; } = Control.Instance.COURTCHANGE.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOut { get; set; } = Control.Instance.TIMEOUT.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        public ReactiveProperty<string> ATeamColorCode { get; set; } = Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BTeamColorCode { get; set; } = Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BackGroundColor { get; set; } = Control.Instance.BackGroundColor.ObserveProperty(x => x.Value).ToReactiveProperty();


        //コンボボックス用
        public ReactiveProperty<string> Server { get; set; } = new();
        public ReactiveProperty<int> ServerIndex { get; set; } = new();

        public ReactiveProperty<string> ComboSet { get; set; } = new();
        public ReactiveProperty<int> ComboSetIndex { get; set; } = new();

        public ReactiveProperty<string> ComboPoint { get; set; } = new();
        public ReactiveProperty<int> ComboPointIndex { get; set; } = new();

        public ReactiveProperty<string> ComboLastSet { get; set; } = new();
        public ReactiveProperty<int> ComboLastSetIndex { get; set; } = new();

        public ReactiveProperty<string> ComboTimeOut { get; set; } = new();
        public ReactiveProperty<int> ComboTimeOutIndex { get; set; } = new();


        public string Title => "設定";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;
        public void OnDialogClosed()
        {
            Control.LockControl(true);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Control.LockControl(false);

            if (Control.Instance.IsLeftFirstServe.Value)
            {
                ServerIndex.Value = 0;
            }
            else
            {
                ServerIndex.Value = 1;
            }

            ComboSetIndex.Value = Control.Instance.SET.Value switch
            {
                7 => 0,
                5 => 1,
                3 => 2,
                1 => 3,
                _ => 1,
            };

            ComboPointIndex.Value = Control.Instance.POINT.Value switch
            {
                25 => 0,
                21 => 1,
                15 => 2,
                _ => 1,
            };

            ComboLastSetIndex.Value = Control.Instance.LASTSETPOINT.Value switch
            {
                25 => 0,
                21 => 1,
                15 => 2,
                _ => 2,
            };

            ComboTimeOutIndex.Value = Control.Instance.TIMEOUT.Value switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                3 => 3,
                _ => 2,
            };
        }
    }
}
