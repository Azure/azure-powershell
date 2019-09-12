---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/update-azappserviceenvironment
schema: 2.0.0
---

# Update-AzAppServiceEnvironment

## SYNOPSIS
Create or update an App Service Environment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppServiceEnvironment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ApiManagementAccountId <String>] [-ClusterSetting <INameValuePair[]>] [-DnsSuffix <String>]
 [-DynamicCacheEnabled] [-FrontEndScaleFactor <Int32>] [-HasLinuxWorker]
 [-InternalLoadBalancingMode <InternalLoadBalancingMode>] [-IpsslAddressCount <Int32>] [-Kind <String>]
 [-Location <String>] [-MultiRoleCount <Int32>] [-MultiSize <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesName <String>]
 [-SslCertKeyVaultId <String>] [-SslCertKeyVaultSecretName <String>] [-Suspended]
 [-UserWhitelistedIPRange <String[]>] [-VirtualNetworkId <String>] [-VirtualNetworkSubnet <String>]
 [-VnetName <String>] [-VnetResourceGroupName <String>] [-VnetSubnetName <String>]
 [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzAppServiceEnvironment -Name <String> -ResourceGroupName <String>
 -HostingEnvironmentEnvelope <IAppServiceEnvironmentPatchResource> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAppServiceEnvironment -InputObject <IAppServiceIdentity>
 -HostingEnvironmentEnvelope <IAppServiceEnvironmentPatchResource> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppServiceEnvironment -InputObject <IAppServiceIdentity> [-ApiManagementAccountId <String>]
 [-ClusterSetting <INameValuePair[]>] [-DnsSuffix <String>] [-DynamicCacheEnabled]
 [-FrontEndScaleFactor <Int32>] [-HasLinuxWorker] [-InternalLoadBalancingMode <InternalLoadBalancingMode>]
 [-IpsslAddressCount <Int32>] [-Kind <String>] [-Location <String>] [-MultiRoleCount <Int32>]
 [-MultiSize <String>] [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesName <String>]
 [-SslCertKeyVaultId <String>] [-SslCertKeyVaultSecretName <String>] [-Suspended]
 [-UserWhitelistedIPRange <String[]>] [-VirtualNetworkId <String>] [-VirtualNetworkSubnet <String>]
 [-VnetName <String>] [-VnetResourceGroupName <String>] [-VnetSubnetName <String>]
 [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update an App Service Environment.

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

### -ApiManagementAccountId
API Management Account associated with the App Service Environment.

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

### -ClusterSetting
Custom settings for changing the behavior of the App Service Environment.
To construct, see NOTES section for CLUSTERSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.INameValuePair[]
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

### -DnsSuffix
DNS suffix of the App Service Environment.

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

### -DynamicCacheEnabled
True/false indicating whether the App Service Environment is suspended.
The environment can be suspended e.g.
when the management endpoint is no longer available(most likely because NSG blocked the incoming traffic).

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

### -FrontEndScaleFactor
Scale factor for front-ends.

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

### -HasLinuxWorker
Flag that displays whether an ASE has linux workers or not

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

### -HostingEnvironmentEnvelope
ARM resource for a app service environment.
To construct, see NOTES section for HOSTINGENVIRONMENTENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceEnvironmentPatchResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InternalLoadBalancingMode
Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.InternalLoadBalancingMode
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IpsslAddressCount
Number of IP SSL addresses reserved for the App Service Environment.

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

### -Location
Location of the App Service Environment, e.g.
"West US".

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

### -MultiRoleCount
Number of front-end instances.

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

### -MultiSize
Front-end VM size, e.g.
"Medium", "Large".

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
Name of the App Service Environment.

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

### -NetworkAccessControlList
Access control list for controlling traffic to the App Service Environment.
To construct, see NOTES section for NETWORKACCESSCONTROLLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.INetworkAccessControlEntry[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### -PropertiesName
Name of the App Service Environment.

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

### -SslCertKeyVaultId
Key Vault ID for ILB App Service Environment default SSL certificate

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

### -SslCertKeyVaultSecretName
Key Vault Secret Name for ILB App Service Environment default SSL certificate

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

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Suspended
\<code\>true\</code\> if the App Service Environment is suspended; otherwise, \<code\>false\</code\>.
The environment can be suspended, e.g.
when the management endpoint is no longer available (most likely because NSG blocked the incoming traffic).

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

### -UserWhitelistedIPRange
User added ip ranges to whitelist on ASE db

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

### -VirtualNetworkId
Resource id of the Virtual Network.

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

### -VirtualNetworkSubnet
Subnet within the Virtual Network.

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

### -VnetName
Name of the Virtual Network for the App Service Environment.

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

### -VnetResourceGroupName
Resource group of the Virtual Network.

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

### -VnetSubnetName
Subnet of the Virtual Network.

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

### -WorkerPool
Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
To construct, see NOTES section for WORKERPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160301.IWorkerPool[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceEnvironmentPatchResource

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IAppServiceEnvironmentResource

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CLUSTERSETTING <INameValuePair[]>: Custom settings for changing the behavior of the App Service Environment.
  - `[Name <String>]`: Pair name.
  - `[Value <String>]`: Pair value.

#### HOSTINGENVIRONMENTENVELOPE <IAppServiceEnvironmentPatchResource>: ARM resource for a app service environment.
  - `Location <String>`: Location of the App Service Environment, e.g. "West US".
  - `PropertiesName <String>`: Name of the App Service Environment.
  - `WorkerPool <IWorkerPool[]>`: Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
    - `[ComputeMode <ComputeModeOptions?>]`: Shared or dedicated app hosting.
    - `[WorkerCount <Int32?>]`: Number of instances in the worker pool.
    - `[WorkerSize <String>]`: VM size of the worker pool instances.
    - `[WorkerSizeId <Int32?>]`: Worker size ID for referencing this worker pool.
  - `[Kind <String>]`: Kind of resource.
  - `[ApiManagementAccountId <String>]`: API Management Account associated with the App Service Environment.
  - `[ClusterSetting <INameValuePair[]>]`: Custom settings for changing the behavior of the App Service Environment.
    - `[Name <String>]`: Pair name.
    - `[Value <String>]`: Pair value.
  - `[DnsSuffix <String>]`: DNS suffix of the App Service Environment.
  - `[DynamicCacheEnabled <Boolean?>]`: True/false indicating whether the App Service Environment is suspended. The environment can be suspended e.g. when the management endpoint is no longer available         (most likely because NSG blocked the incoming traffic).
  - `[FrontEndScaleFactor <Int32?>]`: Scale factor for front-ends.
  - `[HasLinuxWorker <Boolean?>]`: Flag that displays whether an ASE has linux workers or not
  - `[InternalLoadBalancingMode <InternalLoadBalancingMode?>]`: Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.
  - `[IpsslAddressCount <Int32?>]`: Number of IP SSL addresses reserved for the App Service Environment.
  - `[MultiRoleCount <Int32?>]`: Number of front-end instances.
  - `[MultiSize <String>]`: Front-end VM size, e.g. "Medium", "Large".
  - `[NetworkAccessControlList <INetworkAccessControlEntry[]>]`: Access control list for controlling traffic to the App Service Environment.
    - `[Action <AccessControlEntryAction?>]`: Action object.
    - `[Description <String>]`: Description of network access control entry.
    - `[Order <Int32?>]`: Order of precedence.
    - `[RemoteSubnet <String>]`: Remote subnet.
  - `[SslCertKeyVaultId <String>]`: Key Vault ID for ILB App Service Environment default SSL certificate
  - `[SslCertKeyVaultSecretName <String>]`: Key Vault Secret Name for ILB App Service Environment default SSL certificate
  - `[Suspended <Boolean?>]`: <code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>. The environment can be suspended, e.g. when the management endpoint is no longer available          (most likely because NSG blocked the incoming traffic).
  - `[UserWhitelistedIPRange <String[]>]`: User added ip ranges to whitelist on ASE db
  - `[VirtualNetworkId <String>]`: Resource id of the Virtual Network.
  - `[VirtualNetworkSubnet <String>]`: Subnet within the Virtual Network.
  - `[VnetName <String>]`: Name of the Virtual Network for the App Service Environment.
  - `[VnetResourceGroupName <String>]`: Resource group of the Virtual Network.
  - `[VnetSubnetName <String>]`: Subnet of the Virtual Network.

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

#### NETWORKACCESSCONTROLLIST <INetworkAccessControlEntry[]>: Access control list for controlling traffic to the App Service Environment.
  - `[Action <AccessControlEntryAction?>]`: Action object.
  - `[Description <String>]`: Description of network access control entry.
  - `[Order <Int32?>]`: Order of precedence.
  - `[RemoteSubnet <String>]`: Remote subnet.

#### WORKERPOOL <IWorkerPool[]>: Description of worker pools with worker size IDs, VM sizes, and number of workers in each pool.
  - `[ComputeMode <ComputeModeOptions?>]`: Shared or dedicated app hosting.
  - `[WorkerCount <Int32?>]`: Number of instances in the worker pool.
  - `[WorkerSize <String>]`: VM size of the worker pool instances.
  - `[WorkerSizeId <Int32?>]`: Worker size ID for referencing this worker pool.

## RELATED LINKS

