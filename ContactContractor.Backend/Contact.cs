namespace ContactContractor.Domain
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public Guid? ContractorId { get; set; }
        public Contractor Contractor { get; set; }
    }
}
