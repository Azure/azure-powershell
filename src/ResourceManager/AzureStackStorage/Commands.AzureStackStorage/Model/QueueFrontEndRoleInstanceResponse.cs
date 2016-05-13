using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    internal class QueueFrontEndRoleInstanceResponse : RoleInstanceResponseBase
    {
        public QueueFrontEndRoleInstanceResponse(QueueFrontEndRoleInstanceModel resource) : base(resource)
        {
            RoleType = RoleType.QueueFrontend;
        }

        public QueueFrontEndRoleInstanceEffectiveSettings Settings { get; set; }
    }
}
