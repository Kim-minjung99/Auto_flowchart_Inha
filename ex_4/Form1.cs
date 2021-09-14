using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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


        Graphics g = null;
        static int start_x, start_y;
        static int end_x, end_y;
        static int my_angle = 0;

        private float pictureScale = 1.0f;
        private Matrix inverseTransform = new Matrix();
        private const int WORLD_WIDTH = 200;
        private const int WORLD_HEIGHT = 200;


        //if 문 갈래길에 필요한 Centerx2를 설정하기위해 도형의 길이비교를 하기위한 선언
        int decision_width;
        int card_width;
        int document_width;
        int input_width;


        Size resize=new Size();
        Size end_resize = new Size();
        Size d_resize = new Size();
        //Size d2_resize = new Size();
        Size dc_resize = new Size();
        Size input_resize = new Size();
        Size process2_resize = new Size();

        int CenterX = 0;
        int CenterX2 = 0;//true false 갈래기준점

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

        public void IFCurveArrow_Flat()//if 문의 true false를 위한 꺾인 화살표
        {
            Graphics G2 = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            
            pen.StartCap = LineCap.Flat;//직선의 선을 그리는 용도
            //pen.StartCap = LineCap.ArrowAnchor;//화살표촉

            int x2_1 = pt2.X + d_resize.Width;
            int y2_1 = pt2.Y + d_resize.Height / 2;

            int y2_2 = pt2.Y + d_resize.Height / 2;
            int x2_2 = CenterX2;



            G2.DrawLine(pen, x2_2, y2_2, x2_1, y2_1);//둘이 동시에 그려지지 않는다.
            G2.DrawString("False", Font, Brushes.Black, x2_1, y2_1 - 15);

            G2.Dispose();
        }
        public void IFCurveArrow_Ancher()//if 문의 true false를 위한 꺾인 화살표
        {
            Graphics G2 = panel1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);

            
            pen.StartCap = LineCap.ArrowAnchor;//화살표촉

            int x2_1 = CenterX2;
            int y2_1 = pt2.Y + d_resize.Height / 2;

            int y2_2 = pt2.Y + d_resize.Height + 3;
            int x2_2 = CenterX2;

            
            G2.DrawLine(pen, x2_2, y2_2, x2_1, y2_1);//둘이 동시에 그려지지 않는다.
            

            G2.Dispose();
        }


       

        private void btn_Screen_Click(object sender, EventArgs e) //이미지 저장
        {
            Screen();
        }

        private void btn_Change_Click(object sender, EventArgs e)// 이미지 전환
        {
            start_x = panel1.Width / 2;
            start_y = panel1.Height / 2;

            panel1.Refresh();
        }

        private void scaleComboBox_SelectedIndexChanged_1(object sender, EventArgs e) //콤보박스 패널 크기 선택
        {
            switch (this.scaleComboBox.Text)
            {
                case "x 1/4":
                    SetScale(0.25f);
                    break;
                case "x 1/2":
                    SetScale(0.5f);
                    break;
                case "x 1":
                    SetScale(1.0f);
                    break;
                case "x 2":
                    SetScale(2.0f);
                    break;
                case "x 4":
                    SetScale(4.0f);
                    break;
                case "x 8":
                    SetScale(8.0f);
                    break;
            }
        }

        private void SetScale(float scale) //패널크기 조절
        {
            
            pictureScale = scale;
            panel1.ClientSize = new Size((int)(WORLD_WIDTH * this.pictureScale), (int)(WORLD_HEIGHT * this.pictureScale)); 
            inverseTransform = new Matrix(); 
            inverseTransform.Scale(1.0f / scale, 1.0f / scale); 
            panel1.Refresh(); 
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            drawline();
            
        }

         public void Screen() //pictureBox1 캡쳐해서 저장하기
        {
            int count = 1;
            while(true)
            { 
                Bitmap bitmap = new Bitmap(this.panel1.Width, this.panel1.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(PointToScreen(new Point(this.panel1.Location.X, this.panel1.Location.Y)), new Point(0, 0), this.panel1.Size);
                bitmap.Save(@"J:\포트폴리오\origin_flowchart\EX_flowchart" + count.ToString() + ".bmp" , System.Drawing.Imaging.ImageFormat.Bmp);

                MessageBox.Show("저장이 완료되었습니다.", "저장");
                count++;
                break;
             }
           
        }

        


        //만약 코드상의 내용에 for, if, scanf...등의 내용이 있다면 도형을 불러오고, 도형상의 좌표를 구하여
        //그 좌표의 내용에 맞게 화살표를 그린다.
        public void drawline()
        {
            Bitmap plbmp = new Bitmap(panel1.Width, panel1.Height);

            //패널에 이미지 그리기
            Graphics g = panel1.CreateGraphics();

            // ';'문자를 기준으로 텍스트 한줄씩 분해
            string[] allLines = textBox1.Text.Split(';');

            //"시작 도형" 절반줄임
            int width = start.Width / 2;
            int height = start.Height / 2;
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

            //process는 사칙연산이나 어려운 계산식들을 때려박는 용도-애들이랑 회의 후에 합칠때 어떻게, 어떤방식으로 넣어야할지 고민해야할듯
            //end는 항상 마지막의 도형

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
                Point pt1 = new Point(100, 50);
                g.DrawImage(resize_start, pt1);//시작도형
                g.DrawString("시작", Font, Brushes.Black, 125, 65);

                x1 = 80 + resize_start.Width / 2;
                y1 = 50 + resize_start.Height;

               

                //가운데 정렬하기위한 중앙값 x좌표를 구하는 공식
                CenterX = pt1.X + resize_start.Width / 2;
                //CenterX2 = pt1.X + resize_start.Width; //오른쪽 정렬하기위한 x좌표

                Point_Array[0] = CenterX;
                Point_Array[1] = y1;   //start도형이 가지고 있어야 하는 0,1좌표

                arrowistrue = true;
            }

            for (int i = 0; i < allLines.Length; i++)//textarea의 문자의 줄 수만큼 반복(Length의 반대)   
            {
                Point pt = new Point(80, 10 * (6 * (i + 2)));//15*i 값 수정, 도형의 위치를 제대로 주기 위함

                if (arrowistrue == true)
                {
                    if (allLines[i].Contains("if"))//------------------------------마름모꼴
                    {
                        Console.WriteLine("if도형의 i: {0}", i);
                        //각각 decision도형마다 resize
                        if (filepath1.Contains("decision"))
                        {

                            decision_width = allLines[i + 1].Length * 20; // 나중에 제일 긴 width를 비교하기 위함
                            int decision_height = allLines[i + 1].Length + 30;
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

                            Console.WriteLine("CenterX:{0}", CenterX);

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

                            Point pt2_2 = new Point(CenterX2 - (resize_process2.Width / 2), y2 + 40);//두번째 도형을 그리는 가운데정렬 포인트, 그림그리기 위해선 포인트
                                                                                                   //값이 필요하므로 임시로 그림을 위한 좌표값이다.

                            Console.WriteLine("CenterX2 : {0}",CenterX2);

                            g.DrawImage(resize_process2, pt2_2);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX2 - (resize_process2.Width / 8), y2 + 45);

                            /*
                            Point_Array[2] = CenterX2;
                            Point_Array[3] = y2;//첫번째 도형에서 두번째 도형까지의 도착

                            
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기
                           

                            

                            Point_Array[0] = CenterX2;
                            Point_Array[1] = pt.Y + resize_decision2.Height;//두번째 도형에서의 시작
                            */
                            IFCurveArrow_Flat();
                            IFCurveArrow_Ancher();



                        }

                    }
                    //print문이 나오면 document도형 생성하기
                    else if (allLines[i].Contains("print"))//------------------------document도형
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


                            g.DrawImage(resize_document, pt3);//pt값을 적용
                                                              //g.DrawString(allLines[i + 1], Font, Brushes.Black, 70, i * 70);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_document.Width / 8), pt.Y);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt3.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기

                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt3.Y + resize_document.Height;

                            

                        }

                    }
                    else if (allLines[i].Contains("for"))//-----------------------------------card
                    {
                        if (filepath3.Contains("card"))
                        {

                            card_width = allLines[i + 1].Length * 20;
                            int card_height = allLines[i + 1].Length + 30;
                            dc_resize = new Size(card_width, card_height);
                            Bitmap resize_card = new Bitmap(card, dc_resize);

                            //card 그림을그리기위한 pt값을 줘서 
                            Point pt4 = new Point(CenterX - (resize_card.Width / 2), pt.Y);

                            g.DrawImage(resize_card, pt4);//pt값을 적용
                                                          //g.DrawString(allLines[i + 1], Font, Brushes.Black, 70, i * 70);
                            g.DrawString(allLines[i + 1], Font, Brushes.Black, CenterX - (resize_card.Width / 8), pt.Y);


                            Point_Array[2] = CenterX;
                            Point_Array[3] = pt4.Y;
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
                            Array.Clear(Point_Array, 0, 4);//배열 비우기

                            Point_Array[0] = CenterX;
                            Point_Array[1] = pt4.Y + resize_card.Height;

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
                            Arrow(Point_Array[2], Point_Array[3], Point_Array[0], Point_Array[1]);
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
                    else if(allLines[i].Contains("end"))//마지막 도형을 위치시킬 기준이 필요함... end도형 바로위의 도형이 무엇인지 구분하고 어떤 위치에 이미지가 그려졌는지 봐야됨
                   {
                        if (filepath6.Contains("end")) 
                        {
                            Point pt_F = new Point(100,400);//끝 도형을 그리기위한 포인트

                            
                            g.DrawImage(resize_end, pt_F);//끝도형
                            g.DrawString("종료", Font, Brushes.Black, pt_F.X + end_resize.Width / 3, pt_F.Y + end_resize.Height / 3);//위치조정필요 **필**


                        }// end 도형은 순서도 어느모양이든 마지막에 나와야만하는 도형이다
                   }

                }//arrowistrue가 true



            }//for문
            //Console.WriteLine("길이가 들어가는지 확인 : {0}", decision_width); 하면 길이가 들어간다(전역변수로 지정)
            /*int decision_width;
            int card_width;
            int document_width;
            int input_width;*/

            
            int high_width = 0;
            if (decision_width > card_width && decision_width>document_width && decision_width>input_width )
            {
                high_width = decision_width;
            }
            else if(card_width>decision_width && card_width>document_width && card_width > input_width)
            {
                high_width = card_width;
            }
            else if (document_width > decision_width && document_width > card_width && document_width > input_width)
            {
                high_width = document_width;
            }
            else if (input_width > decision_width && input_width > document_width && input_width > card_width)
            {
                high_width = input_width;
            }

            CenterX2 = high_width + CenterX;
            Console.WriteLine("두번째 Centerx2는 {0}", CenterX2);
            
            //CenterX2를 구했다. 구한 centerx2를 토대로 이미지 배치를 하면될듯... 성공
            //마지막에 하는 이유는 모든 도형들이 그려지고 나서 width길이 비교를 한 후 centerx2를 구하기 떄문에 마지막에 배치시킨다.
            //구한 centerx2를 가지고 이제 if문옆에 false로 들어가는 도형을 그려야한다.
            

        }
        /*public void CenterX2_method(int CenterX2)//매개변수//CenterX2를 구하기 위한 메소드
        {
            

        }*/

    }
}