using Microsoft.CLU;
using Microsoft.CLU.Common;
using Microsoft.PowerShell.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Linq;

namespace System.Management.Automation
{
    /// <summary>
    /// Represents a session state configuration that is used when a runspace is opened.
    /// </summary>
    public class InitialSessionState
    {
        /// <summary>
        /// Gets the list of modules is used to load the Cmdlets.
        /// </summary>
        public ReadOnlyCollection<ModuleSpecification> Modules
        {
            get
            {
                return new ReadOnlyCollection<ModuleSpecification>(_modulesConfiguration.SelectMany(s => s.GetListValue(Constants.CmdletModulesConfigKey)).Select(m => new ModuleSpecification(m)).ToList());
            }
        }

        /// <summary>
        /// Gets the list of module configurations that is used to load the Cmdlets.
        /// </summary>
        public IEnumerable<ConfigurationDictionary> ModulesConfigurations
        {
            get
            {
                if (_modulesConfiguration == null)
                {
                    return new List<ConfigurationDictionary>();
                }

                return _modulesConfiguration;
            }
        }

        /// <summary>
        /// Gets and sets a Boolean value that indicates whether an exception is thrown while opening the runspace.
        /// </summary>
        public bool ThrowOnRunspaceOpenError { get; set; }

        /// <summary>
        /// Create an instance of InitialSessionState.
        /// </summary>
        protected InitialSessionState()
        {
            _modulesConfiguration = new List<ConfigurationDictionary>();
        }

        /// <summary>
        /// Creates an instance of InitialSessionState.
        /// </summary>
        /// <returns>Instance of InitialSessionState</returns>
        public static InitialSessionState Create()
        {
            return new InitialSessionState();
        }

        /// <summary>
        /// Creates an instance of InitialSessionState with default configuration.
        /// </summary>
        /// <returns></returns>
        public static InitialSessionState CreateDefault()
        {
            return new InitialSessionState();
        }

        /// <summary>
        /// Import CLU Cmdlet modules (packages) by specifying their configuration.
        /// </summary>
        /// <param name="modulesConfiguration">The modules configuration</param>
        public void ImportPSModule(ConfigurationDictionary modulesConfiguration)
        {
            if (modulesConfiguration == null)
            {
                throw new ArgumentNullException("modulesConfiguration");
            }

            var modules = modulesConfiguration.GetListValue(Constants.CmdletModulesConfigKey);
            if (modules.Count() > 0)
            {
                _modulesConfiguration.Add(modulesConfiguration);
            }
        }

        /// <summary>
        /// Import CLU Cmdlet modules (packages) using their names.
        /// </summary>
        /// <param name="name">Module names</param>
        public void ImportPSModule(string[] name)
        {
            ConfigurationDictionary modulesConfiguration = new ConfigurationDictionary();
            modulesConfiguration.SetListValue(Constants.CmdletModulesConfigKey, name);
            ImportPSModule(modulesConfiguration);
        }

        #region Private fields

        private IList<ConfigurationDictionary> _modulesConfiguration;

        #endregion
    }
}