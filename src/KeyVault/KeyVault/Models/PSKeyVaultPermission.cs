using Azure.Security.KeyVault.Administration.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultPermission
    {
        /// <summary> Allowed actions. </summary>
        public string[] AllowedActions { get; }

        /// <summary> Denied actions. </summary>
        public string[] DeniedActions { get; }

        /// <summary> Allowed Data actions. </summary>
        public string[] AllowedDataActions { get; }

        /// <summary> Denied Data actions. </summary>
        public string[] DeniedDataActions { get; }

        public PSKeyVaultPermission(KeyVaultPermission permission)
        {
            AllowedActions = permission.Actions.ToArray();
            DeniedActions = permission.NotActions.ToArray();
            AllowedDataActions = permission.DataActions.ToArray();
            DeniedDataActions = permission.NotDataActions.ToArray();
        }
    }
}