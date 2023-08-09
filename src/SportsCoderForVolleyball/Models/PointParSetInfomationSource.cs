namespace SportsCoderForVolleyball.Models
{
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
}
