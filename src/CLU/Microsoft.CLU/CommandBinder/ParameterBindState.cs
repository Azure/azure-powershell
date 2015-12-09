using Microsoft.CLU.Metadata;
using Microsoft.CLU.Common.Properties;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// Type whose instance holds parameter bind state.
    /// </summary>
    internal class ParameterBindState
    {
        /// <summary>
        /// Creates an instance of ParameterBindState.
        /// </summary>
        /// <param name="metadata"></param>
        public ParameterBindState(IMetadata metadata)
        {
            Debug.Assert(metadata != null);
            Metadata = metadata;
            _parameters = Metadata.Parameters;
            AllArgumentNames = new HashSet<string>();
            ReadFromPositionalFilesValues = new HashSet<string>();
            ReadFromStdinPipelineParameters = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            ReadFromFilePipelineParameters = new Dictionary<string, HashSet<string>>();
            ParameterPositionalStringValues = new List<string>();
            BoundParameterNames = new HashSet<string>();
            var pipelineParameters = _parameters.Values.Where(p => p.TakesInputFromPipeline);
            if (pipelineParameters.Count() == 1)
            {
                ReadFromStdinPipelineParameters.Add(pipelineParameters.First().Name);
            }

            if (File.Exists(Path.Combine(CLUEnvironment.GetRootPath(), "_defaults.json")))
            {
                ReadFromPositionalFilesValues.Add("_defaults.json");
            }
        }

        /// <summary>
        /// The parameters metadata.
        /// </summary>
        public IMetadata Metadata
        {
            get; internal set;
        }

        /// <summary>
        /// The parameters that takes values from the stdin.
        /// </summary>
        public HashSet<String> ReadFromStdinPipelineParameters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Represents files that can contain json documents (one json document per line
        /// in case of more than one documents)
        /// and parameters that takes values from the file.
        /// Key: The full path to the file.
        /// Value: The list of parameter names that takes values from the file identified
        /// by the key.
        ///
        /// Note: In the commandline these file-names will be prefixed with @@
        /// </summary>
        public Dictionary<string, HashSet<string>> ReadFromFilePipelineParameters
        {
            get;
            internal set;
        }

        /// <summary>
        /// Collection of positonal parameter file values.
        /// Note: In the commandline these file-names will be positional argument prefixed with @.
        /// </summary>
        public HashSet<string> ReadFromPositionalFilesValues
        {
            get;
            internal set;
        }

        /// <summary>
        /// Collection of positonal parameter values.
        /// </summary>
        public List<string> ParameterPositionalStringValues
        {
            get;
            internal set;
        }

        /// <summary>
        /// The set of parameter names that handler recevied from the parser
        /// and found as valid names.
        /// </summary>
        public HashSet<string> BoundParameterNames
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get unbound parameters.
        /// </summary>
        public IEnumerable<ParameterMetadata> UnboundParameters
        {
            get
            {
                return _parameters.Values.Where(paramter => !paramter.IsBound).Select(parameter => parameter);
            }
        }

        /// <summary>
        /// Names of all arguments received from the parser.
        /// </summary>
        public HashSet<string> AllArgumentNames
        {
            get;
            internal set;
        }

        /// <summary>
        /// Backing field for CandidateParameterSets property.
        /// </summary>
        HashSet<string> _candidateParameterSets;
        /// <summary>
        /// Gets the collection of candidate parameter sets.
        /// This method will return a subset of parameter sets which is valid
        /// for the current context based on bound parameters.
        /// </summary>
        public HashSet<string> CandidateParameterSets
        {
            get
            {
                if (_candidateParameterSets == null)
                {
                    HashSet<string> allParameterSets = new HashSet<string>(Metadata.AllParameterSets);
                    if (allParameterSets.Count > 0)
                    {
                        var allPresentParameters = BoundParameterNames
                            .Select(boundParameterName => _parameters[boundParameterName]);
                        foreach (var parameter in allPresentParameters.Where(p => p.ParameterSets.Count > 0))
                        {
                            var parameterSets = new HashSet<string>();
                            foreach (var parameterSet in parameter.ParameterSets.Keys)
                            {
                                parameterSets.Add(parameterSet);
                            }
                            if (parameterSets.Count > 0)
                            {
                                allParameterSets.IntersectWith(parameterSets);
                            }
                        }

                        if (allParameterSets.Count == 0)
                        {
                            throw new ArgumentException(Strings.ParameterBindState_CandidateParameterSets_ConflictingParameterSet);
                        }

                        _candidateParameterSets = allParameterSets;
                    }
                    else
                    {
                        _candidateParameterSets = allParameterSets;
                    }
                }

                return _candidateParameterSets;
            }
        }

        public IEnumerable<ParameterMetadata> CandidateParameters
        {
            get
            {
                if (_candidateParameters == null)
                {
                    var candidateParameterSets = CandidateParameterSets;
                    _candidateParameters = _parameters.Values
                        .Where(p => candidateParameterSets.IsEmpty() || !p.ParameterSets.Keys.Intersect(candidateParameterSets).IsEmpty());
                }

                return _candidateParameters;
            }
        }

        #region Private fields

        /// <summary>
        /// Metadata of all parameters corrospodning to the properties
        /// in the _instance.
        /// </summary>
        private IDictionary<string, ParameterMetadata> _parameters;

        /// <summary>
        /// The valid candidate parameters for the current context.
        /// </summary>
        private IEnumerable<ParameterMetadata> _candidateParameters;

        #endregion
    }
}
