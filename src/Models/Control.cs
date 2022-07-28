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
        public void Statistics()
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
                GameLeftTeamServePoint.Value++;
            }
            else
            {
                PointPlusRight(false);
                RightTeamServePoint.Value++;
                GameRightTeamServePoint.Value++;
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
            }
            else
            {
                PointPlusRight();
                RightTeamBlockPoint.Value++;
                GameRightTeamBlockPoint.Value++;
            }
        }
        public void AttackPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                LeftTeamAttackPoint.Value++;
                GameLeftTeamAttackPoint.Value++;
            }
            else
            {
                PointPlusRight();
                RightTeamAttackPoint.Value++;
                GameRightTeamAttackPoint.Value++;
            }
        }
        public void ServeError(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamServeError.Value++;
                GameLeftTeamServeError.Value++;
            }
            else
            {
                PointPlusLeft();
                RightTeamServeError.Value++;
                GameRightTeamServeError.Value++;
            }
        }
        public void Error(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                LeftTeamError.Value++;
                GameLeftTeamError.Value++;
            }
            else
            {
                PointPlusLeft();
                RightTeamError.Value++;
                GameRightTeamError.Value++;
            }
        }

        private static void Swap<T>(ref ReactiveProperty<T> a, ref ReactiveProperty<T> b)
        {
            (a.Value, b.Value) = (b.Value, a.Value);
        }
        public async void CourtChange(bool detectSetpoint = true)
        {
            Swap(ref Instance.PointLeft, ref Instance.PointRight);
            Swap(ref Instance.SetLeft, ref Instance.SetRight);
            Swap(ref Instance.TeamLeft, ref Instance.TeamRight);


            Swap(ref Instance.LeftTeamAttackPoint, ref Instance.RightTeamAttackPoint);
            Swap(ref Instance.LeftTeamBlockPoint, ref Instance.RightTeamBlockPoint);
            Swap(ref Instance.LeftTeamServePoint, ref Instance.RightTeamServePoint);
            Swap(ref Instance.LeftTeamServeError, ref Instance.RightTeamServeError);
            Swap(ref Instance.LeftTeamError, ref Instance.RightTeamError);

            Swap(ref Instance.GameLeftTeamServePoint, ref Instance.GameRightTeamServePoint);
            Swap(ref Instance.GameLeftTeamAttackPoint, ref Instance.GameRightTeamAttackPoint);
            Swap(ref Instance.GameLeftTeamBlockPoint, ref Instance.GameRightTeamBlockPoint);
            Swap(ref Instance.GameLeftTeamServeError, ref Instance.GameRightTeamServeError);
            Swap(ref Instance.GameLeftTeamError, ref Instance.GameRightTeamError);

            Swap(ref Instance.GameLeftTeamOpponentError, ref Instance.GameRightTeamOpponentError);


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

            LeftTeamOpponentError.Value = Instance.LeftTeamError.Value + Instance.LeftTeamServeError.Value;
            RightTeamOpponentError.Value = Instance.RightTeamError.Value + Instance.RightTeamServeError.Value;

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
            Instance.SetInfomation();

            //セットごとのポイント
            await Task.Delay(4000);
            Instance.PointParSetInfomation();
            Instance.IsAnimation.Value = false;

            //セットごとのポイントを削除
            await Task.Delay(10000);
            await DeleteOption();

            //最終セットの場合
            if (Instance.SetRight.Value == Instance.NEEDSET.Value || Instance.SetLeft.Value == Instance.NEEDSET.Value)
            {
                //ゲーム終了ならスコアボードを再表示させない
                Instance.SetInfomation();
                ScoreInfomation();

                return;
            }

            //スコアとセットを非表示
            Instance.IsDisplayGetSet.Value = false;

            //統計表示
            await Task.Delay(2000);
            Statistics();


            //統計非表示
            await Task.Delay(15000);
            Statistics();


            //スコアを表示
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
        public ReactiveProperty<bool> IsDisplaySetStuts = new(false);

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

        public ReactiveProperty<bool> EnableLeftMinus = new(false);
        public ReactiveProperty<bool> EnableRightMinus = new(false);
        public ReactiveProperty<bool> EnableLeftPlus = new(true);
        public ReactiveProperty<bool> EnableRightPlus = new(true);


        public ReactiveProperty<int> TIMEOUT = new(2);
        public ReactiveProperty<int> SET = new(5);
        public ReactiveProperty<int> NEEDSET = new(3);
        public ReactiveProperty<int> POINT = new(25);
        public ReactiveProperty<int> LASTSETPOINT = new(15);
        public ReactiveProperty<bool> COURTCHANGE = new(true);
    }
}
