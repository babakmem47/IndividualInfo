namespace IndividualInfo.Dtos
{
    public class IndividualDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? Gender { get; set; }

        public string TelDirect { get; set; }

        public string TelDakheli { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public SematDto SematDto { get; set; }

        public bool? Deleted { get; set; }
    }
}