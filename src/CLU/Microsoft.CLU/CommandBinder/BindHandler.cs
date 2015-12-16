using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// The supported parameter value sources.
    /// </summary>
    internal enum ParameterValueSource
    {
        None,
        FromPipeline,
        FromJsonDocumentsFile,
        FromJsonDocumentFile,
        FromString
    }

    /// <summary>
    /// Represents a parameter value from command-line.
    /// </summary>
    internal class ParameterValue
    {
        /// <summary>
        /// The parameter value as string.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The parameter value source.
        /// </summary>
        public ParameterValueSource Source { get; set; }

        /// <summary>
        /// Parse the given parameter value and crteate an instance of ParameterValue.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ParameterValue Parse(string value)
        {
            if (value == null)
            {
                return new ParameterValue
                {
                    Value = null,
                    Source = ParameterValueSource.None
                };
            }

            if (value.Equals(Constants.PipelineSourceStdinArgument))
            {
                return new ParameterValue
                {
                    Value = null,
                    Source = ParameterValueSource.FromPipeline
                };
            }

            if (value.StartsWith(Constants.PipelineSourceFileArgumentPrefix))
            {
                return new ParameterValue
                {
                    Value = value.Substring(2),
                    Source = ParameterValueSource.FromJsonDocumentsFile
                };
            }

            if (value.StartsWith(Constants.FileArgumentPrefix))
            {
                return new ParameterValue
                {
                    Value = value.Substring(1),
                    Source = ParameterValueSource.FromJsonDocumentFile
                };
            }

            return new ParameterValue
            {
                Value = value,
                Source = ParameterValueSource.FromString
            };
        }
    }

    /// <summary>
    /// The handler for parser bind events.
    /// </summary>
    internal class BindHandler
    {
        /// <summary>
        /// Create an instance of BindHandler.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="parameters"></param>
        public BindHandler(object instance, ParameterBindState state)
        {
            Debug.Assert(state != null);
            _instance = instance;
            _state = state;
            _parameters = state.Metadata.Parameters;
            _aliases = new Dictionary<char, ParameterMetadata>();

            var pipelineParameters = _parameters.Values.Where(p => p.TakesInputFromPipeline);
            if (pipelineParameters.Count() == 1)
            {
                _state.ReadFromStdinPipelineParameters.Add(pipelineParameters.First().Name);
            }

            foreach (var parameter in _parameters.Values.ToList())
            {
                foreach (var alias in parameter.Aliases)
                {
                    if (alias.Length > 1)
                        _parameters[alias.ToLowerInvariant()] = parameter;
                    else
                        _aliases[alias[0]] = parameter;
                }
            }
        }

        /// <summary>
        /// Bind named parameter.
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <param name="value">The parameter value</param>
        public void Bind(string name, string value)
        {
            if (_parameters.ContainsKey(name) || _aliases.ContainsKey(name[0]))
            {
                var parameter = _parameters.ContainsKey(name) ? _parameters[name] : _aliases[name[0]];

                name = parameter.Name.ToLowerInvariant();

                AddToAllArguments(name);

                _state.BoundParameterNames.Add(name);
                var parameterValue = ParameterValue.Parse(value);
                switch (parameterValue.Source)
                {
                    case ParameterValueSource.None:
                        return;
                    case ParameterValueSource.FromJsonDocumentFile:
                        InterpretAndSetValueEntirelyFromFile(parameter, parameterValue.Value);
                        return;
                    case ParameterValueSource.FromJsonDocumentsFile:
                        AddToReadFromFilePipelineParameters(name, parameterValue.Value);
                        return;
                    case ParameterValueSource.FromPipeline:
                        _state.ReadFromStdinPipelineParameters.Add(name);
                        return;
                    case ParameterValueSource.FromString:
                        parameter.InterpretAndSetValue(_instance, parameterValue.Value);
                        return;
                }
            }
            else
            {
                AddToAllArguments(name);
            }
        }

        /// <summary>
        /// Bind positional parameter
        /// </summary>
        /// <param name="position">The position of the value in the command line</param>
        /// <param name="value">The parameter value</param>
        public void Bind(int position, string value)
        {
            var parameterValue = ParameterValue.Parse(value);
            if (parameterValue.Source != ParameterValueSource.FromString &&
                parameterValue.Source != ParameterValueSource.None &&
                parameterValue.Source != ParameterValueSource.FromJsonDocumentFile)
            {
                throw new ArgumentException(string.Format(Strings.BindHandler_Bind_InvalidPositionalArgument, value));
            }

            if (parameterValue.Source == ParameterValueSource.FromJsonDocumentFile)
            {
                var fullFilePath = new FileInfo(parameterValue.Value).FullName;
                if (!System.IO.File.Exists(fullFilePath))
                {
                    throw new ArgumentException(string.Format(Strings.BindHandler_Bind_FileNotFound, fullFilePath));
                }
                _state.ReadFromPositionalFilesValues.Add(parameterValue.Value);
            }
            else
            {
                _state.ParameterPositionalStringValues.Add(value);
            }
        }

        /// <summary>
        /// Try bind switch parameter
        /// </summary>
        /// <param name="name">The parameter name</param>
        /// <returns></returns>
        public bool TryBindSwitch(string name)
        {
            bool isSwitch = false;
            if (_parameters.ContainsKey(name) || _aliases.ContainsKey(name[0]))
            {
                var parameter = _parameters.ContainsKey(name) ? _parameters[name] : _aliases[name[0]];
                name = parameter.Name.ToLowerInvariant();

                if (parameter.SwitchParameter)
                {
                    parameter.MarkPresent(_instance);
                    _state.BoundParameterNames.Add(name);
                    isSwitch = true;
                }
            }

            if (isSwitch)
            {
                AddToAllArguments(name);
            }

            return isSwitch;
        }

        /// <summary>
        /// Set the value of the parameter from the json document and cache the document.
        /// </summary>
        /// <param name="parameter">The parameter to bound</param>
        /// <param name="filePath">The json document file path</param>
        private void InterpretAndSetValueEntirelyFromFile(ParameterMetadata parameter, string filePath)
        {
            var fullFilePath = new FileInfo(filePath).FullName;
            if (!FilesToBeBoundEntirely.ContainsKey(fullFilePath))
            {
                if (System.IO.File.Exists(fullFilePath))
                {
                    using (var reader = System.IO.File.OpenText(fullFilePath))
                    {
                        FilesToBeBoundEntirely.Add(fullFilePath, reader.ReadToEnd());
                    }
                }
                else
                {
                    throw new ArgumentException(string.Format(Strings.BindHandler_InterpretAndSetValueEntirelyFromFile_FileNotFound, fullFilePath));
                }
            }

            var jsonDocument = FilesToBeBoundEntirely[fullFilePath];
            try
            {
                parameter.InterpretAndSetValue(_instance, jsonDocument);
            }
            catch (JsonException jsonException)
            {
                throw new ParameterBindingException(parameter.Name, filePath, jsonException);
            }
        }

        /// <summary>
        /// Add to the collection which holds pipeline arguments and files with json document.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <param name="filePath">The file path</param>
        private void AddToReadFromFilePipelineParameters(string parameterName, string filePath)
        {
            var fullFilePath = new FileInfo(filePath).FullName;
            if (!_state.ReadFromFilePipelineParameters.ContainsKey(fullFilePath))
            {
                _state.ReadFromFilePipelineParameters[fullFilePath] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            }
            _state.ReadFromFilePipelineParameters[fullFilePath].Add(parameterName);
        }

        /// <summary>
        /// Add given parameter name to the collection which holds all named argument and
        /// switch argument received from the parser.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        private void AddToAllArguments(string parameterName)
        {
            if (_state.AllArgumentNames.Contains(parameterName))
            {
                throw new ArgumentException(string.Format(Strings.BindHandler_AddToAllArguments_DuplicateArgumentFound, parameterName));
            }
            _state.AllArgumentNames.Add(parameterName);
        }

        #region Private fields

        /// <summary>
        /// The instance whose properties needs to be bound.
        /// </summary>
        private object _instance;

        /// <summary>
        /// Metadata of all parameters corrospodning to the properties
        /// in the _instance.
        /// </summary>
        private IDictionary<string, ParameterMetadata> _parameters;

        /// <summary>
        /// Metadata of all parameters corrospodning to the properties
        /// in the _instance, indexed by a single-char alias.
        /// </summary>
        private IDictionary<char, ParameterMetadata> _aliases;

        /// <summary>
        /// The bind state.
        /// </summary>
        private ParameterBindState _state;

        /// <summary>
        /// Dictionary to cache the contents of the files that to be bound entirely and immediately.
        /// </summary>
        private IDictionary<string, string> FilesToBeBoundEntirely = new Dictionary<string, string>();

        #endregion
    }
}
