---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/new-azmobilenetworkpacketcorecontrolplane
schema: 2.0.0
---

# New-AzMobileNetworkPacketCoreControlPlane

## SYNOPSIS
Creates or updates a packet core control plane.

## SYNTAX

```
New-AzMobileNetworkPacketCoreControlPlane -Name <String> -ResourceGroupName <String>
 -LocalDiagnosticAccessAuthenticationType <AuthenticationType> -Location <String> -PlatformType <PlatformType>
 -Site <ISiteResourceId[]> -Sku <BillingSku> [-SubscriptionId <String>] [-AzureStackEdgeDeviceId <String>]
 [-AzureStackHciClusterId <String>] [-ConnectedClusterId <String>]
 [-ControlPlaneAccessInterfaceIpv4Address <String>] [-ControlPlaneAccessInterfaceIpv4Gateway <String>]
 [-ControlPlaneAccessInterfaceIpv4Subnet <String>] [-ControlPlaneAccessInterfaceName <String>]
 [-CoreNetworkTechnology <CoreNetworkType>] [-CustomLocationId <String>] [-HttpsServerCertificateUrl <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-InteropSetting <Hashtable>] [-Tag <Hashtable>] [-UeMtu <Int32>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a packet core control plane.

## EXAMPLES

### Example 1: Creates or updates a packet core control plane.
```powershell
$siteResourceId = New-AzMobileNetworkSiteResourceIdObject -Id /subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/sites/azps-mn-site

New-AzMobileNetworkPacketCoreControlPlane -Name azps-mn-pccp -ResourceGroupName azps_test_group -LocalDiagnosticAccessAuthenticationType Password -Location eastus -PlatformType AKS-HCI -Site $siteResourceId -Sku G0 -ControlPlaneAccessInterfaceIpv4Address 192.168.1.10 -ControlPlaneAccessInterfaceIpv4Gateway 192.168.1.1 -ControlPlaneAccessInterfaceIpv4Subnet 192.168.1.0/24 -ControlPlaneAccessInterfaceName N2 -CoreNetworkTechnology 5GC
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Creates or updates a packet core control plane.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -AzureStackEdgeDeviceId
Azure Stack Edge device resource ID.

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

### -AzureStackHciClusterId
Azure Stack HCI cluster resource ID.

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

### -ConnectedClusterId
Azure Arc connected cluster resource ID.

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

### -ControlPlaneAccessInterfaceIpv4Address
The IPv4 address.

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

### -ControlPlaneAccessInterfaceIpv4Gateway
The default IPv4 gateway (router).

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

### -ControlPlaneAccessInterfaceIpv4Subnet
The IPv4 subnet.

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

### -ControlPlaneAccessInterfaceName
The logical name for this interface.
This should match one of the interfaces configured on your Azure Stack Edge device.

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

### -CoreNetworkTechnology
The core network technology generation (5G core or EPC / 4G core).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.CoreNetworkType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomLocationId
Azure Arc custom location resource ID.

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

### -HttpsServerCertificateUrl
The certificate URL, unversioned.
For example: https://contosovault.vault.azure.net/certificates/ingress.

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
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -InteropSetting
Settings to allow interoperability with third party components e.g.
RANs and UEs.

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

### -LocalDiagnosticAccessAuthenticationType
How to authenticate users who access local diagnostics APIs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.AuthenticationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the packet core control plane.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PacketCoreControlPlaneName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PlatformType
The platform type where packet core is deployed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.PlatformType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Site
Site(s) under which this packet core control plane should be deployed.
The sites must be in the same location as the packet core control plane.
To construct, see NOTES section for SITE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISiteResourceId[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU defining the throughput and SIM allowances for this packet core control plane deployment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.BillingSku
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -UeMtu
The MTU (in bytes) signaled to the UE.
The same MTU is set on the user plane data links for all data networks.
The MTU set on the user plane access link is calculated to be 60 bytes greater than this value to allow for GTP encapsulation.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version of the packet core software that is deployed.

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPacketCoreControlPlane

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SITE <ISiteResourceId[]>: Site(s) under which this packet core control plane should be deployed. The sites must be in the same location as the packet core control plane.
  - `Id <String>`: Site resource ID.

## RELATED LINKS

