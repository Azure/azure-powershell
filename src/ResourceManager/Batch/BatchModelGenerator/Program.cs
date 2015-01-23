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

namespace BatchModelGenerator
{
    public class Program
    {
        private const string ModelNamespace = "Microsoft.Azure.Commands.Batch.Models";
        private const string GeneratedFileDir = "GeneratedFiles";
        private const string OmObject = "omObject";

        private static string AssemblyPath;

        private static readonly Dictionary<string, string> OMtoPSClassMappings = new Dictionary<string, string>()
        {
            {"Microsoft.Azure.Batch.AffinityInformation", "PSAffinitiyInformation"},
            {"Microsoft.Azure.Batch.AutoScaleRun", "PSAutoScaleRun"},
            {"Microsoft.Azure.Batch.AutoScaleRunError", "PSAutoScaleRunError"},
            {"Microsoft.Azure.Batch.FileProperties", "PSFileProperties"},
            {"Microsoft.Azure.Batch.IAutoPoolSpecification", "PSAutoPoolSpecification"},
            {"Microsoft.Azure.Batch.ICertificateReference", "PSCertificateReference"},
            {"Microsoft.Azure.Batch.ICloudPool", "PSCloudPool"},
            {"Microsoft.Azure.Batch.ICloudJob", "PSCloudJob"},
            {"Microsoft.Azure.Batch.ICloudTask", "PSCloudTask"},
            {"Microsoft.Azure.Batch.ICloudWorkItem", "PSCloudWorkItem"},
            {"Microsoft.Azure.Batch.IEnvironmentSetting", "PSEnvironmentSetting"},
            {"Microsoft.Azure.Batch.IJobExecutionEnvironment", "PSJobExecutionEnvironment"},
            {"Microsoft.Azure.Batch.IJobManager", "PSJobManager"},
            {"Microsoft.Azure.Batch.IJobSpecification", "PSJobSpecification"},
            {"Microsoft.Azure.Batch.IMetadataItem", "PSMetadataItem"},
            {"Microsoft.Azure.Batch.IPoolSpecification", "PSPoolSpecification"},
            {"Microsoft.Azure.Batch.IResourceFile", "PSResourceFile"},
            {"Microsoft.Azure.Batch.IStartTask", "PSStartTask"},
            {"Microsoft.Azure.Batch.ITaskFile", "PSTaskFile"},
            {"Microsoft.Azure.Batch.IUser", "PSUser"},
            {"Microsoft.Azure.Batch.IVM", "PSVM"},
            {"Microsoft.Azure.Batch.IWorkItemExecutionInformation", "PSWorkItemExecutionInformation"},
            {"Microsoft.Azure.Batch.IWorkItemSchedule", "PSWorkItemSchedule"},
            {"Microsoft.Azure.Batch.IWorkItemStatistics", "PSWorkItemStatistics"},
            {"Microsoft.Azure.Batch.JobConstraints", "PSJobConstraints"},
            {"Microsoft.Azure.Batch.JobExecutionInformation", "PSJobExecutionInformation"},
            {"Microsoft.Azure.Batch.JobManager", "PSJobManager"},
            {"Microsoft.Azure.Batch.JobSchedulingError", "PSJobSchedulingError"},
            {"Microsoft.Azure.Batch.JobStatistics", "PSJobStatistics"},
            {"Microsoft.Azure.Batch.NameValuePair", "PSNameValuePair"},
            {"Microsoft.Azure.Batch.PoolStatistics", "PSPoolStatistics"},
            {"Microsoft.Azure.Batch.RecentJob", "PSRecentJob"},
            {"Microsoft.Azure.Batch.ResizeError", "PSResizeError"},
            {"Microsoft.Azure.Batch.ResourceFile", "PSResourceFile"},
            {"Microsoft.Azure.Batch.ResourceStatistics", "PSResourceStatistics"},
            {"Microsoft.Azure.Batch.SchedulingPolicy", "PSSchedulingPolicy"},
            {"Microsoft.Azure.Batch.StartTask", "PSStartTask"},
            {"Microsoft.Azure.Batch.StartTaskInformation", "PSStartTaskInformation"},
            {"Microsoft.Azure.Batch.TaskConstraints", "PSTaskConstraints"},
            {"Microsoft.Azure.Batch.TaskExecutionInformation", "PSTaskExecutionInformation"},
            {"Microsoft.Azure.Batch.TaskInformation", "PSTaskInformation"},
            {"Microsoft.Azure.Batch.TaskSchedulingError", "PSTaskSchedulingError"},
            {"Microsoft.Azure.Batch.TaskStatistics", "PSTaskStatistics"},
            {"Microsoft.Azure.Batch.UsageStatistics", "PSUsageStatistics"},
            {"Microsoft.Azure.Batch.VMError", "PSVMError"},
            {"Microsoft.Azure.Batch.VMInformation", "PSVMInformation"},
        };

