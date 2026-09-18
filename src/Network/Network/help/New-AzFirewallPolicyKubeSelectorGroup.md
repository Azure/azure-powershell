---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicykubeselectorgroup
schema: 2.0.0
---

# New-AzFirewallPolicyKubeSelectorGroup

## SYNOPSIS
Creates a Kube Selector Group on an Azure Firewall Policy.

## SYNTAX

### SetByNameParameterSet (Default)
```
New-AzFirewallPolicyKubeSelectorGroup -Name <String> [-PodSelector <PSKubeLabelSelector>]
 [-NamespaceSelector <PSKubeLabelSelector>] -ResourceGroupName <String> -FirewallPolicyName <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
New-AzFirewallPolicyKubeSelectorGroup -Name <String> [-PodSelector <PSKubeLabelSelector>]
 [-NamespaceSelector <PSKubeLabelSelector>] -FirewallPolicyObject <PSAzureFirewallPolicy>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyKubeSelectorGroup** cmdlet creates a Kube Selector Group, defined by a pod and/or namespace label selector, on an Azure Firewall Policy.

## EXAMPLES

### Example 1
```powershell
$expression = New-AzFirewallPolicyLabelSelectorExpression -Key "tier" -Operator In -Value "frontend","backend"
$podSelector = New-AzFirewallPolicyKubeLabelSelector -MatchLabel @{ app = "web" } -MatchExpression $expression
New-AzFirewallPolicyKubeSelectorGroup -Name "kubeSelectorGroup1" -ResourceGroupName "rg1" -FirewallPolicyName "firewallPolicy" -PodSelector $podSelector
```

This example creates a Kube Selector Group whose pod selector matches pods labeled app=web and tier in (frontend, backend).

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -FirewallPolicyName
The name of the firewall policy

```yaml
Type: String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FirewallPolicyObject
Firewall Policy.

```yaml
Type: PSAzureFirewallPolicy
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the Kube Selector Group

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceSelector
The namespace selector that matches Kubernetes namespaces by their labels.

```yaml
Type: PSKubeLabelSelector
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PodSelector
The pod selector that matches Kubernetes pods by their labels.

```yaml
Type: PSKubeLabelSelector
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyKubeSelectorGroupWrapper

## NOTES

## RELATED LINKS
