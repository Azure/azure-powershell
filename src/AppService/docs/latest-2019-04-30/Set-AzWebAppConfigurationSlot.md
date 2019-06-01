---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebappconfigurationslot
schema: 2.0.0
---

# Set-AzWebAppConfigurationSlot

## SYNOPSIS
Updates the configuration of an app.

## SYNTAX

### Update (Default)
```
Set-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> [-SiteConfig <ISiteConfigResource>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzWebAppConfigurationSlot -Name <String> -ResourceGroupName <String> -Slot <String>
 -SubscriptionId <String> -ActionType <AutoHealActionType> -IsPushEnabled
 [-ActionMinProcessExecutionTime <String>] [-AlwaysOn] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>]
 [-AppSetting <INameValuePair[]>] [-AutoHealEnabled] [-AutoSwapSlotName <String>]
 [-AzureStorageAccount <ISiteConfigAzureStorageAccounts>] [-ConnectionString <IConnStringInfo[]>]
 [-CorAllowedOrigin <String[]>] [-CorSupportCredential] [-CustomActionExe <String>]
 [-CustomActionParameter <String>] [-DefaultDocument <String[]>] [-DetailedErrorLoggingEnabled]
 [-DocumentRoot <String>] [-DynamicTagsJson <String>] [-ExperimentRampUpRule <IRampUpRule[]>]
 [-FtpsState <FtpsState>] [-HandlerMapping <IHandlerMapping[]>] [-Http20Enabled] [-HttpLoggingEnabled]
 [-IPSecurityRestriction <IIPSecurityRestriction[]>] [-JavaContainer <String>]
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
 [-SlowRequestTimeTaken <String>] [-TagWhitelistJson <String>] [-TagsRequiringAuth <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>]
 [-TriggerStatusCode <IStatusCodesBasedTrigger[]>] [-Use32BitWorkerProcess]
 [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>] [-WebSocketsEnabled]
 [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzWebAppConfigurationSlot -InputObject <IWebSiteIdentity> -ActionType <AutoHealActionType> -IsPushEnabled
 [-ActionMinProcessExecutionTime <String>] [-AlwaysOn] [-ApiDefinitionUrl <String>] [-AppCommandLine <String>]
 [-AppSetting <INameValuePair[]>] [-AutoHealEnabled] [-AutoSwapSlotName <String>]
 [-AzureStorageAccount <ISiteConfigAzureStorageAccounts>] [-ConnectionString <IConnStringInfo[]>]
 [-CorAllowedOrigin <String[]>] [-CorSupportCredential] [-CustomActionExe <String>]
 [-CustomActionParameter <String>] [-DefaultDocument <String[]>] [-DetailedErrorLoggingEnabled]
 [-DocumentRoot <String>] [-DynamicTagsJson <String>] [-ExperimentRampUpRule <IRampUpRule[]>]
 [-FtpsState <FtpsState>] [-HandlerMapping <IHandlerMapping[]>] [-Http20Enabled] [-HttpLoggingEnabled]
 [-IPSecurityRestriction <IIPSecurityRestriction[]>] [-JavaContainer <String>]
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
 [-SlowRequestTimeTaken <String>] [-TagWhitelistJson <String>] [-TagsRequiringAuth <String>]
 [-TracingOption <String>] [-TriggerPrivateBytesInKb <Int32>]
 [-TriggerStatusCode <IStatusCodesBasedTrigger[]>] [-Use32BitWorkerProcess]
 [-VirtualApplication <IVirtualApplication[]>] [-VnetName <String>] [-WebSocketsEnabled]
 [-WindowsFxVersion <String>] [-XManagedServiceIdentityId <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzWebAppConfigurationSlot -InputObject <IWebSiteIdentity> [-SiteConfig <ISiteConfigResource>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.AutoHealActionType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AlwaysOn
<code>true</code> if Always On is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiDefinitionUrl
The URL of the API definition.

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

### -AppCommandLine
App command line to launch.

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

### -AppSetting
Application settings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INameValuePair[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoHealEnabled
<code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutoSwapSlotName
Auto-swap slot name.

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

### -AzureStorageAccount
User-provided Azure storage accounts.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigAzureStorageAccounts
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IConnStringInfo[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorSupportCredential
Gets or sets whether CORS requests with credentials are allowed.
See https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentialsfor more details.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomActionExe
Executable to be run.

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

### -CustomActionParameter
Parameters for the executable.

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

### -DefaultDocument
Default documents.

```yaml
Type: System.String[]
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

### -DetailedErrorLoggingEnabled
<code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DocumentRoot
Document root.

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

### -DynamicTagsJson
Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.

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

### -ExperimentRampUpRule
List of ramp-up rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IRampUpRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.FtpsState
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IHandlerMapping[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HttpLoggingEnabled
<code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -JavaContainer
Java container.

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

### -JavaContainerVersion
Java container version.

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

### -JavaVersion
Java version.

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

### -LimitMaxDiskSizeInMb
Maximum allowed disk size usage in MB.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LimitMaxMemoryInMb
Maximum allowed memory usage in MB.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LimitMaxPercentageCpu
Maximum allowed CPU usage percentage.

```yaml
Type: System.Double
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxFxVersion
Linux App Framework and version

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

### -LoadBalancing
Site load balancing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.SiteLoadBalancing
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LocalMySqlEnabled
<code>true</code> to enable local MySQL; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogsDirectorySizeLimit
HTTP logs directory size limit.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MachineKeyDecryption
Algorithm used for decryption.

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

### -MachineKeyDecryptionKey
Decryption key.

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

### -MachineKeyValidation
MachineKey validation.

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

### -MachineKeyValidationKey
Validation key.

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

### -ManagedPipelineMode
Managed pipeline mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ManagedPipelineMode
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MinTlsVersion
MinTlsVersion: configures the minimum version of TLS required for SSL requests

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.SupportedTlsVersions
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
Name of the app.

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

### -NetFrameworkVersion
.NET Framework version.

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

### -NodeVersion
Version of Node.js.

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

### -NumberOfWorker
Number of workers.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PhpVersion
Version of PHP.

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

### -PublishingUsername
Publishing user name.

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

### -PushKind
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

### -PythonVersion
Version of Python.

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

### -RemoteDebuggingEnabled
<code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RemoteDebuggingVersion
Remote debugging version.

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

### -RequestCount
Request Count.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RequestTimeInterval
Time interval.

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

### -RequestTracingEnabled
<code>true</code> if request tracing is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RequestTracingExpirationTime
Request tracing expiration time.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -ScmIPSecurityRestriction
IP security restrictions for scm.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IIPSecurityRestriction[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ScmType
SCM type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ScmType
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
Web app configuration ARM resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SlowRequestTimeInterval
Time interval.

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

### -SlowRequestTimeTaken
Time taken.

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

### -TagsRequiringAuth
Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.Tags can consist of alphanumeric characters and the following:'_', '@', '#', '.', ':', '-'.
Validation should be performed at the PushRequestHandler.

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

### -TagWhitelistJson
Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.

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

### -TracingOption
Tracing options.

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

### -TriggerPrivateBytesInKb
A rule based on private bytes.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TriggerStatusCode
A rule based on status codes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IStatusCodesBasedTrigger[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Use32BitWorkerProcess
<code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualApplication
Virtual applications.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IVirtualApplication[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WebSocketsEnabled
<code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowsFxVersion
Xenon App Framework and version

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

### -XManagedServiceIdentityId
Explicit Managed Service Identity Id

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigResource

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISiteConfigResource

## ALIASES

## RELATED LINKS

