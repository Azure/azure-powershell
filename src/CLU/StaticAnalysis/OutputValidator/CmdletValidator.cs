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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;

namespace StaticAnalysis.OutputValidator
{
    public class CmdletValidator
    {
        private string _assemblyName;
        private IToolsLogger _logger;

        public CmdletValidator(IToolsLogger logger, string name)
        {
            _logger = logger;
            if (name == null )
            {
                throw new ArgumentNullException(nameof(name));
            }

            _assemblyName = name;
        }

        public IEnumerable<CmdletValidationInfo> ValidateCmdletOutput()
        {
            Assembly cmdletAssembly = Assembly.Load(new AssemblyName(_assemblyName));
            foreach (
                var cmdletType in
                    cmdletAssembly.GetCmdletTypes())
            {
                var cmdletAttribute = cmdletType.GetAttribute<CmdletAttribute>();
                var validationInfo = new CmdletValidationInfo()
                {
                    CmdletName = $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}",
                    SourceFile = _assemblyName
                };

                if (cmdletType.HasAttribute<OutputTypeAttribute>())
                {
                    var outputAttribute =
                        cmdletType.GetAttributes<OutputTypeAttribute>();
                    validationInfo.OutputType = outputAttribute.Select( t => t.Type[0].Type);
                }

                yield return validationInfo;
            }
            
        }
    }
}
