using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
/*
 * This Class handels all interaction with the SQLite database
 * 
 */
public class ConnectionClass
{
    String ConString = "Data Source=MyMovies.sqlite;Version=3;";
    /*
     * An Empty constructor
     * 
     */ 
    public ConnectionClass()
    {

    }

    /*
     * makes a new Database with movie table if it does not exist
     * 
     */
    public void NewDataBase()
    {
        try
        {
            if (!(File.Exists("MyMovies.sqlite")))//is db made
            {
                SQLiteConnection.CreateFile("MyMovies.sqlite");
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyMovies.sqlite;Version=3;");
            m_dbConnection.Open();

            String MakeTable = "Create Table IF NOT EXISTS Movies  (RowId INTEGER PRIMARY KEY AUTOINCREMENT, Title Text, Year Text, Gerna Text, Rated Text, Rating Text, Length Text, Resolution Text, Plot Text, Path TEXT, Poster TEXT )";


            SQLiteCommand command = new SQLiteCommand(MakeTable, m_dbConnection);
            command.ExecuteNonQuery();
            //Make Actor Table

            String Actor = "Create Table IF NOT EXISTS ACTOR (AID INTEGER PRIMARY KEY AUTOINCREMENT, Name Text)";
             command = new SQLiteCommand(Actor, m_dbConnection);
            command.ExecuteNonQuery();

            //Make Relation
            String MovieActor = "Create Table IF NOT EXISTS MovieActor (MovieID INTEGER, ActorID INTEGER, FOREIGN KEY(MovieID) REFERENCES Movies(RowID), FOREIGN KEY(ActorID) REFERENCES ACTOR(AID) )";
            command = new SQLiteCommand(MovieActor, m_dbConnection);
            command.ExecuteNonQuery();
            

            m_dbConnection.Close();
        }
        catch (SQLiteException e)
        {

        }
    }

    /*
     * Inserts a new Actor into the Actor Table
     * @Parm Actor name String
     * 
     */
     public bool InsertNewActor(String Actor)
    {
        try
        {
            String insert = "INSERT INTO ACTOR (Name) SELECT @AName  WHERE NOT EXISTS (SELECT * FROM ACTOR WHERE Name = @AName) ";
            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand(insert, con);
            com.Parameters.AddWithValue("@AName", Actor);
            com.ExecuteNonQuery();
           
            com.Dispose();
            con.Close();
            con.Dispose();

            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }

    /*
     * Inserts a row into the MovieActor Relation
     * @Parm RowID Integer (id for movie) AID Integer (ID for an Actor)
     * 
     */
     public bool Insert_MovieActor(int RowID, int AID)
    {
        try
        {
            String insert = "INSERT INTO MovieActor (MovieID, ActorID) SELECT @MID, @ActID WHERE NOT EXISTS (SELECT * FROM MovieActor WHERE MovieID = @MID AND ActorID = @ActID)";

            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand(insert, con);
            com.Parameters.AddWithValue("@MID", RowID);
            com.Parameters.AddWithValue("@ActID", AID);

            com.ExecuteNonQuery();

            com.Dispose();
            con.Close();
            con.Dispose();

            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    } 
    /*
     * Inserts a new Movie Row into the Database
     * @pram String title, String Year, String Gernas, String Rating, String Length, String Resoulution, 
     * sring File Path String Plot
     * 
     */
    public void InsertNewRow(String M_Title, String M_Year, String M_Gernas, String M_Rating, String M_Length, String M_Res, String M_Plot, String M_Path)
    {
        String SqlInsert = "INSERT INTO Movies ( Title, Year, Gerna, Rating, Length, Resolution, Plot, Path) VALUES (@Title,@Year,@Gerna,@Rating,@Length,@Resolution,@Plot,@Path)";
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand Insert = new SQLiteCommand(SqlInsert, con);
        Insert.Parameters.AddWithValue("@Title", M_Title);
        Insert.Parameters.AddWithValue("@Year", M_Year);
        Insert.Parameters.AddWithValue("@Gerna", M_Gernas);
        Insert.Parameters.AddWithValue("@Rating", M_Rating);
        Insert.Parameters.AddWithValue("@Length", M_Length);
        Insert.Parameters.AddWithValue("@Resolution", M_Res);
        Insert.Parameters.AddWithValue("@Plot", M_Plot);
        Insert.Parameters.AddWithValue("@Path", M_Path);
        try
        {

            Insert.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {
            throw new Exception(e.Message);
        }
    }
    /*
     * Gets title year gerna rating length and res for all movies to be didplayed in table
     * 
     */
    public DataTable SelAllMovies()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");
        String GetAllM = "SELECT * FROM Movies";
        try
        {
            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand comm = new SQLiteCommand(GetAllM, con);
            SQLiteDataReader r = comm.ExecuteReader();

            while (r.Read())//Build DataTable
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Rating"] = (String)r["Rating"];
                dr["Length"] = (String)r["Length"];
                dr["Resolution"] = (String)r["Resolution"];
                dr["ID"] = r["RowId"];
                //add row to datatable
                dt.Rows.Add(dr);
            }
            r.Close();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {

        }

        return dt;
    }
    /*
     * Updates a row in the movie db based on RowID
     * @pram int rowid, string title, string year, string genras, string rating, string length, string plot, string res
     * @return a bool on good insert
     */
    public bool UpDateRow(int Rid, String N_Title, String N_Year, String N_Genra, String N_Rating, String N_Length, String N_Plot, String N_Res)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("UPDATE Movies set Title = @NTitle, Year = @NYear, Gerna = @NGenra, Rating = @NRating, Length = @NLength, Plot = @NPlot, Resolution = @NRes WHERE Rowid = " + Rid, con);
        com.Parameters.AddWithValue("@NTitle", N_Title);
        com.Parameters.AddWithValue("@NYear", N_Year);
        com.Parameters.AddWithValue("@NGenra", N_Genra);
        com.Parameters.AddWithValue("@NRating", N_Rating);
        com.Parameters.AddWithValue("@NLength", N_Length);
        com.Parameters.AddWithValue("@NPlot", N_Plot);
        com.Parameters.AddWithValue("@NRes", N_Res);
        try
        {
            com.ExecuteNonQuery();
            com.Dispose();
            con.Dispose();
            return true;
        }
        catch (SQLiteException e)
        {
            return false;
        }
    }
    /*
     * gets the movie title plot and file path from rowID
     * @Pram Movie rowID
     * @return String[] with title plot and path
     */
    public String[] GetMoiveByID(int ID)
    {
        String[] Movie_Dets = new String[4];
        String Sql = "SELECT Title, Plot, Path FROM Movies WHERE RowId =" + ID;

        try
        {
            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand(Sql, con);
            SQLiteDataReader r = com.ExecuteReader();

            while (r.Read())
            {

                Movie_Dets[0] = (String)r["Title"];
                Movie_Dets[1] = (String)r["Plot"];
                Movie_Dets[2] = (String)r["Path"];

            }
            r.Close();
            con.Close();
            con.Dispose();
            com.Dispose();
        }
        catch (SQLiteException e)
        {

        }

        return Movie_Dets;
    }
    /*
     * returns all movie of the selected Gernra
     * @param a gerna as string
     * @return A datatable with all the movie info
     */
    public DataTable GetMovieByGernra(String G)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");

        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        String temp = '"' + "%" + G + "%" + '"';
        SQLiteCommand sql = new SQLiteCommand("SELECT * FROM MOVIES WHERE Gerna LIKE " + temp, con);

        //    sql.Parameters.AddWithValue("@Gern", temp);
        try
        {
            SQLiteDataReader r = sql.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Rating"] = (String)r["Rating"];
                dr["Length"] = (String)r["Length"];
                dr["Resolution"] = (String)r["Resolution"];
                dr["ID"] = r["RowId"].ToString();
                //add row to datatable
                dt.Rows.Add(dr);
            }
            r.Close();
            con.Close();
            con.Dispose();
        }
        catch
        {

        }
        sql.Dispose();

        return dt;
    }
    /*
     * returns all movies of the selected rating range
     * @param a string rating
     * @return a datatable with movies from n.0 to n.9
     */
    public DataTable GetMovieByRating(String R)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        String Rate = '"' + R  + '"';
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM MOVIES WHERE Rating < " + R, con);
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Rating"] = (String)r["Rating"];
                dr["Length"] = (String)r["Length"];
                dr["Resolution"] = (String)r["Resolution"];
                dr["ID"] = r["RowId"].ToString();
                //add row to datatable
                dt.Rows.Add(dr);
            }
            r.Close();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {

        }
        return dt;
    }
    /*
     * get all movies made in the selected decade
     * @param A decade as a year
     * @return a datatable of movies from that decade
     */
    public DataTable GetMovieByYear(String Y)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");

        String Decade = '"' + Y + "%" + '"';
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM MOVIES WHERE Year LIKE " + Decade, con);

        // com.Parameters.AddWithValue("@year", Decade);
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Rating"] = (String)r["Rating"];
                dr["Length"] = (String)r["Length"];
                dr["Resolution"] = (String)r["Resolution"];
                dr["ID"] = r["RowId"].ToString();
                //add row to datatable
                dt.Rows.Add(dr);
            }
            r.Close();
        }
        catch (SQLiteException e)
        {

        }

        con.Close();
        con.Dispose();
        return dt;
    }
    /*
     * Get movies matching Title
     * @pram a title or part of a title as a string
     * @return a datatable that matches part of that title
     */
    public DataTable GetMovieByTitle(String Title)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        String Ser_Title = '"' + "%" + Title + "%" + '"';
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM MOVIES WHERE Title LIKE " + Ser_Title, con);
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Rating"] = (String)r["Rating"];
                dr["Length"] = (String)r["Length"];
                dr["Resolution"] = (String)r["Resolution"];
                dr["ID"] = r["RowId"].ToString();
                //add row to datatable
                dt.Rows.Add(dr);
            }
            r.Close();
        }
        catch (SQLiteException e)
        {

        }
        con.Close();
        con.Dispose();
        return dt;
    }


    /*
     * checks if filepath is already in database
     * @param a file path
     * @return a bool showing wither the file is in the database or not
     */
    public bool IsPresent(String F_Path)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM MOVIES WHERE Path = @Path", con);
        com.Parameters.AddWithValue("@Path", F_Path);
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            if (r.Read())
            {
                r.Close();
                con.Close();
                con.Dispose();

                return false;
            }
            else
            {
                r.Close();
                con.Close();
                con.Dispose();

                return true;
            }
        }
        catch (SQLiteException e)
        {

        }
        return true;
    }
    /*
     * Drops all rows from the Movies Table
     * 
     */
    public void DeleteAll()
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("DELETE  FROM MOVIES", con);
        string MovieActor = "DELETE  FROM MovieActor";
        string actor = "DELETE FROM Actor ";
        try
        {
            
            com.ExecuteNonQuery();
            com.CommandText = MovieActor;
            com.ExecuteNonQuery();
            com.CommandText = actor;
            com.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {

        }
    }
    /*
     * Gets all row info of a movie by RowID
     * @Pram the RowID of a Movie as an in
     * @Return All columns for that RowId
     */
    public Movie GetMovieData(int Mid)
    {
       
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM Movies WHERE Rowid = " + Mid, con);
        Movie mov = new Movie();
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            if (r.Read())
            {
                
                mov.Title = (String)r["Title"];
                mov.Year = (String)r["Year"];
                mov.Genre = (String)r["Gerna"];
                mov.imdbRating = (String)r["Rating"];
                mov.Runtime = (String)r["Length"];
                mov.Res = (String)r["Resolution"];
                mov.Plot = (String)r["Plot"];
                mov.Path = (String)r["Path"];
                mov.Poster = (String)r["Poster"];
                mov.Rated = (String)r["Rated"];

                
            }
            
            r.Close();
            con.Close();
            con.Dispose();
            return mov; 

        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return mov;
        }
    }

    /*
     * returns the RowID from a movie 
     * @parm path @return rowID
     * 
     */
     public int GetRowID(string Path)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        string temp = '"' + Path + '"';
        SQLiteCommand com = new SQLiteCommand("SELECT ROWID FROM MOVIES WHERE Path = " +  temp, con);

        try
        {
           SQLiteDataReader dr = com.ExecuteReader();
            if (dr.HasRows )
            {
                dr.Read();
                int id = int.Parse ( dr["RowID"].ToString() );
                dr.Close();
                con.Close();
                return id;
            }
        }
        catch(Exception e)
        {

        }
        con.Close();
        return 0;
    } 
    /*
     * Inserts only if row data is not in table
     * @Pram movie title, movie year, gerna, rating, length, res, plot and path
     * 
     */ 
    public void TestInsertNewRow(String M_Title, String M_Year, String M_Gernas, String M_Rating, String M_Length, String M_Res, String M_Plot, String M_Path, String M_Poster, String M_Rated)
    {
        String p = '"' + M_Path + '"';
        String SqlInsert = "INSERT INTO Movies ( Title, Year, Gerna, Rated, Rating, Length, Resolution, Plot, Path, Poster) SELECT @Title,@Year,@Gerna,@Rated,@Rating,@Length,@Resolution,@Plot,@Path, @Poster WHERE NOT EXISTS (SELECT Path FROM Movies WHERE Path = @Path)";
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand Insert = new SQLiteCommand(SqlInsert, con);
        Insert.Parameters.AddWithValue("@Title", M_Title);
        Insert.Parameters.AddWithValue("@Year", M_Year);
        Insert.Parameters.AddWithValue("@Gerna", M_Gernas);
        Insert.Parameters.AddWithValue("@Rating", M_Rating);
        Insert.Parameters.AddWithValue("@Length", M_Length);
        Insert.Parameters.AddWithValue("@Resolution", M_Res);
        Insert.Parameters.AddWithValue("@Plot", M_Plot);
        Insert.Parameters.AddWithValue("@Path", M_Path);
        Insert.Parameters.AddWithValue("@Poster", M_Poster);
        Insert.Parameters.AddWithValue("@Rated", M_Rated);
        try
        {

            Insert.ExecuteNonQuery();
            Insert.Dispose();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {
           throw new Exception(e.Message);
        }
    }
    /*
     * Delete a Row by RowId
     * @pram a movie RowId as a int
     */
    public void DeleteByID(int M_Id)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("DELETE  FROM Movies WHERE Rowid = " + M_Id, con);
        try
        {

            com.ExecuteNonQuery();
            com.CommandText = "DELETE FROM MovieActor WHERE MovieID = " + M_Id;
            com.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        con.Clone();
        con.Dispose();
        com.Dispose();
    }

    /*
     * gets the AID for a given actor
     * @parm actor name @return AID
     * 
     */
    public int GetActorID(string aname)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        string temp = '"' + aname + '"';
        SQLiteCommand com = new SQLiteCommand("Select AID FROM ACTOR Where Name = " + temp , con);
        try
        {
            SQLiteDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                
                dr.Read();
                int id =  int.Parse( dr["AID"].ToString() );
                dr.Close();
                con.Close();
                con.Dispose();
                return id;
            }

        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        con.Close();
        con.Dispose();
        return 0;
        }

    /*
     * retruns rows for a given actor
     * @parm name @return table of movies
     * 
     */
     public DataTable GetActorMovies(string name)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();

        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Year");
        dt.Columns.Add("Gernra");
        dt.Columns.Add("Rating");
        dt.Columns.Add("Length");
        dt.Columns.Add("Resolution");
        dt.Columns.Add("ID");

        string temp = '"' + "%" + name + "%" + '"';
        SQLiteCommand com = new SQLiteCommand("Select * from movies join MovieActor on movies.RowID = MovieActor.MovieID WHERE MovieActor.ActorID in (SELECT AID FROM Actor WHERE Name LIKE " + temp + ")", con);
      //  com.Parameters.AddWithValue("@Aname", temp);

        try
        {
            SQLiteDataReader dr = com.ExecuteReader();
            while(dr.Read())
            {
                DataRow drt = dt.NewRow();
                drt["Title"] = (String)dr["Title"];
                drt["Year"] = (String)dr["Year"];
                drt["Gernra"] = (String)dr["Gerna"];
                drt["Rating"] = (String)dr["Rating"];
                drt["Length"] = (String)dr["Length"];
                drt["Resolution"] = (String)dr["Resolution"];
                drt["ID"] = dr["RowId"].ToString();
                //add row to datatable
                dt.Rows.Add(drt);
                
            }
            return dt;
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        return dt;
    } 

    /*
     * returns a list of actors in a movie
     * @parm MID @return List of actors
     * ]
     */
     public List<String> GetActorsFromMovie(int Mid)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT Name FROM ACTOR WHERE AID in (SELECT ActorID FROM MovieActor join Movies on movies.RowID = MovieActor.MovieID WHERE RowID = @MID)", con);
        com.Parameters.AddWithValue("@MID", Mid);
        List<string> Actors = new List<string>();
        try
        {
            SQLiteDataReader dr = com.ExecuteReader();
            int i = 0;
            while (dr.Read() &&  i < 4)
            {
                Actors.Add((string)dr["Name"]);
                
                i++;
            }
            
            dr.Close();
            con.Close();
            con.Dispose();
            return Actors;
        }//try
        catch(Exception e)
        {

        }
        con.Close();
        con.Dispose();
        return null;
    }
    
    /*
     *finds all titles that are duplicates
     * @return List<String>
     */  
    public List<String> FindDubs()
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT TITLE, YEAR, COUNT(*) c FROM Movies GROUP BY TITle, year HAVING c > 1", con);
        List<String> Dubs = new List<string>();
        SQLiteDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            Dubs.Add((String)dr["Title"]);
        }
        dr.Close();
        con.Close();
        con.Dispose();
        return Dubs;
    }
    
}
