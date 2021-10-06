namespace Visualizador3D
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btAbrir = new System.Windows.Forms.Button();
            this.pbPrincipal = new System.Windows.Forms.PictureBox();
            this.tcPrincipal = new System.Windows.Forms.TabControl();
            this.tpIeC = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sbCAmbG = new System.Windows.Forms.HScrollBar();
            this.sbCAmbB = new System.Windows.Forms.HScrollBar();
            this.sbCAmbR = new System.Windows.Forms.HScrollBar();
            this.sbCMatG = new System.Windows.Forms.HScrollBar();
            this.sbCMatB = new System.Windows.Forms.HScrollBar();
            this.sbCMatR = new System.Windows.Forms.HScrollBar();
            this.sbCBrilhoG = new System.Windows.Forms.HScrollBar();
            this.sbCBrilhoB = new System.Windows.Forms.HScrollBar();
            this.sbCBrilhoR = new System.Windows.Forms.HScrollBar();
            this.lbCBrilho = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbCMat = new System.Windows.Forms.Label();
            this.lbCAmb = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sbIAmbG = new System.Windows.Forms.HScrollBar();
            this.sbIAmbB = new System.Windows.Forms.HScrollBar();
            this.sbIAmbR = new System.Windows.Forms.HScrollBar();
            this.sbIMatG = new System.Windows.Forms.HScrollBar();
            this.sbIMatB = new System.Windows.Forms.HScrollBar();
            this.sbIMatR = new System.Windows.Forms.HScrollBar();
            this.sbIBrilhoG = new System.Windows.Forms.HScrollBar();
            this.sbIBrilhoB = new System.Windows.Forms.HScrollBar();
            this.sbIBrilhoR = new System.Windows.Forms.HScrollBar();
            this.lbIBrilho = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbIMat = new System.Windows.Forms.Label();
            this.lbIAmb = new System.Windows.Forms.Label();
            this.tpCol = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProjecao = new System.Windows.Forms.ComboBox();
            this.labelPerspectiva = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.ckFacesOcultas = new System.Windows.Forms.CheckBox();
            this.rbPhong = new System.Windows.Forms.RadioButton();
            this.rbGouraud = new System.Windows.Forms.RadioButton();
            this.txN = new System.Windows.Forms.NumericUpDown();
            this.rbFlat = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbWireframe = new System.Windows.Forms.RadioButton();
            this.tpVistas = new System.Windows.Forms.TabPage();
            this.pbLateral = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPlanta = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFrontal = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btLuz = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrincipal)).BeginInit();
            this.tcPrincipal.SuspendLayout();
            this.tpIeC.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpCol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txN)).BeginInit();
            this.tpVistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrontal)).BeginInit();
            this.SuspendLayout();
            // 
            // btAbrir
            // 
            this.btAbrir.BackColor = System.Drawing.Color.LightGray;
            this.btAbrir.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btAbrir.FlatAppearance.BorderSize = 0;
            this.btAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAbrir.ForeColor = System.Drawing.Color.Black;
            this.btAbrir.Location = new System.Drawing.Point(0, 0);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(97, 26);
            this.btAbrir.TabIndex = 2;
            this.btAbrir.Text = "Abrir Arquivo";
            this.btAbrir.UseVisualStyleBackColor = false;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // pbPrincipal
            // 
            this.pbPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrincipal.Location = new System.Drawing.Point(0, 24);
            this.pbPrincipal.Margin = new System.Windows.Forms.Padding(3, 3, 608, 3);
            this.pbPrincipal.Name = "pbPrincipal";
            this.pbPrincipal.Size = new System.Drawing.Size(1273, 610);
            this.pbPrincipal.TabIndex = 0;
            this.pbPrincipal.TabStop = false;
            this.pbPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPrincipal_MouseDown);
            this.pbPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPrincipal_MouseMove);
            // 
            // tcPrincipal
            // 
            this.tcPrincipal.Controls.Add(this.tpIeC);
            this.tcPrincipal.Controls.Add(this.tpCol);
            this.tcPrincipal.Controls.Add(this.tpVistas);
            this.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcPrincipal.Location = new System.Drawing.Point(808, 24);
            this.tcPrincipal.Name = "tcPrincipal";
            this.tcPrincipal.SelectedIndex = 0;
            this.tcPrincipal.Size = new System.Drawing.Size(465, 610);
            this.tcPrincipal.TabIndex = 3;
            // 
            // tpIeC
            // 
            this.tpIeC.BackColor = System.Drawing.Color.LightGray;
            this.tpIeC.Controls.Add(this.groupBox4);
            this.tpIeC.Controls.Add(this.groupBox2);
            this.tpIeC.Location = new System.Drawing.Point(4, 22);
            this.tpIeC.Name = "tpIeC";
            this.tpIeC.Padding = new System.Windows.Forms.Padding(3);
            this.tpIeC.Size = new System.Drawing.Size(457, 584);
            this.tpIeC.TabIndex = 0;
            this.tpIeC.Text = "Intensidade e Cor";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sbCAmbG);
            this.groupBox4.Controls.Add(this.sbCAmbB);
            this.groupBox4.Controls.Add(this.sbCAmbR);
            this.groupBox4.Controls.Add(this.sbCMatG);
            this.groupBox4.Controls.Add(this.sbCMatB);
            this.groupBox4.Controls.Add(this.sbCMatR);
            this.groupBox4.Controls.Add(this.sbCBrilhoG);
            this.groupBox4.Controls.Add(this.sbCBrilhoB);
            this.groupBox4.Controls.Add(this.sbCBrilhoR);
            this.groupBox4.Controls.Add(this.lbCBrilho);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lbCMat);
            this.groupBox4.Controls.Add(this.lbCAmb);
            this.groupBox4.Location = new System.Drawing.Point(7, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 104);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cor";
            // 
            // sbCAmbG
            // 
            this.sbCAmbG.Location = new System.Drawing.Point(22, 61);
            this.sbCAmbG.Name = "sbCAmbG";
            this.sbCAmbG.Size = new System.Drawing.Size(135, 15);
            this.sbCAmbG.TabIndex = 33;
            this.sbCAmbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCAmbG_Scroll);
            // 
            // sbCAmbB
            // 
            this.sbCAmbB.Location = new System.Drawing.Point(21, 82);
            this.sbCAmbB.Name = "sbCAmbB";
            this.sbCAmbB.Size = new System.Drawing.Size(135, 15);
            this.sbCAmbB.TabIndex = 32;
            this.sbCAmbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCAmbB_Scroll);
            // 
            // sbCAmbR
            // 
            this.sbCAmbR.Location = new System.Drawing.Point(22, 39);
            this.sbCAmbR.Name = "sbCAmbR";
            this.sbCAmbR.Size = new System.Drawing.Size(135, 15);
            this.sbCAmbR.TabIndex = 31;
            this.sbCAmbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCAmbR_Scroll);
            // 
            // sbCMatG
            // 
            this.sbCMatG.Location = new System.Drawing.Point(161, 61);
            this.sbCMatG.Name = "sbCMatG";
            this.sbCMatG.Size = new System.Drawing.Size(135, 15);
            this.sbCMatG.TabIndex = 30;
            this.sbCMatG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCMatG_Scroll);
            // 
            // sbCMatB
            // 
            this.sbCMatB.Location = new System.Drawing.Point(161, 82);
            this.sbCMatB.Name = "sbCMatB";
            this.sbCMatB.Size = new System.Drawing.Size(135, 15);
            this.sbCMatB.TabIndex = 29;
            this.sbCMatB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCMatB_Scroll);
            // 
            // sbCMatR
            // 
            this.sbCMatR.Location = new System.Drawing.Point(161, 39);
            this.sbCMatR.Name = "sbCMatR";
            this.sbCMatR.Size = new System.Drawing.Size(135, 15);
            this.sbCMatR.TabIndex = 28;
            this.sbCMatR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCMatR_Scroll);
            // 
            // sbCBrilhoG
            // 
            this.sbCBrilhoG.Location = new System.Drawing.Point(300, 61);
            this.sbCBrilhoG.Name = "sbCBrilhoG";
            this.sbCBrilhoG.Size = new System.Drawing.Size(135, 15);
            this.sbCBrilhoG.TabIndex = 27;
            this.sbCBrilhoG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCBrilhoG_Scroll);
            // 
            // sbCBrilhoB
            // 
            this.sbCBrilhoB.Location = new System.Drawing.Point(300, 82);
            this.sbCBrilhoB.Name = "sbCBrilhoB";
            this.sbCBrilhoB.Size = new System.Drawing.Size(135, 15);
            this.sbCBrilhoB.TabIndex = 26;
            this.sbCBrilhoB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCBrilhoB_Scroll);
            // 
            // sbCBrilhoR
            // 
            this.sbCBrilhoR.Location = new System.Drawing.Point(300, 39);
            this.sbCBrilhoR.Name = "sbCBrilhoR";
            this.sbCBrilhoR.Size = new System.Drawing.Size(135, 15);
            this.sbCBrilhoR.TabIndex = 25;
            this.sbCBrilhoR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbCBrilhoR_Scroll);
            // 
            // lbCBrilho
            // 
            this.lbCBrilho.AutoSize = true;
            this.lbCBrilho.BackColor = System.Drawing.Color.Black;
            this.lbCBrilho.ForeColor = System.Drawing.Color.White;
            this.lbCBrilho.Location = new System.Drawing.Point(355, 22);
            this.lbCBrilho.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCBrilho.Name = "lbCBrilho";
            this.lbCBrilho.Size = new System.Drawing.Size(36, 13);
            this.lbCBrilho.TabIndex = 17;
            this.lbCBrilho.Text = "Brilho:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "B";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "G";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "R";
            // 
            // lbCMat
            // 
            this.lbCMat.AutoSize = true;
            this.lbCMat.BackColor = System.Drawing.Color.Black;
            this.lbCMat.ForeColor = System.Drawing.Color.White;
            this.lbCMat.Location = new System.Drawing.Point(210, 22);
            this.lbCMat.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCMat.Name = "lbCMat";
            this.lbCMat.Size = new System.Drawing.Size(47, 13);
            this.lbCMat.TabIndex = 10;
            this.lbCMat.Text = "Material:";
            // 
            // lbCAmb
            // 
            this.lbCAmb.AutoSize = true;
            this.lbCAmb.BackColor = System.Drawing.Color.Black;
            this.lbCAmb.ForeColor = System.Drawing.Color.White;
            this.lbCAmb.Location = new System.Drawing.Point(67, 22);
            this.lbCAmb.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCAmb.Name = "lbCAmb";
            this.lbCAmb.Size = new System.Drawing.Size(54, 13);
            this.lbCAmb.TabIndex = 3;
            this.lbCAmb.Text = "Ambiente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sbIAmbG);
            this.groupBox2.Controls.Add(this.sbIAmbB);
            this.groupBox2.Controls.Add(this.sbIAmbR);
            this.groupBox2.Controls.Add(this.sbIMatG);
            this.groupBox2.Controls.Add(this.sbIMatB);
            this.groupBox2.Controls.Add(this.sbIMatR);
            this.groupBox2.Controls.Add(this.sbIBrilhoG);
            this.groupBox2.Controls.Add(this.sbIBrilhoB);
            this.groupBox2.Controls.Add(this.sbIBrilhoR);
            this.groupBox2.Controls.Add(this.lbIBrilho);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbIMat);
            this.groupBox2.Controls.Add(this.lbIAmb);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 107);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Intensidade";
            // 
            // sbIAmbG
            // 
            this.sbIAmbG.Location = new System.Drawing.Point(21, 61);
            this.sbIAmbG.Name = "sbIAmbG";
            this.sbIAmbG.Size = new System.Drawing.Size(135, 15);
            this.sbIAmbG.TabIndex = 33;
            this.sbIAmbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIAmbG_Scroll);
            // 
            // sbIAmbB
            // 
            this.sbIAmbB.Location = new System.Drawing.Point(21, 82);
            this.sbIAmbB.Name = "sbIAmbB";
            this.sbIAmbB.Size = new System.Drawing.Size(135, 15);
            this.sbIAmbB.TabIndex = 32;
            this.sbIAmbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIAmbB_Scroll);
            // 
            // sbIAmbR
            // 
            this.sbIAmbR.Location = new System.Drawing.Point(21, 39);
            this.sbIAmbR.Name = "sbIAmbR";
            this.sbIAmbR.Size = new System.Drawing.Size(135, 15);
            this.sbIAmbR.TabIndex = 31;
            this.sbIAmbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIAmbR_Scroll);
            // 
            // sbIMatG
            // 
            this.sbIMatG.Location = new System.Drawing.Point(165, 61);
            this.sbIMatG.Name = "sbIMatG";
            this.sbIMatG.Size = new System.Drawing.Size(135, 15);
            this.sbIMatG.TabIndex = 30;
            this.sbIMatG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIMatG_Scroll);
            // 
            // sbIMatB
            // 
            this.sbIMatB.Location = new System.Drawing.Point(165, 82);
            this.sbIMatB.Name = "sbIMatB";
            this.sbIMatB.Size = new System.Drawing.Size(135, 15);
            this.sbIMatB.TabIndex = 29;
            this.sbIMatB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIMatB_Scroll);
            // 
            // sbIMatR
            // 
            this.sbIMatR.Location = new System.Drawing.Point(165, 39);
            this.sbIMatR.Name = "sbIMatR";
            this.sbIMatR.Size = new System.Drawing.Size(135, 15);
            this.sbIMatR.TabIndex = 28;
            this.sbIMatR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIMatR_Scroll);
            // 
            // sbIBrilhoG
            // 
            this.sbIBrilhoG.Location = new System.Drawing.Point(307, 61);
            this.sbIBrilhoG.Name = "sbIBrilhoG";
            this.sbIBrilhoG.Size = new System.Drawing.Size(135, 15);
            this.sbIBrilhoG.TabIndex = 27;
            this.sbIBrilhoG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIBrilhoG_Scroll);
            // 
            // sbIBrilhoB
            // 
            this.sbIBrilhoB.Location = new System.Drawing.Point(307, 82);
            this.sbIBrilhoB.Name = "sbIBrilhoB";
            this.sbIBrilhoB.Size = new System.Drawing.Size(135, 15);
            this.sbIBrilhoB.TabIndex = 26;
            this.sbIBrilhoB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIBrilhoB_Scroll);
            // 
            // sbIBrilhoR
            // 
            this.sbIBrilhoR.Location = new System.Drawing.Point(307, 39);
            this.sbIBrilhoR.Name = "sbIBrilhoR";
            this.sbIBrilhoR.Size = new System.Drawing.Size(135, 15);
            this.sbIBrilhoR.TabIndex = 25;
            this.sbIBrilhoR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbIBrilhoR_Scroll);
            // 
            // lbIBrilho
            // 
            this.lbIBrilho.AutoSize = true;
            this.lbIBrilho.BackColor = System.Drawing.Color.Black;
            this.lbIBrilho.ForeColor = System.Drawing.Color.White;
            this.lbIBrilho.Location = new System.Drawing.Point(354, 22);
            this.lbIBrilho.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIBrilho.Name = "lbIBrilho";
            this.lbIBrilho.Size = new System.Drawing.Size(36, 13);
            this.lbIBrilho.TabIndex = 17;
            this.lbIBrilho.Text = "Brilho:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "G";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "R";
            // 
            // lbIMat
            // 
            this.lbIMat.AutoSize = true;
            this.lbIMat.BackColor = System.Drawing.Color.Black;
            this.lbIMat.ForeColor = System.Drawing.Color.White;
            this.lbIMat.Location = new System.Drawing.Point(211, 22);
            this.lbIMat.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIMat.Name = "lbIMat";
            this.lbIMat.Size = new System.Drawing.Size(47, 13);
            this.lbIMat.TabIndex = 10;
            this.lbIMat.Text = "Material:";
            // 
            // lbIAmb
            // 
            this.lbIAmb.AutoSize = true;
            this.lbIAmb.BackColor = System.Drawing.Color.Black;
            this.lbIAmb.ForeColor = System.Drawing.Color.White;
            this.lbIAmb.Location = new System.Drawing.Point(44, 22);
            this.lbIAmb.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIAmb.Name = "lbIAmb";
            this.lbIAmb.Size = new System.Drawing.Size(54, 13);
            this.lbIAmb.TabIndex = 3;
            this.lbIAmb.Text = "Ambiente:";
            // 
            // tpCol
            // 
            this.tpCol.BackColor = System.Drawing.Color.LightGray;
            this.tpCol.Controls.Add(this.groupBox1);
            this.tpCol.Controls.Add(this.ckFacesOcultas);
            this.tpCol.Controls.Add(this.rbPhong);
            this.tpCol.Controls.Add(this.rbGouraud);
            this.tpCol.Controls.Add(this.txN);
            this.tpCol.Controls.Add(this.rbFlat);
            this.tpCol.Controls.Add(this.label4);
            this.tpCol.Controls.Add(this.rbWireframe);
            this.tpCol.Location = new System.Drawing.Point(4, 22);
            this.tpCol.Name = "tpCol";
            this.tpCol.Padding = new System.Windows.Forms.Padding(3);
            this.tpCol.Size = new System.Drawing.Size(457, 608);
            this.tpCol.TabIndex = 1;
            this.tpCol.Text = "Coloração e Projeção";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProjecao);
            this.groupBox1.Controls.Add(this.labelPerspectiva);
            this.groupBox1.Controls.Add(this.tbD);
            this.groupBox1.Location = new System.Drawing.Point(9, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 59);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projeções";
            // 
            // cbProjecao
            // 
            this.cbProjecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjecao.FormattingEnabled = true;
            this.cbProjecao.Items.AddRange(new object[] {
            "Paralela",
            "Cabinet",
            "Cavaleira",
            "Perspectiva"});
            this.cbProjecao.Location = new System.Drawing.Point(6, 19);
            this.cbProjecao.Name = "cbProjecao";
            this.cbProjecao.Size = new System.Drawing.Size(169, 21);
            this.cbProjecao.TabIndex = 0;
            this.cbProjecao.SelectedIndexChanged += new System.EventHandler(this.cbProjecao_SelectedIndexChanged_1);
            // 
            // labelPerspectiva
            // 
            this.labelPerspectiva.AutoSize = true;
            this.labelPerspectiva.Location = new System.Drawing.Point(191, 22);
            this.labelPerspectiva.Name = "labelPerspectiva";
            this.labelPerspectiva.Size = new System.Drawing.Size(25, 13);
            this.labelPerspectiva.TabIndex = 1;
            this.labelPerspectiva.Text = "d = ";
            // 
            // tbD
            // 
            this.tbD.Enabled = false;
            this.tbD.Location = new System.Drawing.Point(222, 20);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(43, 20);
            this.tbD.TabIndex = 2;
            this.tbD.Text = "-500";
            this.tbD.TextChanged += new System.EventHandler(this.tbD_TextChanged);
            // 
            // ckFacesOcultas
            // 
            this.ckFacesOcultas.AutoSize = true;
            this.ckFacesOcultas.Checked = true;
            this.ckFacesOcultas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFacesOcultas.Location = new System.Drawing.Point(203, 47);
            this.ckFacesOcultas.Name = "ckFacesOcultas";
            this.ckFacesOcultas.Size = new System.Drawing.Size(90, 17);
            this.ckFacesOcultas.TabIndex = 10;
            this.ckFacesOcultas.Text = "Rm F Ocultas";
            this.ckFacesOcultas.UseVisualStyleBackColor = true;
            this.ckFacesOcultas.CheckedChanged += new System.EventHandler(this.ckFacesOcultas_CheckedChanged);
            // 
            // rbPhong
            // 
            this.rbPhong.AutoSize = true;
            this.rbPhong.Location = new System.Drawing.Point(395, 6);
            this.rbPhong.Name = "rbPhong";
            this.rbPhong.Size = new System.Drawing.Size(56, 17);
            this.rbPhong.TabIndex = 16;
            this.rbPhong.TabStop = true;
            this.rbPhong.Text = "Phong";
            this.rbPhong.UseVisualStyleBackColor = true;
            this.rbPhong.CheckedChanged += new System.EventHandler(this.rbPhong_CheckedChanged);
            // 
            // rbGouraud
            // 
            this.rbGouraud.AutoSize = true;
            this.rbGouraud.Location = new System.Drawing.Point(256, 6);
            this.rbGouraud.Name = "rbGouraud";
            this.rbGouraud.Size = new System.Drawing.Size(66, 17);
            this.rbGouraud.TabIndex = 15;
            this.rbGouraud.TabStop = true;
            this.rbGouraud.Text = "Gouraud";
            this.rbGouraud.UseVisualStyleBackColor = true;
            this.rbGouraud.CheckedChanged += new System.EventHandler(this.rbGouraud_CheckedChanged);
            // 
            // txN
            // 
            this.txN.Location = new System.Drawing.Point(136, 45);
            this.txN.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txN.Name = "txN";
            this.txN.Size = new System.Drawing.Size(61, 20);
            this.txN.TabIndex = 12;
            this.txN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txN.ValueChanged += new System.EventHandler(this.txN_ValueChanged);
            // 
            // rbFlat
            // 
            this.rbFlat.AutoSize = true;
            this.rbFlat.Location = new System.Drawing.Point(142, 6);
            this.rbFlat.Name = "rbFlat";
            this.rbFlat.Size = new System.Drawing.Size(42, 17);
            this.rbFlat.TabIndex = 14;
            this.rbFlat.TabStop = true;
            this.rbFlat.Text = "Flat";
            this.rbFlat.UseVisualStyleBackColor = true;
            this.rbFlat.CheckedChanged += new System.EventHandler(this.rbFlat_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Grau de Especularidade:";
            // 
            // rbWireframe
            // 
            this.rbWireframe.AutoSize = true;
            this.rbWireframe.Checked = true;
            this.rbWireframe.Location = new System.Drawing.Point(6, 6);
            this.rbWireframe.Name = "rbWireframe";
            this.rbWireframe.Size = new System.Drawing.Size(73, 17);
            this.rbWireframe.TabIndex = 13;
            this.rbWireframe.TabStop = true;
            this.rbWireframe.Text = "Wireframe";
            this.rbWireframe.UseVisualStyleBackColor = true;
            this.rbWireframe.CheckedChanged += new System.EventHandler(this.rbWireframe_CheckedChanged);
            // 
            // tpVistas
            // 
            this.tpVistas.BackColor = System.Drawing.Color.LightGray;
            this.tpVistas.Controls.Add(this.pbLateral);
            this.tpVistas.Controls.Add(this.label3);
            this.tpVistas.Controls.Add(this.pbPlanta);
            this.tpVistas.Controls.Add(this.label1);
            this.tpVistas.Controls.Add(this.pbFrontal);
            this.tpVistas.Controls.Add(this.label2);
            this.tpVistas.Location = new System.Drawing.Point(4, 22);
            this.tpVistas.Name = "tpVistas";
            this.tpVistas.Padding = new System.Windows.Forms.Padding(3);
            this.tpVistas.Size = new System.Drawing.Size(457, 608);
            this.tpVistas.TabIndex = 2;
            this.tpVistas.Text = "Vistas";
            // 
            // pbLateral
            // 
            this.pbLateral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLateral.Location = new System.Drawing.Point(42, 391);
            this.pbLateral.Name = "pbLateral";
            this.pbLateral.Size = new System.Drawing.Size(412, 195);
            this.pbLateral.TabIndex = 9;
            this.pbLateral.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lateral";
            // 
            // pbPlanta
            // 
            this.pbPlanta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbPlanta.Location = new System.Drawing.Point(42, 197);
            this.pbPlanta.Name = "pbPlanta";
            this.pbPlanta.Size = new System.Drawing.Size(412, 194);
            this.pbPlanta.TabIndex = 7;
            this.pbPlanta.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Planta";
            // 
            // pbFrontal
            // 
            this.pbFrontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbFrontal.Location = new System.Drawing.Point(42, 3);
            this.pbFrontal.Name = "pbFrontal";
            this.pbFrontal.Size = new System.Drawing.Size(412, 194);
            this.pbFrontal.TabIndex = 5;
            this.pbFrontal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Frontal";
            // 
            // btLuz
            // 
            this.btLuz.BackColor = System.Drawing.Color.White;
            this.btLuz.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLuz.BackgroundImage")));
            this.btLuz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btLuz.FlatAppearance.BorderSize = 0;
            this.btLuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuz.Location = new System.Drawing.Point(30, 62);
            this.btLuz.Name = "btLuz";
            this.btLuz.Size = new System.Drawing.Size(41, 36);
            this.btLuz.TabIndex = 45;
            this.btLuz.UseVisualStyleBackColor = false;
            this.btLuz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseDown);
            this.btLuz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseMove);
            this.btLuz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Lucas Ribeiro Silva";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1273, 634);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btLuz);
            this.Controls.Add(this.tcPrincipal);
            this.Controls.Add(this.btAbrir);
            this.Controls.Add(this.pbPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Visualizador 3D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrincipal)).EndInit();
            this.tcPrincipal.ResumeLayout(false);
            this.tpIeC.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpCol.ResumeLayout(false);
            this.tpCol.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txN)).EndInit();
            this.tpVistas.ResumeLayout(false);
            this.tpVistas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrontal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPrincipal;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.TabControl tcPrincipal;
        private System.Windows.Forms.TabPage tpIeC;
        private System.Windows.Forms.TabPage tpCol;
        private System.Windows.Forms.TabPage tpVistas;
        public System.Windows.Forms.PictureBox pbPlanta;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pbFrontal;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pbLateral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckFacesOcultas;
        private System.Windows.Forms.RadioButton rbPhong;
        private System.Windows.Forms.RadioButton rbGouraud;
        private System.Windows.Forms.NumericUpDown txN;
        private System.Windows.Forms.RadioButton rbFlat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbWireframe;
        private System.Windows.Forms.Button btLuz;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar sbIAmbG;
        private System.Windows.Forms.HScrollBar sbIAmbB;
        private System.Windows.Forms.HScrollBar sbIAmbR;
        private System.Windows.Forms.HScrollBar sbIMatG;
        private System.Windows.Forms.HScrollBar sbIMatB;
        private System.Windows.Forms.HScrollBar sbIMatR;
        private System.Windows.Forms.HScrollBar sbIBrilhoG;
        private System.Windows.Forms.HScrollBar sbIBrilhoB;
        private System.Windows.Forms.HScrollBar sbIBrilhoR;
        private System.Windows.Forms.Label lbIBrilho;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbIMat;
        private System.Windows.Forms.Label lbIAmb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.HScrollBar sbCAmbG;
        private System.Windows.Forms.HScrollBar sbCAmbB;
        private System.Windows.Forms.HScrollBar sbCAmbR;
        private System.Windows.Forms.HScrollBar sbCMatG;
        private System.Windows.Forms.HScrollBar sbCMatB;
        private System.Windows.Forms.HScrollBar sbCMatR;
        private System.Windows.Forms.HScrollBar sbCBrilhoG;
        private System.Windows.Forms.HScrollBar sbCBrilhoB;
        private System.Windows.Forms.HScrollBar sbCBrilhoR;
        private System.Windows.Forms.Label lbCBrilho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbCMat;
        private System.Windows.Forms.Label lbCAmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

