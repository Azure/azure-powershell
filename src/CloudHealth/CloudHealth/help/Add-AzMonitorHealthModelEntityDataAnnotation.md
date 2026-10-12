---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/add-azmonitorhealthmodelentitydataannotation
schema: 2.0.0
---

# Add-AzMonitorHealthModelEntityDataAnnotation

## SYNOPSIS
Add a data annotation to an entity

## SYNTAX

### AddExpanded (Default)
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -AnnotationDetail <Hashtable> [-Description <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddViaJsonString
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddViaJsonFilePath
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddViaIdentityHealthmodelExpanded
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> -AnnotationDetail <Hashtable> [-Description <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddViaIdentityHealthmodel
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> -Body <IAddDataAnnotationRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Add
```
Add-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Body <IAddDataAnnotationRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzMonitorHealthModelEntityDataAnnotation -InputObject <ICloudHealthIdentity> -AnnotationDetail <Hashtable>
 [-Description <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AddViaIdentity
```
Add-AzMonitorHealthModelEntityDataAnnotation -InputObject <ICloudHealthIdentity>
 -Body <IAddDataAnnotationRequest> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Add a data annotation to an entity

## EXAMPLES

### Example 1: Annotate an entity with a maintenance window
```powershell
# Add a data annotation to the entity frontend-service
Add-AzMonitorHealthModelEntityDataAnnotation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -Description 'Planned maintenance window' -AnnotationDetail @{ startTime = '2026-08-10T09:00:00Z'; endTime = '2026-08-10T11:00:00Z' }
```

Adds a data annotation to the entity.

## PARAMETERS

### -AnnotationDetail
Annotation details as a dynamic key-value pair bag.
Service-enforced limits: a maximum of 10 entries per annotation and a maximum value length of 256 characters.
Requests exceeding these limits will be rejected with a 400 response.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: AddExpanded, AddViaIdentityHealthmodelExpanded, AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Request body for adding a data annotation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAddDataAnnotationRequest
Parameter Sets: AddViaIdentityHealthmodel, Add, AddViaIdentity
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

### -Description
Optional description of the annotation

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityHealthmodelExpanded, AddViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityName
Name of the entity.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaJsonString, AddViaJsonFilePath, AddViaIdentityHealthmodelExpanded, AddViaIdentityHealthmodel, Add
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: AddViaIdentityHealthmodelExpanded, AddViaIdentityHealthmodel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HealthModelName
Name of health model resource

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaJsonString, AddViaJsonFilePath, Add
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: AddViaIdentityExpanded, AddViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Add operation

```yaml
Type: System.String
Parameter Sets: AddViaJsonString
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
Parameter Sets: AddExpanded, AddViaJsonString, AddViaJsonFilePath, Add
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
Parameter Sets: AddExpanded, AddViaJsonString, AddViaJsonFilePath, Add
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IAddDataAnnotationRequest

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDataAnnotation

## NOTES

## RELATED LINKS
