### Example 1: List available GitHub owners for onboarding
```powershell
Get-AzSecurityConnectorGitHubOwnerAvailable -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01
```

```output
GitHubInternalId                : 45003365
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-gh-01/devops/default/gitHubOwners/dfdsdktests
Name                            : dfdsdktests
OnboardingState                 : Onboarded
OwnerUrl                        : https://github.com/dfdsdktests
ProvisioningState               : Pending
ProvisioningStatusMessage       : Beginning provisioning of GitHub connector.
ProvisioningStatusUpdateTimeUtc : 2/23/2024 8:46:22 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/gitHubOwners
```


