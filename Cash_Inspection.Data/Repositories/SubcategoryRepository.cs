﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Cash_Inspection.Data.Model.Interfaces;
using Cash_Inspection.Data.Model.Entities;


namespace Cash_Inspection.Data.Repositories
{
    //Subcategory Repository
    internal class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        internal SubcategoryRepository(DataContext context)
            : base(context)
        {
        }

        public Subcategory Get(Guid id)
        {
            return Set.Find(id);
        }

        public IList<Subcategory> GetAll(Guid catId)
        {
            return Set.FirstOrDefault(x => x.Category.Id == catId).Category.Subcategories.SkipWhile(x => x.Category.Id != catId).AsEnumerable()
                    .OrderBy(x => x.Category.Id).ToList();
        }
     

    }
}