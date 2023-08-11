using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SportsCoderForVolleyball.Models;
using SportsCoderForVolleyball.Shared;
using System;

namespace SportsCoderForVolleyball.ViewModels
{
    public class SettingDialogViewModel : BindableBase, IDialogAware
    {
        public SettingDialogViewModel()
        {
            SubmitCommand.Subscribe(_ =>
            {
                Data.Instance.POINT.Value = int.Parse(ComboPoint.Value);
                Data.Instance.SET.Value = int.Parse(ComboSet.Value);
                Data.Instance.NEEDSET.Value = (int.Parse(ComboSet.Value) - 1) /2 + 1;
                Data.Instance.LASTSETPOINT.Value = int.Parse(ComboLastSet.Value);
                Data.Instance.COURTCHANGE.Value = CourtChange.Value;

                Data.Instance.TIMEOUT.Value = TimeOut.Value;

                UI.Instance.TeamLeft.Value = ATeamName.Value;
                UI.Instance.TeamRight.Value = BTeamName.Value;

                //UI.Instance.ColorCodeLeftTeam.Value = ATeamColorCode.Value;
                //UI.Instance.ColorCodeRightTeam.Value = BTeamColorCode.Value;

                UI.Instance.BackGroundColor.Value = BackGroundColor.Value;

                if (Server.Value == "左")
                {
                    UI.Instance.IsLeftServe.Value = true;
                    UI.Instance.IsRightServe.Value = false;

                    Data.Instance.IsLeftFirstServe.Value = true;
                }
                else
                {
                    UI.Instance.IsLeftServe.Value = false;
                    UI.Instance.IsRightServe.Value = true;

                    Data.Instance.IsLeftFirstServe.Value = false;
                }

                RequestClose.Invoke(null);
            });
        }

        public ReactiveCommand SubmitCommand { get; } = new();

        //設定
        public ReactiveProperty<string> ATeamName { get; set; } = UI.Instance.TeamLeft.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BTeamName { get; set; } = UI.Instance.TeamRight.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> Set { get; set; } = Data.Instance.SET.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<int> Point { get; set; } = Control.Instance.POINT.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<int> LastSetPoint { get; set; } = Control.Instance.LASTSETPOINT.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<bool> CourtChange { get; set; } = Data.Instance.COURTCHANGE.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<int> TimeOut { get; set; } = Data.Instance.TIMEOUT.ObserveProperty(x => x.Value).ToReactiveProperty();

        //色
        //public ReactiveProperty<string> ATeamColorCode { get; set; } = Data.Instance.ColorCodeLeftTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        //public ReactiveProperty<string> BTeamColorCode { get; set; } = Data.Instance.ColorCodeRightTeam.ObserveProperty(x => x.Value).ToReactiveProperty();
        public ReactiveProperty<string> BackGroundColor { get; set; } = UI.Instance.BackGroundColor.ObserveProperty(x => x.Value).ToReactiveProperty();


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

            if (Data.Instance.IsLeftFirstServe.Value)
            {
                ServerIndex.Value = 0;
            }
            else
            {
                ServerIndex.Value = 1;
            }

            ComboSetIndex.Value = Data.Instance.SET.Value switch
            {
                7 => 0,
                5 => 1,
                3 => 2,
                1 => 3,
                _ => 1,
            };

            ComboPointIndex.Value = Data.Instance.POINT.Value switch
            {
                25 => 0,
                21 => 1,
                15 => 2,
                _ => 1,
            };

            ComboLastSetIndex.Value = Data.Instance.LASTSETPOINT.Value switch
            {
                25 => 0,
                21 => 1,
                15 => 2,
                _ => 2,
            };

            ComboTimeOutIndex.Value = Data.Instance.TIMEOUT.Value switch
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