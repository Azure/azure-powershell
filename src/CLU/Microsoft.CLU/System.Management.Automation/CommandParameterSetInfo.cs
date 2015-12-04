using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public class CommandParameterSetInfo
    {
        public bool IsDefault { get; internal set; }
        public string Name { get; internal set; }
        public ReadOnlyCollection<CommandParameterInfo> Parameters { get { return _roParameters; } }

        public override string ToString()
        {
            return base.ToString();
        }

        internal void Add(CommandParameterInfo info)
        {
            _parameters.Add(info);
        }

        internal CommandParameterSetInfo()
        {
            _parameters = new List<CommandParameterInfo>();
            _roParameters = new ReadOnlyCollection<CommandParameterInfo>(_parameters);
        }

        private List<CommandParameterInfo> _parameters = new List<CommandParameterInfo>();
        private ReadOnlyCollection<CommandParameterInfo> _roParameters;
    }
}
