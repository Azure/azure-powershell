---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
schema: 2.0.0
---

# New-AzManagedNetworkScope

## SYNOPSIS
Creates a scope for managedNetwork.

## SYNTAX

```
New-AzManagedNetworkScope [-ManagementGroupIdList <String[]>]
 [-SubscriptionIdList <String[]>]
 [-VirtualNetworkIdList <String[]>]
 [-SubnetIdList <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedNetworkScope** cmdlet creates a scope for managedNetwork.

## EXAMPLES

### 1: Create a private endpoint
```
$testmanagednetworkscope = New-AzManagedNetworkScope -ManagementGroupIdList $ManagementGroupIdList -SubscriptionIdList $SubscriptionIdList
-VirtualNetworkIdList $VirtualNetworkIdList -SubnetIdList $SubnetIdList
```

This example creates a Managed Network scope.

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

### -ManagementGroupIdList
Azure ManagedNetwork Scope management group ids.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetIdList
Azure ManagedNetwork Scope subnet ids.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionIdList
Azure ManagedNetwork Scope subscription ids.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkIdList
Azure ManagedNetwork Scope virtual network ids.

```yaml
Type: System.String[]
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

### System.String []

## OUTPUTS

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope

## NOTES

## RELATED LINKS

[Get-AzManagedNetwork](./Get-AzManagedNetwork.md)

[Remove-AzManagedNetwork](./Remove-AzManagedNetwork.md)

[update-AzManagedNetwork](./Update-AzManagedNetwork.md)