---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:  https://learn.microsoft.com/powershell/module/az.network/remove-aznetworkmanagerverifierworkspacereachabilityanalysisrun
schema: 2.0.0
---

# Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun

## SYNOPSIS
To remove network manager verifier workspace reachability analysis run.

## SYNTAX


### ByName (Default)

```
Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -Name <String> -NetworkManagerName <String>
 -ResourceGroupName <String> -VerifierWorkspaceName <String> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```
### ByInputObject
```
Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -InputObject <PSReachabilityAnalysisRun> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -ResourceId <String> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```
## DESCRIPTION
**Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun** cmdlet removes a network manager verifier workspace reachability analysis run.

## EXAMPLES

### Example 1
```powershell
 Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun -Name TestReachabilityAnalysisRun3 -NetworkManagerName "testNM" -ResourceGroupName "testRG" -VerifierWorkspaceName "testVNV"
 ```

```output
Confirm
Are you sure you want to remove resource 'TestReachabilityAnalysisRun3'
[Y] Yes  [N] No  [S] Suspend  [?] Help (default is "Y"): Y
```

Removed the network manager verifier workspace reachability analysis run 'TestReachabilityAnalysisRun3'.

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

### -Force
Do not ask for confirmation.

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```
### -InputObject
The Verifier Workspace Analysis Run.
```yaml
Type: Microsoft.Azure.Commands.Network.Models.NetworkManager.PSReachabilityAnalysisRun
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
{{ Fill PassThru Description }}

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
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VerifierWorkspaceName
The verifier workspace name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```
### -ResourceId
The resource id.
```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun](./Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun.md)

[New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun](./New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun.md)