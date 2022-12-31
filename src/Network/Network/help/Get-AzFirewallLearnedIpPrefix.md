---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/Get-AzFirewallLearnedIpPrefix
schema: 2.0.0
---

# Get-AzFirewallLearnedIpPrefix

## SYNOPSIS
Gets firewall auto learned ip prefixes.

## SYNTAX

```
Get-AzFirewallLearnedIpPrefix -Name <String>  -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzFirewallLearnedIpPrefix** cmdlet gets a firewall auto learned ip prefixes.

## EXAMPLES

### Example 1: Retrieve a Firewall auto learned ip prefixes by its name

```powershell
Get-AzFirewallLearnedIpPrefix -ResourceGroupName rgName -Name azFw
```

```output
IpPrefixes :    [ "10.101.0.0/16", "10.102.0.0/16" ]
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the Firewall that this cmdlet gets.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that Firewall belongs to.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallIpPrefix

## NOTES

## RELATED LINKS
