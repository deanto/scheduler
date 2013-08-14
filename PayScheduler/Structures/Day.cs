using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using PayScheduler.Views;

namespace PayScheduler.Structures
{
    class Day:IFrame,IFrameDrow
    {
        /* класс содержащий информацию на день.
         */

        private string ID = "day";
        private int _day, _month, _year;

        public int day { get { return _day; } set { _day = value; } }
        public int month { get { return _month; } set { _month = value; } }
        public int year { get { return _year; } set { _year = value; } }

        public Day()
        {
            // default
            _day = 0;
            _month = 0;
            _year = 0;
        }

        public IFrame copy()
        {
            Day copy = new Day();
            copy.day = _day;
            copy.month = _month;
            copy.year = _year;

            return copy;
        }

        public string id()
        {
            return ID;
        }



        public Bitmap Drow(IFrame frame)
        {
            DayViewOne r = new DayViewOne();
            return r.Drow(this);
        }
    }
    class DayViewOne : IFrameDrow
    {
        // этот класс будет рисовать день в календаре

        public Bitmap Drow(IFrame frame)
        {
            
            if (String.Equals(frame.id(),"day"))
            {
                
            Day t = (Day)frame;

            Bitmap view = new Bitmap(ViewSettings.GetSettings().dayx, ViewSettings.GetSettings().dayy);
            Graphics g = Graphics.FromImage(view);
            g.FillRectangle(Brushes.Cyan, 0, 0, view.Width, view.Height);
            g.DrawString(t.day + "/",new Font("Times",5),Brushes.DarkOrange,2,2);

            return view;
            }
            return null;
        }
    }
    class DayViewFull : IFrameDrow
    {
        public Bitmap Drow(IFrame frame)
        {
            if (String.Equals(frame.id(), "day"))
            {
                DayViewOne t = new DayViewOne();

                Bitmap simple = t.Drow(frame);
                Graphics g = Graphics.FromImage(simple);
                g.DrawString("Full", new Font("Times", 100), Brushes.Gold, 3, 15);

                return simple;
            }
            return null;
        }
    }

}
