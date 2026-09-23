---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudl3networkattachmentconfigurationobject
schema: 2.0.0
---

# New-AzNetworkCloudL3NetworkAttachmentConfigurationObject

## SYNOPSIS
Create an in-memory object for L3NetworkAttachmentConfiguration.

## SYNTAX

```
New-AzNetworkCloudL3NetworkAttachmentConfigurationObject -NetworkId <String> [-IpamEnabled <String>]
 [-PluginType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for L3NetworkAttachmentConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for L3NetworkAttachmentConfiguration.
```powershell
New-AzNetworkCloudL3NetworkAttachmentConfigurationObject -NetworkId '/subscriptions/{subscriptionId}/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3network-502' -IpamEnabled True -PluginType 'SRIOV'
```

```output
IpamEnabled NetworkId                                                                                                                  PluginType
----------- ---------                                                                                                                  ----------
True        /subscriptions/{subscriptionId}/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3network-502 SRIOV
```

Create an in-memory object for L3NetworkAttachmentConfiguration.

## PARAMETERS

### -IpamEnabled
The indication of whether this network will or will not perform IP address management and allocate IP addresses when attached.

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

### -NetworkId
The resource ID of the network that is being configured for attachment.

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

### -PluginType
The indicator of how this network will be utilized by the Kubernetes cluster.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.L3NetworkAttachmentConfiguration

## NOTES

## RELATED LINKS
