namespace NEW_MVP
{
    partial class FormInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonInquiry = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxExcludeLoan = new System.Windows.Forms.CheckBox();
            this.checkBoxExcludePMNT = new System.Windows.Forms.CheckBox();
            this.labelCnt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "다음 문자열을 포함";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 21);
            this.textBox1.TabIndex = 1;
            // 
            // buttonInquiry
            // 
            this.buttonInquiry.Location = new System.Drawing.Point(337, 11);
            this.buttonInquiry.Name = "buttonInquiry";
            this.buttonInquiry.Size = new System.Drawing.Size(212, 23);
            this.buttonInquiry.TabIndex = 2;
            this.buttonInquiry.Text = "조회";
            this.buttonInquiry.UseVisualStyleBackColor = true;
            this.buttonInquiry.Click += new System.EventHandler(this.buttonInquiry_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1540, 637);
            this.dataGridView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "*공백인 경우 전체 조회. 필터는 다음 항목에만 적용됨: Part Design, Part PN, Options, SN, Notes";
            // 
            // checkBoxExcludeLoan
            // 
            this.checkBoxExcludeLoan.AutoSize = true;
            this.checkBoxExcludeLoan.Location = new System.Drawing.Point(15, 65);
            this.checkBoxExcludeLoan.Name = "checkBoxExcludeLoan";
            this.checkBoxExcludeLoan.Size = new System.Drawing.Size(116, 16);
            this.checkBoxExcludeLoan.TabIndex = 5;
            this.checkBoxExcludeLoan.Text = "대여중 재고 제외";
            this.checkBoxExcludeLoan.UseVisualStyleBackColor = true;
            // 
            // checkBoxExcludePMNT
            // 
            this.checkBoxExcludePMNT.AutoSize = true;
            this.checkBoxExcludePMNT.Location = new System.Drawing.Point(137, 65);
            this.checkBoxExcludePMNT.Name = "checkBoxExcludePMNT";
            this.checkBoxExcludePMNT.Size = new System.Drawing.Size(170, 16);
            this.checkBoxExcludePMNT.TabIndex = 6;
            this.checkBoxExcludePMNT.Text = "영구대여(9999/12/31) 제외";
            this.checkBoxExcludePMNT.UseVisualStyleBackColor = true;
            // 
            // labelCnt
            // 
            this.labelCnt.AutoSize = true;
            this.labelCnt.Location = new System.Drawing.Point(555, 17);
            this.labelCnt.Name = "labelCnt";
            this.labelCnt.Size = new System.Drawing.Size(103, 12);
            this.labelCnt.TabIndex = 7;
            this.labelCnt.Text = "[Result Count: 0]";
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 745);
            this.Controls.Add(this.labelCnt);
            this.Controls.Add(this.checkBoxExcludePMNT);
            this.Controls.Add(this.checkBoxExcludeLoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonInquiry);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormInventory";
            this.Text = "Inventory List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonInquiry;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxExcludeLoan;
        private System.Windows.Forms.CheckBox checkBoxExcludePMNT;
        private System.Windows.Forms.Label labelCnt;
    }
}