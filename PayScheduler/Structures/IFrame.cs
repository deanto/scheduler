using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayScheduler.Structures
{
    interface IFrame
    {
        /* IFrame интерфейс для всех объектов на экране. это и весь месяц и каждый день
         * что может:
         * - копировать себя - предоставляет такой же объект
         * - говорить кто это - строковый идентификатор
         * - 
        */

        IFrame copy();
        string id();
    }
}
