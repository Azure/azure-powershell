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
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace StaticAnalysis.HelpGenerator
{
    public class CmdletHelp
    {
        private IList<string> _cluNames = new List<string>();
        private IList<string> _aliases = new List<string>();
        private IList<ParameterSetHelp> _parameterSets = new List<ParameterSetHelp>();
        private IList<ParameterHelp> _parameters = new List<ParameterHelp>();
        private IList<ExampleHelp> _examples = new List<ExampleHelp>();
        private IList<CmdletHelpReference> _references = new List<CmdletHelpReference>();
        private IList<Type> _output = new List<Type>();
        private string _noun;

        public string NounName
        {
            get
            {
                return _noun;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.ToLower().Contains("azurerm"))
                {
                    NounPrefix = "AzureRm";
                    _noun = value.Remove(0, "AzureRm".Length);
                }
                else if (!string.IsNullOrWhiteSpace(value) && value.ToLower().Contains("azure"))
                {
                    NounPrefix = "Azure";
                    _noun = value.Remove(0, "Azure".Length);
                }
                else
                {
                    NounPrefix = String.Empty;
                    _noun = value;
                }
            }
        }

        public string VerbName { get; set; }
        public string PowerShellName {  get { return $"{VerbName}-{NounName}"; } }
        public IList<string> CluNames { get { return _cluNames; } }  
        public IList<string> Aliases { get { return _aliases; } } 
        public string Synopsis { get; set; }
        public string Description { get; set; } 
        public IList<Type> OutputTypes { get { return _output; } }
        private string NounPrefix { get; set; }
        public IList<ParameterSetHelp> ParameterSets
        {
            get
            {
                return _parameterSets;
            }
        }

        public IList<ParameterHelp> Parameters
        {
            get { return _parameters; }
        }

        public IList<ExampleHelp> Examples {  get { return _examples;} } 

        public IList<CmdletHelpReference> References { get { return _references; } }
    }
}
