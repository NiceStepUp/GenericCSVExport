using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.DTO.CommonDTO
{
    public class FileDTO
    {
        public byte[] Content { get; set; }


        public string FileName { get; set; }


        public string MediaTypeHeaderValue { get; set; }

    }
}
