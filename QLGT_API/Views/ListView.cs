using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Views
{
    public class ListView<T> where T: class
    {
        public List<T> Data { get; set; }
         
        public int? PrePage { get; set; }
        
        public int? NextPage { get; set; }
        
    }
}
