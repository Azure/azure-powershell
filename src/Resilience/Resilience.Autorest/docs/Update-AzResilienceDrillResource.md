---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/update-azresiliencedrillresource
schema: 2.0.0
---

# Update-AzResilienceDrillResource

## SYNOPSIS
This enables the user to include, exclude or update resources from their Drill.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>] [-ResourceListExcludeResource <String[]>]
 [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzResilienceDrillResource -InputObject <IResilienceIdentity> -OperationId <String>
 -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResilienceDrillResource -InputObject <IResilienceIdentity> -OperationId <String>
 -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>] [-ResourceListExcludeResource <String[]>]
 [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroup
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> -Body <IAddOrUpdateResourcesRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -OperationId <String> -FaultDurationInMin <Int32> [-ForceInclusionAndUpdate <String>]
 [-ResourceListExcludeResource <String[]>] [-ResourceListIncludeResource <IIncludeOrUpdateResource[]>]
 [-ResourceListUpdateResource <IIncludeOrUpdateResource[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzResilienceDrillResource -DrillName <String> -ServiceGroupName <String> -OperationId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
This enables the user to include, exclude or update resources from their Drill.

## EXAMPLES

### Example 1: Update a drill resource
```powershell
Update-AzResilienceDrillResource `
  -DrillName 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -FaultDurationInMin 0
```

Updates the specified drill resource, preserving properties that are not supplied.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IAddOrUpdateResourcesRequest
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IIncludeOrUpdateResource[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IIncludeOrUpdateResource[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IAddOrUpdateResourcesRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

