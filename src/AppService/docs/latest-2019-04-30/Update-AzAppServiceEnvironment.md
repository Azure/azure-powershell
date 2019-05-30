---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/update-azappserviceenvironment
schema: 2.0.0
---

# Update-AzAppServiceEnvironment

## SYNOPSIS
Create or update an App Service Environment.

## SYNTAX

### Update (Default)
```
Update-AzAppServiceEnvironment -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-HostingEnvironmentEnvelope <IAppServiceEnvironmentPatchResource>] [-PassThru] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzAppServiceEnvironment -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Location <String> -PropertiesName <String> -WorkerPool <IWorkerPool[]> [-PassThru]
 [-ApiManagementAccountId <String>] [-ClusterSetting <INameValuePair[]>] [-DnsSuffix <String>]
 [-DynamicCacheEnabled] [-FrontEndScaleFactor <Int32>] [-HasLinuxWorker]
 [-InternalLoadBalancingMode <InternalLoadBalancingMode>] [-IpsslAddressCount <Int32>] [-Kind <String>]
 [-MultiRoleCount <Int32>] [-MultiSize <String>] [-NetworkAccessControlList <INetworkAccessControlEntry[]>]
 [-ProvisioningState <ProvisioningState>] [-SslCertKeyVaultId <String>] [-SslCertKeyVaultSecretName <String>]
 [-Status <HostingEnvironmentStatus>] [-Suspended] [-UserWhitelistedIPRange <String[]>]
 [-VirtualNetworkId <String>] [-VirtualNetworkSubnet <String>] [-VnetName <String>]
 [-VnetResourceGroupName <String>] [-VnetSubnetName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppServiceEnvironment -InputObject <IWebSiteIdentity> -Location <String> -PropertiesName <String>
 -WorkerPool <IWorkerPool[]> [-PassThru] [-ApiManagementAccountId <String>]
 [-ClusterSetting <INameValuePair[]>] [-DnsSuffix <String>] [-DynamicCacheEnabled]
 [-FrontEndScaleFactor <Int32>] [-HasLinuxWorker] [-InternalLoadBalancingMode <InternalLoadBalancingMode>]
 [-IpsslAddressCount <Int32>] [-Kind <String>] [-MultiRoleCount <Int32>] [-MultiSize <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-ProvisioningState <ProvisioningState>]
 [-SslCertKeyVaultId <String>] [-SslCertKeyVaultSecretName <String>] [-Status <HostingEnvironmentStatus>]
 [-Suspended] [-UserWhitelistedIPRange <String[]>] [-VirtualNetworkId <String>]
 [-VirtualNetworkSubnet <String>] [-VnetName <String>] [-VnetResourceGroupName <String>]
 [-VnetSubnetName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzAppServiceEnvironment -InputObject <IWebSiteIdentity>
 [-HostingEnvironmentEnvelope <IAppServiceEnvironmentPatchResource>] [-PassThru] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
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
Default value: False
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
Default value: 0
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostingEnvironmentEnvelope
ARM resource for a app service environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IAppServiceEnvironmentPatchResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InternalLoadBalancingMode
Specifies which endpoints to serve internally in the Virtual Network for the App Service Environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.InternalLoadBalancingMode
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
Default value: 0
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

Required: True
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
Default value: 0
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INetworkAccessControlEntry[]
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
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Provisioning state of the App Service Environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ProvisioningState
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

### -Status
Current status of the App Service Environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.HostingEnvironmentStatus
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

### -Suspended
<code>true</code> if the App Service Environment is suspended; otherwise, <code>false</code>.
The environment can be suspended, e.g.
when the management endpoint is no longer available (most likely because NSG blocked the incoming traffic).

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IWorkerPool[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IAppServiceEnvironmentPatchResource

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.IAppServiceEnvironmentResource

## ALIASES

## RELATED LINKS

