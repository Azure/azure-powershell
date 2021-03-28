---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubresourcetyperegistration
schema: 2.0.0
---

# Set-AzProviderHubResourceTypeRegistration

## SYNOPSIS
Creates or updates a resource type.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 [-SubscriptionId <String>] [-AllowedUnauthorizedAction <String[]>]
 [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
 [-CheckNameAvailabilitySpecificationEnableDefaultValidation]
 [-CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]
 [-DefaultApiVersion <String>] [-DisallowedActionVerb <String[]>] [-EnableAsyncOperation]
 [-EnableThirdPartyS2S] [-Endpoint <IResourceTypeEndpoint[]>] [-ExtendedLocation <IExtendedLocationOptions[]>]
 [-FeatureRuleRequiredFeaturesPolicy <String>] [-IdentityManagementApplicationId <String>]
 [-IdentityManagementType <String>] [-IsPureProxy] [-LinkedAccessCheck <ILinkedAccessCheck[]>]
 [-LoggingRule <ILoggingRule[]>] [-MarketplaceType <String>] [-ProvisioningState <String>]
 [-Regionality <String>] [-RequestHeaderOptionOptInHeader <String>] [-RequiredFeature <String[]>]
 [-ResourceCreationBeginRequest <String[]>] [-ResourceCreationBeginResponse <String[]>]
 [-ResourceDeletionPolicy <String>] [-ResourceMovePolicyCrossResourceGroupMoveEnabled]
 [-ResourceMovePolicyCrossSubscriptionMoveEnabled] [-ResourceMovePolicyValidationRequired]
 [-RoutingType <String>] [-ServiceTreeInfo <IServiceTreeInfo[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-SubscriptionStateRule <ISubscriptionStateRule[]>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThrottlingRule <IThrottlingRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 -Property <IResourceTypeRegistration> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a resource type.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

## PARAMETERS

### -AllowedUnauthorizedAction
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
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

### -AuthorizationActionMapping
.
To construct, see NOTES section for AUTHORIZATIONACTIONMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckNameAvailabilitySpecificationEnableDefaultValidation
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultApiVersion
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DisallowedActionVerb
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAsyncOperation
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableThirdPartyS2S
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
.
To construct, see NOTES section for ENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocation
.
To construct, see NOTES section for EXTENDEDLOCATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FeatureRuleRequiredFeaturesPolicy
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityManagementApplicationId
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityManagementType
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsPureProxy
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkedAccessCheck
.
To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoggingRule
.
To construct, see NOTES section for LOGGINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceType
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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
.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### -ProvisioningState
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Regionality
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestHeaderOptionOptInHeader
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiredFeature
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceCreationBeginRequest
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceCreationBeginResponse
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceDeletionPolicy
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceMovePolicyCrossResourceGroupMoveEnabled
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceMovePolicyCrossSubscriptionMoveEnabled
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceMovePolicyValidationRequired
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type.

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

### -RoutingType
.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTreeInfo
.
To construct, see NOTES section for SERVICETREEINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl
.

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction
.
To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionStateRule
.
To construct, see NOTES section for SUBSCRIPTIONSTATERULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SwaggerSpecification
.
To construct, see NOTES section for SWAGGERSPECIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateDeploymentOptionPreflightOption
.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateDeploymentOptionPreflightSupported
.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThrottlingRule
.
To construct, see NOTES section for THROTTLINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AUTHORIZATIONACTIONMAPPING <IAuthorizationActionMapping[]>: .
  - `[Desired <String>]`: 
  - `[Original <String>]`: 

ENDPOINT <IResourceTypeEndpoint[]>: .
  - `[ApiVersion <String[]>]`: 
  - `[Enabled <Boolean?>]`: 
  - `[Extension <IResourceTypeExtension[]>]`: 
    - `[EndpointUri <String>]`: 
    - `[ExtensionCategory <String[]>]`: 
    - `[Timeout <TimeSpan?>]`: 
  - `[FeatureRuleRequiredFeaturesPolicy <String>]`: 
  - `[Location <String[]>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[Timeout <TimeSpan?>]`: 

EXTENDEDLOCATION <IExtendedLocationOptions[]>: .
  - `[SupportedPolicy <String>]`: 
  - `[Type <String>]`: 

LINKEDACCESSCHECK <ILinkedAccessCheck[]>: .
  - `[ActionName <String>]`: 
  - `[LinkedAction <String>]`: 
  - `[LinkedActionVerb <String>]`: 
  - `[LinkedProperty <String>]`: 
  - `[LinkedType <String>]`: 

LOGGINGRULE <ILoggingRule[]>: .
  - `Action <String>`: 
  - `DetailLevel <String>`: 
  - `Direction <String>`: 
  - `[HiddenPropertyPathHiddenPathsOnRequest <String[]>]`: 
  - `[HiddenPropertyPathHiddenPathsOnResponse <String[]>]`: 

PROPERTY <IResourceTypeRegistration>: .
  - `[AllowedUnauthorizedAction <String[]>]`: 
  - `[AuthorizationActionMapping <IAuthorizationActionMapping[]>]`: 
    - `[Desired <String>]`: 
    - `[Original <String>]`: 
  - `[CheckNameAvailabilitySpecificationEnableDefaultValidation <Boolean?>]`: 
  - `[CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]`: 
  - `[DefaultApiVersion <String>]`: 
  - `[DisallowedActionVerb <String[]>]`: 
  - `[EnableAsyncOperation <Boolean?>]`: 
  - `[EnableThirdPartyS2S <Boolean?>]`: 
  - `[Endpoint <IResourceTypeEndpoint[]>]`: 
    - `[ApiVersion <String[]>]`: 
    - `[Enabled <Boolean?>]`: 
    - `[Extension <IResourceTypeExtension[]>]`: 
      - `[EndpointUri <String>]`: 
      - `[ExtensionCategory <String[]>]`: 
      - `[Timeout <TimeSpan?>]`: 
    - `[FeatureRuleRequiredFeaturesPolicy <String>]`: 
    - `[Location <String[]>]`: 
    - `[RequiredFeature <String[]>]`: 
    - `[Timeout <TimeSpan?>]`: 
  - `[ExtendedLocation <IExtendedLocationOptions[]>]`: 
    - `[SupportedPolicy <String>]`: 
    - `[Type <String>]`: 
  - `[FeatureRuleRequiredFeaturesPolicy <String>]`: 
  - `[IdentityManagementApplicationId <String>]`: 
  - `[IdentityManagementType <String>]`: 
  - `[IsPureProxy <Boolean?>]`: 
  - `[LinkedAccessCheck <ILinkedAccessCheck[]>]`: 
    - `[ActionName <String>]`: 
    - `[LinkedAction <String>]`: 
    - `[LinkedActionVerb <String>]`: 
    - `[LinkedProperty <String>]`: 
    - `[LinkedType <String>]`: 
  - `[LoggingRule <ILoggingRule[]>]`: 
    - `Action <String>`: 
    - `DetailLevel <String>`: 
    - `Direction <String>`: 
    - `[HiddenPropertyPathHiddenPathsOnRequest <String[]>]`: 
    - `[HiddenPropertyPathHiddenPathsOnResponse <String[]>]`: 
  - `[MarketplaceType <String>]`: 
  - `[ProvisioningState <String>]`: 
  - `[Regionality <String>]`: 
  - `[RequestHeaderOptionOptInHeader <String>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[ResourceCreationBeginRequest <String[]>]`: 
  - `[ResourceCreationBeginResponse <String[]>]`: 
  - `[ResourceDeletionPolicy <String>]`: 
  - `[ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]`: 
  - `[ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]`: 
  - `[ResourceMovePolicyValidationRequired <Boolean?>]`: 
  - `[RoutingType <String>]`: 
  - `[ServiceTreeInfo <IServiceTreeInfo[]>]`: 
    - `[ComponentId <String>]`: 
    - `[ServiceId <String>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
    - `Action <String>`: 
    - `State <String>`: 
  - `[SubscriptionStateRule <ISubscriptionStateRule[]>]`: 
    - `[AllowedAction <String[]>]`: 
    - `[State <String>]`: 
  - `[SwaggerSpecification <ISwaggerSpecification[]>]`: 
    - `[ApiVersion <String[]>]`: 
    - `[SwaggerSpecFolderUri <String>]`: 
  - `[TemplateDeploymentOptionPreflightOption <String[]>]`: 
  - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
  - `[ThrottlingRule <IThrottlingRule[]>]`: 
    - `Action <String>`: 
    - `Metric <IThrottlingMetric[]>`: 
      - `Limit <Int64>`: 
      - `Type <String>`: 
      - `[Interval <TimeSpan?>]`: 
    - `[RequiredFeature <String[]>]`: 

SERVICETREEINFO <IServiceTreeInfo[]>: .
  - `[ComponentId <String>]`: 
  - `[ServiceId <String>]`: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  - `Action <String>`: 
  - `State <String>`: 

SUBSCRIPTIONSTATERULE <ISubscriptionStateRule[]>: .
  - `[AllowedAction <String[]>]`: 
  - `[State <String>]`: 

SWAGGERSPECIFICATION <ISwaggerSpecification[]>: .
  - `[ApiVersion <String[]>]`: 
  - `[SwaggerSpecFolderUri <String>]`: 

THROTTLINGRULE <IThrottlingRule[]>: .
  - `Action <String>`: 
  - `Metric <IThrottlingMetric[]>`: 
    - `Limit <Int64>`: 
    - `Type <String>`: 
    - `[Interval <TimeSpan?>]`: 
  - `[RequiredFeature <String[]>]`: 

## RELATED LINKS

