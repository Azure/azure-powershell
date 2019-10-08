---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
online version: https://docs.microsoft.com/en-us/powershell/module/az.managednetwork/new-azmanagednetwork
schema: 2.0.0
---

# New-AzManagedNetworkScope

## SYNOPSIS
Creates a scope for managedNetwork.

## SYNTAX

```
New-AzManagedNetworkScope  [-ManagementGroupIdList <String[]>] [-SubscriptionIdList <String[]>] [-VirtualNetworkIdList <String[]>] [-SubnetIdList <String[]>][-AsJob] [-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>] 
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

### -ManagementGroupIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkIdList
```yaml
Type: System.Collections.Generic.List<String>
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubnetIdList
```yaml
Type: System.Collections.Generic.List<String>
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

### System.Collections.Generic.List<String>

## OUTPUTS

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope

## NOTES

## RELATED LINKS

[Get-AzManagedNetwork](./Get-AzManagedNetwork.md)

[Remove-AzManagedNetwork](./Remove-AzManagedNetwork.md)

[update-AzManagedNetwork](./Update-AzManagedNetwork.md)