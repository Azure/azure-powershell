---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
ms.assetid: 99E6C4DD-11AF-4DC0-848B-39811240BE06
online version: 
schema: 2.0.0
---

# Set-AzureRmDnsRecordSet

## SYNOPSIS
Updates a DNS record set.

## SYNTAX

```
Set-AzureRmDnsRecordSet -RecordSet <DnsRecordSet> [-Overwrite] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDnsRecordSet** cmdlet updates a record set in the Azure DNS service from a local **RecordSet** object.

You can pass a **RecordSet** object as a parameter or by using the pipeline operator.

You can use the *Confirm* parameter and $ConfirmPreference Windows PowerShell variable to control whether the cmdlet prompts you for confirmation.

The record set is not updated if it has been changed in Azure DNS since the local **RecordSet** object was retrieved.
This provides protection for concurrent changes.
You can suppress this behavior using the *Overwrite* parameter, which updates the record set regardless of concurrent changes.

## EXAMPLES

### Example 1: Update a record set
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -ResourceGroupName MyResourceGroup -ZoneName myzone.com -Name www -RecordType A
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Ipv4Address 172.16.0.0
PS C:\> Add-AzureRmDnsRecordConfig -RecordSet $RecordSet -Ipv4Address 172.31.255.255
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet

# These cmdlets can also be piped:

PS C:\> Get-AzureRmDnsRecordSet -ResourceGroupName MyResourceGroup -ZoneName myzone.com -Name www -RecordType A | Add-AzureRmDnsRecordConfig -Ipv4Address 172.16.0.0 | Add-AzureRmDnsRecordConfig -Ipv4Address 172.31.255.255 | Set-AzureRmDnsRecordSet
```

The first command uses the Get-AzureRmDnsRecordSet cmdlet to get the specified record set, and then stores it in the $RecordSet variable.

The second and third commands are off-line operations to add two A records to the record set.

The final command uses the **Set-AzureRmDnsRecordSet** cmdlet to commit the update.

### Example 2: Update an SOA record
```
PS C:\>$RecordSet = Get-AzureRmDnsRecordSet -Name "@" -RecordType SOA -Zone $Zone
PS C:\> $RecordSet.Records[0].Email = "admin.myzone.com"
PS C:\> Set-AzureRmDnsRecordSet -RecordSet $RecordSet
```

The first command uses the **Get-AzureRmDnsRecordset** cmdlet to get the specified record set, and then stores it in the $RecordSet variable.

The second command updates the specified SOA record in $RecordSet.

The final command uses the **Set-AzureRmDnsRecordSet** cmdlet to propagate the update in $RecordSet.

## PARAMETERS

### -Overwrite
Indicates to update the record set regardless of concurrent changes.

The record set will not be updated if it has been changed in Azure DNS since the local **RecordSet** object was retrieved.
This provides protection for concurrent changes.
To suppress this behavior, you can use the *Overwrite* parameter, which results in the record set being updated regardless of concurrent changes.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecordSet
Specifies the **RecordSet** to update.

```yaml
Type: DnsRecordSet
Parameter Sets: (All)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet
You can pass a **RecordSet** object to this cmdlet.

## OUTPUTS

### Microsoft.Azure.Commands.Dns.DnsRecordSet
This cmdlet returns an object that represents the updated **RecordSet** object.

## NOTES
You can use the *Confirm* parameter to control whether this cmdlet prompts you for confirmation.
By default, the cmdlet prompts you for confirmation if the $ConfirmPreference Windows PowerShell variable has a value of Medium or lower.

If you specify *Confirm* or *Confirm:$True*, this cmdlet prompts you for confirmation before it runs.
If you specify *Confirm:$False*, the cmdlet does not prompt you for confirmation. 

## RELATED LINKS

[Get-AzureRmDnsRecordSet](./Get-AzureRmDnsRecordSet.md)

[New-AzureRmDnsRecordSet](./New-AzureRmDnsRecordSet.md)

[Remove-AzureRmDnsRecordSet](./Remove-AzureRmDnsRecordSet.md)
