---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubproviderregistration
schema: 2.0.0
---

# New-AzProviderHubProviderRegistration

## SYNOPSIS
Creates or updates the provider registration.

## SYNTAX

```
New-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String>]
 [-Capability <IResourceProviderCapabilities[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-ManagementIncidentContactEmail <String>] [-ManagementIncidentRoutingService <String>]
 [-ManagementIncidentRoutingTeam <String>] [-ManagementManifestOwner <String[]>]
 [-ManagementResourceAccessPolicy <ResourceAccessPolicy>] [-ManagementResourceAccessRole <IAny[]>]
 [-ManagementSchemaOwner <String[]>] [-ManagementServiceTreeInfo <IServiceTreeInfo[]>] [-Metadata <IAny>]
 [-Namespace <String>] [-ProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderAuthorization <IResourceProviderAuthorization[]>]
 [-ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]
 [-ProviderType <ResourceProviderType>] [-ProviderVersion <String>] [-ProvisioningState <ProvisioningState>]
 [-RequestHeaderOptionOptInHeader <OptInHeaderType>] [-RequiredFeature <String[]>]
 [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-TemplateDeploymentOptionPreflightOption <PreflightOption[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThirdPartyProviderAuthorizationAuthorization <ILightHouseAuthorization[]>]
 [-ThirdPartyProviderAuthorizationManagedByTenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the provider registration.

## EXAMPLES

### Example 1: Create/Update a provider registration.
```powershell
New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Internal" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}
```

```output
Name                Type
----                ----
Microsoft.Contoso   Microsoft.ProviderHub/providerRegistrations
```

Create/Update a provider registration.

### Example 2: Create/Update a provider registration.
```powershell
New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Hidden" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}
```

```output
Name                Type
----                ----
Microsoft.Contoso   Microsoft.ProviderHub/providerRegistrations
```

Create/Update a provider registration.

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

### -Capability
.
To construct, see NOTES section for CAPABILITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[]
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

### -ManagementIncidentContactEmail
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

### -ManagementIncidentRoutingService
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

### -ManagementIncidentRoutingTeam
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

### -ManagementManifestOwner
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

### -ManagementResourceAccessPolicy
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceAccessPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementResourceAccessRole
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementSchemaOwner
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

### -ManagementServiceTreeInfo
.
To construct, see NOTES section for MANAGEMENTSERVICETREEINFO properties and create a hash table.

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

### -Metadata
Any object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
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

### -ProviderAuthenticationAllowedAudience
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

### -ProviderAuthorization
.
To construct, see NOTES section for PROVIDERAUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderHubMetadataProviderAuthenticationAllowedAudience
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

### -ProviderHubMetadataProviderAuthorization
.
To construct, see NOTES section for PROVIDERHUBMETADATAPROVIDERAUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]
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

### -ProviderType
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderVersion
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

### -ThirdPartyProviderAuthorizationAuthorization
.
To construct, see NOTES section for THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThirdPartyProviderAuthorizationManagedByTenantId
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration

## NOTES

## RELATED LINKS
