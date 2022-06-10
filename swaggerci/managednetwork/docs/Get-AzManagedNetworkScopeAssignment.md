---
external help file:
Module Name: Az.ManagedNetwork
online version: https://docs.microsoft.com/en-us/powershell/module/az.managednetwork/get-azmanagednetworkscopeassignment
schema: 2.0.0
---

# Get-AzManagedNetworkScopeAssignment

## SYNOPSIS
Get the specified scope assignment.

## SYNTAX

### List (Default)
```
Get-AzManagedNetworkScopeAssignment -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzManagedNetworkScopeAssignment -Name <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzManagedNetworkScopeAssignment -InputObject <IManagedNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specified scope assignment.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.IManagedNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the scope assignment to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ScopeAssignmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The base resource of the scope assignment.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.IManagedNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IScopeAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IManagedNetworkIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ManagedNetworkGroupName <String>]`: The name of the Managed Network Group.
  - `[ManagedNetworkName <String>]`: The name of the Managed Network.
  - `[ManagedNetworkPeeringPolicyName <String>]`: The name of the Managed Network Peering Policy.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[Scope <String>]`: The base resource of the scope assignment.
  - `[ScopeAssignmentName <String>]`: The name of the scope assignment to get.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

