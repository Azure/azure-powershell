---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/new-azwebappconfigurationslot
schema: 2.0.0
---

# New-AzWebAppConfigurationSlot

## SYNOPSIS
Updates the configuration of an app.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-ActionMinProcessExecutionTime <String>] [-ActionType <AutoHealActionType>]
 [-AlwaysOn] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>] [-AppSetting <INameValuePair[]>]
 [-AutoHealEnabled] [-AutoSwapSlotName <String>] [-AzureStorageAccount <Hashtable>]
 [-ConnectionString <IConnStringInfo[]>] [-CorAllowedOrigin <String[]>] [-CorSupportCredentials]
 [-CustomActionExe <String>] [-CustomActionParameter <String>] [-DefaultDocument <String[]>]
 [-DetailedErrorLoggingEnabled] [-DocumentRoot <String>] [-DynamicTagsJson <String>]
 [-ExperimentRampUpRule <IRampUpRule[]>] [-FtpsState <FtpsState>] [-HandlerMapping <IHandlerMapping[]>]
 [-Http20Enabled] [-HttpLoggingEnabled] [-IPSecurityRestriction <IIPSecurityRestriction[]>] [-IsPushEnabled]
 [-JavaContainer <String>] [-JavaContainerVersion <String>] [-JavaVersion <String>] [-Kind <String>]
 [-LimitMaxDiskSizeInMb <Int64>] [-LimitMaxMemoryInMb <Int64>] [-LimitMaxPercentageCpu <Double>]
 [-LinuxFxVersion <String>] [-LoadBalancing <SiteLoadBalancing>] [-LocalMySqlEnabled]
 [-LogsDirectorySizeLimit <Int32>] [-MachineKeyDecryption <String>] [-MachineKeyDecryptionKey <String>]
 [-MachineKeyValidation <String>] [-MachineKeyValidationKey <String>]
 [-ManagedPipelineMode <ManagedPipelineMode>] [-ManagedServiceIdentityId <Int32>]
 [-MinTlsVersion <SupportedTlsVersions>] [-NetFrameworkVersion <String>] [-NodeVersion <String>]
 [-NumberOfWorker <Int32>] [-PhpVersion <String>] [-PublishingUsername <String>] [-PushKind <String>]
 [-PythonVersion <String>] [-RemoteDebuggingEnabled] [-RemoteDebuggingVersion <String>]
 [-RequestCount <Int32>] [-RequestTimeInterval <String>] [-RequestTracingEnabled]
 [-RequestTracingExpirationTime <DateTime>] [-ReservedInstanceCount <Int32>]
 [-ScmIPSecurityRestriction <IIPSecurityRestriction[]>] [-ScmIPSecurityRestrictionsUseMain]
 [-ScmType <ScmType>] [-SlowRequestCount <Int32>] [-SlowRequestTimeInterval <String>]
 [-SlowRequestTimeTaken <String>] [-TagsRequiringAuth <String>] [-TagWhitelistJson <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>]
 [-TriggerStatusCode <IStatusCodesBasedTrigger[]>] [-Use32BitWorkerProcess]
 [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>] [-WebSocketsEnabled]
 [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> -SiteConfig <ISiteConfigResource> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebAppConfigurationSlot -InputObject <IAppServiceIdentity> -SiteConfig <ISiteConfigResource>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebAppConfigurationSlot -InputObject <IAppServiceIdentity> [-ActionMinProcessExecutionTime <String>]
 [-ActionType <AutoHealActionType>] [-AlwaysOn] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>]
 [-AppSetting <INameValuePair[]>] [-AutoHealEnabled] [-AutoSwapSlotName <String>]
 [-AzureStorageAccount <Hashtable>] [-ConnectionString <IConnStringInfo[]>] [-CorAllowedOrigin <String[]>]
 [-CorSupportCredentials] [-CustomActionExe <String>] [-CustomActionParameter <String>]
 [-DefaultDocument <String[]>] [-DetailedErrorLoggingEnabled] [-DocumentRoot <String>]
 [-DynamicTagsJson <String>] [-ExperimentRampUpRule <IRampUpRule[]>] [-FtpsState <FtpsState>]
 [-HandlerMapping <IHandlerMapping[]>] [-Http20Enabled] [-HttpLoggingEnabled]
 [-IPSecurityRestriction <IIPSecurityRestriction[]>] [-IsPushEnabled] [-JavaContainer <String>]
 [-JavaContainerVersion <String>] [-JavaVersion <String>] [-Kind <String>] [-LimitMaxDiskSizeInMb <Int64>]
 [-LimitMaxMemoryInMb <Int64>] [-LimitMaxPercentageCpu <Double>] [-LinuxFxVersion <String>]
 [-LoadBalancing <SiteLoadBalancing>] [-LocalMySqlEnabled] [-LogsDirectorySizeLimit <Int32>]
 [-MachineKeyDecryption <String>] [-MachineKeyDecryptionKey <String>] [-MachineKeyValidation <String>]
 [-MachineKeyValidationKey <String>] [-ManagedPipelineMode <ManagedPipelineMode>]
 [-ManagedServiceIdentityId <Int32>] [-MinTlsVersion <SupportedTlsVersions>] [-NetFrameworkVersion <String>]
 [-NodeVersion <String>] [-NumberOfWorker <Int32>] [-PhpVersion <String>] [-PublishingUsername <String>]
 [-PushKind <String>] [-PythonVersion <String>] [-RemoteDebuggingEnabled] [-RemoteDebuggingVersion <String>]
 [-RequestCount <Int32>] [-RequestTimeInterval <String>] [-RequestTracingEnabled]
 [-RequestTracingExpirationTime <DateTime>] [-ReservedInstanceCount <Int32>]
 [-ScmIPSecurityRestriction <IIPSecurityRestriction[]>] [-ScmIPSecurityRestrictionsUseMain]
 [-ScmType <ScmType>] [-SlowRequestCount <Int32>] [-SlowRequestTimeInterval <String>]
 [-SlowRequestTimeTaken <String>] [-TagsRequiringAuth <String>] [-TagWhitelistJson <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>]
 [-TriggerStatusCode <IStatusCodesBasedTrigger[]>] [-Use32BitWorkerProcess]
 [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>] [-WebSocketsEnabled]
 [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the configuration of an app.

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
Dynamic: False
```

### -ActionType
ActionType - predefined action to be taken

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.AutoHealActionType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AlwaysOn
\<code\>true\</code\> if Always On is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -AppSetting
Application settings.
To construct, see NOTES section for APPSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.INameValuePair[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoHealEnabled
\<code\>true\</code\> if Auto Heal is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -AzureStorageAccount
User-provided Azure storage accounts.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionString
Connection strings.
To construct, see NOTES section for CONNECTIONSTRING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160301.IConnStringInfo[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorAllowedOrigin
Gets or sets the list of origins that should be allowed to make cross-origincalls (for example: http://example.com:12345).
Use "*" to allow all.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorSupportCredentials
Gets or sets whether CORS requests with credentials are allowed.
See https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentialsfor more details.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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

### -DetailedErrorLoggingEnabled
\<code\>true\</code\> if detailed error logging is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -ExperimentRampUpRule
List of ramp-up rules.
To construct, see NOTES section for EXPERIMENTRAMPUPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IRampUpRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FtpsState
State of FTP / FTPS service

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.FtpsState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HandlerMapping
Handler mappings.
To construct, see NOTES section for HANDLERMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IHandlerMapping[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Http20Enabled
Http20Enabled: configures a web site to allow clients to connect over http2.0

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLoggingEnabled
\<code\>true\</code\> if HTTP logging is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IPSecurityRestriction
IP security restrictions for main.
To construct, see NOTES section for IPSECURITYRESTRICTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IsPushEnabled
Gets or sets a flag indicating whether the Push endpoint is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -LimitMaxDiskSizeInMb
Maximum allowed disk size usage in MB.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LimitMaxMemoryInMb
Maximum allowed memory usage in MB.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LimitMaxPercentageCpu
Maximum allowed CPU usage percentage.

```yaml
Type: System.Double
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -LoadBalancing
Site load balancing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.SiteLoadBalancing
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalMySqlEnabled
\<code\>true\</code\> to enable local MySQL; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogsDirectorySizeLimit
HTTP logs directory size limit.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -ManagedPipelineMode
Managed pipeline mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.ManagedPipelineMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedServiceIdentityId
Managed Service Identity Id

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MinTlsVersion
MinTlsVersion: configures the minimum version of TLS required for SSL requests

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.SupportedTlsVersions
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -NumberOfWorker
Number of workers.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -RemoteDebuggingEnabled
\<code\>true\</code\> if remote debugging is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -RequestCount
Request Count.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -RequestTracingEnabled
\<code\>true\</code\> if request tracing is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -ReservedInstanceCount
Number of reserved instances.This setting only applies to the Consumption Plan

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmIPSecurityRestriction
IP security restrictions for scm.
To construct, see NOTES section for SCMIPSECURITYRESTRICTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmIPSecurityRestrictionsUseMain
IP security restrictions for scm to use main.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmType
SCM type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.ScmType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteConfig
Web app configuration ARM resource.
To construct, see NOTES section for SITECONFIG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteConfigResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -SlowRequestCount
Request Count.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -TriggerPrivateBytesInKb
A rule based on private bytes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TriggerStatusCode
A rule based on status codes.
To construct, see NOTES section for TRIGGERSTATUSCODE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IStatusCodesBasedTrigger[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Use32BitWorkerProcess
\<code\>true\</code\> to use 32-bit worker process; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualApplication
Virtual applications.
To construct, see NOTES section for VIRTUALAPPLICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IVirtualApplication[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -WebSocketsEnabled
\<code\>true\</code\> if WebSocket is enabled; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -XManagedServiceIdentityId
Explicit Managed Service Identity Id

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteConfigResource

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ISiteConfigResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPSETTING <INameValuePair[]>: Application settings.
  - `[Name <String>]`: Pair name.
  - `[Value <String>]`: Pair value.

#### CONNECTIONSTRING <IConnStringInfo[]>: Connection strings.
  - `[ConnectionString <String>]`: Connection string value.
  - `[Name <String>]`: Name of connection string.
  - `[Type <ConnectionStringType?>]`: Type of database.

#### EXPERIMENTRAMPUPRULE <IRampUpRule[]>: List of ramp-up rules.
  - `[ActionHostName <String>]`: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
  - `[ChangeDecisionCallbackUrl <String>]`: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
  - `[ChangeIntervalInMinute <Int32?>]`: Specifies interval in minutes to reevaluate ReroutePercentage.
  - `[ChangeStep <Double?>]`: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches         <code>MinReroutePercentage</code> or <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.         Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
  - `[MaxReroutePercentage <Double?>]`: Specifies upper boundary below which ReroutePercentage will stay.
  - `[MinReroutePercentage <Double?>]`: Specifies lower boundary above which ReroutePercentage will stay.
  - `[Name <String>]`: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
  - `[ReroutePercentage <Double?>]`: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.

#### HANDLERMAPPING <IHandlerMapping[]>: Handler mappings.
  - `[Argument <String>]`: Command-line arguments to be passed to the script processor.
  - `[Extension <String>]`: Requests with this extension will be handled using the specified FastCGI application.
  - `[ScriptProcessor <String>]`: The absolute path to the FastCGI application.

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

#### IPSECURITYRESTRICTION <IIPSecurityRestriction[]>: IP security restrictions for main.
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

#### SCMIPSECURITYRESTRICTION <IIPSecurityRestriction[]>: IP security restrictions for scm.
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

#### SITECONFIG <ISiteConfigResource>: Web app configuration ARM resource.
  - `ActionType <AutoHealActionType>`: ActionType - predefined action to be taken
  - `IsPushEnabled <Boolean>`: Gets or sets a flag indicating whether the Push endpoint is enabled.
  - `[Kind <String>]`: Kind of resource.
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

#### TRIGGERSTATUSCODE <IStatusCodesBasedTrigger[]>: A rule based on status codes.
  - `[Count <Int32?>]`: Request Count.
  - `[Status <Int32?>]`: HTTP status code.
  - `[SubStatus <Int32?>]`: Request Sub Status.
  - `[TimeInterval <String>]`: Time interval.
  - `[Win32Status <Int32?>]`: Win32 error code.

#### VIRTUALAPPLICATION <IVirtualApplication[]>: Virtual applications.
  - `[PhysicalPath <String>]`: Physical path.
  - `[PreloadEnabled <Boolean?>]`: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
  - `[VirtualDirectory <IVirtualDirectory[]>]`: Virtual directories for virtual application.
    - `[PhysicalPath <String>]`: Physical path.
    - `[VirtualPath <String>]`: Path to virtual application.
  - `[VirtualPath <String>]`: Virtual path.

## RELATED LINKS

