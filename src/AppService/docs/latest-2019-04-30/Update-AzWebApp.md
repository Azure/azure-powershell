---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/update-azwebapp
schema: 2.0.0
---

# Update-AzWebApp

## SYNOPSIS
Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-ClientAffinityEnabled]
 [-ClientCertEnabled] [-ClientCertExclusionPath <String>] [-CloningInfoAppSettingsOverride <Hashtable>]
 [-CloningInfoCloneCustomHostName] [-CloningInfoCloneSourceControl] [-CloningInfoConfigureLoadBalancing]
 [-CloningInfoCorrelationId <String>] [-CloningInfoHostingEnvironment <String>] [-CloningInfoOverwrite]
 [-CloningInfoSourceWebAppId <String>] [-CloningInfoSourceWebAppLocation <String>]
 [-CloningInfoTrafficManagerProfileId <String>] [-CloningInfoTrafficManagerProfileName <String>]
 [-ContainerSize <Int32>] [-DailyMemoryTimeQuota <Int32>] [-Enabled] [-GeoDistribution <IGeoDistribution[]>]
 [-HostingEnvironmentProfileId <String>] [-HostNamesDisabled] [-HostNameSslState <IHostNameSslState[]>]
 [-HttpsOnly] [-HyperV] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IsXenon] [-Kind <String>] [-RedundancyMode <RedundancyMode>]
 [-Reserved] [-ScmSiteAlsoStopped] [-ServerFarmId <String>] [-SiteConfig <ISiteConfig>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzWebApp -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -SiteEnvelope <ISitePatchResource> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzWebApp -InputObject <IAppServiceIdentity> -SiteEnvelope <ISitePatchResource>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWebApp -InputObject <IAppServiceIdentity> [-ClientAffinityEnabled] [-ClientCertEnabled]
 [-ClientCertExclusionPath <String>] [-CloningInfoAppSettingsOverride <Hashtable>]
 [-CloningInfoCloneCustomHostName] [-CloningInfoCloneSourceControl] [-CloningInfoConfigureLoadBalancing]
 [-CloningInfoCorrelationId <String>] [-CloningInfoHostingEnvironment <String>] [-CloningInfoOverwrite]
 [-CloningInfoSourceWebAppId <String>] [-CloningInfoSourceWebAppLocation <String>]
 [-CloningInfoTrafficManagerProfileId <String>] [-CloningInfoTrafficManagerProfileName <String>]
 [-ContainerSize <Int32>] [-DailyMemoryTimeQuota <Int32>] [-Enabled] [-GeoDistribution <IGeoDistribution[]>]
 [-HostingEnvironmentProfileId <String>] [-HostNamesDisabled] [-HostNameSslState <IHostNameSslState[]>]
 [-HttpsOnly] [-HyperV] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IsXenon] [-Kind <String>] [-RedundancyMode <RedundancyMode>]
 [-Reserved] [-ScmSiteAlsoStopped] [-ServerFarmId <String>] [-SiteConfig <ISiteConfig>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new web, mobile, or API app in an existing resource group, or updates an existing app.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ClientAffinityEnabled
\<code\>true\</code\> to enable client affinity; \<code\>false\</code\> to stop sending session affinity cookies, which route client requests in the same session to the same instance.
Default is \<code\>true\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClientCertEnabled
\<code\>true\</code\> to enable client certificate authentication (TLS mutual authentication); otherwise, \<code\>false\</code\>.
Default is \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClientCertExclusionPath
client certificate authentication comma-separated exclusion paths

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoAppSettingsOverride
Application setting overrides for cloned app.
If specified, these settings override the settings cloned from source app.
Otherwise, application settings from source app are retained.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoCloneCustomHostName
\<code\>true\</code\> to clone custom hostnames from source app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoCloneSourceControl
\<code\>true\</code\> to clone source control from source app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoConfigureLoadBalancing
\<code\>true\</code\> to configure load balancing for source and destination app.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoCorrelationId
Correlation ID of cloning operation.
This ID ties multiple cloning operationstogether to use the same snapshot.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoHostingEnvironment
App Service Environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoOverwrite
\<code\>true\</code\> to overwrite destination app; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoSourceWebAppId
ARM resource ID of the source app.
App resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoSourceWebAppLocation
Location of source app ex: West US or North Europe

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoTrafficManagerProfileId
ARM resource ID of the Traffic Manager profile to use, if it exists.
Traffic Manager resource ID is of the form /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CloningInfoTrafficManagerProfileName
Name of Traffic Manager profile to create.
This is only needed if Traffic Manager profile does not already exist.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContainerSize
Size of the function container.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DailyMemoryTimeQuota
Maximum allowed daily memory-time quota (applicable on dynamic apps only).

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Enabled
\<code\>true\</code\> if the app is enabled; otherwise, \<code\>false\</code\>.
Setting this value to false disables the app (takes the app offline).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GeoDistribution
GeoDistributions for this site
To construct, see NOTES section for GEODISTRIBUTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IGeoDistribution[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostingEnvironmentProfileId
Resource ID of the App Service Environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostNamesDisabled
\<code\>true\</code\> to disable the public hostnames of the app; otherwise, \<code\>false\</code\>.
If \<code\>true\</code\>, the app is only accessible via API management process.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostNameSslState
Hostname SSL states are used to manage the SSL bindings for app's hostnames.
To construct, see NOTES section for HOSTNAMESSLSTATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160301.IHostNameSslState[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpsOnly
HttpsOnly: configures a web site to accept only https requests.
Issues redirect forhttp requests

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HyperV
Hyper-V sandbox.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityType
Type of managed service identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.ManagedServiceIdentityType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentityUserAssignedIdentity
The list of user assigned identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IsXenon
Obsolete: Hyper-V sandbox.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Unique name of the app to create or update.
To create or update a deployment slot, use the {slot} parameter.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RedundancyMode
Site redundancy mode

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.RedundancyMode
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Reserved
\<code\>true\</code\> if reserved; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmSiteAlsoStopped
\<code\>true\</code\> to stop SCM (KUDU) site when the app is stopped; otherwise, \<code\>false\</code\>.
The default is \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServerFarmId
Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteConfig
Configuration of the app.
To construct, see NOTES section for SITECONFIG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteConfig
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteEnvelope
ARM resource for a site.
To construct, see NOTES section for SITEENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISitePatchResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISitePatchResource

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISite

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### GEODISTRIBUTION <IGeoDistribution[]>: GeoDistributions for this site
  - `[Location <String>]`: Location.
  - `[NumberOfWorker <Int32?>]`: NumberOfWorkers.

#### HOSTNAMESSLSTATE <IHostNameSslState[]>: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
  - `[HostType <HostType?>]`: Indicates whether the hostname is a standard or repository hostname.
  - `[Name <String>]`: Hostname.
  - `[SslState <SslState?>]`: SSL type.
  - `[Thumbprint <String>]`: SSL certificate thumbprint.
  - `[ToUpdate <Boolean?>]`: Set to <code>true</code> to update existing hostname.
  - `[VirtualIP <String>]`: Virtual IP address assigned to the hostname if IP based SSL is enabled.

#### INPUTOBJECT <IAppServiceIdentity>: Identity Parameter
  - `[AnalysisName <String>]`: Analysis Name
  - `[ApiName <String>]`: The managed API name.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[CertificateOrderName <String>]`: Name of the certificate order.
  - `[ConnectionName <String>]`: The connection name.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Only the 'primary' gateway is supported.
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Resource identity path
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: ID of web app instance.
  - `[Location <String>]`: 
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: Name of the Service Bus namespace.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[RelayName <String>]`: Name of the Service Bus relay.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Name of web app slot. If not specified then will default to production slot.
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[ThreadId <String>]`: TID.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the Virtual Network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

#### SITECONFIG <ISiteConfig>: Configuration of the app.
  - `ActionType <AutoHealActionType>`: ActionType - predefined action to be taken
  - `IsPushEnabled <Boolean>`: Gets or sets a flag indicating whether the Push endpoint is enabled.
  - `[ActionMinProcessExecutionTime <String>]`: MinProcessExecutionTime - minimum time the process must execute                     before taking the action
  - `[AlwaysOn <Boolean?>]`: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
  - `[ApiDefinitionUrl <String>]`: The URL of the API definition.
  - `[AppCommandLine <String>]`: App command line to launch.
  - `[AppSetting <INameValuePair[]>]`: Application settings.
    - `[Name <String>]`: Pair name.
    - `[Value <String>]`: Pair value.
  - `[AutoHealEnabled <Boolean?>]`: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
  - `[AutoSwapSlotName <String>]`: Auto-swap slot name.
  - `[AzureStorageAccount <ISiteConfigAzureStorageAccounts>]`: User-provided Azure storage accounts.
    - `[(Any) <IAzureStorageInfoValue>]`: This indicates any property can be added to this object.
  - `[ConnectionString <IConnStringInfo[]>]`: Connection strings.
    - `[ConnectionString <String>]`: Connection string value.
    - `[Name <String>]`: Name of connection string.
    - `[Type <ConnectionStringType?>]`: Type of database.
  - `[CorAllowedOrigin <String[]>]`: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
  - `[CorSupportCredentials <Boolean?>]`: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
  - `[CustomActionExe <String>]`: Executable to be run.
  - `[CustomActionParameter <String>]`: Parameters for the executable.
  - `[DefaultDocument <String[]>]`: Default documents.
  - `[DetailedErrorLoggingEnabled <Boolean?>]`: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
  - `[DocumentRoot <String>]`: Document root.
  - `[DynamicTagsJson <String>]`: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
  - `[ExperimentRampUpRule <IRampUpRule[]>]`: List of ramp-up rules.
    - `[ActionHostName <String>]`: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
    - `[ChangeDecisionCallbackUrl <String>]`: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
    - `[ChangeIntervalInMinute <Int32?>]`: Specifies interval in minutes to reevaluate ReroutePercentage.
    - `[ChangeStep <Double?>]`: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches         <code>MinReroutePercentage</code> or <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.         Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
    - `[MaxReroutePercentage <Double?>]`: Specifies upper boundary below which ReroutePercentage will stay.
    - `[MinReroutePercentage <Double?>]`: Specifies lower boundary above which ReroutePercentage will stay.
    - `[Name <String>]`: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
    - `[ReroutePercentage <Double?>]`: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
  - `[FtpsState <FtpsState?>]`: State of FTP / FTPS service
  - `[HandlerMapping <IHandlerMapping[]>]`: Handler mappings.
    - `[Argument <String>]`: Command-line arguments to be passed to the script processor.
    - `[Extension <String>]`: Requests with this extension will be handled using the specified FastCGI application.
    - `[ScriptProcessor <String>]`: The absolute path to the FastCGI application.
  - `[Http20Enabled <Boolean?>]`: Http20Enabled: configures a web site to allow clients to connect over http2.0
  - `[HttpLoggingEnabled <Boolean?>]`: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
  - `[IPSecurityRestriction <IIPSecurityRestriction[]>]`: IP security restrictions for main.
    - `IPAddress <String>`: IP address the security restriction is valid for.
    - `[SubnetMask <String>]`: Subnet mask for the range of IP addresses the restriction is valid for.
    - `[Action <String>]`: Allow or Deny access for this IP range.
    - `[Description <String>]`: IP restriction rule description.
    - `[Name <String>]`: IP restriction rule name.
    - `[Priority <Int32?>]`: Priority of IP restriction rule.
    - `[SubnetTrafficTag <Int32?>]`: (internal) Subnet traffic tag
    - `[Tag <IPFilterTag?>]`: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
    - `[VnetSubnetResourceId <String>]`: Virtual network resource id
    - `[VnetTrafficTag <Int32?>]`: (internal) Vnet traffic tag
  - `[JavaContainer <String>]`: Java container.
  - `[JavaContainerVersion <String>]`: Java container version.
  - `[JavaVersion <String>]`: Java version.
  - `[LimitMaxDiskSizeInMb <Int64?>]`: Maximum allowed disk size usage in MB.
  - `[LimitMaxMemoryInMb <Int64?>]`: Maximum allowed memory usage in MB.
  - `[LimitMaxPercentageCpu <Double?>]`: Maximum allowed CPU usage percentage.
  - `[LinuxFxVersion <String>]`: Linux App Framework and version
  - `[LoadBalancing <SiteLoadBalancing?>]`: Site load balancing.
  - `[LocalMySqlEnabled <Boolean?>]`: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
  - `[LogsDirectorySizeLimit <Int32?>]`: HTTP logs directory size limit.
  - `[MachineKeyDecryption <String>]`: Algorithm used for decryption.
  - `[MachineKeyDecryptionKey <String>]`: Decryption key.
  - `[MachineKeyValidation <String>]`: MachineKey validation.
  - `[MachineKeyValidationKey <String>]`: Validation key.
  - `[ManagedPipelineMode <ManagedPipelineMode?>]`: Managed pipeline mode.
  - `[ManagedServiceIdentityId <Int32?>]`: Managed Service Identity Id
  - `[MinTlsVersion <SupportedTlsVersions?>]`: MinTlsVersion: configures the minimum version of TLS required for SSL requests
  - `[NetFrameworkVersion <String>]`: .NET Framework version.
  - `[NodeVersion <String>]`: Version of Node.js.
  - `[NumberOfWorker <Int32?>]`: Number of workers.
  - `[PhpVersion <String>]`: Version of PHP.
  - `[PublishingUsername <String>]`: Publishing user name.
  - `[PushKind <String>]`: Kind of resource.
  - `[PythonVersion <String>]`: Version of Python.
  - `[RemoteDebuggingEnabled <Boolean?>]`: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
  - `[RemoteDebuggingVersion <String>]`: Remote debugging version.
  - `[RequestCount <Int32?>]`: Request Count.
  - `[RequestTimeInterval <String>]`: Time interval.
  - `[RequestTracingEnabled <Boolean?>]`: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
  - `[RequestTracingExpirationTime <DateTime?>]`: Request tracing expiration time.
  - `[ReservedInstanceCount <Int32?>]`: Number of reserved instances.         This setting only applies to the Consumption Plan
  - `[ScmIPSecurityRestriction <IIPSecurityRestriction[]>]`: IP security restrictions for scm.
  - `[ScmIPSecurityRestrictionsUseMain <Boolean?>]`: IP security restrictions for scm to use main.
  - `[ScmType <ScmType?>]`: SCM type.
  - `[SlowRequestCount <Int32?>]`: Request Count.
  - `[SlowRequestTimeInterval <String>]`: Time interval.
  - `[SlowRequestTimeTaken <String>]`: Time taken.
  - `[TagWhitelistJson <String>]`: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
  - `[TagsRequiringAuth <String>]`: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
  - `[TracingOption <String>]`: Tracing options.
  - `[TriggerPrivateBytesInKb <Int32?>]`: A rule based on private bytes.
  - `[TriggerStatusCode <IStatusCodesBasedTrigger[]>]`: A rule based on status codes.
    - `[Count <Int32?>]`: Request Count.
    - `[Status <Int32?>]`: HTTP status code.
    - `[SubStatus <Int32?>]`: Request Sub Status.
    - `[TimeInterval <String>]`: Time interval.
    - `[Win32Status <Int32?>]`: Win32 error code.
  - `[Use32BitWorkerProcess <Boolean?>]`: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
  - `[VirtualApplication <IVirtualApplication[]>]`: Virtual applications.
    - `[PhysicalPath <String>]`: Physical path.
    - `[PreloadEnabled <Boolean?>]`: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
    - `[VirtualDirectory <IVirtualDirectory[]>]`: Virtual directories for virtual application.
      - `[PhysicalPath <String>]`: Physical path.
      - `[VirtualPath <String>]`: Path to virtual application.
    - `[VirtualPath <String>]`: Virtual path.
  - `[VnetName <String>]`: Virtual Network name.
  - `[WebSocketsEnabled <Boolean?>]`: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
  - `[WindowsFxVersion <String>]`: Xenon App Framework and version
  - `[XManagedServiceIdentityId <Int32?>]`: Explicit Managed Service Identity Id

#### SITEENVELOPE <ISitePatchResource>: ARM resource for a site.
  - `CloningInfoSourceWebAppId <String>`: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  - `[Kind <String>]`: Kind of resource.
  - `[ClientAffinityEnabled <Boolean?>]`: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  - `[ClientCertEnabled <Boolean?>]`: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  - `[ClientCertExclusionPath <String>]`: client certificate authentication comma-separated exclusion paths
  - `[CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]`: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[CloningInfoCloneCustomHostName <Boolean?>]`: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  - `[CloningInfoCloneSourceControl <Boolean?>]`: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  - `[CloningInfoConfigureLoadBalancing <Boolean?>]`: <code>true</code> to configure load balancing for source and destination app.
  - `[CloningInfoCorrelationId <String>]`: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  - `[CloningInfoHostingEnvironment <String>]`: App Service Environment.
  - `[CloningInfoOverwrite <Boolean?>]`: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  - `[CloningInfoSourceWebAppLocation <String>]`: Location of source app ex: West US or North Europe
  - `[CloningInfoTrafficManagerProfileId <String>]`: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  - `[CloningInfoTrafficManagerProfileName <String>]`: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  - `[ContainerSize <Int32?>]`: Size of the function container.
  - `[DailyMemoryTimeQuota <Int32?>]`: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  - `[Enabled <Boolean?>]`: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  - `[GeoDistribution <IGeoDistribution[]>]`: GeoDistributions for this site
    - `[Location <String>]`: Location.
    - `[NumberOfWorker <Int32?>]`: NumberOfWorkers.
  - `[HostNameSslState <IHostNameSslState[]>]`: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    - `[HostType <HostType?>]`: Indicates whether the hostname is a standard or repository hostname.
    - `[Name <String>]`: Hostname.
    - `[SslState <SslState?>]`: SSL type.
    - `[Thumbprint <String>]`: SSL certificate thumbprint.
    - `[ToUpdate <Boolean?>]`: Set to <code>true</code> to update existing hostname.
    - `[VirtualIP <String>]`: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  - `[HostNamesDisabled <Boolean?>]`: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  - `[HostingEnvironmentProfileId <String>]`: Resource ID of the App Service Environment.
  - `[HttpsOnly <Boolean?>]`: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  - `[HyperV <Boolean?>]`: Hyper-V sandbox.
  - `[IdentityType <ManagedServiceIdentityType?>]`: Type of managed service identity.
  - `[IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]`: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    - `[(Any) <IComponentsSchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]`: This indicates any property can be added to this object.
  - `[IsXenon <Boolean?>]`: Obsolete: Hyper-V sandbox.
  - `[RedundancyMode <RedundancyMode?>]`: Site redundancy mode
  - `[Reserved <Boolean?>]`: <code>true</code> if reserved; otherwise, <code>false</code>.
  - `[ScmSiteAlsoStopped <Boolean?>]`: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  - `[ServerFarmId <String>]`: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
  - `[SiteConfig <ISiteConfig>]`: Configuration of the app.
    - `ActionType <AutoHealActionType>`: ActionType - predefined action to be taken
    - `IsPushEnabled <Boolean>`: Gets or sets a flag indicating whether the Push endpoint is enabled.
    - `[ActionMinProcessExecutionTime <String>]`: MinProcessExecutionTime - minimum time the process must execute                     before taking the action
    - `[AlwaysOn <Boolean?>]`: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    - `[ApiDefinitionUrl <String>]`: The URL of the API definition.
    - `[AppCommandLine <String>]`: App command line to launch.
    - `[AppSetting <INameValuePair[]>]`: Application settings.
      - `[Name <String>]`: Pair name.
      - `[Value <String>]`: Pair value.
    - `[AutoHealEnabled <Boolean?>]`: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    - `[AutoSwapSlotName <String>]`: Auto-swap slot name.
    - `[AzureStorageAccount <ISiteConfigAzureStorageAccounts>]`: User-provided Azure storage accounts.
      - `[(Any) <IAzureStorageInfoValue>]`: This indicates any property can be added to this object.
    - `[ConnectionString <IConnStringInfo[]>]`: Connection strings.
      - `[ConnectionString <String>]`: Connection string value.
      - `[Name <String>]`: Name of connection string.
      - `[Type <ConnectionStringType?>]`: Type of database.
    - `[CorAllowedOrigin <String[]>]`: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    - `[CorSupportCredentials <Boolean?>]`: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    - `[CustomActionExe <String>]`: Executable to be run.
    - `[CustomActionParameter <String>]`: Parameters for the executable.
    - `[DefaultDocument <String[]>]`: Default documents.
    - `[DetailedErrorLoggingEnabled <Boolean?>]`: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    - `[DocumentRoot <String>]`: Document root.
    - `[DynamicTagsJson <String>]`: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    - `[ExperimentRampUpRule <IRampUpRule[]>]`: List of ramp-up rules.
      - `[ActionHostName <String>]`: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      - `[ChangeDecisionCallbackUrl <String>]`: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      - `[ChangeIntervalInMinute <Int32?>]`: Specifies interval in minutes to reevaluate ReroutePercentage.
      - `[ChangeStep <Double?>]`: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches         <code>MinReroutePercentage</code> or <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.         Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      - `[MaxReroutePercentage <Double?>]`: Specifies upper boundary below which ReroutePercentage will stay.
      - `[MinReroutePercentage <Double?>]`: Specifies lower boundary above which ReroutePercentage will stay.
      - `[Name <String>]`: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      - `[ReroutePercentage <Double?>]`: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    - `[FtpsState <FtpsState?>]`: State of FTP / FTPS service
    - `[HandlerMapping <IHandlerMapping[]>]`: Handler mappings.
      - `[Argument <String>]`: Command-line arguments to be passed to the script processor.
      - `[Extension <String>]`: Requests with this extension will be handled using the specified FastCGI application.
      - `[ScriptProcessor <String>]`: The absolute path to the FastCGI application.
    - `[Http20Enabled <Boolean?>]`: Http20Enabled: configures a web site to allow clients to connect over http2.0
    - `[HttpLoggingEnabled <Boolean?>]`: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    - `[IPSecurityRestriction <IIPSecurityRestriction[]>]`: IP security restrictions for main.
      - `IPAddress <String>`: IP address the security restriction is valid for.
      - `[SubnetMask <String>]`: Subnet mask for the range of IP addresses the restriction is valid for.
      - `[Action <String>]`: Allow or Deny access for this IP range.
      - `[Description <String>]`: IP restriction rule description.
      - `[Name <String>]`: IP restriction rule name.
      - `[Priority <Int32?>]`: Priority of IP restriction rule.
      - `[SubnetTrafficTag <Int32?>]`: (internal) Subnet traffic tag
      - `[Tag <IPFilterTag?>]`: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      - `[VnetSubnetResourceId <String>]`: Virtual network resource id
      - `[VnetTrafficTag <Int32?>]`: (internal) Vnet traffic tag
    - `[JavaContainer <String>]`: Java container.
    - `[JavaContainerVersion <String>]`: Java container version.
    - `[JavaVersion <String>]`: Java version.
    - `[LimitMaxDiskSizeInMb <Int64?>]`: Maximum allowed disk size usage in MB.
    - `[LimitMaxMemoryInMb <Int64?>]`: Maximum allowed memory usage in MB.
    - `[LimitMaxPercentageCpu <Double?>]`: Maximum allowed CPU usage percentage.
    - `[LinuxFxVersion <String>]`: Linux App Framework and version
    - `[LoadBalancing <SiteLoadBalancing?>]`: Site load balancing.
    - `[LocalMySqlEnabled <Boolean?>]`: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    - `[LogsDirectorySizeLimit <Int32?>]`: HTTP logs directory size limit.
    - `[MachineKeyDecryption <String>]`: Algorithm used for decryption.
    - `[MachineKeyDecryptionKey <String>]`: Decryption key.
    - `[MachineKeyValidation <String>]`: MachineKey validation.
    - `[MachineKeyValidationKey <String>]`: Validation key.
    - `[ManagedPipelineMode <ManagedPipelineMode?>]`: Managed pipeline mode.
    - `[ManagedServiceIdentityId <Int32?>]`: Managed Service Identity Id
    - `[MinTlsVersion <SupportedTlsVersions?>]`: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    - `[NetFrameworkVersion <String>]`: .NET Framework version.
    - `[NodeVersion <String>]`: Version of Node.js.
    - `[NumberOfWorker <Int32?>]`: Number of workers.
    - `[PhpVersion <String>]`: Version of PHP.
    - `[PublishingUsername <String>]`: Publishing user name.
    - `[PushKind <String>]`: Kind of resource.
    - `[PythonVersion <String>]`: Version of Python.
    - `[RemoteDebuggingEnabled <Boolean?>]`: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    - `[RemoteDebuggingVersion <String>]`: Remote debugging version.
    - `[RequestCount <Int32?>]`: Request Count.
    - `[RequestTimeInterval <String>]`: Time interval.
    - `[RequestTracingEnabled <Boolean?>]`: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    - `[RequestTracingExpirationTime <DateTime?>]`: Request tracing expiration time.
    - `[ReservedInstanceCount <Int32?>]`: Number of reserved instances.         This setting only applies to the Consumption Plan
    - `[ScmIPSecurityRestriction <IIPSecurityRestriction[]>]`: IP security restrictions for scm.
    - `[ScmIPSecurityRestrictionsUseMain <Boolean?>]`: IP security restrictions for scm to use main.
    - `[ScmType <ScmType?>]`: SCM type.
    - `[SlowRequestCount <Int32?>]`: Request Count.
    - `[SlowRequestTimeInterval <String>]`: Time interval.
    - `[SlowRequestTimeTaken <String>]`: Time taken.
    - `[TagWhitelistJson <String>]`: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    - `[TagsRequiringAuth <String>]`: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    - `[TracingOption <String>]`: Tracing options.
    - `[TriggerPrivateBytesInKb <Int32?>]`: A rule based on private bytes.
    - `[TriggerStatusCode <IStatusCodesBasedTrigger[]>]`: A rule based on status codes.
      - `[Count <Int32?>]`: Request Count.
      - `[Status <Int32?>]`: HTTP status code.
      - `[SubStatus <Int32?>]`: Request Sub Status.
      - `[TimeInterval <String>]`: Time interval.
      - `[Win32Status <Int32?>]`: Win32 error code.
    - `[Use32BitWorkerProcess <Boolean?>]`: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    - `[VirtualApplication <IVirtualApplication[]>]`: Virtual applications.
      - `[PhysicalPath <String>]`: Physical path.
      - `[PreloadEnabled <Boolean?>]`: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      - `[VirtualDirectory <IVirtualDirectory[]>]`: Virtual directories for virtual application.
        - `[PhysicalPath <String>]`: Physical path.
        - `[VirtualPath <String>]`: Path to virtual application.
      - `[VirtualPath <String>]`: Virtual path.
    - `[VnetName <String>]`: Virtual Network name.
    - `[WebSocketsEnabled <Boolean?>]`: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    - `[WindowsFxVersion <String>]`: Xenon App Framework and version
    - `[XManagedServiceIdentityId <Int32?>]`: Explicit Managed Service Identity Id

## RELATED LINKS

