using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpCfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:";
            var files = Directory.GetFiles(path,"*.*",SearchOption.AllDirectories);

            files.Select(file => new FileInfo(file))
                    .Select(info => info.Length)
                    .Sum();
        }
    }
}
