using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.Domain.Abstract
{
    public interface IElectronicPartRepository
    {
        IEnumerable<ElectronicPart> ElectronicParts { get; }

        void SaveItem(ElectronicPart electronicPart);
        ElectronicPart DeleteItem(int ElectronicItemID);
    }
}
