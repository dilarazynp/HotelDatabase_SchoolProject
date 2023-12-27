namespace HotelReservation
{
    partial class Room
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
            btnAdd = new Button();
            textRoomID = new TextBox();
            textCapacity = new TextBox();
            textRoomType = new TextBox();
            textPrice = new TextBox();
            textSituation = new TextBox();
            btnDelete = new Button();
            btnSearch = new Button();
            btnList = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnUpdate = new Button();
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
            dataGridView1.Size = new Size(644, 352);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(662, 47);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(270, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Room Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // textRoomID
            // 
            textRoomID.Location = new Point(779, 189);
            textRoomID.Name = "textRoomID";
            textRoomID.Size = new Size(153, 27);
            textRoomID.TabIndex = 3;
            // 
            // textCapacity
            // 
            textCapacity.Location = new Point(779, 222);
            textCapacity.Name = "textCapacity";
            textCapacity.Size = new Size(153, 27);
            textCapacity.TabIndex = 4;
            // 
            // textRoomType
            // 
            textRoomType.Location = new Point(779, 255);
            textRoomType.Name = "textRoomType";
            textRoomType.Size = new Size(153, 27);
            textRoomType.TabIndex = 5;
            // 
            // textPrice
            // 
            textPrice.Location = new Point(779, 288);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(153, 27);
            textPrice.TabIndex = 6;
            // 
            // textSituation
            // 
            textSituation.Location = new Point(779, 321);
            textSituation.Name = "textSituation";
            textSituation.Size = new Size(153, 27);
            textSituation.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(662, 82);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(270, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Room Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(662, 152);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(270, 29);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Room Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnList
            // 
            btnList.Location = new Point(662, 12);
            btnList.Name = "btnList";
            btnList.Size = new Size(270, 29);
            btnList.TabIndex = 10;
            btnList.Text = "Room List";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(662, 196);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 11;
            label1.Text = "RoomID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(662, 229);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 12;
            label2.Text = "Capacity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(662, 262);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 13;
            label3.Text = "Room Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(662, 295);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 14;
            label4.Text = "Price:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(662, 328);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 15;
            label5.Text = "Situation:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(662, 117);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(270, 29);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Room Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 385);
            Controls.Add(btnUpdate);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnList);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(textSituation);
            Controls.Add(textPrice);
            Controls.Add(textRoomType);
            Controls.Add(textCapacity);
            Controls.Add(textRoomID);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Name = "Room";
            Text = "Room";
            Load += Room_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private TextBox textRoomID;
        private TextBox textCapacity;
        private TextBox textRoomType;
        private TextBox textPrice;
        private TextBox textSituation;
        private Button btnDelete;
        private Button btnSearch;
        private Button btnList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnUpdate;
    }
}