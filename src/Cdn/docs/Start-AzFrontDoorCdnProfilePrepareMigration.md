---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/start-azfrontdoorcdnprofilepreparemigration
schema: 2.0.0
---

# Start-AzFrontDoorCdnProfilePrepareMigration

## SYNOPSIS
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

## SYNTAX

### MigrateExpanded (Default)
```
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName <String> -ClassicResourceReferenceId <String>
 -ProfileName <String> -SkuName <SkuName> [-SubscriptionId <String>]
 [-MigrationWebApplicationFirewallMapping <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Migrate
```
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName <String>
 -MigrationParameter <IMigrationParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassicResourceReferenceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -MigrationParameter
Request body for Migrate operation.
To construct, see NOTES section for MIGRATIONPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IMigrationParameters
Parameter Sets: Migrate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationWebApplicationFirewallMapping
Waf mapping for the migrated profile

```yaml
Type: System.String
Parameter Sets: MigrateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the new profile that need to be created.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName
Parameter Sets: MigrateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IMigrateResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`MIGRATIONPARAMETER <IMigrationParameters>`: Request body for Migrate operation.
  - `ProfileName <String>`: Name of the new profile that need to be created.
  - `[ClassicResourceReferenceId <String>]`: Resource ID.
  - `[MigrationWebApplicationFirewallMapping <IMigrationWebApplicationFirewallMapping[]>]`: Waf mapping for the migrated profile
    - `[MigratedFromId <String>]`: Resource ID.
    - `[MigratedToId <String>]`: Resource ID.
  - `[SkuName <SkuName?>]`: Name of the pricing tier.

## RELATED LINKS

