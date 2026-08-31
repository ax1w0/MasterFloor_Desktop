using System.Linq;
using MasterFloor.Model;

namespace MasterFloor.Class
{
    public static class DiscountCalculator
    {
        private static MasterFloorEntities masterFloor;

        public static int CalculateDiscount(int partnerID)
        {
            using (var context = new MasterFloorEntities())
            {
                var sales = context.RealizationHistory
                    .Where(rh => rh.PartnerId == partnerID).ToList();

                int totalSales = sales.Sum(rh => rh.Count);

                int discount = 0;

                if (totalSales < 10000)
                    discount = 0;
                else if (totalSales < 50000)
                    discount = 5;
                else if (totalSales < 300000)
                    discount = 10;
                else
                    discount = 15;

                return discount;
            }
        }
    }
}
