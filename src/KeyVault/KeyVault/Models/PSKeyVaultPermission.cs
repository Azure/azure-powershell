using Azure.Security.KeyVault.Administration;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultPermission
    {
        /// <summary> Allowed actions. </summary>
        public string[] Actions { get; set; } = new string[] { };

        /// <summary> Excluded actions. </summary>
        public string[] NotActions { get; set; } = new string[] { };

        /// <summary> Allowed data actions. </summary>
        public string[] DataActions { get; set; } = new string[] { };

        /// <summary> Excluded data actions. </summary>
        public string[] NotDataActions { get; set; } = new string[] { };

        internal PSKeyVaultPermission(string[] actions, string[] notActions, string[] dataActions, string[] notDataActions)
        {
            Actions = actions;
            NotActions = notActions;
            DataActions = dataActions;
            NotDataActions = notDataActions;
        }

        /// <summary>
        /// For deserialization.
        /// </summary>
        public PSKeyVaultPermission()
        {
        }

        public PSKeyVaultPermission(KeyVaultPermission permission)
        {
            Actions = permission.Actions.ToArray();
            NotActions = permission.NotActions.ToArray();
            DataActions = permission.DataActions.Select(x => x.ToString()).ToArray();
            NotDataActions = permission.NotDataActions.Select(x => x.ToString()).ToArray();
        }
    }
}