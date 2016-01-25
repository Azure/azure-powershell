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
using System.Threading.Tasks;

namespace StaticAnalysis.HelpGenerator
{
    public enum PipelineInput
    {
        None,
        ByValue,
        ByPropertyName
    }
    public class ParameterHelp
    {
        IList<string> _aliases = new List<string>(); 
        public string Name { get; set; }

        public string PreferredName
        {
            get
            {
                string result = Name;
                if (Aliases != null && Aliases.Any(a => a != null && a.Length == 1))
                {
                    result = Aliases.First(a => a != null && a.Length == 1);
                }

                return result;
            }
        }
        public string Description { get; set; }
        public IList<string> Aliases { get { return _aliases; } } 
        public Type Type { get; set; }
        public bool IsSwitch { get; set; }
        public PipelineInput Pipeline { get; set; }

        public string GetReference()
        {
            return "-" + (PreferredName.Length > 1 ? "-" : string.Empty) + PreferredName;
        }
    }

}
