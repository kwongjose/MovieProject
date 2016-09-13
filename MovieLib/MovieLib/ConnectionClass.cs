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
            if(!(File.Exists("MyMovies.sqlite") ))//is db made
            {
                SQLiteConnection.CreateFile("MyMovies.sqlite");
            }
           
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyMovies.sqlite;Version=3;");
            m_dbConnection.Open();

            String MakeTable = "Create Table IF NOT EXISTS Movies  (RowId INTEGER PRIMARY KEY AUTOINCREMENT, Title Text, Year Text, Gerna Text, Rating Text, Length Text, Resolution Text, Plot Text, Path TEXT)";


            SQLiteCommand command = new SQLiteCommand(MakeTable, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        catch(SQLiteException e)
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
            System.Diagnostics.Debug.WriteLine("somthing is wrong");
            Insert.ExecuteNonQuery();
        }
        catch(SQLiteException e)
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
        dt.Columns.Add("Length");
        dt.Columns.Add("Res");
        dt.Columns.Add("ID");
       String GetAllM = "SELECT * FROM Movies";
        try
        {
            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand comm = new SQLiteCommand(GetAllM);
            SQLiteDataReader r = comm.ExecuteReader();

            while(r.Read())//Build DataTable
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Year"] = (String)r["Year"];
                dr["Gernra"] = (String)r["Gerna"];
                dr["Length"] = (String)r["Length"];
                dr["Res"] = (String)r["Resolution"];
                dr["ID"] = (int)r["RowId"];
                //add row to datatable
                dt.Rows.Add(dr);
            }
            con.Close();
        }
        catch(SQLiteException e)
        {

        }
        
        return dt;
    }
    /*
     * gets the movie title plot and file path from rowID
     * 
     */
     public DataTable GetMoiveByID(int ID)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Plot");
        dt.Columns.Add("Path");
        String Sql = "SELECT Title, Plot, Path FROM Movies WHERE RowId =" + ID;

        try
        {
            SQLiteConnection con = new SQLiteConnection(ConString);
            SQLiteCommand com = new SQLiteCommand(Sql, con);
            SQLiteDataReader r = com.ExecuteReader();

            while (r.Read())
            {
                DataRow dr = dt.NewRow();
                dr["Title"] = (String)r["Title"];
                dr["Plot"] = (String)r["Plot"];
                dr["Path"] = (String)r["Path"];

                dt.Rows.Add(dr);
            }
            con.Close();
        }
        catch(SQLiteException e)
        {

        }
            
        return dt;
    }
         
}
