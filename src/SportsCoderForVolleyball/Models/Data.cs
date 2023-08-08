using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SportsCoderForVolleyball.Models.Control;

namespace SportsCoderForVolleyball.Models
{
    public class Data
    {
        public static Data Instance { get; } = new();
        public ReactiveCollection<string> History { get; set; } = new ReactiveCollection<string>() { "S" };

        public ReactiveProperty<List<Set>> Sets = new(new List<Set>());
        public ReactiveProperty<List<PointParSetInfomationSource>> PointParSetSource { get; set; } = new();

        public Option Option { get; set; } = new();
        public Point Point { get; set; } = new();
        public Control Control { get; set; } = new();

        //アニメーション

        /// <summary>
        /// 
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
                if (LeftTeam is null && isDisplayMessage.Value == true)
                {
                    HideMessage();
                    return;
                }
                else if (LeftTeam! == true && isDisplayMessageLeft.Value == true)
                {
                    HideMessage();
                    return;
                }
                else if (LeftTeam! == false && isDisplayMessageRight.Value == true)
                {
                    HideMessage();
                    return;
                }
            }

            //スコアが表示されていない場合、表示する
            if (IsDisplayScoreboard.Value == false)
            {
                Instance.IsDisplayScoreboard.Value = true;
                await Task.Delay(1000);
            }

            //別のメッセージが表示されている場合は、閉じる
            if (isMessageShow && forceNoHide == false)
            {
                HideMessage();
                await Task.Delay(1000);
            }

            isMessageShow = true;
            Message.Value = message;

            if (LeftTeam is null)
            {
                isDisplayMessage.Value = true;
            }
            else if ((bool)LeftTeam)
            {
                isDisplayMessageLeft.Value = true;
            }
            else
            {
                isDisplayMessageRight.Value = true;
            }

            if (autoHideSeconds is not null)
            {
                for (int i = 0; i < autoHideSeconds; i++)
                {
                    if (isMessageShow == false)
                    {
                        return;
                    }
                    await Task.Delay(1000);
                }
                HideMessage();
            }
        }
        public void HideMessage()
        {
            isDisplayMessageLeft.Value = false;
            isDisplayMessageRight.Value = false;
            isMessageShow = false;
        }
        private bool isMessageShow { get; set; }
        public ReactiveProperty<string> Message { get; private set; } = new();
        public ReactiveProperty<bool> isDisplayMessageLeft { get; private set; } = new();
        public ReactiveProperty<bool> isDisplayMessageRight { get; private set; } = new();
        public ReactiveProperty<bool> isDisplayMessage { get; private set; } = new();
        public ReactiveProperty<bool> IsDisplayScoreboard = new(true);
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout = new(false);
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining = new(false);
        public ReactiveProperty<bool> IsDisplayGetSet = new(false);
        public ReactiveProperty<bool> IsDisplayPointParSet = new(false);
        public ReactiveProperty<bool> IsDisplaySetStuts = new(false);
        public ReactiveProperty<bool> IsDisplayGameStuts = new(false);

        //プレー統計アニメーション
        public ReactiveProperty<bool> IsDisplayAttackPointInfomation = new(false);
        public ReactiveProperty<bool> IsDisplayBlockPointInfomation = new(false);
        public ReactiveProperty<bool> IsDisplayServePointInfomation = new(false);
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation = new(false);

        //セット統計
        public ReactiveProperty<int> LeftTeamServePoint = new(0);
        public ReactiveProperty<int> RightTeamServePoint = new(0);
        public ReactiveProperty<int> LeftTeamAttackPoint = new(0);
        public ReactiveProperty<int> RightTeamAttackPoint = new(0);
        public ReactiveProperty<int> LeftTeamBlockPoint = new(0);
        public ReactiveProperty<int> RightTeamBlockPoint = new(0);
        public ReactiveProperty<int> LeftTeamServeError = new(0);
        public ReactiveProperty<int> RightTeamServeError = new(0);
        public ReactiveProperty<int> LeftTeamError = new(0);
        public ReactiveProperty<int> RightTeamError = new(0);
        public ReactiveProperty<int> LeftTeamOpponentError = new(0);
        public ReactiveProperty<int> RightTeamOpponentError = new(0);

        //ゲーム統計
        public ReactiveProperty<int> GameLeftTeamPoint = new(0);
        public ReactiveProperty<int> GameRightTeamPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamServePoint = new(0);
        public ReactiveProperty<int> GameRightTeamServePoint = new(0);
        public ReactiveProperty<int> GameLeftTeamAttackPoint = new(0);
        public ReactiveProperty<int> GameRightTeamAttackPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamBlockPoint = new(0);
        public ReactiveProperty<int> GameRightTeamBlockPoint = new(0);
        public ReactiveProperty<int> GameLeftTeamServeError = new(0);
        public ReactiveProperty<int> GameRightTeamServeError = new(0);
        public ReactiveProperty<int> GameLeftTeamError = new(0);
        public ReactiveProperty<int> GameRightTeamError = new(0);
        public ReactiveProperty<int> GameLeftTeamOpponentError = new(0);
        public ReactiveProperty<int> GameRightTeamOpponentError = new(0);

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

        public ReactiveProperty<bool> GuiEnable = new(true);

        //ルール
        public ReactiveProperty<int> TIMEOUT = new(2);
        public ReactiveProperty<int> SET = new(5);
        public ReactiveProperty<int> NEEDSET = new(3);
        public ReactiveProperty<int> POINT = new(25);
        public ReactiveProperty<int> LASTSETPOINT = new(15);
        public ReactiveProperty<bool> COURTCHANGE = new(true);

        public ReactiveProperty<bool> IsLeftFirstServe = new(true);


        
    }
}
