---
external help file:
Module Name: Az.StorageSync
online version: https://learn.microsoft.com/powershell/module/az.storagesync/invoke-azstoragesyncsharecloudendpoint
schema: 2.0.0
---

# Invoke-AzStorageSyncShareCloudEndpoint

## SYNOPSIS
Get the AFS file share metadata signing certificate public keys.

## SYNTAX

### Share (Default)
```
Invoke-AzStorageSyncShareCloudEndpoint -CloudEndpointName <String> -ResourceGroupName <String>
 -StorageSyncServiceName <String> -SyncGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ShareViaIdentity
```
Invoke-AzStorageSyncShareCloudEndpoint -InputObject <IStorageSyncIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the AFS file share metadata signing certificate public keys.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CloudEndpointName
Name of Cloud Endpoint object.

```yaml
Type: System.String
Parameter Sets: Share
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.IStorageSyncIdentity
Parameter Sets: ShareViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Share
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSyncServiceName
Name of Storage Sync Service resource.

```yaml
Type: System.String
Parameter Sets: Share
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Share
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncGroupName
Name of Sync Group resource.

```yaml
Type: System.String
Parameter Sets: Share
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.IStorageSyncIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageSync.Models.Api20220601.ICloudEndpointAfsShareMetadataCertificatePublicKeys

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IStorageSyncIdentity>`: Identity Parameter
  - `[CloudEndpointName <String>]`: Name of Cloud Endpoint object.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The desired region for the name check.
  - `[OperationId <String>]`: operation Id
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ServerEndpointName <String>]`: Name of Server Endpoint object.
  - `[ServerId <String>]`: GUID identifying the on-premises server.
  - `[StorageSyncServiceName <String>]`: Name of Storage Sync Service resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[SyncGroupName <String>]`: Name of Sync Group resource.
  - `[WorkflowId <String>]`: workflow Id

## RELATED LINKS

