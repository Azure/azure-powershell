---
external help file: Az.MySql-help.xml
Module Name: Az.MySql
online version: https://learn.microsoft.com/powershell/module/az.mysql/get-azmysqlflexibleserveradvancedthreatprotectionsetting
schema: 2.0.0
---

# Get-AzMySqlFlexibleServerAdvancedThreatProtectionSetting

## SYNOPSIS
Get a server's Advanced Threat Protection state

## SYNTAX

```
Get-AzMySqlFlexibleServerAdvancedThreatProtectionSetting -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a server's Advanced Threat Protection state

## EXAMPLES

### Example 1: Get a server's Advanced Threat Protection state
```powershell
Get-AzMySqlFlexibleServerAdvancedThreatProtectionSetting -ResourceGroupName PowershellMySqlTest -ServerName mysql-test
```

```output
State
-----
Disabled
```

Get a server's Advanced Threat Protection state

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20231230.IAdvancedThreatProtection

## NOTES

## RELATED LINKS
