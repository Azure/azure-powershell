using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;

namespace FormatParser
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
                    cmdletAssembly.ExportedTypes.Where(t => t.HasAttribute<CmdletAttribute>()))
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
