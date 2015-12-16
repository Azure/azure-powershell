using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace System.Management.Automation
{
    public sealed class PSModuleInfo
    {
        internal PSModuleInfo(Assembly assembly, string assemblyLocation, ICommandRuntime host)
        {
            _assembly = assembly;
            _host = host;
            _file = new FileInfo(assemblyLocation);
        }

        public string Name { get { return _file.Name; } }

        public string Path { get { return _file.FullName; } }

        public string ModuleBase { get { return _file.Directory.FullName; } }

        public Dictionary<string, CmdletInfo> ExportedCmdlets
        {
            get
            {
                if (_exportedCommands == null)
                {
                    _exportedCommands = new Dictionary<string, CmdletInfo>();
                    foreach (var type in _assembly.GetExportedTypes().Where(t => t.GetTypeInfo().GetCustomAttributes(typeof(System.Management.Automation.CmdletAttribute), false).FirstOrDefault() != null))
                    {
                        var info = new CmdletInfo(type, this, _host, null);

                        var commandName = $"{info.Verb}-{info.Noun}".ToLowerInvariant();
                        if (!_exportedCommands.ContainsKey(commandName))
                            _exportedCommands.Add(commandName, info);
                    }
                }
                return _exportedCommands;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private Assembly _assembly;
        private FileInfo _file;
        private ICommandRuntime _host;
        private Dictionary<string, CmdletInfo> _exportedCommands;
    }
}
