using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using PayScheduler.Structures;

namespace PayScheduler.Views
{
    interface IFrameDrow
    {
        /* рисовальщик объектов. через него рисуем объекты.
         * 
         */

        Bitmap Drow(IFrame frame);
        
    }

}
