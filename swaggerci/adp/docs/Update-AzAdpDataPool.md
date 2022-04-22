---
external help file:
Module Name: Az.Adp
online version: https://docs.microsoft.com/en-us/powershell/module/az.adp/update-azadpdatapool
schema: 2.0.0
---

# Update-AzAdpDataPool

## SYNOPSIS
Updates the properties of an existing Data Pool

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAdpDataPool -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Location <IDataPoolLocation[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAdpDataPool -InputObject <IAdpIdentity> [-Location <IDataPoolLocation[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an existing Data Pool

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

### -AccountName
The name of the ADP account

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

### -AsJob
Run the command as a job

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Adp.Models.IAdpIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Gets or sets the collection of locations where Data Pool resources should be created
To construct, see NOTES section for LOCATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Adp.Models.Api20211101Preview.IDataPoolLocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Data Pool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DataPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

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

### -Tag
Resource tags

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

### Microsoft.Azure.PowerShell.Cmdlets.Adp.Models.IAdpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Adp.Models.Api20211101Preview.IDataPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAdpIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the ADP account
  - `[DataPoolName <String>]`: The name of the Data Pool
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

LOCATION <IDataPoolLocation[]>: Gets or sets the collection of locations where Data Pool resources should be created
  - `Name <String>`: The location name
  - `[EncryptionKeyName <String>]`: The name of Key Vault key
  - `[EncryptionKeyVaultUri <String>]`: The URI of a soft delete-enabled Key Vault that is in the same location as the Data Pool location
  - `[EncryptionKeyVersion <String>]`: The version of Key Vault key
  - `[EncryptionUserAssignedIdentity <String>]`: The resource ID of a user-assigned Managed Identity used to access the encryption key in the Key Vault. Requires access to the key operations get, wrap, unwrap, and recover
  - `[StorageAccountCount <Int32?>]`: The amount of storage accounts provisioned per Data Pool. Default: 5
  - `[StorageSkuName <StorageSkuName?>]`: The SKU name

## RELATED LINKS

