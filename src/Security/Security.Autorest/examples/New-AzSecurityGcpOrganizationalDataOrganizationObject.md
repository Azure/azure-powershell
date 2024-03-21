### Example 1: Create new GcpOrganizationalDataOrganization object
```powershell
New-AzSecurityGcpOrganizationalDataOrganizationObject -WorkloadIdentityProviderId "provider" -ServiceAccountEmailAddress "my@email.com" -ExcludedProjectNumber @(1,2)
```

```output
ExcludedProjectNumber      : {1, 2}
OrganizationMembershipType : Organization
OrganizationName           : 
ServiceAccountEmailAddress : my@email.com
WorkloadIdentityProviderId : provider
```




