---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/update-azproviderhubresourcetyperegistration
schema: 2.0.0
---

# Update-AzProviderHubResourceTypeRegistration

## SYNOPSIS
Update a resource type.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 [-SubscriptionId <String>] [-AllowedUnauthorizedAction <String[]>]
 [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
 [-CheckNameAvailabilitySpecificationEnableDefaultValidation]
 [-CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]
 [-DefaultApiVersion <String>] [-DisallowedActionVerb <String[]>] [-EnableAsyncOperation]
 [-EnableThirdPartyS2S] [-Endpoint <IResourceTypeEndpoint[]>] [-ExtendedLocation <IExtendedLocationOptions[]>]
 [-ExtensionOptionResourceCreationBeginRequest <String[]>]
 [-ExtensionOptionResourceCreationBeginResponse <String[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-IdentityManagementApplicationId <String>] [-IdentityManagementType <String>] [-IsPureProxy]
 [-LinkedAccessCheck <ILinkedAccessCheck[]>] [-LoggingRule <ILoggingRule[]>] [-MarketplaceType <String>]
 [-ProvisioningState <String>] [-Regionality <String>] [-RequestHeaderOptionOptInHeader <String>]
 [-RequiredFeature <String[]>] [-ResourceDeletionPolicy <String>]
 [-ResourceMovePolicyCrossResourceGroupMoveEnabled] [-ResourceMovePolicyCrossSubscriptionMoveEnabled]
 [-ResourceMovePolicyValidationRequired] [-RoutingType <String>] [-ServiceTreeInfo <IServiceTreeInfo[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-SubscriptionStateRule <ISubscriptionStateRule[]>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThrottlingRule <IThrottlingRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityProviderRegistrationExpanded
```
Update-AzProviderHubResourceTypeRegistration -ResourceType <String>
 -ProviderRegistrationInputObject <IProviderHubIdentity> [-AllowedUnauthorizedAction <String[]>]
 [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
 [-CheckNameAvailabilitySpecificationEnableDefaultValidation]
 [-CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]
 [-DefaultApiVersion <String>] [-DisallowedActionVerb <String[]>] [-EnableAsyncOperation]
 [-EnableThirdPartyS2S] [-Endpoint <IResourceTypeEndpoint[]>] [-ExtendedLocation <IExtendedLocationOptions[]>]
 [-ExtensionOptionResourceCreationBeginRequest <String[]>]
 [-ExtensionOptionResourceCreationBeginResponse <String[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-IdentityManagementApplicationId <String>] [-IdentityManagementType <String>] [-IsPureProxy]
 [-LinkedAccessCheck <ILinkedAccessCheck[]>] [-LoggingRule <ILoggingRule[]>] [-MarketplaceType <String>]
 [-ProvisioningState <String>] [-Regionality <String>] [-RequestHeaderOptionOptInHeader <String>]
 [-RequiredFeature <String[]>] [-ResourceDeletionPolicy <String>]
 [-ResourceMovePolicyCrossResourceGroupMoveEnabled] [-ResourceMovePolicyCrossSubscriptionMoveEnabled]
 [-ResourceMovePolicyValidationRequired] [-RoutingType <String>] [-ServiceTreeInfo <IServiceTreeInfo[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-SubscriptionStateRule <ISubscriptionStateRule[]>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThrottlingRule <IThrottlingRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzProviderHubResourceTypeRegistration -InputObject <IProviderHubIdentity>
 [-AllowedUnauthorizedAction <String[]>] [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
 [-CheckNameAvailabilitySpecificationEnableDefaultValidation]
 [-CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]
 [-DefaultApiVersion <String>] [-DisallowedActionVerb <String[]>] [-EnableAsyncOperation]
 [-EnableThirdPartyS2S] [-Endpoint <IResourceTypeEndpoint[]>] [-ExtendedLocation <IExtendedLocationOptions[]>]
 [-ExtensionOptionResourceCreationBeginRequest <String[]>]
 [-ExtensionOptionResourceCreationBeginResponse <String[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-IdentityManagementApplicationId <String>] [-IdentityManagementType <String>] [-IsPureProxy]
 [-LinkedAccessCheck <ILinkedAccessCheck[]>] [-LoggingRule <ILoggingRule[]>] [-MarketplaceType <String>]
 [-ProvisioningState <String>] [-Regionality <String>] [-RequestHeaderOptionOptInHeader <String>]
 [-RequiredFeature <String[]>] [-ResourceDeletionPolicy <String>]
 [-ResourceMovePolicyCrossResourceGroupMoveEnabled] [-ResourceMovePolicyCrossSubscriptionMoveEnabled]
 [-ResourceMovePolicyValidationRequired] [-RoutingType <String>] [-ServiceTreeInfo <IServiceTreeInfo[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-SubscriptionStateRule <ISubscriptionStateRule[]>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThrottlingRule <IThrottlingRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a resource type.

## EXAMPLES

### Example 1: Update a resource type registration.
```powershell
Update-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }
```

```output
Name                  Type
----                  ----
testResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Update a resource type registration.

## PARAMETERS

### -AllowedUnauthorizedAction
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAuthorizationActionMapping[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### -DisallowedActionVerb
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

### -EnableAsyncOperation
.

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

### -EnableThirdPartyS2S
.

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

### -Endpoint
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocation
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IExtendedLocationOptions[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionOptionResourceCreationBeginRequest
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

### -ExtensionOptionResourceCreationBeginResponse
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

### -FeatureRuleRequiredFeaturesPolicy
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

### -IdentityManagementApplicationId
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

### -IdentityManagementType
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsPureProxy
.

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

### -LinkedAccessCheck
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILinkedAccessCheck[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoggingRule
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILoggingRule[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### -ProviderRegistrationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: UpdateViaIdentityProviderRegistrationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Regionality
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

### -RequestHeaderOptionOptInHeader
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

### -RequiredFeature
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

### -ResourceDeletionPolicy
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

### -ResourceMovePolicyCrossResourceGroupMoveEnabled
.

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

### -ResourceMovePolicyCrossSubscriptionMoveEnabled
.

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

### -ResourceMovePolicyValidationRequired
.

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

### -ResourceType
The resource type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTreeInfo
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IServiceTreeInfo[]
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateOverrideAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionStateRule
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SwaggerSpecification
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISwaggerSpecification[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThrottlingRule
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IThrottlingRule[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeRegistration

## NOTES

## RELATED LINKS
