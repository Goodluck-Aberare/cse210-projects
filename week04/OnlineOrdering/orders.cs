using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        private Customer customer;
        private List<Product> products = new List<Product>();

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double TotalCost()
        {
            double productTotal = 0;

            foreach (var p in products)
                productTotal += p.TotalCost();

            double shipping = customer.LivesInUSA() ? 5 : 35;

            return productTotal + shipping;
        }

        public string PackingLabel()
        {
            string label = "PACKING LABEL:\n";

            foreach (var p in products)
            {
                label += $"- {p.GetName()} (ID: {p.GetProductId()})\n";
            }

            return label;
        }

        public string ShippingLabel()
        {
            return $"SHIPPING LABEL:\n{customer.GetName()}\n{customer.GetAddress().FullAddress()}";
        }
    }
}
