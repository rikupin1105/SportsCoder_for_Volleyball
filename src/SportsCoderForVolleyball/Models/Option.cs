using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static SportsCoderForVolleyball.Models.Control;
using static SportsCoderForVolleyball.Models.Data;

namespace SportsCoderForVolleyball.Models
{
    public class Option
    {
        public void LeftTimeout()
        {
            Instance.TimeOutLeft.Value++;
            Instance.ShowMessage("TIME OUT", true, 5);
        }
        public void RightTimeOut()
        {
            Instance.TimeOutRight.Value++;
            Instance.ShowMessage("TIME OUT", false, 5);
        }
        public void TechnicalTimeOut()
        {
            Instance.ShowMessage("TECHNICAL TIMEOUT", autoHideSeconds: 10);
        }
        public void InfomationScore()
        {
            if (Instance.IsDisplayScoreboard.Value)
            {
                //表示されているとき
                if (Instance.IsDisplayGetSet.Value)
                {
                    Instance.IsDisplayGetSet.Value = false;
                }
                else
                {
                    Instance.HideMessage();
                    Instance.IsDisplayScoreboard.Value = false;
                }
            }
            else
            {
                //未表示のとき

                Instance.IsDisplayScoreboard.Value = true;
                if (Instance.IsDisplayGetSet.Value)
                {
                    Instance.IsDisplayGetSet.Value = false;
                }
                //await.Control DetectSetPoint();
            }
        }
        public static void InfomationStatistics()
        {
            if (Instance.IsDisplaySetStuts.Value)
            {
                Instance.IsDisplaySetStuts.Value = false;
            }
            else
            {
                Instance.IsDisplaySetStuts.Value = true;
            }
        }
        public void InfomationPointParSet()
        {
            if (Instance.IsDisplayPointParSet.Value)
            {
                Instance.IsDisplayPointParSet.Value = false;
            }
            else
            {

                var itemsorce = new List<PointParSetInfomationSource>();
                foreach (var item in Instance.Sets.Value)
                {
                    if (Instance.IsATeamLeft.Value)
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

                Instance.PointParSetSource.Clear();
                Instance.PointParSetSource.AddRange(itemsorce);

                Instance.IsDisplayPointParSet.Value = true;
            }
        }
        public static void InfomationSet()
        {
            if (Instance.IsDisplayGetSet.Value)
            {
                Instance.IsDisplayGetSet.Value = false;
            }
            else
            {
                Instance.IsDisplayGetSet.Value = true;
            }
        }
        public void InfomationAttackPoint()
        {
            Instance.ShowMessage("ATTACK POINT", Instance.GameLeftTeamAttackPoint.Value.ToString(), Instance.GameRightTeamAttackPoint.Value.ToString(), autoHideSeconds: 5);
        }
        public void InfomationBlockPoint()
        {
            Instance.ShowMessage("BLOCK POINT", Instance.GameLeftTeamBlockPoint.Value.ToString(), Instance.GameRightTeamBlockPoint.Value.ToString(), autoHideSeconds: 5);
        }
        public void InfomationServePoint()
        {
            Instance.ShowMessage("SERVE POINT", Instance.GameLeftTeamServePoint.Value.ToString(), Instance.GameRightTeamServePoint.Value.ToString(), autoHideSeconds: 5);
        }
        public void InfomationServeError()
        {
            Instance.ShowMessage("SERVE ERROR", Instance.GameLeftTeamServeError.Value.ToString(), Instance.GameRightTeamServeError.Value.ToString(), autoHideSeconds: 5);
        }
    }
}
