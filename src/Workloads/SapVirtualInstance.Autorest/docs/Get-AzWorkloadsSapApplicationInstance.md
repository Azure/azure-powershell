---
external help file:
Module Name: Az.SapVirtualInstance
online version: https://learn.microsoft.com/powershell/module/az.sapvirtualinstance/get-azworkloadssapapplicationinstance
schema: 2.0.0
---

# Get-AzWorkloadsSapApplicationInstance

## SYNOPSIS
Gets the SAP Application Server Instance corresponding to the Virtual Instance for SAP solutions resource.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName <String> -SapVirtualInstanceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsSapApplicationInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsSapApplicationInstance -InputObject <ISapVirtualInstanceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the SAP Application Server Instance corresponding to the Virtual Instance for SAP solutions resource.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of SAP Application Server instance resource.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapVirtualInstanceName
The name of the Virtual Instances for SAP solutions resource

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

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.ISapApplicationServerInstance

## NOTES

## RELATED LINKS


