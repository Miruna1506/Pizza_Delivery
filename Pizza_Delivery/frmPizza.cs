using System;
using System.Windows.Forms;

namespace Pizza_Delivery
{
    public partial class frmPizza : Form
    {
        private PizzaRepository _pizzaRepository;

        public frmPizza()
        {
            InitializeComponent();

            _pizzaRepository = new PizzaRepository();

            int latimeDisponibila = lvPizza.ClientSize.Width;

            lvPizza.Columns.Clear();

            lvPizza.Columns.Add("Denumire",
                (int)(0.20 * latimeDisponibila),
                HorizontalAlignment.Left);

            lvPizza.Columns.Add("Dimensiune",
                (int)(0.15 * latimeDisponibila),
                HorizontalAlignment.Center);

            lvPizza.Columns.Add("Preț",
                (int)(0.10 * latimeDisponibila),
                HorizontalAlignment.Right);

            lvPizza.Columns.Add("Ingrediente",
                (int)(0.55 * latimeDisponibila),
                HorizontalAlignment.Left);

            btnEditeaza.Enabled = false;
            btnSterge.Enabled = false;

            RefreshList();
        }

        private void RefreshList()
        {
            lvPizza.Items.Clear();

            foreach (var pizza in _pizzaRepository.GetAll())
            {
                ListViewItem item = new ListViewItem(pizza.Denumire);

                item.SubItems.Add(pizza.Dimensiune);
                item.SubItems.Add(pizza.Pret.ToString("0.00") + " lei");
                item.SubItems.Add(pizza.Ingrediente);

                item.Tag = pizza;

                lvPizza.Items.Add(item);
            }
        }

        private void lvPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esteSelectata = lvPizza.SelectedItems.Count > 0;

            btnEditeaza.Enabled = esteSelectata;
            btnSterge.Enabled = esteSelectata;
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            using (frmPizzaEdit frm = new frmPizzaEdit())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void btnEditeaza_Click(object sender, EventArgs e)
        {
            if (lvPizza.SelectedItems.Count == 0)
                return;

            Pizza pizza = lvPizza.SelectedItems[0].Tag as Pizza;

            if (pizza == null)
                return;

            using (frmPizzaEdit frm = new frmPizzaEdit(pizza.IdPizza))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (lvPizza.SelectedItems.Count == 0)
                return;

            Pizza pizza = lvPizza.SelectedItems[0].Tag as Pizza;

            if (pizza == null)
                return;

            if (MessageBox.Show(
                $"Sunteți sigur că vreți să ștergeți pizza {pizza.Denumire}?",
                "Confirmare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _pizzaRepository.Delete(pizza.IdPizza);

                    RefreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Pizza nu poate fi ștearsă deoarece există comenzi asociate.\n\n" + ex.Message,
                        "Eroare",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}