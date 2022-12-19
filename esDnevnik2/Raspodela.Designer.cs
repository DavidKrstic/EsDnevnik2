namespace esDnevnik2
{
    partial class Raspodela
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
        private void InitializeComponent()
        {
            this.cB_nastavnik = new System.Windows.Forms.ComboBox();
            this.cB_godina = new System.Windows.Forms.ComboBox();
            this.cB_predmet = new System.Windows.Forms.ComboBox();
            this.cB_odeljenje = new System.Windows.Forms.ComboBox();
            this.lbl_godina = new System.Windows.Forms.Label();
            this.lbl_nastavnik = new System.Windows.Forms.Label();
            this.lbl_predmet = new System.Windows.Forms.Label();
            this.lbl_odeljenje = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.tB_id = new System.Windows.Forms.TextBox();
            this.btn_first = new System.Windows.Forms.Button();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cB_nastavnik
            // 
            this.cB_nastavnik.FormattingEnabled = true;
            this.cB_nastavnik.Location = new System.Drawing.Point(348, 139);
            this.cB_nastavnik.Name = "cB_nastavnik";
            this.cB_nastavnik.Size = new System.Drawing.Size(121, 21);
            this.cB_nastavnik.TabIndex = 0;
            // 
            // cB_godina
            // 
            this.cB_godina.FormattingEnabled = true;
            this.cB_godina.Location = new System.Drawing.Point(348, 98);
            this.cB_godina.Name = "cB_godina";
            this.cB_godina.Size = new System.Drawing.Size(121, 21);
            this.cB_godina.TabIndex = 1;
            // 
            // cB_predmet
            // 
            this.cB_predmet.FormattingEnabled = true;
            this.cB_predmet.Location = new System.Drawing.Point(348, 182);
            this.cB_predmet.Name = "cB_predmet";
            this.cB_predmet.Size = new System.Drawing.Size(121, 21);
            this.cB_predmet.TabIndex = 2;
            // 
            // cB_odeljenje
            // 
            this.cB_odeljenje.FormattingEnabled = true;
            this.cB_odeljenje.Location = new System.Drawing.Point(348, 225);
            this.cB_odeljenje.Name = "cB_odeljenje";
            this.cB_odeljenje.Size = new System.Drawing.Size(121, 21);
            this.cB_odeljenje.TabIndex = 3;
            // 
            // lbl_godina
            // 
            this.lbl_godina.AutoSize = true;
            this.lbl_godina.Location = new System.Drawing.Point(265, 107);
            this.lbl_godina.Name = "lbl_godina";
            this.lbl_godina.Size = new System.Drawing.Size(41, 13);
            this.lbl_godina.TabIndex = 4;
            this.lbl_godina.Text = "Godina";
            // 
            // lbl_nastavnik
            // 
            this.lbl_nastavnik.AutoSize = true;
            this.lbl_nastavnik.Location = new System.Drawing.Point(265, 147);
            this.lbl_nastavnik.Name = "lbl_nastavnik";
            this.lbl_nastavnik.Size = new System.Drawing.Size(55, 13);
            this.lbl_nastavnik.TabIndex = 5;
            this.lbl_nastavnik.Text = "Nastavnik";
            // 
            // lbl_predmet
            // 
            this.lbl_predmet.AutoSize = true;
            this.lbl_predmet.Location = new System.Drawing.Point(265, 190);
            this.lbl_predmet.Name = "lbl_predmet";
            this.lbl_predmet.Size = new System.Drawing.Size(46, 13);
            this.lbl_predmet.TabIndex = 6;
            this.lbl_predmet.Text = "Predmet";
            // 
            // lbl_odeljenje
            // 
            this.lbl_odeljenje.AutoSize = true;
            this.lbl_odeljenje.Location = new System.Drawing.Point(265, 234);
            this.lbl_odeljenje.Name = "lbl_odeljenje";
            this.lbl_odeljenje.Size = new System.Drawing.Size(51, 13);
            this.lbl_odeljenje.TabIndex = 7;
            this.lbl_odeljenje.Text = "Odeljenje";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(265, 69);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(18, 13);
            this.lbl_id.TabIndex = 8;
            this.lbl_id.Text = "ID";
            // 
            // tB_id
            // 
            this.tB_id.Location = new System.Drawing.Point(348, 62);
            this.tB_id.Name = "tB_id";
            this.tB_id.Size = new System.Drawing.Size(121, 20);
            this.tB_id.TabIndex = 9;
            // 
            // btn_first
            // 
            this.btn_first.Location = new System.Drawing.Point(37, 313);
            this.btn_first.Name = "btn_first";
            this.btn_first.Size = new System.Drawing.Size(75, 36);
            this.btn_first.TabIndex = 10;
            this.btn_first.Text = "<<";
            this.btn_first.UseVisualStyleBackColor = true;
            this.btn_first.Click += new System.EventHandler(this.btn_first_Click);
            // 
            // btn_prev
            // 
            this.btn_prev.Location = new System.Drawing.Point(142, 313);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(75, 36);
            this.btn_prev.TabIndex = 11;
            this.btn_prev.Text = "<";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(244, 313);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 36);
            this.btn_insert.TabIndex = 12;
            this.btn_insert.Text = "Dodaj";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(348, 313);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 36);
            this.btn_update.TabIndex = 13;
            this.btn_update.Text = "Izmeni";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(455, 313);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 36);
            this.btn_delete.TabIndex = 14;
            this.btn_delete.Text = "Obrisi";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(564, 313);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 36);
            this.btn_next.TabIndex = 15;
            this.btn_next.Text = ">";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_last
            // 
            this.btn_last.Location = new System.Drawing.Point(669, 313);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(75, 36);
            this.btn_last.TabIndex = 16;
            this.btn_last.Text = ">>";
            this.btn_last.UseVisualStyleBackColor = true;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // Raspodela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_last);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.btn_first);
            this.Controls.Add(this.tB_id);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_odeljenje);
            this.Controls.Add(this.lbl_predmet);
            this.Controls.Add(this.lbl_nastavnik);
            this.Controls.Add(this.lbl_godina);
            this.Controls.Add(this.cB_odeljenje);
            this.Controls.Add(this.cB_predmet);
            this.Controls.Add(this.cB_godina);
            this.Controls.Add(this.cB_nastavnik);
            this.Name = "Raspodela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raspodela";
            this.Load += new System.EventHandler(this.Raspodela_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cB_nastavnik;
        private System.Windows.Forms.ComboBox cB_godina;
        private System.Windows.Forms.ComboBox cB_predmet;
        private System.Windows.Forms.ComboBox cB_odeljenje;
        private System.Windows.Forms.Label lbl_godina;
        private System.Windows.Forms.Label lbl_nastavnik;
        private System.Windows.Forms.Label lbl_predmet;
        private System.Windows.Forms.Label lbl_odeljenje;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox tB_id;
        private System.Windows.Forms.Button btn_first;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_last;
    }
}