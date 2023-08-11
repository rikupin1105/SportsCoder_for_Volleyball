using Reactive.Bindings;

namespace SportsCoderForVolleyball.Shared
{
    public class UI
    {
        public static UI Instance { get; } = new();
        /// <summary>
        /// メッセージを表示します
        /// </summary>
        /// <param name="message">表示内容</param>
        /// <param name="LeftTeam"></param>
        /// <param name="autoHideSeconds">自動非表示(秒数)</param>
        /// <param name="forceNoHide">強制的に非表示をオフ</param>
        public async void ShowMessage(string message, bool? LeftTeam = null, int? autoHideSeconds = null, bool? forceNoHide = false)
        {
            //表示中にもう一度押されたら非表示にする。
            if (message == Message.Value &&  forceNoHide == false)
            {
                if (LeftTeam is null && IsDisplayMessage.Value == true)
                {
                    HideMessage();
                    return;
                }
                else if (LeftTeam! == true && IsDisplayMessageLeft.Value == true)
                {
                    HideMessage();
                    return;
                }
                else if (LeftTeam! == false && IsDisplayMessageRight.Value == true)
                {
                    HideMessage();
                    return;
                }
            }

            //スコアが表示されていない場合、表示する
            if (UI.Instance.IsDisplayScoreboard.Value == false)
            {
                UI.Instance.IsDisplayScoreboard.Value = true;
                await Task.Delay(1000);
            }

            //別のメッセージが表示されている場合は、閉じる
            if (IsMessageShow && forceNoHide == false)
            {
                HideMessage();
                await Task.Delay(1000);
            }

            IsMessageShow = true;
            Message.Value = message;

            if (LeftTeam is null)
            {
                IsDisplayMessage.Value = true;
            }
            else if ((bool)LeftTeam)
            {
                IsDisplayMessageLeft.Value = true;
            }
            else
            {
                IsDisplayMessageRight.Value = true;
            }

            if (autoHideSeconds is not null)
            {
                for (int i = 0; i < autoHideSeconds; i++)
                {
                    if (IsMessageShow == false)
                    {
                        return;
                    }
                    await Task.Delay(1000);
                }
                HideMessage();
            }
        }

        /// <summary>
        /// メッセージを表示します
        /// </summary>
        /// <param name="message">表示内容</param>
        /// <param name="messageLeft">左側</param>
        /// <param name="messageRight">右側</param>
        /// <param name="autoHideSeconds">自動非表示(秒数)</param>
        /// <param name="forceNoHide">強制的に非表示をオフ</param>
        public async void ShowMessage(string message, string messageLeft, string messageRight, int? autoHideSeconds = null, bool? forceNoHide = false)
        {
            //表示中にもう一度押されたら非表示にする。
            if (message == Message.Value && messageLeft == MessageLeft.Value  && messageRight==MessageRight.Value && forceNoHide == false)
            {
                if (IsDisplayMessage.Value == true)
                {
                    HideMessage();
                    return;
                }
            }

            //スコアが表示されていない場合、表示する
            if (UI.Instance.IsDisplayScoreboard.Value == false)
            {
                UI.Instance.IsDisplayScoreboard.Value = true;
                await Task.Delay(1000);
            }

            //別のメッセージが表示されている場合は、閉じる
            if (IsMessageShow && forceNoHide == false)
            {
                HideMessage();
                await Task.Delay(1000);
            }

            IsMessageShow = true;
            Message.Value = message;
            MessageLeft.Value = messageLeft;
            MessageRight.Value = messageRight;
            IsDisplayInfomation.Value = true;

            if (autoHideSeconds is not null)
            {
                for (int i = 0; i < autoHideSeconds; i++)
                {
                    if (IsMessageShow == false)
                    {
                        return;
                    }
                    await Task.Delay(1000);
                }
                HideMessage();
            }
        }

        /// <summary>
        /// メッセージを非表示にします
        /// </summary>
        public void HideMessage()
        {
            IsDisplayMessageLeft.Value = false;
            IsDisplayMessageRight.Value = false;
            IsDisplayMessage.Value = false;
            IsDisplayInfomation.Value = false;

            IsMessageShow = false;
        }


        public ReactiveProperty<bool> IsDisplayScoreboard = new(true);
        private bool IsMessageShow { get; set; }
        public ReactiveProperty<string> Message { get; private set; } = new();
        public ReactiveProperty<string> MessageLeft { get; private set; } = new();
        public ReactiveProperty<string> MessageRight { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayMessageLeft { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayMessageRight { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayMessage { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayInfomation { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout = new(false);

        public ReactiveProperty<bool> IsDisplayGetSet = new(false);
        public ReactiveProperty<bool> IsDisplayPointParSet = new(false);
        public ReactiveProperty<bool> IsDisplaySetStuts = new(false);
        public ReactiveProperty<bool> IsDisplayGameStuts = new(false);

        //UI部品
        public ReactiveProperty<int> Set = new(1);
        public ReactiveProperty<string> TeamLeft = new("USA");
        public ReactiveProperty<string> TeamRight = new("JPN");
        public ReactiveProperty<int> PointLeft = new(0);
        public ReactiveProperty<int> PointRight = new(0);
        public ReactiveProperty<int> SetLeft = new(0);
        public ReactiveProperty<int> SetRight = new(0);
        public ReactiveProperty<int> TimeOutRight = new(0);
        public ReactiveProperty<int> TimeOutLeft = new(0);
        public ReactiveProperty<bool> IsLeftServe = new(true);
        public ReactiveProperty<bool> IsRightServe = new(false);
        public ReactiveProperty<bool> IsATeamLeft = new(true);
        public ReactiveProperty<string> ColorCodeLeftTeam = new("#ffffff");
        public ReactiveProperty<string> ColorCodeRightTeam = new("#000000");
        public ReactiveProperty<string> BackGroundColor = new("#00ff00");
    }
}