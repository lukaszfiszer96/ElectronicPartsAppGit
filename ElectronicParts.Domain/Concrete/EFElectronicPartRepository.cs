using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.Domain.Concrete
{
    public class EFElectronicPartRepository : IElectronicPartRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<ElectronicPart> ElectronicParts { get { return context.ElectronicParts; } }

        public void SaveItem(ElectronicPart electronicPart)
        {
            if (electronicPart.ElectronicPartID == 0)
                context.ElectronicParts.Add(electronicPart);
            else
            {
                ElectronicPart oldPart = context.ElectronicParts.Find(electronicPart.ElectronicPartID);
                string a = oldPart.Category;
                if (oldPart != null)
                {

                    oldPart.MaxPower = electronicPart.MaxPower;
                    oldPart.Name = electronicPart.Name;
                    oldPart.Price = electronicPart.Price;
                    oldPart.Value = electronicPart.Value;
                    if (electronicPart.Category != null)
                        oldPart.Category = electronicPart.Category;
                    oldPart.Tolerance = electronicPart.Tolerance;
                }
            }

            context.SaveChanges();
        }

        public ElectronicPart DeleteItem(int EleID)
        {
            ElectronicPart electronicPartDelete = context.ElectronicParts.Find(EleID);
            if (electronicPartDelete != null)
            {
                context.ElectronicParts.Remove(electronicPartDelete);
                context.SaveChanges();
            }
            return electronicPartDelete;
        }
    }
}
