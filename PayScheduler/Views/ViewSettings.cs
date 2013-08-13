using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayScheduler.Views
{
    class ViewSettings
    {
        // класс работающий с настройками.
        /*
         * шаблон одиночка.один класс на всю систему - меняем настройки в одном месте - меняются везде.так как все рисовальщики знают где брать настройки эти
         * 
         */

        public int dayx, dayy;

        private ViewSettings()
        {
            // default
            dayx = 10;
            dayy = 30;
        }

        private static ViewSettings link;

        public static ViewSettings GetSettings()
        {
            if (link == null)
            {
                link = new ViewSettings();
            }
            return link;
        }

    }
}
