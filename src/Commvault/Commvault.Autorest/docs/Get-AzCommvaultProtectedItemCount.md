---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/get-azcommvaultprotecteditemcount
schema: 2.0.0
---

# Get-AzCommvaultProtectedItemCount

## SYNOPSIS
Gets the count of protected items for provided CCA resource IDs across subscriptions.

## SYNTAX

### CountExpanded (Default)
```
Get-AzCommvaultProtectedItemCount -ResourceId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CountViaJsonFilePath
```
Get-AzCommvaultProtectedItemCount -JsonFilePath <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CountViaJsonString
```
Get-AzCommvaultProtectedItemCount -JsonString <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the count of protected items for provided CCA resource IDs across subscriptions.

## EXAMPLES

### Example 1: Count the protected items of cloud accounts
```powershell
Get-AzCommvaultProtectedItemCount -ResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-contoso', '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-fabrikam'
```

Gets the number of protected items across the specified cloud accounts.

### Example 2: Count the protected items by using a JSON request
```powershell
Get-AzCommvaultProtectedItemCount -JsonString '{"resourceIds":["/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-contoso"]}'
```

Gets the number of protected items by passing the request body as a JSON string.

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

### -JsonFilePath
Path of Json file supplied to the Count operation

```yaml
Type: System.String
Parameter Sets: CountViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Count operation

```yaml
Type: System.String
Parameter Sets: CountViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The list of CCA resource IDs.

```yaml
Type: System.String[]
Parameter Sets: CountExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICountProtectedItemsResponse

## NOTES

## RELATED LINKS

