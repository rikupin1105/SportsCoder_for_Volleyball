using Prism.Commands;
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
            ATeamName =     Control.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
            BTeamName =     Control.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
            Point =         Control.Instance.POINT.ObserveProperty(x => x.Value).ToReactiveProperty();
            Set =           Control.Instance.SET.ObserveProperty(x => x.Value).ToReactiveProperty();
            LastSetPoint =  Control.Instance.LASTSETPOINT.ObserveProperty(x => x.Value).ToReactiveProperty();
            CourtChange =   Control.Instance.COURTCHANGE.ObserveProperty(x => x.Value).ToReactiveProperty();
            TimeOut =       Control.Instance.TIMEOUT.ObserveProperty(x => x.Value).ToReactiveProperty();
            ATeamColorCode =       Control.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
            BTeamColorCode =       Control.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();


            SubmitCommand.Subscribe(_ =>
            {
                Control.Instance.POINT.Value = Point.Value;
                Control.Instance.SET.Value = Set.Value;
                Control.Instance.NEEDSET.Value = (Set.Value - 1) /2 + 1;
                Control.Instance.LASTSETPOINT.Value = LastSetPoint.Value;
                Control.Instance.COURTCHANGE.Value = CourtChange.Value;
                Control.Instance.TIMEOUT.Value = TimeOut.Value;

                Control.Instance.TeamLeft.Value = ATeamName.Value;
                Control.Instance.TeamRight.Value = BTeamName.Value;

                Control.Instance.ColorCodeLeftTeam.Value = ATeamColorCode.Value;
                Control.Instance.ColorCodeRightTeam.Value = BTeamColorCode.Value;

                RequestClose.Invoke(null);
            });
        }

        public ReactiveCommand SubmitCommand { get; } = new();

        public ReactiveProperty<string> ATeamName { get; set; }
        public ReactiveProperty<string> BTeamName { get; set; }
        public ReactiveProperty<int> Set { get; set; }
        public ReactiveProperty<int> Point { get; set; }
        public ReactiveProperty<int> LastSetPoint { get; set; }
        public ReactiveProperty<bool> CourtChange { get; set; }
        public ReactiveProperty<int> TimeOut { get; set; } = new();

        public ReactiveProperty<string> ATeamColorCode { get; set; }
        public ReactiveProperty<string> BTeamColorCode { get; set; }



        public string Title => "設定";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;
        public void OnDialogClosed() 
        {
            Control.Instance.LockControl(true);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Control.Instance.LockControl(false);
        }
    }
}
