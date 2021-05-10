using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Factory.Creators
{
    // Creator Interface
    public interface IStoredProductCreator
    {
        public abstract StoredProduct CreateStoredProduct();
    }
}
