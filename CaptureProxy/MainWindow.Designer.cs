namespace CaptureProxy
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOffsetX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOffsetY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericInterval = new System.Windows.Forms.NumericUpDown();
            this.checkDrawCursor = new System.Windows.Forms.CheckBox();
            this.checkShowFPS = new System.Windows.Forms.CheckBox();
            this.columnDrawCursor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInterval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnShowFPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnTitle,
            this.columnOffsetX,
            this.columnOffsetY,
            this.columnWidth,
            this.columnHeight,
            this.columnDrawCursor,
            this.columnInterval,
            this.columnShowFPS});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(277, 254);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Title";
            // 
            // columnOffsetX
            // 
            this.columnOffsetX.Text = "X";
            this.columnOffsetX.Width = 30;
            // 
            // columnOffsetY
            // 
            this.columnOffsetY.Text = "Y";
            this.columnOffsetY.Width = 30;
            // 
            // columnWidth
            // 
            this.columnWidth.Text = "W";
            this.columnWidth.Width = 30;
            // 
            // columnHeight
            // 
            this.columnHeight.Text = "H";
            this.columnHeight.Width = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkShowFPS);
            this.groupBox1.Controls.Add(this.checkDrawCursor);
            this.groupBox1.Controls.Add(this.numericInterval);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.textTitle);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericHeight);
            this.groupBox1.Controls.Add(this.numericWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericOffsetY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericOffsetX);
            this.groupBox1.Location = new System.Drawing.Point(295, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "キャプチャ設定";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(159, 222);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(49, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(8, 67);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(151, 19);
            this.textTitle.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "ウィンドウタイトル";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(8, 30);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(200, 19);
            this.textName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "設定名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Height";
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(165, 124);
            this.numericHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(43, 19);
            this.numericHeight.TabIndex = 6;
            this.numericHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericHeight.ValueChanged += new System.EventHandler(this.numericHeight_ValueChanged);
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(165, 99);
            this.numericWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(43, 19);
            this.numericWidth.TabIndex = 5;
            this.numericWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.numericWidth.ValueChanged += new System.EventHandler(this.numericWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Width";
            // 
            // numericOffsetY
            // 
            this.numericOffsetY.Location = new System.Drawing.Point(57, 124);
            this.numericOffsetY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericOffsetY.Name = "numericOffsetY";
            this.numericOffsetY.Size = new System.Drawing.Size(43, 19);
            this.numericOffsetY.TabIndex = 3;
            this.numericOffsetY.ValueChanged += new System.EventHandler(this.numericOffsetY_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "OffsetY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "OffsetX";
            // 
            // numericOffsetX
            // 
            this.numericOffsetX.Location = new System.Drawing.Point(57, 99);
            this.numericOffsetX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericOffsetX.Name = "numericOffsetX";
            this.numericOffsetX.Size = new System.Drawing.Size(43, 19);
            this.numericOffsetX.TabIndex = 0;
            this.numericOffsetX.ValueChanged += new System.EventHandler(this.numericOffsetX_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "描画間隔(ms)";
            // 
            // numericInterval
            // 
            this.numericInterval.Location = new System.Drawing.Point(165, 171);
            this.numericInterval.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericInterval.Name = "numericInterval";
            this.numericInterval.Size = new System.Drawing.Size(43, 19);
            this.numericInterval.TabIndex = 15;
            this.numericInterval.Value = new decimal(new int[] {
            33,
            0,
            0,
            0});
            this.numericInterval.ValueChanged += new System.EventHandler(this.numericInterval_ValueChanged);
            // 
            // checkDrawCursor
            // 
            this.checkDrawCursor.AutoSize = true;
            this.checkDrawCursor.Location = new System.Drawing.Point(8, 149);
            this.checkDrawCursor.Name = "checkDrawCursor";
            this.checkDrawCursor.Size = new System.Drawing.Size(128, 16);
            this.checkDrawCursor.TabIndex = 16;
            this.checkDrawCursor.Text = "マウスカーソルを含める";
            this.checkDrawCursor.UseVisualStyleBackColor = true;
            this.checkDrawCursor.CheckedChanged += new System.EventHandler(this.checkDrawCursor_CheckedChanged);
            // 
            // checkShowFPS
            // 
            this.checkShowFPS.AutoSize = true;
            this.checkShowFPS.Location = new System.Drawing.Point(6, 226);
            this.checkShowFPS.Name = "checkShowFPS";
            this.checkShowFPS.Size = new System.Drawing.Size(97, 16);
            this.checkShowFPS.TabIndex = 17;
            this.checkShowFPS.Text = "FPSを表示する";
            this.checkShowFPS.UseVisualStyleBackColor = true;
            this.checkShowFPS.CheckedChanged += new System.EventHandler(this.checkShowFPS_CheckedChanged);
            // 
            // columnDrawCursor
            // 
            this.columnDrawCursor.Text = "DrawCursor";
            this.columnDrawCursor.Width = 30;
            // 
            // columnInterval
            // 
            this.columnInterval.Text = "Interval";
            this.columnInterval.Width = 30;
            // 
            // columnShowFPS
            // 
            this.columnShowFPS.Text = "ShowFPS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "窓撮代理奴";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnOffsetX;
        private System.Windows.Forms.ColumnHeader columnOffsetY;
        private System.Windows.Forms.ColumnHeader columnWidth;
        private System.Windows.Forms.ColumnHeader columnHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericOffsetY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericOffsetX;
        internal System.Windows.Forms.ListView listView;
        private System.Windows.Forms.CheckBox checkDrawCursor;
        private System.Windows.Forms.NumericUpDown numericInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkShowFPS;
        private System.Windows.Forms.ColumnHeader columnDrawCursor;
        private System.Windows.Forms.ColumnHeader columnInterval;
        private System.Windows.Forms.ColumnHeader columnShowFPS;
        private System.Windows.Forms.Button button1;
    }
}

