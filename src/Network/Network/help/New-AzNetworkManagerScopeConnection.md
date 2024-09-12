---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerscopeconnection
schema: 2.0.0
---

# New-AzNetworkManagerScopeConnection

## SYNOPSIS
Creates a scope connection.

## SYNTAX

```
New-AzNetworkManagerScopeConnection -Name <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -TenantId <String> -ResourceId <String> [-Description <String>] [-AsJob] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerScopeConnection** cmdlet creates a scope connection.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerScopeConnection -ResourceGroupName psResourceGroup -NetworkManagerName psNetworkManager -Name "subConnection" -TenantId "00001111-aaaa-2222-bbbb-3333cccc4444" -ResourceId "/subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884" -Description "SampleDescription"
```

```output
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
ResourceId        : /subscriptions/0fd190fa-dd1c-4724-b7f6-c5cc3ba5c884
ConnectionState   : Pending
DisplayName       :
Description       : SampleDescription
Type              : Microsoft.Network/networkManagers/scopeConnections
ProvisioningState :
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-07T23:53:52.6942092Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-07T23:53:52.6942092Z"
                    }
Name              : subConnection
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/scopeConnections/subConnection
```

Creates a scope connection to a cross-tenant subscription.

### Example 2
```powershell
New-AzNetworkManagerScopeConnection -ResourceGroupName psResourceGroup -NetworkManagerName psNetworkManager -Name "mgConnection" -TenantId "00001111-aaaa-2222-bbbb-3333cccc4444" -ResourceId "/providers/Microsoft.Management/managementGroups/newMG" -Description "SampleDescription"
```

```output
TenantId          : 00001111-aaaa-2222-bbbb-3333cccc4444
ResourceId        : /providers/Microsoft.Management/managementGroups/newMG
ConnectionState   : Pending
DisplayName       :
Description       : SampleDescription
Type              : Microsoft.Network/networkManagers/scopeConnections
ProvisioningState :
SystemData        : Microsoft.Azure.Commands.Network.Models.NetworkManager.PSSystemData
SystemDataText    : {
                      "CreatedBy": "jaredgorthy@microsoft.com",
                      "CreatedByType": "User",
                      "CreatedAt": "2022-08-07T23:55:14.7516201Z",
                      "LastModifiedBy": "jaredgorthy@microsoft.com",
                      "LastModifiedByType": "User",
                      "LastModifiedAt": "2022-08-07T23:55:14.7516201Z"
                    }
Name              : mgConnection
Etag              :
Id                : /subscriptions/f0dc2b34-dfad-40e4-83e0-2309fed8d00b/resourceGroups/psResourceGroup/providers/Microsoft.Network/networkManagers/psNetworkManager/scopeConnections/mgConnection
```

Creates a scope connection to a cross-tenant management group.

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -Force
Do not ask for confirmation if you want to overwrite a resource.

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
Accept wildcard characters: True
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

### -ResourceId
Resource Id of the subscription or management group to be managed.
Resource IDs should be in the form '/subscriptions/{subscriptionId}' or '/providers/Microsoft.Management/managementGroups/{managementGroupId}'.

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

### -TenantId
Tenant Id of the resource you'd like to manage.

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopeConnection

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerScopeConnection](./Get-AzNetworkManagerScopeConnection.md)

[Remove-AzNetworkManagerScopeConnection](./Remove-AzNetworkManagerScopeConnection.md)

[Set-AzNetworkManagerScopeConnection](./Set-AzNetworkManagerScopeConnection.md)
