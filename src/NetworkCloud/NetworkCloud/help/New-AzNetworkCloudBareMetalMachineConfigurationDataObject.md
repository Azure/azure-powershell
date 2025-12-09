---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudbaremetalmachineconfigurationdataobject
schema: 2.0.0
---

# New-AzNetworkCloudBareMetalMachineConfigurationDataObject

## SYNOPSIS
Create an in-memory object for BareMetalMachineConfigurationData.

## SYNTAX

```
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword <SecureString>
 -BmcCredentialsUsername <String> -BmcMacAddress <String> -BootMacAddress <String> -RackSlot <Int64>
 -SerialNumber <String> [-MachineDetail <String>] [-MachineName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BareMetalMachineConfigurationData.

## EXAMPLES

### Example 1: Create bare metal machine configuration object
```powershell
$password = ConvertTo-SecureString -String "P@ssw0rd123!" -AsPlainText -Force
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername "admin" -BmcMacAddress "00:1a:2b:3c:4d:5e" -BootMacAddress "00:1a:2b:3c:4d:5f" -RackSlot 1 -SerialNumber "ABC123DEF456" -MachineName "bmm-001"
```

```output
BmcCredentialsPassword      : System.Security.SecureString
BmcCredentialsUsername      : admin
BmcMacAddress               : 00:1a:2b:3c:4d:5e
BootMacAddress              : 00:1a:2b:3c:4d:5f
MachineDetail               : 
MachineName                 : bmm-001
RackSlot                    : 1
SerialNumber                : ABC123DEF456
```

This example creates a bare metal machine configuration object with BMC credentials and networking details.

### Example 2: Create bare metal machine configuration with additional details
```powershell
$password = ConvertTo-SecureString -String "SecurePass123!" -AsPlainText -Force
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername "bmc_admin" -BmcMacAddress "00:2b:3c:4d:5e:6f" -BootMacAddress "00:2b:3c:4d:5e:70" -RackSlot 2 -SerialNumber "XYZ789UVW012" -MachineName "bmm-002" -MachineDetail "Asset Tag: AT-12345"
```

```output
BmcCredentialsPassword      : System.Security.SecureString
BmcCredentialsUsername      : bmc_admin
BmcMacAddress               : 00:2b:3c:4d:5e:6f
BootMacAddress              : 00:2b:3c:4d:5e:70
MachineDetail               : Asset Tag: AT-12345
MachineName                 : bmm-002
RackSlot                    : 2
SerialNumber                : XYZ789UVW012
```

This example creates a configuration object with additional machine details and higher rack slot.

## PARAMETERS

### -BmcCredentialsPassword
The password of the administrator of the device used during initialization.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BmcCredentialsUsername
The username of the administrator of the device used during initialization.

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

### -BmcMacAddress
The MAC address of the BMC for this machine.

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

### -BootMacAddress
The MAC address associated with the PXE NIC card.

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

### -MachineDetail
The free-form additional information about the machine, e.g.
an asset tag.

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

### -MachineName
The user-provided name for the bare metal machine created from this specification.
If not provided, the machine name will be generated programmatically.

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

### -RackSlot
The slot the physical machine is in the rack based on the BOM configuration.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
The serial number of the machine.
Hardware suppliers may use an alternate value.
For example, service tag.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BareMetalMachineConfigurationData

## NOTES

## RELATED LINKS
