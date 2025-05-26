---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworkpacketcorecontrolplane
schema: 2.0.0
---

# Update-AzMobileNetworkPacketCoreControlPlane

## SYNOPSIS
update a packet core control plane.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMobileNetworkPacketCoreControlPlane -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AzureStackEdgeDeviceId <String>] [-AzureStackHciClusterId <String>]
 [-ConnectedClusterId <String>] [-ControlPlaneAccessInterfaceIpv4Address <String>]
 [-ControlPlaneAccessInterfaceIpv4Gateway <String>] [-ControlPlaneAccessInterfaceIpv4Subnet <String>]
 [-ControlPlaneAccessInterfaceName <String>] [-CoreNetworkTechnology <String>] [-CustomLocationId <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-HttpsServerCertificateUrl <String>]
 [-InteropSetting <Hashtable>] [-LocalDiagnosticAccessAuthenticationType <String>] [-PlatformType <String>]
 [-Site <ISiteResourceId[]>] [-Sku <String>] [-Tag <Hashtable>] [-UeMtu <Int32>]
 [-UserAssignedIdentity <String[]>] [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMobileNetworkPacketCoreControlPlane -InputObject <IMobileNetworkIdentity>
 [-AzureStackEdgeDeviceId <String>] [-AzureStackHciClusterId <String>] [-ConnectedClusterId <String>]
 [-ControlPlaneAccessInterfaceIpv4Address <String>] [-ControlPlaneAccessInterfaceIpv4Gateway <String>]
 [-ControlPlaneAccessInterfaceIpv4Subnet <String>] [-ControlPlaneAccessInterfaceName <String>]
 [-CoreNetworkTechnology <String>] [-CustomLocationId <String>] [-EnableSystemAssignedIdentity <Boolean?>]
 [-HttpsServerCertificateUrl <String>] [-InteropSetting <Hashtable>]
 [-LocalDiagnosticAccessAuthenticationType <String>] [-PlatformType <String>] [-Site <ISiteResourceId[]>]
 [-Sku <String>] [-Tag <Hashtable>] [-UeMtu <Int32>] [-UserAssignedIdentity <String[]>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a packet core control plane.

## EXAMPLES

### Example 1: Updates packet core control planes.
```powershell
Update-AzMobileNetworkPacketCoreControlPlane -PacketCoreControlPlaneName azps-mn-pccp -ResourceGroupName azps_test_group -Tag @{"abc"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-pccp azps_test_group   Succeeded
```

Updates packet core control planes.

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
Type: System.String
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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the packet core control plane.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.ISiteResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU defining the throughput and SIM allowances for this packet core control plane deployment.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IPacketCoreControlPlane

## NOTES

## RELATED LINKS

