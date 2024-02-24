### Example 1: Create new GcpOrganizationalDataOrganization object
```powershell
$orgData = New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
New-AzSecurityGcpProjectEnvironmentObject -ProjectDetailProjectId "asc-sdk-samples" -ScanInterval 24 -OrganizationalData $orgData -ProjectDetailProjectNumber "1234"
```

```output
EnvironmentType                     : GcpProject
OrganizationalData                  : {
                                        "organizationMembershipType": "Organization",
                                        "excludedProjectNumbers": [ "1", "2" ],
                                        "serviceAccountEmailAddress": "my@email.com",
                                        "workloadIdentityProviderId": "provider"
                                      }
ProjectDetailProjectId              : asc-sdk-samples
ProjectDetailProjectName            : 
ProjectDetailProjectNumber          : 1234
ProjectDetailWorkloadIdentityPoolId : 
ScanInterval                        : 24
```


