using System;
using System.IO;
using System.Windows.Forms;

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
            v.id = Convert.ToInt32(textBox1.Text);
            v.materia = textBox2.Text;
            v.data = textBox3.Text;
            v.voto = Convert.ToInt32(textBox4.Text);            
            v.cognome = textBox5.Text;
            v.nome = textBox6.Text;
            AggiungiSuFile(v);

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

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

        public static Voto cercaVoto(int id, string filename)
        {
            return FromString(cercaSuFile(id, filename));
        }

        public static string cercaSuFile(int id, string filename, string sep = ";")
        {
            StreamReader sr = new StreamReader(filename);
            string line = "";

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
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }
    }
}
