namespace Ui
{
    public class Point
    {
        private int m_X;
        private int m_Y;

        public Point(int i_x, int i_y)
        {
            m_X = i_x;
            m_Y = i_y;
        }
        public int x
        {
            get { return m_X; }

            set { m_X = value; }
        }
        public int y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }
    }
}

