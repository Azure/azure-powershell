---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkSiteResourceIdObject
schema: 2.0.0
---

# New-AzMobileNetworkSiteResourceIdObject

## SYNOPSIS
Create an in-memory object for SiteResourceId.

## SYNTAX

```
New-AzMobileNetworkSiteResourceIdObject -Id <String> [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SiteResourceId.

## EXAMPLES

### Example 1: Create an in-memory object for SiteResourceId.
```powershell
New-AzMobileNetworkSiteResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/sites/azps-mn-site"
```

```output
Id
--
/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/sites/azps-mn-site
```

Create an in-memory object for SiteResourceId.

## PARAMETERS

### -Id
Site resource ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.SiteResourceId

## NOTES

## RELATED LINKS
