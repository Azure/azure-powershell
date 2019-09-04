---
external help file:
Module Name: Az.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/az.dns/new-azdnszone
schema: 2.0.0
---

# New-AzDnsZone

## SYNOPSIS
Creates or updates a DNS zone.
Does not modify DNS records within the zone.

## SYNTAX

### CreatePublic (Default)
```
New-AzDnsZone -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-DoNotOverwrite] [-Etag <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreatePrivate
```
New-AzDnsZone -Name <String> -ResourceGroupName <String> -Location <String> -Private
 [-SubscriptionId <String>] [-DoNotOverwrite] [-Etag <String>] [-RegistrationVirtualNetworkId <String[]>]
 [-ResolutionVirtualNetworkId <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a DNS zone.
Does not modify DNS records within the zone.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -DoNotOverwrite
Does not overwrite the record set if it already exists.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
The etag of the zone.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Private
When provided, creates a private DNS zone.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreatePrivate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RegistrationVirtualNetworkId
A list of references to virtual networks that register hostnames in this DNS zone.

```yaml
Type: System.String[]
Parameter Sets: CreatePrivate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResolutionVirtualNetworkId
A list of references to virtual networks that resolve records in this DNS zone.

```yaml
Type: System.String[]
Parameter Sets: CreatePrivate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -SubscriptionId
Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IZone

## ALIASES

## NOTES

## RELATED LINKS

