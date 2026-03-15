### Example 1: Update confluent environment
```powershell
Set-AzConfluentEnvironment `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Id "env-exampleenv001" `
    -Kind "Environment" `
    -StreamGovernanceConfigPackage "ESSENTIALS"
```

```output
Id                            : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001
Kind                          : Environment
MetadataCreatedTimestamp      :
MetadataDeletedTimestamp      :
MetadataResourceName          :
MetadataSelf                  :
MetadataUpdatedTimestamp      :
Name                          : env-exampleenv001
ResourceGroupName             : sharedrp-confluent
StreamGovernanceConfigPackage : ESSENTIALS
SystemDataCreatedAt           : 3/7/2026 3:28:11 PM
SystemDataCreatedBy           : user4@example.com
SystemDataCreatedByType       : User
SystemDataLastModifiedAt      : 3/7/2026 3:28:11 PM
SystemDataLastModifiedBy      : user4@example.com
SystemDataLastModifiedByType  : User
Type                          : microsoft.confluent/organizations/environments
```

This command updated confluent environment