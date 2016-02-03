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
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StaticAnalysis.help;

namespace StaticAnalysis.HelpAnalyzer
{
    public class CmdletLoader : MarshalByRefObject
    {
        /// <summary>
        /// Get cmdlets from the given assembly
        /// </summary>
        /// <param name="assemblyPath"></param>
        /// <returns></returns>
        public IList<CmdletHelpMetadata> GetCmdlets(string assemblyPath)
        {
            IList<CmdletHelpMetadata> result = new List<CmdletHelpMetadata>();
            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var type in assembly.GetCmdletTypes())
                {
                    var cmdlet = type.GetAttribute<CmdletAttribute>();
                    result.Add(
                        new CmdletHelpMetadata
                    {
                        ClassName = type.FullName,
                        CmdletName = string.Format("{0}-{1}", cmdlet.VerbName, cmdlet.NounName)
                    });
                }
            }
            catch
            {
            }

            return result;
        }
    }
}
