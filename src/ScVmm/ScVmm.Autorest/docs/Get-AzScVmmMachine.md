---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmmachine
schema: 2.0.0
---

# Get-AzScVmmMachine

## SYNOPSIS
Retrieves information about the model view or the instance view of a hybrid machine.

## SYNTAX

### List1 (Default)
```
Get-AzScVmmMachine [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmMachine -InputObject <IScVmmIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzScVmmMachine -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about the model view or the instance view of a hybrid machine.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -Expand
The expand expression to apply on the operation.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the hybrid machine.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MachineName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IMachine

## NOTES

## RELATED LINKS

