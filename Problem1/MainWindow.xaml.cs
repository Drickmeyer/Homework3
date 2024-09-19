using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TVShow> TVShows = new List<TVShow>();
        private char[] CharactersToTrim = { '"', ' ' };
        public MainWindow()
        {
            InitializeComponent();


            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                TVShows.Add(new TVShow(line));
            }

            PopulateListBox(TVShows);
            PopulateRatingFilter();
            PopulateCountryFilter();
            PopulateLanguageFilter();

        }

        private void PopulateLanguageFilter()
        {
            cboLanguage.Items.Add("All");
            cboLanguage.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                var values = show.Language.Split(',');

                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!cboLanguage.Items.Contains(cleanedValue))
                    {
                        cboLanguage.Items.Add(cleanedValue);
                    }
                }

            }
        }

        private void PopulateCountryFilter()
        {
            cboCountry.Items.Add("All");
            cboCountry.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                var values = show.Country.Split(',');

                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!cboCountry.Items.Contains(cleanedValue))
                    {
                        cboCountry.Items.Add(cleanedValue);
                    }
                }

            }
        }

        private void PopulateRatingFilter()
        {
            cboRating.Items.Add("All");
            cboRating.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                if (string.IsNullOrWhiteSpace(show.Rated))
                {
                    continue;
                }
                string cleanedValue = show.Rated.Trim();
                if (!cboRating.Items.Contains(cleanedValue))
                {
                    cboRating.Items.Add(cleanedValue);
                }
            }
        }

        private void PopulateListBox(List<TVShow> tVShows)
        {
            lstShows.Items.Clear();

            foreach (var show in tVShows)
            {
                lstShows.Items.Add(show);
            }
        }

        private void cboRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void UpdateDataForFilters()
        {
            if (cboCountry.SelectedValue is null
             || cboLanguage.SelectedValue is null
             || cboRating.SelectedValue is null)
            {
                return;
            }

            List<TVShow> filteredShows;
            filteredShows = FilterRating(TVShows);
            filteredShows = FilterCountry(filteredShows);
            filteredShows = FilterLanguage(filteredShows);

            PopulateListBox(filteredShows);

        }

        private List<TVShow> FilterCountry(List<TVShow> shows)
        {
            string country = cboCountry.SelectedValue.ToString();

            List<TVShow> filteredShows = new List<TVShow>();

            foreach (var show in shows)
            {

                if (country.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Country.Contains(country))
                {
                    filteredShows.Add(show);
                }
            }

            return filteredShows;
        }

        private List<TVShow> FilterLanguage(List<TVShow> shows)
        {
            string language = cboLanguage.SelectedValue.ToString();

            List<TVShow> filteredShows = new List<TVShow>();

            foreach (var show in shows)
            {

                if (language.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Language.Contains(language))
                {
                    filteredShows.Add(show);
                }
            }

            return filteredShows;
        }

        private List<TVShow> FilterRating(List<TVShow> shows)
        {
            string rating = cboRating.SelectedValue.ToString();

            List<TVShow> filteredShows = new List<TVShow>();

            foreach (var show in shows)
            {

                if (rating.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Rated.Contains(rating))
                {
                    filteredShows.Add(show);
                }
            }

            return filteredShows;
        }

        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void cboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cboRating.SelectedIndex = 0;
            cboLanguage.SelectedIndex = 0;
            cboCountry.SelectedIndex = 0;
        }

        private void lstShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TVShow selectedShow = (TVShow)lstShows.SelectedItem;
            ShowDetailsWindow wnd = new ShowDetailsWindow();
            wnd.SetupWindow(selectedShow);
            wnd.ShowDialog();
        }
    }
}
