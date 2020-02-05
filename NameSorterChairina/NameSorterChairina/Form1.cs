using NameSorterChairina.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameSorterChairina
{
    public partial class FormName : Form
    {

        // Insialisasi Variabel

        public FormName()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                string data;
                // load the data unsorted-name-list.txt
                using (FileStream fs = new FileStream("unsorted-names-list.txt", FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);

                    while ((data = sr.ReadLine()) != null) //loop
                    {
                        var parts = data.Split(',');
                        Array.Reverse(parts);
                        listRead.Items.Add(string.Join(" ", data));

                    } // end loop

                    fs.Close(); //Close file unsorted-name-list.txt
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Opening File", "Data Not Loaded", MessageBoxButtons.OK);
            }
        }

        private void btnStartSort_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (string value in listRead.Items)
            {
                items.Add(value);
            }
            // items.Sort((second, first) => string.Compare(first, second));
            items.Sort(new NameCompare());
            listSort.Items.AddRange(items.ToArray());      
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream file = new FileStream("sorted-names-list.txt", FileMode.OpenOrCreate))
                {
                    StreamWriter sw = new StreamWriter(file);

                    for (int i = 0; i < listSort.Items.Count; i++)
                    {
                        sw.WriteLine((string)listSort.Items[i]);
                    }
                    sw.Close();
                    MessageBox.Show("File Saved"); // Box
                    listSort.Items.Clear(); // Membersihkan List Box Sorted Name
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Saved File", "Data Not Saved", MessageBoxButtons.OK);
            }

        }

        private IComparer<string> NameCompare()
        {
            throw new NotImplementedException();
        }


    }
}
