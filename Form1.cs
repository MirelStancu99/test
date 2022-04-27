using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnII_1058_Stancu_Gheorghe_Mirel
{
    public partial class Form1 : Form
    {
        public List<Pastila> lista = new List<Pastila>();
        public Form1()
        {
            InitializeComponent();

            Pastila p1 = new Pastila(10, "Nurofen", "Pfizer", "COMPENSAT");
            Pastila p2 = new Pastila(20, "Avocalmin", "Pfizer", "COMPENSAT");

            //Adaugare iteme manual in listview
            ListViewItem lv = new ListViewItem(p1.gramaj.ToString());
            lv.SubItems.Add(p1.denumire);
            lv.SubItems.Add(p1.producator);
            lv.SubItems.Add(p1.modEliberare);
            listView1.Items.Add(lv);

            ListViewItem lv2 = new ListViewItem(p2.gramaj.ToString());
            lv2.SubItems.Add(p2.denumire);
            lv2.SubItems.Add(p2.producator);
            lv2.SubItems.Add(p2.modEliberare);
            listView1.Items.Add(lv2);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pastila p = new Pastila();
            p.setGramaj(Convert.ToInt32(textBoxGramaj.Text));
            p.setDenumire(textBoxDenumire.Text);
            p.setProducator(textBoxProducator.Text);
            p.setModEliberare(comboBoxMod.SelectedItem.ToString());
            lista.Add(p);


            //Adaugare elemente in listview
            ListViewItem lv = new ListViewItem(p.gramaj.ToString());
            lv.SubItems.Add(p.denumire);
            lv.SubItems.Add(p.producator);
            lv.SubItems.Add(p.modEliberare);
            listView1.Items.Add(lv);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxGramaj_Validating(object sender, CancelEventArgs e)
        {
            //VALIDARE GRAMAJ
            if(textBoxGramaj.Text.Length > 0)
            {
                if(Convert.ToInt32(textBoxGramaj.Text) < 0)
                {
                    errorProvider1.SetError(textBoxGramaj, "Gramajul trebuie sa fie pozitiv");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(textBoxGramaj, ""); //scoate eroarea
            }
        }

        private void textBoxDenumire_Validating(object sender, CancelEventArgs e)
        {
            //VALIDARE DENUMIRE
            if (textBoxDenumire.Text.Length <= 0)
            {
                errorProvider1.SetError(textBoxDenumire, "Completeaza denumirea");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textBoxDenumire, "");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void salveazaBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //Serializare
        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "fisiere pastile (*.prs)|*.prs";
            fd.CheckPathExists = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                List<Pastila> lista = new List<Pastila>();
                foreach (ListViewItem lv in listView1.Items)
                    lista.Add((Pastila)lv.Tag);  //lista obiecte de serializat

                Stream fisier = File.Create(fd.FileName);
                BinaryFormatter serializator = new BinaryFormatter();

                serializator.Serialize(fisier, lista);
                fisier.Close();
            }
        }
        //Deserializare
        private void deschideBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "fisiere pastile *.prs|*.prs";
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stream fisier = File.OpenRead(fd.FileName);
                BinaryFormatter deserializator = new BinaryFormatter();
                List<Pastila> lista = new List<Pastila>();

                lista.AddRange((List<Pastila>)deserializator.Deserialize(fisier));

                fisier.Close();

                foreach (Pastila p in lista)
                {
                    ListViewItem lv = new ListViewItem(new string[] { p.gramaj.ToString(), p.denumire, p.producator,p.modEliberare });
                    lv.Tag = p;
                    listView1.Items.Add(lv);

                }
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }
    }
}
