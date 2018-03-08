---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
Module Name: AzureRM.Dns
ms.assetid: B78F3E8B-C7D2-458C-AB23-06F584FE97E0
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.dns/new-azurermdnszone
schema: 2.0.0
---

# New-AzureRmDnsZone

## SYNOPSIS
Creates a new DNS zone.

## SYNTAX

### VirtualNetworkIds (Default)
```
New-AzureRmDnsZone -Name <String> -ResourceGroupName <String> [-ZoneType <ZoneType>] [-Tag <Hashtable>]
 [-RegistrationVirtualNetworkIds <System.Collections.Generic.List`1[System.String]>]
 [-ResolutionVirtualNetworkIds <System.Collections.Generic.List`1[System.String]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VirtualNetworkObjects
```
New-AzureRmDnsZone -Name <String> -ResourceGroupName <String> [-ZoneType <ZoneType>] [-Tag <Hashtable>]
 [-RegistrationVirtualNetworks <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork]>]
 [-ResolutionVirtualNetworks <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDnsZone** cmdlet creates a new Domain Name System (DNS) zone in the specified
resource group. You must specify a unique DNS zone name for the *Name* parameter or the cmdlet will
return an error. After the zone is created, use the New-AzureRmDnsRecordSet cmdlet to create record
sets in the zone.

You can use the *Confirm* parameter and $ConfirmPreference Windows PowerShell variable to control
whether the cmdlet prompts you for confirmation.

## EXAMPLES

### Example 1: Create a DNS zone
```
PS C:\>$Zone = New-AzureRmDnsZone -Name "myzone.com" -ResourceGroupName "MyResourceGroup"
```

This command creates a new DNS zone named myzone.com in the specified resource group, and then
stores it in the $Zone variable.

### Example 2: Create a Private DNS zone by specifying virtual network IDs
```
PS C:\>$ResVirtualNetworkId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testresgroup/providers/Microsoft.Network/virtualNetworks/resvnet"
PS C:\>$Zone = New-AzureRmDnsZone -Name "myprivatezone.com" -ResourceGroupName "MyResourceGroup" -ZoneType Private -ResolutionVirtualNetworkIds @($ResVirtualNetworkId)
```

This command creates a new Private DNS zone named myprivatezone.com in the specified resource group with
an associated resolution virtual network (specifying its ID), and then stores it in the $Zone variable.

### Example 3: Create a Private DNS zone by specifying virtual network objects
```
PS C:\>$ResVirtualNetwork = Get-AzureRmVirtualNetwork -Name "resvnet" -ResourceGroupName "testresgroup"
PS C:\>$Zone = New-AzureRmDnsZone -Name "myprivatezone.com" -ResourceGroupName "MyResourceGroup" -ZoneType Private -ResolutionVirtualNetworks @($ResVirtualNetwork)
```

This command creates a new Private DNS zone named myprivatezone.com in the specified resource group with
an associated resolution virtual network (referred to by $ResVirtualNetwork variable), and then stores it
in the $Zone variable.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the DNS zone to create.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RegistrationVirtualNetworkIds
The list of virtual networks that will register virtual machine hostnames records in this DNS zone, only available for private zones.```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: VirtualNetworkIds
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RegistrationVirtualNetworks
The list of virtual networks that will register virtual machine hostnames records in this DNS zone, only available for private zones.```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork]
Parameter Sets: VirtualNetworkObjects
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResolutionVirtualNetworkIds
The list of virtual networks able to resolve records in this DNS zone, only available for private zones.```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: VirtualNetworkIds
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResolutionVirtualNetworks
The list of virtual networks able to resolve records in this DNS zone, only available for private zones.```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork]
Parameter Sets: VirtualNetworkObjects
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group in which to create the zone.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ZoneType
The type of the zone, Public or Private. Zones without a type or with a type of Public are made available on the public DNS serving plane for use in the DNS hierarchy. Zones with a type of Private are only visible from with the set of associated virtual networks (this feature is in preview). This property cannot be changed for a zone.

```yaml
Type: ZoneType
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
You cannot pipe input to this cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsZone
This cmdlet returns a Microsoft.Azure.Commands.Dns.DnsZone object that represents the new DNS zone.

## NOTES
You can use the *Confirm* parameter to control whether this cmdlet prompts you for confirmation.
By default, the cmdlet prompts you for confirmation if the $ConfirmPreference Windows PowerShell variable has a value of Medium or lower.

If you specify *Confirm* or *Confirm:$True*, this cmdlet prompts you for confirmation before it runs.
If you specify *Confirm:$False*, the cmdlet does not prompt you for confirmation.

## RELATED LINKS

[Get-AzureRmDnsZone](./Get-AzureRmDnsZone.md)

[New-AzureRmDnsRecordSet](./New-AzureRmDnsRecordSet.md)

[Remove-AzureRmDnsZone](./Remove-AzureRmDnsZone.md)
