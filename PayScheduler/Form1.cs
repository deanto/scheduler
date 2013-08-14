using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using PayScheduler.Structures;
using PayScheduler.Views;

namespace PayScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vs = ViewSettings.GetSettings();


            frames = new FrameWorker(); // первый уровень.просто фон
            frames._x = 10;
            frames._y = 10;
            frames._height = 800;
            frames._wight = 600;
            frames.obj = new Background();



            FrameWorker frame1 = new FrameWorker();// первый месяц
            frame1.obj = new Month();
            

                FrameWorker month1day1 = new FrameWorker();
                month1day1.obj = new Structures.Day();
                frame1.addFrameWorker(month1day1, 20, 20, 20, 20);
                FrameWorker month1day2 = new FrameWorker();
                month1day2.obj = new Structures.Day();
                frame1.addFrameWorker(month1day2, 60, 20, 20, 20);
                FrameWorker month1day3 = new FrameWorker();
                month1day3.obj = new Structures.Day();
                frame1.addFrameWorker(month1day3, 20, 60, 20, 20);


            FrameWorker frame2 = new FrameWorker(); // второй месяц
            frame2.obj = new Month();
            

                FrameWorker month2day1 = new FrameWorker();
                month2day1.obj = new Structures.Day();
                frame2.addFrameWorker(month2day1, 20, 20,260,160);
                FrameWorker month2day2 = new FrameWorker();
                month2day2.obj = new Structures.Day();
                frame2.addFrameWorker(month2day2, 220, 20, 260, 160);

            frames.addFrameWorker(frame1, 10, 300, 100, 100);
            frames.addFrameWorker(frame2, 150, 10,300, 400);
            
        }

        ViewSettings vs;
        Month month;
        MonthSimpleDrow t;


        FrameWorker frames;


        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap view = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(view);
            g.DrawImage(d(frames), frames._x, frames._y, frames._wight, frames._height);

            pictureBox1.Image = view;

        }

        

       private Bitmap d(FrameWorker frame)
        {

           Bitmap view = new Bitmap(frame._wight, frame._height);
            // на него все покидаем из этого фрейма

           Graphics g = Graphics.FromImage(view);

           g.DrawImage(frame.obj.Drow(null), 0, 0, view.Width, view.Height);
           if (frame._frames!=null)

               for (int i = 0; i < frame._frames.Count; i++)
               {
                   Bitmap tmp = d(frame._frames[i]);
                   g.DrawImage(tmp, frame._frames[i]._x, frame._frames[i]._y, frame._frames[i]._wight, frame._frames[i]._height);

               }
           

           return view;
        }
    }
}
