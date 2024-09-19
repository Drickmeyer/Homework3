using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1
{
    public class TVShow
    {
        public string Actors { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string RuntimeInMinutes { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Writer { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string TotalSeasons { get; set; }

        /// <summary>
        /// Default/Empty Constructor
        /// </summary>
        public TVShow()
        {
            Actors = string.Empty;
            Awards = string.Empty;
            Country = string.Empty;
            Director = string.Empty;
            Genre = string.Empty;
            Language = string.Empty;
            Plot = string.Empty;
            Poster = string.Empty;
            Rated = string.Empty;
            Released = string.Empty;
            RuntimeInMinutes = string.Empty;
            Title = string.Empty;
            Type = string.Empty;
            Writer = string.Empty;
            Year = string.Empty;
            ImdbID = string.Empty;
            ImdbRating = string.Empty;
            ImdbVotes = string.Empty;
            TotalSeasons = string.Empty;
        }

        public TVShow(string line)
        {
            //   1         2           3 ...
            //Actors	Awards	Country	Director	Genre	Language	Plot	Poster	Rated	Released	Runtime in minutes	Title	Type	Writer	Year	imdbID	imdbRating	imdbVotes	totalSeasons
            var pieces = line.Split('\t');

            Actors = pieces[1];
            Awards = pieces[2];
            Country = pieces[3];
            Director = pieces[4];
            Genre = pieces[5];
            Language = pieces[6];
            Plot = pieces[7];
            Poster = pieces[8];
            Rated = pieces[9];
            Released = pieces[10];
            RuntimeInMinutes = pieces[11];
            Title = pieces[12];
            Type = pieces[13];
            Writer = pieces[14];
            Year = pieces[15];
            ImdbID = pieces[16];
            ImdbRating = pieces[17];
            ImdbVotes = pieces[18];
            TotalSeasons = pieces[19];
        }

        public override string ToString()
        {
            return $"{Title} rated {Rated} created in {Country} in {Language} languages.";
        }

    }
}
