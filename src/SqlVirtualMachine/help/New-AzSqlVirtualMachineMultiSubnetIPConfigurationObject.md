---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/Az.SqlVirtualMachine/new-AzSqlVirtualMachineMultiSubnetIPConfigurationObject
schema: 2.0.0
---

# New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject

## SYNOPSIS
Create an in-memory object for MultiSubnetIPConfiguration.

## SYNTAX

```
New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -SqlVirtualMachineInstance <String>
 [-PrivateIPAddressIpaddress <String>] [-PrivateIPAddressSubnetResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MultiSubnetIPConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for multi subnet ip configuration
```powershell
$multiSubnetIpConfig = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetId -PrivateIPAddressIpaddress $IPAddress -SqlVirtualMachineInstance $SqlVMResourceId
$multiSubnetIpConfig | Format-List
```

```output
PrivateIPAddressIpaddress        : 192.168.16.7
PrivateIPAddressSubnetResourceId : 
SqlVirtualMachineInstance        : 
```

*New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject* creates an in-memory object of type *MultiSubnetIPConfiguration*.
This object represents a multi subnet ip configuration for an availability group listener.
It will be used for parameter *MultiSubnetIPConfiguration* in cmdlet *New-AzAvailabilityGroupListener*.

## PARAMETERS

### -PrivateIPAddressIpaddress
Private IP address bound to the availability group listener.

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

### -PrivateIPAddressSubnetResourceId
Subnet used to include private IP.

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

### -SqlVirtualMachineInstance
SQL virtual machine instance resource id that are enrolled into the availability group listener.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.MultiSubnetIPConfiguration

## NOTES

ALIASES

## RELATED LINKS

