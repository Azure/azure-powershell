using Azure.Security.KeyVault.Administration;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultPermission
    {
        /// <summary> Allowed actions. </summary>
        public string[] AllowedActions { get; set; } = new string[] { };

        /// <summary> Denied actions. </summary>
        public string[] DeniedActions { get; set; } = new string[] { };

        /// <summary> Allowed Data actions. </summary>
        public string[] AllowedDataActions { get; set; } = new string[] { };

        /// <summary> Denied Data actions. </summary>
        public string[] DeniedDataActions { get; set; } = new string[] { };

        internal PSKeyVaultPermission(string[] allowedActions, string[] deniedActions, string[] allowedDataActions, string[] deniedDataActions)
        {
            AllowedActions = allowedActions;
            DeniedActions = deniedActions;
            AllowedDataActions = allowedDataActions;
            DeniedDataActions = deniedDataActions;
        }

        /// <summary>
        /// For deserialization.
        /// </summary>
        public PSKeyVaultPermission()
        {
        }

        public PSKeyVaultPermission(KeyVaultPermission permission)
        {
            AllowedActions = permission.Actions.ToArray();
            DeniedActions = permission.NotActions.ToArray();
            AllowedDataActions = permission.DataActions.Select(x => x.ToString()).ToArray();
            DeniedDataActions = permission.NotDataActions.Select(x => x.ToString()).ToArray();
        }
    }
}