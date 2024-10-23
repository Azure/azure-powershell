---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/deploy-aznetworkmanagercommit
schema: 2.0.0
---

# Deploy-AzNetworkManagerCommit

## SYNOPSIS
Deploys a network manager commit.

## SYNTAX

```
Deploy-AzNetworkManagerCommit -Name <String> -ResourceGroupName <String> -TargetLocation <String[]>
 [-ConfigurationId <String[]>] -CommitType <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Deploy-AzNetworkManagerCommit** cmdlet deploys a network manager commit.

## EXAMPLES

### Example 1
```powershell
$regions = @("eastus", "westus")
$configIds = @("/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/connectivityConfigurations/psConnectivityConfigMesh")
Deploy-AzNetworkManagerCommit -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -TargetLocation $regions -ConfigurationId $configids -CommitType "Connectivity"
```

This example is used to commit connecitivity confguration in East US and West US regions.

### Example 2
```powershell
$regions = @( "westus")
Deploy-AzNetworkManagerCommit -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -TargetLocation $regions -CommitType "Connectivity"
```

This example is used to uncommit all connecitivity confgurations in West US region.

### Example 3
```powershell
$regions = @( "westus")
$configIds = @("/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityAdminConfigurations/psSecurityAdminConfig")
Deploy-AzNetworkManagerCommit -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -TargetLocation $regions -CommitType "SecurityAdmin" -ConfigurationId $configids
```

This example is used to commit a security admin config in West US region.

### Example 3
```powershell
$regions = @( "westus")
$configIds = @("/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/routingConfigurations/psRoutingConfig")
Deploy-AzNetworkManagerCommit -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -TargetLocation $regions -CommitType "Routing" -ConfigurationId $configids
```

This example is used to commit a routing config in West US region.

### Example 3
```powershell
$regions = @( "westus")
$configIds = @("/subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/securityUserConfigurations/psSecurityUserConfig")
Deploy-AzNetworkManagerCommit -ResourceGroupName "psResourceGroup" -Name "psNetworkManager" -TargetLocation $regions -CommitType "SecurityUser" -ConfigurationId $configids
```

This example is used to commit a security user config in West US region.

## PARAMETERS

### -CommitType
Commit Type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: SecurityAdmin, Connectivity, Routing, SecurityUser

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ConfigurationId
List of configuration ids.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -TargetLocation
List of target locations.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### System.String

### System.String[]	

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerCommit

## NOTES

## RELATED LINKS

[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)

[Set-AzNetworkManager](./Set-AzNetworkManager.md)
