using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            public Cantante(string id, string nomeCompleto, string nomeArte, string nazionalita, List<Canzone> listCanzoni)
            {
                Id = id;
                NomeCompleto = nomeCompleto;
                NomeArte = nomeArte;
                Nazionalita = nazionalita;
                ListCanzoni = listCanzoni;
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

            BindingSource listGeneri = new BindingSource();
            listGeneri.DataSource = generes;

            cbSigla.DataSource = listGeneri;
            cbSigla.DisplayMember = "Sigla";

            tbGenere.DataBindings.Add("Text", listGeneri, "NomeGenere");

        }
    }
}
