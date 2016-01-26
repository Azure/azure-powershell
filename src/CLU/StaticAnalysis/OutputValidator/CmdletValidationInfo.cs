// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;

namespace StaticAnalysis.OutputValidator
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
            return (outputType != null && !outputType.GetTypeInfo().IsPrimitive && !outputType.Namespace.StartsWith("System") && !outputType.Namespace.StartsWith("Newtonsoft"));
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
