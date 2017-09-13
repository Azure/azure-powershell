---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: E37ADC54-A37B-41BF-BE94-9E4052C234BB
online version:
schema: 2.0.0
---

# Set-AzureRmDnsZone

## SYNOPSIS
Updates the properties of a DNS zone.

## SYNTAX

### Fields
```
Set-AzureRmDnsZone -Name <String> -ResourceGroupName <String> [-Tag <Hashtable>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Object
```
Set-AzureRmDnsZone -Zone <DnsZone> [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDnsZone** cmdlet updates the specified DNS zone in the Azure DNS service.
This cmdlet does not update the record sets in the zone.

You can pass a **DnsZone** object as a parameter or by using the pipeline operator, or alternatively you can specify the *ZoneName* and *ResourceGroupName* parameters.

You can use the *Confirm* parameter and $ConfirmPreference Windows PowerShell variable to control whether the cmdlet prompts you for confirmation.

When passing a DNS zone as an object (using the Zone object or via the pipeline), it is not updated if it has been changed in Azure DNS since the local DnsZone object was retrieved.
This provides protection for concurrent changes.
You can suppress this behavior with the *Overwrite* parameter, which updates the zone regardless of concurrent changes.

## EXAMPLES

### Example 1: Update a DNS zone
```
PS C:\>$Zone = Get-AzureRmDnsZone -Name "myzone.com" -ResourceGroupName "MyResourceGroup"
PS C:\> $Zone.Tags = @(@{"Name"="Dept"; "Value"="Electrical"})
PS C:\> Set-AzureRmDnsZone -Zone $Zone
```

The first command gets the zone named myzone.com from the specified resource group, and then stores it in the $Zone variable.

The second command updates the tags for $Zone.

The final command commits the change.

### Example 2: Update tags for a zone
```
PS C:\>Set-AzureRmDNSZone -ResourceGroupName "MyResourceGroup" -Name "myzone.com" -Tag @(@{"Name"="Dept"; "Value"="Electrical"})
```

This command updates the tags for the zone named myzone.com without first explicitly getting the zone.

### Example 3: Associating a private zone with a virtual network
```
PS C:\>$vnet = Get-AzureRmVirualNetwork -ResourceGroupName "MyResourceGroup" -Name "myvnet"
PS C:\>Set-AzureRmDNSZone -ResourceGroupName "MyResourceGroup" -Name "myzone.com" -AssociatedVnet @($vnet.Id) -RegisteringVnets @($vnet.Id)
```

This command associates the DNS zone with the virtual network and created DNS records for VMs in the virtual network in the zone.

## PARAMETERS

### -Name
Specifies the name of the DNS zone to update.

```yaml
Type: String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Overwrite
When passing a DNS zone as an object (using the Zone object or via the pipeline), it is not updated if it has been changed in Azure DNS since the local DnsZone object was retrieved.
This provides protection for concurrent changes.
You can suppress this behavior with the *Overwrite* parameter, which updates the zone regardless of concurrent changes.

```yaml
Type: SwitchParameter
Parameter Sets: Object
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the zone to update.
You must also specify the ZoneName parameter.

Alternatively, you can specify the zone using a DnsZone object with the *Zone* parameter or the pipeline.

```yaml
Type: String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies an array of tags to associate with the DNS zone.
Tags are name-value pairs that are represented as hashtables, for instance, @(@{"Name"="dept"; "Value"="shopping"}, @{"Name"="env"; "Value"="production"})

```yaml
Type: Hashtable
Parameter Sets: Fields
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
Specifies the DNS zone to update.

Alternatively, you can specify the zone using the *ZoneName* and *ResourceGroupName* parameters.

```yaml
Type: DnsZone
Parameter Sets: Object
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -AssociatedVnet
Specified the list of virtual networks in which the DNS zone is visible.  Only applicable to Private DNS Zones. 

```yaml
Type: Array of Virtual Network IDs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegisteringVnet
Specified the list of virtual networks that register hostnames in this DNS zone.  Only applicable to Private DNS Zones. 

```yaml
Type: Array of Virtual Network IDs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Dns.DnsZone
You can pipe a DnsZone object to this cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsZone
This cmdlet returns a DnsZone object that represents the updated DNS zone with a new Etag.

## NOTES
You can use the *Confirm* parameter to control whether this cmdlet prompts you for confirmation.
By default, the cmdlet prompts you for confirmation if the $ConfirmPreference Windows PowerShell variable has a value of Medium or lower.

If you specify *Confirm* or *Confirm:$True*, this cmdlet prompts you for confirmation before it runs.
If you specify *Confirm:$False*, the cmdlet does not prompt you for confirmation. 


## RELATED LINKS

[Get-AzureRmDnsZone](./Get-AzureRmDnsZone.md)

[New-AzureRmDnsZone](./New-AzureRmDnsZone.md)

[Remove-AzureRmDnsZone](./Remove-AzureRmDnsZone.md)
