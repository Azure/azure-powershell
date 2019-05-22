---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappconfigurationslot
schema: 2.0.0
---

# New-AzWebAppConfigurationSlot

## SYNOPSIS
Updates the configuration of an app.

## SYNTAX

### Create (Default)
```
New-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-SiteConfig <ISiteConfigResource>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-ActionMinProcessExecutionTime <String>] -ActionType <AutoHealActionType>
 [-AlwaysOn <Boolean>] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>] [-AppSetting <INameValuePair[]>]
 [-AutoHealEnabled <Boolean>] [-AutoSwapSlotName <String>]
 [-AzureStorageAccount <ISiteConfigAzureStorageAccounts>] [-ConnectionString <IConnStringInfo[]>]
 [-CorAllowedOrigin <String[]>] [-CorSupportCredential <Boolean>] [-CustomActionExe <String>]
 [-CustomActionParameter <String>] [-DefaultDocument <String[]>] [-DetailedErrorLoggingEnabled <Boolean>]
 [-DocumentRoot <String>] [-DynamicTagsJson <String>] [-ExperimentRampUpRule <IRampUpRule[]>]
 [-FtpsState <FtpsState>] [-HandlerMapping <IHandlerMapping[]>] [-Http20Enabled <Boolean>]
 [-HttpLoggingEnabled <Boolean>] [-IPSecurityRestriction <IIPSecurityRestriction[]>] -IsPushEnabled <Boolean>
 [-JavaContainer <String>] [-JavaContainerVersion <String>] [-JavaVersion <String>] [-Kind <String>]
 [-LimitMaxDiskSizeInMb <Int64>] [-LimitMaxMemoryInMb <Int64>] [-LimitMaxPercentageCpu <Double>]
 [-LinuxFxVersion <String>] [-LoadBalancing <SiteLoadBalancing>] [-LocalMySqlEnabled <Boolean>]
 [-LogsDirectorySizeLimit <Int32>] [-MachineKeyDecryption <String>] [-MachineKeyDecryptionKey <String>]
 [-MachineKeyValidation <String>] [-MachineKeyValidationKey <String>]
 [-ManagedPipelineMode <ManagedPipelineMode>] [-ManagedServiceIdentityId <Int32>]
 [-MinTlsVersion <SupportedTlsVersions>] [-NetFrameworkVersion <String>] [-NodeVersion <String>]
 [-NumberOfWorker <Int32>] [-PhpVersion <String>] [-PublishingUsername <String>] [-PushKind <String>]
 [-PythonVersion <String>] [-RemoteDebuggingEnabled <Boolean>] [-RemoteDebuggingVersion <String>]
 [-RequestCount <Int32>] [-RequestTimeInterval <String>] [-RequestTracingEnabled <Boolean>]
 [-RequestTracingExpirationTime <DateTime>] [-ReservedInstanceCount <Int32>]
 [-ScmIPSecurityRestriction <IIPSecurityRestriction[]>] [-ScmIPSecurityRestrictionsUseMain <Boolean>]
 [-ScmType <ScmType>] [-SlowRequestCount <Int32>] [-SlowRequestTimeInterval <String>]
 [-SlowRequestTimeTaken <String>] [-TagWhitelistJson <String>] [-TagsRequiringAuth <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>] [-TriggerStatusCode <IStatusCodesBasedTrigger[]>]
 [-Use32BitWorkerProcess <Boolean>] [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>]
 [-WebSocketsEnabled <Boolean>] [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebAppConfigurationSlot -InputObject <IWebSiteIdentity> [-ActionMinProcessExecutionTime <String>]
 -ActionType <AutoHealActionType> [-AlwaysOn <Boolean>] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>]
 [-AppSetting <INameValuePair[]>] [-AutoHealEnabled <Boolean>] [-AutoSwapSlotName <String>]
 [-AzureStorageAccount <ISiteConfigAzureStorageAccounts>] [-ConnectionString <IConnStringInfo[]>]
 [-CorAllowedOrigin <String[]>] [-CorSupportCredential <Boolean>] [-CustomActionExe <String>]
 [-CustomActionParameter <String>] [-DefaultDocument <String[]>] [-DetailedErrorLoggingEnabled <Boolean>]
 [-DocumentRoot <String>] [-DynamicTagsJson <String>] [-ExperimentRampUpRule <IRampUpRule[]>]
 [-FtpsState <FtpsState>] [-HandlerMapping <IHandlerMapping[]>] [-Http20Enabled <Boolean>]
 [-HttpLoggingEnabled <Boolean>] [-IPSecurityRestriction <IIPSecurityRestriction[]>] -IsPushEnabled <Boolean>
 [-JavaContainer <String>] [-JavaContainerVersion <String>] [-JavaVersion <String>] [-Kind <String>]
 [-LimitMaxDiskSizeInMb <Int64>] [-LimitMaxMemoryInMb <Int64>] [-LimitMaxPercentageCpu <Double>]
 [-LinuxFxVersion <String>] [-LoadBalancing <SiteLoadBalancing>] [-LocalMySqlEnabled <Boolean>]
 [-LogsDirectorySizeLimit <Int32>] [-MachineKeyDecryption <String>] [-MachineKeyDecryptionKey <String>]
 [-MachineKeyValidation <String>] [-MachineKeyValidationKey <String>]
 [-ManagedPipelineMode <ManagedPipelineMode>] [-ManagedServiceIdentityId <Int32>]
 [-MinTlsVersion <SupportedTlsVersions>] [-NetFrameworkVersion <String>] [-NodeVersion <String>]
 [-NumberOfWorker <Int32>] [-PhpVersion <String>] [-PublishingUsername <String>] [-PushKind <String>]
 [-PythonVersion <String>] [-RemoteDebuggingEnabled <Boolean>] [-RemoteDebuggingVersion <String>]
 [-RequestCount <Int32>] [-RequestTimeInterval <String>] [-RequestTracingEnabled <Boolean>]
 [-RequestTracingExpirationTime <DateTime>] [-ReservedInstanceCount <Int32>]
 [-ScmIPSecurityRestriction <IIPSecurityRestriction[]>] [-ScmIPSecurityRestrictionsUseMain <Boolean>]
 [-ScmType <ScmType>] [-SlowRequestCount <Int32>] [-SlowRequestTimeInterval <String>]
 [-SlowRequestTimeTaken <String>] [-TagWhitelistJson <String>] [-TagsRequiringAuth <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>] [-TriggerStatusCode <IStatusCodesBasedTrigger[]>]
 [-Use32BitWorkerProcess <Boolean>] [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>]
 [-WebSocketsEnabled <Boolean>] [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebAppConfigurationSlot -InputObject <IWebSiteIdentity> [-SiteConfig <ISiteConfigResource>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the configuration of an app.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ActionMinProcessExecutionTime
MinProcessExecutionTime - minimum time the process must execute before taking the action

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

### -ActionType
ActionType - predefined action to be taken

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.AutoHealActionType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlwaysOn
\<code\>true\</code\> if Always On is enabled; otherwise, \<code\>false\</code\>.

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

### -ApiDefinitionUrl
The URL of the API definition.

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

### -AppCommandLine
App command line to launch.

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

### -AppSetting
Application settings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INameValuePair[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoHealEnabled
\<code\>true\</code\> if Auto Heal is enabled; otherwise, \<code\>false\</code\>.

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

### -AutoSwapSlotName
Auto-swap slot name.

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

### -AzureStorageAccount
User-provided Azure storage accounts.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigAzureStorageAccounts
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionString
Connection strings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IConnStringInfo[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorAllowedOrigin
Gets or sets the list of origins that should be allowed to make cross-origincalls (for example: http://example.com:12345). Use "*" to allow all.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorSupportCredential
Gets or sets whether CORS requests with credentials are allowed. See https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentialsfor more details.

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

### -CustomActionExe
Executable to be run.

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

### -CustomActionParameter
Parameters for the executable.

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

### -DefaultDocument
Default documents.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -DetailedErrorLoggingEnabled
\<code\>true\</code\> if detailed error logging is enabled; otherwise, \<code\>false\</code\>.

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

### -DocumentRoot
Document root.

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

### -DynamicTagsJson
Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.

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

### -ExperimentRampUpRule
List of ramp-up rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IRampUpRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FtpsState
State of FTP / FTPS service

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.FtpsState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HandlerMapping
Handler mappings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IHandlerMapping[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Http20Enabled
Http20Enabled: configures a web site to allow clients to connect over http2.0

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

### -HttpLoggingEnabled
\<code\>true\</code\> if HTTP logging is enabled; otherwise, \<code\>false\</code\>.

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

### -IPSecurityRestriction
IP security restrictions for main.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsPushEnabled
Gets or sets a flag indicating whether the Push endpoint is enabled.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -JavaContainer
Java container.

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

### -JavaContainerVersion
Java container version.

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

### -JavaVersion
Java version.

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

### -LimitMaxDiskSizeInMb
Maximum allowed disk size usage in MB.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitMaxMemoryInMb
Maximum allowed memory usage in MB.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitMaxPercentageCpu
Maximum allowed CPU usage percentage.

```yaml
Type: System.Double
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxFxVersion
Linux App Framework and version

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

