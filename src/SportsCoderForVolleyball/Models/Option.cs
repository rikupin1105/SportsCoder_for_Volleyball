using System.Collections.Generic;
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

            _stopTechnicalTimeout = true;
            _stopRightTimeOut = true;
            _stopLeftTimeOut = true;

            Instance.IsDisplayRightSetPoint.Value = false;
            Instance.IsDisplayLeftSetPoint.Value = false;
            Instance.IsDisplayRightMatchPoint.Value = false;
            Instance.IsDisplayLeftMatchPoint.Value = false;
            Instance.IsDisplayTimeoutRemaining.Value = false;
            Instance.IsDisplayRightSetPoint.Value = false;
            Instance.IsDisplayRightMatchPoint.Value = false;
            Instance.IsDisplayLeftSetPoint.Value = false;
            Instance.IsDisplayLeftMatchPoint.Value = false;
            Instance.IsDisplayPointParSet.Value = false;
            Instance.IsDisplayAttackPointInfomation.Value = false;
            Instance.IsDisplayBlockPointInfomation.Value = false;
            Instance.IsDisplayServePointInfomation.Value = false;
            Instance.IsDisplayServeErrorInfomation.Value = false;

            if (flag && wait) await Task.Delay(1000);
        }
        private bool IsDispleyOption()
        {
            if (Instance.IsDisplayTechnicalTimeout.Value) return true;
            if (Instance.IsDisplayLeftTimeout.Value) return true;
            if (Instance.IsDisplayRightTimeout.Value) return true;
            if (Instance.IsDisplayRightSetPoint.Value) return true;
            if (Instance.IsDisplayRightMatchPoint.Value) return true;
            if (Instance.IsDisplayLeftSetPoint.Value) return true;
            if (Instance.IsDisplayLeftMatchPoint.Value) return true;
            if (Instance.IsDisplayTimeoutRemaining.Value) return true;
            if (Instance.IsDisplayRightSetPoint.Value) return true;
            if (Instance.IsDisplayRightMatchPoint.Value) return true;
            if (Instance.IsDisplayLeftSetPoint.Value) return true;
            if (Instance.IsDisplayLeftMatchPoint.Value) return true;
            if (Instance.IsDisplayPointParSet.Value) return true;

            if (Instance.IsDisplayAttackPointInfomation.Value) return true;
            if (Instance.IsDisplayBlockPointInfomation.Value) return true;
            if (Instance.IsDisplayServePointInfomation.Value) return true;
            if (Instance.IsDisplayServeErrorInfomation.Value) return true;

            if (Instance.IsDisplayGetSet.Value) return true;
            return false;
        }
        public async void LeftTimeout()
        {
            if (Instance.IsDisplayLeftTimeout.Value  || Instance.IsDisplayTimeoutRemaining.Value)
            {
                //すでに表示されている
                await DeleteOption();
            }
            else
            {
                Instance.TimeOutLeft.Value++;
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }

                await DeleteOption();


                Instance.History.Add("TL");

                Instance.IsDisplayLeftTimeout.Value = true;
                _stopLeftTimeOut = false;
                for (int i = 0; i < 160; i++)
                {
                    if (_stopLeftTimeOut)
                    {
                        _stopLeftTimeOut = false;
                        break;
                    }
                    if (i == 80)
                    {
                        Instance.IsDisplayLeftTimeout.Value = false;
                        await Task.Delay(500);
                        Instance.IsDisplayTimeoutRemaining.Value = true;
                    }
                    await Task.Delay(100);
                }
                Instance.IsDisplayLeftTimeout.Value = false;
                Instance.IsDisplayTimeoutRemaining.Value = false;


                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
        }
        public async void RightTimeOut()
        {
            if (Instance.IsDisplayRightTimeout.Value  || Instance.IsDisplayTimeoutRemaining.Value)
            {
                //すでに表示されている
                await DeleteOption();
            }
            else
            {
                Instance.TimeOutRight.Value++;
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }

                await DeleteOption();


                Instance.History.Add("TR");
                Instance.IsDisplayRightTimeout.Value = true;
                _stopRightTimeOut = false;

                for (int i = 0; i < 160; i++)
                {
                    if (_stopRightTimeOut)
                    {
                        _stopRightTimeOut = false;
                        break;
                    }
                    if (i == 80)
                    {
                        Instance.IsDisplayRightTimeout.Value = false;
                        await Task.Delay(500);
                        Instance.IsDisplayTimeoutRemaining.Value = true;
                    }
                    await Task.Delay(100);
                }
                Instance.IsDisplayRightTimeout.Value = false;
                Instance.IsDisplayTimeoutRemaining.Value = false;


                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
        }
        public async void TechnicalTimeOut()
        {
            if (Instance.IsDisplayTechnicalTimeout.Value)
            {
                await DeleteOption();
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
        public async void InfomationAttackPoint()
        {
            if (Instance.IsDisplayAttackPointInfomation.Value)
            {
                Instance.IsDisplayAttackPointInfomation.Value = false;
                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
            else
            {
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }

                await DeleteOption();
                Instance.IsDisplayAttackPointInfomation.Value = true;
            }
        }
        public async void InfomationBlockPoint()
        {
            if (Instance.IsDisplayBlockPointInfomation.Value)
            {
                Instance.IsDisplayBlockPointInfomation.Value = false;
                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
            else
            {
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }
                await DeleteOption();
                Instance.IsDisplayBlockPointInfomation.Value = true;
            }
        }
        public async void InfomationServePoint()
        {
            if (Instance.IsDisplayServePointInfomation.Value)
            {
                Instance.IsDisplayServePointInfomation.Value = false;
                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
            else
            {
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }
                await DeleteOption();
                Instance.IsDisplayServePointInfomation.Value = true;
            }
        }
        public async void InfomationServeError()
        {
            if (Instance.IsDisplayServeErrorInfomation.Value)
            {
                Instance.IsDisplayServeErrorInfomation.Value = false;
                await Task.Delay(1000);
                await Instance.Control.DetectSetPoint();
            }
            else
            {
                if (Instance.IsDisplayScoreboard.Value == false)
                {
                    Instance.IsDisplayScoreboard.Value = true;
                    await Task.Delay(1000);
                }
                await DeleteOption();
                Instance.IsDisplayServeErrorInfomation.Value = true;
            }
        }
    }
}
