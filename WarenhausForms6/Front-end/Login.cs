using System.Security.Cryptography;

namespace WarenhausForms6
{
    public partial class Login : Form
    {
        DBAcess _acess;
        IAccount _account;
        MitarbeiterAnsicht _ansicht;
        public Login()
        {
            _acess = new DBAcess("root", "");
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (Zugriffsverwaltung.AccountZugriff(_acess, true, textBox1.Text, SHA1.GetSha1(textBox2.Text)))
                {
                    _account = new MitarbeiterAccount(textBox1.Text);
                    _ansicht = new MitarbeiterAnsicht();
                    _ansicht.Show();
                    this.Visible = false;
                }
            }
            else
            {
                if (Zugriffsverwaltung.AccountZugriff(_acess, false, textBox1.Text, SHA1.GetSha1(textBox2.Text)))
                {
                }
            }
        }
    }
}