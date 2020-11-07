
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Description for Updates the configuration of an app.
.Description
Description for Updates the configuration of an app.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResource
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

APPSETTING <INameValuePair[]>: Application settings.
  [Name <String>]: Pair name.
  [Value <String>]: Pair value.

CONNECTIONSTRING <IConnStringInfo[]>: Connection strings.
  [ConnectionString <String>]: Connection string value.
  [Name <String>]: Name of connection string.
  [Type <ConnectionStringType?>]: Type of database.

EXPERIMENTRAMPUPRULE <IRampUpRule[]>: List of ramp-up rules.
  [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
  [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
  [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
  [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
  [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
  [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
  [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
  [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.

HANDLERMAPPING <IHandlerMapping[]>: Handler mappings.
  [Argument <String>]: Command-line arguments to be passed to the script processor.
  [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
  [ScriptProcessor <String>]: The absolute path to the FastCGI application.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order.
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the identity resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Name of the deployment slot. By default, this API returns the production slot.
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.

IPSECURITYRESTRICTION <IIPSecurityRestriction[]>: IP security restrictions for main.
  [Action <String>]: Allow or Deny access for this IP range.
  [Description <String>]: IP restriction rule description.
  [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
  [Name <String>]: IP restriction rule name.
  [Priority <Int32?>]: Priority of IP restriction rule.
  [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
  [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
  [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
  [VnetSubnetResourceId <String>]: Virtual network resource id
  [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag

SCMIPSECURITYRESTRICTION <IIPSecurityRestriction[]>: IP security restrictions for scm.
  [Action <String>]: Allow or Deny access for this IP range.
  [Description <String>]: IP restriction rule description.
  [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
  [Name <String>]: IP restriction rule name.
  [Priority <Int32?>]: Priority of IP restriction rule.
  [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
  [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
  [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
  [VnetSubnetResourceId <String>]: Virtual network resource id
  [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag

SITECONFIG <ISiteConfigResource>: Web app configuration ARM resource.
  IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
  [Kind <String>]: Kind of resource.
  [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
  [ActionType <AutoHealActionType?>]: Predefined action to be taken.
  [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
  [ApiDefinitionUrl <String>]: The URL of the API definition.
  [ApiManagementConfigId <String>]: APIM-Api Identifier.
  [AppCommandLine <String>]: App command line to launch.
  [AppSetting <INameValuePair[]>]: Application settings.
    [Name <String>]: Pair name.
    [Value <String>]: Pair value.
  [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
  [AutoSwapSlotName <String>]: Auto-swap slot name.
  [ConnectionString <IConnStringInfo[]>]: Connection strings.
    [ConnectionString <String>]: Connection string value.
    [Name <String>]: Name of connection string.
    [Type <ConnectionStringType?>]: Type of database.
  [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
  [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
  [CustomActionExe <String>]: Executable to be run.
  [CustomActionParameter <String>]: Parameters for the executable.
  [DefaultDocument <String[]>]: Default documents.
  [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
  [DocumentRoot <String>]: Document root.
  [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
  [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
    [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
    [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
    [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
    [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
    [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
    [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
    [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
    [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
  [FtpsState <FtpsState?>]: State of FTP / FTPS service
  [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
    [Argument <String>]: Command-line arguments to be passed to the script processor.
    [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
    [ScriptProcessor <String>]: The absolute path to the FastCGI application.
  [HealthCheckPath <String>]: Health check path
  [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
  [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
  [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
    [Action <String>]: Allow or Deny access for this IP range.
    [Description <String>]: IP restriction rule description.
    [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
    [Name <String>]: IP restriction rule name.
    [Priority <Int32?>]: Priority of IP restriction rule.
    [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
    [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
    [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
    [VnetSubnetResourceId <String>]: Virtual network resource id
    [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
  [JavaContainer <String>]: Java container.
  [JavaContainerVersion <String>]: Java container version.
  [JavaVersion <String>]: Java version.
  [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
  [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
  [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
  [LinuxFxVersion <String>]: Linux App Framework and version
  [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
  [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
  [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
  [MachineKeyDecryption <String>]: Algorithm used for decryption.
  [MachineKeyDecryptionKey <String>]: Decryption key.
  [MachineKeyValidation <String>]: MachineKey validation.
  [MachineKeyValidationKey <String>]: Validation key.
  [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
  [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
  [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
  [NetFrameworkVersion <String>]: .NET Framework version.
  [NodeVersion <String>]: Version of Node.js.
  [NumberOfWorker <Int32?>]: Number of workers.
  [PhpVersion <String>]: Version of PHP.
  [PowerShellVersion <String>]: Version of PowerShell.
  [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
  [PublishingUsername <String>]: Publishing user name.
  [PushKind <String>]: Kind of resource.
  [PythonVersion <String>]: Version of Python.
  [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
  [RemoteDebuggingVersion <String>]: Remote debugging version.
  [RequestCount <Int32?>]: Request Count.
  [RequestTimeInterval <String>]: Time interval.
  [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
  [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
  [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
  [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
  [ScmType <ScmType?>]: SCM type.
  [SlowRequestCount <Int32?>]: Request Count.
  [SlowRequestTimeInterval <String>]: Time interval.
  [SlowRequestTimeTaken <String>]: Time taken.
  [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
  [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
  [TracingOption <String>]: Tracing options.
  [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
  [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
    [Count <Int32?>]: Request Count.
    [Status <Int32?>]: HTTP status code.
    [SubStatus <Int32?>]: Request Sub Status.
    [TimeInterval <String>]: Time interval.
    [Win32Status <Int32?>]: Win32 error code.
  [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
  [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
    [PhysicalPath <String>]: Physical path.
    [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
    [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
      [PhysicalPath <String>]: Physical path.
      [VirtualPath <String>]: Path to virtual application.
    [VirtualPath <String>]: Virtual path.
  [VnetName <String>]: Virtual Network name.
  [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
  [WindowsFxVersion <String>]: Xenon App Framework and version
  [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id

TRIGGERSTATUSCODE <IStatusCodesBasedTrigger[]>: A rule based on status codes.
  [Count <Int32?>]: Request Count.
  [Status <Int32?>]: HTTP status code.
  [SubStatus <Int32?>]: Request Sub Status.
  [TimeInterval <String>]: Time interval.
  [Win32Status <Int32?>]: Win32 error code.

VIRTUALAPPLICATION <IVirtualApplication[]>: Virtual applications.
  [PhysicalPath <String>]: Physical path.
  [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
  [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
    [PhysicalPath <String>]: Physical path.
    [VirtualPath <String>]: Path to virtual application.
  [VirtualPath <String>]: Virtual path.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/update-azwebappconfiguration
#>
function Update-AzWebAppConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResource])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResource]
    # Web app configuration ARM resource.
    # To construct, see NOTES section for SITECONFIG properties and create a hash table.
    ${SiteConfig},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Minimum time the process must executebefore taking the action
    ${ActionMinProcessExecutionTime},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType]
    # Predefined action to be taken.
    ${ActionType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    ${AlwaysOn},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The URL of the API definition.
    ${ApiDefinitionUrl},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # APIM-Api Identifier.
    ${ApiManagementConfigId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # App command line to launch.
    ${AppCommandLine},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]]
    # Application settings.
    # To construct, see NOTES section for APPSETTING properties and create a hash table.
    ${AppSetting},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    ${AutoHealEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Auto-swap slot name.
    ${AutoSwapSlotName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[]]
    # Connection strings.
    # To construct, see NOTES section for CONNECTIONSTRING properties and create a hash table.
    ${ConnectionString},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    # Gets or sets the list of origins that should be allowed to make cross-origincalls (for example: http://example.com:12345).
    # Use "*" to allow all.
    ${CorAllowedOrigin},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Gets or sets whether CORS requests with credentials are allowed.
    # See https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentialsfor more details.
    ${CorSupportCredentials},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Executable to be run.
    ${CustomActionExe},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Parameters for the executable.
    ${CustomActionParameter},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    # Default documents.
    ${DefaultDocument},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    ${DetailedErrorLoggingEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Document root.
    ${DocumentRoot},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    ${DynamicTagsJson},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[]]
    # List of ramp-up rules.
    # To construct, see NOTES section for EXPERIMENTRAMPUPRULE properties and create a hash table.
    ${ExperimentRampUpRule},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState]
    # State of FTP / FTPS service
    ${FtpsState},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[]]
    # Handler mappings.
    # To construct, see NOTES section for HANDLERMAPPING properties and create a hash table.
    ${HandlerMapping},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Health check path
    ${HealthCheckPath},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Http20Enabled: configures a web site to allow clients to connect over http2.0
    ${Http20Enabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    ${HttpLoggingEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[]]
    # IP security restrictions for main.
    # To construct, see NOTES section for IPSECURITYRESTRICTION properties and create a hash table.
    ${IPSecurityRestriction},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Gets or sets a flag indicating whether the Push endpoint is enabled.
    ${IsPushEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Java container.
    ${JavaContainer},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Java container version.
    ${JavaContainerVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Java version.
    ${JavaVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Kind of resource.
    ${Kind},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int64]
    # Maximum allowed disk size usage in MB.
    ${LimitMaxDiskSizeInMb},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int64]
    # Maximum allowed memory usage in MB.
    ${LimitMaxMemoryInMb},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Double]
    # Maximum allowed CPU usage percentage.
    ${LimitMaxPercentageCpu},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Linux App Framework and version
    ${LinuxFxVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing]
    # Site load balancing.
    ${LoadBalancing},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    ${LocalMySqlEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # HTTP logs directory size limit.
    ${LogsDirectorySizeLimit},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Algorithm used for decryption.
    ${MachineKeyDecryption},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Decryption key.
    ${MachineKeyDecryptionKey},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # MachineKey validation.
    ${MachineKeyValidation},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Validation key.
    ${MachineKeyValidationKey},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode]
    # Managed pipeline mode.
    ${ManagedPipelineMode},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Managed Service Identity Id
    ${ManagedServiceIdentityId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions]
    # MinTlsVersion: configures the minimum version of TLS required for SSL requests
    ${MinTlsVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # .NET Framework version.
    ${NetFrameworkVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Version of Node.js.
    ${NodeVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Number of workers.
    ${NumberOfWorker},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Version of PHP.
    ${PhpVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Version of PowerShell.
    ${PowerShellVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Number of preWarmed instances.This setting only applies to the Consumption and Elastic Plans
    ${PreWarmedInstanceCount},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Publishing user name.
    ${PublishingUsername},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Kind of resource.
    ${PushKind},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Version of Python.
    ${PythonVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    ${RemoteDebuggingEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Remote debugging version.
    ${RemoteDebuggingVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Request Count.
    ${RequestCount},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Time interval.
    ${RequestTimeInterval},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    ${RequestTracingEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.DateTime]
    # Request tracing expiration time.
    ${RequestTracingExpirationTime},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[]]
    # IP security restrictions for scm.
    # To construct, see NOTES section for SCMIPSECURITYRESTRICTION properties and create a hash table.
    ${ScmIPSecurityRestriction},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # IP security restrictions for scm to use main.
    ${ScmIPSecurityRestrictionsUseMain},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType]
    # SCM type.
    ${ScmType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Request Count.
    ${SlowRequestCount},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Time interval.
    ${SlowRequestTimeInterval},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Time taken.
    ${SlowRequestTimeTaken},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    ${TagWhitelistJson},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.Tags can consist of alphanumeric characters and the following:'_', '@', '#', '.', ':', '-'.
    # Validation should be performed at the PushRequestHandler.
    ${TagsRequiringAuth},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Tracing options.
    ${TracingOption},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # A rule based on private bytes.
    ${TriggerPrivateBytesInKb},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[]]
    # A rule based on status codes.
    # To construct, see NOTES section for TRIGGERSTATUSCODE properties and create a hash table.
    ${TriggerStatusCode},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    ${Use32BitWorkerProcess},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[]]
    # Virtual applications.
    # To construct, see NOTES section for VIRTUALAPPLICATION properties and create a hash table.
    ${VirtualApplication},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Virtual Network name.
    ${VnetName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    ${WebSocketsEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Xenon App Framework and version
    ${WindowsFxVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Explicit Managed Service Identity Id
    ${XManagedServiceIdentityId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Update = 'Az.Functions.private\Update-AzWebAppConfiguration_Update';
            UpdateExpanded = 'Az.Functions.private\Update-AzWebAppConfiguration_UpdateExpanded';
            UpdateViaIdentity = 'Az.Functions.private\Update-AzWebAppConfiguration_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.Functions.private\Update-AzWebAppConfiguration_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
