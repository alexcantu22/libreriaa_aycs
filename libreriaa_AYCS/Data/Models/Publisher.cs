using System.Collections.Generic;

namespace libreriaa_AYCS.Data.Models
{
    public class Publisher
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        //propiedades de navegacion
        public List<Book> Books { get; set; }
    }
}