### -LoadBalancing
Site load balancing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.SiteLoadBalancing
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalMySqlEnabled
\<code\>true\</code\> to enable local MySQL; otherwise, \<code\>false\</code\>.

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

### -LogsDirectorySizeLimit
HTTP logs directory size limit.

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

### -MachineKeyDecryption
Algorithm used for decryption.

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

### -MachineKeyDecryptionKey
Decryption key.

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

### -MachineKeyValidation
MachineKey validation.

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

### -MachineKeyValidationKey
Validation key.

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

### -ManagedPipelineMode
Managed pipeline mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ManagedPipelineMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedServiceIdentityId
Managed Service Identity Id

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

### -MinTlsVersion
MinTlsVersion: configures the minimum version of TLS required for SSL requests

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.SupportedTlsVersions
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the app.

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

### -NetFrameworkVersion
.NET Framework version.

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

### -NodeVersion
Version of Node.js.

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

### -NumberOfWorker
Number of workers.

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

### -PhpVersion
Version of PHP.

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

### -PublishingUsername
Publishing user name.

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

### -PushKind
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

### -PythonVersion
Version of Python.

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

### -RemoteDebuggingEnabled
\<code\>true\</code\> if remote debugging is enabled; otherwise, \<code\>false\</code\>.

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

### -RemoteDebuggingVersion
Remote debugging version.

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

