using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _27___Gestione_prodotti_CRUD
{
    public partial class Form1 : Form
    {
        public static string filename;

        public Form1()
        {
            InitializeComponent();

            filename = Path.GetFullPath("."); //Percorso del file

            filename = Path.GetDirectoryName(filename); //Torna indietro di una cartella
            filename = Path.GetDirectoryName(filename); //Torna indietro di una cartella
            filename = Path.GetDirectoryName(filename); //Torna indietro di una cartella

            filename += @"/lista";

            Directory.CreateDirectory(filename);
            StreamWriter sw = new StreamWriter(filename + @"/lista.txt");
            sw.Close();
        }

        public struct Voto
        {
            public int id;
            public string materia;
            public string data;
            public int voto;
            public string cognome;
            public string nome;
        }

        public static string ToString(Voto v, string sep = ";")
        {

            return (v.id + sep + v.materia + sep + v.data + sep + v.voto + sep + v.cognome + sep + v.nome + sep).PadRight(60) + "##";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Voto v;
            int a = Convert.ToInt32(textBox1.Text);

            if(textBox1.Text=="")
            {
                v.id = 0;
            }
            else
            {
                v.id = a;
            }

            v.materia = textBox2.Text;
            v.data = textBox3.Text;

            int a2 = Convert.ToInt32(textBox4.Text);

            if (textBox4.Text == "")
            {
                v.voto = 0;
            }
            else
            {
                v.voto = a2;
            }

            v.cognome = textBox5.Text;
            v.nome = textBox6.Text;

            textBox1.Text = "";
            textBox1.Focus();
            textBox2.Text = "";
            textBox2.Focus();
            textBox3.Text = "";
            textBox3.Focus();
            textBox4.Text = "";
            textBox4.Focus();
            textBox5.Text = "";
            textBox5.Focus();
            textBox6.Text = "";
            textBox6.Focus();

            AggiungiSuFile(v);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            Aggiorna(sender, e);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(textBox7.Text);

            Voto v = cercaVoto(a,filename);

            v.id = Convert.ToInt32(textBox7.Text);
            v.materia = textBox2.Text;
            v.data = textBox3.Text;
            v.voto = Convert.ToInt32(textBox4.Text);
            v.cognome = textBox5.Text;
            v.nome = textBox6.Text;       
            
            

            textBox7.Text = "";
            textBox7.Focus();
            textBox1.Text = "";
            textBox1.Focus();
            textBox2.Text = "";
            textBox2.Focus();
            textBox3.Text = "";
            textBox3.Focus();
            textBox4.Text = "";
            textBox4.Focus();
            textBox5.Text = "";
            textBox5.Focus();
            textBox6.Text = "";
            textBox6.Focus();

            AggiungiSuFile(v);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(textBox7.Text);

            Voto v = cercaVoto(a, filename);

            v.id = 0;
            v.materia = "";
            v.data = "";
            v.voto = 0;
            v.cognome = "";
            v.nome = "";

            AggiungiSuFile(v);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Funzioni di servizio

        public static void AggiungiSuFile(Voto v)
        {
            scriviAppend(ToString(v));
        }

        public static Voto FromString(string votoStringa, string sep = ";")
        {
            Voto v;
            String[] fields = votoStringa.Split(sep[0]);
            v.id = int.Parse(fields[0]);
            v.cognome = fields[4];
            v.nome = fields[5];
            v.data = fields[2];
            v.voto = int.Parse(fields[3]);
            v.materia = fields[1];
            //dalla stringa deve ritornare la variabile Voto v settata con  i valori
            return v;
        }

        public static Voto cercaVoto(string id, string filename)
        {
            return FromString(cercaSuFile(id, filename));
        }

        public static string cercaSuFile(string id, string filename, string sep = ";")
        {
            StreamReader sr = new StreamReader(filename + @"/lista.txt");
            string line = id;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                //esamino la riga, vedo se c'è l'identificatore cercato
                //se si ritorno la riga
                //..

            }

            sr.Close();

            return line;
        }

        public static void scriviAppend(string content)
        {
            var oStream = new FileStream(filename + @"/lista.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        public void Aggiorna(object sender, EventArgs e)
        {
            using (StreamReader sw = File.OpenText(filename + @"/lista.txt"))
            {
                string s;

                listView1.Items.Clear();

                while ((s = sw.ReadLine()) != null)
                {
                    listView1.Items.Add(s);
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
