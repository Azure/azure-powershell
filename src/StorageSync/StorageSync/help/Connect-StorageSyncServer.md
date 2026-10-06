---
external help file: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.dll-Help.xml
Module Name: Az.StorageSync
online version: https://learn.microsoft.com/powershell/module/Az.storagesync/connect-storagesyncserver
schema: 2.0.0
---

# Connect-StorageSyncServer

## SYNOPSIS
Connects the local server to an existing managed identity registered server resource.

## SYNTAX

```
Connect-StorageSyncServer [-ResourceGroupName] <String> [-StorageSyncServiceName] <String> -ServerId <Guid>
 -ApplicationId <Guid> -StorageSyncServiceUid <Guid> -ManagementEndpointUri <Uri> -DiscoveryEndpointUri <Uri>
 -ServiceLocation <String> -ResourceLocation <String> [-MonitoringEndpointUri <Uri>]
 [-MonitoringConfiguration <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Run this command locally on the target Azure File Sync server after `Register-AzStorageSyncServer` creates the registered server resource in Azure. Supply the values returned by Azure as explicit parameters. The Azure-returned server ID is authoritative and is passed to the local registration and monitoring flow. The command validates the managed identity application ID, discovers standalone or failover cluster configuration through the local agent, then persists the registration in the local Azure File Sync agent.

This command uses plain scalar parameters only. It does not accept a pipeline object or emit a shared object for chaining. It doesn't create or update Azure resources, create certificates, or assign Azure Role-Based Access Control (RBAC) roles.

## EXAMPLES

### Example 1: Connect a local server

```powershell
Connect-StorageSyncServer -ResourceGroupName "myResourceGroup" `
    -StorageSyncServiceName "myStorageSyncServiceName" `
    -ServerId "00000000-0000-0000-0000-000000000001" `
    -ApplicationId "00000000-0000-0000-0000-000000000002" `
    -StorageSyncServiceUid "00000000-0000-0000-0000-000000000003" `
    -ManagementEndpointUri "https://management.azure.com" `
    -DiscoveryEndpointUri "https://discovery.example" `
    -ServiceLocation "westus2" -ResourceLocation "westus2"
```

This command connects the local server by using values that the operator copied from the `Register-AzStorageSyncServer` output.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -ApplicationId
Specifies the application ID of the local server's system-assigned managed identity.

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

### -DiscoveryEndpointUri
Specifies the discovery endpoint URI returned by Azure.

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementEndpointUri
Specifies the management endpoint URI returned by Azure.

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringConfiguration
Specifies the optional monitoring configuration returned by Azure.

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

### -MonitoringEndpointUri
Specifies the optional monitoring endpoint URI returned by Azure.

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group that contains the Storage Sync Service.

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

### -ResourceLocation
Specifies the resource location returned by Azure.

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

### -ServerId
Specifies the Azure File Sync server ID.

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

### -ServiceLocation
Specifies the service location returned by Azure.

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
Specifies the Storage Sync Service name.

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

### -StorageSyncServiceUid
Specifies the Storage Sync Service UID generated and returned by Azure.

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

[Register-AzStorageSyncServer](Register-AzStorageSyncServer.md)
