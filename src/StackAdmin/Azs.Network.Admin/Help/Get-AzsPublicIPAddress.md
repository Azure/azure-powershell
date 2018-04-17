---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# Get-AzsPublicIPAddress

## SYNOPSIS
List of public IP addresses.

## SYNTAX

```
Get-AzsPublicIPAddress [[-Filter] <String>] [[-OrderBy] <String>] [[-Skip] <Int32>] [[-Top] <Int32>]
 [[-InlineCount] <String>] [<CommonParameters>]
```

## DESCRIPTION
List of public IP addresses.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsPublicIPAddress
```

IpAddress         :
IpPool            :
AllocationMethod  : Dynamic
ProvisioningState :
SubscriptionId    :
TenantResourceUri :
Id                : /subscriptions/a35a3f50-9f21-4f04-a978-01bc4ad7aa4f/providers/Microsoft.Network.Admin/adminPublicIPAddresses/publicIp1
Name              : publicIp1
Type              : Microsoft.Network.Admin/adminPublicIPAddresses
Location          :
Tags              :
...

Get the list of public ip addresses, either allocated or not allocated.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InlineCount
OData inline count parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderBy
OData orderBy parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Network.Admin.Models.PublicIpAddress

## NOTES

## RELATED LINKS

