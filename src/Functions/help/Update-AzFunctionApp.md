---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/powershell/module/az.functions/update-azfunctionapp
schema: 2.0.0
---

# Update-AzFunctionApp

## SYNOPSIS
Updates a function app.

## SYNTAX

### ByName (Default)
```
Update-AzFunctionApp -Name <String> -ResourceGroupName <String> [-ApplicationInsightsKey <String>]
 [-ApplicationInsightsName <String>] [-IdentityID <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-PlanName <String>] [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByObjectInput
```
Update-AzFunctionApp -InputObject <ISite> [-ApplicationInsightsKey <String>]
 [-ApplicationInsightsName <String>] [-IdentityID <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-PlanName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a function app.

## EXAMPLES

### Example 1: Update function app hosting plan.
```powershell
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -PlanName NewPlanName 
```

This command updates function app hosting plan.

### Example 2: Set a SystemAssigned managed identity for a function app.
```powershell
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType SystemAssigned 
```

This command sets a SystemAssigned managed identity for a function app.

### Example 3: Update function app Application Insights.
```powershell
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -ApplicationInsightsName ApplicationInsightsProjectName 
```

This command updates function app Application Insights.

### Example 3: Remove managed identity from a function app.
```powershell
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType None 
```

This command removes a managed identity from a function app.

## PARAMETERS

### -ApplicationInsightsKey
Instrumentation key of App Insights to be added.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppInsightsKey

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationInsightsName
Name of the existing App Insights project to be added to the function app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppInsightsName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Runs the cmdlet as a background job.

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

### -DefaultProfile


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

### -IdentityID
Specifies the list of user identities associated with the function app.
            The user identity references will be ARM resource ids in the form:
            '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'

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

### -IdentityType
Specifies the type of identity used for the function app.
            The type 'None' will remove any identities from the function app.
The acceptable values for this parameter are:
            - SystemAssigned
            - UserAssigned
            - None

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
Parameter Sets: ByObjectInput
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the function app.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Starts the operation and returns immediately, before the operation is completed.
In order to determine if the operation has successfully been completed, use some other mechanism.

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

### -PlanName
The name of the service plan.

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ISite>: 
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
    - `IsPushEnabled <Boolean>`: Gets or sets a flag indicating whether the Push endpoint is enabled.
    - `[ActionMinProcessExecutionTime <String>]`: Minimum time the process must execute         before taking the action
    - `[ActionType <AutoHealActionType?>]`: Predefined action to be taken.
    - `[AlwaysOn <Boolean?>]`: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    - `[ApiDefinitionUrl <String>]`: The URL of the API definition.
    - `[ApiManagementConfigId <String>]`: APIM-Api Identifier.
    - `[AppCommandLine <String>]`: App command line to launch.
    - `[AppSetting <INameValuePair[]>]`: Application settings.
      - `[Name <String>]`: Pair name.
      - `[Value <String>]`: Pair value.
    - `[AutoHealEnabled <Boolean?>]`: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    - `[AutoSwapSlotName <String>]`: Auto-swap slot name.
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
      - `[ChangeStep <Double?>]`: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      - `[MaxReroutePercentage <Double?>]`: Specifies upper boundary below which ReroutePercentage will stay.
      - `[MinReroutePercentage <Double?>]`: Specifies lower boundary above which ReroutePercentage will stay.
      - `[Name <String>]`: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      - `[ReroutePercentage <Double?>]`: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    - `[FtpsState <FtpsState?>]`: State of FTP / FTPS service
    - `[HandlerMapping <IHandlerMapping[]>]`: Handler mappings.
      - `[Argument <String>]`: Command-line arguments to be passed to the script processor.
      - `[Extension <String>]`: Requests with this extension will be handled using the specified FastCGI application.
      - `[ScriptProcessor <String>]`: The absolute path to the FastCGI application.
    - `[HealthCheckPath <String>]`: Health check path
    - `[Http20Enabled <Boolean?>]`: Http20Enabled: configures a web site to allow clients to connect over http2.0
    - `[HttpLoggingEnabled <Boolean?>]`: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    - `[IPSecurityRestriction <IIPSecurityRestriction[]>]`: IP security restrictions for main.
      - `[Action <String>]`: Allow or Deny access for this IP range.
      - `[Description <String>]`: IP restriction rule description.
      - `[IPAddress <String>]`: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      - `[Name <String>]`: IP restriction rule name.
      - `[Priority <Int32?>]`: Priority of IP restriction rule.
      - `[SubnetMask <String>]`: Subnet mask for the range of IP addresses the restriction is valid for.
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
    - `[PowerShellVersion <String>]`: Version of PowerShell.
    - `[PreWarmedInstanceCount <Int32?>]`: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    - `[PublishingUsername <String>]`: Publishing user name.
    - `[PushKind <String>]`: Kind of resource.
    - `[PythonVersion <String>]`: Version of Python.
    - `[RemoteDebuggingEnabled <Boolean?>]`: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    - `[RemoteDebuggingVersion <String>]`: Remote debugging version.
    - `[RequestCount <Int32?>]`: Request Count.
    - `[RequestTimeInterval <String>]`: Time interval.
    - `[RequestTracingEnabled <Boolean?>]`: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    - `[RequestTracingExpirationTime <DateTime?>]`: Request tracing expiration time.
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
    - `[(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]`: This indicates any property can be added to this object.
  - `[IsXenon <Boolean?>]`: Obsolete: Hyper-V sandbox.
  - `[RedundancyMode <RedundancyMode?>]`: Site redundancy mode
  - `[Reserved <Boolean?>]`: <code>true</code> if reserved; otherwise, <code>false</code>.
  - `[ScmSiteAlsoStopped <Boolean?>]`: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  - `[ServerFarmId <String>]`: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".

## RELATED LINKS

