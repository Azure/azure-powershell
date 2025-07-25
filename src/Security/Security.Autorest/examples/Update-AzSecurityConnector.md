### Example 1: Update security connector
```powershell
Update-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "ado-sdk-pwsh-test03" -Tag @{myTag="v1"}
```

```output
EnvironmentData                 : {
                                    "environmentType": "AzureDevOpsScope"
                                  }
EnvironmentName                 : AzureDevOps
Etag                            : 
HierarchyIdentifier             : 9dd01e19-8aaf-43a2-8dd4-1c5992f4df35
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/securityconnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03
Kind                            : 
Location                        : CentralUS
Name                            : ado-sdk-pwsh-test03
Offering                        : {{
                                    "offeringType": "CspmMonitorAzureDevOps"
                                  }}
ResourceGroupName               : securityconnectors-pwsh-tmp
SystemDataCreatedAt             : 2/24/2024 12:13:11 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/24/2024 12:24:02 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {
                                    "myTag": "v1"
                                  }
Type                            : Microsoft.Security/securityconnectors
```

