---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnszone
schema: 2.0.0
---

# Update-AzDnsZone

## SYNOPSIS
Updates a DNS zone.
Does not modify DNS records within the zone.

## SYNTAX

### UpdateSubscriptionIdViaHost (Default)
```
Update-AzDnsZone -Name <String> -ResourceGroupName <String> [-Parameter <IZoneUpdate>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzDnsZone -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Tag <IZoneUpdateTags>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzDnsZone -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Parameter <IZoneUpdate>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Update-AzDnsZone -Name <String> -ResourceGroupName <String> [-Tag <IZoneUpdateTags>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a DNS zone.
Does not modify DNS records within the zone.

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
Parameter Sets: (All)
Aliases: ZoneName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a request to update a DNS zone.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZoneUpdate
Parameter Sets: UpdateSubscriptionIdViaHost, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZoneUpdateTags
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnszone](https://docs.microsoft.com/en-us/powershell/module/az.dns/update-azdnszone)

