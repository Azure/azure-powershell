---
external help file: Az.CloudHealth-help.xml
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
 [-SubscriptionId <String>] [-AddRecommendedSignal <String>] [-AddResourceHealthSignal <String>]
 [-AuthenticationSetting <String>] [-DiscoverRelationship <String>] [-DisplayName <String>]
 [-Specification <IDiscoveryRuleSpecification>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Resource <IDiscoveryRule> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityHealthmodelExpanded
```
Update-AzMonitorHealthModelDiscoveryRule -Name <String> -HealthmodelInputObject <ICloudHealthIdentity>
 [-AddRecommendedSignal <String>] [-AddResourceHealthSignal <String>] [-AuthenticationSetting <String>]
 [-DiscoverRelationship <String>] [-DisplayName <String>] [-Specification <IDiscoveryRuleSpecification>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityHealthmodel
```
Update-AzMonitorHealthModelDiscoveryRule -Name <String> -HealthmodelInputObject <ICloudHealthIdentity>
 -Resource <IDiscoveryRule> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMonitorHealthModelDiscoveryRule -InputObject <ICloudHealthIdentity> [-AddRecommendedSignal <String>]
 [-AddResourceHealthSignal <String>] [-AuthenticationSetting <String>] [-DiscoverRelationship <String>]
 [-DisplayName <String>] [-Specification <IDiscoveryRuleSpecification>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzMonitorHealthModelDiscoveryRule -InputObject <ICloudHealthIdentity> -Resource <IDiscoveryRule>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a DiscoveryRule

## EXAMPLES

### Example 1: Update the query on a discovery rule
```powershell
# Replace the Resource Graph query on the discovery rule discover-vms
$specification = New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' and tags['env'] =~ 'prod' | project id"
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover production virtual machines' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-vms -Property $property
```

Replaces the specification with a Resource Graph query that also filters on the env tag.

### Example 2: Update the Application Insights component on a discovery rule
```powershell
# Point the discovery rule discover-appinsights at a different Application Insights component
$applicationInsightsId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/microsoft.insights/components/azpwsh-appinsights'
$specification = New-AzMonitorHealthModelApplicationInsightsTopologySpecificationObject -ApplicationInsightsResourceId $applicationInsightsId
$property = New-AzMonitorHealthModelDiscoveryRulePropertiesObject -AuthenticationSetting default-auth -AddRecommendedSignal Enabled -AddResourceHealthSignal Enabled -DiscoverRelationship Enabled -DisplayName 'Discover services from Application Insights' -Specification $specification
Update-AzMonitorHealthModelDiscoveryRule -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name discover-appinsights -Property $property
```

Replaces the specification on an existing Application Insights discovery rule.

## PARAMETERS

### -AddRecommendedSignal
Whether to add all recommended signals to the discovered entities.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddResourceHealthSignal
Whether to automatically add a signal for the Azure resource's availability state from Azure Resource Health to the discovered entities.
Defaults to `Enabled`: discovery rules updated via this API version without setting this field will begin emitting a Resource Health availability signal.
Pass `Disabled` to preserve pre-`2026-05-01-preview` behavior.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AuthenticationSetting
Reference to the name of the authentication setting which is used for querying Azure Resource Graph.
The same authentication setting will also be assigned to any discovered entities.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
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

### -DiscoverRelationship
Whether to create relationships between the discovered entities based on a set of built-in rules.
These relationships cannot be manually deleted.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Display name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityHealthmodel
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
Parameter Sets: UpdateExpanded, Update
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
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
Parameter Sets: UpdateExpanded, Update, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityHealthmodel
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

### -Resource
A discovery rule which automatically finds entities and relationships in a health model based on an Azure Resource Graph query

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRule
Parameter Sets: Update, UpdateViaIdentityHealthmodel, UpdateViaIdentity
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
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Specification
Specification of the discovery rule defining how entities are discovered.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IDiscoveryRuleSpecification
Parameter Sets: UpdateExpanded, UpdateViaIdentityHealthmodelExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, Update
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
