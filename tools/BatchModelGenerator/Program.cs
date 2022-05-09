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
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PSModelGenerator
{
    public class Program
    {
        private const string ModelNamespace = "Microsoft.Azure.Commands.Batch.Models";
        private const string GeneratedFileDir = "GeneratedFiles";
        private const string OmObject = "omObject";
        private static string AssemblyPath;

        private static readonly Dictionary<string, Tuple<string, string>> OMToPSDictionaryConversionMappings = new()
        {
            {  "Microsoft.Azure.Batch.EnvironmentSetting",  new Tuple<string, string>("Name", "Value") },
            {  "Microsoft.Azure.Batch.MetadataItem",  new Tuple<string, string>("Name", "Value") },
        };

        private static readonly Dictionary<string, string> customMappings = new()
        {
            { "Microsoft.Azure.Batch.UploadBatchServiceLogsResult", "PSStartComputeNodeServiceLogUploadResult" },
            { "Microsoft.Azure.Batch.Common.StatusLevelTypes", "PSStatusLevelTypes" }
        };

        private static readonly Dictionary<string, string> OMtoPSClassMappings = new();

        private static readonly Dictionary<string, string[]> OmittedProperties = new()
        {
            // Hide Custom Behaviors
            {"Microsoft.Azure.Batch.Certificate", new string[] {"CustomBehaviors"}},
            {"Microsoft.Azure.Batch.CloudJob", new string[] {"CustomBehaviors"}},
            {"Microsoft.Azure.Batch.CloudJobSchedule", new string[] {"CustomBehaviors"}},
            {"Microsoft.Azure.Batch.CloudPool", new string[] {"CustomBehaviors"}},
            // Hide file staging for now - users can use storage cmdlets to upload files and generate SAS tokens
            {"Microsoft.Azure.Batch.CloudTask", new string[] {"CustomBehaviors", "FilesToStage"}},
            {"Microsoft.Azure.Batch.ComputeNode", new string[] {"CustomBehaviors"}},
            {"Microsoft.Azure.Batch.ComputeNodeUser", new string[] {"CustomBehaviors"}},
            {"Microsoft.Azure.Batch.NodeFile", new string[] {"CustomBehaviors"}},
        };

        public static void Main(string[] args)
        {
            if (args == null || args.Length != 1 || string.Equals(args[0], @"/?", StringComparison.OrdinalIgnoreCase))
            {
                ShowUsage();
                return;
            }


            AssemblyPath = args[0];
            Assembly omAssembly = Assembly.LoadFile(AssemblyPath);
            CreateMappings(omAssembly);
            if (Directory.Exists(GeneratedFileDir))
            {
                Directory.Delete(GeneratedFileDir, true);
            }
            Directory.CreateDirectory(GeneratedFileDir);

            foreach (KeyValuePair<string, string> mapping in OMtoPSClassMappings)
            {
                string fileName = string.Format("{0}\\{1}.cs", GeneratedFileDir, mapping.Value);

                Type omType = omAssembly.GetType(mapping.Key);
                if (omType == null)
                {
                    throw new InvalidOperationException(string.Format("Unexpected type. Type {0} could not be found in {1}", mapping.Key, AssemblyPath));
                }
                GenerateModel(fileName, omType, mapping.Value);
            }
        }

        private static void CreateMappings(Assembly omAssembly)
        {
            foreach ((string key, string value) in customMappings)
            {
                OMtoPSClassMappings.Add(key, value);
            }

            Type[] allTypes = omAssembly.GetTypes();
            List<(string FullName, string Name)> typeNames = allTypes
                .Where(t => t.GetInterface("IPropertyMetadata") != null && t.Namespace == "Microsoft.Azure.Batch" && t.IsPublic).Select(t => (t.FullName, t.Name)).ToList();

            foreach ((string fullName, string className) in typeNames)
            {
                if (OMtoPSClassMappings.ContainsKey(fullName) == false)
                {
                    OMtoPSClassMappings.Add(fullName, $"PS{className}");
                }
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("This executable automatically generates the PowerShell data model classes used by the Azure Batch PowerShell cmdlets.");
            Console.WriteLine("Usage: BatchModelGenerator.exe <path>");
            Console.WriteLine("Where <path> is the file path to the Microsoft.Azure.Batch.dll file to operate on.");
        }

        private static void GenerateModel(string fileName, Type omType, string modelName)
        {
            CodeCompileUnit compileUnit = new();
            CodeNamespace codeNamespace = new(ModelNamespace);
            GenerateUsingDirectives(codeNamespace);

            var codeType = new CodeTypeDeclaration(modelName)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
                IsPartial = true, // allows us to provide some custom behaviours
            };

            codeNamespace.Types.Add(codeType);
            compileUnit.Namespaces.Add(codeNamespace);

            // The wrapped OM object
            CodeMemberField wrappedField = new();
            wrappedField.Attributes = MemberAttributes.Assembly;
            wrappedField.Name = OmObject;
            wrappedField.Type = new CodeTypeReference(omType.IsEnum ? $"{omType}?" : omType.FullName);
            codeType.Members.Add(wrappedField);

            GenerateConstructors(omType, codeType);

            GenerateProperties(omType, codeType);

            GenerateCodeFile(fileName, compileUnit);
        }

        private static void GenerateCopyrightText(StreamWriter writer)
        {
            writer.WriteLine("﻿// -----------------------------------------------------------------------------");
            writer.WriteLine("﻿//");
            writer.WriteLine("﻿// Copyright Microsoft Corporation");
            writer.WriteLine("﻿// Licensed under the Apache License, Version 2.0 (the \"License\");");
            writer.WriteLine("﻿// you may not use this file except in compliance with the License.");
            writer.WriteLine("﻿// You may obtain a copy of the License at");
            writer.WriteLine("﻿// http://www.apache.org/licenses/LICENSE-2.0");
            writer.WriteLine("﻿// Unless required by applicable law or agreed to in writing, software");
            writer.WriteLine("﻿// distributed under the License is distributed on an \"AS IS\" BASIS,");
            writer.WriteLine("﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.");
            writer.WriteLine("﻿// See the License for the specific language governing permissions and");
            writer.WriteLine("﻿// limitations under the License.");
            writer.WriteLine("﻿// -----------------------------------------------------------------------------");
        }

        private static void GenerateUsingDirectives(CodeNamespace codeNamespace)
        {
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            codeNamespace.Imports.Add(new CodeNamespaceImport("Microsoft.Azure.Batch"));
        }

        private static void GenerateConstructors(Type t, CodeTypeDeclaration codeType)
        {
            CodeFieldReferenceExpression omObjectFieldReference = new(new CodeThisReferenceExpression(), OmObject);

            ConstructorInfo[] constructors = t.GetConstructors();
            ConstructorInfo publicParameterless = null;
            List<ConstructorInfo> publicGeneralParams = new();
            foreach (ConstructorInfo con in constructors.Where(c => c.IsPublic || c.IsStatic))
            {
                ParameterInfo[] parameters = con.GetParameters();
                if (parameters == null || parameters.Length == 0)
                {
                    publicParameterless = con;
                }
                else if (con.IsStatic)
                {
                }
                else
                {
                    publicGeneralParams.Add(con);
                }
            }

            if (publicParameterless != null)
            {
                CodeConstructor constructor = new();
                constructor.Attributes = MemberAttributes.Public;
                CodeObjectCreateExpression createExpression = new(t);
                constructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, createExpression));
                codeType.Members.Add(constructor);
            }

            foreach (ConstructorInfo c in publicGeneralParams)
            {
                AddConstructorWithCopiedParameters(codeType, t, omObjectFieldReference, c);
            }

            // Default internal constructor that accepts the OM object to wrap
            CodeConstructor defaultConstructor = new();
            defaultConstructor.Attributes = MemberAttributes.Assembly;
            CodeParameterDeclarationExpression omObjectParameter = new(t.IsEnum ? $"{t.FullName}?" : t.FullName, OmObject);
            defaultConstructor.Parameters.Add(omObjectParameter);
            CodeArgumentReferenceExpression omObjectArgumentReference = new(OmObject);
            CodeObjectCreateExpression createException = new(typeof(ArgumentNullException), new CodePrimitiveExpression(OmObject));
            CodeThrowExceptionStatement throwException = new(createException);
            CodeBinaryOperatorExpression nullCheck = new(omObjectArgumentReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));

            // if the parameter is null, throw an exception
            defaultConstructor.Statements.Add(new CodeConditionStatement(nullCheck, throwException));

            defaultConstructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, omObjectArgumentReference));
            codeType.Members.Add(defaultConstructor);
        }

        private static void AddConstructorWithCopiedParameters(CodeTypeDeclaration codeType, Type implementationType, CodeFieldReferenceExpression omObjectFieldReference, ConstructorInfo constructorInfo)
        {
            CodeConstructor constructor = new();
            constructor.Attributes = MemberAttributes.Public;

            ParameterInfo[] parameters = constructorInfo.GetParameters();
            CodeExpression[] codeArgumentReferences = new CodeExpression[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                bool isOmTypeArg = false;
                ParameterInfo parameter = parameters[i];
                string paramName = parameter.Name;
                string paramType = parameter.ParameterType.FullName;
                //string paramType = GetFullName(parameter.ParameterType);
                if (OMtoPSClassMappings.ContainsKey(paramType))
                {
                    paramType = OMtoPSClassMappings[paramType];
                    isOmTypeArg = true;
                }

                string passedInArg;

                // Create the proper parameter for optional
                if (parameter.IsOptional)
                {
                    paramName = paramType.Contains("System")
                        ? string.Format("{0} = null", parameter.Name)
                        : string.Format("{0} = default({1})", parameter.Name, paramType);
                }

                // Need to do a null check for calling an omObject from a PS wrapper class
                if (isOmTypeArg && parameter.IsOptional)
                {
                    CodeVariableDeclarationStatement omObjectDeclaration = new(
                        parameter.ParameterType,
                        string.Format("{0}{1}", parameter.Name, "OmObject"),
                        new CodePrimitiveExpression(null));

                    constructor.Statements.Add(omObjectDeclaration);

                    CodeArgumentReferenceExpression omObjectArgumentReference = new(parameter.Name);
                    CodeAssignStatement omObjectAssignStatement = new(new CodeVariableReferenceExpression(string.Format("{0}{1}", parameter.Name, "OmObject")), new CodeVariableReferenceExpression(string.Format("{0}.{1}", parameter.Name, OmObject)));
                    CodeBinaryOperatorExpression nullCheck = new(omObjectArgumentReference, CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null));

                    // if the parameter is not null, use the omObject of the PS Wrapper class
                    constructor.Statements.Add(new CodeConditionStatement(nullCheck, omObjectAssignStatement));

                    passedInArg = string.Format("{0}{1}", parameter.Name, "OmObject");
                }
                else if (isOmTypeArg)
                {
                    passedInArg = string.Format("{0}.{1}", parameter.Name, OmObject);
                }
                else
                {
                    passedInArg = parameter.Name;
                }

                codeArgumentReferences[i] = new CodeArgumentReferenceExpression(passedInArg);
                constructor.Parameters.Add(new CodeParameterDeclarationExpression(paramType, paramName));
            }

            CodeObjectCreateExpression createExpression = new(implementationType, codeArgumentReferences);
            constructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, createExpression));
            codeType.Members.Add(constructor);
        }

        private static void GenerateProperties(Type t, CodeTypeDeclaration codeType)
        {
            foreach (PropertyInfo property in t.GetProperties())
            {
                string propertyFullName = GetFullName(property.PropertyType);

                if (OmittedProperties.ContainsKey(t.FullName) && OmittedProperties[t.FullName].Contains(property.Name))
                {
                    continue;
                }

                if (property.CustomAttributes.Any(x => x.AttributeType.FullName.Contains("Obsolete")))
                {
                    continue;
                }

                string propertyType = GetPropertyType(property.PropertyType);
                bool isGenericCollection = property.PropertyType.IsGenericType &&
                    (property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) ||
                    property.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                    property.PropertyType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>));

                CodeFieldReferenceExpression wrappedObject = new(new CodeThisReferenceExpression(), OmObject);
                CodePropertyReferenceExpression wrappedObjectProperty = new(wrappedObject, property.Name);
                CodeFieldReferenceExpression fieldReference = null;
                if (isGenericCollection || OMtoPSClassMappings.ContainsKey(propertyFullName))
                {
                    // Add a backing field for the property with the same name but using camel case.
                    string fieldName = $"{property.Name.ToLower()[0]}{property.Name[1..]}";
                    CodeMemberField backingField = new();
                    backingField.Attributes = MemberAttributes.Private;
                    backingField.Name = fieldName;
                    backingField.Type = new CodeTypeReference(propertyType);
                    codeType.Members.Add(backingField);

                    fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName);
                }

                CodeMemberProperty codeProperty = new();
                codeProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                codeProperty.Name = property.Name;
                codeProperty.Type = new CodeTypeReference(propertyType);

                // For properties with a backing field, the field will not be initialized in the constructor in order to avoid
                // hitting a run time access constraint from the OM. Instead, the field is initialized on the first access of
                // the property.

                if (isGenericCollection)
                {
                    GenerateGenericCollectionProperty(property, propertyType, fieldReference, wrappedObjectProperty, codeProperty);
                }
                else if (OMtoPSClassMappings.ContainsKey(propertyFullName))
                {
                    GenerateMappedProperty(property, propertyFullName, fieldReference, wrappedObjectProperty, codeProperty);
                }
                else
                {
                    // By default, just pass through to the wrapped OM object's property.
                    if (property.GetMethod != null && property.GetMethod.IsPublic)
                    {
                        codeProperty.HasGet = true;
                        codeProperty.GetStatements.Add(new CodeMethodReturnStatement(wrappedObjectProperty));
                    }
                    if (property.SetMethod != null && property.SetMethod.IsPublic)
                    {
                        codeProperty.HasSet = true;
                        codeProperty.SetStatements.Add(new CodeAssignStatement(wrappedObjectProperty, new CodePropertySetValueReferenceExpression()));
                    }
                }
                codeType.Members.Add(codeProperty);
            }
        }

        private static void GenerateGenericCollectionProperty(PropertyInfo property, string propertyType, CodeFieldReferenceExpression fieldReference, CodePropertyReferenceExpression wrappedObjectProperty, CodeMemberProperty codeProperty)
        {
            // Special handling for dict
            Type argType = property.PropertyType.GetGenericArguments()[0];
            bool magicalDictConversion = propertyType == "IDictionary";
            string wrapperArgType = argType.FullName.StartsWith("System") || argType.FullName.StartsWith("Microsoft.Azure.Batch.Common") ? argType.FullName : OMtoPSClassMappings[argType.FullName];
            string wrapperType = magicalDictConversion ? string.Format("Dictionary<string, string>") : string.Format("List<{0}>", wrapperArgType);
            string variableName = magicalDictConversion ? "dict" : "list";
            if (property.GetMethod != null && property.GetMethod.IsPublic)
            {
                // Collections are not kept in sync with the wrapped OM object. Cmdlets will need to sync them before sending
                // a request to the server.
                CodeVariableDeclarationStatement declaration = new(wrapperType, variableName);
                CodeVariableReferenceExpression reference = new(variableName);
                CodeAssignStatement initialize = new(reference, new CodeObjectCreateExpression(wrapperType));

                // CodeDom doesn't support foreach loops very well, so instead explicitly get the enumerator and loop on MoveNext() calls
                const string enumeratorVariableName = "enumerator";
                CodeVariableDeclarationStatement enumeratorDeclaration = new(string.Format("IEnumerator<{0}>", argType.FullName), enumeratorVariableName);
                CodeVariableReferenceExpression enumeratorReference = new(enumeratorVariableName);
                CodeAssignStatement initializeEnumerator = new(enumeratorReference, new CodeMethodInvokeExpression(wrappedObjectProperty, "GetEnumerator"));
                CodeIterationStatement loopStatement = new();
                loopStatement.TestExpression = new CodeMethodInvokeExpression(enumeratorReference, "MoveNext");
                loopStatement.IncrementStatement = new CodeSnippetStatement(string.Empty);
                loopStatement.InitStatement = new CodeSnippetStatement(string.Empty);
                CodePropertyReferenceExpression enumeratorCurrent = new(enumeratorReference, "Current");

                // Fill the list by individually wrapping each item in the loop
                if (magicalDictConversion)
                {
                    var keyReference = new CodePropertyReferenceExpression(enumeratorCurrent, OMToPSDictionaryConversionMappings[argType.FullName].Item1);
                    var valueReference = new CodePropertyReferenceExpression(enumeratorCurrent, OMToPSDictionaryConversionMappings[argType.FullName].Item2);
                    CodeMethodInvokeExpression addToList = new(reference, "Add", keyReference, valueReference);
                    loopStatement.Statements.Add(addToList);
                }
                else
                {
                    // Fill the list by individually wrapping each item in the loop
                    if (wrapperArgType.Contains("System") || wrapperArgType.StartsWith("Microsoft.Azure.Batch.Common"))
                    {
                        CodeMethodInvokeExpression addToList = new(reference, "Add", enumeratorCurrent);
                        loopStatement.Statements.Add(addToList);
                    }
                    else
                    {
                        CodeObjectCreateExpression createListItem = new(wrapperArgType, enumeratorCurrent);
                        CodeMethodInvokeExpression addToList = new(reference, "Add", createListItem);
                        loopStatement.Statements.Add(addToList);
                    }
                }
                // Initialize the backing field with the built list on first access of the property
                CodeAssignStatement assignStatement = new(fieldReference, reference);

                CodePrimitiveExpression nullExpression = new(null);
                CodeBinaryOperatorExpression fieldNullCheck = new(fieldReference, CodeBinaryOperatorType.IdentityEquality, nullExpression);
                CodeBinaryOperatorExpression wrappedPropertyNullCheck = new(wrappedObjectProperty, CodeBinaryOperatorType.IdentityInequality, nullExpression);
                CodeBinaryOperatorExpression condition = new(fieldNullCheck, CodeBinaryOperatorType.BooleanAnd, wrappedPropertyNullCheck);
                CodeConditionStatement ifBlock = new(condition, declaration, initialize, enumeratorDeclaration, initializeEnumerator, loopStatement, assignStatement);
                codeProperty.GetStatements.Add(ifBlock);
                codeProperty.GetStatements.Add(new CodeMethodReturnStatement(fieldReference));
            }

            if (property.SetMethod != null && property.SetMethod.IsPublic)
            {
                // Call the "set" on the OM object to ensure that constraints are enforced.
                codeProperty.HasSet = true;
                CodePropertySetValueReferenceExpression valueReference = new();
                CodeBinaryOperatorExpression nullCheck = new(valueReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));
                CodeAssignStatement nullAssignment = new(wrappedObjectProperty, new CodePrimitiveExpression(null));
                CodeAssignStatement nonNullAssignment = new(wrappedObjectProperty, new CodeObjectCreateExpression(string.Format("List<{0}>", argType.FullName)));
                CodeConditionStatement ifBlock = new(nullCheck, new CodeStatement[] { nullAssignment }, new CodeStatement[] { nonNullAssignment });
                codeProperty.SetStatements.Add(ifBlock);
                codeProperty.SetStatements.Add(new CodeAssignStatement(fieldReference, valueReference));
            }

        }

        private static void GenerateMappedProperty(PropertyInfo property, string propertyFullName, CodeFieldReferenceExpression fieldReference, CodePropertyReferenceExpression wrappedObjectProperty, CodeMemberProperty codeProperty)
        {
            if (property.GetMethod != null && property.GetMethod.IsPublic)
            {
                codeProperty.HasGet = true;
                CodeObjectCreateExpression createFieldObject = new(OMtoPSClassMappings[propertyFullName], wrappedObjectProperty);
                CodeAssignStatement assignStatement = new(fieldReference, createFieldObject);
                CodePrimitiveExpression nullExpression = new(null);
                CodeBinaryOperatorExpression fieldNullCheck = new(fieldReference, CodeBinaryOperatorType.IdentityEquality, nullExpression);
                CodeBinaryOperatorExpression wrappedPropertyNullCheck = new(wrappedObjectProperty, CodeBinaryOperatorType.IdentityInequality, nullExpression);
                CodeBinaryOperatorExpression condition = new(fieldNullCheck, CodeBinaryOperatorType.BooleanAnd, wrappedPropertyNullCheck);
                CodeConditionStatement ifBlock = new(condition, assignStatement);
                codeProperty.GetStatements.Add(ifBlock);
                codeProperty.GetStatements.Add(new CodeMethodReturnStatement(fieldReference));
            }
            if (property.SetMethod != null && property.SetMethod.IsPublic)
            {
                codeProperty.HasSet = true;
                CodePropertySetValueReferenceExpression valueReference = new();
                CodeBinaryOperatorExpression nullCheck = new(valueReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));
                CodeAssignStatement nullAssignment = new(wrappedObjectProperty, new CodePrimitiveExpression(null));
                CodePropertyReferenceExpression valueProperty = new(valueReference, OmObject);
                CodeAssignStatement nonNullAssignment = new(wrappedObjectProperty, valueProperty);
                CodeConditionStatement ifBlock = new(nullCheck, new CodeStatement[] { nullAssignment }, new CodeStatement[] { nonNullAssignment });
                codeProperty.SetStatements.Add(ifBlock);
                codeProperty.SetStatements.Add(new CodeAssignStatement(fieldReference, valueReference));
            }
        }

        private static void GenerateCodeFile(string fileName, CodeCompileUnit compileUnit)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new();
            options.BracingStyle = "C";

            using StreamWriter sourceWriter = new(fileName);
            GenerateCopyrightText(sourceWriter);
            provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options);
        }

        private static bool IsGenericNullable(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static string GetFullName(Type t)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return t.GetGenericArguments()[0].FullName;
            }

            return t.FullName;
        }

        private static string GetPropertyType(Type t)
        {
            if (t.IsEnum)
            {
                return t.FullName;
            }
            else if (t == typeof(string) || t.IsPrimitive || t == typeof(DateTime) || t == typeof(TimeSpan) || t == typeof(object))
            {
                return t.FullName;
            }
            else if (IsGenericNullable(t))
            {
                Type argType = t.GetGenericArguments()[0];
                if (argType.IsEnum && OMtoPSClassMappings.ContainsKey(argType.FullName))
                {
                    return OMtoPSClassMappings[argType.FullName];
                }

                return string.Format("{0}?", GetPropertyType(argType));
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
            {
                Type argType = t.GetGenericArguments()[0];

                if (OMToPSDictionaryConversionMappings.ContainsKey(argType.FullName))
                {
                    return "IDictionary";
                }

                string str = string.Format("IList<{0}>", GetPropertyType(argType));
                return str;
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
            {
                Type argType = t.GetGenericArguments()[0];

                if (OMToPSDictionaryConversionMappings.ContainsKey(argType.FullName))
                {
                    return "IDictionary";
                }

                string str = string.Format("IReadOnlyList<{0}>", GetPropertyType(argType));
                return str;
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                Type argType = t.GetGenericArguments()[0];

                if (OMToPSDictionaryConversionMappings.ContainsKey(argType.FullName))
                {
                    return "IDictionary";
                }

                string str = string.Format("IEnumerable<{0}>", GetPropertyType(argType));
                return str;
            }
            else if (OMtoPSClassMappings.ContainsKey(t.FullName))
            {
                return OMtoPSClassMappings[t.FullName];
            }
            else
            {
                throw new InvalidOperationException(string.Format("Unexpected type. No mapping defined for type {0}", t.FullName));
            }
        }
    }
}
