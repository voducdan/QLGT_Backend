using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGT_API.Commands
{
    public class PageCommand
    {
        public PageCommand(int? pageIndex, int? pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
