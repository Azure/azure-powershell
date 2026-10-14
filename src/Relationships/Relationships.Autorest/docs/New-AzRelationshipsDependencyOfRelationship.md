---
external help file:
Module Name: Az.Relationships
online version: https://learn.microsoft.com/powershell/module/az.relationships/new-azrelationshipsdependencyofrelationship
schema: 2.0.0
---

# New-AzRelationshipsDependencyOfRelationship

## SYNOPSIS
Create a DependencyOfRelationship

## SYNTAX

### CreateExpanded (Default)
```
New-AzRelationshipsDependencyOfRelationship -Name <String> -ResourceUri <String> [-TargetId <String>]
 [-TargetTenant <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzRelationshipsDependencyOfRelationship -Name <String> -ResourceUri <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzRelationshipsDependencyOfRelationship -Name <String> -ResourceUri <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a DependencyOfRelationship

## EXAMPLES

### Example 1: Create a DependencyOf relationship from a resource group to a Service Group
```powershell
New-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myDependency" -TargetId "/providers/Microsoft.Management/serviceGroups/myServiceGroup"
```

Creates a DependencyOf relationship declaring that the resource group 'myRG' depends on the Service Group 'myServiceGroup'.

### Example 2: Create a DependencyOf relationship from a subscription to a resource group
```powershell
New-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001" -Name "subDep" -TargetId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/targetRG"
```

Creates a DependencyOf relationship where the subscription depends on the resource group 'targetRG'.
Source and target must be different resources.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of dependencyOf relationship.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetId
The relationship target resource id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTenant
The relationship target tenant id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationship

## NOTES

## RELATED LINKS