        private static readonly Dictionary<string, string[]> OmittedProperties = new Dictionary<string, string[]>()
        {
            // Hide file staging for now - users can use storage cmdlets to upload files and generate SAS tokens
            {"Microsoft.Azure.Batch.ICloudTask", new string[] {"FilesToStage"}}
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

            if (Directory.Exists(GeneratedFileDir))
            {
                Directory.Delete(GeneratedFileDir, true);
            }
            Directory.CreateDirectory(GeneratedFileDir);

            foreach (KeyValuePair<string, string> mapping in OMtoPSClassMappings)
            {
                string fileName = string.Format("{0}\\{1}.cs", GeneratedFileDir, mapping.Value);
                // TODO: This check can be removed when the OM interfaces are gone, since the mapping should become 1:1
                if (!File.Exists(fileName))
                {
                    Type omType = omAssembly.GetType(mapping.Key);
                    if (omType == null)
                    {
                        throw new InvalidOperationException(string.Format("Unexpected type. Type {0} could not be found in {1}", mapping.Value, AssemblyPath));
                    }
                    GenerateModel(fileName, omType, mapping.Value);
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
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace(ModelNamespace);
            GenerateUsingDirectives(codeNamespace);
            CodeTypeDeclaration codeType = new CodeTypeDeclaration(modelName);
            codeType.IsClass = true;
            codeType.TypeAttributes = TypeAttributes.Public;
            codeNamespace.Types.Add(codeType);
            compileUnit.Namespaces.Add(codeNamespace);

            // The wrapped OM object
            CodeMemberField wrappedField = new CodeMemberField();
            wrappedField.Attributes = MemberAttributes.Assembly;
            wrappedField.Name = OmObject;
            wrappedField.Type = new CodeTypeReference(omType);
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
            Type implementationType = GetImplementationType(t);
            CodeFieldReferenceExpression omObjectFieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), OmObject);

            ConstructorInfo[] constructors = implementationType.GetConstructors();
            ConstructorInfo pulicParameterless = null;
            ConstructorInfo publicStringParams = null;
            foreach (ConstructorInfo con in constructors.Where(c => c.IsPublic))
            {
                ParameterInfo[] parameters = con.GetParameters();
                if (parameters == null || parameters.Length == 0)
                {
                    pulicParameterless = con;
                }
                else if (parameters.All(p => p.ParameterType == typeof(string)))
                {
                    publicStringParams = con;
                }
            }

            if (pulicParameterless != null)
            {
                CodeConstructor constructor = new CodeConstructor();
                constructor.Attributes = MemberAttributes.Public;
                CodeObjectCreateExpression createExpression = new CodeObjectCreateExpression(implementationType);
                constructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, createExpression));
                codeType.Members.Add(constructor);
            }

