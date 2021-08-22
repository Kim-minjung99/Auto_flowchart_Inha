using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.IO;


namespace ex
{
    

    public partial class Auto_Flowchart : Form
    {
        string txt;
        /*
        int x1;
        int y1;
        int x2;
        int y2;
        */
        //프로젝트 파일안에 있는 이미지 가져오기
        Bitmap start = new Bitmap("start.bmp");
        Bitmap card = new Bitmap("card.bmp");
        Bitmap decision = new Bitmap("decision.bmp");
        Bitmap document = new Bitmap("document.bmp");
        Bitmap end = new Bitmap("end.bmp");
        Bitmap input = new Bitmap("input.bmp");
        Bitmap output = new Bitmap("output.bmp");
        Bitmap process = new Bitmap("process.bmp");

      
        public Auto_Flowchart()//생성자 함수
        {
            InitializeComponent();

            SetClientSizeCore(1000, 1000);

        }
       
       
        public void Arrow(int x1,int y1,int x2,int y2) //화살표 그리는 함수
        {
            Graphics G = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            pen.StartCap = LineCap.ArrowAnchor;
            G.DrawLine(pen, x1,y1,x2,y2);

            G.Dispose();
        }



        public void Screen() //pictureBox1 캡쳐해서 저장하기 
        {
            Bitmap bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(PointToScreen(new Point(this.pictureBox1.Location.X, this.pictureBox1.Location.Y)), new Point(0, 0), this.pictureBox1.Size);
            Console.WriteLine("X좌표는:{0}", this.pictureBox1.Location.X);
            Console.WriteLine("Y좌표는:{0}", this.pictureBox1.Location.Y);
            bitmap.Save(@"J:\origin_flowchart\flowchart.png", System.Drawing.Imaging.ImageFormat.Png);
            pictureBox1.ImageLocation = @"J:\origin_flowchart\flowchart.png";

            MessageBox.Show("저장이 완료되었습니다.", "저장");

        }

        private void btn_Screen_Click(object sender, EventArgs e) //이미지 저장
        {
            Screen();

        }
        System.Windows.Forms.Label label;

       /*public Bitmap resize_BMP()//도형을 줄이는 방법을 정의
        {
            string[] filepath = new string[] { @"J:\포트폴리오\최강zi존 순서도\ex(1)\bin\Debug\start.bmp",
                @"J:\포트폴리오\최강zi존 순서도\ex(1)\bin\Debug\card.bmp",
                @"J:\포트폴리오\최강zi존 순서도\ex(1)\bin\Debug\decision.bmp", 
                @"J:\포트폴리오\최강zi존 순서도\ex(1)\bin\Debug\document.bmp"}; //순서도 도형 파일경로 배열에 선언
            
            for(int i = 0; i <= filepath.Length; i++)
            {
                Bitmap bitmap = new Bitmap();
                if (Path.GetFileNameWithoutExtension(start))
                {

                }
            }
            
        }*/

      

       

