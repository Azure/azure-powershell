using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SignalR
{
    public interface IWithInputObject : IWithResourceGroupAndName
    {
        PSSignalRResource InputObject { get; }
    }

    public static class IWithInputObjectExtensions
    {
        public static void LoadFromInputObject(this IWithInputObject cmdlet)
        {
            var resourceId = new ResourceIdentifier(cmdlet.InputObject.Id);
            cmdlet.ResourceGroupName = resourceId.ResourceGroupName;
            cmdlet.Name = resourceId.ResourceName;
        }
    }
}
