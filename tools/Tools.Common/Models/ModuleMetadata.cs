// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tools.Common.Models
{
    [Serializable]
    public class ModuleMetadata
    {
        [JsonProperty(Order = -99)]
        public string ModuleName { get; set; }
        [JsonProperty(Order = -98)] 
        public string ModuleVersion { get; set; }
        private List<CmdletMetadata> _cmdlets = new List<CmdletMetadata>();
        private Dictionary<string, TypeMetadata> _typeDictionary = new Dictionary<string, TypeMetadata>();
        private Dictionary<string, bool> _processedTypes = new Dictionary<string, bool>();

        public ModuleMetadata()
        {
            InitializeTypeDictionary();
        }

        /// <summary>
        /// Add primitive types to the type dictionary.
        /// </summary>
        private void InitializeTypeDictionary()
        {
            _typeDictionary.Add("System.String",  new TypeMetadata() { Name = "System.String" });
            _typeDictionary.Add("System.Boolean", new TypeMetadata() { Name = "System.Boolean" });
            _typeDictionary.Add("System.Byte",    new TypeMetadata() { Name = "System.Byte" });
            _typeDictionary.Add("System.SByte",   new TypeMetadata() { Name = "System.SByte" });
            _typeDictionary.Add("System.Int16",   new TypeMetadata() { Name = "System.Int16" });
            _typeDictionary.Add("System.UInt16",  new TypeMetadata() { Name = "System.UInt16" });
            _typeDictionary.Add("System.Int32",   new TypeMetadata() { Name = "System.Int32" });
            _typeDictionary.Add("System.UInt32",  new TypeMetadata() { Name = "System.UInt32" });
            _typeDictionary.Add("System.Int64",   new TypeMetadata() { Name = "System.Int64" });
            _typeDictionary.Add("System.UInt64",  new TypeMetadata() { Name = "System.UInt64" });
            _typeDictionary.Add("System.Single",  new TypeMetadata() { Name = "System.Single" });
            _typeDictionary.Add("System.Double",  new TypeMetadata() { Name = "System.Double" });
            _typeDictionary.Add("System.Decimal", new TypeMetadata() { Name = "System.Decimal" });
            _typeDictionary.Add("System.Char",    new TypeMetadata() { Name = "System.Char" });
        }

        public List<CmdletMetadata> Cmdlets { get { return _cmdlets; } set { _cmdlets = value; } }
        public Dictionary<string, TypeMetadata> TypeDictionary { get { return _typeDictionary; } }

        [JsonIgnore]
        public Dictionary<string, bool> ProcessedTypes { get { return _processedTypes; } }

        public void FilterCmdlets(Func<string, bool> cmdletFilter)
        {
            _cmdlets = _cmdlets.Where(
                        (cmdlet) => cmdletFilter(cmdlet.Name) || cmdlet.AliasList.Where(a => cmdletFilter(a)).ToList().Count > 0)
                        .ToList();
        }

        public override bool Equals(Object obj)
        {
            var other = obj as ModuleMetadata;
            if (other == null)
            {
                return false;
            }

            var modulesEqual = true;
            foreach (var thisCmdlet in this.Cmdlets)
            {
                var thisCmdletNames = new Dictionary<string, bool>();
                thisCmdletNames.Add(thisCmdlet.Name, true);
                thisCmdlet.AliasList.ForEach(a => thisCmdletNames.Add(a, true));
                var otherCmdlet = other.Cmdlets.Find(c => thisCmdletNames.ContainsKey(c.Name) || c.AliasList.Find(a => thisCmdletNames.ContainsKey(a)) != null);
                if (otherCmdlet == null)
                {
                    // Console.WriteLine($"Cannot find cmdlet {thisCmdletNames} in new version.");
                    return false;
                }
                modulesEqual &= thisCmdlet.Equals(otherCmdlet);
            }
            /*if(this.Cmdlets.Count != other.Cmdlets.Count)
            {
                Console.WriteLine($"The number of cmdlets is unmatched in old and new module");
            }*/
            modulesEqual &= this.Cmdlets.Count == other.Cmdlets.Count;
            return modulesEqual;
        }

        public static ModuleMetadata DeserializeCmdlets(string fileName)
        {
            return File.Exists(fileName) ? JsonConvert.DeserializeObject<ModuleMetadata>(File.ReadAllText(fileName)) : null;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
