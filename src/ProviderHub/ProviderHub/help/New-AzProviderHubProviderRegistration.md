---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubproviderregistration
schema: 2.0.0
---

# New-AzProviderHubProviderRegistration

## SYNOPSIS
Create the provider registration.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String>]
 [-Capability <IResourceProviderCapabilities[]>] [-FeatureRuleRequiredFeaturesPolicy <String>]
 [-ManagementIncidentContactEmail <String>] [-ManagementIncidentRoutingService <String>]
 [-ManagementIncidentRoutingTeam <String>] [-ManagementManifestOwner <String[]>]
 [-ManagementResourceAccessPolicy <String>] [-ManagementResourceAccessRole <IAny[]>]
 [-ManagementSchemaOwner <String[]>] [-ManagementServiceTreeInfo <IServiceTreeInfo[]>] [-Metadata <IAny>]
 [-Namespace <String>] [-ProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderAuthorization <IResourceProviderAuthorization[]>]
 [-ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]
 [-ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]
 [-ProviderHubMetadataThirdPartyProviderAuthorization <ILightHouseAuthorization[]>]
 [-ProviderHubMetadataThirdPartyProviderAuthorizationManagedByTenantId <String>] [-ProviderType <String>]
 [-ProviderVersion <String>] [-ProvisioningState <String>] [-RequestHeaderOptionOptInHeader <String>]
 [-RequiredFeature <String[]>] [-SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan>]
 [-SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]
 [-TemplateDeploymentOptionPreflightOption <String[]>] [-TemplateDeploymentOptionPreflightSupported]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create the provider registration.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderCapabilities[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -ManagementIncidentContactEmail
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementServiceTreeInfo
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IServiceTreeInfo[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
Anything

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### -ProviderAuthenticationAllowedAudience
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderAuthorization
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderHubMetadataProviderAuthorization
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceProviderAuthorization[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderHubMetadataThirdPartyProviderAuthorization
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ILightHouseAuthorization[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderHubMetadataThirdPartyProviderAuthorizationManagedByTenantId
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderRegistration

## NOTES

## RELATED LINKS
