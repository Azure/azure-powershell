---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudstorageapplianceconfigurationdataobject
schema: 2.0.0
---

# New-AzNetworkCloudStorageApplianceConfigurationDataObject

## SYNOPSIS
Create an in-memory object for StorageApplianceConfigurationData.

## SYNTAX

```
New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword <SecureString>
 -AdminCredentialsUsername <String> -RackSlot <Int64> -SerialNumber <String> [-StorageApplianceName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageApplianceConfigurationData.

## EXAMPLES

### Example 1: Create storage appliance configuration object
```powershell
$password = ConvertTo-SecureString -String "SecurePass123!" -AsPlainText -Force
New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername "admin" -SerialNumber "SA-001" -RackSlot 1 -StorageApplianceName "storageappliance1"
```

```output
AdminCredentialsPassword  : System.Security.SecureString
AdminCredentialsUsername  : admin
RackSlot                  : 1
SerialNumber              : SA-001
StorageApplianceName      : storageappliance1
```

This example creates a storage appliance configuration object with administrative credentials and placement information.

### Example 2: Create storage appliance configuration for different rack slot
```powershell
$password = ConvertTo-SecureString -String "AdminPassword456!" -AsPlainText -Force
New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername "sa_admin" -SerialNumber "SA-002" -RackSlot 2
```

```output
AdminCredentialsPassword  : System.Security.SecureString
AdminCredentialsUsername  : sa_admin
RackSlot                  : 2
SerialNumber              : SA-002
StorageApplianceName      : 
```

This example creates a storage appliance configuration for a different rack slot without specifying the appliance name.

## PARAMETERS

### -AdminCredentialsPassword
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

### -AdminCredentialsUsername
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

### -RackSlot
The slot that storage appliance is in the rack based on the BOM configuration.

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
The serial number of the appliance.

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

### -StorageApplianceName
The user-provided name for the storage appliance that will be created from this specification.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.StorageApplianceConfigurationData

## NOTES

## RELATED LINKS
