using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace timing
{
    public partial class Params : Form
    {

        Dictionary<ListViewItem, Work> dItemWork = new Dictionary<ListViewItem, Work>();
        Dictionary<string, ListViewGroup> dGroup = new Dictionary<string, ListViewGroup>();
        Dictionary<Work, FileSystemWatcher> dictWatchers = new Dictionary<Work, FileSystemWatcher>();
        Work currently_selected = null;

        // UI HELPERS =============================
        void OpenAdditionalInfos()
        {
            if (!additional_infos_is_open)
                this.Width += 500;
            additional_infos_is_open = true;
        }

        void CloseAdditionalInfos()
        {
            if (additional_infos_is_open)
                this.Width -= 500;
            additional_infos_is_open = false;
        }

        public Params()
        {
            InitializeComponent();

            // Timer to refresh the table
            Timer t = new Timer() { Interval = 1000 };
            t.Tick += (object sender, EventArgs ea) =>
            {
                var x = dictWatchers;
                if (Work.current_working == null) return;
                Work.current_working.AddTimeWorked(t.Interval/1000);
                Work.current_working.TriggerUpdate();
            };
            t.Start();

            // Timer to autosave the database
            Timer savedbtimer = new Timer() { Interval = 5000 };
            savedbtimer.Tick += (object sender, EventArgs ea) =>
            {
                Db.save();
            };
            savedbtimer.Start();

            // Resize table ? (still shitty tho)
            foreach (ColumnHeader col in listView1.Columns)
                col.Width = -2;

            // Remove table data from the builder
            listView1.Groups.Clear();
            listView1.Items.Clear();

            // Load the different categories (only code is used for now)
            var categories = new [] { "Code", "Management" };
            
            // Load the data (or create it if it doesnt exist)
            Db.load();

            // =====================================

            // Create the categories in the table
            foreach (var e in categories)
            {
                var gr = new ListViewGroup() { Header = e };
                dGroup.Add(e, gr);
                listView1.Groups.Add(gr);
            }

            // Insert all works from database to the table
            foreach (var e in Db._instance.works)
            {
                Work w = e.Value;
                InsertWorkInTable(w);
            }
        }

        

        // LOGIC HELPERS ==========================

        private ListViewItem InsertWorkInTable(Work w)
        {
            // Create the table elements
            var it = new ListViewItem() { Text = w.name, Group = dGroup[w.group] };
            var si1 = it.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = w.descr });
            var si2 = it.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = w.GetWorkedToday() });

            // Create the FileSystemWatcher
            AddFileListenerForWork(w);

            // Called when a work is modified (manually or with timer)
            w.onUpdate += (object a, object b) =>
            {
                it.Text = w.name;
                si1.Text = w.descr;
                si2.Text = "" + w.GetWorkedToday();
            };

            // Called when the current work is that one
            w.onStartWork += (object a, EventArgs ea) =>
            {
                it.BackColor = Color.Green;
            };

            // Called when the current work is no longer this one
            w.onEndWork += (object a, EventArgs ea) =>
            {
                it.BackColor = Color.White;
            };

            // Add to the list, and the reverse search dict
            var elt = listView1.Items.Add(it);
            dItemWork.Add(elt, w);

            return elt;
        }

        private void AddFileListenerForWork(Work w)
        {
            if (w.path_to_observe != "")
            {
                var fsw = new FileSystemWatcher(w.path_to_observe)
                {
                    Filter = "*.*",
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                };

                // Add to the dict watcher to delete when we update the element
                dictWatchers.Add(w, fsw);

                // When a file is modified, switch to that work
                FileSystemEventHandler fsw_callback = (object sender, FileSystemEventArgs fsea) =>
                {
                    // this.lbl_time_for_this_task.Invoke((MethodInvoker)delegate { lbl_time_for_this_task.Text = w.name; });
                    Work.current_working?.TriggerEndWork();
                    w.TriggerStartWork();
                };

                fsw.Changed += fsw_callback;
                fsw.Created += fsw_callback;
                fsw.Deleted += fsw_callback;

                // Go
                fsw.EnableRaisingEvents = true;
            }
        }

        private void RemoveFileListenerForWork(Work w)
        {
            if (!dictWatchers.ContainsKey(w)) return;

            dictWatchers[w].EnableRaisingEvents = false;
            dictWatchers.Remove(w);
        }

        private void RemoveWorkSelectedInTable()
        {
            if (listView1.SelectedItems.Count == 0) return;
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        // THIS IS CALLED AFTER INIT
        bool additional_infos_is_open = true;
        private void Params_Load(object sender, EventArgs e)
        {
            CloseAdditionalInfos();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the user selects a work in the table

            if (listView1.SelectedItems.Count == 0) return;

            // End the previous work if it existed
            Work.current_working?.TriggerEndWork();

            // Start the new work
            currently_selected = dItemWork[listView1.SelectedItems[0]];
            currently_selected.TriggerStartWork();

            // If we were editing something, close it to avoid replacing data
            CloseAdditionalInfos();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CREATE NEW LINE

            Work w = new Work() {
                name = "name",
                descr = "small description",
                group = "Code",
                seconds_worked = 0,
                path_to_observe = ""
            };

            // Rename the element if it already exists
            int i = 1;
            string newname = w.name;
            while (Db._instance.works.ContainsKey(newname))
                newname = w.name + "("+(i++)+")";
            w.name = newname;

            Db._instance.works.Add(w.name, w);
            var elt = InsertWorkInTable(w);

            elt.Selected = true;
            listView1.Select();
            btn_edit.PerformClick(); // Simulate click on edit
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (currently_selected == null) return;
            var work = currently_selected;

            work.name = inp_name.Text;
            work.descr = inp_descr.Text;
            work.path_to_observe = inp_path.Text;

            // Update file listener
            RemoveFileListenerForWork(work);
            AddFileListenerForWork(work);

            work.TriggerUpdate();

            CloseAdditionalInfos();
            listView1.Select(); // prevent multiple calls by pressing enter hehe
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var work = currently_selected;

            RemoveFileListenerForWork(work);
            RemoveWorkSelectedInTable();

            Db._instance.works.Remove(work.name);

            inp_name.Text = "";
            inp_descr.Text = "";
            inp_path.Text = "";

            CloseAdditionalInfos();
            listView1.Select(); // prevent multiple calls by pressing enter hehe
        }

        private void inp_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void inp_descr_TextChanged(object sender, EventArgs e)
        {

        }

        private void inp_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            OpenAdditionalInfos();

            inp_name.Text = currently_selected.name;
            inp_descr.Text = currently_selected.descr;
            inp_path.Text = currently_selected.path_to_observe;
        }
    }
}
