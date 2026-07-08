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
    public partial class frmComandaEditare : Form
    {
        private ComandaRepository _comandaRepository;
        private ClientRepository _clientRepository;
        private AdresaRepository _adresaRepository;
        private PizzaRepository _pizzaRepository;
        private RandComandaRepository _randComandaRepository;

        private Comanda _comanda;
        private Client _client;
        private Adresa _adresa;

        private List<RandComanda> _randuriComanda;

        private bool _isUpdateOperation;

        public frmComandaEditare(Guid? id = null)
        {
            InitializeComponent();

            _comandaRepository = new ComandaRepository();
            _clientRepository = new ClientRepository();
            _adresaRepository = new AdresaRepository();
            _pizzaRepository = new PizzaRepository();
            _randComandaRepository = new RandComandaRepository();

            _randuriComanda = new List<RandComanda>();

            IncarcaPizza();

            if (id == null)
            {
                _isUpdateOperation = false;

                _comanda = new Comanda();
                _client = new Client();
                _adresa = new Adresa();

                Text = "Adauga comanda";
            }
            else
            {
                _isUpdateOperation = true;

                _comanda = _comandaRepository.GetById(id.Value);
                _client = _clientRepository.GetById(_comanda.IdClient);
                _adresa = _adresaRepository.GetById(_comanda.IdAdresa);

                Text = "Editare comanda";

                txtNume.Text = _client.Nume;
                txtPrenume.Text = _client.Prenume;
                txtTelefon.Text = _client.Telefon;
                txtEmail.Text = _client.Email;

                txtStrada.Text = _adresa.Strada;
                txtNumar.Text = _adresa.Numar;
                txtOras.Text = _adresa.Oras;
                txtJudet.Text = _adresa.Judet;

                dtpDataComenzii.Value = _comanda.DataComenzii;
                txtObservatii.Text = _comanda.Observatii;

                IncarcaRanduriComanda();
            }

            RefreshListaRanduri();
        }

        private void IncarcaPizza()
        {
            cboPizza.DataSource = null;

            cboPizza.DisplayMember = "Afisare";
            cboPizza.ValueMember = "IdPizza";

            cboPizza.DataSource = _pizzaRepository.GetAll();

            cboPizza.SelectedIndex = -1;
        }

        private void IncarcaRanduriComanda()
        {
            var randuriAfisare = _randComandaRepository.GetByComandaId(_comanda.IdComanda);

            _randuriComanda.Clear();

            foreach (var r in randuriAfisare)
            {
                RandComanda rand = new RandComanda();
                rand.IdRandComanda = r.IdRandComanda;
                rand.IdComanda = r.IdComanda;
                rand.IdPizza = r.IdPizza;
                rand.Cantitate = r.Cantitate;

                _randuriComanda.Add(rand);
            }
        }

        private void RefreshListaRanduri()
        {
            lstRanduriComanda.Items.Clear();

            foreach (var rand in _randuriComanda)
            {
                Pizza pizza = _pizzaRepository.GetById(rand.IdPizza);

                if (pizza != null)
                {
                    lstRanduriComanda.Items.Add(
                        $"{pizza.Denumire} - {pizza.Dimensiune} x {rand.Cantitate}");
                }
            }
        }

        private bool Validare()
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Numele este obligatoriu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenume.Text))
            {
                MessageBox.Show("Prenumele este obligatoriu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                MessageBox.Show("Telefonul este obligatoriu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Emailul este obligatoriu");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStrada.Text))
            {
                MessageBox.Show("Strada este obligatorie");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumar.Text))
            {
                MessageBox.Show("Numarul este obligatoriu");
                return false;
            }

            if (_randuriComanda.Count == 0)
            {
                MessageBox.Show("Adaugati cel putin o pizza in comanda");
                return false;
            }

            return true;
        }

        private void btnAdaugaPizza_Click(object sender, EventArgs e)
        {
            Pizza pizzaSelectata = cboPizza.SelectedItem as Pizza;

            if (pizzaSelectata == null)
            {
                MessageBox.Show("Selectati pizza");
                return;
            }

            RandComanda rand = new RandComanda();
            rand.IdComanda = _comanda.IdComanda;
            rand.IdPizza = pizzaSelectata.IdPizza;
            rand.Cantitate = (int)nudCantitate.Value;

            _randuriComanda.Add(rand);

            RefreshListaRanduri();

            cboPizza.SelectedIndex = -1;
            nudCantitate.Value = 1;
        }

        private void btnStergePizza_Click(object sender, EventArgs e)
        {
            if (lstRanduriComanda.SelectedIndex < 0)
            {
                MessageBox.Show("Selectati o pizza din comanda.");
                return;
            }

            _randuriComanda.RemoveAt(lstRanduriComanda.SelectedIndex);
            RefreshListaRanduri();
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (!Validare())
                return;

            _client.Nume = txtNume.Text.Trim();
            _client.Prenume = txtPrenume.Text.Trim();
            _client.Telefon = txtTelefon.Text.Trim();
            _client.Email = txtEmail.Text.Trim();

            if (_isUpdateOperation)
                _clientRepository.Update(_client);
            else
                _clientRepository.Insert(_client);

            _adresa.IdClient = _client.IdClient;
            _adresa.Strada = txtStrada.Text.Trim();
            _adresa.Numar = txtNumar.Text.Trim();
            _adresa.Oras = txtOras.Text.Trim();
            _adresa.Judet = txtJudet.Text.Trim();

            if (_isUpdateOperation)
                _adresaRepository.Update(_adresa);
            else
                _adresaRepository.Insert(_adresa);

            _comanda.IdClient = _client.IdClient;
            _comanda.IdAdresa = _adresa.IdAdresa;
            _comanda.DataComenzii = dtpDataComenzii.Value;
            _comanda.Observatii = txtObservatii.Text.Trim();

            if (_isUpdateOperation)
                _comandaRepository.Update(_comanda);
            else
                _comandaRepository.Add(_comanda);

            _randComandaRepository.DeleteByComandaId(_comanda.IdComanda);

            foreach (var rand in _randuriComanda)
            {
                rand.IdComanda = _comanda.IdComanda;
                _randComandaRepository.Add(rand);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}