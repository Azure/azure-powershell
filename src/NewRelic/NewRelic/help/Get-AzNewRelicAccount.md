---
external help file:
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicaccount
schema: 2.0.0
---

# Get-AzNewRelicAccount

## SYNOPSIS
List all the existing accounts

## SYNTAX

```
Get-AzNewRelicAccount -Location <String> -UserEmail <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List all the existing accounts

## EXAMPLES

### Example 1: Get specific monitor account with specified location
```powershell
Get-AzNewRelicAccount -Location eastus -UserEmail v-jiaji@outlook.com
```

```output
OrganizationId                       AccountId AccountName Region
--------------                       --------- ----------- ------
ea6e1130-d7a1-4519-826f-e7d51b66c7a4 3994857   3994857     eastus
40f16846-b6e5-4394-9dcd-36c484b5d907 3994838   3994838     eastus
d2f7ead5-855d-4c76-ab0e-8db6ace6a4e1 3974757   3974757     eastus
5ef43ba0-1831-44a3-a8d0-6da95bec103e 3968603   3968603     eastus
9a7aa973-ff6e-4e0f-acd6-86b41f6a7b80 3967352   3967352     eastus
51170629-d6fd-4c58-91a3-0efb267704e7 3967342   3967342     eastus
61c8301a-d564-4c97-aeec-d9bec5bca043 3966988   3966988     eastus
```

Get specific monitor account with specified location

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

### -Location
Location for NewRelic.

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

### -UserEmail
User Email.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.Api20220701.IAccountResource

## NOTES

ALIASES

## RELATED LINKS

