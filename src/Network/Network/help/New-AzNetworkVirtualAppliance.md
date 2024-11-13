---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkvirtualappliance
schema: 2.0.0
---

# New-AzNetworkVirtualAppliance

## SYNOPSIS
Create a Network Virtual Appliance resource.

## SYNTAX

### ResourceNameParameterSet (Default)
```
New-AzNetworkVirtualAppliance -Name <String> -ResourceGroupName <String> -Location <String>
 -VirtualHubId <String> -Sku <PSVirtualApplianceSkuProperties> -VirtualApplianceAsn <Int32>
 [-Identity <PSManagedServiceIdentity>] [-BootStrapConfigurationBlob <String[]>]
 [-CloudInitConfigurationBlob <String[]>] [-CloudInitConfiguration <String>] [-Tag <Hashtable>] [-Force]
 [-AsJob] [-AdditionalNic <PSVirtualApplianceAdditionalNicProperties[]>]
 [-InternetIngressIp <PSVirtualApplianceInternetIngressIpsProperties[]>]
 [-NetworkProfile <PSVirtualApplianceNetworkProfile>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
New-AzNetworkVirtualAppliance -ResourceId <String> -Location <String> -VirtualHubId <String>
 -Sku <PSVirtualApplianceSkuProperties> -VirtualApplianceAsn <Int32> [-Identity <PSManagedServiceIdentity>]
 [-BootStrapConfigurationBlob <String[]>] [-CloudInitConfigurationBlob <String[]>]
 [-CloudInitConfiguration <String>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-AdditionalNic <PSVirtualApplianceAdditionalNicProperties[]>]
 [-InternetIngressIp <PSVirtualApplianceInternetIngressIpsProperties[]>]
 [-NetworkProfile <PSVirtualApplianceNetworkProfile>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkVirtualAppliance** command creates a Network Virtual Appliance(NVA) resource in Azure.

## EXAMPLES

### Example 1
```powershell
$sku=New-AzVirtualApplianceSkuProperty -VendorName "barracudasdwanrelease" -BundledScaleUnit 1 -MarketPlaceVersion 'latest'

$hub=Get-AzVirtualHub -ResourceGroupName testrg -Name hub

$nva=New-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -Location eastus2 -VirtualApplianceAsn 1270 -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo Hello World!"
```

Creates a new Network Virtual Appliance resource in resource group: testrg.

### Example 2
```powershell
$sku=New-AzVirtualApplianceSkuProperty -VendorName "ciscosdwantest" -BundledScaleUnit 4 -MarketPlaceVersion '17.6.03'

$hub=Get-AzVirtualHub -ResourceGroupName testrg -Name hub

$additionalNic=New-AzVirtualApplianceAdditionalNicProperty -NicName "sdwan" -HasPublicIp $true

$nva=New-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -Location eastus2 -VirtualApplianceAsn 65222 -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo Hello World!" -AdditionalNic $additionalNic
```

Creates a new Network Virtual Appliance resource in resource group: testrg with additional nic "sdwan" and a public IP attached to "sdwan" nic.

### Example 3
```powershell
$sku=New-AzVirtualApplianceSkuProperty -VendorName "ciscosdwantest" -BundledScaleUnit 4 -MarketPlaceVersion '17.6.03'
$hub=Get-AzVirtualHub -ResourceGroupName testrg -Name hub
$id1 = "/subscriptions/{subscriptionid}/resourceGroups/testrg/providers/Microsoft.Network/publicIPAddresses/{publicip1name}"
$pip2 = Get-AzPublicIpAddress -Name publicip2name
$id2 = $pip2.Id
$IngressIps=New-AzVirtualApplianceInternetIngressIpsProperty -InternetIngressPublicIpId $id1, $id2
$nva=New-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -Location eastus2 -VirtualApplianceAsn 65222 -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo Hello World!" -InternetIngressIp $IngressIps
```

Creates a new Network Virtual Appliance resource in resource group: testrg with 2 Internet Ingress Public IPs attached to it.

### Example 4
```powershell
$sku = New-AzVirtualApplianceSkuProperty -VendorName "ciscosdwantest" -BundledScaleUnit 4 -MarketPlaceVersion '17.6.03'
$hub = Get-AzVirtualHub -ResourceGroupName testrg -Name hub

$ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
$ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig-2" -Primary $false
$nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfiguration $ipConfig1, $ipConfig2

$ipConfig3 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig" -Primary $true
$ipConfig4 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig-2" -Primary $false
$nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfiguration $ipConfig3, $ipConfig4
$networkProfile = New-AzVirtualApplianceNetworkProfile -NetworkInterfaceConfiguration $nicConfig1, $nicConfig2

$nva = New-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -Location eastus2 -VirtualApplianceAsn 65222 -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo Hello World!" -NetworkProfile $networkProfile
```

Creates a new Network Virtual Appliance resource in resource group: testrg with network profile containing 2 IP configurations on both network interfaces.

## PARAMETERS

### -AdditionalNic
The AdditionalNic Properties of the Virtual Appliance.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceAdditionalNicProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

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

### -BootStrapConfigurationBlob
The Bootstrap configuration blob URL.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CloudInitConfiguration
The Cloudinit configuration as plain text.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CloudInitConfigurationBlob
The Cloudinit configuration blob storage URL.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Identity
The Managed identity.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSManagedServiceIdentity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InternetIngressIp
The Internet Ingress IPs to be attached to the Virtual Appliance.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceInternetIngressIpsProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The public IP address location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkProfile
The Network Profile to be attached to the Virtual Appliance.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceNetworkProfile
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku
The Sku of the Virtual Appliance.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceSkuProperties
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualApplianceAsn
The ASN number of the Virtual Appliance.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualHubId
The Resource Id of the Virtual Hub.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceSkuProperties

### System.Int32

### Microsoft.Azure.Commands.Network.Models.PSManagedServiceIdentity

### System.String[]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance

## NOTES

## RELATED LINKS
