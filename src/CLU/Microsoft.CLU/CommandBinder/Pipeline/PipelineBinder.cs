using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// The entry point for processing pipeline parameters. There are two sources for pipeline
    /// parameters
    /// 1. Stdin pipeline source.
    /// 2. File pipleline source, there are two type of such source:
    ///      a. A file with mutiple-records.
    ///      b. Multiple files with single record.
    /// The Bind method of this type invokes specialized classes to handle binding using these sources.
    /// </summary>
    internal class PipelineBinder
    {
        /// <summary>
        /// Create an instance of PipelineBinder.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance, this cannot be null</param>
        /// <param name="dynamicParameterInstance">The  dynamic parameter instance, this can be null</param>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="hasEmptyParameterSets">Indicates whether cmdlet has empty parameter set or not</param>
        /// <param name="handleRecord">The call-back to be invoked each time a pipeline record is bound</param>
        public PipelineBinder(Cmdlet cmdletInstance, object dynamicParameterInstance, ParameterBindState staticBindState,
            ParameterBindState dynamicBindState, bool hasEmptyParameterSets, Action<HashSet<string>> handleRecord)
        {
            Debug.Assert(cmdletInstance != null);
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);
            Debug.Assert(handleRecord != null);

            _cmdletInstance = cmdletInstance;
            _dynamicParameterInstance = dynamicParameterInstance;
            _staticBindState = staticBindState;
            _dynamicBindState = dynamicBindState;
            _hasEmptyParameterSets = hasEmptyParameterSets;
            _handleRecord = handleRecord;
        }

        /// <summary>
        /// Bind the pipline parameters.
        /// Note: This method is guaranteed to invoke handleRecord atleast once.
        /// The handleRecord will be called each time a record is get bound.
        /// The handleRecord will be called once if there is no pipeline data
        /// or if there is no pipeline parameters eligible to bound from pipeline.
        /// </summary>
        public void Bind()
        {
            var pipelineParametersSingleRecordFilesBinder = new PipelineParametersSingleRecordFilesBinder(_cmdletInstance, _dynamicParameterInstance,
                _staticBindState, _dynamicBindState);
            Action<HashSet<string>> handle = (HashSet<string> parameterSets) =>
            {
                var paramSets = pipelineParametersSingleRecordFilesBinder.BindOnce(parameterSets);
                _handleRecord(paramSets);
            };

            if (_cmdletInstance.CommandRuntime.Host.IsInputRedirected)
            {
                PipelineParametersStdinBinder pipelineParametersStdinBinder = new PipelineParametersStdinBinder(_cmdletInstance, _dynamicParameterInstance,
                    _staticBindState, _dynamicBindState, _hasEmptyParameterSets);

                pipelineParametersStdinBinder.Bind(handle);
            }
            else
            {
                var mutiRecordSourceFile = MultiRecordSourceFileFinder.Find(_staticBindState, _dynamicBindState);
                if (mutiRecordSourceFile != null)
                {
                    PipelineParametersFileBinder pipelineParametersFileBinder = new PipelineParametersFileBinder(_cmdletInstance, _dynamicParameterInstance,
                    _staticBindState, _dynamicBindState, mutiRecordSourceFile, _hasEmptyParameterSets);
                    pipelineParametersSingleRecordFilesBinder.SkipFile = mutiRecordSourceFile.FullPath;
                    pipelineParametersFileBinder.Bind(handle);
                }
                else
                {
                    handle(_staticBindState.CandidateParameterSets);
                }
            }
        }

        #region Private fields

        /// <summary>
        /// The cmdlet instance.
        /// </summary>
        private Cmdlet _cmdletInstance;

        /// <summary>
        /// The dynamic parameter instance.
        /// </summary>
        private object _dynamicParameterInstance;

        /// <summary>
        /// The state of static parameter binding.
        /// </summary>
        private ParameterBindState _staticBindState;

        /// <summary>
        /// The state of dynamic parameter binding.
        /// </summary>
        private ParameterBindState _dynamicBindState;

        /// <summary>
        /// Indidates whether there is any parameter set defined in the cmdlet.
        /// </summary>
        private bool _hasEmptyParameterSets;

        /// <summary>
        /// The call-back to be invoked after processing each record in the pipeline source.
        /// </summary>
        private Action<HashSet<string>> _handleRecord;

        #endregion
    }
}
