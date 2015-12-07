using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public class RuntimeDefinedParameter
    {
        public RuntimeDefinedParameter() { Attributes = new Collection<Attribute>(); }
        public RuntimeDefinedParameter(string name, Type parameterType, Collection<Attribute> attributes)
        {
            Name = name;
            ParameterType = parameterType;
            Attributes = attributes != null ? attributes : new Collection<Attribute>();
        }

        public Collection<Attribute> Attributes { get; private set; }
        public bool IsSet { get; set; }
        public string Name { get; set; }
        public Type ParameterType { get; set; }
        public object Value
        {
            get { return _value; }
            set { _value = value; IsSet = true; }
        }
        private object _value;
    }

    public class RuntimeDefinedParameterDictionary : Dictionary<string, RuntimeDefinedParameter>
    {
        public RuntimeDefinedParameterDictionary() : base(_invariantComparer) { }

        public object Data { get; set; }
        public string HelpFile { get; set; }

        private static IEqualityComparer<string> _invariantComparer = new StringInvariantComparer();
    }
    internal class StringInvariantComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLowerInvariant().Equals(y.ToLowerInvariant());
        }

        public int GetHashCode(string obj)
        {
            return obj.ToLowerInvariant().GetHashCode();
        }
    }

}