            if (publicStringParams != null)
            {
                CodeConstructor constructor = new CodeConstructor();
                constructor.Attributes = MemberAttributes.Public;

                ParameterInfo[] parameters = publicStringParams.GetParameters();
                CodeExpression[] codeArgumentReferences = new CodeExpression[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(String), parameters[i].Name));
                    codeArgumentReferences[i] = new CodeArgumentReferenceExpression(parameters[i].Name);
                }
                CodeObjectCreateExpression createExpression = new CodeObjectCreateExpression(implementationType, codeArgumentReferences);
                constructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, createExpression));
                codeType.Members.Add(constructor);
            }

            // TODO: Add handling for other public constructors with more complicated parameters

            // Default internal constructor that accepts the OM object to wrap
            CodeConstructor defaultConstructor = new CodeConstructor();
            defaultConstructor.Attributes = MemberAttributes.Assembly;
            CodeParameterDeclarationExpression omObjectParameter = new CodeParameterDeclarationExpression(t, OmObject);
            defaultConstructor.Parameters.Add(omObjectParameter);
            CodeArgumentReferenceExpression omObjectArgumentReference = new CodeArgumentReferenceExpression(OmObject);
            CodeObjectCreateExpression createException = new CodeObjectCreateExpression(typeof(ArgumentNullException), new CodePrimitiveExpression(OmObject));
            CodeThrowExceptionStatement throwException = new CodeThrowExceptionStatement(createException);
            CodeBinaryOperatorExpression nullCheck = new CodeBinaryOperatorExpression(omObjectArgumentReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));

            // if the parameter is null, throw an exception
            defaultConstructor.Statements.Add(new CodeConditionStatement(nullCheck, throwException));

            defaultConstructor.Statements.Add(new CodeAssignStatement(omObjectFieldReference, omObjectArgumentReference));
            codeType.Members.Add(defaultConstructor);
        }

        private static void GenerateProperties(Type t, CodeTypeDeclaration codeType)
        {
            foreach (PropertyInfo property in t.GetProperties())
            {
                if (OmittedProperties.ContainsKey(t.FullName) && OmittedProperties[t.FullName].Contains(property.Name))
                {
                    continue;
                }

                string propertyType = GetPropertyType(property.PropertyType);
                bool isGenericCollection = property.PropertyType.IsGenericType && 
                              (property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) || property.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                CodeFieldReferenceExpression wrappedObject = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), OmObject);
                CodePropertyReferenceExpression wrappedObjectProperty = new CodePropertyReferenceExpression(wrappedObject, property.Name);
                CodeFieldReferenceExpression fieldReference = null;
                if (isGenericCollection || OMtoPSClassMappings.ContainsKey(property.PropertyType.FullName))
                {
                    // Add a backing field for the property with the same name but using camel case.
                    string fieldName = string.Format("{0}{1}", property.Name.ToLower()[0], property.Name.Substring(1, property.Name.Length - 1));
                    CodeMemberField backingField = new CodeMemberField();
                    backingField.Attributes = MemberAttributes.Private;
                    backingField.Name = fieldName;
                    backingField.Type = new CodeTypeReference(propertyType);
                    codeType.Members.Add(backingField);

                    fieldReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName);
                }

                CodeMemberProperty codeProperty = new CodeMemberProperty();
                codeProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                codeProperty.Name = property.Name;
                codeProperty.Type = new CodeTypeReference(propertyType);

                // For properties with a backing field, the field will not be initialized in the constructor in order to avoid 
                // hitting a run time access constraint from the OM. Instead, the field is initialized on the first access of 
                // the property.

                if (isGenericCollection)
                {
                    // Collections are not kept in sync with the wrapped OM object. Cmdlets will need to sync them before sending
                    // a request to the server.
                    Type argType = property.PropertyType.GetGenericArguments()[0];
                    string wrapperArgType = OMtoPSClassMappings[argType.FullName];
                    string wrapperListType = string.Format("List<{0}>", wrapperArgType);

                    if (property.GetMethod != null && property.GetMethod.IsPublic)
                    {
                        codeProperty.HasGet = true;
                        // Build a list of wrapper objects
                        const string listVariableName = "list";
                        CodeVariableDeclarationStatement listDeclaration = new CodeVariableDeclarationStatement(wrapperListType, listVariableName);
                        CodeVariableReferenceExpression listReference = new CodeVariableReferenceExpression(listVariableName);
                        CodeAssignStatement initializeList = new CodeAssignStatement(listReference, new CodeObjectCreateExpression(wrapperListType));

                        // CodeDom doesn't support foreach loops very well, so instead explicitly get the enumerator and loop on MoveNext() calls
                        const string enumeratorVariableName = "enumerator";
                        CodeVariableDeclarationStatement enumeratorDeclaration = new CodeVariableDeclarationStatement(string.Format("IEnumerator<{0}>", argType.FullName), enumeratorVariableName);
                        CodeVariableReferenceExpression enumeratorReference = new CodeVariableReferenceExpression(enumeratorVariableName);
                        CodeAssignStatement initializeEnumerator = new CodeAssignStatement(enumeratorReference, new CodeMethodInvokeExpression(wrappedObjectProperty, "GetEnumerator"));
                        CodeIterationStatement loopStatement = new CodeIterationStatement();
                        loopStatement.TestExpression = new CodeMethodInvokeExpression(enumeratorReference, "MoveNext");
                        loopStatement.IncrementStatement = new CodeSnippetStatement(string.Empty);
                        loopStatement.InitStatement = new CodeSnippetStatement(string.Empty);
                        CodePropertyReferenceExpression enumeratorCurrent = new CodePropertyReferenceExpression(enumeratorReference, "Current");

                        // Fill the list by individually wrapping each item in the loop
                        CodeObjectCreateExpression createListItem = new CodeObjectCreateExpression(wrapperArgType, enumeratorCurrent);
                        CodeMethodInvokeExpression addToList = new CodeMethodInvokeExpression(listReference, "Add", createListItem);
                        loopStatement.Statements.Add(addToList);
                        
                        // Initialize the backing field with the built list on first access of the property
                        CodeAssignStatement assignStatement = new CodeAssignStatement(fieldReference, listReference);
                        CodePrimitiveExpression nullExpression = new CodePrimitiveExpression(null);
                        CodeBinaryOperatorExpression fieldNullCheck = new CodeBinaryOperatorExpression(fieldReference, CodeBinaryOperatorType.IdentityEquality, nullExpression);
                        CodeBinaryOperatorExpression wrappedPropertyNullCheck = new CodeBinaryOperatorExpression(wrappedObjectProperty, CodeBinaryOperatorType.IdentityInequality, nullExpression);
                        CodeBinaryOperatorExpression condition = new CodeBinaryOperatorExpression(fieldNullCheck, CodeBinaryOperatorType.BooleanAnd, wrappedPropertyNullCheck);
                        CodeConditionStatement ifBlock = new CodeConditionStatement(condition, listDeclaration, initializeList, enumeratorDeclaration, initializeEnumerator, loopStatement, assignStatement);
                        codeProperty.GetStatements.Add(ifBlock);
                        codeProperty.GetStatements.Add(new CodeMethodReturnStatement(fieldReference));
                    }
                    if (property.SetMethod != null && property.SetMethod.IsPublic)
                    {
                        // Call the "set" on the OM object to ensure that constraints are enforced.
                        codeProperty.HasSet = true;
                        CodePropertySetValueReferenceExpression valueReference = new CodePropertySetValueReferenceExpression();
                        CodeBinaryOperatorExpression nullCheck = new CodeBinaryOperatorExpression(valueReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));
                        CodeAssignStatement nullAssignment = new CodeAssignStatement(wrappedObjectProperty, new CodePrimitiveExpression(null));
                        CodeAssignStatement nonNullAssignment = new CodeAssignStatement(wrappedObjectProperty, new CodeObjectCreateExpression(string.Format("List<{0}>", argType.FullName)));
                        CodeConditionStatement ifBlock = new CodeConditionStatement(nullCheck, new CodeStatement[] { nullAssignment }, new CodeStatement[] { nonNullAssignment });
                        codeProperty.SetStatements.Add(ifBlock);
                        codeProperty.SetStatements.Add(new CodeAssignStatement(fieldReference, valueReference));
                    }
                }
                else if (OMtoPSClassMappings.ContainsKey(property.PropertyType.FullName))
                {
                    if (property.GetMethod != null && property.GetMethod.IsPublic)
                    {
                        codeProperty.HasGet = true;
                        CodeObjectCreateExpression createFieldObject = new CodeObjectCreateExpression(OMtoPSClassMappings[property.PropertyType.FullName], wrappedObjectProperty);
                        CodeAssignStatement assignStatement = new CodeAssignStatement(fieldReference, createFieldObject);
                        CodePrimitiveExpression nullExpression = new CodePrimitiveExpression(null);
                        CodeBinaryOperatorExpression fieldNullCheck = new CodeBinaryOperatorExpression(fieldReference, CodeBinaryOperatorType.IdentityEquality, nullExpression);
                        CodeBinaryOperatorExpression wrappedPropertyNullCheck = new CodeBinaryOperatorExpression(wrappedObjectProperty, CodeBinaryOperatorType.IdentityInequality, nullExpression);
                        CodeBinaryOperatorExpression condition = new CodeBinaryOperatorExpression(fieldNullCheck, CodeBinaryOperatorType.BooleanAnd, wrappedPropertyNullCheck);
                        CodeConditionStatement ifBlock = new CodeConditionStatement(condition, assignStatement);
                        codeProperty.GetStatements.Add(ifBlock);
                        codeProperty.GetStatements.Add(new CodeMethodReturnStatement(fieldReference));
                    }
                    if (property.SetMethod != null && property.SetMethod.IsPublic)
                    {
                        codeProperty.HasSet = true;
                        CodePropertySetValueReferenceExpression valueReference = new CodePropertySetValueReferenceExpression();
                        CodeBinaryOperatorExpression nullCheck = new CodeBinaryOperatorExpression(valueReference, CodeBinaryOperatorType.IdentityEquality, new CodePrimitiveExpression(null));
                        CodeAssignStatement nullAssignment = new CodeAssignStatement(wrappedObjectProperty, new CodePrimitiveExpression(null));
                        CodePropertyReferenceExpression valueProperty = new CodePropertyReferenceExpression(valueReference, OmObject);
                        CodeAssignStatement nonNullAssignment = new CodeAssignStatement(wrappedObjectProperty, valueProperty);
                        CodeConditionStatement ifBlock = new CodeConditionStatement(nullCheck, new CodeStatement[] { nullAssignment }, new CodeStatement[] { nonNullAssignment });
                        codeProperty.SetStatements.Add(ifBlock);
                        codeProperty.SetStatements.Add(new CodeAssignStatement(fieldReference, valueReference));
                    }
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

        private static void GenerateCodeFile(string fileName, CodeCompileUnit compileUnit)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                GenerateCopyrightText(sourceWriter);
                provider.GenerateCodeFromCompileUnit(compileUnit, sourceWriter, options);
            }
        }

        private static string GetPropertyType(Type t)
        {
            if (t.IsEnum || t == typeof(String) || t.IsPrimitive || t == typeof(DateTime) || t == typeof(TimeSpan))
            {
                return t.FullName;
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type argType = t.GetGenericArguments()[0];
                return string.Format("{0}?", GetPropertyType(argType));
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
            {
                Type argType = t.GetGenericArguments()[0];

                string str = string.Format("IList<{0}>", GetPropertyType(argType));
                return str;
            }
            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                Type argType = t.GetGenericArguments()[0];

                string str = string.Format("IEnumerable<{0}>", GetPropertyType(argType));
                return str;
            }
            else if (OMtoPSClassMappings.ContainsKey(t.FullName))
            {
                return OMtoPSClassMappings[t.FullName];
            }
            else
            {
                throw new InvalidOperationException(string.Format("Unexpected type. No mapping defined for type {0}", t.Name));
            }
        }

        // TODO: Remove once interfaces are gone
        private static Type GetImplementationType(Type t)
        {
            Type implType = t;
            if (t.IsInterface)
            {
                // Remove starting 'I' to get implementation class name.
                string implementationName = t.FullName.Replace(t.Name, t.Name.Substring(1, t.Name.Length - 1));
                Assembly omAssembly = System.Reflection.Assembly.LoadFile(AssemblyPath);
                Type temp = omAssembly.GetType(implementationName);
                if (temp != null)
                {
                    implType = temp;
                }
            }
            return implType;
        }   
    }
}
