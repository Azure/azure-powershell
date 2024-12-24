---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkmanagerverifierworkspace
schema: 2.0.0
---

# Get-AzNetworkManagerVerifierWorkspace

## SYNOPSIS
To get network manager verifier workspace

## SYNTAX

### ByName (Default)
```
Get-AzNetworkManagerVerifierWorkspace [-Name <String>] -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByList
```
Get-AzNetworkManagerVerifierWorkspace -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```
### ByResourceId
```
Get-AzNetworkManagerVerifierWorkspace -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
When given a 'Name', the **Get-AzNetworkManagerVerifierWorkspace** cmdlet gets that specific network manager verifier workspace. When not given a 'Name', the **Get-AzNetworkManagerVerifierWorkspace** cmdlet gets a list of the network manager verifier workspaces in the specified network manager.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkManagerVerifierWorkspace -NetworkManagerName "testNM" -ResourceGroupName "testRG"
```

```output
Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": ""
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
                       "LastModifiedAt": "2024-04-08T22:14:28.9064474Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/AmeWorkspace

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": ""
                     }
Name               : ameWorkspace2
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-04-08T22:34:58.4212634Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-04-08T22:34:58.4212634Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/ameWorkspace2

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "string"
                     }
Name               : testworkspaceame1
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-04-08T23:02:36.3712Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-04-08T23:02:36.3712Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testworkspaceame1

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": ""
                     }
Name               : testVNV
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-05-03T20:34:19.9181023Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-05-03T20:34:19.9181023Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testVNV

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
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
                       "LastModifiedAt": "2024-01-30T16:25:07.4175577Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace5

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "string"
                     }
Name               : testVerifierWorkspace8
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-02-15T23:35:24.1880643Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace8

Location           : eastus2euap
Tags               : {}
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "string"
                     }
Name               : testVerifierWorkspace9
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-02-16T00:03:39.541236Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-02-16T00:24:13.1874766Z"
                     }
Id                 : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9
```

Gets all network manager verifier workspaces in network manager 'testNM'.

### Example 2

```powershell
Get-AzNetworkManagerVerifierWorkspace -Name "testVerifierWorkspace9" -NetworkManagerName "testNM" -ResourceGroupName "testRG"
```

```output
Location           : eastus2euap
Tags               :
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspaceProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "Description": "string"
                     }
Name               : testVerifierWorkspace9
ResourceGroupName  : testRG
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/verifierWorkspaces
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-02-16T00:03:39.541236Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-02-16T00:24:13.1874766Z"
                     }
Id                 : /subscriptions//00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsof
                     t.Network/networkManagers/testNM/verifierWorkspaces/testVerifierWorkspace9
```
Gets the network manager verifier workspace of name'testVerifierWorkspace9'.

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
Parameter Sets: ByList, ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```
### -ResourceId
The Verifier Workspace resource id.
```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: VerifierWorkspaceId

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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSVerifierWorkspace

## NOTES

## RELATED LINKS
[New-AzNetworkManagerVerifierWorkspace](./New-AzNetworkManagerVerifierWorkspace.md)

[Set-AzNetworkManagerVerifierWorkspace](./Set-AzNetworkManagerVerifierWorkspace.md)

[Remove-AzNetworkManagerVerifierWorkspace](./Remove-AzNetworkManagerVerifierWorkspace.md)
