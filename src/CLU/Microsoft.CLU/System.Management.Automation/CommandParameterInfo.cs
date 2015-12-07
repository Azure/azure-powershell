using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace System.Management.Automation
{
    public class CommandParameterInfo
    {
        internal CommandParameterInfo(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes();
            var prmAttr = attributes.Where(a => a is ParameterAttribute).Select(a => a as ParameterAttribute).First();

            Aliases = attributes.Where(a => a is AliasAttribute).Select(a => a as AliasAttribute).SelectMany(a => a.AliasNames);

            Attributes = new ReadOnlyCollection<Attribute>(attributes.ToList());

            IsDynamic = false;
            Name = property.Name;
            ParameterType = property.PropertyType;
            IsMandatory = prmAttr.Mandatory;
            HelpMessage = prmAttr.HelpMessage;
            Position = prmAttr.Position;
            ValueFromPipeline = prmAttr.ValueFromPipeline;
            ValueFromPipelineByPropertyName = prmAttr.ValueFromPipelineByPropertyName;
            ValueFromRemainingArguments = prmAttr.ValueFromRemainingArguments;
        }

        internal CommandParameterInfo(string name, Type type)
        {
            IsDynamic = false;
            Name = name;
            ParameterType = type;
            IsMandatory = false;
            ValueFromPipeline = false;
            ValueFromPipelineByPropertyName = false;
            ValueFromRemainingArguments = false;
        }

        public IEnumerable<string> Aliases { get; private set; }
        public ReadOnlyCollection<Attribute> Attributes { get; private set; }
        public string HelpMessage { get; private set; }
        public bool IsDynamic { get; private set; }
        public bool IsMandatory { get; private set; }
        public string Name { get; private set; }
        public Type ParameterType { get; private set; }
        public int Position { get; private set; }
        public bool ValueFromPipeline { get; private set; }
        public bool ValueFromPipelineByPropertyName { get; private set; }
        public bool ValueFromRemainingArguments { get; private set; }
    }
}
