---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azconnectionpolicy
schema: 2.0.0
---

# Remove-AzConnectionPolicy

## SYNOPSIS
Deletes a ConnectionPolicy resource associated with a VirtualHub.

## SYNTAX

### ByConnectionPolicyName (Default)
```
Remove-AzConnectionPolicy -ResourceGroupName <String> -ParentResourceName <String> -Name <String> [-AsJob]
 [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObject
```
Remove-AzConnectionPolicy -Name <String> -ParentObject <PSVirtualHub> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByConnectionPolicyObject
```
Remove-AzConnectionPolicy -InputObject <PSConnectionPolicy> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByConnectionPolicyResourceId
```
Remove-AzConnectionPolicy -ResourceId <String> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes the specified ConnectionPolicy that is associated with the specified VirtualHub.

## EXAMPLES

### Example 1: Delete a ConnectionPolicy by name
```powershell
Remove-AzConnectionPolicy -ResourceGroupName "testRg" -ParentResourceName "testHub" -Name "testPolicy" -Force -PassThru
```

```output
True
```

### Example 2: Delete a ConnectionPolicy using the pipeline
```powershell
Get-AzConnectionPolicy -ResourceGroupName "testRg" -HubName "testHub" -Name "testPolicy" | Remove-AzConnectionPolicy -Force -PassThru
```

This command retrieves a ConnectionPolicy and deletes it via pipeline input.

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

### -Force
Do not prompt for confirmation before deleting the resource.

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
The ConnectionPolicy resource to delete.

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
The name of the ConnectionPolicy resource to delete.

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

### -PassThru
Returns an object representing the item on which this operation is being performed.

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
The resource ID of the ConnectionPolicy to delete.

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

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzConnectionPolicy](./Get-AzConnectionPolicy.md)

[New-AzConnectionPolicy](./New-AzConnectionPolicy.md)

[Set-AzConnectionPolicy](./Set-AzConnectionPolicy.md)
