using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

public class ConnectionClass
{
    String ConString = "Data Source=MyMovies.sqlite;Version=3;";

    public ConnectionClass()
    {

    }

    /*
     * makes a new Database with movie table
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

            String MakeTable = "Create Table IF NOT EXISTS Movies  (RowId INTEGER PRIMARY KEY AUTOINCREMENT, Title Text, Year Text, Gerna Text, Rating Text, Length Text, Resolution Text, Plot Text, Path TEXT )";


            SQLiteCommand command = new SQLiteCommand(MakeTable, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        catch (SQLiteException e)
        {

        }
    }
    /*
     * Inserts a new Movie Row into the Database
     * Takes String title, String Year, String Gernas, String Rating, String Length, String Resoulution, 
     * sring File Path String Plot
     * 
     */
    public void InsertNewRow(String M_Title, String M_Year, String M_Gernas, String M_Rating, String M_Length, String M_Res, String M_Plot, String M_Path)
    {
        String SqlInsert = "INSERT INTO Movies ( Title, Year, Gerna, Rating, Length, Resolution, Plot, Path) VALUES (@Title,@Year,@Gerna,@Rating,@Length,@Resolution,@Plot,@Path)";
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand Insert = new SQLiteCommand(SqlInsert, con);
        System.Diagnostics.Debug.WriteLine("somthing is wrong");
        Insert.Parameters.AddWithValue("@Title", M_Title);
        System.Diagnostics.Debug.WriteLine("somthing is sdafwrong");
        Insert.Parameters.AddWithValue("@Year", M_Year);
        Insert.Parameters.AddWithValue("@Gerna", M_Gernas);
        Insert.Parameters.AddWithValue("@Rating", M_Rating);
        Insert.Parameters.AddWithValue("@Length", M_Length);
        Insert.Parameters.AddWithValue("@Resolution", M_Res);
        Insert.Parameters.AddWithValue("@Plot", M_Plot);
        Insert.Parameters.AddWithValue("@Path", M_Path);
        System.Diagnostics.Debug.WriteLine("somthing isasdfasd wrong");
        try
        {

            Insert.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {
            System.Diagnostics.Debug.WriteLine("somthing is wrong");
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
     * Updates a row in the movie db based on RowID
     * 
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
     * 
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
     * 
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
        System.Diagnostics.Debug.WriteLine(temp);
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
     * 
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
        String Rate = '"' + R + "%" + '"';
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM MOVIES WHERE Rating LIke " + Rate, con);
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
     * 
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
     * 
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
        String Ser_Title = '"' + Title + "%" + '"';
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
     * if present true
     * false if absent
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
        try
        {
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
     * 
     */
    public String[] GetMovieData(int Mid)
    {
        String[] data = new String[10];
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("SELECT * FROM Movies WHERE Rowid = " + Mid, con);
        try
        {
            SQLiteDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                data[0] = (String)r["Title"];
                data[1] = (String)r["Year"];
                data[2] = (String)r["Gerna"];
                data[3] = (String)r["Rating"];
                data[4] = (String)r["Length"];
                data[5] = (String)r["Resolution"];
                data[6] = (String)r["Plot"];
                data[7] = (String)r["Path"];
            }
            r.Close();
            con.Close();
            con.Dispose();
            return data;

        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return data;
        }
    }

    public void TestInsertNewRow(String M_Title, String M_Year, String M_Gernas, String M_Rating, String M_Length, String M_Res, String M_Plot, String M_Path)
    {
        String p = '"' + M_Path + '"';
        String SqlInsert = "INSERT INTO Movies ( Title, Year, Gerna, Rating, Length, Resolution, Plot, Path) SELECT @Title,@Year,@Gerna,@Rating,@Length,@Resolution,@Plot,@Path WHERE NOT EXISTS (SELECT Path FROM Movies WHERE Path = @Path)";
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand Insert = new SQLiteCommand(SqlInsert, con);
        System.Diagnostics.Debug.WriteLine("somthing is wrong");
        Insert.Parameters.AddWithValue("@Title", M_Title);
        System.Diagnostics.Debug.WriteLine("somthing is sdafwrong");
        Insert.Parameters.AddWithValue("@Year", M_Year);
        Insert.Parameters.AddWithValue("@Gerna", M_Gernas);
        Insert.Parameters.AddWithValue("@Rating", M_Rating);
        Insert.Parameters.AddWithValue("@Length", M_Length);
        Insert.Parameters.AddWithValue("@Resolution", M_Res);
        Insert.Parameters.AddWithValue("@Plot", M_Plot);
        Insert.Parameters.AddWithValue("@Path", M_Path);
        System.Diagnostics.Debug.WriteLine("somthing isasdfasd wrong");
        try
        {

            Insert.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (SQLiteException e)
        {
            System.Diagnostics.Debug.WriteLine("somthing is wrong");
            throw new Exception(e.Message);
        }
    }
    /*
     * Delete a Row by RowId
     * 
     */
    public void DeleteByID(int M_Id)
    {
        SQLiteConnection con = new SQLiteConnection(ConString);
        con.Open();
        SQLiteCommand com = new SQLiteCommand("DELETE  FROM Movies WHERE Rowid = " + M_Id, con);


        com.ExecuteNonQuery();

        con.Clone();
        con.Dispose();
        com.Dispose();
    }
}
