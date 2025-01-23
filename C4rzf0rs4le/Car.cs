using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4rzf0rs4le
{
    public class Car
    {
        public string username { get; set; }
        public string phoneNumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string video_director { get; set; }
        public string hp { get; set; }
        public string color { get; set; }
        /*    public string[] description { get; set; }
            
            public string engine_size { get; set; }
            public string fuel { get; set; }
           
            public string gearbox_type { get; set; }*/
        public string mileage { get; set; }
        public int make_year { get; set; }
        public string price { get; set; }
        public override string ToString()
        {
            return make;
        }
        


    }
}
