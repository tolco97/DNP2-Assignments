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
                return Orders?.Sum(order => order.Product.Price) ?? 0;
            }
        }

        #endregion

        #region Methods

        public bool HasOrderedProduct(string productName)
        {
            return Orders != null && Orders.Any(order => string.Equals(order.Product.Name, productName));
        }

        #endregion
    }
}