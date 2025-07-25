### Example 1: Get discovered AzureDevOps organization by name
```powershell
Get-AzSecurityConnectorAzureDevOpsOrg -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests
```

```output
ActionableRemediation           : {
                                    "state": "Enabled",
                                    "categoryConfigurations": [
                                      {
                                        "minimumSeverityLevel": "High",
                                        "category": "IaC"
                                      }
                                    ],
                                    "branchConfiguration": {
                                      "branchNames": [ ],
                                      "annotateDefaultBranch": "Enabled"
                                    },
                                    "inheritFromParentState": "Disabled"
                                  }
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests
Name                            : dfdsdktests
OnboardingState                 : Onboarded
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/23/2024 6:49:40 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs
```

### Example 2: List discovered AzureDevOps organizations
```powershell
Get-AzSecurityConnectorAzureDevOpsOrg -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01
```

```output
Name              ResourceGroupName
----              -----------------
dfdsdktests       dfdtest-sdk
dfdsdktests2      dfdtest-sdk
```

