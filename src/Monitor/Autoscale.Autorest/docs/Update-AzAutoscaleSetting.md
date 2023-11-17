---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azAutoscaleSetting
schema: 2.0.0
---

# Update-AzAutoscaleSetting

## SYNOPSIS
Updates an existing AutoscaleSettingsResource.
To update other fields use the CreateOrUpdate method.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAutoscaleSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Enabled <Boolean>] [-Notification <IAutoscaleNotification[]>]
 [-PredictiveAutoscalePolicyScaleLookAheadTime <TimeSpan>]
 [-PredictiveAutoscalePolicyScaleMode <PredictiveAutoscalePolicyScaleMode>] [-Profile <IAutoscaleProfile[]>]
 [-Tag <Hashtable>] [-TargetResourceLocation <String>] [-TargetResourceUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAutoscaleSetting -InputObject <IAutoscaleIdentity> [-Enabled <Boolean>]
 [-Notification <IAutoscaleNotification[]>] [-PredictiveAutoscalePolicyScaleLookAheadTime <TimeSpan>]
 [-PredictiveAutoscalePolicyScaleMode <PredictiveAutoscalePolicyScaleMode>] [-Profile <IAutoscaleProfile[]>]
 [-Tag <Hashtable>] [-TargetResourceLocation <String>] [-TargetResourceUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing AutoscaleSettingsResource.
To update other fields use the CreateOrUpdate method.

## EXAMPLES

### Example 1: Update Tag and Enable existing autoscale setting
```powershell
Update-AzAutoscaleSetting -ResourceGroupName test-group -Name test-autoscalesetting -Tag @{'key'='val'} -Enabled $true
```

Update Tag and Enable existing autoscale setting

## PARAMETERS

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

### -Enabled
the enabled flag.
Specifies whether automatic scaling is enabled for the resource.
The default value is 'false'.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The autoscale setting name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: AutoscaleSettingName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Notification
the collection of notifications.
To construct, see NOTES section for NOTIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleNotification[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PredictiveAutoscalePolicyScaleLookAheadTime
the amount of time to specify by which instances are launched in advance.
It must be between 1 minute and 60 minutes in ISO 8601 format.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PredictiveAutoscalePolicyScaleMode
the predictive autoscale mode

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.PredictiveAutoscalePolicyScaleMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
the collection of automatic scaling profiles that specify different scaling parameters for different time periods.
A maximum of 20 profiles can be specified.
To construct, see NOTES section for PROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleProfile[]
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceLocation
the location of the resource that the autoscale setting should be added to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceUri
the resource identifier of the resource that the autoscale setting should be added to.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource

## NOTES

## RELATED LINKS

