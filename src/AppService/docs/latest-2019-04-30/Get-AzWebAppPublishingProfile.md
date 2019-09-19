---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/get-azwebapppublishingprofile
schema: 2.0.0
---

# Get-AzWebAppPublishingProfile

## SYNOPSIS
Gets the publishing profile for an app (or deployment slot, if specified).

## SYNTAX

### ListExpanded (Default)
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -OutFile <String>
 [-SubscriptionId <String[]>] [-Format <PublishingProfileFormat>] [-IncludeDisasterRecoveryEndpoints]
 [-PassThru] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -OutFile <String>
 -PublishingProfileOption <ICsmPublishingProfileOptions> [-SubscriptionId <String[]>] [-PassThru]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List1
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -Slot <String> -OutFile <String>
 -PublishingProfileOption <ICsmPublishingProfileOptions> [-SubscriptionId <String[]>] [-PassThru]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListBySiteObject
```
Get-AzWebAppPublishingProfile -SiteObject <ISite> [-SubscriptionId <String[]>]
 [-Format <PublishingProfileFormat>] [-IncludeDisasterRecoveryEndpoints] [-PassThru]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListExpanded1
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -Slot <String> -OutFile <String>
 [-SubscriptionId <String[]>] [-Format <PublishingProfileFormat>] [-IncludeDisasterRecoveryEndpoints]
 [-PassThru] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets the publishing profile for an app (or deployment slot, if specified).

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

### -Format
Name of the format.
Valid values are: FileZilla3WebDeploy -- defaultFtp

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.PublishingProfileFormat
Parameter Sets: ListBySiteObject, ListExpanded, ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeDisasterRecoveryEndpoints
Include the DisasterRecover endpoint if true

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListBySiteObject, ListExpanded, ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: List, List1, ListExpanded, ListExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OutFile
Path to write output file to

```yaml
Type: System.String
Parameter Sets: List, List1, ListExpanded, ListExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingProfileOption
Publishing options for requested profile.
To construct, see NOTES section for PUBLISHINGPROFILEOPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmPublishingProfileOptions
Parameter Sets: List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: List, List1, ListExpanded, ListExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteObject
The object representation of the web app or slot.
To construct, see NOTES section for SITEOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISite
Parameter Sets: ListBySiteObject
Aliases: WebApp, WebAppSlot

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will get the publishing profile for the production slot.

```yaml
Type: System.String
Parameter Sets: List1, ListExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmPublishingProfileOptions

## OUTPUTS

### System.Boolean

## ALIASES

### Get-AzWebAppPublishingProfile

### Get-AzWebAppSlotPublishingProfile

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PUBLISHINGPROFILEOPTION <ICsmPublishingProfileOptions>: Publishing options for requested profile.
  - `[Format <PublishingProfileFormat?>]`: Name of the format. Valid values are:         FileZilla3         WebDeploy -- default         Ftp
  - `[IncludeDisasterRecoveryEndpoint <Boolean?>]`: Include the DisasterRecover endpoint if true

#### SITEOBJECT <ISite>: The object representation of the web app or slot.
  - `Location <String>`: Resource Location.
  - `CloningInfoSourceWebAppId <String>`: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  - `[Kind <String>]`: Kind of resource.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
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
  - `[Config <ISiteConfig>]`: Configuration of the app.
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

## RELATED LINKS

