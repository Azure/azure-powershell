### Example 1: Update discovered AzureDevOps project configuration
```powershell
$config = New-AzSecurityConnectorActionableRemediationObject -State Disabled -InheritFromParentState Disabled -CategoryConfiguration @( @{category="IaC"; minimumSeverityLevel="Low"})
Update-AzSecurityConnectorAzureDevOpsProject -ResourceGroupName "securityConnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -OrgName "org1" -ProjectName "Build" -ActionableRemediation $config
```

```output
ActionableRemediation           : {
                                    "state": "Disabled",
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
                                  rojects/Build
Name                            : Build
OnboardingState                 : Onboarded
ParentOrgName                   : org1
ProjectId                       : 68b6a6ae-a3e4-41fa-b16e-bc4bbacd139a
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/24/2024 12:31:18 AM
ResourceGroupName               : securityConnectors-pwsh-tmp
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects
```



