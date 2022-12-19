using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace esDnevnik2
{
    public partial class Osoba : Form
    {
        
        int broj_sloga = 0;
        DataTable tabela;
        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from osoba", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }
        private void Tb_Load()
        {
            if(tabela.Rows.Count == 0)
            {
                tB_id.Text = "";
                tB_ime.Text = "";
                tB_prezime.Text = "";
                tB_adresa.Text = "";
                tB_jmbg.Text = "";
                tB_email.Text = "";
                tB_pass.Text = "";
                tB_uloga.Text = "";
                btn_delete.Enabled = false;
            }
            else
            {
                tB_id.Text = tabela.Rows[broj_sloga]["id"].ToString();
                tB_ime.Text = tabela.Rows[broj_sloga]["ime"].ToString();
                tB_prezime.Text = tabela.Rows[broj_sloga]["prezime"].ToString();
                tB_adresa.Text = tabela.Rows[broj_sloga]["adresa"].ToString();
                tB_jmbg.Text = tabela.Rows[broj_sloga]["jmbg"].ToString();
                tB_email.Text = tabela.Rows[broj_sloga]["email"].ToString();
                tB_pass.Text = tabela.Rows[broj_sloga]["pass"].ToString();
                tB_uloga.Text = tabela.Rows[broj_sloga]["uloga"].ToString();
                btn_delete.Enabled = true;
            }
            if(broj_sloga == 0)
            {
                btn_first.Enabled = false;
                btn_prev.Enabled = false;
            }
            else
            {
                btn_first.Enabled = true;
                btn_prev.Enabled = true;
            }
            if(broj_sloga == tabela.Rows.Count - 1)
            {
                btn_last.Enabled = false;
                btn_next.Enabled = false;
            }
            else
            {
                btn_last.Enabled = true;
                btn_next.Enabled = true;
            }
        }
        public Osoba()
        {
            InitializeComponent();
        }

        private void Osoba_Load(object sender, EventArgs e)
        {
            Load_Data();
            Tb_Load();
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            Tb_Load();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            Tb_Load();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            Tb_Load();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count - 1;
            Tb_Load();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            
            StringBuilder Naredba = new StringBuilder("INSERT INTO osoba (ime, prezime, adresa, jmbg, email, pass, uloga) values ('");
            Naredba.Append(tB_ime.Text + "', '");
            Naredba.Append(tB_prezime.Text + "', '");
            Naredba.Append(tB_adresa.Text + "', '");
            Naredba.Append(tB_jmbg.Text + "', '");
            Naredba.Append(tB_email.Text + "', '");
            Naredba.Append(tB_pass.Text + "', '");
            Naredba.Append(tB_uloga.Text + "')");
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            Load_Data();
            broj_sloga = tabela.Rows.Count - 1;
            Tb_Load();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("UPDATE osoba SET ");
            Naredba.Append("ime = '" + tB_ime.Text + "', ");
            Naredba.Append("prezime = '" + tB_prezime.Text + "', ");
            Naredba.Append("adresa = '" + tB_adresa.Text + "', ");
            Naredba.Append("jmbg = '" + tB_jmbg.Text + "', ");
            Naredba.Append("email = '" + tB_email.Text + "', ");
            Naredba.Append("pass = '" + tB_pass.Text + "', ");
            Naredba.Append("uloga = '" + tB_uloga.Text + "' ");
            Naredba.Append("WHERE id = " + tB_id.Text);
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba.ToString(), veza);
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            Load_Data();
            Tb_Load();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string Naredba = "DELETE FROM osoba WHERE id = " + tB_id.Text;
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(Naredba.ToString(), veza);
            Boolean brisano = false;
            try
            {
                veza.Open();
                Komanda.ExecuteNonQuery();
                veza.Close();
                brisano = true;
            }
            catch (Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            if(brisano)
            {
                Load_Data();
                if (broj_sloga > 0) broj_sloga--;
            }
            Load_Data();
            Tb_Load();
        }
    }
}
