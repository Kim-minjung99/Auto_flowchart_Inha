
namespace ex
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Screen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Change = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로만들기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다른이름으로저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.순서도변환ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.순서도저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.순서도크기조절ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x02ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x04ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x08ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용방법ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Screen
            // 
            this.btn_Screen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Screen.Location = new System.Drawing.Point(783, 658);
            this.btn_Screen.Name = "btn_Screen";
            this.btn_Screen.Size = new System.Drawing.Size(188, 46);
            this.btn_Screen.TabIndex = 0;
            this.btn_Screen.Text = "순서도 저장";
            this.btn_Screen.UseVisualStyleBackColor = true;
            this.btn_Screen.Click += new System.EventHandler(this.btn_Screen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(579, 649);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1";
            // 
            // btn_Change
            // 
            this.btn_Change.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Change.Location = new System.Drawing.Point(198, 658);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(188, 46);
            this.btn_Change.TabIndex = 3;
            this.btn_Change.Text = "순서도 변환";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.편집ToolStripMenuItem,
            this.순서도크기조절ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1170, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새로만들기ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.다른이름으로저장ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 새로만들기ToolStripMenuItem
            // 
            this.새로만들기ToolStripMenuItem.Name = "새로만들기ToolStripMenuItem";
            this.새로만들기ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.새로만들기ToolStripMenuItem.Text = "새로 만들기";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            // 
            // 다른이름으로저장ToolStripMenuItem
            // 
            this.다른이름으로저장ToolStripMenuItem.Name = "다른이름으로저장ToolStripMenuItem";
            this.다른이름으로저장ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.다른이름으로저장ToolStripMenuItem.Text = "다른 이름으로 저장";
            // 
            // 편집ToolStripMenuItem
            // 
            this.편집ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.순서도변환ToolStripMenuItem,
            this.순서도저장ToolStripMenuItem});
            this.편집ToolStripMenuItem.Name = "편집ToolStripMenuItem";
            this.편집ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.편집ToolStripMenuItem.Text = "편집";
            // 
            // 순서도변환ToolStripMenuItem
            // 
            this.순서도변환ToolStripMenuItem.Name = "순서도변환ToolStripMenuItem";
            this.순서도변환ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.순서도변환ToolStripMenuItem.Text = "순서도 변환";
            // 
            // 순서도저장ToolStripMenuItem
            // 
            this.순서도저장ToolStripMenuItem.Name = "순서도저장ToolStripMenuItem";
            this.순서도저장ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.순서도저장ToolStripMenuItem.Text = "순서도 저장";
            // 
            // 순서도크기조절ToolStripMenuItem
            // 
            this.순서도크기조절ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x01ToolStripMenuItem,
            this.x02ToolStripMenuItem,
            this.x04ToolStripMenuItem,
            this.x08ToolStripMenuItem,
            this.x1ToolStripMenuItem});
            this.순서도크기조절ToolStripMenuItem.Name = "순서도크기조절ToolStripMenuItem";
            this.순서도크기조절ToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.순서도크기조절ToolStripMenuItem.Text = "순서도 크기 조절";
            // 
            // x01ToolStripMenuItem
            // 
            this.x01ToolStripMenuItem.Name = "x01ToolStripMenuItem";
            this.x01ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x01ToolStripMenuItem.Text = "x 0.1";
            // 
            // x02ToolStripMenuItem
            // 
            this.x02ToolStripMenuItem.Name = "x02ToolStripMenuItem";
            this.x02ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x02ToolStripMenuItem.Text = "x 0.2";
            // 
            // x04ToolStripMenuItem
            // 
            this.x04ToolStripMenuItem.Name = "x04ToolStripMenuItem";
            this.x04ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x04ToolStripMenuItem.Text = "x 0.4";
            // 
            // x08ToolStripMenuItem
            // 
            this.x08ToolStripMenuItem.Name = "x08ToolStripMenuItem";
            this.x08ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x08ToolStripMenuItem.Text = "x 0.8";
            // 
            // x1ToolStripMenuItem
            // 
            this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            this.x1ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x1ToolStripMenuItem.Text = "x 1";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.사용방법ToolStripMenuItem});
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // 사용방법ToolStripMenuItem
            // 
            this.사용방법ToolStripMenuItem.Name = "사용방법ToolStripMenuItem";
            this.사용방법ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.사용방법ToolStripMenuItem.Text = "사용 방법";
            // 
            // scaleComboBox
            // 
            this.scaleComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scaleComboBox.FormattingEnabled = true;
            this.scaleComboBox.Items.AddRange(new object[] {
            "x 0.1",
            "x 0.2",
            "x 0.4",
            "x 0.6",
            "x 0.8",
            "x 1"});
            this.scaleComboBox.Location = new System.Drawing.Point(232, 721);
            this.scaleComboBox.Name = "scaleComboBox";
            this.scaleComboBox.Size = new System.Drawing.Size(121, 20);
            this.scaleComboBox.TabIndex = 7;
            this.scaleComboBox.SelectedIndexChanged += new System.EventHandler(this.scaleComboBox_SelectedIndexChanged_1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(100, 100);
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(588, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 649);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(518, 581);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.scaleComboBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_Screen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Change, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1170, 755);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1170, 779);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "q";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Screen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로만들기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다른이름으로저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 순서도변환ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 순서도저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용방법ToolStripMenuItem;
        private System.Windows.Forms.ComboBox scaleComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem 순서도크기조절ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x02ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x04ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x08ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x1ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

