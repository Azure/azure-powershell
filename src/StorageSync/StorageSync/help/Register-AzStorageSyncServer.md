---
external help file: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.dll-Help.xml
Module Name: Az.StorageSync
online version: https://learn.microsoft.com/powershell/module/Az.storagesync/register-Azstoragesyncserver
schema: 2.0.0
---

# Register-AzStorageSyncServer

## SYNOPSIS
Creates a managed identity registered server resource in Azure.

## SYNTAX

```
Register-AzStorageSyncServer [-ResourceGroupName] <String> [-StorageSyncServiceName] <String>
 -ApplicationId <Guid> -AgentVersion <String> -ServerRole <String> [-ServerOSVersion <String>]
 [-FriendlyName <String>] [-ClusterId <Guid>] [-ClusterName <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This command creates a registered server resource in a storage sync service by using the server's system-assigned managed identity. It performs only Azure Resource Manager operations and can be run from any computer. Certificate-based registration isn't supported.

This command uses plain scalar parameters only. It does not accept or emit shared objects. The managed identity application id, agent version, server role, and other local values come from `Get-StorageSyncServer`, which is run on the target server. Read the values returned by this command and supply them to `Connect-StorageSyncServer` as explicit parameters to complete local configuration.

## EXAMPLES

### Example 1
```powershell
$local = Get-StorageSyncServer
Register-AzStorageSyncServer -ResourceGroupName "myResourceGroup" `
    -StorageSyncServiceName "myStorageSyncServiceName" `
    -ApplicationId $local.ApplicationId `
    -AgentVersion $local.AgentVersion `
    -ServerRole $local.ServerRole `
    -ServerOSVersion $local.ServerOSVersion `
    -FriendlyName $local.ServerName
```

This command creates the registered server resource in Azure using the local values from `Get-StorageSyncServer`. Read the returned values and supply them to `Connect-StorageSyncServer` on the target server.

## PARAMETERS

### -AgentVersion
The Azure File Sync agent version reported by the local server (from `Get-StorageSyncServer`).

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

### -ApplicationId
Specifies the application ID of the server's system-assigned managed identity.

```yaml
Type: System.Guid
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterId
The cluster id when the local server is a failover cluster node (from `Get-StorageSyncServer`).

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The cluster name when the local server is a failover cluster node (from `Get-StorageSyncServer`).

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

### -FriendlyName
A friendly name for the registered server, typically the local server name (from `Get-StorageSyncServer`).

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

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerOSVersion
The local server operating system version (from `Get-StorageSyncServer`).

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

### -ServerRole
The local server role, Standalone or ClusterNode (from `Get-StorageSyncServer`).

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

### -StorageSyncServiceName
Name of the StorageSyncService.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.StorageSync.Models.PSRegisteredServer

## NOTES

## RELATED LINKS

[Connect-StorageSyncServer](Connect-StorageSyncServer.md)
