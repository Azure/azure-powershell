using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FormatParser
{
    public class CmdletValidationInfo
    {
        IEnumerable<Type> _outputType = null;
        public string SourceFile { get; set; }
        public string CmdletName { get; set; }

        public IEnumerable<Type> OutputType
        {
            get { return _outputType; }
            set { _outputType = value.Select(GetUnderlyingType); }
        }

        public bool HasComplexOutput
        {
            get { return _outputType.Any(HasComplexProperties); }
        }

        public bool IsComplex
        {
            get { return _outputType.Any(IsComplexType); }
        }

        public static bool IsComplexType(Type outputType)
        {
            return (outputType != null && !outputType.GetTypeInfo().IsPrimitive);
        }

        public static bool HasComplexProperties(Type outputType)
        {
            if (outputType != null && !outputType.GetTypeInfo().IsPrimitive)
            {
                foreach (
                    var propertyInfo in outputType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var propertyType = GetUnderlyingType(propertyInfo.PropertyType);
                    if (!propertyType.GetTypeInfo().IsPrimitive)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Type GetUnderlyingType(Type typeToProcess)
        {
            if (typeToProcess == null)
            {
                throw new ArgumentNullException(nameof(typeToProcess));
            }

            var result = typeToProcess;
            if (typeToProcess.IsArray)
            {
                return GetUnderlyingType(typeToProcess.GetElementType());
            }

            if (typeToProcess.IsConstructedGenericType)
            {
                var arguments = typeToProcess.GetGenericArguments();
                if (arguments != null && arguments.Length == 1)
                {
                    return GetUnderlyingType(arguments[0]);
                }
                else if (arguments != null && arguments.Length == 2)
                {
                    return GetUnderlyingType(arguments[1]);
                }
            }

            return result;
        }
    }
}
