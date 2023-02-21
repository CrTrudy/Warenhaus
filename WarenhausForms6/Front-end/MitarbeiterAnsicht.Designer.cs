namespace WarenhausForms6
{
    partial class MitarbeiterAnsicht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public  void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.name_label = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.nutzer_button = new System.Windows.Forms.Button();
            this.sortiment_button = new System.Windows.Forms.Button();
            this.Bestand = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.best_button = new System.Windows.Forms.Button();
            this.bestellungen_button = new System.Windows.Forms.Button();
            this.suche_textbox = new System.Windows.Forms.TextBox();
            this.suche_button = new System.Windows.Forms.Button();
            this.bestellt_button = new System.Windows.Forms.Button();
            this.bezahlt_button = new System.Windows.Forms.Button();
            this.verpackt_button = new System.Windows.Forms.Button();
            this.versendet_button = new System.Windows.Forms.Button();
            this.reklamation_button = new System.Windows.Forms.Button();
            this.kunde_button = new System.Windows.Forms.Button();
            this.mitarbeiter_button = new System.Windows.Forms.Button();
            this.artikel_button = new System.Windows.Forms.Button();
            this.lager_button = new System.Windows.Forms.Button();
            this.artikel_sortiment_button = new System.Windows.Forms.Button();
            this.Neu_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(12, 9);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(39, 15);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "Name";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(781, 70);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // nutzer_button
            // 
            this.nutzer_button.Location = new System.Drawing.Point(49, 104);
            this.nutzer_button.Name = "nutzer_button";
            this.nutzer_button.Size = new System.Drawing.Size(88, 23);
            this.nutzer_button.TabIndex = 2;
            this.nutzer_button.Text = "Nutzer";
            this.nutzer_button.UseVisualStyleBackColor = true;
            this.nutzer_button.Click += new System.EventHandler(this.Nutzer_button_Click);
            // 
            // sortiment_button
            // 
            this.sortiment_button.Location = new System.Drawing.Point(49, 133);
            this.sortiment_button.Name = "sortiment_button";
            this.sortiment_button.Size = new System.Drawing.Size(88, 23);
            this.sortiment_button.TabIndex = 4;
            this.sortiment_button.Text = "Sortiment";
            this.sortiment_button.UseVisualStyleBackColor = true;
            this.sortiment_button.Click += new System.EventHandler(this.Sortiment_button_Click);
            // 
            // Bestand
            // 
            this.Bestand.Location = new System.Drawing.Point(49, 162);
            this.Bestand.Name = "Bestand";
            this.Bestand.Size = new System.Drawing.Size(88, 23);
            this.Bestand.TabIndex = 5;
            this.Bestand.Text = "Bestand";
            this.Bestand.UseVisualStyleBackColor = true;
            this.Bestand.Click += new System.EventHandler(this.Bestand_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(143, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(606, 278);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // best_button
            // 
            this.best_button.Location = new System.Drawing.Point(621, 388);
            this.best_button.Name = "best_button";
            this.best_button.Size = new System.Drawing.Size(75, 23);
            this.best_button.TabIndex = 13;
            this.best_button.Text = "Bestätigen";
            this.best_button.UseVisualStyleBackColor = true;
            this.best_button.Click += new System.EventHandler(this.best_button_Click);
            // 
            // bestellungen_button
            // 
            this.bestellungen_button.Location = new System.Drawing.Point(49, 191);
            this.bestellungen_button.Name = "bestellungen_button";
            this.bestellungen_button.Size = new System.Drawing.Size(88, 23);
            this.bestellungen_button.TabIndex = 14;
            this.bestellungen_button.Text = "Bestellungen";
            this.bestellungen_button.UseVisualStyleBackColor = true;
            this.bestellungen_button.Click += new System.EventHandler(this.Bestellungen_button_Click);
            // 
            // suche_textbox
            // 
            this.suche_textbox.Location = new System.Drawing.Point(173, 71);
            this.suche_textbox.Name = "suche_textbox";
            this.suche_textbox.Size = new System.Drawing.Size(121, 23);
            this.suche_textbox.TabIndex = 15;
            this.suche_textbox.Tag = "";
            this.suche_textbox.Text = "Suche";
            // 
            // suche_button
            // 
            this.suche_button.Location = new System.Drawing.Point(143, 70);
            this.suche_button.Name = "suche_button";
            this.suche_button.Size = new System.Drawing.Size(24, 23);
            this.suche_button.TabIndex = 16;
            this.suche_button.Text = "S";
            this.suche_button.UseVisualStyleBackColor = true;
            // 
            // bestellt_button
            // 
            this.bestellt_button.Location = new System.Drawing.Point(300, 71);
            this.bestellt_button.Name = "bestellt_button";
            this.bestellt_button.Size = new System.Drawing.Size(75, 23);
            this.bestellt_button.TabIndex = 17;
            this.bestellt_button.Text = "Bestellt";
            this.bestellt_button.UseVisualStyleBackColor = true;
            this.bestellt_button.Click += new System.EventHandler(this.Warenkorb_button_Click);
            // 
            // bezahlt_button
            // 
            this.bezahlt_button.Location = new System.Drawing.Point(381, 71);
            this.bezahlt_button.Name = "bezahlt_button";
            this.bezahlt_button.Size = new System.Drawing.Size(75, 23);
            this.bezahlt_button.TabIndex = 18;
            this.bezahlt_button.Text = "Bezahlt";
            this.bezahlt_button.UseVisualStyleBackColor = true;
            this.bezahlt_button.Click += new System.EventHandler(this.Bezahlt_button_Click);
            // 
            // verpackt_button
            // 
            this.verpackt_button.Location = new System.Drawing.Point(462, 70);
            this.verpackt_button.Name = "verpackt_button";
            this.verpackt_button.Size = new System.Drawing.Size(75, 23);
            this.verpackt_button.TabIndex = 19;
            this.verpackt_button.Text = "Verpackt";
            this.verpackt_button.UseVisualStyleBackColor = true;
            this.verpackt_button.Click += new System.EventHandler(this.Verpackt_button_Click);
            // 
            // versendet_button
            // 
            this.versendet_button.Location = new System.Drawing.Point(543, 70);
            this.versendet_button.Name = "versendet_button";
            this.versendet_button.Size = new System.Drawing.Size(75, 23);
            this.versendet_button.TabIndex = 20;
            this.versendet_button.Text = "Versendet";
            this.versendet_button.UseVisualStyleBackColor = true;
            this.versendet_button.Click += new System.EventHandler(this.Versendet_button_Click);
            // 
            // reklamation_button
            // 
            this.reklamation_button.Location = new System.Drawing.Point(624, 70);
            this.reklamation_button.Name = "reklamation_button";
            this.reklamation_button.Size = new System.Drawing.Size(88, 23);
            this.reklamation_button.TabIndex = 21;
            this.reklamation_button.Text = "Reklamation";
            this.reklamation_button.UseVisualStyleBackColor = true;
            this.reklamation_button.Click += new System.EventHandler(this.Reklamation_button_Click);
            // 
            // kunde_button
            // 
            this.kunde_button.Location = new System.Drawing.Point(300, 71);
            this.kunde_button.Name = "kunde_button";
            this.kunde_button.Size = new System.Drawing.Size(75, 23);
            this.kunde_button.TabIndex = 22;
            this.kunde_button.Text = "Kunde";
            this.kunde_button.UseVisualStyleBackColor = true;
            this.kunde_button.Click += new System.EventHandler(this.Kunde_button_Click);
            // 
            // mitarbeiter_button
            // 
            this.mitarbeiter_button.Location = new System.Drawing.Point(381, 71);
            this.mitarbeiter_button.Name = "mitarbeiter_button";
            this.mitarbeiter_button.Size = new System.Drawing.Size(75, 23);
            this.mitarbeiter_button.TabIndex = 23;
            this.mitarbeiter_button.Text = "Mitarbeiter";
            this.mitarbeiter_button.UseVisualStyleBackColor = true;
            this.mitarbeiter_button.Click += new System.EventHandler(this.Mitarbeiter_button_Click);
            // 
            // artikel_button
            // 
            this.artikel_button.Location = new System.Drawing.Point(300, 71);
            this.artikel_button.Name = "artikel_button";
            this.artikel_button.Size = new System.Drawing.Size(75, 23);
            this.artikel_button.TabIndex = 24;
            this.artikel_button.Text = "Artikel";
            this.artikel_button.UseVisualStyleBackColor = true;
            this.artikel_button.Click += new System.EventHandler(this.Artikel_button_Click);
            // 
            // lager_button
            // 
            this.lager_button.Location = new System.Drawing.Point(381, 71);
            this.lager_button.Name = "lager_button";
            this.lager_button.Size = new System.Drawing.Size(75, 23);
            this.lager_button.TabIndex = 25;
            this.lager_button.Text = "Lager";
            this.lager_button.UseVisualStyleBackColor = true;
            this.lager_button.Click += new System.EventHandler(this.Lager_button_Click);
            // 
            // artikel_sortiment_button
            // 
            this.artikel_sortiment_button.Location = new System.Drawing.Point(300, 71);
            this.artikel_sortiment_button.Name = "artikel_sortiment_button";
            this.artikel_sortiment_button.Size = new System.Drawing.Size(75, 23);
            this.artikel_sortiment_button.TabIndex = 26;
            this.artikel_sortiment_button.Text = "Artikel";
            this.artikel_sortiment_button.UseVisualStyleBackColor = true;
            this.artikel_sortiment_button.Click += new System.EventHandler(this.Artikel_sortiment_button_Click);
            // 
            // Neu_button
            // 
            this.Neu_button.Location = new System.Drawing.Point(543, 388);
            this.Neu_button.Name = "Neu_button";
            this.Neu_button.Size = new System.Drawing.Size(75, 23);
            this.Neu_button.TabIndex = 27;
            this.Neu_button.Text = "Neu";
            this.Neu_button.UseVisualStyleBackColor = true;
            this.Neu_button.Click += new System.EventHandler(this.neu_button_Click);
            // 
            // MitarbeiterAnsicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 520);
            this.Controls.Add(this.Neu_button);
            this.Controls.Add(this.artikel_sortiment_button);
            this.Controls.Add(this.lager_button);
            this.Controls.Add(this.artikel_button);
            this.Controls.Add(this.mitarbeiter_button);
            this.Controls.Add(this.kunde_button);
            this.Controls.Add(this.reklamation_button);
            this.Controls.Add(this.versendet_button);
            this.Controls.Add(this.verpackt_button);
            this.Controls.Add(this.bezahlt_button);
            this.Controls.Add(this.bestellt_button);
            this.Controls.Add(this.suche_button);
            this.Controls.Add(this.suche_textbox);
            this.Controls.Add(this.bestellungen_button);
            this.Controls.Add(this.best_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Bestand);
            this.Controls.Add(this.sortiment_button);
            this.Controls.Add(this.nutzer_button);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.name_label);
            this.Name = "MitarbeiterAnsicht";
            this.Text = "Mitarbeiter";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label name_label;
        private MonthCalendar monthCalendar1;
        private Button nutzer_button;
        private Button sortiment_button;
        private Button Bestand;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private Button best_button;
        private Button bestellungen_button;
        private TextBox suche_textbox;
        private Button suche_button;
        private Button bestellt_button;
        private Button bezahlt_button;
        private Button verpackt_button;
        private Button versendet_button;
        private Button reklamation_button;
        private Button kunde_button;
        private Button mitarbeiter_button;
        private Button artikel_button;
        private Button lager_button;
        private Button artikel_sortiment_button;
        private Button Neu_button;
    }
}