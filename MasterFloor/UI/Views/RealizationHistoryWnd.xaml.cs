using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MasterFloor.Model;

namespace MasterFloor.UI.Views
{
    public partial class RealizationHistoryWnd : Window
    {
        private MasterFloorEntities masterFloor = new MasterFloorEntities();
        public RealizationHistoryWnd()
        {
            InitializeComponent();
            var partnerName = masterFloor.Partner.ToList();
            cmbPartnerName.ItemsSource = partnerName;
            cmbPartnerName.DisplayMemberPath = "CompanyName";
            cmbPartnerName.SelectedValuePath = "ID";
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PartnersWnd partnersWnd = new PartnersWnd();
            partnersWnd.Show();
            Close();
        }

        private void cmbPartnerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPartnerName.SelectedItem is Partner selectedPartner)
            {
                var realizationData = masterFloor.RealizationHistory
                    .Where(rh => rh.PartnerId == selectedPartner.Id)
                    .Join(masterFloor.Product,
                          rh => rh.ProductId,
                          p => p.Id,
                          (rh, p) => new
                          {
                              ProductName = p.Name,
                              rh.Count,
                              rh.Date
                          })
                    .ToList();
                dgHistorySales.ItemsSource = realizationData;
            }
            else
            {
                MessageBox.Show($"No sales history found for this partner", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                dgHistorySales.ItemsSource = null;
            }
        }
    }
}
