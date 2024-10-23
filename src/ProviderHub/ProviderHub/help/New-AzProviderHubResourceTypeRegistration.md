---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubresourcetyperegistration
schema: 2.0.0
---

# New-AzProviderHubResourceTypeRegistration

## SYNOPSIS
Creates or updates a resource type.

## SYNTAX

```
New-AzProviderHubResourceTypeRegistration -ProviderNamespace <String> -ResourceType <String>
 [-SubscriptionId <String>] [-AllowedUnauthorizedAction <String[]>]
 [-AuthorizationActionMapping <IAuthorizationActionMapping[]>]
 [-CheckNameAvailabilitySpecificationEnableDefaultValidation]
 [-CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]
 [-DefaultApiVersion <String>] [-DisallowedActionVerb <String[]>] [-EnableAsyncOperation]
 [-EnableThirdPartyS2S] [-Endpoint <IResourceTypeEndpoint[]>] [-ExtendedLocation <IExtendedLocationOptions[]>]
 [-FeatureRuleRequiredFeaturesPolicy <String>] [-IdentityManagementApplicationId <String>]
 [-IdentityManagementType <IdentityManagementTypes>] [-IsPureProxy] [-LinkedAccessCheck <ILinkedAccessCheck[]>]
 [-LoggingRule <ILoggingRule[]>] [-MarketplaceType <String>] [-ProvisioningState <ProvisioningState>]
 [-Regionality <Regionality>] [-RequestHeaderOptionOptInHeader <OptInHeaderType>] [-RequiredFeature <String[]>]
 [-ResourceCreationBeginRequest <ExtensionOptionType[]>]
 [-ResourceCreationBeginResponse <ExtensionOptionType[]>] [-ResourceDeletionPolicy <ResourceDeletionPolicy>]
 [-ResourceMovePolicyCrossResourceGroupMoveEnabled] [-ResourceMovePolicyCrossSubscriptionMoveEnabled]
 [-ResourceMovePolicyValidationRequired] [-RoutingType <RoutingType>] [-ServiceTreeInfo <IServiceTreeInfo[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-SubscriptionStateRule <ISubscriptionStateRule[]>] [-SwaggerSpecification <ISwaggerSpecification[]>]
 [-TemplateDeploymentOptionPreflightOption <PreflightOption[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThrottlingRule <IThrottlingRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
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
To construct, see NOTES section for AUTHORIZATIONACTIONMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]
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
To construct, see NOTES section for ENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[]
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
To construct, see NOTES section for EXTENDEDLOCATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes
Parameter Sets: (All)
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
To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]
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
To construct, see NOTES section for LOGGINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType
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

### -ResourceCreationBeginRequest
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType
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
To construct, see NOTES section for SERVICETREEINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]
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
To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[]
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
To construct, see NOTES section for SUBSCRIPTIONSTATERULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]
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
To construct, see NOTES section for SWAGGERSPECIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[]
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
To construct, see NOTES section for THROTTLINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration

## NOTES

## RELATED LINKS
