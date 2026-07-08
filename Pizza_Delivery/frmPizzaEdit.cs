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
    public partial class frmPizzaEdit : Form
    {
        private PizzaRepository _pizzaRepository;
        private Pizza _pizzaEditare;
        private bool _isUpdateOperation;

        public frmPizzaEdit(Guid? id = null)
        {
            InitializeComponent();

            _pizzaRepository = new PizzaRepository();

            IncarcaDimensiuni();

            if (id == null)
            {
                _isUpdateOperation = false;

                _pizzaEditare = new Pizza()
                {
                    IdPizza = Guid.NewGuid()
                };

                Text = "Adaugă pizza";
            }
            else
            {
                _isUpdateOperation = true;

                _pizzaEditare = _pizzaRepository.GetById(id.Value);

                if (_pizzaEditare == null)
                {
                    MessageBox.Show("Pizza nu a fost găsită.");
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                Text = "Editează pizza";

                txtDenumire.Text = _pizzaEditare.Denumire;
                cboDimensiune.SelectedItem = _pizzaEditare.Dimensiune;
                txtPret.Text = _pizzaEditare.Pret.ToString("0.00", CultureInfo.InvariantCulture);
                txtIngrediente.Text = _pizzaEditare.Ingrediente;
            }
        }

        private void IncarcaDimensiuni()
        {
            cboDimensiune.Items.Clear();

            cboDimensiune.Items.Add("Mica");
            cboDimensiune.Items.Add("Medie");
            cboDimensiune.Items.Add("Mare");

            cboDimensiune.SelectedIndex = -1;
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            _pizzaEditare.Denumire = txtDenumire.Text.Trim();
            _pizzaEditare.Dimensiune = cboDimensiune.SelectedItem.ToString();
            _pizzaEditare.Pret = decimal.Parse(txtPret.Text.Trim(), CultureInfo.InvariantCulture);
            _pizzaEditare.Ingrediente = txtIngrediente.Text.Trim();

            if (_isUpdateOperation)
                _pizzaRepository.Update(_pizzaEditare);
            else
                _pizzaRepository.Add(_pizzaEditare);

            DialogResult = DialogResult.OK;
        }

        private bool ValidateForm()
        {
            epPizza.Clear();

            bool esteValid = true;

            if (string.IsNullOrWhiteSpace(txtDenumire.Text))
            {
                epPizza.SetError(txtDenumire, "Denumirea este obligatorie.");
                esteValid = false;
            }

            if (cboDimensiune.SelectedIndex < 0)
            {
                epPizza.SetError(cboDimensiune, "Dimensiunea este obligatorie.");
                esteValid = false;
            }

            decimal pret;

            if (string.IsNullOrWhiteSpace(txtPret.Text))
            {
                epPizza.SetError(txtPret, "Prețul este obligatoriu.");
                esteValid = false;
            }
            else if (!decimal.TryParse(txtPret.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out pret))
            {
                epPizza.SetError(txtPret, "Prețul trebuie să fie un număr valid. Exemplu: 30.50");
                esteValid = false;
            }
            else if (pret <= 0)
            {
                epPizza.SetError(txtPret, "Prețul trebuie să fie mai mare decât 0.");
                esteValid = false;
            }

            return esteValid;
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}