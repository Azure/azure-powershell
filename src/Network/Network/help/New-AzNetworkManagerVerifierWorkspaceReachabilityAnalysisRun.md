---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerverifierworkspacereachabilityanalysisrun
schema: 2.0.0
---

# New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun

## SYNOPSIS
To create network manager verifier workspace reachability analysis run

## SYNTAX

```
New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -VerifierWorkspaceName <String> [-Description <String>] -IntentId <String>
 [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun** cmdlet creates a new network manager verifier workspace reachability analysis run.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceGroupName "testRG"  -VerifierWorkspaceName "paigeVNV" -Name "TestReachabilityAnalysisRun3" -NetworkManagerName "testNM" -IntentId “/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWorkspaces/paigeVNV/reachabilityAnalysisIntents/test”
```

```output
Name                  : TestReachabilityAnalysisRun3
VerifierWorkspaceName : paigeVNV
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-10-12T17:55:25.4518154Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-10-12T17:55:25.4518154Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/paigeVNV/reachabilityAnalysisRuns/TestReachabilityAnalysisRun3
```

Created a new network manager verifier workspace reachability analysis run named TestReachabilityAnalysisRun3

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -Description
Description.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -IntentId
Intent ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Reachability Analysis Run name.

```yaml
Type: String
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
Type: String
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
Type: ActionPreference
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
Type: String
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
Type: String
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRun

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun](./Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun.md)

[Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun](./Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun.md)