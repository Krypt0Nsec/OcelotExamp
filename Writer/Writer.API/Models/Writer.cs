namespace Writer.API.Models
{
	public class Writer
	{
		//Domain, entitiy, model, (poco)
		public int Id { get; set; }

		public string Name { get; set; }

		public Writer()
		{
			
		}

		public Writer(int Id, string Name) 
		{
			this.Id = Id;
			this.Name = Name;
		}
	}
}
