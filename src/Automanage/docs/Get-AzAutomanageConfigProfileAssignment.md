---
external help file:
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/get-azautomanageconfigprofileassignment
schema: 2.0.0
---

# Get-AzAutomanageConfigProfileAssignment

## SYNOPSIS
Get information about a configuration profile assignment

## SYNTAX

### List2 (Default)
```
Get-AzAutomanageConfigProfileAssignment [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAutomanageConfigProfileAssignment -ResourceGroupName <String> -VMName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutomanageConfigProfileAssignment -InputObject <IAutomanageIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzAutomanageConfigProfileAssignment -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List3
```
Get-AzAutomanageConfigProfileAssignment -MachineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List4
```
Get-AzAutomanageConfigProfileAssignment -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a configuration profile assignment

## EXAMPLES

### Example 1: List all configuration profile assignments under a subscription
```powershell
Get-AzAutomanageConfigProfileAssignment
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.Compute/virtualMachines/aglinuxvm
default lnxtest                     Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lnxtest/providers/Microsoft.Compute/virtualMachines/advisortest2
```

This command lists all configuration profile assignments under a subscription.

### Example 2: List all configuration profile assignments under a resource group
```powershell
Get-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.Compute/virtualMachines/aglinuxvm
```

This command lists all configuration profile assignments under a resource group.

### Example 3: Get information about a configuration profile assignment of the VM
```powershell
Get-AzAutomanageConfigProfileAssignment -ResourceGroupName automangerg -VMName aglinuxvm
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.Compute/virtualMachines/aglinuxvm
```

This command gets information about a configuration profile assignment of the VM.

## PARAMETERS

### -ClusterName
The name of the Arc machine.

```yaml
Type: System.String
Parameter Sets: List4
Aliases:

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineName
The name of the Arc machine.

```yaml
Type: System.String
Parameter Sets: List3
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
Parameter Sets: Get, List1, List3, List4
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
Parameter Sets: Get, List1, List2, List3, List4
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfileAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IAutomanageIdentity>`: Identity Parameter
  - `[BestPracticeName <String>]`: The Automanage best practice name.
  - `[ClusterName <String>]`: The name of the Arc machine.
  - `[ConfigurationProfileAssignmentName <String>]`: Name of the configuration profile assignment. Only default is supported.
  - `[ConfigurationProfileName <String>]`: Name of the configuration profile.
  - `[Id <String>]`: Resource identity path
  - `[MachineName <String>]`: The name of the Arc machine.
  - `[ReportName <String>]`: The report name.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VersionName <String>]`: The Automanage best practice version name.

## RELATED LINKS

