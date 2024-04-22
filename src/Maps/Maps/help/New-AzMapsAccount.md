---
external help file: Az.Maps-help.xml
Module Name: Az.Maps
online version: https://learn.microsoft.com/powershell/module/az.maps/new-azmapsaccount
schema: 2.0.0
---

# New-AzMapsAccount

## SYNOPSIS
Create or update a Maps Account.
A Maps Account holds the keys which allow access to the Maps REST APIs.

## SYNTAX

```
New-AzMapsAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 -SkuName <Name> [-DisableLocalAuth] [-Kind <Kind>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a Maps Account.
A Maps Account holds the keys which allow access to the Maps REST APIs.

## EXAMPLES

### Example 1: Create a Maps Account.
```powershell
New-AzMapsAccount -ResourceGroupName azure-rg-test -Name pwsh-mapsAccount01 -SkuName S0 -Location eastus
```

```output
Location Name               Type                    Kind
-------- ----               ----                    ----
eastus   pwsh-mapsAccount01 Microsoft.Maps/accounts Gen1
```

This command creates a Maps Account.A Maps Account holds the keys which allow access to the Maps REST APIs.

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

### -DisableLocalAuth
Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support.
This will disable Shared Keys authentication from any usage.

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

### -Kind
Get or Set Kind property.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
The name of the Maps Account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
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

### -SkuName
The name of the SKU, in standard format (such as S0).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount

## NOTES

## RELATED LINKS
