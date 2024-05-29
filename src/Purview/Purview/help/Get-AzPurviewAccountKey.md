---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewaccountkey
schema: 2.0.0
---

# Get-AzPurviewAccountKey

## SYNOPSIS
List the authorization keys associated with this account.

## SYNTAX

```
Get-AzPurviewAccountKey -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List the authorization keys associated with this account.

## EXAMPLES

### Example 1: List the authorization keys associated with a specified account.
```powershell
Get-AzPurviewAccountKey -AccountName test-pa -ResourceGroupName test-rg
```

```output
AtlasKafkaPrimaryEndpoint
-------------------------
Endpoint=sb://atlas-xxxxxxxx-5348-4811-a336-759242a25d37.servicebus.windows.net/;SharedAccessKeyName=AlternateSharedAccessKey;SharedAcces…
```

List the authorization keys associated with account 'test-pa'.

## PARAMETERS

### -AccountName
The name of the account.

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

### -ResourceGroupName
The resource group name.

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
The subscription identifier

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccessKeys

## NOTES

## RELATED LINKS
