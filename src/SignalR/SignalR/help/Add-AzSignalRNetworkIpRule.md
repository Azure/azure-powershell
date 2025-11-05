---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/add-azsignalrnetworkiprule
schema: 2.0.0
---

# Add-AzSignalRNetworkIpRule

## SYNOPSIS
Add one or more IP rules to the Network ACLs of an Azure SignalR Service instance.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Add-AzSignalRNetworkIpRule [-ResourceGroupName <String>] [-Name] <String> -IpRule <PSIpRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Add-AzSignalRNetworkIpRule -ResourceId <String> -IpRule <PSIpRule[]> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Add-AzSignalRNetworkIpRule -InputObject <PSSignalRResource> -IpRule <PSIpRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Adds IP rule entries (created with New-AzSignalRNetworkIpRuleObject) to the existing list of IP rules in the Network ACL configuration of an Azure SignalR Service. The cmdlet retrieves the current resource, appends the supplied rules, updates the service, and returns the updated Network ACL object. Duplicate rules are not filtered automatically; adding an identical rule will create another entry.

## EXAMPLES

### Example 1: Add IP rules using resource group & name (ResourceGroupParameterSet)
```powershell
$rg = "my-rg"
$signalrName = "mysignalr"
$rule1 = New-AzSignalRNetworkIpRuleObject -Value "10.1.0.0/16" -Action Allow
$rule2 = New-AzSignalRNetworkIpRuleObject -Value "20.2.2.2" -Action Deny
$acls = Add-AzSignalRNetworkIpRule -ResourceGroupName $rg -Name $signalrName -IpRule $rule1,$rule2
$acls.IPRules
```
Adds two rules (an allow CIDR and a deny single IP) to the SignalR instance identified by resource group and name.

### Example 2: Add IP rule using resource ID (ResourceIdParameterSet)
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "my-rg" -Name "mysignalr"
$rule = New-AzSignalRNetworkIpRuleObject -Value "30.3.3.3" -Action Allow
$acls = Add-AzSignalRNetworkIpRule -ResourceId $signalr.Id -IpRule $rule
```
Retrieves the SignalR instance, then adds a single allow rule using the resource ID parameter set.

### Example 3: Add IP rules via pipeline SignalR object (InputObjectParameterSet)
```powershell
$ruleAllow = New-AzSignalRNetworkIpRuleObject -Value "40.4.0.0/24" -Action Allow
$ruleDeny  = New-AzSignalRNetworkIpRuleObject -Value "50.5.5.5" -Action Deny
Get-AzSignalR -ResourceGroupName "my-rg" -Name "mysignalr" | Add-AzSignalRNetworkIpRule -IpRule $ruleAllow,$ruleDeny
```
Pipes a SignalR resource object into the cmdlet and adds two IP rules.

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
