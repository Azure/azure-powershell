using System;
using System.Diagnostics;
using System.Management.Automation;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// An entry point to get access to metadata information of a cmdlet and it's instance.
    /// </summary>
    internal class CmdletMetadata
    {
        /// <summary>
        /// The metadata information of the cmdlet type.
        /// </summary>
        public TypeMetadata Type { get; set; }

        /// <summary>
        /// The metadata information of the cmdlet instance.
        /// </summary>
        public InstanceMetadata Instance { get; private set; }

        /// <summary>
        /// Creates an instance of CmdletMetadata.
        /// </summary>
        /// <param name="cmdletType">The type of the cmdlet</param>
        /// <param name="cmdletInstance">The instance of a cmdlet</param>
        private CmdletMetadata(Type cmdletType, Cmdlet cmdletInstance)
        {
            Type = new TypeMetadata(cmdletType);
            Instance = new InstanceMetadata(cmdletInstance);
        }

        /// <summary>
        /// Loads metadata information of a cmdlet type and it's instance.
        /// </summary>
        /// <param name="cmdletType">The type of the cmdlet</param>
        /// <param name="cmdletInstance">The instance of a cmdlet</param>
        /// <returns></returns>
        public static CmdletMetadata Load(Type cmdletType, Cmdlet cmdletInstance)
        {
            Debug.Assert(cmdletType != null);
            Debug.Assert(cmdletInstance != null);

            var cmdletMetadata = new CmdletMetadata(cmdletType, cmdletInstance);
            cmdletMetadata.Type.Load();
            // DON'T load the instance metadata now! This needs to be delayed
            // until static property boundings are done.
            // cmdletMetadata.Instance.Load();
            return cmdletMetadata;
        }

        /// <summary>
        /// Loads metadata information of a cmdlet type and it's instance.
        /// </summary>
        /// <param name="cmdletInstance">The instance of a cmdlet</param>
        /// <returns></returns>
        public static CmdletMetadata Load(Cmdlet cmdletInstance)
        {
            Debug.Assert(cmdletInstance != null);
            return Load(cmdletInstance.GetType(), cmdletInstance);
        }
    }
}
