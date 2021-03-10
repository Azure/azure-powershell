---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubcustomrollout
schema: 2.0.0
---

# Set-AzProviderHubCustomRollout

## SYNOPSIS
Creates or updates the rollout details.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> [-SubscriptionId <String>]
 [-CanaryRegion <String[]>] [-ProvisioningState <ProvisioningState>]
 [-SpecificationProviderRegistration <IProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> -Property <ICustomRollout>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the rollout details.

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

### -CanaryRegion
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

### -Property
Rollout details.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RolloutName
The rollout name.

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

### -SpecificationProviderRegistration
.
To construct, see NOTES section for SPECIFICATIONPROVIDERREGISTRATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationResourceTypeRegistration
.
To construct, see NOTES section for SPECIFICATIONRESOURCETYPEREGISTRATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusCompletedRegion
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

### -StatusFailedOrSkippedRegion
Dictionary of \<ExtendedErrorInfo\>

```yaml
Type: System.Collections.Hashtable
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROPERTY <ICustomRollout>: Rollout details.
  - `[CanaryRegion <String[]>]`: 
  - `[ProvisioningState <ProvisioningState?>]`: 
  - `[SpecificationProviderRegistration <IProviderRegistration>]`: 
    - `[Capability <IResourceProviderCapabilities[]>]`: 
      - `Effect <ResourceProviderCapabilitiesEffect>`: 
      - `QuotaId <String>`: 
      - `[RequiredFeature <String[]>]`: 
    - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
    - `[ManagementIncidentContactEmail <String>]`: 
    - `[ManagementIncidentRoutingService <String>]`: 
    - `[ManagementIncidentRoutingTeam <String>]`: 
    - `[ManagementManifestOwner <String[]>]`: 
    - `[ManagementResourceAccessPolicy <String>]`: 
    - `[ManagementResourceAccessRole <IAny[]>]`: 
    - `[ManagementSchemaOwner <String[]>]`: 
    - `[ManagementServiceTreeInfo <IServiceTreeInfo[]>]`: 
      - `[ComponentId <String>]`: 
      - `[ServiceId <String>]`: 
    - `[Metadata <IAny>]`: Any object
    - `[Namespace <String>]`: 
    - `[ProviderAuthenticationAllowedAudience <String[]>]`: 
    - `[ProviderAuthorization <IResourceProviderAuthorization[]>]`: 
      - `[ApplicationId <String>]`: 
      - `[ManagedByRoleDefinitionId <String>]`: 
      - `[RoleDefinitionId <String>]`: 
    - `[ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]`: 
    - `[ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]`: 
    - `[ProviderType <ResourceProviderType?>]`: 
    - `[ProviderVersion <String>]`: 
    - `[ProvisioningState <ProvisioningState?>]`: 
    - `[RequestHeaderOptionOptInHeader <OptInHeaderType?>]`: 
    - `[RequiredFeature <String[]>]`: 
    - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
    - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
      - `Action <SubscriptionNotificationOperation>`: 
      - `State <SubscriptionTransitioningState>`: 
    - `[TemplateDeploymentOptionPreflightOption <PreflightOption[]>]`: 
    - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
    - `[ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]`: 
      - `PrincipalId <String>`: 
      - `RoleDefinitionId <String>`: 
    - `[ThirdPartyProviderAuthorizationManagedByTenantId <String>]`: 
  - `[SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>]`: 
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
        - `[ExtensionCategory <ExtensionCategory[]>]`: 
        - `[Timeout <TimeSpan?>]`: 
      - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
      - `[Location <String[]>]`: 
      - `[RequiredFeature <String[]>]`: 
      - `[Timeout <TimeSpan?>]`: 
    - `[ExtendedLocation <IExtendedLocationOptions[]>]`: 
      - `[SupportedPolicy <String>]`: 
      - `[Type <String>]`: 
    - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
    - `[IdentityManagementApplicationId <String>]`: 
    - `[IdentityManagementType <IdentityManagementTypes?>]`: 
    - `[IsPureProxy <Boolean?>]`: 
    - `[LinkedAccessCheck <ILinkedAccessCheck[]>]`: 
      - `[ActionName <String>]`: 
      - `[LinkedAction <String>]`: 
      - `[LinkedActionVerb <String>]`: 
      - `[LinkedProperty <String>]`: 
      - `[LinkedType <String>]`: 
    - `[LoggingRule <ILoggingRule[]>]`: 
      - `Action <String>`: 
      - `DetailLevel <LoggingDetails>`: 
      - `Direction <LoggingDirections>`: 
      - `[HiddenPropertyPathHiddenPathsOnRequest <String[]>]`: 
      - `[HiddenPropertyPathHiddenPathsOnResponse <String[]>]`: 
    - `[MarketplaceType <String>]`: 
    - `[ProvisioningState <ProvisioningState?>]`: 
    - `[Regionality <Regionality?>]`: 
    - `[RequestHeaderOptionOptInHeader <OptInHeaderType?>]`: 
    - `[RequiredFeature <String[]>]`: 
    - `[ResourceCreationBeginRequest <ExtensionOptionType[]>]`: 
    - `[ResourceCreationBeginResponse <ExtensionOptionType[]>]`: 
    - `[ResourceDeletionPolicy <ResourceDeletionPolicy?>]`: 
    - `[ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]`: 
    - `[ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]`: 
    - `[ResourceMovePolicyValidationRequired <Boolean?>]`: 
    - `[RoutingType <RoutingType?>]`: 
    - `[ServiceTreeInfo <IServiceTreeInfo[]>]`: 
    - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
    - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
    - `[SubscriptionStateRule <ISubscriptionStateRule[]>]`: 
      - `[AllowedAction <String[]>]`: 
      - `[State <SubscriptionState?>]`: 
    - `[SwaggerSpecification <ISwaggerSpecification[]>]`: 
      - `[ApiVersion <String[]>]`: 
      - `[SwaggerSpecFolderUri <String>]`: 
    - `[TemplateDeploymentOptionPreflightOption <PreflightOption[]>]`: 
    - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
    - `[ThrottlingRule <IThrottlingRule[]>]`: 
      - `Action <String>`: 
      - `Metric <IThrottlingMetric[]>`: 
        - `Limit <Int64>`: 
        - `Type <ThrottlingMetricType>`: 
        - `[Interval <TimeSpan?>]`: 
      - `[RequiredFeature <String[]>]`: 
  - `[StatusCompletedRegion <String[]>]`: 
  - `[StatusFailedOrSkippedRegion <ICustomRolloutStatusFailedOrSkippedRegions>]`: Dictionary of <ExtendedErrorInfo>
    - `[(Any) <IExtendedErrorInfo>]`: This indicates any property can be added to this object.

SPECIFICATIONPROVIDERREGISTRATION <IProviderRegistration>: .
  - `[Capability <IResourceProviderCapabilities[]>]`: 
    - `Effect <ResourceProviderCapabilitiesEffect>`: 
    - `QuotaId <String>`: 
    - `[RequiredFeature <String[]>]`: 
  - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
  - `[ManagementIncidentContactEmail <String>]`: 
  - `[ManagementIncidentRoutingService <String>]`: 
  - `[ManagementIncidentRoutingTeam <String>]`: 
  - `[ManagementManifestOwner <String[]>]`: 
  - `[ManagementResourceAccessPolicy <String>]`: 
  - `[ManagementResourceAccessRole <IAny[]>]`: 
  - `[ManagementSchemaOwner <String[]>]`: 
  - `[ManagementServiceTreeInfo <IServiceTreeInfo[]>]`: 
    - `[ComponentId <String>]`: 
    - `[ServiceId <String>]`: 
  - `[Metadata <IAny>]`: Any object
  - `[Namespace <String>]`: 
  - `[ProviderAuthenticationAllowedAudience <String[]>]`: 
  - `[ProviderAuthorization <IResourceProviderAuthorization[]>]`: 
    - `[ApplicationId <String>]`: 
    - `[ManagedByRoleDefinitionId <String>]`: 
    - `[RoleDefinitionId <String>]`: 
  - `[ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]`: 
  - `[ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]`: 
  - `[ProviderType <ResourceProviderType?>]`: 
  - `[ProviderVersion <String>]`: 
  - `[ProvisioningState <ProvisioningState?>]`: 
  - `[RequestHeaderOptionOptInHeader <OptInHeaderType?>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
    - `Action <SubscriptionNotificationOperation>`: 
    - `State <SubscriptionTransitioningState>`: 
  - `[TemplateDeploymentOptionPreflightOption <PreflightOption[]>]`: 
  - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
  - `[ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]`: 
    - `PrincipalId <String>`: 
    - `RoleDefinitionId <String>`: 
  - `[ThirdPartyProviderAuthorizationManagedByTenantId <String>]`: 

SPECIFICATIONRESOURCETYPEREGISTRATION <IResourceTypeRegistration[]>: .
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
      - `[ExtensionCategory <ExtensionCategory[]>]`: 
      - `[Timeout <TimeSpan?>]`: 
    - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
    - `[Location <String[]>]`: 
    - `[RequiredFeature <String[]>]`: 
    - `[Timeout <TimeSpan?>]`: 
  - `[ExtendedLocation <IExtendedLocationOptions[]>]`: 
    - `[SupportedPolicy <String>]`: 
    - `[Type <String>]`: 
  - `[FeatureRuleRequiredFeaturesPolicy <FeaturesPolicy?>]`: 
  - `[IdentityManagementApplicationId <String>]`: 
  - `[IdentityManagementType <IdentityManagementTypes?>]`: 
  - `[IsPureProxy <Boolean?>]`: 
  - `[LinkedAccessCheck <ILinkedAccessCheck[]>]`: 
    - `[ActionName <String>]`: 
    - `[LinkedAction <String>]`: 
    - `[LinkedActionVerb <String>]`: 
    - `[LinkedProperty <String>]`: 
    - `[LinkedType <String>]`: 
  - `[LoggingRule <ILoggingRule[]>]`: 
    - `Action <String>`: 
    - `DetailLevel <LoggingDetails>`: 
    - `Direction <LoggingDirections>`: 
    - `[HiddenPropertyPathHiddenPathsOnRequest <String[]>]`: 
    - `[HiddenPropertyPathHiddenPathsOnResponse <String[]>]`: 
  - `[MarketplaceType <String>]`: 
  - `[ProvisioningState <ProvisioningState?>]`: 
  - `[Regionality <Regionality?>]`: 
  - `[RequestHeaderOptionOptInHeader <OptInHeaderType?>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[ResourceCreationBeginRequest <ExtensionOptionType[]>]`: 
  - `[ResourceCreationBeginResponse <ExtensionOptionType[]>]`: 
  - `[ResourceDeletionPolicy <ResourceDeletionPolicy?>]`: 
  - `[ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]`: 
  - `[ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]`: 
  - `[ResourceMovePolicyValidationRequired <Boolean?>]`: 
  - `[RoutingType <RoutingType?>]`: 
  - `[ServiceTreeInfo <IServiceTreeInfo[]>]`: 
    - `[ComponentId <String>]`: 
    - `[ServiceId <String>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
    - `Action <SubscriptionNotificationOperation>`: 
    - `State <SubscriptionTransitioningState>`: 
  - `[SubscriptionStateRule <ISubscriptionStateRule[]>]`: 
    - `[AllowedAction <String[]>]`: 
    - `[State <SubscriptionState?>]`: 
  - `[SwaggerSpecification <ISwaggerSpecification[]>]`: 
    - `[ApiVersion <String[]>]`: 
    - `[SwaggerSpecFolderUri <String>]`: 
  - `[TemplateDeploymentOptionPreflightOption <PreflightOption[]>]`: 
  - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
  - `[ThrottlingRule <IThrottlingRule[]>]`: 
    - `Action <String>`: 
    - `Metric <IThrottlingMetric[]>`: 
      - `Limit <Int64>`: 
      - `Type <ThrottlingMetricType>`: 
      - `[Interval <TimeSpan?>]`: 
    - `[RequiredFeature <String[]>]`: 

## RELATED LINKS

