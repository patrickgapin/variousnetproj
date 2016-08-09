using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileConverterService
{
    public interface IConverterService
    {
        bool Start();
        bool Stop();        
        FileSystemWatcher Watcher { get; set; }
    }
}
