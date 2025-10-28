namespace UserInputJsonToXml
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
            InputJSONParser = new Label();
            txtCustomerName = new TextBox();
            textOrderId = new TextBox();
            CustomerName = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtAmount = new TextBox();
            Submit_btn = new Button();
            txtShippingCity = new TextBox();
            progressBar1 = new ProgressBar();
            txtResponse = new TextBox();
            ShowJson_btn = new Button();
            ShowXml_btn = new Button();
            SuspendLayout();
            // 
            // InputJSONParser
            // 
            InputJSONParser.AutoSize = true;
            InputJSONParser.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InputJSONParser.Location = new Point(307, 28);
            InputJSONParser.Name = "InputJSONParser";
            InputJSONParser.Size = new Size(183, 24);
            InputJSONParser.TabIndex = 0;
            InputJSONParser.Text = "InputJSONParser";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(184, 112);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(100, 23);
            txtCustomerName.TabIndex = 1;
            txtCustomerName.TextChanged += txtCustomerName_TextChanged;
            // 
            // textOrderId
            // 
            textOrderId.Location = new Point(184, 150);
            textOrderId.Name = "textOrderId";
            textOrderId.Size = new Size(100, 23);
            textOrderId.TabIndex = 2;
            // 
            // CustomerName
            // 
            CustomerName.AutoSize = true;
            CustomerName.Location = new Point(87, 115);
            CustomerName.Name = "CustomerName";
            CustomerName.Size = new Size(100, 15);
            CustomerName.TabIndex = 3;
            CustomerName.Text = "Customer Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 153);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Order ID: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 221);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 8;
            label3.Text = "Shipping City: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 182);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 7;
            label4.Text = "Order Amount: ";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(184, 179);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 5;
            // 
            // Submit_btn
            // 
            Submit_btn.Location = new Point(199, 250);
            Submit_btn.Name = "Submit_btn";
            Submit_btn.Size = new Size(75, 23);
            Submit_btn.TabIndex = 0;
            Submit_btn.Text = "Submit";
            Submit_btn.Click += Submit_btn_Click;
            // 
            // txtShippingCity
            // 
            txtShippingCity.Location = new Point(184, 221);
            txtShippingCity.Name = "txtShippingCity";
            txtShippingCity.Size = new Size(100, 23);
            txtShippingCity.TabIndex = 9;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = Color.Green;
            progressBar1.Location = new Point(88, 394);
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(642, 23);
            progressBar1.TabIndex = 10;
            // 
            // txtResponse
            // 
            txtResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResponse.BackColor = SystemColors.Control;
            txtResponse.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResponse.Location = new Point(307, 86);
            txtResponse.MaximumSize = new Size(500, 500);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.Size = new Size(382, 250);
            txtResponse.TabIndex = 11;
            txtResponse.Visible = false;
            txtResponse.WordWrap = false;
            // 
            // ShowJson_btn
            // 
            ShowJson_btn.Location = new Point(454, 57);
            ShowJson_btn.Name = "ShowJson_btn";
            ShowJson_btn.Size = new Size(104, 23);
            ShowJson_btn.TabIndex = 12;
            ShowJson_btn.Text = "Show sent Json";
            ShowJson_btn.UseVisualStyleBackColor = true;
            ShowJson_btn.Click += ShowJson_btn_Click;
            // 
            // ShowXml_btn
            // 
            ShowXml_btn.Location = new Point(564, 57);
            ShowXml_btn.Name = "ShowXml_btn";
            ShowXml_btn.Size = new Size(125, 23);
            ShowXml_btn.TabIndex = 13;
            ShowXml_btn.Text = "Show received XML";
            ShowXml_btn.UseVisualStyleBackColor = true;
            ShowXml_btn.Click += ShowXml_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ShowXml_btn);
            Controls.Add(ShowJson_btn);
            Controls.Add(txtResponse);
            Controls.Add(progressBar1);
            Controls.Add(txtShippingCity);
            Controls.Add(Submit_btn);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtAmount);
            Controls.Add(label2);
            Controls.Add(CustomerName);
            Controls.Add(textOrderId);
            Controls.Add(txtCustomerName);
            Controls.Add(InputJSONParser);
            Name = "Form1";
            Text = "InputJSONParser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InputJSONParser;
        private TextBox txtCustomerName;
        private TextBox textOrderId;
        private Label CustomerName;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAmount;
        private Button Submit_btn;
        private TextBox txtShippingCity;
        private ProgressBar progressBar1;
        private TextBox txtResponse;
        private Button ShowJson_btn;
        private Button ShowXml_btn;
    }
}
