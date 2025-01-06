---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanageripampool
schema: 2.0.0
---

# New-AzNetworkManagerIpamPool

## SYNOPSIS
Creates a new IPAM pool.

## SYNTAX

```
New-AzNetworkManagerIpamPool -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -Location <String> -AddressPrefix <System.Collections.Generic.List`1[System.String]> [-Description <String>]
 [-DisplayName <String>] [-ParentPoolName <String>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerIpamPool** cmdlet creates a new IPAM pool in the given Network Manager.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerIpamPool -Name testCmdletPool -NetworkManagerName testNM -ResourceGroupName testRG -Location eastus -AddressPrefix @("10.0.0.0/24")
```

```output
Location           : eastus
Tags               :
Properties         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPoolProperties
TagsTable          :
PropertiesText     : {
                       "ProvisioningState": "Succeeded",
                       "DisplayName": "",
                       "IPAddressType": [
                         "IPv4"
                       ],
                       "AddressPrefixes": [
                         "10.0.0.0/24"
                       ]
                     }
Name               : testCmdletPool
ResourceGroupName  : testRGg
NetworkManagerName : testNM
Type               : Microsoft.Network/networkManagers/ipamPools
SystemData         : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText     : {
                       "CreatedBy": "test@email.com",
                       "CreatedByType": "User",
                       "CreatedAt": "2024-10-02T22:08:42.6972318Z",
                       "LastModifiedBy": "test@email.com",
                       "LastModifiedByType": "User",
                       "LastModifiedAt": "2024-10-02T22:08:42.6972318Z"
                     }
Id                 : /subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/testRG/providers/Microsoft.Network/networkManagers/testNM/ipamPools/testCmdletPool
```

A new IPAM pool was created called 'testCmdletPool' in the Network Manager 'testNM'

## PARAMETERS

### -AddressPrefix
The address prefixes to assign.

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

### -DisplayName
Display name.

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

### -Location
location.

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

### -ParentPoolName
Name of the parent pool name to assign this pool to.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
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

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSIpamPool

## NOTES

## RELATED LINKS

[Remove-AzNetworkManagerIpamPool](./Remove-AzNetworkManagerIpamPool.md)

[Get-AzNetworkManagerIpamPool](./Get-AzNetworkManagerIpamPool.md)

[Set-AzNetworkManagerIpamPool](./Set-AzNetworkManagerIpamPool.md)