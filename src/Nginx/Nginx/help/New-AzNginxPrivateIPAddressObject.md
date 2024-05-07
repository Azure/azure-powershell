---
external help file: Az.Nginx-help.xml
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/Az.Nginx/new-AzNginxPrivateIPAddressObject
schema: 2.0.0
---

# New-AzNginxPrivateIPAddressObject

## SYNOPSIS
Create an in-memory object for NginxPrivateIPAddress.

## SYNTAX

```
New-AzNginxPrivateIPAddressObject [-PrivateIPAddress <String>]
 [-PrivateIPAllocationMethod <NginxPrivateIPAllocationMethod>] [-SubnetId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NginxPrivateIPAddress.

## EXAMPLES

### Example 1: Create an in-memory object for NginxPrivateIPAddress
```powershell
New-AzNginxPrivateIPAddressObject -PrivateIPAddress 10.0.0.0 -PrivateIPAllocationMethod Static -SubnetId /subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default
```

```output
PrivateIPAddress PrivateIPAllocationMethod SubnetId
---------------- ------------------------- --------
10.0.0.0         Static                    /subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default
```

Create an in-memory object for NginxPrivateIPAddress.

## PARAMETERS

### -PrivateIPAddress

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

### -PrivateIPAllocationMethod

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Support.NginxPrivateIPAllocationMethod
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20230401.NginxPrivateIPAddress

## NOTES

## RELATED LINKS
