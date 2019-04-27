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
using System.Collections.Generic;

namespace StringMatching
{
    public static class SqlConstants_Slower
    {
        public static List<string> LogSchema = new List<string> { "LogId", "CreatedDate", "CreatedBy" };
        public static List<string> DependencySchema = new List<string> { "DependencyId", "CreatedDate", "CreatedBy" };
        public static List<string> HashSchema = new List<string> { "HashId", "CreatedDate", "CreatedBy" };

        public static string SchemaString { get; } = "Schema";
    } // end class SqlConstants_Slower
} // end namespace StringMatching
