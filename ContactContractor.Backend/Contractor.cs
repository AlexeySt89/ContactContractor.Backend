namespace ContactContractor.Domain
{
    public class Contractor
    {
        public Guid ContractorId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
    }
}
