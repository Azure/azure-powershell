---
external help file: Az.ResourceMover-help.xml
Module Name: Az.ResourceMover
online version: https://learn.microsoft.com/powershell/module/az.resourcemover/resolve-azresourcemovermovecollectiondependency
schema: 2.0.0
---

# Resolve-AzResourceMoverMoveCollectionDependency

## SYNOPSIS
Computes, resolves and validate the dependencies of the moveResources in the move collection.

**Please note that for 'RegionToRegion' type move collections the 'Resolve-AzResourceMoverMoveCollectionDependency' command just resolves the move collection, the user is required to identify the list of unresolved dependencies using 'Get-AzResourceMoverUnresolvedDependency' and then manually add them to the move collection using 'Add-AzResourceMoverMoveResource' command.**

**However, for moveType 'RegionToZone' this command finds the required dependencies and automatically adds them to the move collection in a single step.**

## SYNTAX

```
Resolve-AzResourceMoverMoveCollectionDependency -MoveCollectionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Computes, resolves and validate the dependencies of the moveResources in the move collection.

**Please note that for 'RegionToRegion' type move collections the 'Resolve-AzResourceMoverMoveCollectionDependency' command just resolves the move collection, the user is required to identify the list of unresolved dependencies using 'Get-AzResourceMoverUnresolvedDependency' and then manually add them to the move collection using 'Add-AzResourceMoverMoveResource' command.**

**However, for moveType 'RegionToZone' this command finds the required dependencies and automatically adds them to the move collection in a single step.**

## EXAMPLES

### Example 1: Compute, resolve and validate the dependencies of the Move Resources in the Move collection. (RegionToRegion)
```powershell
Resolve-AzResourceMoverMoveCollectionDependency -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"
```

```output
AdditionalInfo : 
Code           : MoveCollectionResolveDependenciesOperationFailed
Detail         : {}
EndTime        : 2/9/2021 2:05:04 AM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/operations/c2ad0066-6a69-45fe-aa70-193c240a9bc0
Message        : The resolve dependencies operation of one or more resources has failed. Check the move status of the resource for more details.
Possible Causes: The resolve dependencies operation of one ore more resources has failed.
Recommended Action: Retry the operation after resolving errors if any. If issue persists, contact support.
Name           : c2ad0066-6a69-45fe-aa70-193c240a9bc0
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/9/2021 2:05:00 AM
Status         : Succeeded
```

Compute, resolve and validate the dependencies of the Move Resources in 'RegionToRegion' type Move collection.

### Example 2: Compute, resolve and validate the dependencies of the Move Resources in the Move collection. (RegionToZone)
```powershell
Resolve-AzResourceMoverMoveCollectionDependency -MoveCollectionName "PS-demo-RegionToZone"  -ResourceGroupName "RG-MoveCollection-demoRMS"
```

```output
AdditionalInfo :
Code           :
Detail         :
EndTime        : 9/5/2023 11:45:11 AM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-demo-RegionToZone/operations/26077f45-dd8a-406d-bfc9-1b2d59d27e25
Message        :
Name           : 26077f45-dd8a-406d-bfc9-1b2d59d27e25
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 9/5/2023 11:45:10 AM
Status         : Succeeded
```

Compute, resolve and validate the dependencies of the Move Resources in 'RegionToZone' type Move collection.

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

### -MoveCollectionName
The Move Collection Name.

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
The Resource Group Name.

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

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20230801.IOperationStatus

## NOTES

## RELATED LINKS
