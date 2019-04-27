// ******************************************************************************************************************
//  StringMatching - a simple example showing string comparisons.
//  Copyright(C) 2019  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 
//
// ******************************************************************************************************************
//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringMatching
{
    class Program
    {
        //Class Properties:
        public static string ApplicationName { get; set; }
        public static List<string> Expected { get; set; }

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            //Slower method
            timer.Start();
            MatchSchema_Slower("Hash"); // testing with 'Hash'
            timer.Stop();

            //Print slower method outcome to console for clarity
            Console.WriteLine($"********************************SLOWER: Elapsed Time = {timer.Elapsed.TotalMilliseconds} ms\n");
            Console.WriteLine($"ApplicationName: {ApplicationName}");
            Console.Write("Expected:");
            Expected.ForEach(a => { Console.Write($" {a},"); });

            //Faster method
            timer.Restart();
            MatchSchema_Faster("Log"); // testing with 'Log'
            timer.Stop();

            //Print faster method outcome to console for clarity
            Console.WriteLine($"\n\n\n\n********************************FASTER: Elapsed Time = {timer.Elapsed.TotalMilliseconds} ms\n");
            Console.WriteLine($"ApplicationName: {ApplicationName}");
            Console.Write("Expected:");
            Expected.ForEach(a => { Console.Write($" {a},"); });

            //Wait for user input
            Console.Write("\n\n\nPress enter to exit...");
            Console.ReadKey();
        } // end method Main

        public static void MatchSchema_Slower(string table)
        {
            //Get all the schema lists using reflection
            var schemas = typeof(SqlConstants_Slower).GetFields().Where(x => x.Name.Contains(SqlConstants_Slower.SchemaString));

            //For every schema found
            foreach (var s in schemas)
            {
                //Pull out the schema name only
                var schemaName = s.Name.Substring(0, (s.Name.Length - SqlConstants_Slower.SchemaString.Length));

                //If the schema name matches table
                if (schemaName == table)
                {
                    //Save data
                    ApplicationName = ($"{schemaName} {SqlConstants_Slower.SchemaString}");
                    Expected = (List<string>)s.GetValue(null);
                } // end if
            } // end foreach
        } // end method MatchSchema_Slower

        public static void MatchSchema_Faster(string table)
        {
            ApplicationName = ($"{table} {SqlConstants_Faster.SchemaString}");
            Expected = SqlConstants_Faster.Schemas[table];
        } // end method MatchSchema_Faster
    } // end class Program
} // end namespace StringMatching
