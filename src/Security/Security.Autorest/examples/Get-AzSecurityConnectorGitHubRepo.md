### Example 1: Get discovered GitHub repository by name
```powershell
Get-AzSecurityConnectorGitHubRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01 -OwnerName dfdsdktests -RepoName TestApp0
```

```output
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-gh-01/devops/default/gitHubOwners/dfdsdktests/repos/TestApp0
Name                            : TestApp0
OnboardingState                 : Onboarded
ParentOwnerName                 : dfdsdktests
ProvisioningState               : 
ProvisioningStatusMessage       : 
ProvisioningStatusUpdateTimeUtc : 2/23/2024 8:46:23 PM
RepoFullName                    : 
RepoId                          : 728418798
RepoName                        : TestApp0
RepoUrl                         : https://github.com/dfdsdktests/TestApp0
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/gitHubOwners/repos
```


### Example 2: List discovered GitHub repositories
```powershell
Get-AzSecurityConnectorGitHubRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01 -OwnerName dfdsdktests
```

```output

Name      ResourceGroupName
----      -----------------
TestApp0  dfdtest-sdk
TestApp1  dfdtest-sdk
```



