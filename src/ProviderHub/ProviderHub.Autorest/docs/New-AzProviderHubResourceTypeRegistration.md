---
external help file:
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubresourcetyperegistration
schema: 2.0.0
---

# New-AzProviderHubResourceTypeRegistration

## SYNOPSIS
Creates or updates a resource type.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
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

### CreateViaIdentityProviderRegistrationExpanded
```
New-AzProviderHubResourceTypeRegistration -ProviderNamespace <String>
 -ProviderRegistrationInputObject <IProviderHubIdentity> -ResourceType <String> [-SubscriptionId <String>]
 [-AllowedUnauthorizedAction <String[]>] [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
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

### CreateViaJsonFilePath
```
New-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-ResourceDeletionPolicy <String>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 -JsonString <String> [-SubscriptionId <String>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-ResourceDeletionPolicy <String>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a resource type.

## EXAMPLES

### Example 1: Create/Update a resource type registration.
```powershell
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation
```

```output
Name                  Type
----                  ----
testResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Create/Update a resource type registration.

### Example 2: Create/Update a nested resource type registration.
```powershell
New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -RoutingType "Default" -Regionality "Global" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = ""; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" }
```

```output
Name                                     Type
----                                     ----
testResourceType/nestedResourceType      Microsoft.ProviderHub/providerRegistrations/resourceTypeRegistrations
```

Create/Update a nested resource type registration.

## PARAMETERS

### -AllowedUnauthorizedAction
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAuthorizationActionMapping[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeEndpoint[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IExtendedLocationOptions[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkedAccessCheck
.
To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILinkedAccessCheck[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILoggingRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: (All)
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
Parameter Sets: CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IServiceTreeInfo[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateOverrideAction[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISubscriptionStateRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IThrottlingRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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

