using Prism.Services.Dialogs;
using Reactive.Bindings;
using System.Threading.Tasks;
using static SportsCoderForVolleyball.Models.Data;

namespace SportsCoderForVolleyball.Models
{
    public class Control
    {
        private IDialogService _dialogService;
        public void SetService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        public static void LockControl(bool look = true)
        {
            Instance.GuiEnable.Value = look;
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

            Swap(ref Instance.ColorCodeLeftTeam, ref Instance.ColorCodeRightTeam);

            Swap(ref Instance.GameLeftTeamOpponentError, ref Instance.GameRightTeamOpponentError);
            SwitchServer();

            Instance.IsATeamLeft.Value = !Instance.IsATeamLeft.Value;

            if (History)
                Instance.History.Add("CC");

            if (detectSetpoint)
            {
                await DetectSetPoint();
            }
        }
        private async Task GameSetAsync()
        {
            //操作のロック
            LockControl(false);

            Instance.HideMessage();

            Instance.LeftTeamOpponentError.Value = Instance.RightTeamError.Value + Instance.RightTeamServeError.Value;
            Instance.RightTeamOpponentError.Value = Instance.LeftTeamError.Value + Instance.LeftTeamServeError.Value;

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
            Option.InfomationSet();

            //セットごとのポイント
            await Task.Delay(4000);
            Option.InfomationPointParSet();
            Instance.IsDisplayScoreboard.Value = false;

            //セットごとのポイントを削除
            await Task.Delay(10000);

            Instance.IsDisplayPointParSet.Value = false;
            await Task.Delay(1000);


            //スコアとセットを非表示
            Instance.IsDisplayGetSet.Value = false;

            ////統計表示
            //await Task.Delay(2000);
            //Instance.IsDisplaySetStuts.Value = true;


            ////統計非表示
            //await Task.Delay(15000);
            //Instance.IsDisplaySetStuts.Value = false;


            //最終セットの場合
            if (Instance.SetRight.Value == Instance.NEEDSET.Value || Instance.SetLeft.Value == Instance.NEEDSET.Value)
            {
                //ゲーム終了ならスコアボードを再表示させない
                //await Task.Delay(2000);

                //Instance.IsDisplayGameStuts.Value = true;

                //await Task.Delay(15000);

                //Instance.IsDisplayGameStuts.Value = false;

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
                //コートチェンジあり
                CourtChange(false, false);
                Instance.IsLeftServe.Value = true;
                Instance.IsRightServe.Value = false;
            }
            else
            {
                //コートチェンジなし
                if (Instance.Set.Value % 2 == 0)
                {
                    if (Instance.IsLeftFirstServe.Value)
                    {
                        Instance.IsLeftServe.Value = false;
                        Instance.IsRightServe.Value = true;
                    }
                    else
                    {
                        Instance.IsLeftServe.Value = true;
                        Instance.IsRightServe.Value = false;
                    }
                }
                else
                {
                    if (Instance.IsLeftFirstServe.Value)
                    {
                        Instance.IsLeftServe.Value = true;
                        Instance.IsRightServe.Value = false;
                    }
                    else
                    {
                        Instance.IsLeftServe.Value = false;
                        Instance.IsRightServe.Value = true;
                    }
                }
            }


            Option.InfomationScore();

            //操作ロックの解除
            LockControl(true);
        }
        public async Task DetectSetPoint()
        {
            //ファイナルセットの場合
            if (Instance.Set.Value == Instance.SET.Value)
            {
                //ゲーム終了の検出
                //左チーム
                if (Instance.PointLeft.Value - Instance.PointRight.Value >= 2 && Instance.PointLeft.Value >= Instance.LASTSETPOINT.Value)
                {
                    LockControl(false);
                    Instance.HideMessage();
                    Instance.SetLeft.Value++;
                    var parmaters = new DialogParameters($"message=ゲームを終了しますか？");

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
                    return;
                }

                //右チーム
                if (Instance.PointRight.Value - Instance.PointLeft.Value >= 2 && Instance.PointRight.Value >= Instance.LASTSETPOINT.Value)
                {
                    LockControl(false);
                    Instance.HideMessage();
                    Instance.SetRight.Value++;
                    var parmaters = new DialogParameters($"message=ゲームを終了しますか？");

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
                    return;
                }


                //マッチポイントの検出
                //左チーム
                if (Instance.PointLeft.Value + 1 >= Instance.LASTSETPOINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.ShowMessage("MATCH POINT", true, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }

                //右チーム
                if (Instance.PointRight.Value + 1 >= Instance.LASTSETPOINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.ShowMessage("MATCH POINT", false, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }
                return;
            }
            //ファイナルセット以外
            else
            {
                //セット終了の検出
                //左チーム
                if (Instance.PointLeft.Value >= Instance.POINT.Value && Instance.PointLeft.Value - Instance.PointRight.Value >= 2)
                {
                    LockControl(false);

                    Instance.HideMessage();

                    if (Instance.SetLeft.Value + 1 == Instance.NEEDSET.Value)
                    {
                        //試合に勝利
                        Instance.SetLeft.Value++;
                        var parmaters = new DialogParameters($"message=ゲームを終了しますか？");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetLeft.Value--;
                                Undo();
                                LockControl(true);
                            }
                        }, "DialogWindow");
                        return;
                    }
                    else
                    {
                        //セット獲得
                        Instance.SetLeft.Value++;


                        var parmaters = new DialogParameters($"message=セットを終了しますか？");
                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                if (Instance.COURTCHANGE.Value)
                                    Instance.History.Add($"ESL{Instance.Set.Value}C");
                                else
                                    Instance.History.Add($"ESL{Instance.Set.Value}");
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetLeft.Value--;
                                Undo();
                                LockControl(true);
                            }
                        }, "DialogWindow");
                        return;
                    }
                }

                //右チーム
                if (Instance.PointRight.Value >= Instance.POINT.Value && Instance.PointRight.Value - Instance.PointLeft.Value >= 2)
                {
                    LockControl(false);
                    Instance.HideMessage();
                    if (Instance.SetRight.Value + 1 == Instance.NEEDSET.Value)
                    {
                        //試合に勝利
                        Instance.SetRight.Value++;
                        var parmaters = new DialogParameters($"message=ゲームを終了しますか？");

                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetRight.Value--;
                                Undo();
                                LockControl(true);
                            }
                        }, "DialogWindow");
                        return;
                    }
                    else
                    {
                        //セット獲得
                        Instance.SetRight.Value++;

                        var parmaters = new DialogParameters($"message=セットを終了しますか？");
                        _dialogService.Show("EndofSetDialog", parmaters, async result =>
                        {
                            if (result.Result == ButtonResult.Yes)
                            {
                                if (Instance.COURTCHANGE.Value)
                                    Instance.History.Add($"ESR{Instance.Set.Value}C");
                                else
                                    Instance.History.Add($"ESR{Instance.Set.Value}");


                                await GameSetAsync();
                            }
                            else
                            {
                                Instance.SetRight.Value--;
                                Undo();
                                LockControl(true);
                            }
                        }, "DialogWindow");
                        return;
                    }
                }

                //セットポイントの検出
                //左チーム
                if (Instance.SetLeft.Value+1 != Instance.NEEDSET.Value && Instance.PointLeft.Value+1 >= Instance.POINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.ShowMessage("SET POINT", true, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }

                //右チーム
                if (Instance.SetRight.Value+1 != Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.ShowMessage("SET POINT", false, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }


                //マッチポイントの検出
                //左チーム
                if (Instance.SetLeft.Value+1 == Instance.NEEDSET.Value && Instance.PointLeft.Value+1 >= Instance.POINT.Value && Instance.PointLeft.Value > Instance.PointRight.Value)
                {
                    Instance.ShowMessage("MATCH POINT", true, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }
                //右チーム
                if (Instance.SetRight.Value+1 == Instance.NEEDSET.Value && Instance.PointRight.Value+1 >= Instance.POINT.Value && Instance.PointRight.Value > Instance.PointLeft.Value)
                {
                    Instance.ShowMessage("MATCH POINT", false, forceNoHide: true);
                    return;
                }
                else
                {
                    Instance.HideMessage();
                }

            }
        }
        public async void Undo()
        {
            if (Instance.History.Count == 0) return;

            var c = Instance.History[^1];

            //ポイント
            if (c[0] == 'P')
            {
                //1文字目がP - Point を表す
                //2文字目がL or R - Left or Right を表す

                var skill = c.Split('.')[1];
                if (c[1]=='R')
                {
                    Instance.GameRightTeamPoint.Value--;
                    Instance.PointRight.Value--;
                    switch (skill)
                    {
                        case "A":
                            Instance.RightTeamAttackPoint.Value--;
                            Instance.GameRightTeamAttackPoint.Value--;
                            break;
                        case "B":
                            Instance.RightTeamBlockPoint.Value--;
                            Instance.GameRightTeamBlockPoint.Value--;
                            break;
                        case "S":
                            Instance.RightTeamServePoint.Value--;
                            Instance.GameRightTeamServeError.Value--;
                            break;
                        case "E":
                            Instance.LeftTeamError.Value--;
                            Instance.GameLeftTeamError.Value--;
                            break;
                        case "SE":
                            Instance.LeftTeamServeError.Value--;
                            Instance.GameLeftTeamServeError.Value--;
                            break;
                    }
                }
                else if (c[1] == 'L')
                {

                    Instance.GameLeftTeamPoint.Value--;
                    Instance.PointLeft.Value--;
                    switch (skill)
                    {
                        case "A":
                            Instance.LeftTeamAttackPoint.Value--;
                            Instance.GameLeftTeamAttackPoint.Value--;
                            break;
                        case "B":
                            Instance.LeftTeamBlockPoint.Value--;
                            Instance.GameLeftTeamBlockPoint.Value--;
                            break;
                        case "S":
                            Instance.LeftTeamServePoint.Value--;
                            Instance.GameLeftTeamServeError.Value--;
                            break;
                        case "E":
                            Instance.RightTeamError.Value--;
                            Instance.GameRightTeamError.Value--;
                            break;
                        case "SE":
                            Instance.RightTeamServeError.Value--;
                            Instance.GameRightTeamServeError.Value--;
                            break;
                    }
                }
                await DetectSetPoint();
            }
            //タイムアウト
            else if (c[0] == 'T')
            {

                //1文字目がT - TimeOut を表す
                //2文字目がL or R - Left or Right を表す

                if (c[1]=='R')
                {
                    Instance.TimeOutRight.Value--;
                }
                else if (c[1] == 'L')
                {
                    Instance.TimeOutLeft.Value--;
                }
            }
            //終了
            else if (c[0] == 'E')
            {
                if (c[1]=='S')
                {
                    var set = int.Parse(c[3].ToString());
                    //セット終了
                    var a = Instance.Sets.Value[set-1];

                    Instance.Set.Value--;

                    if (Instance.IsATeamLeft.Value)
                    {
                        Instance.PointLeft.Value = a.ATeamPoint;
                        Instance.LeftTeamAttackPoint.Value = a.ATeamAttackPoint;
                        Instance.LeftTeamBlockPoint.Value = a.ATeamBlockPoint;
                        Instance.LeftTeamServePoint.Value = a.ATeamServePoint;
                        Instance.LeftTeamServeError.Value = a.ATeamServeError;
                        Instance.LeftTeamError.Value = a.ATeamError;
                        Instance.LeftTeamOpponentError.Value = a.ATeamServeError + a.ATeamError;

                        Instance.PointRight.Value = a.BTeamPoint;
                        Instance.RightTeamAttackPoint.Value = a.BTeamAttackPoint;
                        Instance.RightTeamBlockPoint.Value = a.BTeamBlockPoint;
                        Instance.RightTeamServePoint.Value = a.BTeamServePoint;
                        Instance.RightTeamServeError.Value = a.BTeamServeError;
                        Instance.RightTeamError.Value = a.BTeamError;
                        Instance.RightTeamOpponentError.Value = a.BTeamServeError + a.BTeamError;
                    }
                    else
                    {
                        Instance.PointLeft.Value = a.BTeamPoint;
                        Instance.LeftTeamAttackPoint.Value = a.BTeamAttackPoint;
                        Instance.LeftTeamBlockPoint.Value = a.BTeamBlockPoint;
                        Instance.LeftTeamServePoint.Value = a.BTeamServePoint;
                        Instance.LeftTeamServeError.Value = a.BTeamServeError;
                        Instance.LeftTeamError.Value = a.BTeamError;
                        Instance.LeftTeamOpponentError.Value = a.BTeamServeError + a.BTeamError;

                        Instance.PointRight.Value = a.ATeamPoint;
                        Instance.RightTeamAttackPoint.Value = a.ATeamAttackPoint;
                        Instance.RightTeamBlockPoint.Value = a.ATeamBlockPoint;
                        Instance.RightTeamServePoint.Value = a.ATeamServePoint;
                        Instance.RightTeamServeError.Value = a.ATeamServeError;
                        Instance.RightTeamError.Value = a.ATeamError;
                        Instance.RightTeamOpponentError.Value = a.ATeamServeError + a.ATeamError;
                    }

                    Instance.Sets.Value.RemoveAt(set-1);

                    if (c.Contains('C'))
                    {
                        CourtChange(false, false);
                        if (c[2]=='R')
                        {
                            Instance.SetRight.Value--;
                        }
                        else if (c[2] == 'L')
                        {
                            Instance.SetLeft.Value--;
                        }
                    }
                    Instance.History.RemoveAt(Instance.History.Count - 1);
                    Undo();
                    return;
                }
            }
            //チェンジ
            else if (c[0] == 'C')
            {
                if (c[1] == 'S')
                {
                    //サーバーチェンジ
                    SwitchServer(false);
                    Instance.History.RemoveAt(Instance.History.Count - 1);
                    return;
                }
                else if (c[1] == 'C')
                {
                    //コートチェンジ
                    CourtChange(History: false);
                    Instance.History.RemoveAt(Instance.History.Count - 1);
                    return;
                }
            }
            //スタート
            else if (c[0] == 'S')
            {
                return;
            }

            Instance.History.RemoveAt(Instance.History.Count - 1);

            //サーバー
            for (int i = Instance.History.Count - 1; i >= 0; i--)
            {
                if (Instance.History[i][0] == 'P')
                {
                    if (Instance.History[i][1] == 'R')
                    {
                        Instance.IsLeftServe.Value = false;
                        Instance.IsRightServe.Value = true;
                    }
                    else if (Instance.History[i][1] == 'L')
                    {
                        Instance.IsLeftServe.Value = true;
                        Instance.IsRightServe.Value = false;
                    }
                    return;
                }
                else if (Instance.History[i][0]=='E')
                {
                    var set = int.Parse(Instance.History[i][3].ToString()) + 1;
                    if (Instance.COURTCHANGE.Value)
                    {
                        Instance.IsLeftServe.Value = true;
                        Instance.IsRightServe.Value = false;
                    }
                    else if (set % 2 == 0)
                    {
                        if (Instance.IsLeftFirstServe.Value)
                        {
                            Instance.IsLeftServe.Value = false;
                            Instance.IsRightServe.Value = true;
                        }
                        else
                        {
                            Instance.IsLeftServe.Value = true;
                            Instance.IsRightServe.Value = false;
                        }
                        return;
                    }
                    else
                    {
                        if (Instance.IsLeftFirstServe.Value)
                        {
                            Instance.IsLeftServe.Value = true;
                            Instance.IsRightServe.Value = false;
                            return;
                        }
                        else
                        {
                            Instance.IsLeftServe.Value = false;
                            Instance.IsRightServe.Value = true;
                            return;
                        }
                    }
                }
                else if (Instance.History[i] == "S")
                {
                    if (Instance.IsLeftFirstServe.Value)
                    {
                        Instance.IsLeftServe.Value = true;
                        Instance.IsRightServe.Value = false;
                    }
                    else
                    {
                        Instance.IsLeftServe.Value = false;
                        Instance.IsRightServe.Value = true;
                    }
                }
            }
        }
        public static void SwitchServer(bool History = true)
        {
            Swap(ref Instance.IsLeftServe, ref Instance.IsRightServe);
            if (History)
                Instance.History.Add("CS");
        }
        private static void Swap<T>(ref ReactiveProperty<T> a, ref ReactiveProperty<T> b)
        {
            (a.Value, b.Value) = (b.Value, a.Value);
        }
    }
}
