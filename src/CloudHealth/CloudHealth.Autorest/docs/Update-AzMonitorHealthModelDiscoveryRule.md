---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/update-azmonitorhealthmodeldiscoveryrule
schema: 2.0.0
---

# Update-AzMonitorHealthModelDiscoveryRule

## SYNOPSIS
Update a DiscoveryRule

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Property <IDiscoveryRuleProperties>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 -Resource <IDiscoveryRule> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzMonitorHealthModelDiscoveryRule -InputObject <ICloudHealthIdentity> -Resource <IDiscoveryRule>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMonitorHealthModelDiscoveryRule -InputObject <ICloudHealthIdentity>
 [-Property <IDiscoveryRuleProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityHealthmodel
```
Update-AzMonitorHealthModelDiscoveryRule -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 -Resource <IDiscoveryRule> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityHealthmodelExpanded
```
Update-AzMonitorHealthModelDiscoveryRule -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 [-Property <IDiscoveryRuleProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a DiscoveryRule

## EXAMPLES

### Example 1: Narrow the query on a discovery rule
```powershell
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' and tags['env'] =~ 'prod' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover production virtual machines' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Restricts discovery to virtual machines tagged as production.

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

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: UpdateViaIdentityHealthmodel, UpdateViaIdentityHealthmodelExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the discovery rule.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityHealthmodel, UpdateViaIdentityHealthmodelExpanded
Aliases: DiscoveryRuleName

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

### -Property
The resource-specific properties for this resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRuleProperties
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
A discovery rule which automatically finds entities and relationships in a health model based on an Azure Resource Graph query

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRule
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityHealthmodel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRule

## NOTES

## RELATED LINKS

