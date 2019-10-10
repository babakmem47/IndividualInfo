namespace IndividualInfo.Dtos
{
    public class WorkPlaceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WorkPlaceTypeDto WorkPlaceTypeDto { get; set; }

        //public byte WorkPlaceTypeDtoId { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string FieldOfActivity { get; set; }
    }
}