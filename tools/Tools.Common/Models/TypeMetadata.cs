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
using System.Reflection;
using System.Text.RegularExpressions;
using Tools.Common.Loaders;

namespace Tools.Common.Models
{
    /// <summary>
    /// Encapsulates the important information about a type without requiring the assembly containing the
    /// type to be loaded. Used for transferring type metadat across AppDomain boundaries.
    /// </summary>
    [Serializable]
    public class TypeMetadata
    {
        private Dictionary<string, string> _properties = new Dictionary<string, string>();
        private List<string> _genericTypeArguments = new List<string>();
        private List<MethodSignature> _methods = new List<MethodSignature>();
        private List<MethodSignature> _constructors = new List<MethodSignature>();


        /// <summary>
        /// Allow easy conversion between types and type metadata objects.
        /// </summary>
        /// <param name="typeToProcess"></param>
        /// <returns>The capture type metadata</returns>
        public static implicit operator TypeMetadata(Type typeToProcess)
        {
            return new TypeMetadata(typeToProcess);
        }

        public TypeMetadata()
        {

        }

        public TypeMetadata(Type inputType)
        {
            Namespace = inputType.Namespace;
            Name = inputType.ToString();
            AssemblyQualifiedName = inputType.AssemblyQualifiedName;

            // Get the properties of the type
            var properties = inputType.GetProperties();

            // Sort the properties by name to retain ordering when loading cmdlets
            Array.Sort(properties, delegate (PropertyInfo p1, PropertyInfo p2)
                                    {
                                        return p1.PropertyType.ToString().CompareTo(p2.PropertyType.ToString());
                                    });

            var methods = inputType.GetMethods()
                                   .Where(m => !m.IsSpecialName)
                                   .ToArray();

            var constructors = inputType.GetConstructors();

            ModuleMetadata moduleMetadata = CmdletLoader.ModuleMetadata;

            // If the type is an array
            if (inputType.HasElementType)
            {
                // Get the element type of the array
                ElementType = inputType.GetElementType().ToString();

                // If the element type is not in the type dictionary,
                // add it and check its properties
                if (!moduleMetadata.TypeDictionary.ContainsKey(ElementType))
                {
                    moduleMetadata.TypeDictionary.Add(ElementType, new TypeMetadata() { Name = ElementType });
                    var typeMetadata = new TypeMetadata(inputType.GetElementType());
                    moduleMetadata.TypeDictionary[ElementType] = typeMetadata;
                }

                return;
            }

            // If the type is a generic
            if (inputType.IsGenericType)
            {
                // Get the argument types
                var genericTypeArguments = inputType.GetGenericArguments();

                // For each of the arguments, add them to the list of arguments
                // and check if the type is in the type dictionary
                foreach (var arg in genericTypeArguments)
                {
                    _genericTypeArguments.Add(arg.ToString());

                    if (!moduleMetadata.TypeDictionary.ContainsKey(arg.ToString()))
                    {
                        moduleMetadata.TypeDictionary.Add(arg.ToString(), new TypeMetadata() { Name = arg.ToString() });
                        var typeMetadata = new TypeMetadata(arg);
                        moduleMetadata.TypeDictionary[arg.ToString()] = typeMetadata;
                    }
                }

                return;
            }

            // If the type is in the System namespace, don't look at any of its properties
            if (Namespace.StartsWith("System"))
            {
                return;
            }

            // For each property, check to see if we have already processed its type before,
            // and if not, we will add it to the global dictionary and process the TypeMetadata.
            foreach (var property in properties)
            {
                // Get the property type
                var propertyType = property.PropertyType;

                // If the type has not been seen before, we will map it to a null value in the
                // global dictionary so we don't repeat the computation, and then create the
                // TypeMetadata object associated with it, and finally set it as the value
                // associated with the type name key in the dictionary.
                if (!moduleMetadata.TypeDictionary.ContainsKey(propertyType.ToString()))
                {
                    moduleMetadata.TypeDictionary.Add(propertyType.ToString(), new TypeMetadata() { Name = propertyType.ToString() });
                    var typeMetadata = new TypeMetadata(propertyType);
                    moduleMetadata.TypeDictionary[propertyType.ToString()] = typeMetadata;
                }

                // Add the property to the dictionary
                if (!_properties.ContainsKey(property.Name.ToString()))
                {
                    _properties.Add(property.Name, propertyType.ToString());
                }
            }

            foreach (var method in methods)
            {
                var methodParameterMetadata = new List<MethodParameterMetadata>();
                MethodMetadata methodMetadata = null;
                if (moduleMetadata.TypeDictionary.ContainsKey(method.ReturnType.ToString()))
                {
                    var typeMetadata = moduleMetadata.TypeDictionary[method.ReturnType.ToString()];
                    methodMetadata = new MethodMetadata()
                    {
                        Name = method.Name,
                        ReturnType = typeMetadata.Name
                    };
                }
                else
                {
                    moduleMetadata.TypeDictionary.Add(method.ReturnType.ToString(), new TypeMetadata() { Name = method.ReturnType.ToString() });
                    var typeMetadata = new TypeMetadata(method.ReturnType);
                    moduleMetadata.TypeDictionary[method.ReturnType.ToString()] = typeMetadata;
                    methodMetadata = new MethodMetadata()
                    {
                        Name = method.Name,
                        ReturnType = typeMetadata.Name
                    };
                }


                foreach (var parameter in method.GetParameters())
                {
                    var parameterMetadata = new MethodParameterMetadata()
                    {
                        Name = parameter.Name,
                        Type = parameter.GetType().ToString()
                    };

                    methodParameterMetadata.Add(parameterMetadata);
                }

                methodMetadata.Parameters = methodParameterMetadata;
                _methods.Add(methodMetadata);
            }

            foreach (var constructor in constructors)
            {
                var constructorParameterMetadata = new List<MethodParameterMetadata>();
                var constructorMetadata = new ConstructorMetadata();

                foreach (var parameter in constructor.GetParameters())
                {
                    var parameterMetadata = new MethodParameterMetadata()
                    {
                        Name = parameter.Name,
                        Type = parameter.GetType().ToString()
                    };

                    constructorParameterMetadata.Add(parameterMetadata);
                }

                constructorMetadata.Parameters = constructorParameterMetadata;
                _constructors.Add(constructorMetadata);
            }
        }

