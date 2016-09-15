using MediaInfoLib;
using MovieLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Class takes in a File Path Seperates it into a Title with or without year
 * Calls web API
 * inserts data into DATABASE
 * 
 */
public class FileToDataBase
{
    String Movie_Path, Movie_Year, Movie_Title, Full_Path;
    String Width, Height, Resulution;


    public FileToDataBase(String F_Path)
    {
        Resulution = "n/a";

        var Minfo = new MediaInfo();
        Minfo.Open(F_Path);
        try
        {
            var VidINfo = new VideoInfo(Minfo);
            Width = VidINfo.Width.ToString();
            Height = VidINfo.Heigth.ToString();
            Resulution = Width + " X " + Height;
            Minfo.Close();
        }
        catch (Exception e)
        {
            // MessageBox.Show("Files found: " + e.Message, "Message");
        }

        System.Diagnostics.Debug.WriteLine(Resulution);

        Full_Path = F_Path;
        Movie_Path = Path.GetFileName(F_Path);//movie title (1999).mpg
        //does path hold a date
        if (Movie_Path.Contains('('))//Holds a Date
        {
            Movie_Year = getBetween(Movie_Path, "(", ")");//(1990) or ""

            int i = Movie_Path.IndexOf("(");

            Movie_Title = Movie_Path.Substring(0, i);//Movie Title

        }
        else
        {
            Movie_Title = Movie_Path.Remove(Movie_Path.Length - 4);//Movie Title
        }

        ApiCallBuilder(Movie_Title, Movie_Year);//Call the API

        // System.Diagnostics.Debug.WriteLine(j + "test");
    }
    /*
     * Gets Text Between Two subStrings
     * 
     */
    private static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }
    /*
     * Calls the web API using the title or title and year
     * returns JSON
     * http://www.omdbapi.com/?t=taken+2&y=2012&plot=short&r=json
     */
    private void ApiCallBuilder(String M_Title, String M_Year)
    {

        StringBuilder ApiCall = new StringBuilder();

        if (M_Year == null)//Call API using Title Only
        {
            String[] M_Parts = M_Title.Split(' ');
            ApiCall.Append("?t=");
            ApiCall.Append(M_Parts[0]);
            for (int i = 1; i < M_Parts.Length; i++)
            {
                ApiCall.Append("+");
                ApiCall.Append(M_Parts[i]);
            }
            ApiCall.Append("&y=&plot=full&r=json");
        }
        else//Call API using Title and Year
        {
            String[] M_Parts = M_Title.Split(' ');
            ApiCall.Append("?t=");
            ApiCall.Append(M_Parts[0]);
            for (int i = 1; i < M_Parts.Length; i++)
            {
                ApiCall.Append("+");
                ApiCall.Append(M_Parts[i]);
            }
            ApiCall.Append("&y=");
            ApiCall.Append(M_Year);
            ApiCall.Append("&plot=full&r=json");
        }
        System.Diagnostics.Debug.WriteLine(ApiCall.ToString());
        Task<String> t = Task.Run( () => CallWebApi(ApiCall.ToString()) );//I don't know why this works
         Task.WhenAll(t);
        System.Diagnostics.Debug.WriteLine(t.Result + "I AM HERE");                          //  String json = t.Result;
        ParseJson(t.Result);

    }
    /*
     * Calls the OMDB API to get the Movie Data
     * 
     */
    private async Task<String> CallWebApi(String Call)
    {

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));

            HttpResponseMessage response = await client.GetAsync(Call);

            if (response.IsSuccessStatusCode)
            {

                String JsonMessage;
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    JsonMessage = new StreamReader(responseStream).ReadToEnd();
                  //  System.Diagnostics.Debug.WriteLine(JsonMessage);
                   // ParseJson(JsonMessage);
                    return JsonMessage;
                }

            }
            else
            {
                return "";
            }
        }//end using
    }
    /*
     * Parse JSON Data for info to be inserted into the Data Base
     *
     */
    private bool ParseJson(String Json)
    {       //handels when no data from server
        JObject SerJson = JObject.Parse(Json);


        Movie Curent_Movie = JsonConvert.DeserializeObject<Movie>(SerJson.ToString());
        if (Curent_Movie.Response == "True")
        {
            ConnectionClass con = new ConnectionClass();
            con.TestInsertNewRow(Curent_Movie.Title, Curent_Movie.Year, Curent_Movie.Genre, Curent_Movie.imdbRating, Curent_Movie.Runtime, Resulution, Curent_Movie.Plot, Full_Path);
            return true;
        }
        else
        {
            return false;
        }
    }
}

