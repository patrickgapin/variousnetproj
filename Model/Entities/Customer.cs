
namespace Model.Entities
{
    public class Customer: Person
    {
        public string CustomerID { get; set; }
        public string PurchaseCode { get; set; }

        public bool IsNew { get; set; }
        public string Status { get; set; }
    }
}
