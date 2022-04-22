---
external help file:
Module Name: Az.DataBoxEdge
online version: https://docs.microsoft.com/en-us/powershell/module/az.databoxedge/update-azdataboxedgedeviceextendedinformation
schema: 2.0.0
---

# Update-AzDataBoxEdgeDeviceExtendedInformation

## SYNOPSIS
Gets additional information for the specified Data Box Edge/Data Box Gateway device.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataBoxEdgeDeviceExtendedInformation -DeviceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ChannelIntegrityKeyName <String>] [-ChannelIntegrityKeyVersion <String>]
 [-ClientSecretStoreId <String>] [-ClientSecretStoreUrl <String>] [-SyncStatus <KeyVaultSyncStatus>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataBoxEdgeDeviceExtendedInformation -InputObject <IDataBoxEdgeIdentity>
 [-ChannelIntegrityKeyName <String>] [-ChannelIntegrityKeyVersion <String>] [-ClientSecretStoreId <String>]
 [-ClientSecretStoreUrl <String>] [-SyncStatus <KeyVaultSyncStatus>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets additional information for the specified Data Box Edge/Data Box Gateway device.

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

### -ChannelIntegrityKeyName
The name for Channel Integrity Key stored in the Client Key Vault

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

### -ChannelIntegrityKeyVersion
The version of Channel Integrity Key stored in the Client Key Vault

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

### -ClientSecretStoreId
The Key Vault ARM Id for client secrets

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

### -ClientSecretStoreUrl
The url to access the Client Key Vault

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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncStatus
For changing or to initiate the resync to key-vault set the status to KeyVaultSyncPending, rest of the status will not be applicable.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.KeyVaultSyncStatus
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IDataBoxEdgeDeviceExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxEdgeIdentity>: Identity Parameter
  - `[AddonName <String>]`: The addon name.
  - `[ContainerName <String>]`: The container Name
  - `[DeviceName <String>]`: The device name.
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: The alert name.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[RoleName <String>]`: The role name.
  - `[StorageAccountName <String>]`: The storage account name.
  - `[SubscriptionId <String>]`: The subscription ID.

## RELATED LINKS

