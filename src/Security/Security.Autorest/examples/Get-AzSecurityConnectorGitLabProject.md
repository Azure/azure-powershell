### Example 1: Get discovered GitLab project by name
```powershell
Get-AzSecurityConnectorGitLabProject -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gl-01 -GroupFqName dfdsdktests -ProjectName testapp0
```

```output
FullyQualifiedFriendlyName      : Defender for DevOps SDK Tests / TestApp0
FullyQualifiedName              : dfdsdktests$testapp0
FullyQualifiedParentGroupName   : dfdsdktests
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-gl-01/devops/default/gitLabGroups/dfdsdktests/projects/testapp0
Name                            : testapp0
OnboardingState                 : Onboarded
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource modification successful.
ProvisioningStatusUpdateTimeUtc : 1/1/1970 12:00:00 AM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/gitLabGroups/projects
Url                             : https://gitlab.com/dfdsdktests/testapp0
```

### Example 2: List discovered GitLab projects
```powershell
Get-AzSecurityConnectorGitLabProject -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gl-01 -GroupFqName dfdsdktests
```

```output
Name      ResourceGroupName
----      -----------------
testapp10 dfdtest-sdk
testapp11 dfdtest-sdk
testapp0  dfdtest-sdk
```


