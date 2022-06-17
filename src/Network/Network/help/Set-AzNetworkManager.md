---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/set-aznetworkmanager
schema: 2.0.0
---

# Set-AzNetworkManager

## SYNOPSIS
Updates a network manager.

## SYNTAX

```
Set-AzNetworkManager -ResourceGroupName <String> -NetworkManager <PSNetworkManager> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetworkManager** cmdlet updates a network manager.

## EXAMPLES

### Example 1
```powershell
PS C:\> $networkManager = Get-AzNetworkManager -ResourceGroupName "TestResourceGroup" -Name "TestNM"
PS C:\> $networkManager.Description = "Sample Description"
PS C:\> Set-AzNetworkManager -ResourceGroupName "TestResourceGroup" -NetworkManager $networkManager

Description                     : Sample Description
Location                        : eastus2euap
Id                              : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/provider
                                  s/Microsoft.Network/networkManagers/TestNM
Type                            : Microsoft.Network/networkManagers
Tag                             : {}
ProvisioningState               : Succeeded
NetworkManagerScopeAccesses     : [
                                    "SecurityAdmin",
                                    "SecurityUser"
                                  ]
NetworkManagerScopes            : {
                                    "ManagementGroups": [],
                                    "Subscriptions": [
                                      "/subscriptions/00000000-0000-0000-0000-000000000000"
                                    ]
                                  }
SystemData                      : {
                                    "CreatedBy": "user@microsoft.com",
                                    "CreatedByType": "User",
                                    "CreatedAt": "2021-10-05T04:15:42",
                                    "LastModifiedBy": "user@microsoft.com",
                                    "LastModifiedByType": "User",
                                    "LastModifiedAt": "2021-10-05T04:15:42"
                                  }
Name                            : TestNM
Etag                            : W/"00000000-0000-0000-0000-000000000000"
```
Example to update the description of a network manager TestNM

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

### -NetworkManager
The Network Manager

```yaml
Type: PSNetworkManager
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManager

## NOTES

## RELATED LINKS

[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)