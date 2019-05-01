---
external help file: Az.Dns-help.xml
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/set-azdnszone
schema: 2.0.0
---

# Set-AzDnsZone

## SYNOPSIS
Creates or updates a DNS zone.
Does not modify DNS records within the zone.

## SYNTAX

### UpdateSubscriptionIdViaHost1 (Default)
```
Set-AzDnsZone -Name <String> -ResourceGroupName <String> [-Parameter <IZone>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzDnsZone -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Etag <String>]
 [-Location <String>] [-RegistrationVirtualNetwork <ISubResource[]>]
 [-ResolutionVirtualNetwork <ISubResource[]>] [-Tag <IResourceTags>] [-Type <ZoneType>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update1
```
Set-AzDnsZone -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Parameter <IZone>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded1
```
Set-AzDnsZone -Name <String> -ResourceGroupName <String> [-Etag <String>] [-Location <String>]
 [-RegistrationVirtualNetwork <ISubResource[]>] [-ResolutionVirtualNetwork <ISubResource[]>]
 [-Tag <IResourceTags>] [-Type <ZoneType>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a DNS zone.
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

### -Etag
The etag of the zone.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases:

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
Describes a DNS zone.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone
Parameter Sets: UpdateSubscriptionIdViaHost1, Update1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegistrationVirtualNetwork
A list of references to virtual networks that register hostnames in this DNS zone.
This is a only when ZoneType is Private.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180301Preview.ISubResource[]
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResolutionVirtualNetwork
A list of references to virtual networks that resolve records in this DNS zone.
This is a only when ZoneType is Private.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180301Preview.ISubResource[]
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: UpdateExpanded1, Update1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IResourceTags
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of this DNS zone (Public or Private).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Dns.Support.ZoneType
Parameter Sets: UpdateExpanded1, UpdateSubscriptionIdViaHostExpanded1
Aliases: ZoneType

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

[https://docs.microsoft.com/en-us/powershell/module/az.dns/set-azdnszone](https://docs.microsoft.com/en-us/powershell/module/az.dns/set-azdnszone)

