---
external help file: Az.DependencyMap-help.xml
Module Name: Az.DependencyMap
online version: https://learn.microsoft.com/powershell/module/az.dependencymap/remove-azdependencymapdiscoverysource
schema: 2.0.0
---

# Remove-AzDependencyMapDiscoverySource

## SYNOPSIS
Delete a DiscoverySourceResource

## SYNTAX

### Delete (Default)
```
Remove-AzDependencyMapDiscoverySource -MapName <String> -ResourceGroupName <String> -SourceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityMap
```
Remove-AzDependencyMapDiscoverySource -SourceName <String> -MapInputObject <IDependencyMapIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDependencyMapDiscoverySource -InputObject <IDependencyMapIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a DiscoverySourceResource

## EXAMPLES

### Example 1: Remove a discovery source.
```powershell
Remove-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource
```

This command removes a discovery source from a resource group.

### Example 2: Remove a discovery source by object.
```powershell
Get-AzDependencyMapDiscoverySource -ResourceGroupName dmTestGroup -MapName testMap -SourceName dmSource | Remove-AzDependencyMapDiscoverySource
```

This command removes a discovery source from a resource group.

### Example 3: Remove a discovery source by parent object.
```powershell
Get-AzDependencyMap -ResourceGroupName dmTestGroup -Name testMap | Remove-AzDependencyMapDiscoverySource -SourceName dmSource
```

This command removes a discovery source from a resource group.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MapInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity
Parameter Sets: DeleteViaIdentityMap
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MapName
Maps resource name

```yaml
Type: System.String
Parameter Sets: Delete
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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceName
discovery source resource

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityMap
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
Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
