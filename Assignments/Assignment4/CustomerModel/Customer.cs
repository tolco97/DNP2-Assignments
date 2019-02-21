using System.Linq;

namespace DNP2.Assignment4.CustomerModel
{
    public class Customer
    {
        #region Fields

        public string City;
        public string Name;
        public Order[] Orders;

        #endregion

        #region Properties

        public decimal OrdersPrice
        {
            get
            {
                if (Orders == null)
                {
                    return 0;
                }
                return Orders.Sum(order => order.Product.Price);
            }
        }

        #endregion

        #region Methods

        public bool HasOrderedProduct(string productName)
        {
            if (Orders == null)
            {
                return false;
            }
            return Orders.Any(order => string.Equals(order.Product.Name, productName));
        }

        #endregion
    }
}