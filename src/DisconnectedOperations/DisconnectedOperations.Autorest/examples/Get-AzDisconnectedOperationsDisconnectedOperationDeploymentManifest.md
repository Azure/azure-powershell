### Example 1: Get deployment manifest for a DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
BillingModel     : Capacity
Cloud            : AzureCloud
ConnectionIntent : Disconnected
Location         : EastUS2EUAP
ResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedoperations/Resource-1
ResourceName     : Resource-1
StampId          : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
```

This command gets the deployment manifest for the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1`.