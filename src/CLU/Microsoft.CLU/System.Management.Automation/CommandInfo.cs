using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public abstract class CommandInfo
    {
        public CommandTypes CommandType { get { return CommandTypes.Cmdlet; } }
        public string Name { get; protected set; }
        public abstract ReadOnlyCollection<PSTypeName> OutputType { get;  }
        public virtual Dictionary<string, ParameterMetadata> Parameters { get; }
        public ReadOnlyCollection<CommandParameterSetInfo> ParameterSets { get; }
        public PSModuleInfo Module { get; protected set; }
        public string ModuleName { get { return Module.Name; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
