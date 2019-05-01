---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnszone
schema: 2.0.0
---

# Get-AzDnsZone

## SYNOPSIS
Gets a DNS zone.
Retrieves the zone properties, but not the record sets within the zone.

## SYNTAX

### ListSubscriptionIdViaHost1 (Default)
```
Get-AzDnsZone [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost1
```
Get-AzDnsZone -Name <String> -ResourceGroupName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzDnsZone -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListSubscriptionIdViaHost
```
Get-AzDnsZone -ResourceGroupName <String> [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDnsZone -ResourceGroupName <String> -SubscriptionId <String> [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzDnsZone -SubscriptionId <String> [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a DNS zone.
Retrieves the zone properties, but not the record sets within the zone.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Name
The name of the DNS zone (without a terminating dot).

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost1, Get1
Aliases: ZoneName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost1, Get1, ListSubscriptionIdViaHost, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get1, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of DNS zones to return.
If not specified, returns up to 100 zones.

```yaml
Type: System.Int32
Parameter Sets: ListSubscriptionIdViaHost1, ListSubscriptionIdViaHost, List, List1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnszone](https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnszone)

