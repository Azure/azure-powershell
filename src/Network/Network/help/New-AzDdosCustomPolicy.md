---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicy
schema: 2.0.0
---

# New-AzDdosCustomPolicy

## SYNOPSIS
Creates a DDoS custom policy.

## SYNTAX

```
New-AzDdosCustomPolicy -ResourceGroupName <String> -Name <String> -Location <String> [-Tag <Hashtable>]
 [-DetectionRule <PSDdosCustomPolicyDetectionRule[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDdosCustomPolicy** cmdlet creates a DDoS custom policy with detection rules. A DDoS custom policy allows you to define custom detection thresholds for different types of traffic (TCP, UDP, TCP SYN).

## EXAMPLES

### Example 1: Create a DDoS custom policy with a single detection rule
```powershell
$rule = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
$policy = New-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -Location "eastus" -DetectionRule @($rule)
```

This example creates a DDoS custom policy with a single TCP detection rule.

### Example 2: Create a DDoS custom policy with multiple detection rules
```powershell
$tcpRule = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
$udpRule = New-AzDdosCustomPolicyDetectionRule -Name "udpRule1" -TrafficType Udp -PacketsPerSecond 100000
$tcpSynRule = New-AzDdosCustomPolicyDetectionRule -Name "tcpSynRule1" -TrafficType TcpSyn -PacketsPerSecond 50000
$policy = New-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -Location "eastus" -DetectionRule @($tcpRule, $udpRule, $tcpSynRule)
```

This example creates a DDoS custom policy with three detection rules for different traffic types.

### Example 3: Create a DDoS custom policy with tags
```powershell
$rule = New-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" -TrafficType Tcp -PacketsPerSecond 1000000
$tags = @{"Environment" = "Production"; "Owner" = "NetworkTeam"}
$policy = New-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" -Location "eastus" -DetectionRule @($rule) -Tag $tags
```

This example creates a DDoS custom policy with tags for resource management.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -DetectionRule
Specifies DDoS detection rules for the policy. Use **New-AzDdosCustomPolicyDetectionRule** to create detection rules.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyDetectionRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the location of the DDoS custom policy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the DDoS custom policy to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group of the DDoS custom policy to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies a hash table with resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicy](./Remove-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicyDetectionRule](./New-AzDdosCustomPolicyDetectionRule.md)
