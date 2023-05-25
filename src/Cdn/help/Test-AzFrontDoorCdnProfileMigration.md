---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/test-azfrontdoorcdnprofilemigration
schema: 2.0.0
---

# Test-AzFrontDoorCdnProfileMigration

## SYNOPSIS
Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.

## SYNTAX

```
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName <String> -ClassicResourceReferenceId <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.

## EXAMPLES

### Example 1: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.

### Example 2: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition.
```powershell
Test-AzFrontDoorCdnProfileMigration -ResourceGroupName testrg -ClassicResourceReferenceId /subscriptions/testSubId01/resourcegroups/testrg/providers/Microsoft.Network/Frontdoors/frontdoorName -SubscriptionId testSubId01 
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile, when the subscription of the CDN profile is different from the local subscrition.

You need to set the value of the subscription parameter.

## PARAMETERS

### -ClassicResourceReferenceId
Resource ID of the classic front door instance.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.ICanMigrateResult

## NOTES

ALIASES

## RELATED LINKS

