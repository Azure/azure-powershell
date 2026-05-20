---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azconnectionpolicy
schema: 2.0.0
---

# Set-AzConnectionPolicy

## SYNOPSIS
Updates a ConnectionPolicy resource associated with a VirtualHub.

## SYNTAX

### ByConnectionPolicyName (Default)
```
Set-AzConnectionPolicy -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-EnableInternetSecurity] [-RoutingConfiguration <PSRoutingConfiguration>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObject
```
Set-AzConnectionPolicy -Name <String> -ParentObject <PSVirtualHub> [-EnableInternetSecurity]
 [-RoutingConfiguration <PSRoutingConfiguration>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByConnectionPolicyObject
```
Set-AzConnectionPolicy -InputObject <PSConnectionPolicy> [-EnableInternetSecurity]
 [-RoutingConfiguration <PSRoutingConfiguration>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByConnectionPolicyResourceId
```
Set-AzConnectionPolicy -ResourceId <String> [-EnableInternetSecurity]
 [-RoutingConfiguration <PSRoutingConfiguration>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the specified ConnectionPolicy that is associated with the specified VirtualHub.

## EXAMPLES

### Example 1: Update a ConnectionPolicy to enable internet security
```powershell
Set-AzConnectionPolicy -ResourceGroupName "testRg" -ParentResourceName "testHub" -Name "testPolicy" -EnableInternetSecurity
```

```output
ProvisioningState    : Succeeded
EnableInternetSecurity : True
RoutingConfiguration :
AssociatedConnections : {}
Name                 : testPolicy
Etag                 : W/"etag"
Id                   : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/connectionPolicies/testPolicy
```

### Example 2: Update a ConnectionPolicy using the pipeline
```powershell
Get-AzConnectionPolicy -ResourceGroupName "testRg" -HubName "testHub" -Name "testPolicy" | Set-AzConnectionPolicy -EnableInternetSecurity
```

This command retrieves an existing ConnectionPolicy and updates it with internet security enabled via pipeline input.

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

### -EnableInternetSecurity
Flag to enable internet security on the ConnectionPolicy.

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

### -InputObject
The ConnectionPolicy resource to modify.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSConnectionPolicy
Parameter Sets: ByConnectionPolicyObject
Aliases: ConnectionPolicy

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ConnectionPolicy resource to update.

```yaml
Type: System.String
Parameter Sets: ByConnectionPolicyName, ByVirtualHubObject
Aliases: ResourceName, ConnectionPolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
The parent VirtualHub object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: VirtualHub, ParentVirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
The name of the parent VirtualHub.

```yaml
Type: System.String
Parameter Sets: ByConnectionPolicyName
Aliases: VirtualHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByConnectionPolicyName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of the ConnectionPolicy to update.

```yaml
Type: System.String
Parameter Sets: ByConnectionPolicyResourceId
Aliases: ConnectionPolicyId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RoutingConfiguration
The routing configuration to apply to connections under this ConnectionPolicy.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRoutingConfiguration
Parameter Sets: (All)
Aliases:

Required: False
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSConnectionPolicy

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSConnectionPolicy

## NOTES

## RELATED LINKS

[Get-AzConnectionPolicy](./Get-AzConnectionPolicy.md)

[New-AzConnectionPolicy](./New-AzConnectionPolicy.md)

[Remove-AzConnectionPolicy](./Remove-AzConnectionPolicy.md)
