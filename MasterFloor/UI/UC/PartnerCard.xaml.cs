using System;
using System.Windows.Controls;
using MasterFloor.Model;
using MasterFloor.Class;

namespace MasterFloor.UI.UC
{
    public partial class PartnerCard : UserControl
    {
        private static MasterFloorEntities _masterFloor;

        public PartnerCard(MasterFloorEntities masterFloor)
        {
            InitializeComponent();
            _masterFloor = masterFloor;

            int productTypeId = 1;
            int materialTypeId = 1;
            int quantity = 100;
            double param1 = 1.5;
            double param2 = 2.0;

            int requiredMaterial = ProductionCalculator.CalculateRequiredMaterial(productTypeId, materialTypeId, quantity, param1, param2);

            if (requiredMaterial == -1)
                Console.WriteLine("Data error.");
            else
                Console.WriteLine($"Required amount of material: {requiredMaterial}");
        }
        public void GetPartner(Partner partner)
        {
            string partnerName = partner.CompanyName ?? "No name";
            string partnerType = partner.PartnerType != null ? partner.PartnerType.Name : "No type";
            tbPartnerName.Text = $"{partnerType} | {partnerName}";

            string fullName = $"{partner.Person.Surname} " +
                $"{partner.Person.FirstName} {partner.Person.LastName}";
            tbDirector.Text = fullName;

            string phoneNumber = partner.Phone;
            phoneNumber = $"+{phoneNumber.Substring(0, 1)} {phoneNumber.Substring(1, 3)} " +
                $"{phoneNumber.Substring(4, 3)} {phoneNumber.Substring(7, 2)} {phoneNumber.Substring(9, 2)}";

            tbPhone.Text = phoneNumber;

            tbRank.Text = $"Rating: {partner.Raiting}";

            int discount = DiscountCalculator.CalculateDiscount(partner.Id);
            tbDiscount.Text = $" {discount}%";
        }
    }
}