        public void btn_Change_Click(object sender, EventArgs e)// 이미지 전환
        {
            string txt = textBox1.Text;
            Graphics p = pictureBox1.CreateGraphics();
            Bitmap plbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

           // Graphics flowchart = Graphics.FromImage(plbmp);
            
            start = new Bitmap("start.bmp");
            card = new Bitmap("card.bmp");
            decision = new Bitmap("decision.bmp");
            document = new Bitmap("document.bmp");
            end = new Bitmap("end.bmp");
            input = new Bitmap("input.bmp");
            output = new Bitmap("output.bmp");
            process = new Bitmap("process.bmp");

            // ';'문자를 기준으로 텍스트 한줄씩 분해해서 label에 붙이기
            string[] allLines = textBox1.Text.Split(';');
            

            


            //"시작 도형" 절반줄임
            int width = start.Width / 2;
            int height = start.Height / 2;
            Size resize = new Size(width, height);
            Bitmap resize_start = new Bitmap(start, resize);
            

            //"card" 절반줄임
            int c_width = allLines[0].Length * 10;
            Console.WriteLine("card의  width: {0}", c_width);
            int c_height = allLines[0].Length + 30;
            Console.WriteLine("card의  height: {0}", c_height);

            Size c_resize = new Size(c_width, c_height);
            Bitmap resize_card = new Bitmap(card, c_resize);


            //"decision" 절반줄임
            int d_width = allLines[1].Length * 10;
            Console.WriteLine("decision의  width: {0}", d_width);
            int d_height = allLines[1].Length + 30;
            Console.WriteLine("decision의  height: {0}", d_height);

            Size d_resize = new Size(d_width, d_height);
            Bitmap resize_decision = new Bitmap(decision, d_resize);

            //"document" 절반줄임
            int do_width = allLines[2].Length * 10;
            Console.WriteLine("document의  width: {0}", do_width);
            int do_height = allLines[2].Length + 30;
            Console.WriteLine("document의  height: {0}", do_height);
            Size do_resize = new Size(do_width, do_height);
            Bitmap resize_document = new Bitmap(document, do_resize);



            //

            /*
            g.DrawImage(resize_bmp1, 50, 10);//시작도형의 크기, 위치는 고정이다.
            g.DrawString("시작", Font, Brushes.Black, 78, 28);

            g.DrawImage(bmp2, 50, 100);//10,10의 포인트에 bmp3를 그려라
            g.DrawString(txt, Font, Brushes.Black, 120, 50);
            g.DrawImage(bmp3, 50, 190);//10,10의 포인트에 bmp3를 그려라
            g.DrawString(txt, Font, Brushes.Black, 120, 50);
            g.Dispose();*/
            //decision 도형

            //화살표 만들기
            int[] Point_Array = new int[4] { 0, 0, 0, 0 };

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            int CenterX = 0;

           
            for (int turn = 5; turn <= 20; turn = turn + 5)// 패널상의 위치 포인트를 자동으로 주기위해 for문주기
            {
                //int margin =+ 5; turn 대신에 margin으로 간격곱하기 대체
                //Boolean trues = false;//전에 태영이가 말한 것처럼 false면 화살표 안그리고 true면 화살표그리고...
                
                Point pt = new Point(80, 15 * turn);//도형의 y좌표(도형간 간격)를 주기위한 포인트값

                //픽쳐박스에 이미지 그리기
                Graphics g = pictureBox1.CreateGraphics();

                //패널상에 도형 위치 지정
                switch (turn)
                {

                    case 5:

                        Point pt1 = new Point(150, 50);

                        g.DrawImage(resize_start, pt1);//시작도형
                        g.DrawString("시작", Font, Brushes.Black, 107, 65);
                        
                        x1 = 80 + resize_start.Width / 2;
                        y1 = 50 + resize_start.Height;


                        //가운데 정렬하기위한 중앙값 x좌표를 구하는 공식
                        CenterX = pt1.X + resize_start.Width / 2;
                        
                        Point_Array[0] = CenterX;
                        Point_Array[1] = y1;


                        break;

                    case 10:
                        x2 = pt.X + resize_card.Width / 2;//이미 변화한 좌표값
                        y2 = pt.Y;//화살표 그리기위한 좌표

                        Point pt2 = new Point(CenterX - (resize_card.Width/2), pt.Y);//두번째 도형을 그리는 가운데정렬 포인트, 그림그리기 위해선 포인트
                        //값이 필요하므로 임시로 그림을 위한 좌표값이다.

                        g.DrawImage(resize_card, pt2);
                        g.DrawString(allLines[0], Font, Brushes.Black, 100, 16 * turn);

                        Point_Array[2] = CenterX;
                        Point_Array[3] = y2;//첫번째 도형에서 두번째 도형까지의 도착

                        Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                        Array.Clear(Point_Array, 0, 4);//배열 비우기

                        Console.WriteLine("0: {0} 비어야한다", Point_Array[0]);
                        Console.WriteLine("1: {0} 비어야한다", Point_Array[1]);
                        Console.WriteLine("2: {0} 비어야한다", Point_Array[2]);
                        Console.WriteLine("3: {0} 비어야한다", Point_Array[3]);

                        Point_Array[0] = CenterX;
                        Point_Array[1] = pt.Y + resize_card.Height;//두번째 도형에서의 시작
                       
                        break;

                    case 15:

                        Point pt3 = new Point(CenterX - (resize_decision.Width / 2), pt.Y);

                        g.DrawImage(resize_decision, pt3);//10,10의 포인트에 bmp3를 그려라
                        g.DrawString(allLines[1], Font, Brushes.Black, 100, 15 * turn);

                        Point_Array[2] = CenterX;
                        Point_Array[3] = pt.Y;//두번째 도형에서 세번째 도형으로의 도착
                        Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                        Array.Clear(Point_Array, 0, 4);//배열 비우기

                        Console.WriteLine("0: {0}", Point_Array[0]);
                        Console.WriteLine("1: {0}", Point_Array[1]);
                        Console.WriteLine("2: {0}", Point_Array[2]);
                        Console.WriteLine("3: {0}", Point_Array[3]);
                        
                        Point_Array[0] = CenterX;
                        Point_Array[1] = pt.Y + resize_decision.Height;
                        break;

                    case 20://마지막 도형

                        Point pt4 = new Point(CenterX - (resize_document.Width / 2), pt.Y);
                        g.DrawImage(resize_document, pt4);//10,10의 포인트에 bmp3를 그려라
                        g.DrawString(allLines[2], Font, Brushes.Black, 100, 15 * turn);
                        Point_Array[2] = CenterX;
                        Point_Array[3] = pt.Y;
                        Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);

                        break;


                    //case 25:

                    //case 30:

                    //case 35:

                    //case 40:

                }

                //turn += turn;
                g.Dispose();//Graphics g = panel2.CreateGraphics();
                            //부분에서 CreateGraphics는 직접 호출하여 Graphics객체를 선언한것이기 때문에
                            //Dispose로 모든 리소스를 해제해줘야 한다.


            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
//그림의 그려지는 포인트는 왼쪽위, 근데 중간점이 필요한 이유는 도형들을 가운데 정렬하기 위해서이다.
//기준점은 start_bmp, start_bmp의 중간점을 구한 후 x값은 그대로, y값은 turn의 거리만큼 주면된다
//만약, 두번째 도형이 if문 도형이라면~ 같은 비트맵 도형의 종류를 구분할 수 있는 부분도 있어야 한다.-> 도형을 줄이는 법, 정렬하는 법이
//다르기 떄문에

//그림을 기준으로 해서 글씨까지 위치지정이 되도록 설정해야한다.
