### Example 1: List Azure Support Services
```powershell
Get-AzSupportService
```

```output
DisplayName                                                  Name                                 ResourceType
-----------                                                  ----                                 ------------
Activity Logs                                                484e2236-bc6d-b1bb-76d2-7d09278cf9ea {}
Advisor                                                      26d8424b-0a41-4443-cbc6-0309ea8708d0 {}
AKS Edge Essentials                                          1232100c-42c0-f626-2b4f-8c8a4877acad {Microsoft.Kubernetes/connectedClusters}
```

Lists all the Azure services available for support ticket creation. For **Technical** issues, select the Service Id that maps to the Azure service/product as displayed in the **Services** drop-down list on the Azure portal's [New support request](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/overview) page. Always use the service and its corresponding problem classification(s) obtained programmatically for support ticket creation. This practice ensures that you always have the most recent set of service and problem classification Ids.

### Example 2: Get Azure Support Service
```powershell
Get-AzSupportService -Name "484e2236-bc6d-b1bb-76d2-7d09278cf9ea"
```

```output
DisplayName       : Activity Logs
Id                : /providers/Microsoft.Support/services/484e2236-bc6d-b1bb-76d2-7d09278cf9ea
Name              : 484e2236-bc6d-b1bb-76d2-7d09278cf9ea
ResourceGroupName :
ResourceType      : {}
Type              : Microsoft.Support/services
```

Gets a specific Azure service for support ticket creation.

