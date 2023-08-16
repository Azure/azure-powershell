---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragesku
schema: 2.0.0
---

# Get-AzStorageSku

## SYNOPSIS
Lists the available SKUs supported by Microsoft.Storage for given subscription.

## SYNTAX

```
Get-AzStorageSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the available SKUs supported by Microsoft.Storage for given subscription.

## EXAMPLES

### Example 1: List available Storage SKUs for a subscription 
```powershell
Get-AzStorageSku
```

```output
Kind             Name            Tier     Location             ResourceType
----             ----            ----     --------             ------------
BlockBlobStorage Premium_LRS     Premium  {australiacentral}   storageAccounts
BlockBlobStorage Premium_LRS     Premium  {australiaeast}      storageAccounts
BlockBlobStorage Premium_LRS     Premium  {australiasoutheast} storageAccounts
BlockBlobStorage Premium_LRS     Premium  {brazilsouth}        storageAccounts
BlockBlobStorage Premium_LRS     Premium  {brazilsoutheast}    storageAccounts
BlockBlobStorage Premium_LRS     Premium  {canadacentral}      storageAccounts
BlockBlobStorage Premium_LRS     Premium  {canadaeast}         storageAccounts
BlockBlobStorage Premium_LRS     Premium  {centralindia}       storageAccounts
BlockBlobStorage Premium_LRS     Premium  {centralus}          storageAccounts
```

This command lists all the available Storage SKUs for a subscription.

## PARAMETERS

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

### -SubscriptionId
The ID of the target subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformation

## NOTES

## RELATED LINKS

