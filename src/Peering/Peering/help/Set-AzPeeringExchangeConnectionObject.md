---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
online version:
schema: 2.0.0
---

# Set-AzPeeringExchangeConnectionObject

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ParameterSetNameMd5Authentication (Default)
```
Set-AzPeeringExchangeConnectionObject -InputObject <PSPeering> [-ConnectionIndex] <Int32>
 [[-MD5AuthenticationKey] <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ParameterSetNameIPv4Prefix
```
Set-AzPeeringExchangeConnectionObject -InputObject <PSPeering> [-ConnectionIndex] <Int32>
 [-PeerSessionIPv4Address] <String> [-MaxPrefixesAdvertisedIPv4 <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParameterSetNameIPv6Prefix
```
Set-AzPeeringExchangeConnectionObject -InputObject <PSPeering> [-ConnectionIndex] <Int32>
 [-PeerSessionIPv6Address] <String> [-MaxPrefixesAdvertisedIPv6 <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ConnectionIndex
Create a new Exchange connections using the New-AzExchangePeeringConnection and pipe to this command.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
{{ Fill InputObject Description }}

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv4
HelpMaxAdvertisedIPv4

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv4Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrefixesAdvertisedIPv6
HelpMaxAdvertisedIPv4

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: ParameterSetNameIPv6Prefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MD5AuthenticationKey
The MD5 authentication key for session.

```yaml
Type: System.String
Parameter Sets: ParameterSetNameMd5Authentication
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerSessionIPv4Address
HelpSessionIPv4Prefix

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv4Prefix
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerSessionIPv6Address
HelpSessionIPv4Prefix

```yaml
Type: System.String
Parameter Sets: ParameterSetNameIPv6Prefix
Aliases:

Required: True
Position: 2
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## NOTES

## RELATED LINKS
