---
external help file: Az.Nginx-help.xml
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/Az.Nginx/new-AzNginxPublicIPAddressObject
schema: 2.0.0
---

# New-AzNginxPublicIPAddressObject

## SYNOPSIS
Create an in-memory object for NginxPublicIPAddress.

## SYNTAX

```
New-AzNginxPublicIPAddressObject [-Id <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NginxPublicIPAddress.

## EXAMPLES

### Example 1: Create an in-memory object for NginxPublicIPAddress
```powershell
New-AzNginxPublicIPAddressObject -Id /subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/publicIPAddresses/nginx-test-ip
```

```output
Id
--
/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/publicIPAddresses/nginx-test-ip
```

Create an in-memory object for NginxPublicIPAddress.

## PARAMETERS

### -Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20230401.NginxPublicIPAddress

## NOTES

## RELATED LINKS
