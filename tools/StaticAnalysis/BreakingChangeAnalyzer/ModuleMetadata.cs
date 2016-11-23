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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    [Serializable]
    public class ModuleMetadata
    {
        private List<CmdletBreakingChangeMetadata> _cmdlets = new List<CmdletBreakingChangeMetadata>();
        private Dictionary<string, TypeMetadata> _typeDictionary = new Dictionary<string, TypeMetadata>();

        public ModuleMetadata()
        {
            InitializeTypeDictionary();
        }

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

        public List<CmdletBreakingChangeMetadata> Cmdlets { get { return _cmdlets; } set { _cmdlets = value; } }
        public Dictionary<string, TypeMetadata> TypeDictionary { get { return _typeDictionary; } }

        public void FilterCmdlets(Func<string, bool> cmdletFilter)
        {
            _cmdlets = _cmdlets.Where<CmdletBreakingChangeMetadata>(
                        (cmdlet) => cmdletFilter(cmdlet.Name) || cmdlet.AliasList.Where(a => cmdletFilter(a)).ToList().Count > 0)
                        .ToList<CmdletBreakingChangeMetadata>();
        }
    }
}
