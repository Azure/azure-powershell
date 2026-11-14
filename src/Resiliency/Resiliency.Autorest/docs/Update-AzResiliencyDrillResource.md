---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/update-azresiliencydrillresource
schema: 2.0.0
---

# Update-AzResiliencyDrillResource

## SYNOPSIS
This enables the user to include, exclude or update resources from their Drill.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>] [-ResourceListExcludeResource <String[]>]
 [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzResiliencyDrillResource -InputObject <IResiliencyIdentity> -OperationId <String>
 -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResiliencyDrillResource -InputObject <IResiliencyIdentity> -OperationId <String>
 -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>] [-ResourceListExcludeResource <String[]>]
 [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroup
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupInputObject <IResiliencyIdentity>
 -OperationId <String> -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>]
 [-ResourceListExcludeResource <String[]>] [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzResiliencyDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This enables the user to include, exclude or update resources from their Drill.

## EXAMPLES

### Example 1: Add a resource to a drill
```powershell
Update-AzResiliencyDrillResource -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FaultDurationInMin 30 -ResourceListIncludeResource @(@{ Id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm" })
```

Adds a virtual machine to the drill and sets the fault duration to 30 minutes.
`-OperationId` is a client-generated GUID that identifies this long-running operation.

### Example 2: Exclude a resource from a drill
```powershell
Update-AzResiliencyDrillResource -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FaultDurationInMin 30 -ResourceListExcludeResource "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm2"
```

Excludes a virtual machine from the drill.

### Example 3: Set the default fault of a resource in a drill
```powershell
$vm = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm"
Update-AzResiliencyDrillResource -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FaultDurationInMin 30 -ResourceListUpdateResource @(@{ Id = $vm; DefaultFaultName = "VMShutdown"; DefaultFaultUrn = "urn:csci:microsoft:virtualMachine:shutdown/1.0"; DefaultFaultTargetResourceId = $vm })
```

Sets the default fault for a virtual machine that is already in the drill.
`DefaultFaultName`, `DefaultFaultUrn` and `DefaultFaultTargetResourceId` must all be set.

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

### -Body
Request body of the AddOrUpdateResources API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IAddOrUpdateResourcesRequest
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DrillName
The name of the Drill

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FaultDurationInMin
Duration of faults.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForceInclusionAndUpdate
Whether to allow inclusion and update despite attention reasons.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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

### -OperationId
A GUID that represents the Long Running OperationId.

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

### -ResourceListExcludeResource
Excluded resource

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceListIncludeResource
Include resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IIncludeOrUpdateResource[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceListUpdateResource
Update resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IIncludeOrUpdateResource[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: UpdateViaIdentityServiceGroup, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IAddOrUpdateResourcesRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

