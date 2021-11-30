### Example 1: Gets available product families on procured subscription
```powershell
PS C:\> $productFamilyMeta = Get-AzEdgeOrderProductFamilyMetadata -SubscriptionId SubscriptionId
PS C:\> $productFamilyMeta.HierarchyInformation

ConfigurationName ProductFamilyName ProductLineName ProductName
----------------- ----------------- --------------- -----------
                  azurestackedge
                  azurestackhub
```
This command gets product families available on procured subscription. 
Make sure registerProvider on Microsoft.EdgeOrder is done before running this command.

To get details of any family use Get-AzEdgeOrderProductFamily command