### Example 1: Get discovered AzureDevOps project by organization and project name
```powershell
Get-AzSecurityConnectorAzureDevOpsProject -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests -ProjectName ContosoSDKDfd
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
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests/projects/Co 
                                  ntosoSDKDfd
Name                            : ContosoSDKDfd
OnboardingState                 : Onboarded
ParentOrgName                   : dfdsdktests
ProjectId                       : 161fb6f6-f2fe-4616-a627-293b788ff583
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/23/2024 6:52:43 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects
```

### Example 2: List discovered AzureDevOps projects
```powershell
Get-AzSecurityConnectorAzureDevOpsProject -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests
```

```output
Name              ResourceGroupName
----              -----------------
ContosoSDKDfd     dfdtest-sdk
ContosoEnterprise dfdtest-sdk
```


