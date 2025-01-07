---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-aznetworkmanagerverifierworkspace
schema: 2.0.0
---

# Set-AzNetworkManagerVerifierWorkspace

## SYNOPSIS
To update network manager verifier workspace.

## SYNTAX

```
Set-AzNetworkManagerVerifierWorkspace -InputObject <PSVerifierWorkspace> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
**Set-AzNetworkManagerVerifierWorkspace** cmdlet enables the details of a network manager verifier workspace to be updated
## EXAMPLES

### Example 1
```powershell
$verifierWorkspace = Get-AzNetworkManagerVerifierWorkspace -ResourceGroupName "testRG" -NetworkManagerName "testNM" -Name "AmeWorkspace"
$verifierWorkspace.Properties.Description = "Updated description"
Set-AzNetworkManagerVerifierWorkspace -InputObject $verifierWorkspace
```

```output
Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "Updated description"
                     }
Name               : AmeWorkspace
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-04-08T22:14:28.9064474Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-15T17:48:28.0902461Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWorkspaces/AmeWorkspace

```

Changed the description of the Verifier Workspace 'AmeWorkspace' to "Updated description"
### Example 2
```powershell
$verifierWorkspace = Get-AzNetworkManagerVerifierWorkspace -ResourceGroupName "testRG" -NetworkManagerName "testNM" -Name "testVerifierWorkspace5"
$tags = [System.Collections.Generic.Dictionary[string, string]]::new()
$tags.Add("testTag", "test")
$verifierWorkspace.Tags = $tags
Set-AzNetworkManagerVerifierWorkspace -InputObject $verifierWorkspace
```

```output
Location           : eastus2euap
Tags               : {[testTag, test]}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
                     Name   Value
                     =====  =====
                     testTag   test

PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "string"
                     }
Name               : testVerifierWorkspace5
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-01-30T16:25:07.4175577Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-15T18:00:26.5078204Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-00000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace5
```

Added the tag of of name 'testTag' and value 'test' to the Verifier Workspace 'testVerifierWorkspace5'

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

### -InputObject
The Verifier Workspace

```yaml
Type: PSVerifierWorkspace
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspace

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspace

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerVerifierWorkspace](./Get-AzNetworkManagerVerifierWorkspace.md)

[New-AzNetworkManagerVerifierWorkspace](./New-AzNetworkManagerVerifierWorkspace.md)

[Remove-AzNetworkManagerVerifierWorkspace](./Remove-AzNetworkManagerVerifierWorkspace.md)