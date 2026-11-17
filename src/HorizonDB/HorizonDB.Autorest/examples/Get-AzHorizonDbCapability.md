### Example 1: Get the capability catalog for a region
```powershell
Get-AzHorizonDbCapability -Location 'eastus2' | Format-List -Property Name, ClusterCapabilityRecommendedPostgreSqlVersion, ClusterCapabilitySupportedPostgreSqlVersion, ProvisioningState
```

```output
Name                                          : default
ClusterCapabilityRecommendedPostgreSqlVersion : 17
ClusterCapabilitySupportedPostgreSqlVersion   : {{
                                                  "name": "17",
                                                  "supportedVersionsToUpgrade": [ ]
                                                }, {
                                                  "name": "18",
                                                  "supportedVersionsToUpgrade": [ ]
                                                }}
ProvisioningState                             : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
