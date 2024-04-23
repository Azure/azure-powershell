---
external help file: Az.Automanage-help.xml
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/get-azautomanagereport
schema: 2.0.0
---

# Get-AzAutomanageReport

## SYNOPSIS
Get information about a report associated with a configuration profile assignment run

## SYNTAX

### List (Default)
```
Get-AzAutomanageReport -ResourceGroupName <String> [-SubscriptionId <String[]>] -VMName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzAutomanageReport -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] -VMName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAutomanageReport -InputObject <IAutomanageIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a report associated with a configuration profile assignment run

## EXAMPLES

### Example 1: List all information about a report associated with a configuration profile assignment run
```powershell
Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm
```

```output
Name                                         ResourceGroupName
----                                         -----------------
default/a261e96e-90bd-4feb-bed6-c9e1fb436d51 automangerg
default/787969f2-d8b2-4f33-afb3-f3636880884e automangerg
default/638cc61a-70d9-4a88-9ffc-f5a49e981dd7 automangerg
default/8cbcf4be-6f16-480b-85ac-4c0392ff0476 automangerg
default/20640074-b8fd-4e27-abc3-7c9440ea40db automangerg
default/0a9e1d06-6903-4580-8876-84ab7be07239 automangerg
default/6ae85795-33c1-45e9-8823-3124e53378ab automangerg
default/ec6183de-759e-4db2-ae94-142d0d65c33a automangerg
```

This command lists all information about a report associated with a configuration profile assignment run.

### Example 2: Get information about a report associated with a configuration profile assignment run
```powershell
Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm -Name cb998749-f7da-4899-8273-d0fde617f49e
```

```output
Name                                         ResourceGroupName
----                                         -----------------
default/cb998749-f7da-4899-8273-d0fde617f49e automangerg
```

This command gets information about a report associated with a configuration profile assignment run.

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

### -Name
The report name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ReportName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IReport

## NOTES

## RELATED LINKS
