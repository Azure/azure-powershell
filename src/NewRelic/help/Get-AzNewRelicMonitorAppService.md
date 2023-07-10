---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicmonitorappservice
schema: 2.0.0
---

# Get-AzNewRelicMonitorAppService

## SYNOPSIS
List the app service resources currently being monitored by the NewRelic resource.

## SYNTAX

```
Get-AzNewRelicMonitorAppService -MonitorName <String> -ResourceGroupName <String> -UserEmail <String>
 [-SubscriptionId <String[]>] [-AzureResourceId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
List the app service resources currently being monitored by the NewRelic resource.

## EXAMPLES

### Example 1: Get specific App Service
```powershell
Get-AzNewRelicMonitorAppService -MonitorName test-02 -ResourceGroupName ps-test -UserEmail v-jiaji@outlook.com -AzureResourceId /SUBSCRIPTIONS/272C26CB-7026-4B37-B190-7CB7B2ABECB0/RESOURCEGROUPS/PS-TEST/PROVIDERS/MICROSOFT.WEB/SITES/JOYERTEST
```

Get specified app service information currently being monitored by specified NewRelic resource.

## PARAMETERS

### -AzureResourceId
Azure resource IDs

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -MonitorName
Name of the Monitors resource

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
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEmail
User Email

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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IAppServiceInfo

## NOTES

ALIASES

## RELATED LINKS

