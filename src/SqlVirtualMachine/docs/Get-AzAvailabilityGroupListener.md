---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/get-azavailabilitygrouplistener
schema: 2.0.0
---

# Get-AzAvailabilityGroupListener

## SYNOPSIS
Gets an availability group listener.

## SYNTAX

### List (Default)
```
Get-AzAvailabilityGroupListener -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAvailabilityGroupListener -Name <String> -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAvailabilityGroupListener -InputObject <ISqlVirtualMachineIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an availability group listener.

## EXAMPLES

### Example 1: Get all Availability Group Listeners of a SQL Virtual Machine Group
```powershell
Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01'
```

```output
Name            ResourceGroupName
----            -----------------
AgListener01    ResourceGroup01
AgListener02    ResourceGroup01
```



### Example 2: Get one Availability Group Listener of a SQL Virtual Machine Group
```powershell
Get-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'SqlVmGroup01' -Name 'AgListener01'
```

```output
Name            ResourceGroupName
----            -----------------
AgListener01    ResourceGroup01
```



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
The child resources to include in the response.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the availability group listener.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AvailabilityGroupListenerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -SqlVMGroupName
Name of the SQL virtual machine group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: GroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.IAvailabilityGroupListener

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISqlVirtualMachineIdentity>`: Identity Parameter
  - `[AvailabilityGroupListenerName <String>]`: Name of the availability group listener.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: Name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SqlVirtualMachineGroupName <String>]`: Name of the SQL virtual machine group.
  - `[SqlVirtualMachineName <String>]`: Name of the SQL virtual machine.
  - `[SubscriptionId <String>]`: Subscription ID that identifies an Azure subscription.

## RELATED LINKS

