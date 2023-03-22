---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/get-azsqlvmgroup
schema: 2.0.0
---

# Get-AzSqlVMGroup

## SYNOPSIS
Gets a SQL virtual machine group.

## SYNTAX

### List1 (Default)
```
Get-AzSqlVMGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSqlVMGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSqlVMGroup -InputObject <ISqlVirtualMachineIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzSqlVMGroup -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a SQL virtual machine group.

## EXAMPLES

### Example 1: List all SQL Virtual Machine Groups
```powershell
Get-AzSqlVMGroup
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
eastus   sqlvmgroup02	ResourceGroup01
eastus   sqlvmgroup03	ResourceGroup02
```



### Example 2: List all SQL Virtual Machine Groups in a Resource Group
```powershell
Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
eastus   sqlvmgroup02	ResourceGroup01
```



### Example 3: Get a SQL Virtual Machine Group
```powershell
Get-AzSqlVMGroup -ResourceGroupName 'ResourceGroup01' -Name 'sqlvmgroup01'
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
eastus   sqlvmgroup01	ResourceGroup01
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
Name of the SQL virtual machine group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SqlVirtualMachineGroupName, SqlVMGroupName

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

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.ISqlVirtualMachineGroup

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

