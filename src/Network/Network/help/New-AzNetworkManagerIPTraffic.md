---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanageriptraffic
schema: 2.0.0
---

# New-AzNetworkManagerIPTraffic

## SYNOPSIS
Create a new instance of IP Traffic
## SYNTAX

```
New-AzNetworkManagerIPTraffic -SourceIp <System.Collections.Generic.IList`1[System.String]>
 -DestinationIp <System.Collections.Generic.IList`1[System.String]>
 -SourcePort <System.Collections.Generic.IList`1[System.String]>
 -DestinationPort <System.Collections.Generic.IList`1[System.String]>
 -Protocol <System.Collections.Generic.IList`1[System.String]> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**New-AzNetworkManagerIPTraffic** cmdlet creates a new instance of IP Traffic
## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerIPTraffic -SourceIp @("192.168.1.10") -DestinationIp @("172.16.0.5") -SourcePort @("100") -DestinationPort @("99") -Protocol @("TCP")
```

```output
SourceIps        : {192.168.1.10}
DestinationIps   : {172.16.0.5}
SourcePorts      : {100}
DestinationPorts : {99}
Protocols        : {TCP}
IpTrafficText    : {
                     "SourceIps": [
                       "192.168.1.10"
                     ],
                     "DestinationIps": [
                       "172.16.0.5"
                     ],
                     "SourcePorts": [
                       "100"
                     ],
                     "DestinationPorts": [
                       "99"
                     ],
                     "Protocols": [
                       "TCP"
                     ]
                   }

```


Created a new instance of IP Traffic
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

### -DestinationIp
The destination IPs.

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationPort
The destination ports.

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
The protocols (e.g., TCP, UDP).

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourceIp
The source IPs.

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourcePort
The source ports.

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.Collections.Generic.IList`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIPTraffic

## NOTES

## RELATED LINKS
