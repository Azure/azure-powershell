---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilescache
schema: 2.0.0
---

# New-AzNetAppFilesCache

## SYNOPSIS
Creates a new Azure NetApp Files (ANF) Cache (FlexCache) in a Capacity Pool.

## SYNTAX

### ByFieldsParameterSet (Default)
```
New-AzNetAppFilesCache -ResourceGroupName <String> -Location <String> -AccountName <String> -PoolName <String>
 -Name <String> -FilePath <String> -Size <Int64> -CacheSubnetResourceId <String>
 -PeeringSubnetResourceId <String> -EncryptionKeySource <String> -OriginPeerClusterName <String>
 -OriginPeerAddress <String[]> -OriginPeerVserverName <String> -OriginPeerVolumeName <String>
 [-ProtocolType <String[]>] [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-KerberosEnabled <String>]
 [-ThroughputMibps <Double>] [-KeyVaultPrivateEndpointResourceId <String>] [-Ldap <String>]
 [-LdapServerType <String>] [-CifsChangeNotification <String>] [-GlobalFileLocking <String>]
 [-WriteBack <String>] [-SmbEncryption <String>] [-SmbAccessBasedEnumeration <String>]
 [-SmbNonBrowsable <String>] [-Zone <String[]>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzNetAppFilesCache -Name <String> -FilePath <String> -Size <Int64> -CacheSubnetResourceId <String>
 -PeeringSubnetResourceId <String> -EncryptionKeySource <String> -OriginPeerClusterName <String>
 -OriginPeerAddress <String[]> -OriginPeerVserverName <String> -OriginPeerVolumeName <String>
 [-ProtocolType <String[]>] [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-KerberosEnabled <String>]
 [-ThroughputMibps <Double>] [-KeyVaultPrivateEndpointResourceId <String>] [-Ldap <String>]
 [-LdapServerType <String>] [-CifsChangeNotification <String>] [-GlobalFileLocking <String>]
 [-WriteBack <String>] [-SmbEncryption <String>] [-SmbAccessBasedEnumeration <String>]
 [-SmbNonBrowsable <String>] [-Zone <String[]>] [-Tag <Hashtable>] -PoolObject <PSNetAppFilesPool>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesCache** cmdlet creates a FlexCache under an ANF Capacity Pool. A Cache requires a peered on-prem ONTAP origin volume: the origin cluster name, Intercluster LIF addresses, Vserver (SVM) name, and origin volume name must be supplied via the **OriginPeer\*** parameters. The Cache is allocated data IPs from the subnet referenced by **CacheSubnetResourceId** and uses **PeeringSubnetResourceId** for Intercluster Interface IP addresses.
After creation, use **Get-AzNetAppFilesCachePeeringPassphrase** to obtain the cluster and vserver peering commands that must be applied on the external ONTAP origin to complete peering.

## EXAMPLES

### Example 1: Create a Cache backed by an on-prem ONTAP origin
```powershell
$subsId = (Get-AzContext).Subscription.Id
$cacheSubnet   = "/subscriptions/$subsId/resourceGroups/MyRG/providers/Microsoft.Network/virtualNetworks/myanf-vnet/subnets/cache-subnet"
$peeringSubnet = "/subscriptions/$subsId/resourceGroups/MyRG/providers/Microsoft.Network/virtualNetworks/myanf-vnet/subnets/peering-subnet"

New-AzNetAppFilesCache -ResourceGroupName "MyRG" -Location "eastus" `
    -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfCache" `
    -FilePath "MyAnfCache" -Size (100 * 1024 * 1024 * 1024) `
    -CacheSubnetResourceId $cacheSubnet -PeeringSubnetResourceId $peeringSubnet `
    -EncryptionKeySource "Microsoft.NetApp" `
    -OriginPeerClusterName "onprem-ontap-cluster" `
    -OriginPeerAddress @("10.10.0.10", "10.10.0.11") `
    -OriginPeerVserverName "onprem-svm" `
    -OriginPeerVolumeName "onprem-origin-vol" `
    -ProtocolType @("NFSv3")
```

Creates a 100 GiB NFSv3 FlexCache whose origin is the `onprem-origin-vol` volume on the `onprem-svm` Vserver of the `onprem-ontap-cluster` cluster.

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CacheSubnetResourceId
The Azure Resource URI for a delegated cache subnet that will be used to allocate data IPs

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

### -CifsChangeNotification
Whether CIFS change notification is enabled.
Either 'Disabled' or 'Enabled'

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeySource
Source of the encryption key.
Either 'Microsoft.NetApp' or 'Microsoft.KeyVault'

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

### -ExportPolicy
Export policy for the cache

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeExportPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
The file path of the cache

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

### -GlobalFileLocking
Whether the global file lock is enabled.
Either 'Disabled' or 'Enabled'

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

### -KerberosEnabled
Whether Kerberos is enabled for the cache.
Either 'Disabled' or 'Enabled'

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

### -KeyVaultPrivateEndpointResourceId
Resource ID of the private endpoint for KeyVault when EncryptionKeySource is Microsoft.KeyVault

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

### -Ldap
Whether LDAP is enabled for the flexcache volume.
Either 'Disabled' or 'Enabled'

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

### -LdapServerType
Type of LDAP server.
Either 'ActiveDirectory' or 'OpenLDAP'

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

### -Location
The location of the resource

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF cache

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CacheName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginPeerAddress
ONTAP Intercluster LIF IP addresses; one IP address per cluster node

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OriginPeerClusterName
ONTAP cluster name of external cluster hosting the origin volume

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

### -OriginPeerVolumeName
External origin volume name associated to this cache

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

### -OriginPeerVserverName
External Vserver (SVM) name hosting the origin volume

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

### -PeeringSubnetResourceId
The Azure Resource URI for a delegated subnet that will be used for ANF Intercluster Interface IP addresses

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

### -PoolName
The name of the ANF capacity pool

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolObject
The pool object for the new cache

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtocolType
Set of supported protocol types (NFSv3, NFSv4 or SMB)

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

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Size
Maximum storage quota allowed for the file system in bytes (50 GiB to 1 PiB)

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

### -SmbAccessBasedEnumeration
Enables access-based enumeration for SMB shares.
Either 'Disabled' or 'Enabled'

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

### -SmbEncryption
Enables encryption for in-flight SMB3 data.
Either 'Disabled' or 'Enabled'

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

### -SmbNonBrowsable
Enables non-browsable property for SMB shares.
Either 'Disabled' or 'Enabled'

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

### -Tag
A hashtable representing resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThroughputMibps
Maximum throughput in MiB/s for manual qos cache

```yaml
Type: System.Nullable`1[System.Double]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WriteBack
Whether writeback is enabled for the cache.
Either 'Disabled' or 'Enabled'

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

### -Zone
The availability zones for the cache

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache

## NOTES

## RELATED LINKS
