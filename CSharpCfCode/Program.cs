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
            Directory.GetFiles("C:", "*.*", SearchOption.AllDirectories)
                    .Select(file => new FileInfo(file))
                    .Select(info => info.Length)
                    .Sum();
        }
    }
}
