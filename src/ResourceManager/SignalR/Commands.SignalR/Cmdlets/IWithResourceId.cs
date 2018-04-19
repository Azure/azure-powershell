using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SignalR
{
    public interface IWithResourceId : IWithResourceGroupAndName
    {
        string ResourceId { get; }
    }

    public static class IWithResourceIdExtensions
    {
        public static void LoadFromResourceId(this IWithResourceId cmdlet)
        {
            var resourceId = new ResourceIdentifier(cmdlet.ResourceId);
            cmdlet.ResourceGroupName = resourceId.ResourceGroupName;
            cmdlet.Name = resourceId.ResourceName;
        }
    }
}
