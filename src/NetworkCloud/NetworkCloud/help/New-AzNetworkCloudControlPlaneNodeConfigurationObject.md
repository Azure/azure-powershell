---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudcontrolplanenodeconfigurationobject
schema: 2.0.0
---

# New-AzNetworkCloudControlPlaneNodeConfigurationObject

## SYNOPSIS
Create an in-memory object for ControlPlaneNodeConfiguration.

## SYNTAX

```
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count <Int64>
 [-AdministratorConfigurationAdminUsername <String>]
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-AvailabilityZone <String[]>]
 [-VMSkuName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ControlPlaneNodeConfiguration.

## EXAMPLES

### Example 1: Create control plane node configuration with default settings
```powershell
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count 3 -VMSkuName "Standard_D8s_v5"
```

```output
AdministratorConfigurationAdminUsername : 
AdministratorConfigurationSshPublicKey  : {}
AvailabilityZone                        : {}
Count                                   : 3
VMSkuName                               : Standard_D8s_v5
```

This example creates a control plane node configuration with 3 nodes using the specified VM SKU.

### Example 2: Create control plane configuration with admin settings and availability zones
```powershell
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count 5 -AdministratorConfigurationAdminUsername "azureuser" -AvailabilityZone @("1","2","3") -VMSkuName "Standard_D16s_v5"
```

```output
AdministratorConfigurationAdminUsername : azureuser
AdministratorConfigurationSshPublicKey  : {}
AvailabilityZone                        : {1, 2, 3}
Count                                   : 5
VMSkuName                               : Standard_D16s_v5
```

This example creates a control plane configuration with specific availability zones and administrator settings.

## PARAMETERS

### -AdministratorConfigurationAdminUsername
The user name for the administrator that will be applied to the operating systems that run Kubernetes nodes.
If not supplied, a user name will be chosen by the service.

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

### -AdministratorConfigurationSshPublicKey
The SSH configuration for the operating systems that run the nodes in the Kubernetes cluster.
In some cases, specification of public keys may be required to produce a working environment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ISshPublicKey[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
The list of availability zones of the Network Cloud cluster to be used for the provisioning of nodes in the control plane.
If not specified, all availability zones will be used.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
The number of virtual machines that use this configuration.

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

### -VMSkuName
The name of the VM SKU supplied during creation.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.ControlPlaneNodeConfiguration

## NOTES

## RELATED LINKS
