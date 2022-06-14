---
external help file:
Module Name: Az.MediaServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.mediaservices/get-azmediaservicesassetcontainersas
schema: 2.0.0
---

# Get-AzMediaServicesAssetContainerSas

## SYNOPSIS
Lists storage container URLs with shared access signatures (SAS) for uploading and downloading Asset content.
The signatures are derived from the storage account keys.

## SYNTAX

### ListExpanded (Default)
```
Get-AzMediaServicesAssetContainerSas -AccountName <String> -AssetName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-ExpiryTime <DateTime>] [-Permission <AssetContainerPermission>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzMediaServicesAssetContainerSas -AccountName <String> -AssetName <String> -ResourceGroupName <String>
 -Parameter <IListContainerSasInput> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Lists storage container URLs with shared access signatures (SAS) for uploading and downloading Asset content.
The signatures are derived from the storage account keys.

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
The Media Services account name.

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

### -AssetName
The Asset name.

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

### -ExpiryTime
The SAS URL expiration time.
This must be less than 24 hours from the current time.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters to the list SAS request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IListContainerSasInput
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Permission
The permissions to set on the SAS URL.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Support.AssetContainerPermission
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the Azure subscription.

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

### -SubscriptionId
The unique identifier for a Microsoft Azure subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.MediaServices.Models.Api20211101.IListContainerSasInput

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PARAMETER <IListContainerSasInput>: The parameters to the list SAS request.
  - `[ExpiryTime <DateTime?>]`: The SAS URL expiration time.  This must be less than 24 hours from the current time.
  - `[Permission <AssetContainerPermission?>]`: The permissions to set on the SAS URL.

## RELATED LINKS

