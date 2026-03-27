---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azfirewallpacketcaptureoperation
schema: 2.0.0
---

# Invoke-AzFirewallPacketCaptureOperation

## SYNOPSIS
Invokes a Start/Status/Stop packet capture operation request on Azure Firewall

## SYNTAX

```
Invoke-AzFirewallPacketCaptureOperation -AzureFirewall <PSAzureFirewall>
 -Parameter <PSAzureFirewallPacketCaptureParameters> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Invokes a Start/Status/Stop packet capture operation request on Azure Firewall

## EXAMPLES

### Example 1:  Invokes a start packet capture operation on Azure Firewall
```
$azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location

$azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname

# Create a filter rules
$filter1 = New-AzFirewallPacketCaptureRule -Source "10.0.0.2","192.123.12.1" -Destination "172.32.1.2" -DestinationPort "80","443"
$filter2 = New-AzFirewallPacketCaptureRule -Source "10.0.0.5" -Destination "172.20.10.2" -DestinationPort "80","443"
    
# Create the firewall packet capture parameters
$Params =  New-AzFirewallPacketCaptureParameter  -DurationInSeconds 1200 -NumberOfPacketsToCapture 20000 -SASUrl $sasurl -Filename "AzFwPowershellPacketCapture" -Flag "Syn","Ack" -Protocol "Any" -Filter $Filter1, $Filter2 -Operation "Start"

# Invoke a firewall packet capture
Invoke-AzFirewallPacketCaptureOperation -AzureFirewall $azureFirewall -Parameter $Params
```

This example invokes a start packet capture request on azure firewall with the parameters mentioned.

### Example 2: Invokes a check status packet capture operation on Azure Firewall
```
$azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location

$azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname

# Create the firewall packet capture parameters
$Params =  New-AzFirewallPacketCaptureParameter  -Operation "Status"

# Invoke a firewall packet capture
Invoke-AzFirewallPacketCaptureOperation -AzureFirewall $azureFirewall -Parameter $Params
```

This example invokes a check status packet capture request on azure firewall with the parameters mentioned.

### Example 3: Invokes a stop packet capture operation on Azure Firewall
```
$azureFirewall = New-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname -Location $location

$azFirewall = Get-AzFirewall -Name $azureFirewallName -ResourceGroupName $rgname

# Create the firewall packet capture parameters
$Params =  New-AzFirewallPacketCaptureParameter -Operation "Stop"

# Invoke a firewall packet capture
Invoke-AzFirewallPacketCaptureOperation -AzureFirewall $azureFirewall -Parameter $Params
```

This example invokes a stop packet capture request on azure firewall with the parameters mentioned.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -AzureFirewall
The AzureFirewall

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewall
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameter
The packet capture parameters

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureParameters
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewall

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureParameters

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPacketCaptureResponse

## NOTES

## RELATED LINKS
