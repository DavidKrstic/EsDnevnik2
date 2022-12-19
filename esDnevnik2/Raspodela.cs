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
    public partial class Raspodela : Form
    {
        DataTable raspodela;
        int broj_sloga = 0;
        public Raspodela()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from raspodela", veza);
            raspodela = new DataTable();
            adapter.Fill(raspodela);
        }
        private void ComboFill()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter;
            DataTable dt_godina, dt_nastavnik, dt_predmet, dt_odeljenje;
            adapter = new SqlDataAdapter("Select * from skolska_godina", veza);
            dt_godina = new DataTable();
            adapter.Fill(dt_godina);

            dt_nastavnik = new DataTable();
            adapter = new SqlDataAdapter("Select id, ime + prezime as naziv from osoba where uloga = 2", veza);
            adapter.Fill(dt_nastavnik);

            dt_predmet = new DataTable();
            adapter = new SqlDataAdapter("Select id, naziv from predmet", veza);
            adapter.Fill(dt_predmet);

            dt_odeljenje = new DataTable();
            adapter = new SqlDataAdapter("Select id, STR(razred) + '-' + indeks as naziv from odeljenje", veza);
            adapter.Fill(dt_odeljenje);

            cB_godina.DataSource = dt_godina;
            cB_godina.ValueMember = "id";
            cB_godina.DisplayMember = "naziv";
            

            cB_nastavnik.DataSource = dt_nastavnik;
            cB_nastavnik.ValueMember = "id";
            cB_nastavnik.DisplayMember = "naziv";
           

            cB_predmet.DataSource = dt_predmet;
            cB_predmet.ValueMember = "id";
            cB_predmet.DisplayMember = "naziv";
            

            cB_odeljenje.DataSource = dt_odeljenje;
            cB_odeljenje.ValueMember = "id";
            cB_odeljenje.DisplayMember = "naziv";
            

            tB_id.Text = raspodela.Rows[broj_sloga]["id"].ToString();

            if (raspodela.Rows.Count == 0)
            {
                cB_godina.SelectedValue = -1;
                cB_nastavnik.SelectedValue = -1;
                cB_predmet.SelectedValue = -1;
                cB_odeljenje.SelectedValue = -1;
            }
            else
            {
                cB_godina.SelectedValue = raspodela.Rows[broj_sloga]["godina_id"];
                cB_nastavnik.SelectedValue = raspodela.Rows[broj_sloga]["nastavnik_id"];
                cB_predmet.SelectedValue = raspodela.Rows[broj_sloga]["predmet_id"];
                cB_odeljenje.SelectedValue = raspodela.Rows[broj_sloga]["odeljenje_id"];
            }
            if (broj_sloga == 0)
            {
                btn_first.Enabled = false;
                btn_prev.Enabled = false;
            }
            else
            {
                btn_first.Enabled = true;
                btn_prev.Enabled = true;
            }
            if (broj_sloga == raspodela.Rows.Count - 1)
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
        private void Raspodela_Load(object sender, EventArgs e)
        {
            Load_Data();
            ComboFill();
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            ComboFill();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            ComboFill();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            ComboFill();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            broj_sloga = raspodela.Rows.Count - 1;
            ComboFill();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("INSERT INTO raspodela (godina_id, nastavnik_id, predmet_id, odeljenje_id) values ('");
            Naredba.Append(cB_godina.SelectedValue + "', '");
            Naredba.Append(cB_nastavnik.SelectedValue + "', '");
            Naredba.Append(cB_predmet.SelectedValue + "', '");
            Naredba.Append(cB_odeljenje.SelectedValue + "')");
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
            broj_sloga = raspodela.Rows.Count - 1;
            ComboFill();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            StringBuilder Naredba = new StringBuilder("UPDATE raspodela SET ");
            Naredba.Append("godina_id = '" + cB_godina.SelectedValue + "', ");
            Naredba.Append("nastavnik_id = '" + cB_nastavnik.SelectedValue + "', ");
            Naredba.Append("predmet_id = '" + cB_predmet.SelectedValue + "', ");
            Naredba.Append("odeljenje_id = '" + cB_odeljenje.SelectedValue + "' ");
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
            ComboFill();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string Naredba = "DELETE FROM raspodela WHERE id = " + tB_id.Text;
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
            if (brisano)
            {
                Load_Data();
                if (broj_sloga > 0) broj_sloga--;
            }
            Load_Data();
            ComboFill();
        }
    }
}
