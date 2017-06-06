using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



namespace Restoranas
{
    public partial class Form1 : Form
    {

        List<Kategorijos> kategorijos = new List<Kategorijos>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] turinys = File.ReadAllLines("kategorijos.txt",Encoding.Default);

            if (listBox1.SelectedItem == null)
            {

                foreach (string s in turinys)
                {
                    string[] strMasyvas = s.Split('&');
                    Kategorijos k = new Kategorijos(Convert.ToInt32(strMasyvas[0]), strMasyvas[1]);

                    kategorijos.Add(k);
                    listBox1.Items.Add(k.katID + "," + k.katPav);

                }

                turinys = File.ReadAllLines("patiekalai.txt", Encoding.Default);
                foreach (string t in turinys)
                {
                    string[] split = t.Split('&');
                    Patiekalai p = new Patiekalai(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), split[2], Convert.ToDouble(split[3]), split[4]);

                    foreach (Kategorijos k in kategorijos)
                    {
                        if (k.katID == Convert.ToInt32(split[1]))
                            k.patiekaluSarasas.Add(p);
                        //listBox2.Items.Add(p.pavadinimas);
                        break;
                    }
                }
            }

            //string currentID;
            //string[] elem = listBox1.SelectedItems.ToString().Split(',');
            //currentID = elem[0];
            //textBox1.Text = elem[0].ToString();


        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string currentID;
            string elem = listBox1.SelectedItem.ToString();
            string[] mas = elem.Split(',');
            currentID = mas[0];

            //textBox1.Text = mas[0].ToString();

            //string[] turinys = File.ReadAllLines("patiekalai.txt");

            //foreach (string s in turinys)
            //{
            //    string[] strMasyvas = s.Split('&');
            //    Patiekalai pat = new Patiekalai(Convert.ToInt32(strMasyvas[0]), Convert.ToInt32(strMasyvas[1]), strMasyvas[2], Convert.ToDouble(strMasyvas[3]), strMasyvas[4]);

            //    if (Convert.ToInt32(mas[0]) == pat.kategorijosID)
            //    {
            //        listBox2.Items.Add(pat.pavadinimas);
            //        break;
            //    }
            //}

            using (StreamReader sr = new StreamReader("patiekalai.txt", Encoding.Default))
            {
                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    string[] strMasyvas = str.Split('&');

                    Patiekalai pat = new Patiekalai(Convert.ToInt32(strMasyvas[0]), Convert.ToInt32(strMasyvas[1]), strMasyvas[2], Convert.ToDouble(strMasyvas[3]), strMasyvas[4]);
                    if (Convert.ToInt32(mas[0]) == pat.kategorijosID)
                    {
                        listBox2.Items.Add(pat.pavadinimas);

                    }
                }
            }
        }

       
        public string pavadinimas;

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string current = listBox2.SelectedItem.ToString();
            double kaina;

            using (StreamReader sr = new StreamReader("patiekalai.txt", Encoding.Default))
            {
                while (sr.Peek() >= 0)
                {
                    string str = sr.ReadLine();
                    string[] strMasyvas = str.Split('&');

                    Patiekalai pat = new Patiekalai(Convert.ToInt32(strMasyvas[0]), Convert.ToInt32(strMasyvas[1]), strMasyvas[2], Convert.ToDouble(strMasyvas[3]), strMasyvas[4]);
                    if (current == pat.pavadinimas)
                    {
                        kaina = pat.kaina;
                        pavadinimas = pat.pavadinimas;

                        textBox1.Text = (Convert.ToString(pat.kaina));
                        textBox2.Text = (Convert.ToString(pat.aprasymas));

                        textBox1.ReadOnly = true;
                        textBox1.BackColor = SystemColors.Window;

                        textBox2.ReadOnly = true;
                        textBox2.BackColor = SystemColors.Window;
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double suma = 0;
            double kaina = 0;

        richTextBox1.Text = pavadinimas + Environment.NewLine + richTextBox1.Text;

            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                textBox4.Text = kaina.ToString();
            }
            else
            {
                suma = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(kaina.ToString());
                textBox4.Text = Convert.ToString(suma);
            }
        }

    }
}







        
    

