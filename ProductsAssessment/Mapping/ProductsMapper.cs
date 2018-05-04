namespace ProductsAssessment.Mapping
{
    using DataLayer.Models;
    using ProductsAssessment.Models;
    using System;
    using System.Collections.Generic;

    public class ProductsMapper
    {
        //Mapping a products data object to a products presentation objects
        public static ProductsPO MapDoToPO(ProductsDO from)
        {
            ProductsPO to = new ProductsPO();
            try
            {
                to.ProductName = from.ProductName;
                to.ProductQuanity = from.ProductQuanity;
                to.UnitPrice = from.UnitPrice;
                to.UnitsInStock = from.UnitsInStock;
                to.UnitsOnOrder = from.UnitsOnOrder;
            }
            catch (Exception e)
            {
                throw e;
            }
            return to;
        }


        //Putting the products data object to a products presentation object list.
        public static List<ProductsPO> MapDoToPO(List<ProductsDO> from)
        {
            List<ProductsPO> to = new List<ProductsPO>();

            try
            {
                foreach (ProductsDO item in from)
                {
                    ProductsPO mappedItem = MapDoToPO(item);
                    to.Add(mappedItem);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return to;
        }
    }
}