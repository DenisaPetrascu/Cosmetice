using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Cosmetice.Models
{
    public class Cosmetice
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(500), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
