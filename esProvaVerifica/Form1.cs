using Newtonsoft.Json;
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

namespace esProvaVerifica
{
    public partial class Form1 : Form
    {
        class Cantante
        {
            public Cantante(string nomeCompleto, string nomeArte, string nazionalita)
            {
                NomeCompleto = nomeCompleto;
                NomeArte = nomeArte;
                Nazionalita = nazionalita;
            }

            public string Id { get; set; }
            public string NomeCompleto { get; set; }
            public string NomeArte { get; set; }
            public string Nazionalita { get; set; }
            public List<Canzone> ListCanzoni { get; set; }
        }
        class GenereMusica
        {
            public GenereMusica(string sigla, string nomeGenere)
            {
                Sigla = sigla;
                NomeGenere = nomeGenere;
            }

            public string Sigla { get; set; }
            public string NomeGenere { get; set; }
            public List<Cantante> ListCantanti { get; set; }
        }

        class Canzone
        {
            public Canzone(int id, string nomeCanzone, string annoProduzione)
            {
                Id = id;
                NomeCanzone = nomeCanzone;
                AnnoProduzione = annoProduzione;
            }

            public int Id { get; set; }
            public string NomeCanzone { get; set; }
            public string AnnoProduzione { get; set; }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbNome2.DataBindings.Add(new Binding("Text", tbNome1, "Text"));

            List<GenereMusica> generes = new List<GenereMusica>();
            generes.Add(new GenereMusica("RK", "Rock"));
            generes.Add(new GenereMusica("PP", "Pop"));
            generes.Add(new GenereMusica("HP", "Hip Pop"));
            generes.Add(new GenereMusica("JZ", "Jazz"));

            string json = JsonConvert.SerializeObject(generes, Formatting.Indented);
            richTextBox1.Text = json;

            List<Cantante> cantanti = new List<Cantante>();
            cantanti.Add(new Cantante("Cantante1", "1", "UK"));
            cantanti.Add(new Cantante("Cantante2", "2", "ITA"));
            cantanti.Add(new Cantante("Cantante3", "3", "SPA"));



            BindingSource listGeneri = new BindingSource();
            listGeneri.DataSource = generes;

            cbSigla.DataSource = listGeneri;
            cbSigla.DisplayMember = "Sigla";

            tbGenere.DataBindings.Add("Text", listGeneri, "NomeGenere");

            BindingSource listCantanti = new BindingSource();
            listCantanti.DataSource = cantanti;

            cbCantanti.DataSource = listCantanti;
            cbCantanti.DisplayMember = "NomeCompleto";

            tbNome.DataBindings.Add("Text", listCantanti, "NomeArte");
            tbNaz.DataBindings.Add("Text", listCantanti, "Nazionalita");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