### -RequestCount
Request Count.

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

### -RequestTimeInterval
Time interval.

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

### -RequestTracingEnabled
\<code\>true\</code\> if request tracing is enabled; otherwise, \<code\>false\</code\>.

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

### -RequestTracingExpirationTime
Request tracing expiration time.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservedInstanceCount
Number of reserved instances.This setting only applies to the Consumption Plan

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

### -ScmIPSecurityRestriction
IP security restrictions for scm.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScmIPSecurityRestrictionsUseMain
IP security restrictions for scm to use main.

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

### -ScmType
SCM type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ScmType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteConfig
Web app configuration ARM resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will update configuration for the production slot.

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

### -SlowRequestCount
Request Count.

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

### -SlowRequestTimeInterval
Time interval.

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

### -SlowRequestTimeTaken
Time taken.

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

### -TagsRequiringAuth
Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.Tags can consist of alphanumeric characters and the following:'_', '@', '#', '.', ':', '-'.
Validation should be performed at the PushRequestHandler.

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

### -TagWhitelistJson
Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.

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

### -TracingOption
Tracing options.

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

### -TriggerPrivateBytesInKb
A rule based on private bytes.

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

### -TriggerStatusCode
A rule based on status codes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IStatusCodesBasedTrigger[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Use32BitWorkerProcess
\<code\>true\</code\> to use 32-bit worker process; otherwise, \<code\>false\</code\>.

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

### -VirtualApplication
Virtual applications.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IVirtualApplication[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetName
Virtual Network name.

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

### -WebSocketsEnabled
\<code\>true\</code\> if WebSocket is enabled; otherwise, \<code\>false\</code\>.

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

### -WindowsFxVersion
Xenon App Framework and version

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

### -XManagedServiceIdentityId
Explicit Managed Service Identity Id

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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigResource
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappconfigurationslot](https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebappconfigurationslot)

