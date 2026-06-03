using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Model
{
    public class Felhasznalo
    {


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Jelszo { get; set; }
        public int Szerepkor { get; set; }

        public bool Korozike { get; set; }




        public Felhasznalo(string felhasznaloNev, string teljesNev, string jelszo, int szerepkor, bool korozike)
        {
            FelhasznaloNev = felhasznaloNev;
            TeljesNev = teljesNev;
            Jelszo = jelszo;
            Szerepkor = szerepkor;
            Korozike = korozike;


        }
        public Felhasznalo()
        {
        }


    }
}
