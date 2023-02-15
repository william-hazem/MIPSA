namespace MIPS_Assembler
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
            this.rtbMIPS = new System.Windows.Forms.RichTextBox();
            this.rtbCodigoMaquina = new System.Windows.Forms.RichTextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_sep = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirmifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.converterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDoMifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LnBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox_convert = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog_mif = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_convert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMIPS
            // 
            this.rtbMIPS.AcceptsTab = true;
            this.rtbMIPS.AccessibleDescription = "Área de texto legível por humanos escrito em linguagem assembly";
            this.rtbMIPS.AccessibleName = "Caixa de texto assembly";
            this.rtbMIPS.DetectUrls = false;
            this.rtbMIPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMIPS.Location = new System.Drawing.Point(57, 5);
            this.rtbMIPS.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMIPS.Name = "rtbMIPS";
            this.rtbMIPS.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbMIPS.Size = new System.Drawing.Size(494, 682);
            this.rtbMIPS.TabIndex = 0;
            this.rtbMIPS.Text = resources.GetString("rtbMIPS.Text");
            this.rtbMIPS.VScroll += new System.EventHandler(this.LnBox_VScroll);
            this.rtbMIPS.TextChanged += new System.EventHandler(this.rtb_MIPS_TextChanged);
            this.rtbMIPS.Layout += new System.Windows.Forms.LayoutEventHandler(this.rtbMIPS_Layout);
            // 
            // rtbCodigoMaquina
            // 
            this.rtbCodigoMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCodigoMaquina.Location = new System.Drawing.Point(559, 4);
            this.rtbCodigoMaquina.Margin = new System.Windows.Forms.Padding(4);
            this.rtbCodigoMaquina.Name = "rtbCodigoMaquina";
            this.rtbCodigoMaquina.ReadOnly = true;
            this.rtbCodigoMaquina.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbCodigoMaquina.Size = new System.Drawing.Size(362, 683);
            this.rtbCodigoMaquina.TabIndex = 1;
            this.rtbCodigoMaquina.Text = "";
            // 
            // textBox_Status
            // 
            this.textBox_Status.Location = new System.Drawing.Point(606, 771);
            this.textBox_Status.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(331, 22);
            this.textBox_Status.TabIndex = 3;
            this.textBox_Status.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Assembly MIPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Código de Máquina";
            // 
            // checkBox_sep
            // 
            this.checkBox_sep.AutoSize = true;
            this.checkBox_sep.Location = new System.Drawing.Point(840, 44);
            this.checkBox_sep.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_sep.Name = "checkBox_sep";
            this.checkBox_sep.Size = new System.Drawing.Size(36, 20);
            this.checkBox_sep.TabIndex = 6;
            this.checkBox_sep.Text = "_";
            this.checkBox_sep.UseVisualStyleBackColor = true;
            this.checkBox_sep.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(949, 30);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirmifToolStripMenuItem,
            this.converterToolStripMenuItem,
            this.configuraçõesDoMifToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirmifToolStripMenuItem
            // 
            this.abrirmifToolStripMenuItem.Name = "abrirmifToolStripMenuItem";
            this.abrirmifToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.abrirmifToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.abrirmifToolStripMenuItem.Text = "Abrir";
            this.abrirmifToolStripMenuItem.Click += new System.EventHandler(this.abrirmifToolStripMenuItem_Click);
            // 
            // converterToolStripMenuItem
            // 
            this.converterToolStripMenuItem.Name = "converterToolStripMenuItem";
            this.converterToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.converterToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.converterToolStripMenuItem.Text = "Converter";
            this.converterToolStripMenuItem.Click += new System.EventHandler(this.converterToolStripMenuItem_Click);
            // 
            // configuraçõesDoMifToolStripMenuItem
            // 
            this.configuraçõesDoMifToolStripMenuItem.Name = "configuraçõesDoMifToolStripMenuItem";
            this.configuraçõesDoMifToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.configuraçõesDoMifToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.configuraçõesDoMifToolStripMenuItem.Text = "Configurações ";
            this.configuraçõesDoMifToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesDoMifToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // LnBox
            // 
            this.LnBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LnBox.Enabled = false;
            this.LnBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnBox.Location = new System.Drawing.Point(5, 4);
            this.LnBox.Margin = new System.Windows.Forms.Padding(4);
            this.LnBox.Name = "LnBox";
            this.LnBox.ReadOnly = true;
            this.LnBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LnBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LnBox.Size = new System.Drawing.Size(44, 683);
            this.LnBox.TabIndex = 8;
            this.LnBox.Text = "00\n01\n02\n03\n04\n05\n06\n07\n08\n09";
            // 
            // pictureBox_convert
            // 
            this.pictureBox_convert.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_convert.Image = global::MIPS_Assembler.Properties.Resources.refresh_icon_8;
            this.pictureBox_convert.Location = new System.Drawing.Point(884, 36);
            this.pictureBox_convert.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_convert.Name = "pictureBox_convert";
            this.pictureBox_convert.Size = new System.Drawing.Size(26, 28);
            this.pictureBox_convert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_convert.TabIndex = 15;
            this.pictureBox_convert.TabStop = false;
            this.pictureBox_convert.Click += new System.EventHandler(this.converterToolStripMenuItem_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MIPS_Assembler.Properties.Resources.download__1_;
            this.pictureBox3.Location = new System.Drawing.Point(292, 762);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MIPS_Assembler.Properties.Resources.UFCG_lateral;
            this.pictureBox2.Location = new System.Drawing.Point(132, 762);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MIPS_Assembler.Properties.Resources.rafael_logo_retangulo;
            this.pictureBox1.Location = new System.Drawing.Point(17, 762);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog_mif
            // 
            this.openFileDialog_mif.FileName = "openFileDialog1";
            this.openFileDialog_mif.Filter = "MIF (*.mif)|*.mif";
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.rtbMIPS);
            this.panel1.Controls.Add(this.LnBox);
            this.panel1.Controls.Add(this.rtbCodigoMaquina);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 693);
            this.panel1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 806);
            this.Controls.Add(this.pictureBox_convert);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox_sep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MIPS Assembler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_convert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMIPS;
        private System.Windows.Forms.RichTextBox rtbCodigoMaquina;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_sep;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox LnBox;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDoMifToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem converterToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox_convert;
        private System.Windows.Forms.ToolStripMenuItem abrirmifToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog_mif;
        private System.Windows.Forms.Panel panel1;
    }
}

