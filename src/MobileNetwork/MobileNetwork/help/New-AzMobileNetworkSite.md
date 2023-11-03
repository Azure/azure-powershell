---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/new-azmobilenetworksite
schema: 2.0.0
---

# New-AzMobileNetworkSite

## SYNOPSIS
Creates or updates a mobile network site.
Must be created in the same location as its parent mobile network.

## SYNTAX

```
New-AzMobileNetworkSite -MobileNetworkName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-DataNetworkName <String>] [-SubscriptionId <String>] [-AzureStackEdgeDeviceId <String>]
 [-ControlPlaneAccessInterfaceIpv4Address <String>] [-ControlPlaneAccessInterfaceIpv4Gateway <String>]
 [-ControlPlaneAccessInterfaceIpv4Subnet <String>] [-ControlPlaneAccessInterfaceName <String>]
 [-CoreNetworkTechnology <CoreNetworkType>] [-CustomLocationId <String>] [-DnsAddress <String[]>]
 [-LocalDiagnosticAccessAuthenticationType <AuthenticationType>] [-NaptConfigurationEnabled <NaptEnabled>]
 [-PlatformType <PlatformType>] [-Sku <BillingSku>] [-Tag <Hashtable>]
 [-UserEquipmentAddressPoolPrefix <String[]>] [-UserEquipmentStaticAddressPoolPrefix <String[]>]
 [-UserPlaneAccessInterfaceIpv4Address <String>] [-UserPlaneAccessInterfaceIpv4Gateway <String>]
 [-UserPlaneAccessInterfaceIpv4Subnet <String>] [-UserPlaneAccessInterfaceName <String>]
 [-UserPlaneDataInterfaceIpv4Address <String>] [-UserPlaneDataInterfaceIpv4Gateway <String>]
 [-UserPlaneDataInterfaceIpv4Subnet <String>] [-UserPlaneDataInterfaceName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a mobile network site.
Must be created in the same location as its parent mobile network.

## EXAMPLES

### Example 1: Creates or updates a mobile network site.
```powershell
New-AzMobileNetworkSite -MobileNetworkName azps-mn -Name azps-mn-site -ResourceGroupName azps_test_group -Location eastus -Tag @{"site"="123"}
```

```output
Location Name         ResourceGroupName ProvisioningState
-------- ----         ----------------- -----------------
eastus   azps-mn-site azps_test_group   Succeeded
```

Creates or updates a mobile network site.
Must be created in the same location as its parent mobile network.

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

### -DataNetworkName
New-AzMobileNetworkDataNetwork
The name of the data network.

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

### -DnsAddress
New-AzMobileNetworkAttachedDataNetwork
The DNS servers to signal to UEs to use for this attached data network.
This configuration is mandatory - if you don't want DNS servers, you must provide an empty array.

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

### -LocalDiagnosticAccessAuthenticationType
How to authenticate users who access local diagnostics APIs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.AuthenticationType
Parameter Sets: (All)
Aliases:

Required: False
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

### -MobileNetworkName
The name of the mobile network.

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
The name of the mobile network site.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SiteName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NaptConfigurationEnabled
Whether NAPT is enabled for connections to this attached data network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled
Parameter Sets: (All)
Aliases:

Required: False
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
New-AzMobileNetworkPacketCoreControlPlane
The platform type where packet core is deployed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.PlatformType
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

### -UserEquipmentAddressPoolPrefix
The user equipment (UE) address pool prefixes for the attached data network from which the packet core instance will dynamically assign IP addresses to UEs.The packet core instance assigns an IP address to a UE when the UE sets up a PDU session.
You must define at least one of userEquipmentAddressPoolPrefix and userEquipmentStaticAddressPoolPrefix.
If you define both, they must be of the same size.

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

### -UserEquipmentStaticAddressPoolPrefix
The user equipment (UE) address pool prefixes for the attached data network from which the packet core instance will assign static IP addresses to UEs.The packet core instance assigns an IP address to a UE when the UE sets up a PDU session.
The static IP address for a specific UE is set in StaticIPConfiguration on the corresponding SIM resource.At least one of userEquipmentAddressPoolPrefix and userEquipmentStaticAddressPoolPrefix must be defined.
If both are defined, they must be of the same size.

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

### -UserPlaneAccessInterfaceIpv4Address
New-AzMobileNetworkPacketCoreDataPlane
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

### -UserPlaneAccessInterfaceIpv4Gateway
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

### -UserPlaneAccessInterfaceIpv4Subnet
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

### -UserPlaneAccessInterfaceName
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

### -UserPlaneDataInterfaceIpv4Address
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

### -UserPlaneDataInterfaceIpv4Gateway
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

### -UserPlaneDataInterfaceIpv4Subnet
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

### -UserPlaneDataInterfaceName
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISite

## NOTES

ALIASES

## RELATED LINKS

