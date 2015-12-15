using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace System.Management.Automation
{
    public sealed class ParameterMetadata
    {
        public ParameterMetadata(ParameterMetadata other)
        {
            this.Name = other.Name;
            this.ParameterSets = other.ParameterSets;
            this._mandatory = other._mandatory;
            this._position = other._position;
        }

        public ParameterMetadata(string name)
        {
            this.Name = name;
            this.ParameterSets = new Dictionary<string, ParameterSetMetadata>();
        }

        public ParameterMetadata(string name, Type parameterType) : this(name)
        {
            this.ParameterType = parameterType;
        }

        public ParameterMetadata(PropertyInfo info) : this(info.Name, info.PropertyType)
        {
            Debug.Assert(info != null);
            this._property = info;
            var attributes = info.GetCustomAttributes();

            foreach (var attr in _property.GetCustomAttributes())
            {
                _attributes.Add(attr);
                var pAttr = attr as ParameterAttribute;
                if (pAttr != null)
                {
                    SetMandatory(pAttr.ParameterSetName, pAttr.Mandatory);
                    SetPosition(pAttr.ParameterSetName, pAttr.Position);
                }
            }
        }

        public IEnumerable<string> Aliases
        {
            get
            {
                var attributes = _property != null ? _property.GetCustomAttributes() : null;
                return attributes != null ?
                    attributes.Where(a => a is AliasAttribute).Select(a => a as AliasAttribute).SelectMany(a => a.AliasNames) :
                    new string[0];
            }
        }

        public Collection<Attribute> Attributes { get { return _attributes; } }

        public bool IsDynamic { get; set; }

        internal int Position(string parameterSet)
        {
            if (!string.IsNullOrEmpty(parameterSet))
            {
                if (_position.ContainsKey(parameterSet))
                    return _position[parameterSet];
            }
            if (_position.ContainsKey("AllParameterSets"))
                return _position["AllParameterSets"];
            return -1;
        }

        internal void SetPosition(string parameterSet, int position)
        {
            if (position != -1)
            {
                if (string.IsNullOrEmpty(parameterSet))
                    parameterSet = "AllParameterSets";
                _position[parameterSet] = position;
            }
        }

        internal bool IsMandatory(string parameterSet)
        {
            if (!string.IsNullOrEmpty(parameterSet))
            {
                if (_position.ContainsKey(parameterSet))
                    return _mandatory[parameterSet];
            }
            if (_mandatory.ContainsKey("AllParameterSets"))
                return _mandatory["AllParameterSets"];
            return false;
        }

        internal void SetMandatory(string parameterSet, bool isMandatory)
        {
            if (string.IsNullOrEmpty(parameterSet))
                parameterSet = "AllParameterSets";
            _mandatory[parameterSet] = isMandatory;
        }

        public string Name { get; set; }

        public Dictionary<string, ParameterSetMetadata> ParameterSets { get; private set; }

        public Type ParameterType { get; set; }

        public bool SwitchParameter { get { return this.ParameterType.Equals(typeof(SwitchParameter)); } }

        internal bool IsBound { get; set; }

        internal bool IsBuiltin { get; set; }

        internal void MarkPresent(object instance)
        {
            if (SwitchParameter)
            {
                var dict = instance as RuntimeDefinedParameterDictionary;

                if (dict != null)
                {
                    if (dict.ContainsKey(Name))
                    {
                        dict[Name].Value = System.Management.Automation.SwitchParameter.Present;
                        IsBound = true;
                    }
                }
                else if (_property != null && instance != null)
                {
                    IsBound = true;
                    _property.SetValue(instance, System.Management.Automation.SwitchParameter.Present);

                    var cmdlet = instance as PSCmdlet;
                    if (cmdlet != null)
                    {
                        cmdlet.MyInvocation.BoundParameters[Name] = true;
                    }
                }
            }
        }

        internal void SetValue(object instance, object value)
        {
            var dict = instance as RuntimeDefinedParameterDictionary;

            if (dict != null)
            {
                if (dict.ContainsKey(Name))
                {
                    dict[Name].Value = value;
                    IsBound = true;
                }
            }
            else if (_property != null && instance != null)
            {
                _property.SetValue(instance, value);
                IsBound = true;

                var cmdlet = instance as PSCmdlet;
                if (cmdlet != null)
                {
                    cmdlet.MyInvocation.BoundParameters[Name] = value;
                }
            }
        }

        internal void InterpretAndSetValue(object instance, string argValue)
        {
            var dict = instance as RuntimeDefinedParameterDictionary;

            if (dict != null)
            {
                if (dict.ContainsKey(Name))
                {
                    var value = InterpretValue(argValue, dict[Name].ParameterType);
                    dict[Name].Value = value;
                    IsBound = true;
                }
            }
            else if (_property != null && instance != null)
            {
                var value = InterpretValue(argValue, _property.PropertyType);
                _property.SetValue(instance, value);
                IsBound = true;

                var cmdlet = instance as PSCmdlet;
                if (cmdlet != null)
                {
                    cmdlet.MyInvocation.BoundParameters[Name] = value;
                }
            }
        }

        internal object InterpretValue(string strValue, Type argType)
        {
            if (strValue != null && 
                argType.GetTypeInfo().IsGenericType && 
                argType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return InterpretValue(strValue, argType.GetGenericArguments()[0]);
            }

            if (!argType.GetTypeInfo().IsClass)
            {
                if (strValue == null) return null;

                var parser = argType.GetMethod("Parse", new Type[] { typeof(string) });

                if (argType.GetTypeInfo().IsValueType && parser != null)
                {
                    var result = parser.Invoke(null, new object[] { strValue });
                    Validate(result);
                    return result;
                }
                else if (argType.GetTypeInfo().IsEnum)
                {
                    var result = Enum.Parse(argType, strValue);
                    Validate(result);
                    return result;
                }
            }

            if (argType.Equals(typeof(string)))
            {
                Validate(strValue);
                return strValue;
            }

            var strDeserialized = JsonConvert.DeserializeObject(strValue, argType);
            Validate(strDeserialized);
            return strDeserialized;
        }

        private void Validate(object argument)
        {
            try
            {
                foreach (var validator in Validations)
                {
                    validator.Validate(argument, null);
                }
            }
            catch (ValidationException ae)
            {
                throw new ValidationException($"The value passed for {Name} {ae.Message}", ae);
            }
        }

        internal bool TakesInputFromPipeline
        {
            get
            {
                return _attributes.Where(a => a.GetType().Equals(typeof(ParameterAttribute)))
                    .Select(a => a as ParameterAttribute)
                    .Where(a => a.ValueFromPipeline).Any();
            }
        }

        internal bool TakesInputFromPipelineByPropertyName
        {
            get
            {
                return _attributes.Where(a => a.GetType().Equals(typeof(ParameterAttribute)))
                    .Select(a => a as ParameterAttribute)
                    .Where(a => a.ValueFromPipelineByPropertyName).Any();
            }
        }

        internal IEnumerable<ValidateArgumentsAttribute> Validations
        {
            get
            {
                return _attributes.Where(a => a is ValidateArgumentsAttribute).Select(a => a as ValidateArgumentsAttribute);
            }
        }

        private PropertyInfo _property;
        private Collection<Attribute> _attributes = new Collection<Attribute>();
        private Dictionary<string, int> _position = new Dictionary<string, int>();
        private Dictionary<string, bool> _mandatory = new Dictionary<string, bool>();
    }
}
