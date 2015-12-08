using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Represents a Cmdlet details.
    /// </summary>
    internal class CmdletValue
    {
        /// <summary>
        /// Creates an instance of CmdletValue.
        /// </summary>
        /// <param name="commandDiscriminators">The command discriminators</param>
        /// <param name="cmdletIdentifier">The Cmdlet identifier</param>
        /// <param name="localPackage">The LocalPackage holding the Cmdlet</param>
        public CmdletValue(IEnumerable<string> commandDiscriminators, string cmdletIdentifier, LocalPackage localPackage)
        {
            Debug.Assert(commandDiscriminators != null);
            Debug.Assert(!string.IsNullOrEmpty(cmdletIdentifier));
            Debug.Assert(localPackage != null);

            CommandDiscriminators = commandDiscriminators;
            _cmdletIdentifier = cmdletIdentifier;
            Package = localPackage;
        }

        /// <summary>
        /// Lazy load the Cmdlet.
        /// </summary>
        /// <returns></returns>
        public Type LoadCmdlet()
        {
            if (_cmdlet == null)
            {
                var cmdletIdentifier = _cmdletIdentifier.Split(Constants.CmdletIndexItemValueSeparator);
                Debug.Assert(cmdletIdentifier.Length == 2);
                if (this.PackageAssembly == null)
                {
                    this.PackageAssembly = Package.LoadAssembly(cmdletIdentifier[0]);
                }
                Debug.Assert(this.PackageAssembly.Assembly != null);
                _cmdlet = this.PackageAssembly.Assembly.GetType(cmdletIdentifier[1]);
            }

            return _cmdlet;
        }

        public void Unload()
        {
        }

        public PackageAssembly PackageAssembly { get; private set;  }

        /// <summary>
        /// The LocalPackage instance in which the Cmdlet exists.
        /// </summary>
        public LocalPackage Package
        {
            get; private set;
        }

        /// <summary>
        /// The command discriminators.
        /// </summary>
        public IEnumerable<string> CommandDiscriminators
        {
            get; private set;
        }

        #region private fields

        /// <summary>
        /// The Cmdlet identifier.
        /// </summary>
        private string _cmdletIdentifier;

        /// <summary>
        /// The Cmdlet type.
        /// </summary>
        private Type _cmdlet;

        #endregion
    }
}
