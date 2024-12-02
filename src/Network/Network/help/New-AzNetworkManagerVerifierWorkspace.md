---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerverifierworkspace
schema: 2.0.0
---

# New-AzNetworkManagerVerifierWorkspace

## SYNOPSIS
To create network manager verifier workspace.

## SYNTAX

```
New-AzNetworkManagerVerifierWorkspace -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -Location <String> [-Description <String>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
**New-AzNetworkManagerVerifierWorkspace** cmdlet creates a new network manager verifier workspace.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerVerifierWorkspace -Name "testVerifierWorkspace10" -NetworkManagerName "testNM" -ResourceGroupName "testRG" -Location "eastus2euap "
```

```output
Location           : eastus2euap
Tags               :
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded"
                     }
Name               : testVerifierWorkspace10
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-10-12T17:17:22.4851889Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-12T17:17:22.4851889Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/verifierWork
                     spaces/testVerifierWorkspace10
```

Created a new network manager verifier workspace of name 'testVerifierWorkspace10'.

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

### -Location
location.

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
The resource name.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspace

## NOTES

## RELATED LINKS
[Get-AzNetworkManagerVerifierWorkspace](./Get-AzNetworkManagerVerifierWorkspace.md)

[Set-AzNetworkManagerVerifierWorkspace](./Set-AzNetworkManagerVerifierWorkspace.md)

[Remove-AzNetworkManagerVerifierWorkspace](./Remove-AzNetworkManagerVerifierWorkspace.md)

