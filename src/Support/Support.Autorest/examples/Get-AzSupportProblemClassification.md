### Example 1: List Azure Support Problem Classifications
```powershell
Get-AzSupportProblemClassification -ServiceName "6f16735c-b0ae-b275-ad3a-03479cfa1396"
```

```output
DisplayName                                                                                     Name                                 SecondaryConsentEnabled
-----------                                                                                     ----                                 -----------------------
Compute-VM (cores-vCPUs) subscription limit increases                                           4d78b174-3203-a3ac-9e08-41fb35de6354
Windows Update, Guest Patching and OS Upgrades / Issue with Azure Automatic VM guest patching   e565bd13-86f0-ecb3-d2b7-0a7501ae8839
Windows Update, Guest Patching and OS Upgrades / Issue with Azure Update Management patching    8d686480-ef41-5005-358e-12b9be9608fe
```

Lists all the problem classifications (categories) available for a specific Azure service. Always use the service and problem classifications obtained programmatically. This practice ensures that you always have the most recent set of service and problem classification Ids.

### Example 2: Get Azure Support Problem Classification
```powershell
Get-AzSupportProblemClassification -ServiceName "6f16735c-b0ae-b275-ad3a-03479cfa1396" -Name "e565bd13-86f0-ecb3-d2b7-0a7501ae8839"
```

```output
DisplayName             : Windows Update, Guest Patching and OS Upgrades / Issue with Azure Automatic VM guest patching
Id                      : /providers/Microsoft.Support/services/6f16735c-b0ae-b275-ad3a-03479cfa1396/problemClassifications/e565bd13-86f0-ecb3-d2b7-0a7501ae8839
Name                    : e565bd13-86f0-ecb3-d2b7-0a7501ae8839
ResourceGroupName       :
SecondaryConsentEnabled :
Type                    : Microsoft.Support/problemClassifications
```

Get problem classification details for a specific Azure service.

