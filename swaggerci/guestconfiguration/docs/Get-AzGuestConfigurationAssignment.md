---
external help file:
Module Name: Az.GuestConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.guestconfiguration/get-azguestconfigurationassignment
schema: 2.0.0
---

# Get-AzGuestConfigurationAssignment

## SYNOPSIS
Get information about a guest configuration assignment

## SYNTAX

### List (Default)
```
Get-AzGuestConfigurationAssignment -ResourceGroupName <String> -VMName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGuestConfigurationAssignment -Name <String> -ResourceGroupName <String> -VMName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGuestConfigurationAssignment -InputObject <IGuestConfigurationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get information about a guest configuration assignment

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
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.IGuestConfigurationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The guest configuration assignment name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: GuestConfigurationAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -VMName
The name of the virtual machine.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.IGuestConfigurationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IGuestConfigurationAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IGuestConfigurationIdentity>: Identity Parameter
  - `[GuestConfigurationAssignmentName <String>]`: Name of the guest configuration assignment.
  - `[Id <String>]`: The GUID for the guest configuration assignment report.
  - `[Id1 <String>]`: Resource identity path
  - `[MachineName <String>]`: The name of the ARC machine.
  - `[Name <String>]`: The guest configuration assignment name.
  - `[ReportId <String>]`: The GUID for the guest configuration assignment report.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[SubscriptionId <String>]`: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VmssName <String>]`: The name of the virtual machine scale set.

## RELATED LINKS

