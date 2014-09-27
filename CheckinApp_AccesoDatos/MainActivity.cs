using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using SQLite;

namespace CheckinApp_AccesoDatos
{
	[Activity (Label = "CheckinApp Datos", MainLauncher = true, Icon = "@drawable/icon", Theme="@android:style/Theme.Holo.Light")]
	public class MainActivity : Activity
	{
		private ListView listViewMovies;
		private EditText editTextNewMovie;
		private Button buttonAddMovie;
		private ArrayAdapter adapter;

		private SQLiteConnection db;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			editTextNewMovie = FindViewById<EditText> (Resource.Id.editTextNewMovie);
			buttonAddMovie = FindViewById<Button> (Resource.Id.buttonAddMovie);

			listViewMovies = FindViewById<ListView> (Resource.Id.listViewMovies);
			adapter = new ArrayAdapter (this, Resource.Layout.MovieItem, new string[] { });

			listViewMovies.Adapter = adapter;

			string dbPath = Path.Combine (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "checkinapp.db3");

			db = new SQLiteConnection (dbPath);
			db.CreateTable<Movie> ();

			buttonAddMovie.Click += (object sender, EventArgs e) => {
				string newMovie = editTextNewMovie.Text.Trim();

				if (newMovie != "") {
					Movie movie = new Movie();
					movie.Title = newMovie;

					db.Insert(movie);
					adapter.Add(movie.Title);
				}
			};

			var table = db.Table<Movie> ();

			foreach (Movie record in table) {
				adapter.Add (record.Title);
			}
		}
	}
}


