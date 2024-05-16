### Example 1: Get Security Connector resource by name
```powershell
Get-AzSecurityConnector -ResourceGroupName "dfdtest-sdk" -Name "dfdsdktests-azdo-01"
```

```output
EnvironmentData                 : {
                                    "environmentType": "AzureDevOpsScope"
                                  }
EnvironmentName                 : AzureDevOps
Etag                            : 
HierarchyIdentifier             : 4a8eb7f1-f533-48c5-b102-9b09e90906b7
HierarchyIdentifierTrialEndDate : 
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01
Kind                            : 
Location                        : centralus
Name                            : dfdsdktests-azdo-01
Offering                        : {{
                                    "offeringType": "CspmMonitorAzureDevOps"
                                  }}
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 12/7/2023 6:38:36 AM
SystemDataCreatedBy             : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataCreatedByType         : Application
SystemDataLastModifiedAt        : 2/14/2024 2:11:46 AM
SystemDataLastModifiedBy        : c3d82ccb-fee1-430c-949e-6c0a217c00a8
SystemDataLastModifiedByType    : Application
Tag                             : {}
Type                            : Microsoft.Security/securityconnectors
```


### Example 2: List Security Connectors by subscription
```powershell
Get-AzSecurityConnector
```

```output
Name                ResourceGroupName        EnvironmentName Location  HierarchyIdentifier
----                -----------------        --------------- --------  -------------------
dfdsdktests-azdo-01 dfdtest-sdk              AzureDevOps     centralus 4a8eb7f1-f533-48c5-b102-9b09e90906b7
dfdsdktests-gl-01   dfdtest-sdk              GitLab          centralus 7a1f4efe-f8c6-48e7-b7ef-1b45994ed602
dfdsdktests-gh-01   dfdtest-sdk              Github          centralus bc12ba4d-b89c-486e-85e1-d803e7d80525
aws-sdktest01       securityconnectors-tests AWS             CentralUS 891376984375
gcp-sdktest01       securityconnectors-tests GCP             CentralUS 843025268399
```

