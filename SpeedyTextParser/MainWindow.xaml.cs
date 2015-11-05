using System.Windows;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace SpeedyTextParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Set string for parsing the text
        public static string parsingType = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Clear textboxes
            before.Text = "";
            after.Text = "";
        }

        private void Emails_Checked(object sender, RoutedEventArgs e)
        {
            //Clear textbox for result
            try
            {
                after.Text = "";
            }
            catch { }

            //Set parsing type
            parsingType = "Email";
        }

        private void URLs_Checked(object sender, RoutedEventArgs e)
        {
            //Clear textbox for result
            try
            {
                after.Text = "";
            }
            catch { }

            //Set parsing type
            parsingType = "URL";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (parsingType == "Email")
            {
                try {
                    before.SelectAll();
                    string a = before.Text;

                    Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
                    Match match;

                    List<string> results = new List<string>();
                    for (match = reg.Match(a); match.Success; match = match.NextMatch())
                    {
                        if (!(results.Contains(match.Value)))
                            results.Add(match.Value);
                    }

                    string[] result = results.ToArray();
                    string separator = "\n";

                    string i = string.Join(separator, result);
                    after.Text = i;
                
                }
                catch
                {

                }
                
            }
            else if (parsingType == "URL")
            {
                try
                {
                    before.SelectAll();
                    string a = before.Text;

                    //
                    //
                    //Credit to Diego Perini (dperini) - https://gist.github.com/dperini/729294
                    Regex reg = new Regex("^" +
    "(?:(?:https?|ftp)://)" +
    "(?:\\S+(?::\\S*)?@)?" +
    "(?:" +
      "(?!(?:10|127)(?:\\.\\d{1,3}){3})" +
      "(?!(?:169\\.254|192\\.168)(?:\\.\\d{1,3}){2})" +
      "(?!172\\.(?:1[6-9]|2\\d|3[0-1])(?:\\.\\d{1,3}){2})" +
      "(?:[1-9]\\d?|1\\d\\d|2[01]\\d|22[0-3])" +
      "(?:\\.(?:1?\\d{1,2}|2[0-4]\\d|25[0-5])){2}" +
      "(?:\\.(?:[1-9]\\d?|1\\d\\d|2[0-4]\\d|25[0-4]))" +
    "|" +
      "(?:(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)" +
      "(?:\\.(?:[a-z\\u00a1-\\uffff0-9]-*)*[a-z\\u00a1-\\uffff0-9]+)*" +
      "(?:\\.(?:[a-z\\u00a1-\\uffff]{2,}))" +
      "\\.?" +
    ")" +
    "(?::\\d{2,5})?" +
    "(?:[/?#]\\S*)?" +
  "$", RegexOptions.IgnoreCase);
                    //End credit [:Qwink]
                    //
                    //
                    
                    Match match;

                    List<string> results = new List<string>();
                    for (match = reg.Match(a); match.Success; match = match.NextMatch())
                    {
                        if (!(results.Contains(match.Value)))
                            results.Add(match.Value);
                    }

                    string[] result = results.ToArray();
                    string separator = "\n";

                    string i = string.Join(separator, result);
                    after.Text = i;
                }
                catch
                {

                }
            }
        }
    }
}