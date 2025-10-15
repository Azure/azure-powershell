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

### Example 1: List  SKUs under a subscription
```powershell
Get-AzStorageSku -SubscriptionId $mysubid
```

```output
Capability   : {{
                 "name": "supportsAccountHnsOnMigration",
                 "value": "true"
               }, {
                 "name": "supportsaccountvlw",
                 "value": "true"
               }, {
                 "name": "supportsadlsgen2snapshot",
                 "value": "true"
               }, {
                 "name": "supportsadlsgen2staticwebsite",
                 "value": "true"
               }…}
Kind         : StorageV2
Location     : {westus2}
LocationInfo : {{
                 "location": "westus2",
                 "zones": [ ]
               }}
Name         : Standard_ZRS
ResourceType : storageAccounts
Restriction  : {}
Tier         : Standard
```

This command lists all SKUs under a specified subscription.

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

