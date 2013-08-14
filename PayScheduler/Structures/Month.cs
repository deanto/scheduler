using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using PayScheduler.Views;

namespace PayScheduler.Structures
{
    class Month:IFrame,IFrameDrow
    {
        /* класс для месяца. содержит ссылки на дни. 
         */

        IFrame[] days;

        string ID = "month";
        string _month;

        public string month { get { return _month; } set { _month = value; } }

        public Month()
        {
            days = new IFrame[31];// пусть будет всегда 31.
            for (int i = 0; i < 31; i++) days[i] = new Day();
        }

        private Month(Month pearent)
        {
            days = new IFrame[31];
            for (int i = 0; i < 31; i++) days[i] = pearent[i].copy();
        }

        public IFrame this[int i] {
            get { 
                return days[i];
            } set { days[i] = value; } }

        public IFrame copy()
        {
            Month copy = new Month(this);
            return copy;
            
        }

        public string id()
        {
            return ID;
        }

        public Bitmap Drow(IFrame frame)
        {
            MonthSimpleDrow t = new MonthSimpleDrow();
            return t.Drow(this);
        }
    }


    class MonthSimpleDrow : IFrameDrow
    {

        /// <summary>
        ///  это самый простой рисовальщик. таким будут рисоваться неактивные месяцы сбоку, в списке и прочее.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public Bitmap Drow(IFrame frame)
        {
            if (String.Equals(frame.id(), "month"))
            {
                // это значит первоначальный вариант, когда рисуются дни.

                //Month t=(Month)frame;

                //DayViewFull dw = new DayViewFull();

                //Bitmap[] days = new Bitmap[31];
                //int x=0,y=0;

                //for (int i = 0; i < 31; i++)
                //{   
                //    days[i] = dw.Drow(t[i]);
                //    x+=days[i].Width+30;
                    
                //    if (days[i].Height+30 > y) y=days[i].Height+30;
                //}

                //Bitmap result = new Bitmap(x, y);
                //Graphics g = Graphics.FromImage(result);
                
                //int p=0;
                //for (int i=0;i<31;i++){

                //    g.DrawImageUnscaled(days[i], p, 0);
                //    p += days[i].Width + 30;
                //    }

                //return result;


                // стандартное отображение используется для отображения фона месяца в фреймах
                Bitmap result = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(result);
                g.FillRectangle(Brushes.Beige, 0, 0, 100, 100);
                return result;

            }
            return null;

        }
    }

}
