using Microsoft.CLU.Helpers;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace System.Management.Automation
{
    public class PSObject : IFormattable, IComparable
    {
        public const string AdaptedMemberSetName = "psadapted";
        public const string BaseObjectMemberSetName = "psbase";
        public const string ExtendedMemberSetName = "psextended";

        public PSObject()
        {
            Properties = new PropertyInfoCollection();
        }

        public object BaseObject { get; private set; }
        public object ImmediateBaseObject { get; private set; }
        public PSMemberInfoCollection<PSMemberInfo> Members { get; private set; }
        public PSMemberInfoCollection<PSMethodInfo> Methods { get; private set; }
        public PSMemberInfoCollection<PSPropertyInfo> Properties { get; private set; }
        public Collection<string> TypeNames { get; private set; }

        internal static PSObject AsPSObject(string strValue)
        {
            var psObject = new PSObject();
            psObject.Properties.Add(new CLUPropertyInfo(strValue, typeof(string)));
            return psObject;
        }

        internal static PSObject AsPSObject(string strValue, Type type)
        {
            return AsPSObject(strValue, type, new PSObject());
        }

        internal static PSObject AsPSObject(string strValue, Type type, PSObject psObject)
        {
            Debug.Assert(!string.IsNullOrEmpty(strValue));
            bool isComplex = false;
            var objectValue = InterpretValue(strValue, type, out isComplex);
            if (isComplex)
            {
                if (typeof(IEnumerable).IsAssignableFrom(type))
                {
                    psObject.Properties.Add(new CLUPropertyInfo(objectValue, type));
                }
                else
                {
                    var publicProperties = Reflector.GetPropertyInfosWithPublicGetSet(type);
                    foreach (var property in publicProperties)
                    {
                        var value = property.GetValue(objectValue);
                        psObject.Properties.Add(new CLUPropertyInfo(value, property.PropertyType, property.Name));
                    }

                    if (publicProperties.Count() == 0)
                    {
                        // If we can't enumerate the object properties then use PSObject with one property
                        psObject.Properties.Add(new CLUPropertyInfo(objectValue, type));
                    }
                }
            }
            else
            {
                psObject.Properties.Add(new CLUPropertyInfo(objectValue, type));
            }

            return psObject;
        }

        internal static object InterpretValue(string strValue, Type argType, out bool isComplex)
        {
            isComplex = false;
            if (!argType.GetTypeInfo().IsClass)
            {
                if (strValue == null) return null;

                var parser = argType.GetMethod("Parse", new Type[] { typeof(string) });

                if (argType.GetTypeInfo().IsValueType && parser != null)
                {
                    var result = parser.Invoke(null, new object[] { strValue });
                    return result;
                }
                else if (argType.GetTypeInfo().IsEnum)
                {
                    var result = Enum.Parse(argType, strValue);
                    return result;
                }
            }

            if (argType.Equals(typeof(string)))
            {
                return strValue;
            }

            isComplex = true;
            return JsonConvert.DeserializeObject(strValue, argType);
        }

        public int CompareTo(object obj) { return -1; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return null;
        }

        internal class PropertyInfoCollection : PSMemberInfoCollection<PSPropertyInfo>
        {
            public override PSPropertyInfo this[string name]
            {
                get
                {
                    return _collection[name];
                }
            }

            public override void Add(PSPropertyInfo member)
            {
                _collection.Add(member.Name, member);
            }

            public override void Add(PSPropertyInfo member, bool preValidated)
            {
                Add(member);
            }

            public override IEnumerator<PSPropertyInfo> GetEnumerator()
            {
                return _collection.Values.GetEnumerator();
            }

            public override void Remove(string name)
            {
                if (_collection.ContainsKey(name))
                    _collection.Remove(name);
            }

            private Dictionary<string, PSPropertyInfo> _collection = new Dictionary<string, PSPropertyInfo>();
        }
    }
}
