---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/get-azdatadogmarketplaceagreement
schema: 2.0.0
---

# Get-AzDatadogMarketplaceAgreement

## SYNOPSIS
List Datadog marketplace agreements in the subscription.

## SYNTAX

```
Get-AzDatadogMarketplaceAgreement [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
List Datadog marketplace agreements in the subscription.

## EXAMPLES

### Example 1: List Datadog marketplace agreements in the subscription
```powershell
Get-AzDatadogMarketplaceAgreement
```

```output
Name        Type
----        ----
marketplace Microsoft.Datadog/agreements
Datadog     Microsoft.Datadog/agreements
```

This command lists Datadog marketplace agreements in the subscription.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementResource

## NOTES

## RELATED LINKS
