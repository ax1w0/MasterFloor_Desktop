using System;
using System.Linq;
using MasterFloor.Model;

namespace MasterFloor.Class
{
    public class ProductionCalculator
    {
        private static MasterFloorEntities masterFloor;

        public static int CalculateRequiredMaterial(int productTypeId, int materialTypeId, int quantity, double param1, double param2)
        {
            using (var context = new MasterFloorEntities())
            {
                if (quantity <= 0 || param1 <= 0 || param2 <= 0)
                    return -1;

                var productType = context.ProductType.FirstOrDefault(pt => pt.Id == productTypeId);
                if (productType == null)
                    return -1;

                var materialType = context.MaterialType.FirstOrDefault(mt => mt.Id == materialTypeId);
                if (materialType == null)
                    return -1;

                double materialPerUnit = param1 * param2 * (double)productType.ProductionIndex;

                double defectPercent = (double)materialType.DefectPercent;
                double totalMaterial = materialPerUnit * quantity * defectPercent;

                int requiredMaterial = (int)Math.Ceiling(totalMaterial);

                return requiredMaterial;
            }
        }
    }
}
