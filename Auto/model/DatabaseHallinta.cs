
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Autokauppa.model
{
    public class AutonMalli
    {
        public string malli
        {
        get;
        set;
        }

        public int merkkiID
        {
        get;
        set;
        }

        public int id
        {
            get;
            set;
        }

        /*public AutonMalli(string m, int i, int y)
        {
            m = malli;
            i = merkkiID;
            y = id;
        }*/
    }

    public class AutonMerkki
    {
        public string merkki
        {
            get;
            set;
        }

        public int id
        {
            get;
            set;
        }

        /*public AutonMerkki(string n, int y)
        {
            n = merkki;
            y = id;
        }*/
    }

    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys = new SqlConnection();

        public DatabaseHallinta()
        {
           yhteysTiedot = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public bool connectDatabase()
        {
            if (dbYhteys.State == System.Data.ConnectionState.Closed)
            {
                dbYhteys.ConnectionString = yhteysTiedot;
            }
            
            try
            { 
                dbYhteys.Open();
                return true;
            }
            catch(Exception e)
            { 
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;

            }
            
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;

            
        }

        public List<AutonMerkki> getAllAutoMakersFromDatabase()
        {
            List<AutonMerkki> palaute=new List<AutonMerkki>();


            if (dbYhteys.State == System.Data.ConnectionState.Closed)
            {
                dbYhteys.ConnectionString = yhteysTiedot;
            }

            dbYhteys.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM AutonMerkki", dbYhteys);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                AutonMerkki f = new AutonMerkki();
                f.id = (int)reader["Id"];
                f.merkki = (string)reader["Merkki"];
                palaute.Add(f);
                
            }
            dbYhteys.Close();
            
            return palaute;
        }

        public List<AutonMalli> getAutoModelsByMakerId(int makerId) 
             
        {
            List<AutonMalli> palaute = new List<AutonMalli>();

            if (dbYhteys.State == System.Data.ConnectionState.Closed)
            {
                dbYhteys.ConnectionString = yhteysTiedot;
            }

            dbYhteys.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM AutonMallit", dbYhteys);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                AutonMalli f = new AutonMalli();
                int id = (int)reader["AutonMerkkiID"];

                if (id == makerId)
                {
                    f.id = (int)reader["ID"];
                    f.merkkiID = (int)reader["AutonMerkkiID"];
                    f.malli = (string)reader["Auton_mallin_nimi"];
                    palaute.Add(f);
                }
                    
            }

            dbYhteys.Close();

            return palaute;
        }

    }
}
