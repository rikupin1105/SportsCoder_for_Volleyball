using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsCoderForVolleyball
{
    public class Control
    {
        private IDialogService _dialogService;
        private bool _stopTechnicalTimeout = false;
        private bool _stopLeftTimeOut = false;
        private bool _stopRightTimeOut = false;
        public void SetService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        private async Task DeleteOption(bool wait = true)
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

            if (flag && wait) await Task.Delay(1000);
        }
        private bool IsDispleyOption()
        {
            if (IsDisplayTechnicalTimeout.Value) return true;
            if (IsDisplayLeftTimeout.Value) return true;
            if (IsDisplayRightTimeout.Value) return true;
            if (IsDisplayRightSetPoint.Value) return true;
            if (IsDisplayRightMatchPoint.Value) return true;
            if (IsDisplayLeftSetPoint.Value) return true;
            if (IsDisplayLeftMatchPoint.Value) return true;
            if (IsDisplayTimeoutRemaining.Value) return true;
            if (Instance.IsDisplayRightSetPoint.Value) return true;
            if (Instance.IsDisplayRightMatchPoint.Value) return true;
            if (Instance.IsDisplayLeftSetPoint.Value) return true;
            if (Instance.IsDisplayLeftMatchPoint.Value) return true;
            if (Instance.IsDisplayPointParSet.Value) return true;

            if (IsDisplayGetSet.Value) return true;
            return false;
        }
        public async void LeftTimeout()
        {
            if (Instance.IsDisplayLeftTimeout.Value  || Instance.IsDisplayTimeoutRemaining.Value)
            {
                //すでに表示されている
                await Instance.DeleteOption();
            }
            else
            {
                if (Instance.IsAnimation.Value == false)
                {
                    Instance.IsAnimation.Value = true;
                    await Task.Delay(1000);
                }

                await Instance.DeleteOption();

                Instance.TimeOutLeft.Value++;
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
                //await DetectSetPoint();
            }
        }
        public async void RightTimeOut()
        {
            if (Instance.IsDisplayRightTimeout.Value  || Instance.IsDisplayTimeoutRemaining.Value)
            {
                //すでに表示されている
                await Instance.DeleteOption();
            }
            else
            {
                if (Instance.IsAnimation.Value == false)
                {
                    Instance.IsAnimation.Value = true;
                    await Task.Delay(1000);
                }

                await Instance.DeleteOption();

                Instance.TimeOutRight.Value++;
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
                //await DetectSetPoint();
            }
        }
        public async void TechnicalTimeOut()
        {
            if (Instance.IsDisplayTechnicalTimeout.Value)
            {
                await Instance.DeleteOption();
            }
            else
            {
                if (Instance.IsAnimation.Value == false)
                {
                    Instance.IsAnimation.Value = true;
                    await Task.Delay(1000);
                }

                await Instance.DeleteOption();
                Instance.IsDisplayTechnicalTimeout.Value = true;
                _stopTechnicalTimeout = false;
                for (int i = 0; i < 300; i++)
                {
                    if (_stopTechnicalTimeout)
                    {
                        Instance.IsDisplayTechnicalTimeout.Value = false;
                        _stopTechnicalTimeout = false;
                        await Task.Delay(1000);
                        //await DetectSetPoint();
                        return;
                    }
                    await Task.Delay(100);
                }
                Instance.IsDisplayTechnicalTimeout.Value = false;
            }
        }
        public async void ScoreInfomation()
        {
            if (Instance.IsAnimation.Value)
            {
                //表示されているとき
                if (Instance.IsDisplayGetSet.Value)
                {
                    Instance.IsDisplayGetSet.Value = false;
                }
                else
                {
                    await DeleteOption();
                    Instance.IsAnimation.Value = false;
                }
            }
            else
            {
                //未表示のとき

                Instance.IsAnimation.Value = true;
                if (Instance.IsDisplayGetSet.Value)
                {
                    Instance.IsDisplayGetSet.Value = false;
                }
                //await DetectSetPoint();
            }
        }
        public void PointParSetInfomation()
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
                    if (IsATeamLeft.Value)
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
                PointParSetSource.Value = itemsorce;

                Instance.IsDisplayPointParSet.Value = true;
            }
        }
        public class PointParSetInfomationSource
        {
            public int Left { get; set; }
            public int Right { get; set; }
            public bool IsLeftWin
            {
                get
                {
                    if (Left>Right)
                        return true;
                    else
                        return false;
                }
            }
            public bool IsRightWin { get => !IsLeftWin; }
        }

        public void LockControl(bool look = true)
        {
            Instance.EnableLeftMinus.Value = look;
            Instance.EnableLeftPlus.Value = look;
            Instance.EnableRightMinus.Value = look;
            Instance.EnableRightPlus.Value = look;
        }
        public void SetInfomation()
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
        private async void PointPlusLeft(bool IsDetectSetPoint = true)
        {
            Instance.PointLeft.Value++;
            if (IsDetectSetPoint)
                await DetectSetPoint();
        }
        private async void PointPlusRight(bool IsDetectSetPoint = true)
        {
            Instance.PointRight.Value++;
            if (IsDetectSetPoint)
                await DetectSetPoint();
        }
        private async void PointMinusLeftAsync()
        {
            Instance.PointLeft.Value = Math.Min(Instance.PointLeft.Value--, 0);
            await DetectSetPoint();
        }
        private async void PointMinusRightAsync()
        {
            Instance.PointRight.Value = Math.Min(Instance.PointRight.Value--, 0);
            await DetectSetPoint();
        }


        public async void ServePoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft(false);
                LeftTeamServePoint.Value++;
            }
            else
            {
                PointPlusRight(false);
                RightTeamServePoint.Value++;
            }

            var s = DetectSetPoint().Result;

            if (s == StateSet.None)
            {
                //セットポイントやマッチポイント、セット終了時は表示しない
                await DeleteOption();
                Instance.IsDisplayServePointInfomation.Value = true;
                await Task.Delay(3000);
                Instance.IsDisplayServePointInfomation.Value = false;
                Instance.IsDisplayServeErrorInfomation.Value = true;
                await Task.Delay(3000);
                Instance.IsDisplayServeErrorInfomation.Value = false;
            }
        }
        public void BlockPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                LeftTeamBlockPoint.Value++;
            }
            else
            {
                PointPlusRight();
                RightTeamBlockPoint.Value++;
            }
        }
        public void AttackPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                LeftTeamAttackPoint.Value++;
            }
            else
            {
                PointPlusRight();
                RightTeamAttackPoint.Value++;
            }
        }
        public void ServeError(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamServeError.Value++;
            }
            else
            {
                PointPlusLeft();
                RightTeamServeError.Value++;
            }
        }
        public void Error(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamError.Value++;
            }
            else
            {
                PointPlusLeft();
                RightTeamError.Value++;
            }
        }

        public async void CourtChange(bool detectSetpoint = true)
        {
            (Instance.PointLeft.Value, Instance.PointRight.Value) = (Instance.PointRight.Value, Instance.PointLeft.Value);
            (Instance.SetLeft.Value, Instance.SetRight.Value) = (Instance.SetRight.Value, Instance.SetLeft.Value);
            (Instance.TeamLeft.Value, Instance.TeamRight.Value) = (Instance.TeamRight.Value, Instance.TeamLeft.Value);
            Instance.IsATeamLeft.Value = !Instance.IsATeamLeft.Value;

            if (detectSetpoint)
            {
                await DetectSetPoint();
            }
        }
        private async Task GameSetAsync()
        {
            //操作のロック
            LockControl(false);

            await DeleteOption();

            //記録の書き込み
            if (Instance.IsATeamLeft.Value)
            {
                Instance.Sets.Value.Add(new Set()
                {
                    ATeamPoint = Instance.PointLeft.Value,
                    BTeamPoint = Instance.PointRight.Value,

                    ATeamTimeOut = Instance.TimeOutLeft.Value,
                    BTeamTimeOut = Instance.TimeOutRight.Value
                });
            }
            else
            {
                Instance.Sets.Value.Add(new Set()
                {
                    ATeamPoint = Instance.PointRight.Value,
                    BTeamPoint = Instance.PointLeft.Value,

                    ATeamTimeOut = Instance.TimeOutRight.Value,
                    BTeamTimeOut = Instance.TimeOutLeft.Value
                });
            }



            //情報表示
            await Task.Delay(5000);
            Instance.SetInfomation();

            await Task.Delay(4000);
            Instance.PointParSetInfomation();
            await Task.Delay(10000);
            await DeleteOption();

            if (Instance.SetRight.Value == Instance.NEEDSET.Value || Instance.SetLeft.Value == Instance.NEEDSET.Value)
            {
                //ゲーム終了ならスコアボードを再表示させない
                Instance.SetInfomation();
                ScoreInfomation();

                return;
            }
            if (Instance.COURTCHANGE.Value)
            {
                CourtChange(false);
            }
            ScoreInfomation();

            //操作ロックの解除
            LockControl(true);
        }
        private async Task<StateSet> DetectSetPoint()
        {
            //ファイナルセットの場合
            if (Instance.Set.Value == Instance.SET.Value)
            {
                //ゲーム終了の検出
                //左チーム
                if (Instance.PointLeft.Value - Instance.PointRight.Value >= 2 && Instance.PointLeft.Value >= Instance.LASTSETPOINT.Value)
                {
                    LockControl(false);
                    await DeleteOption(false);
                    Instance.SetLeft.Value++;
                    var parmaters = new DialogParameters($"Team={Instance.TeamLeft.Value}");

                    _dialogService.Show("EndofSetDialog", parmaters, async result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            await GameSetAsync();
                        }
                        else
                        {
                            Instance.SetLeft.Value--;
                            Instance.PointLeft.Value--;
                            LockControl(true);
                            await DetectSetPoint();
                        }
                    }, "DialogWindow");
                    return StateSet.EndMatch;
                }

                //右チーム
                if (Instance.PointRight.Value - Instance.PointLeft.Value >= 2 && Instance.PointRight.Value >= Instance.LASTSETPOINT.Value)
                {
                    LockControl(false);
                    await DeleteOption(false);
                    Instance.SetRight.Value++;
                    var parmaters = new DialogParameters($"Team={Instance.TeamRight.Value}");

                    _dialogService.Show("EndofSetDialog", parmaters, async result =>
                    {
                        if (result.Result == ButtonResult.Yes)
                        {
                            await GameSetAsync();
                        }
                        else
                        {
                            Instance.SetRight.Value--;
                            Instance.PointRight.Value--;
                            LockControl(true);
                            await DetectSetPoint();
                        }
                    }, "DialogWindow");
                    return StateSet.EndMatch;
                }


                //マッチポイントの検出
                //左チーム
                if (Instance.PointLeft.Value + 1 >= Instance.LASTSETPOINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.IsDisplayLeftMatchPoint.Value = true;
                    return StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayLeftMatchPoint.Value = false;
                }

                //右チーム
                if (Instance.PointRight.Value + 1 >= Instance.LASTSETPOINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.IsDisplayRightMatchPoint.Value = true;
                    return StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayRightMatchPoint.Value = false;
                }
                return StateSet.None;
            }
            //ファイナルセット以外
            else
            {
                //セット終了の検出
                //左チーム
                if (Instance.PointLeft.Value >= Instance.POINT.Value && Instance.PointLeft.Value - Instance.PointRight.Value >= 2)
                {
                    LockControl(false);
                    await DeleteOption(false);
                    if (Instance.SetLeft.Value + 1 == Instance.NEEDSET.Value)
                    {
                        //試合に勝利
                        Instance.SetLeft.Value++;
                        var parmaters = new DialogParameters($"Team={Instance.TeamLeft.Value}");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetLeft.Value--;
                                Instance.PointLeft.Value--;
                                LockControl(true);
                                await DetectSetPoint();
                            }
                        }, "DialogWindow");
                        return StateSet.EndMatch;
                    }
                    else
                    {
                        //セット獲得
                        Instance.SetLeft.Value++;
                        var parmaters = new DialogParameters($"Team={Instance.TeamLeft.Value}");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();

                                Instance.PointLeft.Value = 0;
                                Instance.PointRight.Value = 0;

                                Instance.TimeOutLeft.Value = 0;
                                Instance.TimeOutRight.Value = 0;

                                Instance.Set.Value++;
                            }
                            else
                            {
                                Instance.SetLeft.Value--;
                                Instance.PointLeft.Value--;
                                LockControl(true);
                                await DetectSetPoint();
                            }
                        }, "DialogWindow");
                        return StateSet.EndSet;
                    }
                }

                //右チーム
                if (Instance.PointRight.Value >= Instance.POINT.Value && Instance.PointRight.Value - Instance.PointLeft.Value >= 2)
                {
                    LockControl(false);
                    await DeleteOption(false);
                    if (Instance.SetRight.Value + 1 == Instance.NEEDSET.Value)
                    {
                        //試合に勝利
                        Instance.SetRight.Value++;
                        var parmaters = new DialogParameters($"Team={Instance.TeamRight.Value}");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetRight.Value--;
                                Instance.PointRight.Value--;
                                LockControl(true);
                                await DetectSetPoint();
                            }
                        }, "DialogWindow");
                        return StateSet.EndSet;
                    }
                    else
                    {
                        //セット獲得
                        Instance.SetRight.Value++;
                        var parmaters = new DialogParameters($"Team={Instance.TeamRight.Value}");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();

                                Instance.PointLeft.Value = 0;
                                Instance.PointRight.Value = 0;

                                Instance.TimeOutLeft.Value = 0;
                                Instance.TimeOutRight.Value = 0;

                                Instance.Set.Value++;
                            }
                            else
                            {
                                Instance.SetRight.Value--;
                                Instance.PointRight.Value--;
                                LockControl(true);
                                await DetectSetPoint();
                            }
                        }, "DialogWindow");
                        return StateSet.EndSet;
                    }
                }


                //セットポイントの検出
                //左チーム
                if (Instance.SetLeft.Value+1 != Instance.NEEDSET.Value && Instance.PointLeft.Value+1 >= Instance.POINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.IsDisplayLeftSetPoint.Value = true;
                    return StateSet.SetPoint;
                }
                else
                {
                    Instance.IsDisplayLeftSetPoint.Value = false;
                }

                //右チーム
                if (Instance.SetRight.Value+1 != Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.IsDisplayRightSetPoint.Value = true;
                    return StateSet.SetPoint;
                }
                else
                {
                    Instance.IsDisplayRightSetPoint.Value = false;
                }


                //マッチポイントの検出
                //左チーム
                if (Instance.SetLeft.Value+1 == Instance.NEEDSET.Value && Instance.PointLeft.Value+1 >= Instance.POINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.IsDisplayLeftMatchPoint.Value = true;
                    return StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayLeftMatchPoint.Value = false;
                }

                //右チーム
                if (Instance.SetRight.Value+1 == Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.IsDisplayRightMatchPoint.Value = true;
                    return StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayRightMatchPoint.Value = false;
                }
                return StateSet.None;
            }
        }

        private enum StateSet
        {
            SetPoint,
            MatchPoint,
            EndSet,
            EndMatch,
            None
        }



        public static Control Instance { get; } = new();
        public ReactiveProperty<List<Set>> Sets = new(new List<Set>());
        public ReactiveProperty<List<PointParSetInfomationSource>> PointParSetSource { get; set; } = new();

        public ReactiveProperty<bool> IsAnimation = new(true);
        public ReactiveProperty<bool> IsDisplayTechnicalTimeout = new(false);
        public ReactiveProperty<bool> IsDisplayLeftTimeout = new(false);
        public ReactiveProperty<bool> IsDisplayRightTimeout = new(false);
        public ReactiveProperty<bool> IsDisplayRightSetPoint = new(false);
        public ReactiveProperty<bool> IsDisplayRightMatchPoint = new(false);
        public ReactiveProperty<bool> IsDisplayLeftSetPoint = new(false);
        public ReactiveProperty<bool> IsDisplayLeftMatchPoint = new(false);
        public ReactiveProperty<bool> IsDisplayTimeoutRemaining = new(false);
        public ReactiveProperty<bool> IsDisplayGetSet = new(false);
        public ReactiveProperty<bool> IsDisplayPointParSet = new(false);
        public ReactiveProperty<bool> IsDisplayServePointInfomation = new(false);
        public ReactiveProperty<bool> IsDisplayServeErrorInfomation = new(false);



        public ReactiveProperty<int> LeftTeamServePoint { get; set; } = new(0);
        public ReactiveProperty<int> RightTeamServePoint { get; set; } = new(0);

        public ReactiveProperty<int> LeftTeamAttackPoint { get; set; } = new(0);
        public ReactiveProperty<int> RightTeamAttackPoint { get; set; } = new(0);

        public ReactiveProperty<int> LeftTeamBlockPoint { get; set; } = new(0);
        public ReactiveProperty<int> RightTeamBlockPoint { get; set; } = new(0);

        public ReactiveProperty<int> LeftTeamServeError { get; set; } = new(0);
        public ReactiveProperty<int> RightTeamServeError { get; set; } = new(0);

        public ReactiveProperty<int> LeftTeamError { get; set; } = new(0);
        public ReactiveProperty<int> RightTeamError { get; set; } = new(0);



        public ReactiveProperty<int> Set { get; set; } = new(1);
        public ReactiveProperty<string> TeamLeft { get; set; } = new("USA");
        public ReactiveProperty<string> TeamRight { get; set; } = new("JPN");
        public ReactiveProperty<int> PointLeft { get; set; } = new(0);
        public ReactiveProperty<int> PointRight { get; set; } = new(0);
        public ReactiveProperty<int> SetLeft { get; set; } = new(0);
        public ReactiveProperty<int> SetRight { get; set; } = new(0);
        public ReactiveProperty<int> TimeOutRight { get; set; } = new(0);
        public ReactiveProperty<int> TimeOutLeft { get; set; } = new(0);
        public ReactiveProperty<bool> IsLeftServe { get; set; } = new(true);
        public ReactiveProperty<bool> IsATeamLeft { get; set; } = new(true);
        public ReactiveProperty<string> ColorCodeLeftTeam { get; set; } = new("#ffffff");
        public ReactiveProperty<string> ColorCodeRightTeam { get; set; } = new("#000000");

        public ReactiveProperty<bool> EnableLeftMinus { get; set; } = new(false);
        public ReactiveProperty<bool> EnableRightMinus { get; set; } = new(false);
        public ReactiveProperty<bool> EnableLeftPlus { get; set; } = new(true);
        public ReactiveProperty<bool> EnableRightPlus { get; set; } = new(true);


        public ReactiveProperty<int> TIMEOUT { get; set; } = new(2);
        public ReactiveProperty<int> SET { get; set; } = new(5);
        public ReactiveProperty<int> NEEDSET { get; set; } = new(3);
        public ReactiveProperty<int> POINT { get; set; } = new(25);
        public ReactiveProperty<int> LASTSETPOINT { get; set; } = new(15);
        public ReactiveProperty<bool> COURTCHANGE { get; set; } = new(true);
    }
}
