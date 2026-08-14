---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azfirewallpolicykubeselectorgroup
schema: 2.0.0
---

# Get-AzFirewallPolicyKubeSelectorGroup

## SYNOPSIS
Gets a Kube Selector Group from an Azure Firewall Policy.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzFirewallPolicyKubeSelectorGroup [-Name <String>] -ResourceGroupName <String>
 -AzureFirewallPolicyName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByInputObjectParameterSet
```
Get-AzFirewallPolicyKubeSelectorGroup [-Name <String>] -AzureFirewallPolicy <PSAzureFirewallPolicy>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzFirewallPolicyKubeSelectorGroup** cmdlet gets a single Kube Selector Group by name, or lists all Kube Selector Groups, from an Azure Firewall Policy.

## EXAMPLES

### Example 1
```powershell
Get-AzFirewallPolicyKubeSelectorGroup -Name "kubeSelectorGroup1" -ResourceGroupName "rg1" -AzureFirewallPolicyName "firewallPolicy"
```

This example gets the Kube Selector Group named kubeSelectorGroup1 from the firewall policy.

## PARAMETERS

### -AzureFirewallPolicy
Firewall Policy.

```yaml
Type: PSAzureFirewallPolicy
Parameter Sets: GetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureFirewallPolicyName
The Firewall policy name

```yaml
Type: String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: GetByNameParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: String
Parameter Sets: GetByInputObjectParameterSet
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
