---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetworkappliance
schema: 2.0.0
---

# New-AzVirtualNetworkAppliance

## SYNOPSIS
Creates a new Virtual Network Appliance (VNA) resource.

## SYNTAX

```
New-AzVirtualNetworkAppliance -Name <String> -ResourceGroupName <String> -Location <String> -SubnetId <String>
 -BandwidthInGbps <String> [-Tag <Hashtable>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualNetworkAppliance cmdlet creates a new Virtual Network Appliance resource in Azure.
A Virtual Network Appliance is a network device that provides network functions such as firewalling, 
load balancing, or routing within a virtual network.

## EXAMPLES

### Example 1: Create a Virtual Network Appliance
```powershell
$subnet = Get-AzVirtualNetworkSubnetConfig -Name "VirtualNetworkApplianceSubnet" -VirtualNetwork (Get-AzVirtualNetwork -Name "myVnet" -ResourceGroupName "myResourceGroup")
New-AzVirtualNetworkAppliance -Name "myVNA" -ResourceGroupName "myResourceGroup" -Location "eastus" -SubnetId $subnet.Id -BandwidthInGbps "50"
```

Creates a new Virtual Network Appliance named "myVNA" in the specified subnet with 50 Gbps bandwidth.

### Example 2: Create a Virtual Network Appliance with tags
```powershell
$subnet = Get-AzVirtualNetworkSubnetConfig -Name "VirtualNetworkApplianceSubnet" -VirtualNetwork (Get-AzVirtualNetwork -Name "myVnet" -ResourceGroupName "myResourceGroup")
New-AzVirtualNetworkAppliance -Name "myVNA" -ResourceGroupName "myResourceGroup" -Location "eastus" -SubnetId $subnet.Id -BandwidthInGbps "100" -Tag @{"Environment" = "Production"}
```

Creates a new Virtual Network Appliance with 100 Gbps bandwidth and a tag.

## PARAMETERS

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

### -BandwidthInGbps
Bandwidth of the Virtual Network Appliance in Gbps. Valid values are: 50, 100, 200.

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

### -Location
The location.

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
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -SubnetId
The subnet resource ID for the Virtual Network Appliance. The subnet must be named "VirtualNetworkApplianceSubnet".

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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkAppliance

## NOTES

## RELATED LINKS
