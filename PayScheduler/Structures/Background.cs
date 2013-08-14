using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PayScheduler.Views;
using System.Drawing;


namespace PayScheduler.Structures
{
    class Background:IFrame
    {
        public IFrame copy()
        {
            throw new NotImplementedException();
        }

        public string id()
        {
            return "background";
        }

        public Bitmap Drow(IFrame frame)
        {
            Bitmap ans = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(ans);
            g.FillRectangle(Brushes.DarkGreen, 0, 0, 100, 100);
            return ans;
        }

    }
}
