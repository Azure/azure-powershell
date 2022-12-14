---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:https://docs.microsoft.com/powershell/module/az.network/new-azfirewallpolicyexplicitproxy
schema: 2.0.0
---

# New-AzFirewallPolicyExplicitProxy

## SYNOPSIS
Creates a new Explicit Proxy 

## SYNTAX

```
New-AzFirewallPolicyExplicitProxy [-EnableExplicitProxy] [-HttpPort <Int32>] [-HttpsPort <Int32>]
 [-EnablePacFile] [-PacFilePort <Int32>] [-PacFile <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyExplicitProxy** cmdlet creates an explicit proxy

## EXAMPLES

### Example 1
```powershell
 New-AzFirewallPolicyExplicitProxy -EnableExplicitProxy  -HttpPort 100 -HttpsPort 101 -EnablePacFile  -PacFilePort 130 -PacFile "sampleurlfortesting.blob.core.windowsnet/nothing"
```
```output
		EnableExplicitProxy	: true	
		EnablePacFile	    : true	
		HttpPort	        : 100	
		HttpsPort	        : 101	
		PacFile	            : "sampleurlfortesting.blob.core.windowsnet/nothing"
		PacFilePort	        : 130	
```
This example creates an explicit proxy with provided settings

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

### -EnableExplicitProxy
Enable Explicit Proxy.
By default it is disabled.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnablePacFile
Enable PAC File.
By default it is disabled.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPort
Port number for explicit proxy http protocol.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsPort
Port number for explicit proxy https protocol.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PacFile
SAS URL for PAC file.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PacFilePort
Port number for firewall to serve PAC file.

```yaml
Type: Int32
Parameter Sets: (All)
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyExplicitProxy

## NOTES

## RELATED LINKS
[New-AzFireWallPolicy](./New-AzFireWallPolicy.md)

[Set-AzFireWallPolicy](./Set-AzFireWallPolicy.md)