        public string Namespace { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public Dictionary<string, string> Properties { get { return _properties; } }
        public string ElementType { get; set; }
        public List<string> GenericTypeArguments { get { return _genericTypeArguments; } }

        public List<MethodSignature> Methods { get { return _methods; } }

        public List<MethodSignature> Constructors { get { return _constructors; } }

        public string GetClassNameWithoutApiVersion(string className)
        {
            var matcher = Regex.Match(className, @"Microsoft\.Azure\.PowerShell\.Cmdlets\.([\w\.]+)\.Api[\w\d]+\.([\w\.]+)");
            if (!matcher.Success || matcher.Groups.Count < 3)
            {
                return className;
            }
            return string.Format("Microsoft.Azure.PowerShell.Cmdlets.{0}.{1}", matcher.Groups[1].Value, matcher.Groups[2].Value);
        }

        /// <summary>
        /// Checks if two TypeMetadata objects are equal by comparing
        /// each of the properties, methods, and constructors.
        /// </summary>
        /// <param name="other">The TypeMetadata object being compared to this object.</param>
        /// <returns>True if the two objects are equal, false otherwise.</returns>
        public bool Equals(Object obj, bool ignoreMethod = false)
        {
            var other = obj as TypeMetadata;
            if (other == null)
            {
                return false;
            }

            var typesEqual = true;
            string className = GetClassNameWithoutApiVersion(this.Name);
            string otherClassName = GetClassNameWithoutApiVersion(other.Name);
            typesEqual &= string.Equals(className, otherClassName, StringComparison.OrdinalIgnoreCase);
            typesEqual &= string.Equals(this.ElementType, other.ElementType, StringComparison.OrdinalIgnoreCase);
            this.GenericTypeArguments.ForEach(t => typesEqual &= other.GenericTypeArguments.Contains(t));
            typesEqual &= this.GenericTypeArguments.Count == other.GenericTypeArguments.Count;
            ModuleMetadata moduleMetadata = CmdletLoader.ModuleMetadata;
            foreach (var thisPropertyName in this.Properties.Keys)
            {
                var otherPropertyFullName = other.Properties.ContainsKey(thisPropertyName) ? other.Properties[thisPropertyName] : null;
                if (otherPropertyFullName == null)
                {
                    return false;
                }

                var thisPropertyFullName = this.Properties[thisPropertyName];
                if (moduleMetadata.ProcessedTypes.ContainsKey(thisPropertyFullName))
                {
                    continue;
                }
                else
                {
                    moduleMetadata.ProcessedTypes.Add(thisPropertyFullName, true);
                }

                if (!string.Equals(thisPropertyFullName, otherPropertyFullName))
                {
                    return false;
                }

                var thisPropertyTypeMetadata = moduleMetadata.TypeDictionary[thisPropertyFullName];
                var otherPropertyTypeMetadata = moduleMetadata.TypeDictionary[otherPropertyFullName];
                typesEqual &= thisPropertyTypeMetadata.Equals(otherPropertyTypeMetadata);
            }

            typesEqual &= this.Properties.Keys.Count == other.Properties.Keys.Count;
            if (!ignoreMethod)
            {
                typesEqual &= AreMethodSignaturesEqual(this.Methods, other.Methods);
                typesEqual &= AreMethodSignaturesEqual(this.Constructors, other.Constructors);
            }
            return typesEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool AreMethodSignaturesEqual(
            List<MethodSignature> thisMethodSignatures,
            List<MethodSignature> otherMethodSignatures)
        {
            if (thisMethodSignatures.Count != otherMethodSignatures.Count)
            {
                return false;
            }

            foreach (var thisMethod in thisMethodSignatures)
            {
                bool found = false;
                var candidateMethods = otherMethodSignatures.Where(m => string.Equals(m.Name, thisMethod.Name)).ToList();
                foreach (var otherMethod in candidateMethods)
                {
                    var thisParameters = thisMethod.Parameters;
                    var otherParameters = otherMethod.Parameters;
                    if (thisParameters.Count != otherParameters.Count)
                    {
                        continue;
                    }

                    bool match = true;
                    for (int idx = 0; idx < thisParameters.Count; idx++)
                    {
                        var thisParameter = thisParameters[idx];
                        var otherParameter = otherParameters[idx];
                        if (thisParameter.Name != otherParameter.Name || thisParameter.Type != otherParameter.Type)
                        {
                            match = false;
                            break;
                        }
                    }

                    if (thisMethod.ReturnType != null && otherMethod.ReturnType != null)
                    {
                        match &= thisMethod.ReturnType.Equals(otherMethod.ReturnType);
                    }

                    if (match)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return false;
                }
            }

            return true;
        }

        [Serializable]
        public class MethodSignature
        {
            private List<MethodParameterMetadata> _parameters = new List<MethodParameterMetadata>();

            public virtual string Name { get; set; }

            public List<MethodParameterMetadata> Parameters { get { return _parameters; } set { _parameters = value; } }

            public virtual string ReturnType { get; set; }
        }

        [Serializable]
        public class MethodMetadata : MethodSignature { }

        [Serializable]
        public class ConstructorMetadata : MethodSignature
        {
            public override string Name { get { return string.Empty; } set { } }

            public override string ReturnType { get { return null; } set { } }
        }

        [Serializable]
        public class MethodParameterMetadata
        {
            public string Name { get; set; }

            public string Type { get; set; }
        }
    }
}
