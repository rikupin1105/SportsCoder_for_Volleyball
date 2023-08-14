using Reactive.Bindings;

namespace SportsCoderForVolleyball.Shared
{
    public class UI
    {
        public static UI Instance { get; } = new();
        public UI() 
        {

        }
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

            //別のメッセージが表示されている場合は、閉じる
            if (IsMessageShow && forceNoHide == false)
            {
                HideMessage();
                await Task.Delay(1000);
            }

            //スコアが表示されていない場合、分離メッセージを表示する
            IsMessageShow = true;
            Message.Value = message;

            if (UI.Instance.IsDisplayScoreboard.Value == false)
            {
                switch (LeftTeam)
                {
                    case null:
                        IsDisplaySeparatedMessage.Value = true;
                        break;
                    case true:
                        IsDisplaySeparatedMessageLeft.Value = true;
                        break;
                    case false:
                        IsDisplaySeparatedMessageRight.Value = true;
                        break;
                }
            }
            else
            {
                switch (LeftTeam)
                {
                    case null:
                        IsDisplayMessage.Value = true;
                        break;
                    case true:
                        IsDisplayMessageLeft.Value = true;
                        break;
                    case false:
                        IsDisplayMessageRight.Value = true;
                        break;
                }
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
                if (IsMessageShow == true)
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
            IsDisplaySeparatedMessageLeft.Value = false;
            IsDisplaySeparatedMessageRight.Value = false;
            IsDisplayMessage.Value = false;
            IsDisplaySeparatedMessage.Value = false;
            IsDisplayInfomation.Value = false;

            IsMessageShow = false;
        }

        /// <summary>
        /// スコアボードを表示します
        /// </summary>
        public void ShowScoreboard()
        {
            if (IsDisplayScoreboard.Value)
            {
                return;
            }

            HideMessage();
            IsDisplayScoreboard.Value = true;
        }

        /// <summary>
        /// 縦左のスコアボードを表示します
        /// </summary>
        public void ShowVerticalScoreboard()
        {
            if (IsDisplayVerticalLeftScoreboard.Value)
            {
                return;
            }
            HideMessage();
            IsDisplayVerticalLeftScoreboard.Value = true;
        }

        public void ShowPointParSet(List<PointParSetInfomationSource> source)
        {
            PointParSetSource.Clear();
            PointParSetSource.AddRangeOnScheduler(source);

            IsDisplayPointParSet.Value = true;
        }
        public void HidePointParSet() => IsDisplayPointParSet.Value = false;


        public ReactiveProperty<bool> IsDisplayScoreboard { get; } = new(true);
        public ReactiveProperty<bool> IsDisplayVerticalLeftScoreboard { get; } = new(true);


        private bool IsMessageShow { get; set; }
        public ReactiveProperty<string> Message { get; } = new();
        public ReactiveProperty<string> MessageLeft { get; } = new();
        public ReactiveProperty<string> MessageRight { get; } = new();
        public ReactiveProperty<bool> IsDisplayMessageLeft { get; } = new();
        public ReactiveProperty<bool> IsDisplayMessageRight { get; } = new();

        public ReactiveProperty<bool> IsDisplaySeparatedMessageLeft { get; } = new();
        public ReactiveProperty<bool> IsDisplaySeparatedMessageRight { get; } = new();
        public ReactiveProperty<bool> IsDisplaySeparatedMessage { get; } = new();

        public ReactiveProperty<bool> IsDisplayMessage { get; } = new();
        public ReactiveProperty<bool> IsDisplayInfomation { get; } = new();
        public ReactiveProperty<bool> IsDisplayCommonMessage { get; } = new(false);

        public ReactiveProperty<bool> IsDisplayGetSet { get; } = new(false);
        public ReactiveProperty<bool> IsDisplayPointParSet { get; } = new(false);
        public ReactiveProperty<bool> IsDisplaySetStuts { get; } = new(false);
        public ReactiveProperty<bool> IsDisplayGameStuts { get; } = new(false);

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

        public ReactiveCollection<PointParSetInfomationSource> PointParSetSource { get; set; } = new();
    }
}