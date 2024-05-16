### Example 1: Get discovered AzureDevOps repository by organization, project and repo name
```powershell
Get-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests -ProjectName ContosoSDKDfd -RepoName TestApp0
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
                                    "inheritFromParentState": "Enabled"
                                  }
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests/projects/Co 
                                  ntosoSDKDfd/repos/TestApp0
Name                            : TestApp0
OnboardingState                 : Onboarded
ParentOrgName                   : dfdsdktests
ParentProjectName               : ContosoSDKDfd
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/23/2024 6:52:44 PM
RepoId                          : 35cd4811-63c7-4043-8587-f0a9cf37709e
RepoUrl                         : https://dev.azure.com/dfdsdktests/ContosoSDKDfd/_git/TestApp0
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects/repos
Visibility                      : 
```

### Example 2: List discovered AzureDevOps repositories
```powershell
Get-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests -ProjectName ContosoSDKDfd
```

```output
Name          ResourceGroupName
----          -----------------
ContosoSDKDfd dfdtest-sdk
TestApp0      dfdtest-sdk
TestApp2      dfdtest-sdk
```

