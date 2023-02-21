using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarenhausForms6.MySQL;
using WarenhausForms6.MySQL.Stammdaten.Account;
//using WarenhausForms6.Front_end;

namespace WarenhausForms6
{
    public partial class MitarbeiterAnsicht : Form
    {
        ArtikelVerwaltung _artikelVerwaltung;
        BestandVerwalten _bestandVerwalten;
        NutzerVerwaltung _nutzer;
        DBAcess _dBAcess = new DBAcess("root", "");
        DataGridBearbeiten _indexer = new DataGridBearbeiten();
        public MitarbeiterAnsicht()
        {
            InitializeComponent();
            Unsichtbar();
            _artikelVerwaltung = new ArtikelVerwaltung(_dBAcess);
            _bestandVerwalten = new BestandVerwalten(_dBAcess);
            _nutzer = new NutzerVerwaltung(_dBAcess);
        }
        private void Unsichtbar()
        {
            this.kunde_button.Visible = false;
            this.mitarbeiter_button.Visible = false;
            this.bestellt_button.Visible = false;
            this.bezahlt_button.Visible = false;
            this.verpackt_button.Visible = false;
            this.versendet_button.Visible = false;
            this.reklamation_button.Visible = false;
            this.artikel_button.Visible = false;
            this.artikel_sortiment_button.Visible = false;
            this.lager_button.Visible = false;
            this.best_button.Visible = false;

        }
        private void Sortiment_button_Click(object sender, EventArgs e)
        {
            Unsichtbar();
            this.artikel_button.Visible = true;
            this.best_button.Visible = true;
        }
        private void Nutzer_button_Click(object sender, EventArgs e)
        {
            Unsichtbar();
            this.kunde_button.Visible = true;
            this.mitarbeiter_button.Visible = true;
        }
        private void Bestand_button_Click(object sender, EventArgs e)
        {
            Unsichtbar();
            this.artikel_sortiment_button.Visible = true;
            this.lager_button.Visible = true;
        }
        private void Bestellungen_button_Click(object sender, EventArgs e)
        {
            Unsichtbar();
            this.bestellt_button.Visible = true;
            this.bezahlt_button.Visible = true;
            this.verpackt_button.Visible = true;
            this.versendet_button.Visible = true;
            this.reklamation_button.Visible = true;
        }
        private void Warenkorb_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Bestellungen(Status.Warenkorb.ToString());
            this.dataGridView1.DataSource = _bestandVerwalten.BestellungListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }
        private void Bezahlt_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Bestellungen(Status.bezahlt.ToString());
            this.dataGridView1.DataSource = _bestandVerwalten.BestellungListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }

        private void Versendet_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Bestellungen(Status.versendet.ToString());
            this.dataGridView1.DataSource = _bestandVerwalten.BestellungListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }

        private void Verpackt_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Bestellungen(Status.verpackt.ToString());
            this.dataGridView1.DataSource = _bestandVerwalten.BestellungListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }
        private void Reklamation_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Bestellungen(Status.storniert.ToString());
            this.dataGridView1.DataSource = _bestandVerwalten.BestellungListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }
        private void Artikel_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _artikelVerwaltung.Download();
            this.dataGridView1.DataSource = _artikelVerwaltung.ArtikelListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }
        private void Kunde_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _nutzer.KundenLaden();
            this.dataGridView1.DataSource = _nutzer.KundenListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }
        private void Mitarbeiter_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _nutzer.MitarbeiterLaden();
            this.dataGridView1.DataSource = _nutzer.MitarbeiterListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }

        private void Artikel_sortiment_button_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
            _bestandVerwalten.Angebot();
            this.dataGridView1.DataSource = _bestandVerwalten.BestandListe;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoResizeColumns();
        }

        private void Lager_button_Click(object sender, EventArgs e)
        {

        }

        private void best_button_Click(object sender, EventArgs e)
        {
            _artikelVerwaltung.Submit(_indexer.GetNewIndex(), _indexer.GetChIndex());
            _indexer = new DataGridBearbeiten();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _indexer.AddChange(e.RowIndex);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //_indexer.AddNew(e.RowIndex);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.DataSource == _bestandVerwalten.BestellungListe)
            {
                _bestandVerwalten.Warenkorb(_bestandVerwalten.BestellungListe[e.RowIndex]);
                this.dataGridView1.DataSource = _bestandVerwalten.WarenkorbListe;
            }
        }

        private void neu_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.DataSource == _bestandVerwalten.BestandListe)
            {
                _bestandVerwalten.BestandListe.Add(new Bestand());
                this.dataGridView1.ClearSelection();
                this.dataGridView1.DataSource = _bestandVerwalten.BestandListe;
            }
            if (this.dataGridView1.DataSource == _artikelVerwaltung.ArtikelListe)
            {
                _artikelVerwaltung.Upload(new Artikel());
                this.dataGridView1.ClearSelection();

            }
            if (this.dataGridView1.DataSource == _nutzer.KundenListe)
            {
                _nutzer.KundenListe.Add(new Adresse());
                this.dataGridView1.DataSource = _nutzer.KundenListe;
            }
            if (this.dataGridView1.DataSource == _nutzer.MitarbeiterListe)
            {
                _nutzer.MitarbeiterListe.Add(new Adresse());
                this.dataGridView1.DataSource = _nutzer.MitarbeiterListe;
            }
            
        }
    }
}
