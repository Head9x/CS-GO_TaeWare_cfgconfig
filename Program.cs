using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CS_cfgconfig
{
    class Program
    {
        static void Main(string[] arguments)
        {
            bool overwrite = true;
            if (Environment.GetCommandLineArgs().Last() == "false") 
            { 
                 Console.WriteLine("!#!Not overwriting files. Make sure to manually clean up you CFG directory!#!");
                 Console.WriteLine("");
                 overwrite = false;
             }

            getcsgodir getcsgodir = new getcsgodir();
            string csgodir = getcsgodir.GetCSGODir();
            if (csgodir == null)
            {
                Console.WriteLine("CS:GO is not installed");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            Console.WriteLine("Program is copyrighted by Head9x - head9x.dk");
            copydir copydir = new copydir();

            if (Directory.Exists(@".\cfg")) { 
            copydir.CopyDirectory(@".\cfg", csgodir + "\\cfg", true, overwrite);
            }
            if (Directory.Exists(@".\cfg"))
            {
            copydir.CopyDirectory(@".\resource", csgodir + "\\resource", true, overwrite);
            }
            
            Console.WriteLine("!!Remember to add launch options to CS:GO!!");
            Console.WriteLine("\nPress any key to close this window . . .");
            Console.ReadKey();

            //Snippets were grabbed from other sources. Linked below:
            //https://gist.github.com/moritzuehling/7f1c512871e193c0222f#file-getcsgodir-cs
        }
    }
}
