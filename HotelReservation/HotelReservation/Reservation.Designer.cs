namespace HotelReservation
{
    partial class Reservation
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
            dataGridView1 = new DataGridView();
            btnDelete = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            TxtReservationID = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateTimePickerCheckOut = new DateTimePicker();
            dateTimePickerCheckIn = new DateTimePicker();
            textRoomID = new TextBox();
            textCustomerID = new TextBox();
            textPrice = new TextBox();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnList = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.AppWorkspace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(791, 376);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.Location = new Point(809, 92);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(330, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Reservation Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.Location = new Point(809, 57);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(330, 29);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "Reservation Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.Location = new Point(809, 127);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(330, 29);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Reservation Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // TxtReservationID
            // 
            TxtReservationID.Location = new Point(912, 371);
            TxtReservationID.Name = "TxtReservationID";
            TxtReservationID.Size = new Size(227, 27);
            TxtReservationID.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(811, 374);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 16;
            label2.Text = "ReservationID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(811, 304);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 17;
            label3.Text = "Check In:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(811, 335);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 18;
            label4.Text = "Check Out:";
            // 
            // dateTimePickerCheckOut
            // 
            dateTimePickerCheckOut.Location = new Point(911, 330);
            dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            dateTimePickerCheckOut.Size = new Size(230, 27);
            dateTimePickerCheckOut.TabIndex = 18;
            // 
            // dateTimePickerCheckIn
            // 
            dateTimePickerCheckIn.Location = new Point(911, 297);
            dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            dateTimePickerCheckIn.Size = new Size(230, 27);
            dateTimePickerCheckIn.TabIndex = 17;
            // 
            // textRoomID
            // 
            textRoomID.Location = new Point(912, 264);
            textRoomID.Name = "textRoomID";
            textRoomID.Size = new Size(227, 27);
            textRoomID.TabIndex = 15;
            // 
            // textCustomerID
            // 
            textCustomerID.Location = new Point(911, 230);
            textCustomerID.Name = "textCustomerID";
            textCustomerID.Size = new Size(228, 27);
            textCustomerID.TabIndex = 14;
            // 
            // textPrice
            // 
            textPrice.Location = new Point(911, 197);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(228, 27);
            textPrice.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(811, 204);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 11;
            label1.Text = "TotalPrice:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(811, 237);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 11;
            label5.Text = "CustomerID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(811, 270);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 12;
            label6.Text = "RoomID:";
            // 
            // btnList
            // 
            btnList.BackColor = Color.Transparent;
            btnList.Location = new Point(809, 22);
            btnList.Name = "btnList";
            btnList.Size = new Size(330, 29);
            btnList.TabIndex = 14;
            btnList.Text = "Reservation List";
            btnList.UseVisualStyleBackColor = false;
            btnList.Click += btnList_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Transparent;
            btnSearch.Location = new Point(809, 162);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(330, 29);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Reservation Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // Reservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(1159, 434);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnList);
            Controls.Add(btnUpdate);
            Controls.Add(TxtReservationID);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(dateTimePickerCheckOut);
            Controls.Add(label1);
            Controls.Add(dateTimePickerCheckIn);
            Controls.Add(textPrice);
            Controls.Add(textRoomID);
            Controls.Add(textCustomerID);
            Name = "Reservation";
            Text = "Reservation";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button btnDelete;
        private TextBox textRoomID;
        private TextBox textCustomerID;
        private TextBox textPrice;
        private Label label1;
        private Label label5;
        private Label label6;
        private TextBox TxtReservationID;
        private Label label2;
        private DateTimePicker dateTimePickerCheckIn;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePickerCheckOut;
        private Button btnUpdate;
        private Button btnList;
        private Button btnAdd;
        private Button btnSearch;
    }
}