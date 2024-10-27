namespace Web_App___Showcase.Entities
{
    /// <summary>
    ///     Represent Address for Restaurant id DB
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
