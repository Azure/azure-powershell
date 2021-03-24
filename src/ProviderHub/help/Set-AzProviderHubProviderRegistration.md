---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubproviderregistration
schema: 2.0.0
---

# Set-AzProviderHubProviderRegistration

## SYNOPSIS
Creates or updates the provider registration.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String>]
 [-Capability <IResourceProviderCapabilities[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-ManagementIncidentContactEmail <String>] [-ManagementIncidentRoutingService <String>]
 [-ManagementIncidentRoutingTeam <String>] [-ManagementManifestOwner <String[]>]
 [-ManagementResourceAccessPolicy <String>] [-ManagementResourceAccessRole <IAny[]>]
 [-ManagementSchemaOwner <String[]>] [-ManagementServiceTreeInfo <IServiceTreeInfo[]>] [-Metadata <IAny>]
 [-Namespace <String>] [-ProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderAuthorization <IResourceProviderAuthorization[]>]
 [-ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>] [-ProviderType <String>]
 [-ProviderVersion <String>] [-ProvisioningState <String>] [-RequestHeaderOptionOptInHeader <String>]
 [-RequiredFeature <String[]>] [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]
 [-ThirdPartyProviderAuthorizationManagedByTenantId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzProviderHubProviderRegistration -ProviderNamespace <String> -Property <IProviderRegistration>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the provider registration.

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

### -ManagementIncidentContactEmail
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

### -ManagementIncidentRoutingService
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

### -ManagementIncidentRoutingTeam
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

### -ManagementManifestOwner
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

### -ManagementResourceAccessPolicy
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

### -ManagementResourceAccessRole
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProviderAuthenticationAllowedAudience
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

### -ProviderAuthorization
.
To construct, see NOTES section for PROVIDERAUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

### -ThirdPartyProviderAuthorizationAuthorizationszzz
.
To construct, see NOTES section for THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATIONSZZZ properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CAPABILITY <IResourceProviderCapabilities[]>: .
  - `Effect <String>`: 
  - `QuotaId <String>`: 
  - `[RequiredFeature <String[]>]`: 

MANAGEMENTSERVICETREEINFO <IServiceTreeInfo[]>: .
  - `[ComponentId <String>]`: 
  - `[ServiceId <String>]`: 

PROPERTY <IProviderRegistration>: .
  - `[Capability <IResourceProviderCapabilities[]>]`: 
    - `Effect <String>`: 
    - `QuotaId <String>`: 
    - `[RequiredFeature <String[]>]`: 
  - `[FeatureRuleRequiredFeaturesPolicy <String>]`: 
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
  - `[ProviderType <String>]`: 
  - `[ProviderVersion <String>]`: 
  - `[ProvisioningState <String>]`: 
  - `[RequestHeaderOptionOptInHeader <String>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]`: 
  - `[SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]`: 
    - `Action <String>`: 
    - `State <String>`: 
  - `[TemplateDeploymentOptionPreflightOption <String[]>]`: 
  - `[TemplateDeploymentOptionPreflightSupported <Boolean?>]`: 
  - `[ThirdPartyProviderAuthorizationAuthorizationszzz <ILightHouseAuthorization[]>]`: 
    - `PrincipalId <String>`: 
    - `RoleDefinitionId <String>`: 
  - `[ThirdPartyProviderAuthorizationManagedByTenantId <String>]`: 

PROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  - `[ApplicationId <String>]`: 
  - `[ManagedByRoleDefinitionId <String>]`: 
  - `[RoleDefinitionId <String>]`: 

PROVIDERHUBMETADATAPROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  - `[ApplicationId <String>]`: 
  - `[ManagedByRoleDefinitionId <String>]`: 
  - `[RoleDefinitionId <String>]`: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  - `Action <String>`: 
  - `State <String>`: 

THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATIONSZZZ <ILightHouseAuthorization[]>: .
  - `PrincipalId <String>`: 
  - `RoleDefinitionId <String>`: 

## RELATED LINKS

