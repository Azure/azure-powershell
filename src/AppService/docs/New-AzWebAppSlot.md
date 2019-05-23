---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappslot
schema: 2.0.0
---

# New-AzWebAppSlot

## SYNOPSIS
Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.

## SYNTAX

### Create (Default)
```
New-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-SiteEnvelope <ISite>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 [-ClientAffinityEnabled <Boolean>] [-ClientCertEnabled <Boolean>] [-ClientCertExclusionPath <String>]
 [-CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]
 [-CloningInfoCloneCustomHostName <Boolean>] [-CloningInfoCloneSourceControl <Boolean>]
 [-CloningInfoConfigureLoadBalancing <Boolean>] [-CloningInfoCorrelationId <String>]
 [-CloningInfoHostingEnvironment <String>] [-CloningInfoOverwrite <Boolean>]
 -CloningInfoSourceWebAppId <String> [-CloningInfoTrafficManagerProfileId <String>]
 [-CloningInfoTrafficManagerProfileName <String>] [-ContainerSize <Int32>] [-DailyMemoryTimeQuota <Int32>]
 [-Enabled <Boolean>] [-GeoDistribution <IGeoDistribution[]>] [-HostNameSslState <IHostNameSslState[]>]
 [-HostNamesDisabled <Boolean>] [-HostingEnvironmentProfileId <String>] [-HttpsOnly <Boolean>]
 [-HyperV <Boolean>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>] [-IsXenon <Boolean>]
 [-Kind <String>] -Location <String> [-RedundancyMode <RedundancyMode>] [-Reserved <Boolean>]
 [-ScmSiteAlsoStopped <Boolean>] [-ServerFarmId <String>] [-SiteConfig <ISiteConfig>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebAppSlot -InputObject <IWebSiteIdentity> [-ClientAffinityEnabled <Boolean>]
 [-ClientCertEnabled <Boolean>] [-ClientCertExclusionPath <String>]
 [-CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]
 [-CloningInfoCloneCustomHostName <Boolean>] [-CloningInfoCloneSourceControl <Boolean>]
 [-CloningInfoConfigureLoadBalancing <Boolean>] [-CloningInfoCorrelationId <String>]
 [-CloningInfoHostingEnvironment <String>] [-CloningInfoOverwrite <Boolean>]
 -CloningInfoSourceWebAppId <String> [-CloningInfoTrafficManagerProfileId <String>]
 [-CloningInfoTrafficManagerProfileName <String>] [-ContainerSize <Int32>] [-DailyMemoryTimeQuota <Int32>]
 [-Enabled <Boolean>] [-GeoDistribution <IGeoDistribution[]>] [-HostNameSslState <IHostNameSslState[]>]
 [-HostNamesDisabled <Boolean>] [-HostingEnvironmentProfileId <String>] [-HttpsOnly <Boolean>]
 [-HyperV <Boolean>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>] [-IsXenon <Boolean>]
 [-Kind <String>] -Location <String> [-RedundancyMode <RedundancyMode>] [-Reserved <Boolean>]
 [-ScmSiteAlsoStopped <Boolean>] [-ServerFarmId <String>] [-SiteConfig <ISiteConfig>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebAppSlot -InputObject <IWebSiteIdentity> [-SiteEnvelope <ISite>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ClientAffinityEnabled
\<code\>true\</code\> to enable client affinity; \<code\>false\</code\> to stop sending session affinity cookies, which route client requests in the same session to the same instance.
Default is \<code\>true\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientCertEnabled
\<code\>true\</code\> to enable client certificate authentication (TLS mutual authentication); otherwise, \<code\>false\</code\>.
Default is \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientCertExclusionPath
client certificate authentication comma-separated exclusion paths

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoAppSettingsOverride
Application setting overrides for cloned app.
If specified, these settings override the settings cloned from source app.
Otherwise, application settings from source app are retained.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.ICloningInfoAppSettingsOverrides
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoCloneCustomHostName
\<code\>true\</code\> to clone custom hostnames from source app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoCloneSourceControl
\<code\>true\</code\> to clone source control from source app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoConfigureLoadBalancing
\<code\>true\</code\> to configure load balancing for source and destination app.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoCorrelationId
Correlation ID of cloning operation.
This ID ties multiple cloning operationstogether to use the same snapshot.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoHostingEnvironment
App Service Environment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoOverwrite
\<code\>true\</code\> to overwrite destination app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoSourceWebAppId
ARM resource ID of the source app.
App resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoTrafficManagerProfileId
ARM resource ID of the Traffic Manager profile to use, if it exists.
Traffic Manager resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloningInfoTrafficManagerProfileName
Name of Traffic Manager profile to create.
This is only needed if Traffic Manager profile does not already exist.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerSize
Size of the function container.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -DailyMemoryTimeQuota
Maximum allowed daily memory-time quota (applicable on dynamic apps only).

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -Enabled
\<code\>true\</code\> if the app is enabled; otherwise, \<code\>false\</code\>.
Setting this value to false disables the app (takes the app offline).

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoDistribution
GeoDistributions for this site

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IGeoDistribution[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostingEnvironmentProfileId
Resource ID of the App Service Environment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostNamesDisabled
\<code\>true\</code\> to disable the public hostnames of the app; otherwise, \<code\>false\</code\>.
If \<code\>true\</code\>, the app is only accessible via API management process.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostNameSslState
Hostname SSL states are used to manage the SSL bindings for app's hostnames.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IHostNameSslState[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsOnly
HttpsOnly: configures a web site to accept only https requests.
Issues redirect forhttp requests

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -HyperV
Hyper-V sandbox.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ManagedServiceIdentityType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user assigned identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IManagedServiceIdentityUserAssignedIdentities
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsXenon
Obsolete: Hyper-V sandbox.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource Location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Unique name of the app to create or update.
To create or update a deployment slot, use the {slot} parameter.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedundancyMode
Site redundancy mode

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.RedundancyMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reserved
\<code\>true\</code\> if reserved; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScmSiteAlsoStopped
\<code\>true\</code\> to stop SCM (KUDU) site when the app is stopped; otherwise, \<code\>false\</code\>.
The default is \<code\>false\</code\>.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerFarmId
Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteConfig
Configuration of the app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfig
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteEnvelope
A web app, a mobile app backend, or an API app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISite
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Slot
Name of the deployment slot to create or update.
By default, this API attempts to create or modify the production slot.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IResourceTags
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISite
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappslot](https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappslot)

