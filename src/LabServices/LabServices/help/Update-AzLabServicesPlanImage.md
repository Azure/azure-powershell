---
external help file: Az.LabServices-help.xml
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/update-azlabservicesplanimage
schema: 2.0.0
---

# Update-AzLabServicesPlanImage

## SYNOPSIS
Update an image resource.

## SYNTAX

### ResourceId (Default)
```
Update-AzLabServicesPlanImage [-SubscriptionId <String>] -EnabledState <String> -ResourceId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzLabServicesPlanImage -LabPlanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzLabServicesPlanImage -LabPlanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzLabServicesPlanImage -LabPlanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnabledState <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LabPlan
```
Update-AzLabServicesPlanImage -Name <String> [-SubscriptionId <String>] -LabPlan <LabPlan>
 -EnabledState <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityLabPlanExpanded
```
Update-AzLabServicesPlanImage -Name <String> -LabPlanInputObject <ILabServicesIdentity>
 [-EnabledState <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzLabServicesPlanImage -InputObject <ILabServicesIdentity> [-EnabledState <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an image resource.

## EXAMPLES

### Example 1: Update a lab plan image.
```powershell
Update-AzLabServicesPlanImage -ResourceGroupName "Group Name" -LabPlanName "LabPlan Name" -Name "Image Name" -EnabledState "Enabled"
```

```output
Name
----
Image Name
```

This example enables the image for use in labs.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResourceId
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

### -EnabledState
Is the image enabled

```yaml
Type: System.String
Parameter Sets: ResourceId, LabPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityLabPlanExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
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

### -LabPlan
The object of lab service lab plan.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan
Parameter Sets: LabPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabPlanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: UpdateViaIdentityLabPlanExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabPlanName
The name of the lab plan that uniquely identifies it within containing resource group.
Used in resource URIs and in UI.

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The image name.

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded, LabPlan, UpdateViaIdentityLabPlanExpanded
Aliases: ImageName

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
Parameter Sets: ResourceId
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
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of lan service lab plan image to update.

```yaml
Type: System.String
Parameter Sets: ResourceId
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
Type: System.String
Parameter Sets: ResourceId, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded, LabPlan
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.IImage

## NOTES

## RELATED LINKS
