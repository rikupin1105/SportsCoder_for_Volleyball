﻿using System.Collections.Generic;
using System.Threading.Tasks;
using static SportsCoderForVolleyball.Models.Control;
using static SportsCoderForVolleyball.Models.Data;

namespace SportsCoderForVolleyball.Models
{
    public class Option
    {
        private bool _stopTechnicalTimeout = false;
        private bool _stopLeftTimeOut = false;
        private bool _stopRightTimeOut = false;
        public async Task DeleteOption(bool wait = true)
        {
            var flag = IsDispleyOption();
            Instance.IsDisplayRightSetPoint.Value = false;
            Instance.TimeOutLeft.Value++;
            Instance.ShowMessage("TIME OUT", true, 5);
        }
        public void RightTimeOut()
        {
                await DeleteOption();
            }
            else
            {
            Instance.TimeOutRight.Value++;
            Instance.ShowMessage("TIME OUT", false, 5);
        }
        public void TechnicalTimeOut()
        {
            }
            else
            {
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }

                await DeleteOption();
                Instance.IsDisplayTechnicalTimeout.Value = true;
                _stopTechnicalTimeout = false;
                for (int i = 0; i < 300; i++)
                {
                    if (_stopTechnicalTimeout)
                    {
                        Instance.IsDisplayTechnicalTimeout.Value = false;
                        _stopTechnicalTimeout = false;
                        await Task.Delay(1000);
                        //await.Control DetectSetPoint();
                        return;
                    }
                    await Task.Delay(100);
                }
                Instance.IsDisplayTechnicalTimeout.Value = false;
            }
        }
        public async void InfomationScore()
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
                    await DeleteOption();
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
                Instance.PointParSetSource.Value = itemsorce;

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
