using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ex
{
    public partial class Form1 : Form
    {

        //프로젝트 파일안에 있는 이미지 가져오기
        Bitmap start = new Bitmap("start.bmp");
        Bitmap card = new Bitmap("card.bmp");
        Bitmap decision = new Bitmap("decision.bmp");
        Bitmap document = new Bitmap("document.bmp");
        Bitmap end = new Bitmap("end.bmp");
        Bitmap input = new Bitmap("input.bmp");
        Bitmap output = new Bitmap("output.bmp");
        Bitmap process = new Bitmap("process.bmp");
        Bitmap loop = new Bitmap("loop.bmp");


        string[] allLines;
        Graphics g;
        Font font = new Font("맑은고딕", 12, FontStyle.Bold);

        private float pictureXscale = 1.0f;
        private float pictureYscale = 1.0f;
        private Matrix inverseTransform = new Matrix();
        private const int WORLD_WIDTH = 3000;
        private const int WORLD_HEIGHT = 3000;

        //if 문 갈래길에 필요한 Centerx2를 설정하기위해 도형의 길이비교를 하기위한 선언
        int decision_width;
        int loop_width;
        int document_width;
        int input_width;

        Size resize = new Size();
        Size end_resize = new Size();
        Size d_resize = new Size();
        //Size d2_resize = new Size();
        Size dc_resize = new Size();
        Size input_resize = new Size();
        Size process2_resize = new Size();

        int CenterX = 0;
        int CenterX2 = 0;//true false 갈래기준점

        int End_y1 = 0;//각기 순서도에서 그려진 도형의 y좌표를 비교하고 가장 밑에있는 도형의 y좌표를 구해서 그 y좌표 밑으로 화살표를 그린다.
        int End_y2 = 0;
        int End_y3 = 0;
        int End_y4 = 0;
        int End_y5 = 0;

        int end_Y = 0;//밑에 코드중에 End_y1...을 비교하여 맨 밑에있는 도형의 y값의 +5한 최종값을 end_Y라고 하였다.

        Point pt2 = new Point();



        public Form1()
        {
            InitializeComponent();

        }

        //화살표 그리는 함수
        public void Arrow(int x1, int y1, int x2, int y2)
        {
            Graphics G = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            pen.StartCap = LineCap.ArrowAnchor;

            G.DrawLine(pen, x1, y1, x2, y2);

            G.Dispose();
        }

        public void IFCurveArrow_Flat(int x2, int y2, int x1, int y1)//if 문의 true false를 위한 꺾인 화살표
        {
            Graphics G2 = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);

            pen.StartCap = LineCap.Flat;//직선의 선을 그리는 용도
            //pen.StartCap = LineCap.ArrowAnchor;//화살표촉


            G2.DrawLine(pen, x2, y2, x1, y1);//둘이 동시에 그려지지 않는다.
            G2.DrawString("True", Font, Brushes.Black, x2 + 5, y2 + 5);

            G2.Dispose();
        }
        public void IFCurveArrow_Ancher(int x2, int y2, int x1, int y1)//if 문의 true false를 위한 꺾인 화살표
        {
            Graphics G2 = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);


            pen.StartCap = LineCap.ArrowAnchor;//화살표촉

            G2.DrawLine(pen, x2, y2, x1, y1);//둘이 동시에 그려지지 않는다.


            G2.Dispose();
        }

        public void Screen() //pictureBox1 캡쳐해서 저장하기
        {

            int count = 1;
            while (true) 
            {
                Bitmap bitmap = new Bitmap(this.panel1.Width, this.panel1.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(PointToScreen(new Point(this.panel1.Location.X, this.panel1.Location.Y)), new Point(0, 0), this.panel1.Size);
                bitmap.Save(@"J:\포트폴리오\origin_flowchart\EX_flowchart" + count.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);

                //pictureBox1.Image.Save(@"C:\Temp\flowchart\EX_flowchart.png", System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("저장이 완료되었습니다.", "저장");
                count++;
                break;
            }
            

        }
        //public void Screen() //pictureBox1 캡쳐해서 저장하기 //민정이버전캡쳐
        //{
        //    int count = 1;
        //    while (true)
        //    {
        //        Bitmap bitmap = new Bitmap(this.panel1.Width, this.panel1.Height);
        //        Graphics graphics = Graphics.FromImage(bitmap);
        //        graphics.CopyFromScreen(PointToScreen(new Point(this.panel1.Location.X, this.panel1.Location.Y)), new Point(0, 0), this.panel1.Size);
        //        bitmap.Save(@"J:\포트폴리오\origin_flowchart\EX_flowchart" + count.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);

        //        MessageBox.Show("저장이 완료되었습니다.", "저장");
        //        count++;
        //        break;
        //    }

        //}

        private void btn_Screen_Click(object sender, EventArgs e) //이미지 저장
        {
            //bmp1.Save(@"C:\Temp\flowchart\flowchart2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //bmp2.Save(@"C:\Temp\flowchart\flowchart3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            //Size sz = new Size(this.Bounds.Width, this.Bounds.Height);
            //FormCapture(sz, @"C:\Temp\flowchart\autoflowchart.jpg");

            //panel2를 비트맵으로 전환하여 이미지 저장
            //Bitmap plbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.DrawToBitmap(plbmp, new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

            Screen();
        }

        private void btn_Change_Click(object sender, EventArgs e)// 이미지 전환
        {
            pictureBox1.Size = panel1.Size;
            SetScale(1.0f, 1.0f);
            panel1.Refresh();


        }

        private void scaleComboBox_SelectedIndexChanged_1(object sender, EventArgs e) //콤보박스 패널 크기 선택
        {
            switch (this.scaleComboBox.Text)
            {
                case "x 0.1":
                    SetScale(0.6f, 0.4f);
                    break;
                case "x 0.2":
                    SetScale(0.6f, 0.5f);
                    break;
                case "x 0.4":
                    SetScale(0.8f, 0.6f);
                    break;
                case "x 0.6":
                    SetScale(0.8f, 0.7f);
                    break;
                case "x 0.8":
                    SetScale(1.0f, 0.8f);
                    break;
                case "x 1":
                    SetScale(1.0f, 1.0f);
                    break;
            }
        }

        private void SetScale(float Xscale, float Yscale) //패널크기 조절
        {
            pictureXscale = Xscale;
            pictureYscale = Yscale;

        pictureBox1.ClientSize = new Size((int)(WORLD_WIDTH * pictureXscale), (int)(WORLD_HEIGHT * pictureYscale));
            inverseTransform = new Matrix();
            inverseTransform.Scale(1.0f / Xscale, 1.0f / Yscale);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Ready.
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);

            // Scale.
            e.Graphics.ScaleTransform(this.pictureXscale, this.pictureYscale);

            //패널에 이미지 그리기
            g = this.pictureBox1.CreateGraphics();

            // Draw.
            drawline(e.Graphics);
            //e로 그리는게 아니다?
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //// Ready.
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            ////e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.Clear(Color.White);

            //// Scale.
            //e.Graphics.ScaleTransform(this.pictureScale, this.pictureScale);

            ////패널에 이미지 그리기
            //g = this.pictureBox1.CreateGraphics();

            //// Draw.
            //drawline(e.Graphics);
            ////e로 그리는게 아니다?
        }

        private void drawline(Graphics g)
        {

            Bitmap plbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            // ';'문자를 기준으로 텍스트 한줄씩 분해
            allLines = textBox1.Text.Split(';');

            //"시작 도형" 절반줄임
            int width = start.Width;
            int height = start.Height;
            resize = new Size(width, height);
            Bitmap resize_start = new Bitmap(start, resize);

            //"종료 도형" 절반줄임
            int end_width = end.Width / 2;
            int end_height = end.Height / 2;
            end_resize = new Size(end_width, end_height);
            Bitmap resize_end = new Bitmap(end, end_resize);

            //도형의 파일명 가져오기
            string filepath1 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\decision.bmp";
            string filepath2 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\document.bmp";
            string filepath3 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\card.bmp";
            string filepath4 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\input.bmp";
            string filepath5 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\process.bmp";
            string filepath6 = @"J:\포트폴리오\최강zi존 순서도\ex_3\bin\Debug\end.bmp";
            //string filepath4 = @"C:\Users\didek\OneDrive\Desktop\ex (2)\bin\Debug\process.bmp";
            //Console.WriteLine(Path.GetFileName(filepath1));

            //화살표 만들기
            int[] Point_Array = new int[4] { 0, 0, 0, 0 };

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;

            Boolean arrowistrue = false;


            if (arrowistrue == false) //시작도형 만들기
            {
                Point pt1 = new Point(200,50);
                g.DrawImage(resize_start, pt1);//시작도형
                g.DrawString("시작", font, Brushes.Black, 243, 72);

                x1 = 80 + resize_start.Width / 2;
                y1 = 50 + resize_start.Height;

                //Console.WriteLine("시작도형의 i: {0}", i);

                //가운데 정렬하기위한 중앙값 x좌표를 구하는 공식
                // pt1.X + resize_start.Width / 2
                CenterX = pt1.X + resize_start.Width / 2; 

                Point_Array[0] = CenterX;
                Point_Array[1] = y1;   //start도형이 가지고 있어야 하는 0,1좌표

                arrowistrue = true;
            }

            for (int i = 0; i < allLines.Length; i++)//textarea의 문자의 줄 수만큼 반복(Length의 반대)   
            {
                Point pt = new Point(80, 10 * (6 * (i + 2)));//15*i 값 수정, 도형의 위치를 제대로 주기 위함

                if (arrowistrue == true)
                {
                    if (allLines[i].Contains("if"))//마름모꼴
                    {
                        //각각 decision도형마다 resize
                        if (filepath1.Contains("decision"))
                        {
                            decision_width = allLines[i + 1].Length * 30; // 나중에 제일 긴 width를 비교하기 위함
                            int decision_height = allLines[i + 1].Length + 50;
                            d_resize = new Size(decision_width, decision_height);
                            Bitmap resize_decision = new Bitmap(decision, d_resize);


                            x2 = pt.X + resize_decision.Width / 2;//이미 변화한 좌표값
                            y2 = pt.Y;//화살표 그리기위한 좌표

                            pt2 = new Point(CenterX - (resize_decision.Width / 2), pt.Y);//두번째 도형을 그리는 가운데정렬 포인트, 그림그리기 위해선 포인트
                                                                                         //값이 필요하므로 임시로 그림을 위한 좌표값이다.

                            g.DrawImage(resize_decision, pt2);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_decision.Width / 8), pt.Y);

                            Point_Array[2] = CenterX;
                            Point_Array[3] = y2;//첫번째 도형에서 두번째 도형까지의 도착

                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기


                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt.Y + resize_decision.Height;//두번째 도형에서의 시작

                            //----------------------------------------centerx2----------------------------------------------------------

                            int process2_width = allLines[i + 1].Length * 20;
                            int process2_height = allLines[i + 1].Length + 30;
                            process2_resize = new Size(process2_width, process2_height);
                            Bitmap resize_process2 = new Bitmap(process, process2_resize);


                            //x2 = pt.X + resize_decision2.Width / 2;//이미 변화한 좌표값
                            y2 = pt.Y;//화살표 그리기위한 좌표

                            Point pt2_2 = new Point(CenterX2 - (resize_process2.Width / 2), y2 + 60);//두번째 도형을 그리는 가운데정렬 포인트, 그림그리기 위해선 포인트
                                                                                                     //값이 필요하므로 임시로 그림을 위한 좌표값이다.

                            Console.WriteLine("CenterX2 : {0}", CenterX2);

                            g.DrawImage(resize_process2, pt2_2);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX2 - (resize_process2.Width / 8), y2 + 60);

                            /*
                            Point_Array[2] = CenterX2;
                            Point_Array[3] = y2;//첫번째 도형에서 두번째 도형까지의 도착

                            
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기
                           

                            

                            Point_Array[0] = CenterX2;
                            Point_Array[1] = pt.Y + resize_decision2.Height;//두번째 도형에서의 시작
                            */
                            //flat함수를 부르기 위한 x좌표 y좌표
                            int x2_1 = pt2.X + d_resize.Width;
                            int y2_1 = pt2.Y + d_resize.Height / 2;

                            int y2_2 = pt2.Y + d_resize.Height / 2;
                            int x2_2 = CenterX2;


                            //Arrow_ancher함수를 위한 x좌표 y좌표
                            int Ax2_1 = CenterX2;
                            int Ay2_1 = pt2.Y + d_resize.Height / 2;

                            int Ay2_2 = pt2.Y + d_resize.Height + 3;
                            int Ax2_2 = CenterX2;


                            IFCurveArrow_Flat(x2_2, y2_2, x2_1, y2_1);
                            IFCurveArrow_Ancher(Ax2_2, Ay2_2, Ax2_1, Ay2_1);//각각 함수를 부른다.


                            //본래자리로 돌아가는 화살표
                            int BackF_x1 = CenterX2;
                            int BackF_y1 = pt2_2.Y + process2_resize.Height;
                            int BackF_x2 = CenterX2;
                            int BackF_y2 = end_Y;

                            int BackA_x1 = CenterX2;
                            int BackA_y1 = end_Y;
                            int BackA_x2 = CenterX;
                            int BackA_y2 = end_Y;

                            Console.WriteLine("도형을 그리는 시점의 end_Y : {0}", end_Y);

                            IFCurveArrow_Flat(BackF_x2, BackF_y2, BackF_x1, BackF_y1);
                            IFCurveArrow_Ancher(BackA_x2, BackA_y2, BackA_x1, BackA_y1);
                        }

                    }
                    //print문이 나오면 document도형 생성하기
                    else if (allLines[i].Contains("print"))//document도형
                    {
                        //각각 document도형마다 resize
                        if (filepath2.Contains("document"))
                        {
                            document_width = allLines[i + 1].Length * 20;
                            int document_height = allLines[i + 1].Length + 30;
                            dc_resize = new Size(document_width, document_height);
                            Bitmap resize_document = new Bitmap(document, dc_resize);


                            //document 그림을그리기위한 pt값을 줘서 
                            Point pt3 = new Point(CenterX - (resize_document.Width / 2), pt.Y);

                            //resize된 document도형 그리기
                            g.DrawImage(resize_document, pt3);//pt값을 적용
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_document.Width / 8), pt.Y);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt3.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1], g);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기

                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt3.Y + resize_document.Height;


                        }

                    }
                    //for문이 나오면 loop도형 생성하기
                    else if (allLines[i].Contains("for"))//loop도형
                    {
                        //각각 loop도형마다 resize
                        if (filepath3.Contains("loop"))
                        {
                            loop_width = allLines[i + 1].Length * 12;
                            int loop_height = allLines[i + 1].Length * 10;
                            Size lp_resize = new Size(loop_width, loop_height);
                            Bitmap resize_loop = new Bitmap(loop, lp_resize);


                            //process도형은 for문 안에 반복할 문장을 갯수만큼 만들기
                            int ps_width = allLines[i + 1].Length * 8;
                            int ps_height = allLines[i + 1].Length + 20;
                            Size ps_resize = new Size(ps_width, ps_height);
                            Bitmap resize_process = new Bitmap(process, ps_resize);


                            //while(조건)
                            Point pt5 = new Point(CenterX - (resize_loop.Width / 3), pt.Y + 40);
                            g.DrawImage(resize_process, pt5);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, pt5.X + 10, pt5.Y);
                            Point pt6 = new Point(CenterX - (resize_loop.Width / 3), pt.Y + 90);
                            g.DrawImage(resize_process, pt6);
                            g.DrawString(allLines[i + 2], Font, Brushes.Black, pt6.X + 10, pt6.Y);
                            Point pt7 = new Point(CenterX - (resize_loop.Width / 3), pt.Y + 140);
                            g.DrawImage(resize_process, pt7);
                            g.DrawString(allLines[i + 3], Font, Brushes.Black, pt7.X + 10, pt7.Y);


                            Point pt4 = new Point(CenterX - (resize_loop.Width / 2), pt.Y);

                            //resize된 loop도형 그리기
                            g.DrawImage(resize_loop, pt4);
                            //loop도형의 종류
                            g.DrawString(allLines[i], font, Brushes.Black, CenterX - (resize_loop.Width / 2) + 10, pt.Y - 12);
                            //g.DrawString("for", font, Brushes.Black, CenterX - (resize_loop.Width /2)+10, pt.Y + 5);
                            //for문의 조건
                            g.DrawString(allLines[i], Font, Brushes.Black, CenterX + (resize_loop.Width / 6), pt.Y - 6);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt4.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1], g);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기

                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt4.Y + resize_loop.Height;


                        }

                    }

                    else if (allLines[i].Contains("scanf"))//--------------------------------입력-코드상
                    {
                        if (filepath4.Contains("input"))//파일이름
                        {

                            input_width = allLines[i + 1].Length * 20;
                            int input_height = allLines[i + 1].Length + 30;
                            input_resize = new Size(input_width, input_height);
                            Bitmap resize_scanf = new Bitmap(input, input_resize);

                            //card 그림을그리기위한 pt값을 줘서 
                            Point pt5 = new Point(CenterX - (resize_scanf.Width / 2), pt.Y);

                            g.DrawImage(resize_scanf, pt5);//pt값을 적용
                                                           //g.DrawString(allLines[i + 1], Font, Brushes.Black, 70, i * 70);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_scanf.Width / 8), pt.Y);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt5.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1], g);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기

                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt5.Y + resize_scanf.Height;

                        }
                    }
                    /*else if (allLines[i].Contains("[]"))//배열선언
                      {
                          if (filepath4.Contains("scanf"))
                          {

                              int input_width = allLines[i + 1].Length * 20;
                              int input_height = allLines[i + 1].Length + 30;
                              Size input_resize = new Size(input_width, input_height);
                              Bitmap resize_scanf = new Bitmap(input, input_resize);

                              //card 그림을그리기위한 pt값을 줘서 
                              Point pt4 = new Point(CenterX - (resize_scanf.Width / 2), pt.Y);

                              g.DrawImage(resize_scanf, pt4);//pt값을 적용
                                                             //g.DrawString(allLines[i + 1], Font, Brushes.Black, 70, i * 70);
                              g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_scanf.Width / 8), pt.Y);


                              Point_Array[2] = CenterX;
                              Point_Array[3] = pt4.Y;
                              Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                              Array.Clear(Point_Array, 0, 4);//배열 비우기

                              Point_Array[0] = CenterX;
                              Point_Array[1] = pt4.Y + resize_scanf.Height;

                          }
                      }*/
                
            
                    else if (allLines[i].Contains("end"))//--------------------------------입력-코드상
                    {
                        if (filepath6.Contains("end"))//파일이름
                        {

                            Point pt_end = new Point(CenterX - (end.Width / 2), pt.Y);

                            g.DrawImage(end, pt_end);//pt값을 적용
                                                        //g.DrawString(allLines[i + 1], Font, Brushes.Black, 70, i * 70);
                            g.DrawString("종료", font, Brushes.Black, CenterX - (end.Width / 8)-5, pt.Y+20);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt_end.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1], g);
                            //Array.Clear(Point_Array, 0, 4);//배열 비우기

                            //Point_Array[0] = CenterX;
                            //Point_Array[1] = pt5.Y + resize_scanf.Height;

                        }
                    }
            
                }//arrowistrue가 true

            }//for문
             //for문
             //Console.WriteLine("길이가 들어가는지 확인 : {0}", decision_width); 하면 길이가 들어간다(전역변수로 지정)
            /*int decision_width;
            int card_width;
            int document_width;
            int input_width;*/
            int high_width = 0;
            if (decision_width > loop_width && decision_width > document_width && decision_width > input_width)
            {
                high_width = decision_width;
            }
            else if (loop_width > decision_width && loop_width > document_width && loop_width > input_width)
            {
                high_width = loop_width;
            }
            else if (document_width > decision_width && document_width > loop_width && document_width > input_width)
            {
                high_width = document_width;
            }
            else if (input_width > decision_width && input_width > document_width && input_width > loop_width)
            {
                high_width = input_width;
            }

            CenterX2 = high_width + CenterX;
            Console.WriteLine("두번째 Centerx2는 {0}", CenterX2);
        }
        //CenterX2를 구했다. 구한 centerx2를 토대로 이미지 배치를 하면될듯... 성공
        //마지막에 하는 이유는 모든 도형들이 그려지고 나서 width길이 비교를 한 후 centerx2를 구하기 떄문에 마지막에 배치시킨다.
        //구한 centerx2를 가지고 이제 if문옆에 false로 들어가는 도형을 그려야한다.

        /*public void CenterX2_method(int CenterX2)//매개변수//CenterX2를 구하기 위한 메소드
        {


        }*/
    }
}

//글자수가 옆으로 centerx2설정시 화면을 넘어가면 화살표가 이상하게 표시됨
//비트맵 다시 설정해서 축소하고 표시해주는 방식으로..?