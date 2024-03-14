### Example 1: Update discovered AzureDevOps repository configuration
```powershell
$config = New-AzSecurityConnectorActionableRemediationObject -State Enabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="Low"} )
Update-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName "securityConnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -OrgName "org1" -ProjectName "Build" -RepoName "Build" -ActionableRemediation $config
```

```output
ActionableRemediation           : {
                                    "state": "Enabled",
                                    "categoryConfigurations": [
                                      {
                                        "minimumSeverityLevel": "Low",
                                        "category": "IaC"
                                      }
                                    ],
                                    "branchConfiguration": {
                                      "branchNames": [ ],
                                      "annotateDefaultBranch": "Enabled"
                                    },
                                    "inheritFromParentState": "Disabled"
                                  }
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/securityConnectors-pwsh-tmp/providers/Microsoft.Security/securityConnectors/ado-sdk-pwsh-test03/devops/default/azureDevOpsOrgs/org1/p 
                                  rojects/Build/repos/Build
Name                            : Build
OnboardingState                 : Onboarded
ParentOrgName                   : org1
ParentProjectName               : Build
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/24/2024 12:31:19 AM
RepoId                          : 64d6ea8c-6030-44db-86a4-044f13a7f43e
RepoUrl                         : https://dev.azure.com/org1/Build/_git/Build
ResourceGroupName               : securityConnectors-pwsh-tmp
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects/repos
Visibility                      : 
```


