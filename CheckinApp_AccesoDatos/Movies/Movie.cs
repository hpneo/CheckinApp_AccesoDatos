using System;

using SQLite;

namespace CheckinApp_AccesoDatos
{
	[Table("Movies")]
	public class Movie
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		[Column("Title")] 
		public string Title { get; set; }

		public Movie ()
		{
		}
	}
}

