using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBook.BLL.Services
{
    public class FileConfig
    {
        public string FilePath { get; set; }

        public FileConfig(string filePath)
        {
            FilePath = filePath;
        }
    }
}
