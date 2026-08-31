using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MasterFloor.Model;
using MasterFloor.UI.UC;

namespace MasterFloor.UI.Views
{
    public partial class PartnersWnd : Window
    {
        private MasterFloorEntities masterFloor = new MasterFloorEntities();

        public PartnersWnd()
        {
            InitializeComponent();
            LoadPartners();

            nameFilter.SelectionChanged += SearchButton_Click;
            nameFilter.TextChanged += SearchButton_Click;

            innFilter.SelectionChanged += SearchButton_Click;
            innFilter.TextChanged += SearchButton_Click;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPartners();
        }
        private void LoadPartners()
        {
            try
            {
                PartnersStackPanel.Children.Clear();
                bool skipNameFilter = string.IsNullOrEmpty(nameFilter.Text);
                bool skipINNFilter = string.IsNullOrEmpty(innFilter.Text);


                var partnerList = masterFloor.Partner
                .Include("PartnerType")
                .Include("Person")
                .Include("Discount")
                .Where(x => skipNameFilter || x.CompanyName.Contains(nameFilter.Text))
                .Where(x => skipINNFilter || x.INN.Contains(innFilter.Text))
                .ToList();

                cmbPartnerID.ItemsSource = partnerList;
                cmbPartnerID.DisplayMemberPath = "CompanyName";
                cmbPartnerID.SelectedValuePath = "Id";

                foreach (var partner in partnerList)
                {
                    var partnerControl = new PartnerCard(masterFloor);

                    partnerControl.GetPartner(partner);
                    PartnersStackPanel.Children.Add(partnerControl);
                }
            }
            catch
            {
                MessageBox.Show($"An error occurred while connecting to the database", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Exit the program?", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePartnerWnd addEditPartner = new CreatePartnerWnd(masterFloor, false, null);
            addEditPartner.Show();
            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPartnerID.SelectedItem == null)
            {
                MessageBox.Show("Please select a partner to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedPartner = cmbPartnerID.SelectedItem as Partner;
            if (selectedPartner != null)
            {
                var editWindow = new CreatePartnerWnd(masterFloor, true, selectedPartner);
                editWindow.Show();
                LoadPartners();
                Close();
            }
        }

        private void btnGetHistory_Click(object sender, RoutedEventArgs e)
        {
            RealizationHistoryWnd wnd = new RealizationHistoryWnd();
            wnd.Show();
            Close();
        }
    }
}
