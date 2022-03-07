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

            copydir.CopyDirectory(@".\cfg", csgodir + "\\cfg", true, overwrite);
            copydir.CopyDirectory(@".\resource", csgodir + "\\resource", true, overwrite);
            Console.WriteLine("!!Remember to add the following line to launch options to activate TaeCFG!!");
            Console.WriteLine("");
            Console.WriteLine("+exec taeexec.cfg -language taeware -tickrate 128 -d3d9ex +mat_disable_fancy_blending 1 -high -r_emulate_g -softparticlesdefaultoff -no-browser -console -novid -nojoy -limitvsconst -forcenovsync +mat_queue_mode 2");
            Console.WriteLine("");
            Console.ReadKey();

            //Snippets were grabbed from other sources. Linked below:
            //https://gist.github.com/moritzuehling/7f1c512871e193c0222f#file-getcsgodir-cs
        }
    }
}
