using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class FileParser
{
    public static Queue<string> Read(string path)
    {
        return new Queue<string>(File.ReadLines(path));
    }
}