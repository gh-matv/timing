namespace timing
{
    partial class Params
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "AJOUTER",
            "========"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "3",
            "-------"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_descr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_timeworked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_time_for_this_task = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.inp_name = new System.Windows.Forms.TextBox();
            this.inp_descr = new System.Windows.Forms.TextBox();
            this.inp_path = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_name,
            this.column_descr,
            this.column_timeworked});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "Programmation";
            listViewGroup1.Tag = "code";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "Management";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "code";
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(36, 204);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(412, 394);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // column_name
            // 
            this.column_name.Text = "Nom";
            this.column_name.Width = 126;
            // 
            // column_descr
            // 
            this.column_descr.Text = "Description";
            this.column_descr.Width = 122;
            // 
            // column_timeworked
            // 
            this.column_timeworked.Text = "Temps";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 667);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(978, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(118, 17);
            this.StatusLabel.Text = "toolStripStatusLabel1";
            // 
            // lbl_time_for_this_task
            // 
            this.lbl_time_for_this_task.AutoSize = true;
            this.lbl_time_for_this_task.Location = new System.Drawing.Point(675, 9);
            this.lbl_time_for_this_task.Name = "lbl_time_for_this_task";
            this.lbl_time_for_this_task.Size = new System.Drawing.Size(108, 13);
            this.lbl_time_for_this_task.TabIndex = 3;
            this.lbl_time_for_this_task.Text = "lbl_time_for_this_task";
            this.lbl_time_for_this_task.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inp_name
            // 
            this.inp_name.Location = new System.Drawing.Point(589, 258);
            this.inp_name.Name = "inp_name";
            this.inp_name.Size = new System.Drawing.Size(289, 20);
            this.inp_name.TabIndex = 5;
            this.inp_name.TextChanged += new System.EventHandler(this.inp_name_TextChanged);
            // 
            // inp_descr
            // 
            this.inp_descr.Location = new System.Drawing.Point(589, 284);
            this.inp_descr.Name = "inp_descr";
            this.inp_descr.Size = new System.Drawing.Size(289, 20);
            this.inp_descr.TabIndex = 6;
            this.inp_descr.TextChanged += new System.EventHandler(this.inp_descr_TextChanged);
            // 
            // inp_path
            // 
            this.inp_path.Location = new System.Drawing.Point(589, 310);
            this.inp_path.Name = "inp_path";
            this.inp_path.Size = new System.Drawing.Size(289, 20);
            this.inp_path.TabIndex = 7;
            this.inp_path.TextChanged += new System.EventHandler(this.inp_path_TextChanged);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(667, 336);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(158, 23);
            this.btn_update.TabIndex = 8;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(708, 365);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 9;
            this.btn_delete.Text = "Delete (!)";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(245, 604);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(123, 23);
            this.btn_edit.TabIndex = 10;
            this.btn_edit.Text = "Editer";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 145);
            this.label1.TabIndex = 11;
            this.label1.Text = "TIME MANAGEMENT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 689);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.inp_path);
            this.Controls.Add(this.inp_descr);
            this.Controls.Add(this.inp_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_time_for_this_task);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Params";
            this.Text = "Params";
            this.Load += new System.EventHandler(this.Params_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_name;
        private System.Windows.Forms.ColumnHeader column_descr;
        private System.Windows.Forms.ColumnHeader column_timeworked;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label lbl_time_for_this_task;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inp_name;
        private System.Windows.Forms.TextBox inp_descr;
        private System.Windows.Forms.TextBox inp_path;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Label label1;
    }
}