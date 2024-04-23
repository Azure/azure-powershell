---
external help file: Az.Automanage-help.xml
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/get-azautomanageconfigprofilehcrpassignment
schema: 2.0.0
---

# Get-AzAutomanageConfigProfileHcrpAssignment

## SYNOPSIS
Get information about a configuration profile assignment

## SYNTAX

### Get (Default)
```
Get-AzAutomanageConfigProfileHcrpAssignment -MachineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutomanageConfigProfileHcrpAssignment -InputObject <IAutomanageIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a configuration profile assignment

## EXAMPLES

### Example 1: List all configuration profile assignments under a subscription
```powershell
Get-AzAutomanageConfigProfileHcrpAssignment
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
Get-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.Compute/virtualMachines/aglinuxvm
```

This command lists all configuration profile assignments under a resource group.

### Example 3: Get information about a configuration profile assignment
```powershell
Get-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg -MachineName aglinuxmachines
```

```output
Name    ResourceGroupName ManagedBy Status     TargetId
----    ----------------- --------- ------     --------
default automangerg                 Conformant /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.HybridCompute/machines/aglinuxmachines
```

This command gets information about a configuration profile assignment.

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
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.IAutomanageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfileAssignment

## NOTES

## RELATED LINKS
