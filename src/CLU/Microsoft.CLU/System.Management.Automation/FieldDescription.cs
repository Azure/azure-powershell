using System.Collections.ObjectModel;

namespace System.Management.Automation.Host
{
    public class FieldDescription
    {
        public FieldDescription(string name) { Name = name; }

        public Collection<Attribute> Attributes { get; private set; }
        public PSObject DefaultValue { get; set; }
        public string HelpMessage { get; set; }
        public bool IsMandatory { get; set; }
        public string Label { get; set; }
        public string Name { get; private set; }
        public string ParameterAssemblyFullName { get; private set; }
        public string ParameterTypeFullName { get; private set; }
        public string ParameterTypeName { get; private set; }

        public void SetParameterType(Type parameterType) { }
    }
}
