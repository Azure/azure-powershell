---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/powershell/module/az.logz/get-azlogzsubaccountvmhost
schema: 2.0.0
---

# Get-AzLogzSubAccountVMHost

## SYNOPSIS
List the compute resources currently being monitored by the Logz sub account resource.

## SYNTAX

```
Get-AzLogzSubAccountVMHost -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List the compute resources currently being monitored by the Logz sub account resource.

## EXAMPLES

### Example 1: List the compute resources currently being monitored by the logz sub account resource
```powershell
Get-AzLogzSubAccountVMHost -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01
```

```output
AgentVersion Id
------------ --
1.0          /SUBSCRIPTIONS/CE37D538-DFA3-49C3-B3CD-149B4B7DB48A/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1
```

This command lists the compute resources currently being monitored by the logz sub account resource.

## PARAMETERS

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

### -MonitorName
Monitor resource name

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

### -Name
Sub Account resource name

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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IVMResources

## NOTES

ALIASES

## RELATED LINKS

