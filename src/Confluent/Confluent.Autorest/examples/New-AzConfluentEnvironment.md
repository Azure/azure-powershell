### Example 1: Create confluent environment
```powershell
New-AzConfluentEnvironment `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Id "env-xxxxx" `
    -Kind "Environment" `
    -StreamGovernanceConfigPackage "ESSENTIALS"
```

```output
Id                            : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-xxxxx
Kind                          : Environment
MetadataCreatedTimestamp      :
MetadataDeletedTimestamp      :
MetadataResourceName          :
MetadataSelf                  :
MetadataUpdatedTimestamp      :
Name                          : env-xxxxx
ResourceGroupName             : sharedrp-confluent
StreamGovernanceConfigPackage : ESSENTIALS
SystemDataCreatedAt           : 3/7/2026 2:11:30 PM
SystemDataCreatedBy           : user4@example.com
SystemDataCreatedByType       : User
SystemDataLastModifiedAt      : 3/7/2026 2:11:30 PM
SystemDataLastModifiedBy      : user4@example.com
SystemDataLastModifiedByType  : User
Type                          : microsoft.confluent/organizations/environments
```

This command create confluent environment

### Example 2: Create confluent environment with JSON string
```powershell
New-AzConfluentEnvironment `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Id "env-zzzzz" `
    -JsonString '{
        "properties": {
            "streamGovernanceConfig": {
                "package": "ESSENTIALS"
            }
        }
    }'
```

```output
Id                            : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-zzzzz
Kind                          :
MetadataCreatedTimestamp      :
MetadataDeletedTimestamp      :
MetadataResourceName          :
MetadataSelf                  :
MetadataUpdatedTimestamp      :
Name                          : env-zzzzz
ResourceGroupName             : sharedrp-confluent
StreamGovernanceConfigPackage : ESSENTIALS
SystemDataCreatedAt           : 3/7/2026 2:12:38 PM
SystemDataCreatedBy           : user4@example.com
SystemDataCreatedByType       : User
SystemDataLastModifiedAt      : 3/7/2026 2:12:38 PM
SystemDataLastModifiedBy      : user4@example.com
SystemDataLastModifiedByType  : User
Type                          : microsoft.confluent/organizations/environments
```

This command create confluent environment