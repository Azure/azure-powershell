### Example 1: Returns all cluster pool versions in a region.
```powershell
$location = "west us 2"
Get-AzHdInsightOnAksAvailableClusterPoolVersion -Location $location
```

```output
AksVersion                   : 1.26
ClusterPoolVersionValue      : 1.0
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.HDInsight/locations/west us 2/
                               availableclusterpoolversions/1.0
IsPreview                    : False
Name                         : 1.0
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

Get all available cluster pool versions in West US 2
