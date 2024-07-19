namespace xrefBrowser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainFormBindingSource = new BindingSource(components);
            resultsBindingSource = new BindingSource(components);
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            chkOnlyStartsWith = new CheckBox();
            groupBox1 = new GroupBox();
            lblSignature = new Label();
            label3 = new Label();
            lblName = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)mainFormBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultsBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // mainFormBindingSource
            // 
            mainFormBindingSource.DataSource = typeof(ViewModel.MainFormViewModel);
            // 
            // resultsBindingSource
            // 
            resultsBindingSource.DataMember = "Results";
            resultsBindingSource.DataSource = mainFormBindingSource;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.DataSource = resultsBindingSource;
            listBox1.DisplayMember = "FullName";
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 55);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(769, 124);
            listBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.DataBindings.Add(new Binding("Text", mainFormBindingSource, "Query", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(579, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.DataBindings.Add(new Binding("Command", mainFormBindingSource, "ClearQueryCommand", true));
            button1.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(597, 25);
            button1.Name = "button1";
            button1.Size = new Size(25, 24);
            button1.TabIndex = 4;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Query";
            // 
            // chkOnlyStartsWith
            // 
            chkOnlyStartsWith.AutoSize = true;
            chkOnlyStartsWith.Location = new Point(629, 29);
            chkOnlyStartsWith.Name = "chkOnlyStartsWith";
            chkOnlyStartsWith.Size = new Size(152, 19);
            chkOnlyStartsWith.TabIndex = 6;
            chkOnlyStartsWith.Text = "Only Search 'StartsWith'";
            chkOnlyStartsWith.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSignature);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 184);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(769, 365);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected API";
            // 
            // lblSignature
            // 
            lblSignature.AutoSize = true;
            lblSignature.DataBindings.Add(new Binding("Text", resultsBindingSource, "FullName", true));
            lblSignature.Location = new Point(79, 54);
            lblSignature.Name = "lblSignature";
            lblSignature.Size = new Size(38, 15);
            lblSignature.TabIndex = 3;
            lblSignature.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 50);
            label3.Name = "label3";
            label3.Size = new Size(67, 19);
            label3.TabIndex = 2;
            label3.Text = "Signature";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.DataBindings.Add(new Binding("Text", resultsBindingSource, "Name", true));
            lblName.Location = new Point(79, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(38, 15);
            lblName.TabIndex = 1;
            lblName.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(45, 19);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 561);
            Controls.Add(groupBox1);
            Controls.Add(chkOnlyStartsWith);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XREF Browser";
            Load += Form1_Load;
            Shown += Form1_Shown;
            DataContextChanged += Form1_DataContextChanged;
            ((System.ComponentModel.ISupportInitialize)mainFormBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultsBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource mainFormBindingSource;
        private BindingSource resultsBindingSource;
        private ListBox listBox1;
        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private CheckBox chkOnlyStartsWith;
        private GroupBox groupBox1;
        private Label lblSignature;
        private Label label3;
        private Label lblName;
        private Label label2;
    }
}
