---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: C0E1D4DF-232F-49C6-BE4C-05C8E8038329
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azfirewallapplicationrule
schema: 2.0.0
---

# New-AzFirewallApplicationRule

## SYNOPSIS
Creates a Firewall Application Rule.

## SYNTAX

### Default (Default)
```
New-AzFirewallApplicationRule -Name <String> [-Description <String>] -SourceAddress <String[]>
 [-SourceIpGroup <String[]>] [-TargetFqdn <String[]>] [-FqdnTag <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SourceIpGroup
```
New-AzFirewallApplicationRule -Name <String> [-Description <String>] [-SourceAddress <String[]>]
 -SourceIpGroup <String[]> [-TargetFqdn <String[]>] [-FqdnTag <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TargetFqdn
```
New-AzFirewallApplicationRule -Name <String> [-Description <String>] [-SourceAddress <String[]>]
 [-SourceIpGroup <String[]>] -TargetFqdn <String[]> -Protocol <String[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FqdnTag
```
New-AzFirewallApplicationRule -Name <String> [-Description <String>] [-SourceAddress <String[]>]
 [-SourceIpGroup <String[]>] [-FqdnTag <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallApplicationRule** cmdlet creates an application rule for Azure Firewall.

## EXAMPLES

### 1:  Create a rule to allow all HTTPS traffic from 10.0.0.0
```
New-AzFirewallApplicationRule -Name "https-rule" -Protocol "https:443" -TargetFqdn "*" -SourceAddress "10.0.0.0"
```

This example creates a rule which will allow all HTTPS traffic on port 443 from 10.0.0.0.

### 2:  Create a rule to allow WindowsUpdate for 10.0.0.0/24 subnet
```
New-AzFirewallApplicationRule -Name "windows-update-rule" -FqdnTag WindowsUpdate -SourceAddress "10.0.0.0/24"
```

This example creates a rule which will allow traffic for Windows Updates for 10.0.0.0/24 domain.

## PARAMETERS

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

### -Description
The description of the rule

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```
### -FqdnTag
Fqdn Tags

```yaml
Type: System.String[]
Parameter Sets: Default, SourceIpGroup, FqdnTag
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Application Rule

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

### -Protocol
The protocols of the rule

```yaml
Type: System.String[]
Parameter Sets: TargetFqdn
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAddress
The source ipgroup of the rule

```yaml
Type: System.String[]
Parameter Sets: Default
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String[]
Parameter Sets: SourceIpGroup, TargetFqdn, FqdnTag
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceIpGroup
The source addresses of the rule

```yaml
Type: System.String[]
Parameter Sets: Default, TargetFqdn, FqdnTag
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String[]
Parameter Sets: SourceIpGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetFqdn
The source addresses of the rule

```yaml
Type: System.String[]
Parameter Sets: Default, SourceIpGroup
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String[]
Parameter Sets: TargetFqdn
Aliases:

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallApplicationRule

## NOTES

## RELATED LINKS

[New-AzFirewallApplicationRuleCollection](./New-AzFirewallApplicationRuleCollection.md)

[New-AzFirewall](./New-AzFirewall.md)

[Get-AzFirewall](./Get-AzFirewall.md)

[Get-AzFirewallFqdnTag](./Get-AzFirewallFqdnTag.md)
