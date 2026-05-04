---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/update-aznetappfilescache
schema: 2.0.0
---

# Update-AzNetAppFilesCache

## SYNOPSIS
Updates an existing Azure NetApp Files (ANF) Cache.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Update-AzNetAppFilesCache -ResourceGroupName <String> -AccountName <String> -PoolName <String> -Name <String>
 [-Size <Int64>] [-ProtocolType <String[]>] [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>]
 [-ThroughputMibps <Double>] [-KeyVaultPrivateEndpointResourceId <String>] [-CifsChangeNotification <String>]
 [-WriteBack <String>] [-SmbEncryption <String>] [-SmbAccessBasedEnumeration <String>]
 [-SmbNonBrowsable <String>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Update-AzNetAppFilesCache -ResourceId <String> [-Size <Int64>] [-ProtocolType <String[]>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-ThroughputMibps <Double>]
 [-KeyVaultPrivateEndpointResourceId <String>] [-CifsChangeNotification <String>] [-WriteBack <String>]
 [-SmbEncryption <String>] [-SmbAccessBasedEnumeration <String>] [-SmbNonBrowsable <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzNetAppFilesCache -InputObject <PSNetAppFilesCache> [-Size <Int64>] [-ProtocolType <String[]>]
 [-ExportPolicy <PSNetAppFilesVolumeExportPolicy>] [-ThroughputMibps <Double>]
 [-KeyVaultPrivateEndpointResourceId <String>] [-CifsChangeNotification <String>] [-WriteBack <String>]
 [-SmbEncryption <String>] [-SmbAccessBasedEnumeration <String>] [-SmbNonBrowsable <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzNetAppFilesCache** cmdlet patches an existing ANF Cache. Only the properties supplied as parameters are modified; all others retain their current values. Use this cmdlet to resize the cache, change protocol types, adjust SMB/export settings, update throughput, toggle CIFS change notifications or writeback, or attach a new KeyVault private endpoint.

## EXAMPLES

### Example 1: Increase cache size and throughput
```powershell
Update-AzNetAppFilesCache -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfCache" `
    -Size (200 * 1024 * 1024 * 1024) -ThroughputMibps 128
```

Resizes the cache to 200 GiB and raises throughput to 128 MiB/s.

### Example 2: Enable CIFS change notifications and update tags
```powershell
Update-AzNetAppFilesCache -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfCache" `
    -CifsChangeNotification "Enabled" -Tag @{Owner = "ai-team"; Env = "prod"}
```

Enables CIFS change notifications on the cache and replaces the resource tags.

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

### -CifsChangeNotification
Whether CIFS change notifications are enabled

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

### -InputObject
The cache object to update

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultPrivateEndpointResourceId
Resource ID of the private endpoint for KeyVault

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

### -Name
The name of the ANF cache

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: CacheName

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

### -ProtocolType
Set of supported protocol types

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

### -ResourceId
The resource id of the ANF cache

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Size
Maximum storage quota for the file system in bytes

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbAccessBasedEnumeration
Enables access-based enumeration for SMB shares

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
Enables encryption for in-flight SMB3 data

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
Enables non-browsable property for SMB shares

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
Whether writeback is enabled for the cache

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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesCache

## NOTES

## RELATED LINKS
