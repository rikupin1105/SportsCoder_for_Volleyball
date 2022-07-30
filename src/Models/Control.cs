using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsCoderForVolleyball.Models
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

                Instance.History.Value.Add("TL");

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

                Instance.History.Value.Add("TR");
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
        public async void InfomationScore()
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
        public void InfomationStatistics()
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
        public void InfomationSet()
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
            Instance.GuiEnable.Value = look;
        }

        private async void PointPlusLeft(bool IsDetectSetPoint = true)
        {
            Instance.GameLeftTeamPoint.Value++;
            Instance.PointLeft.Value++;
            if (IsDetectSetPoint)
                await DetectSetPoint();
        }
        private async void PointPlusRight(bool IsDetectSetPoint = true)
        {
            Instance.GameRightTeamPoint.Value++;
            Instance.PointRight.Value++;
            if (IsDetectSetPoint)
                await DetectSetPoint();
        }

        public async void ServePoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft(false);
                LeftTeamServePoint.Value++;
                GameLeftTeamServePoint.Value++;

                History.Value.Add("PL.S");
            }
            else
            {
                PointPlusRight(false);
                RightTeamServePoint.Value++;
                GameRightTeamServePoint.Value++;

                History.Value.Add("PR.S");
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
                GameLeftTeamBlockPoint.Value++;

                History.Value.Add("PL.B");
            }
            else
            {
                PointPlusRight();
                RightTeamBlockPoint.Value++;
                GameRightTeamBlockPoint.Value++;

                History.Value.Add("PR.B");
            }
        }
        public void AttackPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                LeftTeamAttackPoint.Value++;
                GameLeftTeamAttackPoint.Value++;

                History.Value.Add("PL.A");
            }
            else
            {
                PointPlusRight();
                RightTeamAttackPoint.Value++;
                GameRightTeamAttackPoint.Value++;

                History.Value.Add("PR.A");
            }
        }
        public void ServeError(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamServeError.Value++;
                GameLeftTeamServeError.Value++;

                History.Value.Add("PR.SE");
            }
            else
            {
                PointPlusLeft();
                RightTeamServeError.Value++;
                GameRightTeamServeError.Value++;

                History.Value.Add("PL.SE");
            }
        }
        public void Error(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamError.Value++;
                GameLeftTeamError.Value++;

                History.Value.Add("PR.SE");
            }
            else
            {
                PointPlusLeft();
                RightTeamError.Value++;
                GameRightTeamError.Value++;

                History.Value.Add("PL.E");
            }
        }

        public async void CourtChange(bool detectSetpoint = true, bool History = true)
        {
            Swap(ref Instance.PointLeft, ref Instance.PointRight);
            Swap(ref Instance.SetLeft, ref Instance.SetRight);
            Swap(ref Instance.TeamLeft, ref Instance.TeamRight);

            Swap(ref Instance.LeftTeamAttackPoint, ref Instance.RightTeamAttackPoint);
            Swap(ref Instance.LeftTeamBlockPoint, ref Instance.RightTeamBlockPoint);
            Swap(ref Instance.LeftTeamServePoint, ref Instance.RightTeamServePoint);
            Swap(ref Instance.LeftTeamServeError, ref Instance.RightTeamServeError);
            Swap(ref Instance.LeftTeamError, ref Instance.RightTeamError);

            Swap(ref Instance.GameLeftTeamPoint, ref Instance.GameRightTeamPoint);
            Swap(ref Instance.GameLeftTeamServePoint, ref Instance.GameRightTeamServePoint);
            Swap(ref Instance.GameLeftTeamAttackPoint, ref Instance.GameRightTeamAttackPoint);
            Swap(ref Instance.GameLeftTeamBlockPoint, ref Instance.GameRightTeamBlockPoint);
            Swap(ref Instance.GameLeftTeamServeError, ref Instance.GameRightTeamServeError);
            Swap(ref Instance.GameLeftTeamError, ref Instance.GameRightTeamError);

            Swap(ref Instance.GameLeftTeamOpponentError, ref Instance.GameRightTeamOpponentError);

            Instance.IsATeamLeft.Value = !Instance.IsATeamLeft.Value;

            if (History)
                Instance.History.Value.Add("C");

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

            LeftTeamOpponentError.Value = Instance.RightTeamError.Value + Instance.RightTeamServeError.Value;
            RightTeamOpponentError.Value = Instance.LeftTeamError.Value + Instance.LeftTeamServeError.Value;

            //記録の書き込み
            if (Instance.IsATeamLeft.Value)
            {
                Instance.Sets.Value.Add(new Set()
                {
                    ATeamPoint = Instance.PointLeft.Value,
                    BTeamPoint = Instance.PointRight.Value,

                    ATeamTimeOut = Instance.TimeOutLeft.Value,
                    BTeamTimeOut = Instance.TimeOutRight.Value,

                    ATeamAttackPoint = Instance.LeftTeamAttackPoint.Value,
                    BTeamAttackPoint = Instance.RightTeamAttackPoint.Value,

                    ATeamBlockPoint = Instance.LeftTeamBlockPoint.Value,
                    BTeamBlockPoint = Instance.RightTeamBlockPoint.Value,

                    ATeamServePoint = Instance.LeftTeamServePoint.Value,
                    BTeamServePoint = Instance.RightTeamServePoint.Value,

                    ATeamServeError = Instance.LeftTeamServeError.Value,
                    BTeamServeError = Instance.RightTeamServeError.Value,

                    ATeamError = Instance.LeftTeamError.Value + Instance.LeftTeamServeError.Value,
                    BTeamError = Instance.RightTeamError.Value + Instance.RightTeamServeError.Value,
                }); ;
            }
            else
            {
                Instance.Sets.Value.Add(new Set()
                {
                    ATeamPoint = Instance.PointRight.Value,
                    BTeamPoint = Instance.PointLeft.Value,

                    ATeamTimeOut = Instance.TimeOutRight.Value,
                    BTeamTimeOut = Instance.TimeOutLeft.Value,

                    ATeamAttackPoint = Instance.RightTeamAttackPoint.Value,
                    BTeamAttackPoint = Instance.LeftTeamAttackPoint.Value,

                    ATeamBlockPoint = Instance.RightTeamBlockPoint.Value,
                    BTeamBlockPoint = Instance.LeftTeamBlockPoint.Value,

                    ATeamServePoint = Instance.RightTeamServePoint.Value,
                    BTeamServePoint = Instance.LeftTeamServePoint.Value,

                    ATeamServeError = Instance.RightTeamServeError.Value,
                    BTeamServeError = Instance.LeftTeamServeError.Value,

                    ATeamError = Instance.RightTeamError.Value + Instance.RightTeamServeError.Value,
                    BTeamError = Instance.LeftTeamError.Value + Instance.LeftTeamServeError.Value,
                });
            }



            //情報表示

            //セット数
            await Task.Delay(5000);
            Instance.InfomationSet();

            //セットごとのポイント
            await Task.Delay(4000);
            Instance.InfomationPointParSet();
            Instance.IsAnimation.Value = false;

            //セットごとのポイントを削除
            await Task.Delay(10000);
            await DeleteOption();


            //スコアとセットを非表示
            Instance.IsDisplayGetSet.Value = false;

            //統計表示
            await Task.Delay(2000);
            IsDisplaySetStuts.Value = true;


            //統計非表示
            await Task.Delay(15000);
            IsDisplaySetStuts.Value = false;


            //最終セットの場合
            if (Instance.SetRight.Value == Instance.NEEDSET.Value || Instance.SetLeft.Value == Instance.NEEDSET.Value)
            {
                //ゲーム終了ならスコアボードを再表示させない
                await Task.Delay(2000);

                IsDisplayGameStuts.Value = true;

                await Task.Delay(15000);

                IsDisplayGameStuts.Value = false;
                
                return;
            }


            await Task.Delay(5000);

            //次のセットへ
            Instance.PointLeft.Value = 0;
            Instance.PointRight.Value = 0;
            Instance.TimeOutLeft.Value = 0;
            Instance.TimeOutRight.Value = 0;
            Instance.LeftTeamAttackPoint.Value = 0;
            Instance.RightTeamAttackPoint.Value = 0;
            Instance.LeftTeamBlockPoint.Value = 0;
            Instance.RightTeamBlockPoint.Value= 0;
            Instance.LeftTeamServePoint.Value=0;
            Instance.RightTeamServePoint.Value = 0;
            Instance.LeftTeamServeError.Value = 0;
            Instance.RightTeamServeError.Value = 0;
            Instance.LeftTeamError.Value = 0;
            Instance.RightTeamError.Value = 0;
            Instance.Set.Value++;

            if (Instance.COURTCHANGE.Value && Instance.Set.Value != Instance.SET.Value)
            {
                CourtChange(false, false);
            }
            InfomationScore();

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
                            Undo();
                            LockControl(true);
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
                            Undo();
                            LockControl(true);
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
                                Undo();
                                LockControl(true);
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
                                if (Instance.COURTCHANGE.Value)
                                    Instance.History.Value.Add($"ESL{Instance.Set.Value}C");
                                else
                                    Instance.History.Value.Add($"ESL{Instance.Set.Value}");
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetLeft.Value--;
                                Undo();
                                LockControl(true);
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
                                Undo();
                                LockControl(true);
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
                                if (Instance.COURTCHANGE.Value)
                                    Instance.History.Value.Add($"ESR{Instance.Set.Value}C");
                                else
                                    Instance.History.Value.Add($"ESR{Instance.Set.Value}");


                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetRight.Value--;
                                Undo();
                                LockControl(true);
                            }
                        }, "DialogWindow");
                        return StateSet.EndSet;
                    }
                }


                var ans = StateSet.None;
                //セットポイントの検出
                //左チーム
                if (Instance.SetLeft.Value+1 != Instance.NEEDSET.Value && Instance.PointLeft.Value+1 >= Instance.POINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.IsDisplayLeftSetPoint.Value = true;
                    ans = StateSet.SetPoint;
                }
                else
                {
                    Instance.IsDisplayLeftSetPoint.Value = false;
                }

                //右チーム
                if (Instance.SetRight.Value+1 != Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.IsDisplayRightSetPoint.Value = true;
                    ans = StateSet.SetPoint;
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
                    ans = StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayLeftMatchPoint.Value = false;
                }
                //右チーム
                if (Instance.SetRight.Value+1 == Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.IsDisplayRightMatchPoint.Value = true;
                    ans = StateSet.MatchPoint;
                }
                else
                {
                    Instance.IsDisplayRightMatchPoint.Value = false;
                }

                return ans;
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
        public async void Undo()
        {
            if (History.Value.Count == 0) return;

            var c = History.Value[History.Value.Count-1];

            if (c[0] == 'P')
            {
                var skill = c.Split('.')[1];
                if (c[1]=='R')
                {
                    GameRightTeamPoint.Value--;
                    PointRight.Value--;
                    switch (skill)
                    {
                        case "A":
                            RightTeamAttackPoint.Value--;
                            GameRightTeamAttackPoint.Value--;
                            break;
                        case "B":
                            RightTeamBlockPoint.Value--;
                            GameRightTeamBlockPoint.Value--;
                            break;
                        case "S":
                            RightTeamServePoint.Value--;
                            GameRightTeamServeError.Value--;
                            break;
                        case "E":
                            LeftTeamError.Value--;
                            GameLeftTeamError.Value--;
                            break;
                        case "SE":
                            LeftTeamServeError.Value--;
                            GameLeftTeamServeError.Value--;
                            break;
                    }
                }
                else if (c[1] == 'L')
                {

                    GameLeftTeamPoint.Value--;
                    PointLeft.Value--;
                    switch (skill)
                    {
                        case "A":
                            LeftTeamAttackPoint.Value--;
                            GameLeftTeamAttackPoint.Value--;
                            break;
                        case "B":
                            LeftTeamBlockPoint.Value--;
                            GameLeftTeamBlockPoint.Value--;
                            break;
                        case "S":
                            LeftTeamServePoint.Value--;
                            GameLeftTeamServeError.Value--;
                            break;
                        case "E":
                            RightTeamError.Value--;
                            GameRightTeamError.Value--;
                            break;
                        case "SE":
                            RightTeamServeError.Value--;
                            GameRightTeamServeError.Value--;
                            break;
                    }
                }
                await DetectSetPoint();
            }
            else if (c[0] == 'T')
            {
                if (c[1]=='R')
                {
                    TimeOutRight.Value--;
                }
                else if (c[1] == 'L')
                {
                    TimeOutLeft.Value--;
                }
            }
            else if (c[0]=='E')
            {
                if (c[1]=='S')
                {
                    var set = int.Parse(c[3].ToString());
                    //セット終了
                    var a = Instance.Sets.Value[set-1];

                    Instance.Set.Value--;

                    if (Instance.IsATeamLeft.Value)
                    {
                        PointLeft.Value = a.ATeamPoint;
                        LeftTeamAttackPoint.Value = a.ATeamAttackPoint;
                        LeftTeamBlockPoint.Value = a.ATeamBlockPoint;
                        LeftTeamServePoint.Value = a.ATeamServePoint;
                        LeftTeamServeError.Value = a.ATeamServeError;
                        LeftTeamError.Value = a.ATeamError;
                        LeftTeamOpponentError.Value = a.ATeamServeError + a.ATeamError;

                        PointRight.Value = a.BTeamPoint;
                        RightTeamAttackPoint.Value = a.BTeamAttackPoint;
                        RightTeamBlockPoint.Value = a.BTeamBlockPoint;
                        RightTeamServePoint.Value = a.BTeamServePoint;
                        RightTeamServeError.Value = a.BTeamServeError;
                        RightTeamError.Value = a.BTeamError;
                        RightTeamOpponentError.Value = a.BTeamServeError + a.BTeamError;
                    }
                    else
                    {
                        PointLeft.Value = a.BTeamPoint;
                        LeftTeamAttackPoint.Value = a.BTeamAttackPoint;
                        LeftTeamBlockPoint.Value = a.BTeamBlockPoint;
                        LeftTeamServePoint.Value = a.BTeamServePoint;
                        LeftTeamServeError.Value = a.BTeamServeError;
                        LeftTeamError.Value = a.BTeamError;
                        LeftTeamOpponentError.Value = a.BTeamServeError + a.BTeamError;

                        PointRight.Value = a.ATeamPoint;
                        RightTeamAttackPoint.Value = a.ATeamAttackPoint;
                        RightTeamBlockPoint.Value = a.ATeamBlockPoint;
                        RightTeamServePoint.Value = a.ATeamServePoint;
                        RightTeamServeError.Value = a.ATeamServeError;
                        RightTeamError.Value = a.ATeamError;
                        RightTeamOpponentError.Value = a.ATeamServeError + a.ATeamError;
                    }

                    Instance.Sets.Value.RemoveAt(set-1);

                    if (c.Contains('C'))
                    {
                        CourtChange(false, false);
                        if (c[2]=='R')
                        {
                            SetRight.Value--;
                        }
                        else if (c[2] == 'L')
                        {
                            SetLeft.Value--;
                        }
                    }
                    History.Value.RemoveAt(History.Value.Count-1);
                    Undo();
                    return;
                }
            }
            else if (c[0] == 'C')
            {
                //コートチェンジ
                CourtChange(History: false);
            }

            History.Value.RemoveAt(History.Value.Count-1);
        }

        public static Control Instance { get; } = new();
        public ReactiveProperty<List<string>> History { get; set; } = new(new List<string>());

        public ReactiveProperty<List<Set>> Sets = new(new List<Set>());
        public ReactiveProperty<List<PointParSetInfomationSource>> PointParSetSource { get; set; } = new();

        //アニメーション
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
        public ReactiveProperty<bool> IsDisplaySetStuts = new(false);
        public ReactiveProperty<bool> IsDisplayGameStuts = new(false);

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
        public ReactiveProperty<bool> IsATeamLeft = new(true);
        public ReactiveProperty<string> ColorCodeLeftTeam = new("#ffffff");
        public ReactiveProperty<string> ColorCodeRightTeam = new("#000000");

        public ReactiveProperty<bool> GuiEnable = new(true);

        //ルール
        public ReactiveProperty<int> TIMEOUT = new(2);
        public ReactiveProperty<int> SET = new(5);
        public ReactiveProperty<int> NEEDSET = new(3);
        public ReactiveProperty<int> POINT = new(25);
        public ReactiveProperty<int> LASTSETPOINT = new(15);
        public ReactiveProperty<bool> COURTCHANGE = new(true);


        private static void Swap<T>(ref ReactiveProperty<T> a, ref ReactiveProperty<T> b)
        {
            (a.Value, b.Value) = (b.Value, a.Value);
        }
    }
}
