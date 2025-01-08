---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudControlPlaneNodeConfigurationObject
schema: 2.0.0
---

# New-AzNetworkCloudControlPlaneNodeConfigurationObject

## SYNOPSIS
Create an in-memory object for ControlPlaneNodeConfiguration.

## SYNTAX

```
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count <Int64> -VMSkuName <String>
 [-AdministratorConfigurationAdminUsername <String>]
 [-AdministratorConfigurationSshPublicKey <ISshPublicKey[]>] [-AvailabilityZone <String[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ControlPlaneNodeConfiguration.

## EXAMPLES

### Example 1: Create an in-memory object for ControlPlaneNodeConfiguration.
```powershell
$sshPublicKey=@{
    keyData= "ssh-rsa"
}
New-AzNetworkCloudControlPlaneNodeConfigurationObject -Count 1 -VMSkuName vmSkuName -AdministratorConfigurationAdminUsername userName -AdministratorConfigurationSshPublicKey $sshPublicKey -AvailabilityZone @("1","2","3")
```

```output
AvailabilityZone Count VMSkuName
---------------- ----- ---------
{1, 2, 3}        1     vmSkuName
```

Create an in-memory object for ControlPlaneNodeConfiguration.

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
To construct, see NOTES section for ADMINISTRATORCONFIGURATIONSSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ISshPublicKey[]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.ControlPlaneNodeConfiguration

## NOTES

## RELATED LINKS
