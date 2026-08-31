using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Mail;
using MasterFloor.Model;

namespace MasterFloor.UI.Views
{
    public partial class CreatePartnerWnd : Window
    {
        private MasterFloorEntities _masterFloor;
        private bool _isEditMode;
        private Partner _originalPartner;
        bool canChange = false;

        public CreatePartnerWnd(MasterFloorEntities masterFloor, bool isEditMode = false, Partner partner = null)
        {
            InitializeComponent();
            this._masterFloor = masterFloor;
            this._isEditMode = isEditMode;
            this._originalPartner = partner;

            LoadPartnerTypes();

            if (isEditMode && partner != null)
            {
                LoadPartnerData();
            }
        }
        private void LoadPartnerTypes()
        {
            cmbPartnerType.ItemsSource = _masterFloor.PartnerType.ToList();
            cmbPartnerType.DisplayMemberPath = "Name";
            cmbPartnerType.SelectedValuePath = "Id";
        }
        private void LoadPartnerData()
        {
            cmbPartnerType.SelectedValue = _originalPartner.TypeId;
            tbxName.Text = _originalPartner.CompanyName;
            tbxEmail.Text = _originalPartner.Email;
            tbxPhone.Text = _originalPartner.Phone;

            if (_originalPartner.Person != null)
            {
                tbxFullName.Text = $"{_originalPartner.Person.Surname} {_originalPartner.Person.FirstName} {_originalPartner.Person.LastName}";
            }
            tbxAddress.Text = _originalPartner.IndexAddress?.Number.ToString();
            tbxINN.Text = _originalPartner.INN;
            tbxRank.Text = _originalPartner.Raiting.ToString();
        }
        private bool IsEmailValid(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ClearFields()
        {
            tbxName.Clear();
            tbxEmail.Clear();
            tbxPhone.Clear();
            tbxFullName.Clear();
            tbxAddress.Clear();
            tbxINN.Clear();
            tbxRank.Clear();
            cmbPartnerType.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to go back? All unsaved data will be lost.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ClearFields();
                PartnersWnd partnersWnd = new PartnersWnd();
                partnersWnd.Show();
                Close();
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var address = ProcessAddress(tbxAddress.Text);
                if (_isEditMode)
                {
                    UpdatePartner();
                }
                else
                {
                    AddNewPartner();
                }
                _masterFloor.SaveChanges();
                ShowSuccessMessage();
                CloseAndShowPartnersWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private IndexAddress ProcessAddress(string addressText)
        {
            string addressNumber = addressText;
            if (addressText.Length != 6)
                throw new Exception("The address must be a 6‑digit number.");

            var address = _masterFloor.IndexAddress.FirstOrDefault(a => a.Number == addressNumber);
            if (address == null)
            {
                address = new IndexAddress { Number = addressNumber };
                _masterFloor.IndexAddress.Add(address);
            }
            return address;
        }
        private void ShowSuccessMessage()
        {
            MessageBox.Show(_isEditMode
                ? "Partner data successfully updated!"
                : "New partner successfully added!",
                "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CloseAndShowPartnersWindow()
        {
            new PartnersWnd().Show();
            Close();
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text) ||
                string.IsNullOrWhiteSpace(tbxEmail.Text) ||
                string.IsNullOrWhiteSpace(tbxPhone.Text) ||
                string.IsNullOrWhiteSpace(tbxFullName.Text) ||
                string.IsNullOrWhiteSpace(tbxINN.Text) ||
                string.IsNullOrWhiteSpace(tbxAddress.Text) ||
                string.IsNullOrWhiteSpace(tbxRank.Text) ||
                cmbPartnerType.SelectedItem == null)
            {
                MessageBox.Show("Not all fields are filled in", "Error",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!IsEmailValid(tbxEmail.Text))
            {
                MessageBox.Show("Enter the correct email address!",
                               "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(tbxRank.Text, out int rank) || rank < 0)
            {
                MessageBox.Show("Please enter a valid rating (a positive integer).");
                return false;
            }

            return true;
        }

        private void UpdatePartner()
        {
            if (_masterFloor == null || _originalPartner == null) return;

            var partnerUpd = _masterFloor.Partner
                .Include("Person")
                .Include("IndexAddress")
                .FirstOrDefault(p => p.Id == _originalPartner.Id);

            if (partnerUpd == null) return;

            partnerUpd.CompanyName = tbxName.Text;
            partnerUpd.Email = tbxEmail.Text;
            partnerUpd.Phone = tbxPhone.Text;
            partnerUpd.Raiting = int.Parse(tbxRank.Text);
            partnerUpd.TypeId = (int)cmbPartnerType.SelectedValue;
            partnerUpd.IndexAddress = ProcessAddress(tbxAddress.Text);
            partnerUpd.INN = tbxINN.Text;

            if (partnerUpd.Person != null)
            {
                var nameParts = tbxFullName.Text.Split(new[] { ' ' }, 3);
                if (partnerUpd.Person == null)
                {
                    partnerUpd.Person = new Person();
                    _masterFloor.Person.Add(partnerUpd.Person);
                }
                partnerUpd.Person.Surname = nameParts[0];
                partnerUpd.Person.FirstName = nameParts[1];
                partnerUpd.Person.LastName = nameParts.Length > 2 ? nameParts[2] : "";
            }

        }

        private void AddNewPartner()
        {
            var nameParts = tbxFullName.Text.Split(new[] { ' ' }, 3);
            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please enter your full name.", "Error",
                               MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newPerson = new Person
            {
                Surname = nameParts[0],
                FirstName = nameParts[1],
                LastName = nameParts.Length > 2 ? nameParts[2] : ""
            };

            var newAddress = new IndexAddress
            {
                Number = tbxAddress.Text
            };

            var newPartner = new Partner
            {
                CompanyName = tbxName.Text,
                Email = tbxEmail.Text,
                Phone = tbxPhone.Text,
                INN = tbxINN.Text,
                Raiting = int.Parse(tbxRank.Text),
                TypeId = (int)cmbPartnerType.SelectedValue,
                DirectorId = newPerson.Id,
                AddressId = newAddress.Id
            };

            _masterFloor.IndexAddress.Add(newAddress);
            _masterFloor.Person.Add(newPerson);
            _masterFloor.Partner.Add(newPartner);

            MessageBox.Show("The partner has been added successfully!", "Success",
                           MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
