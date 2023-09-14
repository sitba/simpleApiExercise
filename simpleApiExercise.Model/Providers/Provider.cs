namespace simpleApiExercise.Model.Providers
{
	public class Provider
	{
        public Provider() { }

        public Provider(int id, string name, string postalAddress, DateTime createdDate, string type)
        {
            Id = id;
            Name = name;
            PostalAddress = postalAddress;
            CreatedDate = createdDate;
            Type = type;
        }

        public int Id { get; set; }
		public string Name { get; set; }
		public string PostalAddress { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Type { get; set; }
    }
}