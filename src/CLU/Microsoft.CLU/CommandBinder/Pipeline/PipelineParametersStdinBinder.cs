using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// The binder for binding pipeline parameters from pipeline source where source is STDIN.
    /// </summary>
    internal class PipelineParametersStdinBinder : PipelineParametersBinder
    {
        /// <summary>
        /// Create an instance of PipelineParametersBinder which can bind static and dynamic parameters
        /// from the STDIN pipeline source.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance, this cannot be null</param>
        /// <param name="dynamicParameterInstance">The  dynamic parameter instance, this can be null</param>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="hasEmptyParameterSets">Indicates whether cmdlet has empty parameter set or not</param>
        public PipelineParametersStdinBinder(Cmdlet cmdletInstance, object dynamicParameterInstance,
            ParameterBindState staticBindState, ParameterBindState dynamicBindState,
            bool hasEmptyParameterSets) : base(cmdletInstance, dynamicParameterInstance, staticBindState, dynamicBindState, hasEmptyParameterSets)
        {}

        /// <summary>
        /// Bind static and dynamic parameters those takes value from STDIN pipeline source.
        /// </summary>
        /// <param name="handleRecord">The call-back
        /// The handleRecord will be called each time a record from STDIN get bound.
        /// The handleRecord will be called once if there is no STDIN pipeline data
        /// or if there is no pipeline parameters eligible to bound from STDIN pipeline.
        /// </param>
        public void Bind(Action<HashSet<string>> handleRecord)
        {
            Debug.Assert(handleRecord != null);
            if (!_host.IsInputRedirected)
            {
                handleRecord(_parameterSets);
                return;
            }

            var cluHost = _host as System.Management.Automation.Host.CLUHost;
            if (cluHost == null)
            {
                // Not localized as this should never happen unless we are trying to run unit tests with a mocked host...
                throw new InvalidOperationException($"Unknown host type {_host.GetType().FullName}  - are you running a unit test with a mocked host?");
            }

            try
            {
                base.Bind(handleRecord, cluHost.StreamInfo.ReadFromPipe.Reader);
            }
            catch (JsonException jsonException)
            {
                throw new ParameterBindingException(Strings.PipelineParametersStdinBinder_Bind_PipelineParameterBindingFromStdInFailed, jsonException);
            }
        }

        /// <summary>
        /// The static parameters which needs to bound from STDIN pipeline.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> StaticPipelineParameters
        {
            get
            {
                return base.StaticPipelineParameters
                    .Where(parameter => _staticBindState.ReadFromStdinPipelineParameters.Contains(parameter.Name));
            }
        }

        /// <summary>
        /// The dynamic parameters which needs to bound from STDIN pipeline.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> DynamicPipelineParameters
        {
            get
            {
                return base.DynamicPipelineParameters
                    .Where(parameter => _dynamicBindState.ReadFromStdinPipelineParameters.Contains(parameter.Name));
            }
        }
    }
}