using System;
using System.Data.SQLite;

public class ConnectionClass
{
	public ConnectionClass()
	{

	}

    /*
     * makes a new Database with movie table
     * 
     */
     public void NewDataBase()
    {
        SQLiteConnection.CreateFile("MyMovies.sqlite");
        m_dbConnection = new SQLiteConnection("Data Source=MyMovies.sqlite;Version=3;");
        m_dbConnection.Open();

        String MakeTable = "Create Table IF NOT EXISTS Moives  (RowId INTERGER primary key, Title Text, Gerna Text, Rating Text, Length Text, Resolution Text, Plot Text)";


        SQLiteCommand command = new SQLiteCommand(MakeTable, m_dbConnection);
        command.ExecuteNonQuery();
        m_dbConnection.Close();
    } 
    /*
     * Inserts a new Movie Row into the Database
     * Takes String title, String Year, String Gernas, String Rating, String Length, String Resoulution, 
     * sring File Path String Plot
     * 
     */
     public void InsertNewRow(String M_Title, String M_Year, String M_Gernas, String M_Rating, String M_Length, String M_Res, String M_Plot, String M_Path)
    {

    }
    /*
     * Gets title year gerna rating length and res for all movies to be didplayed in table
     * 
     */
     public DataTable SelAllMovies()
    {

    }
}
