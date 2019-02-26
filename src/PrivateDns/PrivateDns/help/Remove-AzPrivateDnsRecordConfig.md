---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PrivateDns.dll-Help.xml
Module Name: Az.PrivateDns
online version:
schema: 2.0.0
---

# Remove-AzPrivateDnsRecordConfig

## SYNOPSIS
Removes a Private DNS record from a local record set object.

## SYNTAX

### A
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Ipv4Address <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AAAA
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Ipv6Address <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### MX
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Exchange <String> -Preference <UInt16>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PTR
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Ptrdname <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### TXT
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Value <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SRV
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Priority <UInt16> -Target <String>
 -Port <UInt16> -Weight <UInt16> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CNAME
```
Remove-AzPrivateDnsRecordConfig -RecordSet <PSPrivateDnsRecordSet> -Cname <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzPrivateDnsRecordConfig cmdlet removes a Private Domain Name System (DNS) record from a record set. The RecordSet object is an offline object, and changes to it do not change the Private DNS responses until after you run the Set-AzPrivateDnsRecordSet cmdlet to persist the change to the Microsoft Azure Private DNS service. To remove a record, all the fields for that record type must match exactly. You cannot add or remove SOA records. SOA records are automatically created when a Private DNS zone is created and automatically deleted when the Private DNS zone is deleted. You can pass the RecordSet object to this cmdlet as a parameter or by using the pipeline operator.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Cname
The canonical name of the CNAME record to remove.
Must not be relative to the name of the zone.
Must not have a terminating dot

```yaml
Type: String
Parameter Sets: CNAME
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Exchange
The mail exchange host of the MX record to remove.
Must not be relative to the name of the zone.
Must not have a terminating dot

```yaml
Type: String
Parameter Sets: MX
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv4Address
The IPv4 address of the A record to remove.

```yaml
Type: String
Parameter Sets: A
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6Address
The IPv6 address of the AAAA record to remove.

```yaml
Type: String
Parameter Sets: AAAA
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
The port number of the SRV record to remove.

```yaml
Type: UInt16
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Preference
The preference value of the MX record to remove.

```yaml
Type: UInt16
Parameter Sets: MX
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
The priority value of the SRV record to remove.

```yaml
Type: UInt16
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ptrdname
The target host of the PTR record to remove.
Must not be relative to the name of the zone.
Must not have a terminating dot

```yaml
Type: String
Parameter Sets: PTR
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecordSet
The record set from which to remove the record.

```yaml
Type: PSPrivateDnsRecordSet
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Target
The target host of the SRV record to remove.
Must not be relative to the name of the zone.
Must not have a terminating dot

```yaml
Type: String
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The text value of the TXT record to remove.

```yaml
Type: String
Parameter Sets: TXT
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
The weight value of the SRV record to remove.

```yaml
Type: UInt16
Parameter Sets: SRV
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.PrivateDns.Models.PSPrivateDnsRecordSet

## OUTPUTS

### Microsoft.Azure.Commands.PrivateDns.Models.PSPrivateDnsRecordSet

## NOTES

## RELATED LINKS
