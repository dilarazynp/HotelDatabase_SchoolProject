namespace HotelReservation
{
    partial class Menu
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
            components = new System.ComponentModel.Container();
            btnReservation = new Button();
            btnCustomer = new Button();
            Time = new Label();
            Date = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnRoom = new Button();
            SuspendLayout();
            // 
            // btnReservation
            // 
            btnReservation.Location = new Point(50, 117);
            btnReservation.Name = "btnReservation";
            btnReservation.Size = new Size(94, 29);
            btnReservation.TabIndex = 1;
            btnReservation.Text = "Reservation";
            btnReservation.UseVisualStyleBackColor = true;
            btnReservation.Click += btnReservation_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(212, 117);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(94, 29);
            btnCustomer.TabIndex = 2;
            btnCustomer.Text = "Customer";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(67, 175);
            Time.Name = "Time";
            Time.Size = new Size(45, 20);
            Time.TabIndex = 4;
            Time.Text = "Time:";
            Time.Click += Time_Click;
            // 
            // Date
            // 
            Date.AutoSize = true;
            Date.Location = new Point(326, 175);
            Date.Name = "Date";
            Date.Size = new Size(44, 20);
            Date.TabIndex = 5;
            Date.Text = "Date:";
            Date.Click += Date_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(50, 31);
            label1.Name = "label1";
            label1.Size = new Size(419, 40);
            label1.TabIndex = 6;
            label1.Text = "HOTEL MANAGEMENT SYSTEM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 175);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 7;
            label2.Text = "Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 175);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 9;
            label3.Text = "Date:";
            // 
            // btnRoom
            // 
            btnRoom.Location = new Point(375, 117);
            btnRoom.Name = "btnRoom";
            btnRoom.Size = new Size(94, 29);
            btnRoom.TabIndex = 11;
            btnRoom.Text = "Room";
            btnRoom.UseVisualStyleBackColor = true;
            btnRoom.Click += btnRoom_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(513, 222);
            Controls.Add(btnRoom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Date);
            Controls.Add(Time);
            Controls.Add(btnCustomer);
            Controls.Add(btnReservation);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "Menu";
            Text = "Menu";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReservation;
        private Button btnCustomer;
        private Label Time;
        private Label Date;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button d;
        private Button btnRoom;
    }
}