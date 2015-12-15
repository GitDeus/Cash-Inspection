
using Cash_Inspection.Data.Model;
using Cash_Inspection.Data.Model.Entities;
using Cash_Inspection.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash_Inspection.Data.Model.Interfaces
{
   public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        IList<Subcategory> GetAll(Guid catId);
        Subcategory Get(Guid id);
    }
}
