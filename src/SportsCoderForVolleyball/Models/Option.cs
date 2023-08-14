using SportsCoderForVolleyball.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static SportsCoderForVolleyball.Models.Data;

namespace SportsCoderForVolleyball.Models
{
    public class Option
    {
        public static void LeftTimeout()
        {
            UI.Instance.TimeOutLeft.Value++;
            UI.Instance.ShowMessage("TIME OUT", true, 5);
        }
        public static void RightTimeOut()
        {
            UI.Instance.TimeOutRight.Value++;
            UI.Instance.ShowMessage("TIME OUT", false, 5);
        }
        public static void TechnicalTimeOut() => UI.Instance.ShowMessage("TECHNICAL TIMEOUT", autoHideSeconds: 10);

        public static async void InfomationScore()
        {
            if (UI.Instance.IsDisplayScoreboard.Value)
            {
                //表示されているとき
                if (UI.Instance.IsDisplayGetSet.Value)
                {
                    UI.Instance.IsDisplayGetSet.Value = false;
                }
                else
                {
                    UI.Instance.HideMessage();
                    await Task.Delay(1000);
                    UI.Instance.IsDisplayScoreboard.Value = false;
                }
            }
            else
            {
                //未表示のとき

                UI.Instance.IsDisplayScoreboard.Value = true;
                if (UI.Instance.IsDisplayGetSet.Value)
                {
                    UI.Instance.IsDisplayGetSet.Value = false;
                }
                //await.Control DetectSetPoint();
            }
        }
        public static void InfomationStatistics()
        {
            if (UI.Instance.IsDisplaySetStuts.Value)
            {
                UI.Instance.IsDisplaySetStuts.Value = false;
            }
            else
            {
                UI.Instance.IsDisplaySetStuts.Value = true;
            }
        }
        public static void InfomationPointParSet()
        {
            if (UI.Instance.IsDisplayPointParSet.Value)
            {
                UI.Instance.IsDisplayPointParSet.Value = false;
            }
            else
            {
                var itemsorce = new List<PointParSetInfomationSource>();
                foreach (var item in Instance.Sets.Value)
                {
                    if (UI.Instance.IsATeamLeft.Value)
                    {
                        itemsorce.Add(new PointParSetInfomationSource()
                        {
                            Left = item.ATeamPoint,
                            Right= item.BTeamPoint
                        });
                    }
                    else
                    {
                        itemsorce.Add(new PointParSetInfomationSource()
                        {
                            Right = item.ATeamPoint,
                            Left = item.BTeamPoint
                        });
                    }
                }

                UI.Instance.ShowPointParSet(itemsorce);
            }
        }
        public static void InfomationSet()
        {
            if (UI.Instance.IsDisplayGetSet.Value)
            {
                UI.Instance.IsDisplayGetSet.Value = false;
            }
            else
            {
                UI.Instance.IsDisplayGetSet.Value = true;
            }
        }
        public static void InfomationAttackPoint() => UI.Instance.ShowMessage("ATTACK POINT", Instance.GameLeftTeamAttackPoint.Value.ToString(), Instance.GameRightTeamAttackPoint.Value.ToString(), autoHideSeconds: 5);
        public static void InfomationBlockPoint() => UI.Instance.ShowMessage("BLOCK POINT", Instance.GameLeftTeamBlockPoint.Value.ToString(), Instance.GameRightTeamBlockPoint.Value.ToString(), autoHideSeconds: 5);
        public static void InfomationServePoint() => UI.Instance.ShowMessage("SERVE POINT", Instance.GameLeftTeamServePoint.Value.ToString(), Instance.GameRightTeamServePoint.Value.ToString(), autoHideSeconds: 5);
        public static void InfomationServeError() => UI.Instance.ShowMessage("SERVE ERROR", Instance.GameLeftTeamServeError.Value.ToString(), Instance.GameRightTeamServeError.Value.ToString(), autoHideSeconds: 5);
    }
}
