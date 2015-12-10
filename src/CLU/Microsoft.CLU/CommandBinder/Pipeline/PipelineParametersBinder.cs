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
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Reflection;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// A type that can bind pipeline parameters from a text reader (source of pipeline records).
    /// </summary>
    internal abstract class PipelineParametersBinder
    {
        /// <summary>
        /// Create an instance of PipelineParametersBinder.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance, this cannot be null</param>
        /// <param name="dynamicParameterInstance">The  dynamic parameter instance, this can be null</param>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="hasEmptyParameterSets">Indicates whether cmdlet has empty parameter set or not</param>
        public PipelineParametersBinder(Cmdlet cmdletInstance, object dynamicParameterInstance, ParameterBindState staticBindState, ParameterBindState dynamicBindState, bool hasEmptyParameterSets)
        {
            Debug.Assert(cmdletInstance != null);
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);

            _cmdletInstance = cmdletInstance;
            _dynamicParameterInstance = dynamicParameterInstance;
            _staticBindState = staticBindState;
            _dynamicBindState = dynamicBindState;
            _hasEmptyParameterSets = hasEmptyParameterSets;

            // TODO: We need to see the role parameterset for dynamic parameters and initialize
            // below two variables correctly, for now going ahead with static parameter parameter-sets.
            _parameterSets = _staticBindState.CandidateParameterSets;
        }

        /// <summary>
        /// Bind static and dynamic parameters those takes value from pipeline source. This method
        /// is guaranteed to invoke handleRecord atleast once.
        /// </summary>
        /// <param name="handleRecord">The call-back</param>
        /// <param name="pipeReadEnd">The source of pipeline records</param>
        public virtual void Bind(Action<HashSet<string>> handleRecord, PipelineReader<string> pipelineReader)
        {
            Debug.Assert(handleRecord != null);
            Debug.Assert(pipelineReader != null);
            _pipelineReader = pipelineReader;

            var staticPipelineParameter = StaticPipelineParameters.FirstOrDefault();
            if (staticPipelineParameter != null)
            {
                // Read json document records on the pipeline source one-by-one,
                // set it as value of STATIC parameter (one record at a time) and invoke handleRecord
                BindParameter(_cmdletInstance, staticPipelineParameter, handleRecord);
                return;
            }

            var dynamicPipelineParameter = DynamicPipelineParameters.FirstOrDefault();
            if (dynamicPipelineParameter != null)
            {
                // Read json document records on the pipeline source one-by-one,
                // set it as value of DYNAMIC parameter (one record at a time) and invoke handleRecord
                BindParameter(_dynamicParameterInstance, dynamicPipelineParameter, handleRecord);
                return;
            }

            // Read an entire json on the pipeline source and use to set values of mutliple STATIC and DYNAMIC parameters.
            BindParameters(handleRecord);
        }

        /// <summary>
        /// Bind a parameter using the json record from a pipeline source.
        /// </summary>
        /// <param name="instance">The instance in which parameter is defined.</param>
        /// <param name="parameter">The parameter to be bound from pipeline.</param>
        /// <param name="handleRecord">The call-back to be invoked for each record.</param>
        private void BindParameter(object instance, ParameterMetadata parameter, Action<HashSet<string>> handleRecord)
        {
            Debug.Assert(_pipelineReader != null);
            string line = _pipelineReader.Read();
            if (line == null)
            {
                handleRecord(_parameterSets);
            }
            else
            {
                while (line != null)
                {
                    line = line.Trim();
                    var parameterSets = ParameterSetsCopy;
                    line = BindParameterToDocumentData(instance, parameter, line, parameterSets);
                    handleRecord(parameterSets);
                    if (line == null)
                    {
                        line = _pipelineReader.Read();
                    }
                }
            }
        }

        /// <summary>
        /// Binds multiple static and dynamic parameters using the json record from a pipeline source.
        /// </summary>
        /// <param name="handleRecord">The call-back to be invoked for each record.</param>
        private void BindParameters(Action<HashSet<string>> handleRecord)
        {
            Debug.Assert(_pipelineReader != null);
            bool hasStaticPropertyByNameParameters = StaticPipelinePropertyByNameParameters.Any();
            bool hasDynamicPropertyByNameParameters = DynamicPipelinePropertyByNameParameters.Any();

            if (hasStaticPropertyByNameParameters | hasDynamicPropertyByNameParameters)
            {
                string line = _pipelineReader.Read();
                if (line == null)
                {
                    handleRecord(_parameterSets);
                }
                else
                {
                    var parameterSets = ParameterSetsCopy;
                    var candidateStaticParameters = StaticPipelinePropertyByNameParameters
                        .Where(p => !p.IsBound && (_hasEmptyParameterSets || parameterSets.Overlaps(p.ParameterSets.Keys)));
                    var candidateDynamicParameters = DynamicPipelinePropertyByNameParameters
                        .Where(p => !p.IsBound && (_hasEmptyParameterSets || parameterSets.Overlaps(p.ParameterSets.Keys)));

                    // Convert the candidates to list and use it. If we use Linq then bound using second
                    // record onwards will not work, Linq results in empty set since the parameters are
                    // already in bound state as a result of bounding with first record.
                    var candidateStaticParametersList = candidateStaticParameters.ToList();
                    var candidateDynamicParametersList = candidateDynamicParameters.ToList();
                    while (line != null)
                    {
                        line = line.Trim();
                        BindParametersToDocumentDataByProperty(_cmdletInstance, candidateStaticParametersList, line, parameterSets);
                        if (hasDynamicPropertyByNameParameters)
                        {
                            BindParametersToDocumentDataByProperty(_dynamicParameterInstance, candidateDynamicParametersList, line, parameterSets);
                        }
                        handleRecord(parameterSets);
                        line = _pipelineReader.Read();
                        parameterSets = ParameterSetsCopy;
                    }
                }
            }
            else
            {
                handleRecord(_parameterSets);
            }
        }

        /// <summary>
        /// Bind a pipline-parameter to the json records in the given document.
        /// </summary>
        /// <param name="instance">The instance in which pipeline-parmeter exists</param>
        /// <param name="pipelineParameter">The pipeline-parameter to bind</param>
        /// <param name="document">The document with json records</param>
        /// <param name="parameterSets">The parameter set</param>
        /// <returns></returns>
        private string BindParameterToDocumentData(object instance, ParameterMetadata pipelineParameter, string document, HashSet<string> parameterSets)
        {
            Debug.Assert(_pipelineReader != null);
            var runTime = _cmdletInstance.CommandRuntime;
            parameterSets.IntersectWith(pipelineParameter.ParameterSets.Keys.ToSet());
            if (pipelineParameter.ParameterType.IsArray)
            {
                if (document[0] == '[')
                {
                    pipelineParameter.InterpretAndSetValue(instance, document);
                    return null;
                }
                else
                {
                    var list = new List<object>();
                    while (document[0] != '[')
                    {
                        list.Add(pipelineParameter.InterpretValue(document, pipelineParameter.ParameterType.GetElementType()));
                        document = _pipelineReader.Read();
                        if (document == null)
                        {
                            break;
                        }

                        document = document.Trim();
                    }

                    var array = pipelineParameter.ParameterType.GetConstructors()[0].Invoke(new object[] { list.Count }) as IList;
                    for (int i = 0; i < list.Count; ++i)
                    {
                        array[i] = list[i];
                    }

                    pipelineParameter.SetValue(instance, array);
                    return document;
                }
            }
            else
            {
                pipelineParameter.InterpretAndSetValue(instance, document);
                return null;
            }
        }

        /// <summary>
        /// Bind pipline-parameters that takes value by property name from the json records in the given document.
        /// </summary>
        /// <param name="instance">The instance in which pipeline-parmeter exists</param>
        /// <param name="parameters">The pieline parameter (that takes value by property name) to bind</param>
        /// <param name="document">The document with json records</param>
        /// <param name="parameterSets">The parameter set</param>
        /// <returns></returns>
        private bool BindParametersToDocumentDataByProperty(object instance, IEnumerable<ParameterMetadata> parameters, string document, HashSet<string> parameterSets)
        {
            Debug.Assert(_pipelineReader != null);
            if (string.IsNullOrEmpty(document))
            {
                return false;
            }

            var json = JsonConvert.DeserializeObject(document) as JObject;
            // For invalid json objects such as e.g. primitive types, json records this deserialization will fail.
            if (json == null)
            {
                // e.g. file contains array [] which is not an object from which we can take value using property name.
                throw new ArgumentException(Strings.PipelineParametersBinder_BindParametersToDocumentDataByProperty_ParseDocumentAsJObjectFailed);
            }

            foreach (var parameter in parameters)
            {
                JToken jtoken;

                // First look up by name. If we didn't find a match on name, we'll go through all 
                // aliases to try to find a match.
                var foundMatch = json.TryGetValue(parameter.Name, StringComparison.OrdinalIgnoreCase, out jtoken);
                if (!foundMatch)
                {
                    foreach (var alias in parameter.Aliases)
                    {
                        if (json.TryGetValue(alias, StringComparison.OrdinalIgnoreCase, out jtoken))
                        {
                            foundMatch = true;
                            break;
                        }
                    }
                }

                if (foundMatch)
                {
                    parameterSets.IntersectWith(parameter.ParameterSets.Keys.ToSet());
                    if (parameter.ParameterType.Equals(typeof(string)) || parameter.ParameterType.GetTypeInfo().IsEnum)
                    {
                        parameter.InterpretAndSetValue(instance, (string)jtoken);
                    }
                    else
                    {
                        parameter.InterpretAndSetValue(instance, jtoken.ToString(Formatting.None));
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Get the unbounded static pipeline-parmeters.
        /// </summary>
        protected virtual IEnumerable<ParameterMetadata> StaticPipelineParameters
        {
            get
            {
                return _staticBindState.CandidateParameters
                    .Where(p => p.TakesInputFromPipeline && !p.IsBound);
            }
        }

        /// <summary>
        /// Get the unbounded dynamic pipeline-parmeters.
        /// </summary>
        protected virtual IEnumerable<ParameterMetadata> DynamicPipelineParameters
        {
            get
            {
                return _dynamicBindState.CandidateParameters
                    .Where(p => p.TakesInputFromPipeline && !p.IsBound);
            }
        }

        /// <summary>
        /// Get the collection of static parameters that can receives value from pipeline stream by property name.
        /// </summary>
        protected virtual IEnumerable<ParameterMetadata> StaticPipelinePropertyByNameParameters
        {
            get
            {
                return _staticBindState.CandidateParameters
                    .Where(p => p.TakesInputFromPipelineByPropertyName && !p.IsBound);
            }
        }

        /// <summary>
        /// Get the collection of dynamic parameters that can receives value from pipeline stream by property name.
        /// </summary>
        protected virtual IEnumerable<ParameterMetadata> DynamicPipelinePropertyByNameParameters
        {
            get
            {
                return _dynamicBindState.CandidateParameters
                    .Where(p => p.TakesInputFromPipelineByPropertyName && !p.IsBound);
            }
        }

        /// <summary>
        /// The state of static parameters binding
        /// </summary>
        protected ParameterBindState _staticBindState;

        /// <summary>
        /// The state of dynamic parameters binding
        /// </summary>
        protected ParameterBindState _dynamicBindState;

        /// <summary>
        /// The candiate parameter sets to be considered.
        /// </summary>
        protected HashSet<string> _parameterSets;

        /// <summary>
        /// The host.
        /// </summary>
        protected PSHost _host
        {
            get
            {
                return _cmdletInstance.CommandRuntime.Host;
            }
        }

        #region Private fields

        /// <summary>
        /// The cmdlet instance
        /// </summary>
        private Cmdlet _cmdletInstance;

        /// <summary>
        /// The dynamic parameter instance.
        /// </summary>
        private object _dynamicParameterInstance;

        /// <summary>
        /// The pipline json document source.
        /// </summary>
        private PipelineReader<string> _pipelineReader;

        /// <summary>
        /// Indidates whether there is any parameter set defined in the cmdlet.
        /// </summary>
        private bool _hasEmptyParameterSets;

        #endregion

        /// <summary>
        /// Get a new copy of parameter sets.
        /// </summary>
        HashSet<string> ParameterSetsCopy
        {
            get
            {
                return new HashSet<string>(_parameterSets);
            }
        }
    }
}
