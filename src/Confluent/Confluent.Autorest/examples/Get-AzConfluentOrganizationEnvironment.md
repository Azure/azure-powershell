### Example 1: List all environments in the organization
```powershell
Get-AzConfluentOrganizationEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
 Get-AzConfluentOrganizationEnvironment -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent

Name                  SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind        ResourceGroupName
----                  ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ----        -----------------
default                                                                                                                                                              Environment sharedrp-confluent
test-env-0                                                                                                                                                         Environment sharedrp-confluent
test-env-1                                                                                                                                                         Environment sharedrp-confluent
test-env-2                                                                                                                                                         Environment sharedrp-confluent
test-env-3                                                                                                                                                         Environment sharedrp-confluent
shekarTest                                                                                                                                                           Environment sharedrp-confluent
test-env-4                                                                                                                                                Environment sharedrp-confluent
praveen-test-env                                                                                                                                                     Environment sharedrp-confluent
env1136                                                                                                                                                              Environment sharedrp-confluent
testEnv1                                                                                                                                                             Environment sharedrp-confluent
```

This commands list all environments in an organization

### Example 2: Get Environment details by environment ID
```powershell
 Get-AzConfluentOrganizationEnvironment -EnvironmentId 'shekarTest' -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Id                            : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/shekarTes
                                t
Kind                          : Environment
MetadataCreatedTimestamp      : 12/19/2025 09:33:39 +00:00
MetadataDeletedTimestamp      :
MetadataResourceName          : crn://example.confluent.io/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv001
MetadataSelf                  : https://api.example.confluent.io/org/v2/environments/env-exampleenv001
MetadataUpdatedTimestamp      : 12/19/2025 09:33:39 +00:00
Name                          : shekarTest
ResourceGroupName             : sharedrp-confluent
StreamGovernanceConfigPackage : ESSENTIALS
SystemDataCreatedAt           :
SystemDataCreatedBy           :
SystemDataCreatedByType       :
SystemDataLastModifiedAt      :
SystemDataLastModifiedBy      :
SystemDataLastModifiedByType  :
Type                          : microsoft.confluent/organizations/environments
```

This commands fetches environment details of an environment by environment ID