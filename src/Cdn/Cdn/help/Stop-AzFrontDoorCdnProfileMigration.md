---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/stop-azfrontdoorcdnprofilemigration
schema: 2.0.0
---

# Stop-AzFrontDoorCdnProfileMigration

## SYNOPSIS
Abort classic cdn migrate to AFDx.
Your new Front Door Profile will be deleted and your existing profile will remain active.
WAF policies will not be deleted.

## SYNTAX

```
Stop-AzFrontDoorCdnProfileMigration -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Abort classic cdn migrate to AFDx.
Your new Front Door Profile will be deleted and your existing profile will remain active.
WAF policies will not be deleted.

## EXAMPLES

### Example 1: Abort classic CDN migrate to AFDx
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName
```

Abort classic CDN migrate to AFDx.
This will delete all the AFD Standard or Premium configurations

### Example 2: Abort classic CDN migrate to AFDx, when the subscription of the classic CDN is different from the local subscrition
```powershell
Stop-AzFrontDoorCdnProfileMigration -ProfileName name-migrated -ResourceGroupName rgName -SubscriptionId testSubId01
```

Abort classic CDN migrate to AFDx.
When the subscription of the classic CDN is different from the local subscrition, You need to set the value of the subscription parameter.
This will delete all the AFD Standard or Premium configurations.

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
Name of the new AFD Standard/Premium profile that created in AFDx.

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

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

