using SportsCoderForVolleyball.Shared;
using static SportsCoderForVolleyball.Models.Data;

namespace SportsCoderForVolleyball.Models
{
    public class Point
    {
        private async void PointPlusLeft(bool IsDetectSetPoint = true)
        {
            Instance.GameLeftTeamPoint.Value++;
            UI.Instance.PointLeft.Value++;

            //サーバー表示
            UI.Instance.IsLeftServe.Value = true;
            UI.Instance.IsRightServe.Value = false;

            if (IsDetectSetPoint)
                await Instance.Control.DetectSetPoint();
        }
        private async void PointPlusRight(bool IsDetectSetPoint = true)
        {
            Instance.GameRightTeamPoint.Value++;
            UI.Instance.PointRight.Value++;

            //サーバー表示
            UI.Instance.IsLeftServe.Value = false;
            UI.Instance.IsRightServe.Value = true;

            if (IsDetectSetPoint)
                await Instance.Control.DetectSetPoint();
        }

        public void ServePoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft(false);
                Instance.LeftTeamServePoint.Value++;
                Instance.GameLeftTeamServePoint.Value++;

                Instance.History.Add("PL.S");
            }
            else
            {
                PointPlusRight(false);
                Instance.RightTeamServePoint.Value++;
                Instance.GameRightTeamServePoint.Value++;

                Instance.History.Add("PR.S");
            }
        }
        public void BlockPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                Instance.LeftTeamBlockPoint.Value++;
                Instance.GameLeftTeamBlockPoint.Value++;

                Instance.History.Add("PL.B");
            }
            else
            {
                PointPlusRight();
                Instance.RightTeamBlockPoint.Value++;
                Instance.GameRightTeamBlockPoint.Value++;

                Instance.History.Add("PR.B");
            }
        }
        public void AttackPoint(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusLeft();
                Instance.LeftTeamAttackPoint.Value++;
                Instance.GameLeftTeamAttackPoint.Value++;

                Instance.History.Add("PL.A");
            }
            else
            {
                PointPlusRight();
                Instance.RightTeamAttackPoint.Value++;
                Instance.GameRightTeamAttackPoint.Value++;

                Instance.History.Add("PR.A");
            }
        }
        public void ServeError(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                Instance.LeftTeamServeError.Value++;
                Instance.GameLeftTeamServeError.Value++;
                Instance.GameRightTeamOpponentError.Value++;

                Instance.History.Add("PR.SE");
            }
            else
            {
                PointPlusLeft();
                Instance.RightTeamServeError.Value++;
                Instance.GameRightTeamServeError.Value++;
                Instance.GameLeftTeamOpponentError.Value++;

                Instance.History.Add("PL.SE");
            }
        }
        public void Error(bool IsLeftTeam)
        {
            if (IsLeftTeam)
            {
                PointPlusRight();
                Instance.LeftTeamError.Value++;
                Instance.GameLeftTeamError.Value++;
                Instance.GameRightTeamOpponentError.Value++;

                Instance.History.Add("PR.E");
            }
            else
            {
                PointPlusLeft();
                Instance.RightTeamError.Value++;
                Instance.GameRightTeamError.Value++;
                Instance.GameLeftTeamOpponentError.Value++;

                Instance.History.Add("PL.E");
            }
        }
    }
}
