using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PayScheduler.Structures;

namespace PayScheduler.Views
{
    class FrameWorker
    {   // создаем свои фреймы. свой обработчик координат мыши и прочее
        // контейнер фреймов. есть размеры, можно добавить фрейм указывая координаты.
        // потом автоматически рассчитывается куда тыкнул пользователь. если попадает внутрь фрейма - там тоже автоматически все рассчитывается.
        // и сразу понятно на какой объект попали. у каждого объекта - есть обработчик. в него и передаем управление.

        public int _height, _wight, _x, _y;
        public List<FrameWorker> _frames;
        public IFrame obj;

        public void addFrameWorker(FrameWorker frame, int x, int y, int h, int w)
        {
            FrameWorker add = new FrameWorker();
            add._x=x;
            add._y=y;
            add._height = h;
            add._wight = w;

            add.obj = frame.obj;
            add._frames = frame._frames;

            if (_frames == null) _frames = new List<FrameWorker>();

            _frames.Add(add);
        }

        public bool getin(int x,int y,int x1,int x2,int h,int w)
        {
            // попали ли в прямоугольник 

            if ((x > x1) && (x < x1 + w) && (y > x2) && (y < x2 + h)) return true;
            else return false;

        }

        public IFrame GetThis(int x, int y)
        {
            IFrame getmore = null;
            for (int i = 0; i < _frames.Count; i++)
            { 
               if (getin(x,y,_frames[i]._x,_frames[i]._y,_frames[i]._height,_frames[i]._wight))
               {
                // вот он объект.
                   // нужно у него спросить внутри может у него еще есть объекты.
                   getmore = _frames[i].GetThis(x-_frames[i]._x,y-_frames[i]._y);
                   break;
               }
            }
            
            if (getmore==null)
            {
                return obj;
            } else return getmore;

            
        }

    }
}
