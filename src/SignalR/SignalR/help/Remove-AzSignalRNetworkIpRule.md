---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/remove-azsignalrnetworkiprule
schema: 2.0.0
---

# Remove-AzSignalRNetworkIpRule

## SYNOPSIS
Remove one or more IP rules from the Network ACLs of an Azure SignalR Service instance.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Remove-AzSignalRNetworkIpRule [-ResourceGroupName <String>] [-Name] <String> -IpRule <PSIpRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzSignalRNetworkIpRule -ResourceId <String> -IpRule <PSIpRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzSignalRNetworkIpRule -InputObject <PSSignalRResource> -IpRule <PSIpRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Removes the specified IP rule entries (created with New-AzSignalRNetworkIpRuleObject) from the existing list of IP rules in the Network ACL configuration of an Azure SignalR Service. Only exact matches (action and value) are removed.

## EXAMPLES

### Example 1: Remove a rule using resource group & name (ResourceGroupParameterSet)
```powershell
$rg = "my-rg"
$signalrName = "mysignalr"
$rule = New-AzSignalRNetworkIpRuleObject -Value "10.1.0.0/16" -Action Allow
$updated = Remove-AzSignalRNetworkIpRule -ResourceGroupName $rg -Name $signalrName -IpRule $rule
```
Removes the allow rule for the given CIDR range from the specified SignalR instance.

### Example 2: Remove a rule using resource ID (ResourceIdParameterSet)
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "my-rg" -Name "mysignalr"
$denyRule = New-AzSignalRNetworkIpRuleObject -Value "20.2.2.2" -Action Deny
$acls = Remove-AzSignalRNetworkIpRule -ResourceId $signalr.Id -IpRule $denyRule
```
Removes a deny rule identified by value/action using the resource ID parameter set.

### Example 3: Remove rules via pipeline SignalR object (InputObjectParameterSet)
```powershell
$rule1 = New-AzSignalRNetworkIpRuleObject -Value "30.3.3.3" -Action Allow
$rule2 = New-AzSignalRNetworkIpRuleObject -Value "40.4.0.0/24" -Action Deny
Get-AzSignalR -ResourceGroupName "my-rg" -Name "mysignalr" | Remove-AzSignalRNetworkIpRule -IpRule $rule1,$rule2
```
Pipes the SignalR resource object and removes two IP rules at once.

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

### -InputObject
The SignalR resource object.

```yaml
Type: PSSignalRResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IpRule
IP rule object(s) created by New-AzSignalRNetworkIpRuleObject.

```yaml
Type: PSIpRule[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The SignalR service name.

```yaml
Type: String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name. The default one will be used if not specified.

```yaml
Type: String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The SignalR service resource ID.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

### Microsoft.Azure.Commands.SignalR.Models.PSIpRule[]

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRNetworkAcls

## NOTES

## RELATED LINKS
