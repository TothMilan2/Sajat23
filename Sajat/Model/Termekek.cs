using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Model
{
    public class Termekek
    {
        private string text1;
        private string text2;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Termeknev { get; set; }
        public string Funkcio { get; set; }



        public Termekek(int id, string termeknev, string funkcio)
        {
            Id = id;
            Termeknev = termeknev;
            Funkcio = funkcio;
        }
        public Termekek()
        {
        }

        public Termekek(string text1, string text2)
        {
            this.text1 = text1;
            this.text2 = text2;
        }
    }
}
