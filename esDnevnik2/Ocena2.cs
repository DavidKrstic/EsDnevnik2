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
    public partial class Ocena2 : Form
    {
        DataTable dt_ocena;
        public Ocena2()
        {
            InitializeComponent();
        }

        private void Ocena2_Load(object sender, EventArgs e)
        {
            cmb_GodinaPopulate();
            cmb_predmet.Enabled = false;
            cmb_odeljenje.Enabled = false;
            cmb_ucenik.Enabled = false;
            cmb_ocena.Enabled = false;
            cmb_ocena.Items.Add(1);
            cmb_ocena.Items.Add(2);
            cmb_ocena.Items.Add(3);
            cmb_ocena.Items.Add(4);
            cmb_ocena.Items.Add(5);
            cmb_ProfesorPopulate();
        }

        private void cmb_GodinaPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Skolska_godina", veza);
            DataTable dt_godina = new DataTable();
            adapter.Fill(dt_godina);
            cmb_godina.DataSource = dt_godina;
            cmb_godina.ValueMember = "id";
            cmb_godina.DisplayMember = "naziv";
            cmb_godina.SelectedValue = 2;
        }

        private void cmb_godina_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_godina.IsHandleCreated && cmb_godina.Focused)
            {
                cmb_ProfesorPopulate();
            }
        }
        private void cmb_ProfesorPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("select distinct osoba.id as id, ime + ' ' + prezime as naziv from osoba");
            naredba.Append(" join raspodela on osoba.id = nastavnik_id");
            naredba.Append(" where godina_id = " + cmb_godina.SelectedValue.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            DataTable dt_profesor = new DataTable();
            adapter.Fill(dt_profesor);
            cmb_profesor.DataSource = dt_profesor;
            cmb_profesor.ValueMember = "id";
            cmb_profesor.DisplayMember = "naziv";
            cmb_profesor.SelectedIndex = -1;
        }

        private void cmb_profesor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_profesor.IsHandleCreated && cmb_profesor.Focused)
            {
                cmb_PredmetPopulate();
                cmb_predmet.Enabled = true;
                cmb_odeljenje.Enabled = false;
                cmb_odeljenje.SelectedIndex = -1;
                cmb_ucenik.SelectedIndex = -1;
                cmb_ucenik.Enabled = false;
                cmb_ocena.SelectedIndex = -1;
                cmb_ocena.Enabled = false;
                dt_ocena = new DataTable();
                Grid_Ocene.DataSource = dt_ocena;
            }
        }

        private void cmb_PredmetPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("SELECT DISTINCT predmet.id as id, naziv FROM predmet");
            naredba.Append(" JOIN raspodela ON predmet.id = predmet_id");
            naredba.Append(" WHERE godina_id = " + cmb_godina.SelectedValue.ToString());
            naredba.Append(" and nastavnik_id = " + cmb_profesor.SelectedValue.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            DataTable dt_predmet = new DataTable();
            adapter.Fill(dt_predmet);
            cmb_predmet.DataSource = dt_predmet;
            cmb_predmet.ValueMember = "id";
            cmb_predmet.DisplayMember = "naziv";
            cmb_predmet.SelectedIndex = -1;
        }

        private void cmb_predmet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_predmet.IsHandleCreated && cmb_predmet.Focused)
            {
                cmb_OdeljenjePopulate();
                cmb_odeljenje.Enabled = true;
                cmb_odeljenje.SelectedIndex = -1;
                cmb_ucenik.SelectedIndex = -1;
                cmb_ucenik.Enabled = false;
                cmb_ocena.SelectedIndex = -1;
                cmb_ocena.Enabled = false;
                dt_ocena = new DataTable();
                Grid_Ocene.DataSource = dt_ocena;

            }
        }

        private void cmb_OdeljenjePopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("select distinct odeljenje.id as id, STR(razred) + '-' + indeks as naziv from odeljenje");
            naredba.Append(" join raspodela on odeljenje.id = odeljenje_id");
            naredba.Append(" where raspodela.godina_id = " + cmb_godina.SelectedValue.ToString());
            naredba.Append(" and nastavnik_id = " + cmb_profesor.SelectedValue.ToString());
            naredba.Append(" and predmet_id = " + cmb_predmet.SelectedValue.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            DataTable dt_odeljenje = new DataTable();
            adapter.Fill(dt_odeljenje);
            cmb_odeljenje.DataSource = dt_odeljenje;
            cmb_odeljenje.ValueMember = "id";
            cmb_odeljenje.DisplayMember = "naziv";
            cmb_odeljenje.SelectedIndex = -1;
        }

        private void cmb_UcenikPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("SELECT osoba.id AS id, ime + ' ' + prezime AS naziv FROM osoba ");
            naredba.Append(" join upisnica on osoba.id = osoba_id ");
            naredba.Append(" where upisnica.odeljenje_id = " + cmb_odeljenje.SelectedValue.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            DataTable dt_ucenik = new DataTable();
            adapter.Fill(dt_ucenik);
            cmb_ucenik.DataSource = dt_ucenik;
            cmb_ucenik.ValueMember = "id";
            cmb_ucenik.DisplayMember = "naziv";
            cmb_ucenik.SelectedIndex = -1;
        }

        private void cmb_odeljenje_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_odeljenje.IsHandleCreated && cmb_odeljenje.Focused)
            {
                cmb_UcenikPopulate();
                cmb_ucenik.Enabled = true;
                cmb_ocena.Enabled = true;
                GridPopulate();
                UcenikOcenaIdSet(0);
            }
        }

        private void GridPopulate()
        {
            StringBuilder naredba = new StringBuilder("select ocena.id as id, ime + ' ' + prezime as naziv, ocena, ucenik_id, datum from osoba");
            naredba.Append(" join ocena on osoba.id = ucenik_id");
            naredba.Append(" join raspodela on raspodela_id = raspodela.id");
            naredba.Append(" where raspodela_id = ");
            naredba.Append(" (select id from raspodela ");
            naredba.Append(" where godina_id = " + cmb_godina.SelectedValue.ToString());
            naredba.Append(" and nastavnik_id = " + cmb_profesor.SelectedValue.ToString());
            naredba.Append(" and predmet_id = " + cmb_predmet.SelectedValue.ToString());
            naredba.Append(" and odeljenje_id = " + cmb_odeljenje.SelectedValue.ToString() + " )");
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            dt_ocena = new DataTable();
            adapter.Fill(dt_ocena);
            Grid_Ocene.DataSource = dt_ocena;
            Grid_Ocene.AllowUserToAddRows = false;
            Grid_Ocene.Columns["ucenik_id"].Visible = false;
        }

        private void Grid_Ocene_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                UcenikOcenaIdSet(e.RowIndex);
            }
        }

        private void UcenikOcenaIdSet(int broj_sloga)
        {
            if (dt_ocena.Rows.Count > 0)
            {
                cmb_ucenik.SelectedValue = dt_ocena.Rows[broj_sloga]["ucenik_id"];
                cmb_ocena.SelectedItem = dt_ocena.Rows[broj_sloga]["ocena"];
                txt_Id.Text = dt_ocena.Rows[broj_sloga]["id"].ToString();
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("select id from raspodela");
            naredba.Append(" where godina_id = " + cmb_godina.SelectedValue.ToString());
            naredba.Append(" and nastavnik_id = " + cmb_profesor.SelectedValue.ToString());
            naredba.Append(" and predmet_id = " + cmb_predmet.SelectedValue.ToString());
            naredba.Append(" and odeljenje_id = " + cmb_odeljenje.SelectedValue.ToString());
            SqlConnection veza = Konekcija.Connect();
            SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
            int id_raspodele = 0;
            try 
            {
                veza.Open();
                id_raspodele = (int)Komanda.ExecuteScalar();
                veza.Close();
            }
            catch(Exception Greska)
            {
                MessageBox.Show(Greska.Message);
            }
            if(id_raspodele > 0)
            {
                naredba = new StringBuilder("insert into ocena (datum, raspodela_id, ucenik_id, ocena) values('");
                DateTime datum = Datum.Value;
                naredba.Append(datum.ToString("yyyy-MM-dd") + "', '");
                naredba.Append(id_raspodele.ToString() + "', '");
                naredba.Append(cmb_ucenik.SelectedValue.ToString() + "', '");
                naredba.Append(cmb_ocena.SelectedItem.ToString() + "')");
                Komanda = new SqlCommand(naredba.ToString(), veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch(Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                GridPopulate();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txt_Id.Text) > 0)
            {
                DateTime datum = Datum.Value;
                StringBuilder naredba = new StringBuilder("update ocena set ");
                naredba.Append(" ucenik_id = '" + cmb_ucenik.SelectedValue.ToString() + "', ");
                naredba.Append(" ocena = '" + cmb_ocena.SelectedItem.ToString() + "', ");
                naredba.Append(" datum = '" + datum.ToString("yyyy-MM-dd") + "' ");
                naredba.Append(" where id = " + txt_Id.Text);
                SqlConnection veza = Konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                }
                catch(Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
                GridPopulate();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_Id.Text) > 0)
            {
                string naredba = "delete from ocena where id = " + txt_Id.Text;
                SqlConnection veza = Konekcija.Connect();
                SqlCommand Komanda = new SqlCommand(naredba.ToString(), veza);
                try
                {
                    veza.Open();
                    Komanda.ExecuteNonQuery();
                    veza.Close();
                    GridPopulate();
                    UcenikOcenaIdSet(0);
                }
                catch(Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }
        }
    }
}
