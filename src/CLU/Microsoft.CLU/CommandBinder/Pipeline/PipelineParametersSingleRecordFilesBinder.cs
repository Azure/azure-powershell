using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// The binder for binding pipeline parameters from pipeline source where the source is single-record multiple FILES.
    /// </summary>
    internal class PipelineParametersSingleRecordFilesBinder
    {
        /// <summary>
        /// The path to the file which sholud be considered as single-record file.
        /// </summary>
        public string SkipFile { get; set; }

        public PipelineParametersSingleRecordFilesBinder(Cmdlet cmdletInstance, object dynamicParameterInstance,
            ParameterBindState staticBindState, ParameterBindState dynamicBindState)
        {
            Debug.Assert(cmdletInstance != null);
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);
            _cmdletInstance = cmdletInstance;
            _dynamicParameterInstance = dynamicParameterInstance;
            _staticBindState = staticBindState;
            _dynamicBindState = dynamicBindState;
            _readFromFilePipelineParameters = staticBindState.ReadFromFilePipelineParameters;
        }

        /// <summary>
        /// Bind the pipeline parameters from single-record FILES.
        /// </summary>
        /// <param name="parameterSets">The valid parameter-sets based on the current context</param>
        /// <returns>The resulting parameter-set after pipeline parameters binding</returns>
        public HashSet<string> BindOnce(HashSet<string> parameterSets)
        {
            if (_bounded)
            {
                return _savedParameterSets;
            }

            _bounded = true;
            if (_readFromFilePipelineParameters.Count == 0)
            {
                _savedParameterSets = new HashSet<string>(parameterSets);
                return _savedParameterSets;
            }

            var staticCandidateParameters = _staticBindState.CandidateParameters;
            var dynamicCandidateParameters = _dynamicBindState.CandidateParameters;

            Func<ParameterSetterFromFile, string, object, ParameterMetadata, bool, bool> Set = (setter, filePath, instance, parameter, isPropertyParam) =>
            {
                try
                {
                    return setter.Set(instance, parameter, isPropertyParam);
                }
                catch (JsonException jsonException)
                {
                    throw new ParameterBindingException(parameter.Name, filePath, jsonException);
                }
            };

            foreach (var entry in _readFromFilePipelineParameters)
            {
                if (!string.IsNullOrEmpty(SkipFile) && entry.Key.Equals(SkipFile))
                {
                    // Caller decided to handle this file by "PipelineParametersFileBinder"
                    continue;
                }

                ParameterSetterFromFile setter = new ParameterSetterFromFile(entry.Key);
                HashSet<string> parameterNames = entry.Value;

                var staticPipelineParameters = GetPipelineParameters(staticCandidateParameters, parameterNames);
                foreach (var staticPipelineParameter in staticPipelineParameters)
                {
                    bool isSet = Set(setter, entry.Key, _cmdletInstance, staticPipelineParameter, false);
                    if (isSet)
                    {
                        parameterSets.IntersectWith(staticPipelineParameter.ParameterSets.Keys.ToSet());
                    }
                }

                var dynamicPipelineParameters = GetPipelineParameters(dynamicCandidateParameters, parameterNames);
                foreach (var dynamicPipelineParameter in dynamicPipelineParameters)
                {
                    bool isSet = Set(setter, entry.Key, _dynamicParameterInstance, dynamicPipelineParameter, false);
                    if (isSet)
                    {
                        parameterSets.IntersectWith(dynamicPipelineParameter.ParameterSets.Keys.ToSet());
                    }
                }

                var staticPipelinePropertyParameters = GetPipelinePropertyParameters(staticCandidateParameters, parameterNames);
                foreach (var parameter in staticPipelinePropertyParameters)
                {
                    bool isSet = Set(setter, entry.Key, _cmdletInstance, parameter, true);
                    if (isSet)
                    {
                        parameterSets.IntersectWith(parameter.ParameterSets.Keys.ToSet());
                    }
                }

                var dynamicPipelinePropertyParameters = GetPipelinePropertyParameters(dynamicCandidateParameters, parameterNames);
                foreach (var parameter in staticPipelinePropertyParameters)
                {
                    bool isSet = Set(setter, entry.Key, _dynamicParameterInstance, parameter, true);
                    if (isSet)
                    {
                        parameterSets.IntersectWith(parameter.ParameterSets.Keys.ToSet());
                    }
                }
            }

            _savedParameterSets = new HashSet<string>(parameterSets);
            return _savedParameterSets;
        }

        /// <summary>
        /// From the given candiate parameters, get a subset of pipeline-parameters whose name matches with the inputParameterNames.
        /// </summary>
        /// <param name="candidateParameters">The candidate parameters</param>
        /// <param name="inputParameterNames">The parmater-names to match with</param>
        /// <returns>The matched Pipeline-parameters</returns>
        IEnumerable<ParameterMetadata> GetPipelineParameters(IEnumerable<ParameterMetadata> candidateParameters, HashSet<string> inputParameterNames)
        {
            return candidateParameters
                .Where(parameter => inputParameterNames.Contains(parameter.Name))
                .Where(p => p.TakesInputFromPipeline && !p.IsBound);
        }

        /// <summary>
        /// From the given candiate parameters, get a subset of pipeline-parameters (that takes value by property name) whose
        /// name matches with the inputParameterNames.
        /// </summary>
        /// <param name="candidateParameters">The candidate parameters</param>
        /// <param name="inputParameterNames">The parmater-names to match with</param>
        /// <returns>The matched Pipeline-parameters that take value by propery name</returns>
        IEnumerable<ParameterMetadata> GetPipelinePropertyParameters(IEnumerable<ParameterMetadata> candidateParameters, HashSet<string> inputParameterNames)
        {
           return candidateParameters
                .Where(parameter => inputParameterNames.Contains(parameter.Name))
                .Where(p => p.TakesInputFromPipelineByPropertyName && !p.IsBound);
        }

        #region Private fields

        /// <summary>
        /// Indicates whether the parameters are already bounded.
        /// </summary>
        private bool _bounded;

        /// <summary>
        /// The saved parameter-sets to return to caller if already bounded.
        /// </summary>
        private HashSet<string> _savedParameterSets;

        /// <summary>
        /// The user input parameter names to be bounded from the file represented using the key.
        /// </summary>
        private Dictionary<string, HashSet<string>> _readFromFilePipelineParameters;

        /// <summary>
        /// The cmdlet instance.
        /// </summary>
        private Cmdlet _cmdletInstance;

        /// <summary>
        /// The dynamic parameters instance.
        /// </summary>
        private object _dynamicParameterInstance;

        /// <summary>
        /// The state of the static parameters binding.
        /// </summary>
        private ParameterBindState _staticBindState;

        /// <summary>
        /// The state of the dynamic parameters binding.
        /// </summary>
        private ParameterBindState _dynamicBindState;

        #endregion
    }

    /// <summary>
    /// Type that can be used to set value of parameter from single-record json document file.
    /// </summary>
    internal class ParameterSetterFromFile
    {
        /// <summary>
        /// Creates an instance of ParameterSetterFromFile.
        /// </summary>
        /// <param name="filePath">The file containing json document</param>
        public ParameterSetterFromFile(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(string.Format(Strings.ParameterSetterFromFile_Ctor_FileNotFound, filePath));
            }
        }

        /// <summary>
        /// Set value of the parameter.
        /// </summary>
        /// <param name="instance">The instance of the type in which parameter is defined.</param>
        /// <param name="parameter">The parameter whose value needs to be set.</param>
        /// <param name="fromJsonDocumentProperty">Indicate whether value of parameter needs be set
        /// from a property of the json document.
        /// True, if value needs to be set from property in the json document.
        /// False, if the entire document to be set as parameter value.
        /// </param>
        /// <returns>true, if value set, false otherwise</returns>
        public bool Set(object instance, ParameterMetadata parameter, bool fromJsonDocumentProperty)
        {
            if (_jsonDocument != null)
            {
                if (fromJsonDocumentProperty)
                {
                    if (_jsonObject == null)
                    {
                        InitJsonObject();
                    }

                    return SetValueFromJObject(instance, parameter);
                }
                else
                {
                   return SetVaueFromJsonDocument(instance, parameter);
                }
            }
            else
            {
                if (_emptyDocument)
                {
                    return false;
                }

                using (var reader = File.OpenText(_filePath))
                {
                    _jsonDocument = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(_jsonDocument))
                    {
                        _emptyDocument = true;
                        return false;
                    }

                    if (fromJsonDocumentProperty)
                    {
                        InitJsonObject();
                        return SetValueFromJObject(instance, parameter);
                    }
                    else
                    {
                        return SetVaueFromJsonDocument(instance, parameter);
                    }
                }
            }
        }

        /// <summary>
        /// Set value of a parameter from Json document.
        /// </summary>
        /// <param name="instance">The instance of the type in which parameter is defined.</param>
        /// <param name="parameter">The parameter whose value needs to be set.</param>
        /// <returns>true, if value set, false otherwise</returns>
        private bool SetVaueFromJsonDocument(object instance, ParameterMetadata parameter)
        {
            string[] lines = _jsonDocument.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Count() == 0)
            {
                return false;
            }

            Action<string> CannotBind = (string reason) =>
            {
            throw new ArgumentException(string.Format(Strings.PipelineParametersSingleRecordFilesBinder_SetVaueFromJsonDocument_CouldNotBindFromFile, parameter.Name, parameter.ParameterType, _filePath, reason));
            };

            if (parameter.ParameterType.IsArray)
            {
                string line = lines[0].Trim();
                if (line[0] == '[')
                {
                    if (lines.Count() > 1)
                    {
                        CannotBind(Strings.PipelineParametersSingleRecordFilesBinder_SetVaueFromJsonDocument_UnExpectedMultiJsonArray);
                    }

                    parameter.InterpretAndSetValue(instance, lines[0].Trim());
                }
                else
                {
                    var list = new List<object>();
                    int idx = 1;
                    while (line[0] != '[')
                    {
                        list.Add(parameter.InterpretValue(line, parameter.ParameterType.GetElementType()));
                        if (idx == lines.Count())
                        {
                            break;
                        }

                        line = lines[idx].Trim();
                        idx++;
                    }

                    if (line[0] == '[')
                    {
                        CannotBind(Strings.PipelineParametersSingleRecordFilesBinder_SetVaueFromJsonDocument_ExpectedSingleJsonArray);
                    }

                    var array = parameter.ParameterType.GetConstructors()[0].Invoke(new object[] { list.Count }) as IList;
                    for (int i = 0; i < list.Count; ++i)
                    {
                        array[i] = list[i];
                    }

                    parameter.SetValue(instance, array);
                }
            }
            else
            {
                string line = lines[0].Trim();
                if (lines.Count() > 1)
                {
                    CannotBind(Strings.PipelineParametersSingleRecordFilesBinder_SetVaueFromJsonDocument_UnExpectedMultiJsonRecords);
                }

                if (line[0] == '[')
                {
                    CannotBind(Strings.PipelineParametersSingleRecordFilesBinder_SetVaueFromJsonDocument_FileContentParameterTypeMismatch);
                }

                parameter.InterpretAndSetValue(instance, line);
            }

            return true;
        }

        /// <summary>
        /// Set value of a parameter from JObject.
        /// </summary>
        /// <param name="instance">The instance cof type in which parameter is defined.</param>
        /// <param name="parameter">The parameter whose value needs to be set.</param>
        /// <returns></returns>
        public bool SetValueFromJObject(object instance, ParameterMetadata parameter)
        {
            JToken jtoken;
            if (_jsonObject.TryGetValue(parameter.Name, StringComparison.OrdinalIgnoreCase, out jtoken))
            {
                if (parameter.ParameterType.Equals(typeof(string)) || parameter.ParameterType.GetTypeInfo().IsEnum)
                {
                    parameter.InterpretAndSetValue(instance, (string)jtoken);
                }
                else
                {
                    parameter.InterpretAndSetValue(instance, jtoken.ToString(Formatting.None));
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Initialize the JObject from the json document.
        /// </summary>
        private void InitJsonObject()
        {
            _jsonObject = JsonConvert.DeserializeObject(_jsonDocument) as JObject;
            // For invalid json objects such as e.g. primitive types, json records
            // this deserialization will fail.
            if (_jsonObject == null)
            {
                // e.g. document contains array [] which is not an object from which
                // we can take value using property name.
                throw new ArgumentException(string.Format(Strings.PipelineParametersSingleRecordFilesBinder_InitJsonObject_ParseFileAsJObjectFailed, _filePath));
            }
        }

        /// <summary>
        /// The file containing json document.
        /// </summary>
        string _filePath;

        /// <summary>
        /// The content of json document file.
        /// </summary>
        string _jsonDocument;

        /// <summary>
        /// The content of json document file deserialized to JObject.
        /// </summary>
        JObject _jsonObject;

        /// <summary>
        /// Indicate whether the json document file is empty.
        /// </summary>
        bool _emptyDocument;
    }
}
