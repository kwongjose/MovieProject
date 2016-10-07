﻿using MediaToolkit;
using MediaToolkit.Model;
using MovieLib;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

/*
 * Class takes in a File Path Seperates it into a Title with or without year
 * Calls web API
 * inserts data into DATABASE
 * 
 */
public class FileToDataBase
{
    String Movie_Path, Movie_Year, Movie_Title, Full_Path;
    String  Resulution;
    /*
     * constructor for updateing movie info in table using and IMdb title ID
     * @pram An IMdb title ID, the RowID of movie to update, the resulution of the movie
     * 
     */ 
    public FileToDataBase(String IMDB_Id, int M_Id, String Res)
    {
        //TODO::Make API Call using IMDB ID then call UPDATEROW FROM CONNECTIN CLASS
        StringBuilder ApiCall = new StringBuilder();
        ApiCall.Append("?i=");
        ApiCall.Append(IMDB_Id);
        ApiCall.Append("&plot=full&r=json");

        Task<String> t = Task.Run(() => CallWebApi(ApiCall.ToString()));//I don't know why this works
        Task.WhenAll(t);   

        Movie Curent_Movie = JsonConvert.DeserializeObject<Movie>(t.Result);


        ConnectionClass con = new ConnectionClass();
        con.UpDateRow(M_Id, Curent_Movie.Title, Curent_Movie.Year, Curent_Movie.Genre, Curent_Movie.imdbRating, Curent_Movie.Runtime, Curent_Movie.Plot, Res);
    }
    /*
     * empty constructor
     * 
     */ 
    public FileToDataBase()
    {

    }
    /*
     * makes an API call 
     * @pram a file path to use to make the api call
     * 
     */ 
    public String MakeAPI(String Fname)
    {
       

        Resulution = "n/a";
       // System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
        var infile = new MediaFile { Filename = Fname };
        using (var engin = new Engine())
        {
            engin.GetMetadata(infile);

        }
        try
        {
            Resulution = infile.Metadata.VideoData.FrameSize;
            Resulution = Resulution.Replace("x", " X ");
        }
        catch (Exception e)
        {

        }
      

        Full_Path = Fname;
        Movie_Path = Path.GetFileName(Fname);//movie title (1999).mpg
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
        return "";
    }
    /*
     * A constructor for adding a row to the database
     * @parm and IMdb title ID, the Path of the file to use
     * 
     */ 
    public FileToDataBase(String IMDB_Id, String Path)
    {
        
        StringBuilder ApiCall = new StringBuilder();
        ApiCall.Append("?i=");
        ApiCall.Append(IMDB_Id);
        ApiCall.Append("&plot=full&r=json");
                

        Full_Path = Path;

        var infile = new MediaFile { Filename = Path };
        using (var engin = new Engine())
        {
            engin.GetMetadata(infile);

        }
        Resulution = infile.Metadata.VideoData.FrameSize;
        Resulution = Resulution.Replace("x", " X ");

        Task<String> t = Task.Run(() => CallWebApi(ApiCall.ToString()));//I don't know why this works
        Task.WhenAll(t);
        ParseJson(t.Result);


    }
    /*
     * Stand alone method that sets the resulution
     * using this to see if i can speed up total run time
     * 
     */ 
    private async Task<String> GetRes(String F)
    {
        MediaFile infile = new MediaFile { Filename = F };
        using (Engine engin = new Engine())
        {
            engin.GetMetadata(infile);

        }
        try
        {
            Resulution = infile.Metadata.VideoData.FrameSize;
            Resulution = Resulution.Replace("x", " X ");
            
            return "";
        }
        catch (Exception e)
        {
            return "";
        }
    }
    /*
     * constructor that preps seperates the file name into movie or movie and title
     * @pram File Path
     * 
     */ 
    public FileToDataBase(String F_Path)
    {
       
        Resulution = "n/a";

        //Thread thread = new Thread(() => GetRes(F_Path) );
       //  task = new Task(() =>  GetRes(F_Path));
       // task.Start();

           
         MediaFile infile = new MediaFile { Filename = F_Path }; //Try to speed this up
          using (Engine engin = new Engine())
          {
              engin.GetMetadata(infile);

          }
          try
          {
              Resulution = infile.Metadata.VideoData.FrameSize;
              Resulution = Resulution.Replace("x", " X ");
          }
          catch(Exception e)
          {

          }
          
        
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
    }
    /*
     * Gets Text Between Two subStrings
     * @param full String, The first part of the sub string, the end of the substring
     * @return The SubString between strStart and strEnd
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
    private String ApiCallBuilder(String M_Title, String M_Year)
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

        Task<String> t = Task.Run( () => CallWebApi(ApiCall.ToString()));//I don't know why this works
        t.Wait();
       //Task.WaitAll(task);
        ParseJson(t.Result);
       
        return "";
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
        
        Movie Curent_Movie = JsonConvert.DeserializeObject<Movie>(Json);
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

