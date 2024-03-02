using MySql.Data.MySqlClient;
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

namespace grafikus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adatBeolvasas();
        }

        private void button1_Click(object sender, EventArgs e) // betöltés
        {

        }

        private void button2_Click(object sender, EventArgs e)  //mentés
        {
            
        }

        private void button3_Click(object sender, EventArgs e)  //felvitel
        {
            FormBook formGyumolcs = new FormBook("insert");
            formBook.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)  //módosítás
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztott elem!");
                return;
            }
            FormBook formAuto = new FormBook("edit");
            formBook.ShowDialog();
            updateBookListBox();
        }

        private void button5_Click(object sender, EventArgs e)  //törlés
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Választott elemet!");
                return;
            }
            Book book = (Book)listBox1.SelectedItem;
            if (MessageBox.Show("A törlést választotta! Szeretné törölni?", "Válasszon!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                comm.CommandText = "DELETE FROM `books` WHERE `id`=" + book.id;
                comm.ExecuteNonQuery();
                adatBeolvasas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
