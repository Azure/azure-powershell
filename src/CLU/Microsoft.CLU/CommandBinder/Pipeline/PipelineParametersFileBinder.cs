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
    /// The binder for binding pipeline parameters from pipeline source where the source is a multi-record FILE.
    /// </summary>
    internal class PipelineParametersFileBinder : PipelineParametersBinder
    {
        /// <summary>
        /// Create an instance of PipelineParametersFileBinder which can bind static and dynamic parameters
        /// from the pipeline json document.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance, this cannot be null</param>
        /// <param name="dynamicParameterInstance">The  dynamic parameter instance, this can be null</param>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="hasEmptyParameterSets">Indicates whether cmdlet has empty parameter set or not</param>
        public PipelineParametersFileBinder(Cmdlet cmdletInstance, object dynamicParameterInstance,
            ParameterBindState staticBindState, ParameterBindState dynamicBindState,
            MultiRecordSourceFile multiRecordSourceFile, bool hasEmptyParameterSets) : base(cmdletInstance, dynamicParameterInstance, staticBindState, dynamicBindState, hasEmptyParameterSets)
        {
            Debug.Assert(multiRecordSourceFile != null);
            _multiRecordSourceFile = multiRecordSourceFile;
            _inputParameterNames = staticBindState.ReadFromFilePipelineParameters[multiRecordSourceFile.FullPath];
        }

        /// <summary>
        /// Bind pipeline static and dynamic parameters those take value from mult-record source FILE.
        /// </summary>
        /// <param name="handleRecord">The call-back
        /// The handleRecord will be called each time a record from FILE get bound.
        /// The handleRecord will be called once if there is no FILE pipeline data
        /// or if there is no pipeline parameters eligible to bound from FILE pipeline.
        public void Bind(Action<HashSet<string>> handleRecord)
        {
            Debug.Assert(handleRecord != null);
            using (var pipelineSource = new PipelineFileReader(_multiRecordSourceFile.FullPath))
            {
                try
                {
                    base.Bind(handleRecord, pipelineSource);
                }
                catch (JsonException jsonException)
                {
                    throw new ParameterBindingException(string.Format(Strings.PipelineParametersFileBinder_Bind_PipelineParameterBindingFromFileFailed, _multiRecordSourceFile.FullPath), jsonException);
                }
            }
        }

        /// <summary>
        /// The static parameters to bound from mult-record source FILE.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> StaticPipelineParameters
        {
            get
            {
                return base.StaticPipelineParameters
                    .Where(p => _inputParameterNames.Contains(p.Name) && p.ParameterType.IsArray == _multiRecordSourceFile.IsArray);
            }
        }

        /// <summary>
        /// The dynamic parameters to bound from mult-record source FILE.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> DynamicPipelineParameters
        {
            get
            {
                return base.DynamicPipelineParameters
                    .Where(p => _inputParameterNames.Contains(p.Name) && p.ParameterType.IsArray == _multiRecordSourceFile.IsArray);
            }
        }

        /// <summary>
        /// The static parameters to bound from mult-record source FILE by property name.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> StaticPipelinePropertyByNameParameters
        {
            get
            {
                return base.StaticPipelinePropertyByNameParameters
                    .Where(p => _inputParameterNames.Contains(p.Name) && p.ParameterType.IsArray == _multiRecordSourceFile.IsArray);
            }
        }

        /// <summary>
        /// The dynamic parameters to bound from mult-record source FILE by property name.
        /// </summary>
        protected override IEnumerable<ParameterMetadata> DynamicPipelinePropertyByNameParameters
        {
            get
            {
                return base.DynamicPipelinePropertyByNameParameters
                    .Where(p => _inputParameterNames.Contains(p.Name) && p.ParameterType.IsArray == _multiRecordSourceFile.IsArray);
            }
        }

        #region Private fields.

        /// <summary>
        /// Represents a multi-record source FILE for pipeline parameters.
        /// </summary>
        private MultiRecordSourceFile _multiRecordSourceFile;

        /// <summary>
        /// The user input parameter names that takes value from multi-record source FILE.
        /// </summary>
        private HashSet<string> _inputParameterNames;

        #endregion
    }
}
