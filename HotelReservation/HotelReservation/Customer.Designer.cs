namespace HotelReservation
{
    partial class Customer
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
            dataGridView1 = new DataGridView();
            btnList = new Button();
            btnAdd = new Button();
            textEmail = new TextBox();
            textLastName = new TextBox();
            textName = new TextBox();
            textCustomerID = new TextBox();
            textAddress = new TextBox();
            textPhoneNumber = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(696, 367);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnList
            // 
            btnList.Location = new Point(714, 12);
            btnList.Name = "btnList";
            btnList.Size = new Size(253, 29);
            btnList.TabIndex = 1;
            btnList.Text = "Customer List";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(714, 47);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(253, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Customer Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(842, 284);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(125, 27);
            textEmail.TabIndex = 4;
            // 
            // textLastName
            // 
            textLastName.Location = new Point(842, 251);
            textLastName.Name = "textLastName";
            textLastName.Size = new Size(125, 27);
            textLastName.TabIndex = 5;
            // 
            // textName
            // 
            textName.Location = new Point(842, 218);
            textName.Name = "textName";
            textName.Size = new Size(125, 27);
            textName.TabIndex = 6;
            // 
            // textCustomerID
            // 
            textCustomerID.Location = new Point(842, 188);
            textCustomerID.Name = "textCustomerID";
            textCustomerID.Size = new Size(125, 27);
            textCustomerID.TabIndex = 7;
            // 
            // textAddress
            // 
            textAddress.Location = new Point(842, 350);
            textAddress.Name = "textAddress";
            textAddress.Size = new Size(125, 27);
            textAddress.TabIndex = 8;
            // 
            // textPhoneNumber
            // 
            textPhoneNumber.Location = new Point(842, 317);
            textPhoneNumber.Name = "textPhoneNumber";
            textPhoneNumber.Size = new Size(125, 27);
            textPhoneNumber.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(714, 188);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 10;
            label1.Text = "CustomerID:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(714, 218);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 11;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(714, 251);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 12;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(717, 284);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 13;
            label4.Text = "Email:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(717, 317);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 14;
            label5.Text = "Phone Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(717, 350);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 15;
            label6.Text = "Address:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(714, 82);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(253, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Customer Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(714, 118);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(253, 29);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Customer Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(714, 153);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(253, 29);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Customer Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 400);
            Controls.Add(btnSearch);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textPhoneNumber);
            Controls.Add(textAddress);
            Controls.Add(textCustomerID);
            Controls.Add(textName);
            Controls.Add(textLastName);
            Controls.Add(textEmail);
            Controls.Add(btnAdd);
            Controls.Add(btnList);
            Controls.Add(dataGridView1);
            Name = "Customer";
            Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnList;
        private Button btnAdd;
        private TextBox textEmail;
        private TextBox textLastName;
        private TextBox textName;
        private TextBox textCustomerID;
        private TextBox textAddress;
        private TextBox textPhoneNumber;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnSearch;
    }
}