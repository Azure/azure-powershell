---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerverifierworkspacereachabilityanalysisintent
schema: 2.0.0
---

# Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent

## SYNOPSIS
To get network manager verifier workspace reachability analysis intent.
## SYNTAX

### ByName (Default)
```
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent [-Name <String>] -NetworkManagerName <String>
 -ResourceGroupName <String> -VerifierWorkspaceName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByList
```
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -VerifierWorkspaceName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```
### ByResourceId
```
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```


## DESCRIPTION
When given a 'Name', the **Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent** cmdlet gets that specific Verifier Workspace Reachability Analysis Intent. When not given a 'Name', the **Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent** cmdlet gets a list of the Verifier Workspace Reachability Analysis Intents in the specified network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -NetworkManagerName "testNM" -ResourceGroupName "testRG" -VerifierWorkspaceName "testVerifierWorkspace9"
```

```output
Name                  : testReachabilityAnalysisIntent5
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-02-16T00:03:44.5882378Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-02-16T00:03:44.5882378Z"
                        }
Id                    : /subscriptions//00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Micro
                        soft.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9/reachabilit
                        yAnalysisIntents/testReachabilityAnalysisIntent5

Name                  : testReachabilityAnalysisIntenant6
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-02-16T00:19:07.6430128Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-02-16T00:19:07.6430128Z"
                        }
Id                    : /subscriptions//00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Micro
                        soft.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9/reachabilit
                        yAnalysisIntents/testReachabilityAnalysisIntenant6

Name                  : testReachabilityAnalysisIntenant7
VerifierWorkspaceName :
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-02-16T00:24:30.5939209Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-02-16T00:24:30.5939209Z"
                        }
Id                    : /subscriptions//00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Micro
                        soft.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9/reachabilit
                        yAnalysisIntents/testReachabilityAnalysisIntenant7
```

Gets all Verifier Workspace Reachability Analysis Intents in workspace 'testVerifierWorkspace9'

### Example 2

```powershell
Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent -NetworkManagerName "testNM" -ResourceGroupName "testRG" -VerifierWorkspaceName "testVerifierWorkspace9" -Name "testReachabilityAnalysisIntenant7"
```
```output
Name                  : testReachabilityAnalysisIntenant7
VerifierWorkspaceName : testVerifierWorkspace9
ResourceGroupName     : testRG
NetworkManagerName    : testNM
Properties            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntentProperties
Type                  : Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents
SystemData            : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText        : {
                          "CreatedBy": "test@email.com",
                          "CreatedByType": "User",
                          "CreatedAt": "2024-02-16T00:24:30.5939209Z",
                          "LastModifiedBy": "test@email.com",
                          "LastModifiedByType": "User",
                          "LastModifiedAt": "2024-02-16T00:24:30.5939209Z"
                        }
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Micro
                        soft.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9/reachabilit
                        yAnalysisIntents/testReachabilityAnalysisIntenant7
```

Gets the Verifier Workspace Reachability Analysis Intent for 'testReachabilityAnalysisIntenant7'

## PARAMETERS

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
Parameter Sets: ByName
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```


### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: ByList, ByName
Aliases:

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
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -VerifierWorkspaceName
The verifier workspace name.

```yaml
Type: System.String
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```
### -ResourceId
The Verifier Workspace Analysis Intent resource id.
```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: ReachabilityAnalysisIntentId

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisIntent

## NOTES

## RELATED LINKS
[New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent](./New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent.md)

[Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent](./Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent.md)
