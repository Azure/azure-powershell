using Azure.Security.KeyVault.Administration.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultRoleDefinition
    {
        /// <summary> The role definition ID. </summary>
        public string Id { get; }

        /// <summary> The role definition name. </summary>
        public string Name { get; }

        /// <summary> The role definition type. </summary>
        public string Type { get; }

        /// <summary> The role name. </summary>
        public string RoleName { get; set; }

        /// <summary> The role definition description. </summary>
        public string Description { get; set; }

        /// <summary> The role type. </summary>
        public string RoleType { get; set; }

        /// <summary> Role definition permissions. </summary>
        public PSKeyVaultPermission[] Permissions { get; }

        /// <summary> Role definition assignable scopes. </summary>
        public string[] AssignableScopes { get; }

        public PSKeyVaultRoleDefinition(KeyVaultRoleDefinition roleDefinition)
        {
            Id = roleDefinition.Id;
            Name = roleDefinition.Name;
            Type = roleDefinition.Type;
            RoleName = roleDefinition.RoleName;
            Description = roleDefinition.Description;
            RoleType = roleDefinition.RoleType;
            AssignableScopes = roleDefinition.AssignableScopes.ToArray();
            Permissions = roleDefinition.Permissions.Select(permission => new PSKeyVaultPermission(permission)).ToArray();
        }
    }
}