---
external help file: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.dll-Help.xml
Module Name: Az.StorageSync
online version: https://learn.microsoft.com/powershell/module/Az.storagesync/get-storagesyncserver
schema: 2.0.0
---

# Get-StorageSyncServer

## SYNOPSIS
Reads local Azure File Sync server information through the server agent.

## SYNTAX

```
Get-StorageSyncServer [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Run this command locally on a Windows Server that has the Azure File Sync agent installed. It reads local state through the agent, including the server ID, standalone or failover cluster role, cluster ID, cluster name, and the server system-assigned managed identity application ID and tenant ID.

This command does not create or modify any Azure or local resources. Use its output values as inputs to `Register-AzStorageSyncServer` and `Connect-StorageSyncServer`. The three commands are independent and are not connected through the pipeline.

## EXAMPLES

### Example 1: Read local server information

```powershell
Get-StorageSyncServer
```

This command returns the local server ID, cluster details, and managed identity application ID for use in the registration and connection steps.

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.StorageSync.Models.PSLocalStorageSyncServer

## NOTES

## RELATED LINKS

[Register-AzStorageSyncServer](Register-AzStorageSyncServer.md)

[Connect-StorageSyncServer](Connect-StorageSyncServer.md)
