---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/new-azconfluentenvironment
schema: 2.0.0
---

# New-AzConfluentEnvironment

## SYNOPSIS
Create confluent environment

## SYNTAX

### CreateExpanded (Default)
```
New-AzConfluentEnvironment -Id <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Kind <String>] [-MetadataCreatedTimestamp <String>]
 [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>] [-MetadataSelf <String>]
 [-MetadataUpdatedTimestamp <String>] [-StreamGovernanceConfigPackage <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConfluentEnvironment -Id <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConfluentEnvironment -Id <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityOrganizationExpanded
```
New-AzConfluentEnvironment -Id <String> -OrganizationInputObject <IConfluentIdentity> [-Kind <String>]
 [-MetadataCreatedTimestamp <String>] [-MetadataDeletedTimestamp <String>] [-MetadataResourceName <String>]
 [-MetadataSelf <String>] [-MetadataUpdatedTimestamp <String>] [-StreamGovernanceConfigPackage <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create confluent environment

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Confluent environment id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EnvironmentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Type of environment

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataCreatedTimestamp
Created Date Time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataDeletedTimestamp
Deleted Date time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataResourceName
Resource name of the record

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataSelf
Self lookup url

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataUpdatedTimestamp
Updated Date time

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: CreateViaIdentityOrganizationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamGovernanceConfigPackage
Stream governance configuration

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IScEnvironmentRecord

## NOTES

## RELATED LINKS
