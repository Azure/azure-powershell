---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/powershell/module/az.logz/invoke-azlogzhostmonitor
schema: 2.0.0
---

# Invoke-AzLogzHostMonitor

## SYNOPSIS
Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM.

## SYNTAX

### Host (Default)
```
Invoke-AzLogzHostMonitor -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### HostViaIdentity
```
Invoke-AzLogzHostMonitor -InputObject <ILogzIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM.

## EXAMPLES

### Example 1: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM
```powershell
Invoke-AzLogzHostMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04
```

```output
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM.

### Example 2: Returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline
```powershell
Get-AzLogzMonitor -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 | Invoke-AzLogzHostMonitor
```

```output
ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

This command returns the payload that needs to be passed in the request body for installing Logz.io agent on a VM by pipeline.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity
Parameter Sets: HostViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Host
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
Parameter Sets: Host
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
Type: System.String
Parameter Sets: Host
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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IVMExtensionPayload

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ILogzIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: 
  - `[SubAccountName <String>]`: Sub Account resource name
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

