---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubcustomrollout
schema: 2.0.0
---

# New-AzProviderHubCustomRollout

## SYNOPSIS
Creates or updates the rollout details.

## SYNTAX

```
New-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> [-SubscriptionId <String>]
 [-CanaryRegion <String[]>] [-ProvisioningState <String>]
 [-SpecificationProviderRegistration <IProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the rollout details.

## EXAMPLES

### Example 1: Create/Update a resource provider custom rollout.
```powershell
PS C:\> New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -CanaryRegion "Eastus2EUAP"
```

## PARAMETERS

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CanaryRegion
.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

SPECIFICATIONPROVIDERREGISTRATION \<IProviderRegistration\>: .
  \[Capability \<IResourceProviderCapabilities\[\]\>\]:
    Effect \<String\>:
    QuotaId \<String\>:
    \[RequiredFeature \<String\[\]\>\]:
  \[FeatureRuleRequiredFeaturesPolicy \<String\>\]:
  \[ManagementIncidentContactEmail \<String\>\]:
  \[ManagementIncidentRoutingService \<String\>\]:
  \[ManagementIncidentRoutingTeam \<String\>\]:
  \[ManagementManifestOwner \<String\[\]\>\]:
  \[ManagementResourceAccessPolicy \<String\>\]:
  \[ManagementResourceAccessRole \<IResourceProviderManagementResourceAccessRolesItem\[\]\>\]:
  \[ManagementSchemaOwner \<String\[\]\>\]:
  \[ManagementServiceTreeInfo \<IServiceTreeInfo\[\]\>\]:
    \[ComponentId \<String\>\]:
    \[ServiceId \<String\>\]:
  \[Metadata \<IResourceProviderManifestPropertiesMetadata\>\]: Dictionary of \<string\>
    \[(Any) \<String\>\]: This indicates any property can be added to this object.
  \[Namespace \<String\>\]:
  \[ProviderAuthenticationAllowedAudience \<String\[\]\>\]:
  \[ProviderAuthorization \<IResourceProviderAuthorization\[\]\>\]:
    \[ApplicationId \<String\>\]:
    \[ManagedByRoleDefinitionId \<String\>\]:
    \[RoleDefinitionId \<String\>\]:
  \[ProviderHubMetadataProviderAuthenticationAllowedAudience \<String\[\]\>\]:
  \[ProviderHubMetadataProviderAuthorization \<IResourceProviderAuthorization\[\]\>\]:
  \[ProviderType \<String\>\]:
  \[ProviderVersion \<String\>\]:
  \[ProvisioningState \<String\>\]:
  \[RequestHeaderOptionOptInHeader \<String\>\]:
  \[RequiredFeature \<String\[\]\>\]:
  \[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl \<TimeSpan?\>\]:
  \[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction \<ISubscriptionStateOverrideAction\[\]\>\]:
    Action \<String\>:
    State \<String\>:
  \[TemplateDeploymentOptionPreflightOption \<String\[\]\>\]:
  \[TemplateDeploymentOptionPreflightSupported \<Boolean?\>\]:
  \[ThirdPartyProviderAuthorizationAuthorizationszzz \<ILightHouseAuthorization\[\]\>\]:
    PrincipalId \<String\>:
    RoleDefinitionId \<String\>:
  \[ThirdPartyProviderAuthorizationManagedByTenantId \<String\>\]:

SPECIFICATIONRESOURCETYPEREGISTRATION \<IResourceTypeRegistration\[\]\>: .
  \[AllowedUnauthorizedAction \<String\[\]\>\]:
  \[AuthorizationActionMapping \<IAuthorizationActionMapping\[\]\>\]:
    \[Desired \<String\>\]:
    \[Original \<String\>\]:
  \[CheckNameAvailabilitySpecificationEnableDefaultValidation \<Boolean?\>\]:
  \[CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation \<String\[\]\>\]:
  \[DefaultApiVersion \<String\>\]:
  \[DisallowedActionVerb \<String\[\]\>\]:
  \[EnableAsyncOperation \<Boolean?\>\]:
  \[EnableThirdPartyS2S \<Boolean?\>\]:
  \[Endpoint \<IResourceTypeEndpoint\[\]\>\]:
    \[ApiVersion \<String\[\]\>\]:
    \[Enabled \<Boolean?\>\]:
    \[Extension \<IResourceTypeExtension\[\]\>\]:
      \[EndpointUri \<String\>\]:
      \[ExtensionCategory \<String\[\]\>\]:
      \[Timeout \<TimeSpan?\>\]:
    \[FeatureRuleRequiredFeaturesPolicy \<String\>\]:
    \[Location \<String\[\]\>\]:
    \[RequiredFeature \<String\[\]\>\]:
    \[Timeout \<TimeSpan?\>\]:
  \[ExtendedLocation \<IExtendedLocationOptions\[\]\>\]:
    \[SupportedPolicy \<String\>\]:
    \[Type \<String\>\]:
  \[FeatureRuleRequiredFeaturesPolicy \<String\>\]:
  \[IdentityManagementApplicationId \<String\>\]:
  \[IdentityManagementType \<String\>\]:
  \[IsPureProxy \<Boolean?\>\]:
  \[LinkedAccessCheck \<ILinkedAccessCheck\[\]\>\]:
    \[ActionName \<String\>\]:
    \[LinkedAction \<String\>\]:
    \[LinkedActionVerb \<String\>\]:
    \[LinkedProperty \<String\>\]:
    \[LinkedType \<String\>\]:
  \[LoggingRule \<ILoggingRule\[\]\>\]:
    Action \<String\>:
    DetailLevel \<String\>:
    Direction \<String\>:
    \[HiddenPropertyPathHiddenPathsOnRequest \<String\[\]\>\]:
    \[HiddenPropertyPathHiddenPathsOnResponse \<String\[\]\>\]:
  \[MarketplaceType \<String\>\]:
  \[ProvisioningState \<String\>\]:
  \[Regionality \<String\>\]:
  \[RequestHeaderOptionOptInHeader \<String\>\]:
  \[RequiredFeature \<String\[\]\>\]:
  \[ResourceCreationBeginRequest \<String\[\]\>\]:
  \[ResourceCreationBeginResponse \<String\[\]\>\]:
  \[ResourceDeletionPolicy \<String\>\]:
  \[ResourceMovePolicyCrossResourceGroupMoveEnabled \<Boolean?\>\]:
  \[ResourceMovePolicyCrossSubscriptionMoveEnabled \<Boolean?\>\]:
  \[ResourceMovePolicyValidationRequired \<Boolean?\>\]:
  \[RoutingType \<String\>\]:
  \[ServiceTreeInfo \<IServiceTreeInfo\[\]\>\]:
    \[ComponentId \<String\>\]:
    \[ServiceId \<String\>\]:
  \[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl \<TimeSpan?\>\]:
  \[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction \<ISubscriptionStateOverrideAction\[\]\>\]:
    Action \<String\>:
    State \<String\>:
  \[SubscriptionStateRule \<ISubscriptionStateRule\[\]\>\]:
    \[AllowedAction \<String\[\]\>\]:
    \[State \<String\>\]:
  \[SwaggerSpecification \<ISwaggerSpecification\[\]\>\]:
    \[ApiVersion \<String\[\]\>\]:
    \[SwaggerSpecFolderUri \<String\>\]:
  \[TemplateDeploymentOptionPreflightOption \<String\[\]\>\]:
  \[TemplateDeploymentOptionPreflightSupported \<Boolean?\>\]:
  \[ThrottlingRule \<IThrottlingRule\[\]\>\]:
    Action \<String\>:
    Metric \<IThrottlingMetric\[\]\>:
      Limit \<Int64\>:
      Type \<String\>:
      \[Interval \<TimeSpan?\>\]:
    \[RequiredFeature \<String\[\]\>\]:

## RELATED LINKS

[https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubcustomrollout](https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubcustomrollout)

