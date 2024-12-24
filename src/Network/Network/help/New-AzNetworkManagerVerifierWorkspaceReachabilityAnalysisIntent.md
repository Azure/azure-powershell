---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerverifierworkspacereachabilityanalysisintent
schema: 2.0.0
---

# New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent

## SYNOPSIS
To create a new Network Manager Verifier Workspace Reachability Analysis Intent

## SYNTAX

```
New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -VerifierWorkspaceName <String> [-Description <String>] -SourceResourceId <String>
 -DestinationResourceId <String> -IpTraffic <PSIPTraffic> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
**New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent** cmdlet creates a new Network Manager Verifier Workspace Reachability Analysis Intent
## EXAMPLES

### Example 1
```powershell
$ipTraffic = New-AzNetworkManagerIPTraffic -SourceIp @("192.168.1.10") -DestinationIp @("172.16.0.5") -SourcePort @("100") -DestinationPort @("99") -Protocol @("TCP");
New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -Name "analysisIntentTest24" -NetworkManagerName "testNM" -ResourceGroupName "testRG" -VerifierWorkspaceName "testVNV" -SourceResourceId "/subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM" -DestinationResourceId "/subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test" -IpTraffic $ipTraffic;
```

```output
Name                  : analysisIntentTest24
VerifierWorkspaceName : testVNV
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-10-15T18:45:22.9301207Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-10-15T18:45:22.9301207Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWorkspaces/testVNV/reachabilityA
                        nalysisIntents/analysisIntentTest24
```

Created a new Network Manager Verifier Workspace Reachability Analysis Intent

### Example 2
```powershell
New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -Name "analysisIntentTest23" -NetworkManagerName "testNM" -ResourceGroupName "testRG" -VerifierWorkspaceName "testVNV" -SourceResourceId "/subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM" -DestinationResourceId "/subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test" -IpTraffic (New-AzNetworkManagerIPTraffic -SourceIp @("192.168.1.10") -DestinationIp @("172.16.0.5") -SourcePort @("100") -DestinationPort @("99") -Protocol @("TCP"))
```

```output
Name                  : analysisIntentTest23
VerifierWorkspaceName : testVNV
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-10-15T18:47:37.9813771Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-10-15T18:47:37.9813771Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWorkspaces/testVNV/reachabilityA
                        nalysisIntents/analysisIntentTest23
```

Created a new Network Manager Verifier Workspace Reachability Analysis Intent

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
Description.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationResourceId
Destination resource ID.

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -IpTraffic
IP traffic details.

```yaml
Type: PSIPTraffic
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Reachability Analysis Intent name.

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

### -NetworkManagerName
The network manager name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -SourceResourceId
Source resource ID.

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

### -VerifierWorkspaceName
Verifier Workspace name.

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIPTraffic

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntent

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent](./Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent.md)

[Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent](./Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent.md)