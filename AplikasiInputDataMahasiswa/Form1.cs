using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        // deklarasi objek collection
        private List<Mahasiswa> list = new List<Mahasiswa>();
        // constructor
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }
        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
        }
        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                // inputan selain angka
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
          
            {
                // membuat objek mahasiswa 
                Mahasiswa mhs = new Mahasiswa();
                // set nilai masing-masing propertynya
                // berdasarkan inputan yang ada di form
                mhs.Nim = txtNim.Text;
                mhs.Nama = txtNama.Text;
                mhs.Kelas = txtKelas.Text;
                mhs.Nilai = int.Parse(txtNilai.Text);
                // tambahkan objek mahasiswa ke dalam collection
                list.Add(mhs);
                var msg = "Data mahasiswa berhasil disimpan.";
                // tampilkan dialog informasi
                MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                // reset form input
                ResetForm();
            }


        }
    }
}
