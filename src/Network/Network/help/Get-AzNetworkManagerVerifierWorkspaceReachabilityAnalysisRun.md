---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerverifierworkspacereachabilityanalysisrun
schema: 2.0.0
---

# Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun

## SYNOPSIS
To get network manager verifier workspace reachability analysis run.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> -workspaceName <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Expand
```
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -workspaceName <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
When given a 'Name', the **Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun** cmdlet gets that specific network manager verifier workspace reachability analysis run. When not given a 'Name', the **Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun** cmdlet gets a list of the network manager verifier workspace reachability analysis runs in the specified workspace.
## EXAMPLES

### Example 1
```powershell
 Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -NetworkManagerName "testNM" -ResourceGroupName "testRG" -workspaceName "testVNV"
```

```output
Name                  : testAsyncOpBehvaiorRun
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-05T19:39:38.2563968Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-05T19:40:01.1132044Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testAsyncOpBehvaiorRun

Name                  : testrun
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T16:01:54.313026Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T16:02:07.4222816Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrun

Name                  : testrun1
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T16:04:57.7083709Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T16:05:08.4340122Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrun1

Name                  : testrun2
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T16:07:08.2595595Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T16:07:18.9324364Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrun2

Name                  : testrun3
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T16:08:38.3602762Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T16:08:50.960041Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrun3

Name                  : testrunfan1
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T21:03:46.2977531Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T21:03:59.9659393Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrunfan1
```
Gets list of network manager verifier workspace reachability analysis runs for 'testVNV' verifier workspace.

### Example 2
```powershell
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -NetworkManagerName "testNM" -ResourceGroupName "testRG" -workspaceName "testVNV" -Name "testrun"
```

```output
Name                  : testrun
VerifierWorkspaceName : testVNV
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRunProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-09-19T16:01:54.313026Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-09-19T16:02:07.4222816Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierW
                        orkspaces/testVNV/reachabilityAnalysisRuns/testrun
```

Gets network manager verifier workspace reachability analysis run for 'testrun'.

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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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
Accept wildcard characters: True
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
Accept wildcard characters: True
```

### -workspaceName
The verifier workspace name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRun

## NOTES

## RELATED LINKS
