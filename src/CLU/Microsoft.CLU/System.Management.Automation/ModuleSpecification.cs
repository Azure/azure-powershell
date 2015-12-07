using System;

namespace Microsoft.PowerShell.Commands
{
    public class ModuleSpecification
    {
        public Guid? Guid { get; }
        public string Name { get; }
        public Version Version { get; }

        public ModuleSpecification(string moduleName)
        {
            Name = moduleName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
