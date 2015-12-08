using Microsoft.CLU;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace System.Management.Automation
{
    /// <summary>
    /// This type provides methods that are used to create a pipeline of commands and invoke
    /// those commands either synchronously within a runspace. This class also provides access
    /// to the output streams that contain data that is generated when the commands are invoked.
    ///
    /// PowerShell::PSCommand : represents a collection of commands to run.
    /// PSCommand::CommandCollection
    ///                |
    ///                -- [
    ///                     Command1 {cmdtext, parameters}
    ///                     Command2 {cmdtext, parameters}
    ///                     Command3 {cmdtext, parameters}
    ///                     ...
    ///                   ]
    ///
    /// PowerShell::Invoke(input) : creates a pipeline and runs the commands in PowerShell::PSCommand
    /// PowerShell::Invoke(input) -> CLURunspace -- CLUPipeline
    ///                                                |
    ///                                               input -> pipe0 -> CmdletRunner(Command1 { cmdtext, parameters}) -> pipe1 -> CmdletRunner(Command2 { cmdtext, parameters}) -> pipe2 ->
    /// RETURN(PowerShell::Invoke(input)) : The result of pipeline execution.
    /// PowerShell::Streams : The merged stream result of all commands executed.
    /// </summary>
    public sealed class PowerShell : IDisposable
    {
        /// <summary>
        /// Gets or sets the commands of the pipeline invoked by the PowerShell object.
        /// </summary>
        public PSCommand Commands { get; set; }

        /// <summary>
        /// Backing field for HadErrors property.
        /// </summary>
        private bool _hadErrors;
        /// <summary>
        /// Gets a value that indicates whether an error occurred while executing the pipeline.
        /// </summary>
        public bool HadErrors
        {
            get
            {
                return _hadErrors;
            }
        }

        /// <summary>
        /// Gets or sets the runspace that is used when the pipeline is invoked.
        /// </summary>
        public Runspace Runspace { get; set; }

        /// <summary>
        /// Backing field for Streams property.
        /// </summary>
        private PSDataStreams _dataStreams;
        /// <summary>
        /// Gets the data streams that contain any messages and error reports that
        /// were generated when the pipeline of the PowerShell object is invoked.
        /// </summary>
        public PSDataStreams Streams
        {
            get
            {
                if (_dataStreams == null)
                {
                    throw new InvalidOperationException("Streams not available");
                }

                return _dataStreams;
            }
        }

        /// <summary>
        /// Initializes a new instance of the PowerShell class with an empty pipeline.
        /// </summary>
        /// <returns>An instance of PowerShell</returns>
        public static PowerShell Create()
        {
            var powerShell = new PowerShell();
            powerShell.Commands = new PSCommand();
            return powerShell;
        }

        /// <summary>
        /// Add a new command using it name and mark it as active command.
        /// </summary>
        /// <param name="command">The command name</param>
        /// <returns>A PowerShell object whose pipeline includes the command at the end of the pipeline</returns>
        public PowerShell AddCommand(string cmdlet)
        {
            Commands.AddCommand(cmdlet);
            return this;
        }

        /// <summary>
        /// Adds a switch parameter to the last command added to the pipeline.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        /// <returns>A PowerShell object with the specified switch parameter added to the last command of the pipeline</returns>
        public PowerShell AddParameter(string parameterName)
        {
            Commands.AddParameter(parameterName);
            return this;
        }

        /// <summary>
        /// Adds a parameter and value to the last command added to the pipeline.
        /// </summary>
        /// <param name="parameterName">The parameter name</param>
        /// <param name="value">The parameter value</param>
        /// <returns>A PowerShell object with the specified parameter added to the last command of the pipeline</returns>
        public PowerShell AddParameter(string parameterName, object value)
        {
            Commands.AddParameter(parameterName, value);
            return this;
        }

        /// <summary>
        /// Adds an argument for a positional parameter of a command without specifying the parameter name.
        /// </summary>
        /// <param name="value">Positional argument value</param>
        /// <returns>A PowerShell object with the argument added at the end of the pipeline</returns>
        public PowerShell AddArgument(object value)
        {
            Commands.AddArgument(value);
            return this;
        }

        /// <summary>
        /// Adds parameters to the last command of the pipeline.
        /// The parameter names and values are taken from the keys and values of the dictionary.
        /// </summary>
        /// <param name="parameters">A dictionary of the parameters to be added</param>
        /// <returns>A PowerShell object with the specified parameters added to the last command of the pipeline</returns>
        public PowerShell AddParameters(IDictionary parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            foreach (DictionaryEntry parameter in parameters)
            {
                string parameterName = parameter.Key as string;
                if (parameterName == null)
                {
                    throw new ArgumentException("All keys in the parameters set must be string");
                }

                Commands.AddParameter(parameterName, parameter.Value);
            }

            return this;
        }

        /// <summary>
        /// Adds a set of parameters to the last command of the pipeline.
        /// The parameter values are taken from the values in a list
        /// </summary>
        /// <param name="parameters">A list of the parameters to be added</param>
        /// <returns>A PowerShell object with the specified parameters added to the last command of the pipeline</returns>
        public PowerShell AddParameters(IList parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            foreach (var parameter in parameters)
            {
                Commands.AddArgument(parameter);
            }

            return this;
        }

        /// <summary>
        /// Synchronously runs the pipeline of the PowerShell object by using the supplied input data.
        /// </summary>
        /// <param name="input">Input data for the first command of the pipeline</param>
        /// <returns>A Collection collection of PSObject objects that contain the output of the pipeline</returns>
        public Collection<PSObject> Invoke(IEnumerable input)
        {
            if (Runspace == null)
            {
                throw new InvalidOperationException("Runspace is not initialized");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            Pipeline pipeline = Runspace.CreatePipeline();
            foreach (var cmd in Commands.Commands)
            {
                pipeline.Commands.Add(cmd);
            }

            var result = pipeline.Invoke(input);
            _hadErrors = pipeline.HadErrors;
            MergeStreams(pipeline.Streams);
            return result;
        }

        /// <summary>
        /// Synchronously runs the commands of the PowerShell object pipeline.
        /// </summary>
        /// <returns>A Collection collection of PSObject objects that contain the output of the pipeline</returns>
        public Collection<PSObject> Invoke()
        {
            return Invoke(new Collections.Generic.List<object>());
        }

        /// <summary>
        /// Merge the data streams and store the result in _dataStreams private field.
        /// </summary>
        /// <param name="streams">The streams to be merged</param>
        private void MergeStreams(IEnumerable<PSDataStreams> streams)
        {
            _dataStreams = new PSDataStreams();
            foreach (var stream in streams)
            {
                foreach (var debug in stream.Debug)
                {
                    _dataStreams.Debug.Add(debug);
                }

                foreach (var error in stream.Error)
                {
                    _dataStreams.Error.Add(error);
                }

                foreach (var warning in stream.Warning)
                {
                    _dataStreams.Warning.Add(warning);
                }

                foreach (var verbose in stream.Verbose)
                {
                    _dataStreams.Verbose.Add(verbose);
                }

                foreach (var progress in stream.Progress)
                {
                    _dataStreams.Progress.Add(progress);
                }
            }
        }

        public void Dispose()
        {}
    }
}
