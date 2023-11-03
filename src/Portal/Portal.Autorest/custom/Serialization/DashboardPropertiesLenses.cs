using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    public partial class DashboardPropertiesLenses
    {
        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject json)
        {
            // Perform serialization using the appropriate item instantiator
            Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.JsonSerializable.FromJson(
                json, 
                ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardLens>)this).AdditionalProperties, 
                (js) => Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardLens.FromJson(js), 
                null);
        }
    }
}
