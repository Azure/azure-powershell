---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/powershell/module/az.dnsresolver/get-azdnsresolver
schema: 2.0.0
---

# Get-AzDnsResolver

## SYNOPSIS
Gets properties of a DNS resolver.

## SYNTAX

### List1 (Default)
```
Get-AzDnsResolver [-SubscriptionId <String[]>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDnsResolver -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDnsResolver -InputObject <IDnsResolverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDnsResolver -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzDnsResolver -ResourceGroupName <String> -VirtualNetworkName <String> [-SubscriptionId <String[]>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a DNS resolver.

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the DNS resolver.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DnsResolverName

Required: True
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
Parameter Sets: Get, List, List2
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
Parameter Sets: Get, List, List1, List2
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of results to return.
If not specified, returns up to 100 results.

```yaml
Type: System.Int32
Parameter Sets: List, List1, List2
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkName
The name of the virtual network.

```yaml
Type: System.String
Parameter Sets: List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IDnsResolver

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDnsResolverIdentity>: Identity Parameter
  - `[DnsResolverName <String>]`: The name of the DNS resolver.
  - `[Id <String>]`: Resource identity path
  - `[InboundEndpointName <String>]`: The name of the inbound endpoint for the DNS resolver.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VirtualNetworkName <String>]`: The name of the virtual network.

## RELATED LINKS

