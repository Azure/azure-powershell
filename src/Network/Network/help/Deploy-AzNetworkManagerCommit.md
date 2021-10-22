---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/deploy-aznetworkmanagercommit
schema: 2.0.0
---

# Deploy-AzNetworkManagerCommit

## SYNOPSIS
Deploys network manager commit

## SYNTAX

```
Deploy-AzNetworkManagerCommit -Name <String> -ResourceGroupName <String>
 -TargetLocation <System.Collections.Generic.List`1[System.String]>
 [-ConfigurationId <System.Collections.Generic.List`1[System.String]>] -CommitType <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Deploy-AzNetworkManagerCommit** cmdlet deploys network manager commit

## EXAMPLES

### Example 1
```powershell
PS C:\> [System.Collections.Generic.List[string]]$configids  = @()
PS C:\> $configids.Add($TestConfigId);
PS C:\> [System.Collections.Generic.List[String]]$regions = @()  
PS C:\> $regions.Add("centraluseuap")
PS C:\> Deploy-AzNetworkManagerCommit -ResourceGroupName TestRGName -Name TestNMName -TargetLocation $regions -ConfigurationId $configids -CommitType "Connectivity" 

```

The example is used to commit connecitivity confgurations $TestConfigId on region centraluseuap.

### Example 2
```powershell
PS C:\> [System.Collections.Generic.List[String]]$regions = @()  
PS C:\> $regions.Add("centraluseuap")
PS C:\> Deploy-AzNetworkManagerCommit -ResourceGroupName TestRGName -Name TestNMName -TargetLocation $regions -CommitType "Connectivity" 

```

The example is used to uncommit all connecitivity confgurations on region centraluseuap.

## PARAMETERS

### -CommitType
Commit Type.

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

### -ConfigurationId
List of configuration ids.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept wildcard characters: False
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
Accept wildcard characters: False
```

### -TargetLocation
List of target locations.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
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

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerCommit

## NOTES

## RELATED LINKS

[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)