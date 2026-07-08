using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Delivery
{
    public partial class frmComenzi : Form
    {
        private ComandaRepository _comandaRepository;

        public frmComenzi()
        {
            InitializeComponent();

            _comandaRepository = new ComandaRepository();

            int latimeDisponibila = lvComenzi.ClientSize.Width;

            lvComenzi.Columns.Clear();

            lvComenzi.Columns.Add("Client", (int)(0.12 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Telefon", (int)(0.10 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Email", (int)(0.12 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Produse", (int)(0.20 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Data comenzii", (int)(0.12 * latimeDisponibila), HorizontalAlignment.Center);
            lvComenzi.Columns.Add("Observatii", (int)(0.10 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Adresa", (int)(0.16 * latimeDisponibila), HorizontalAlignment.Left);
            lvComenzi.Columns.Add("Total", (int)(0.08 * latimeDisponibila), HorizontalAlignment.Right); // <--- Coloana nouă de Total

            btnEditeaza.Enabled = false;
            btnSterge.Enabled = false;

            RefreshList();
        }

        private void RefreshList()
        {
            lvComenzi.Items.Clear();

            foreach (var c in _comandaRepository.GetAll())
            {
                ListViewItem item = new ListViewItem(c.Client);
                item.SubItems.Add(c.Telefon);
                item.SubItems.Add(c.Email);
                item.SubItems.Add(c.Produse);
                item.SubItems.Add(c.DataComenzii.ToString("dd.MM.yyyy HH:mm"));
                item.SubItems.Add(c.Observatii);
                item.SubItems.Add(c.Adresa);
                item.SubItems.Add(c.Total.ToString("0.00") + " lei");

                item.Tag = c;

                lvComenzi.Items.Add(item);
            }
        }

        private void lvComenzi_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esteSelectat = lvComenzi.SelectedItems.Count > 0;
            btnEditeaza.Enabled = esteSelectat;
            btnSterge.Enabled = esteSelectat;
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (lvComenzi.SelectedItems.Count == 0)
                return;

            var comanda = lvComenzi.SelectedItems[0].Tag as ComandaAfisare;
            if (comanda == null)
                return;

            if (MessageBox.Show( $"Sunteți sigur că vreți să ștergeți comanda clientului {comanda.Client}?", "Confirmare", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _comandaRepository.Delete(comanda.IdComanda);
                RefreshList();
            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            using (frmComandaEditare frm = new frmComandaEditare())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void btnEditeaza_Click(object sender, EventArgs e)
        {
            if (lvComenzi.SelectedItems.Count == 0)
                return;

            var comanda = lvComenzi.SelectedItems[0].Tag as ComandaAfisare;
            if (comanda == null)
                return;

            using (frmComandaEditare frm = new frmComandaEditare(comanda.IdComanda))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }
    }
}