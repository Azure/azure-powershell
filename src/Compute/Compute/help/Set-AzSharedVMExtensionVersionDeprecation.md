---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azsharedvmextensionversiondeprecation
schema: 2.0.0
---

# Set-AzSharedVMExtensionVersionDeprecation

## SYNOPSIS
Schedules deprecation for a Shared VM Extension Version.

## SYNTAX

### DefaultParameter (Default)
```
Set-AzSharedVMExtensionVersionDeprecation -ResourceGroupName <String> -SharedVMExtensionName <String>
 -Version <String> -DeprecationState <String> [-DaysUntilDeprecation <Int32>] [-DeprecationType <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameter
```
Set-AzSharedVMExtensionVersionDeprecation -ResourceId <String> -DeprecationState <String>
 [-DaysUntilDeprecation <Int32>] [-DeprecationType <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameter
```
Set-AzSharedVMExtensionVersionDeprecation -InputObject <PSSharedVMExtensionVersion>
 -DeprecationState <String> [-DaysUntilDeprecation <Int32>] [-DeprecationType <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSharedVMExtensionVersionDeprecation** cmdlet schedules a published shared VM extension version for graceful deprecation by setting a deprecation state, timeframe, and scope.

## EXAMPLES

### Example 1
```powershell
Set-AzSharedVMExtensionVersionDeprecation -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0' -DeprecationState 'ScheduledForDeprecation' -DaysUntilDeprecation 90 -DeprecationType 'Minor'
```

This command schedules version '1.0.0' of the shared VM extension 'myVMExtension' to be deprecated 90 days from now, for the 'Minor' deprecation scope.

### Example 2
```powershell
Get-AzSharedVMExtensionVersion -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0' | Set-AzSharedVMExtensionVersionDeprecation -DeprecationState 'Active'
```

This command pipes the shared VM extension version object into `Set-AzSharedVMExtensionVersionDeprecation` and resets it back to the 'Active' state.

## PARAMETERS

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

### -DaysUntilDeprecation
The number of days from now after which the shared VM extension version is considered deprecated. Required when -DeprecationState is 'ScheduledForDeprecation' and no deprecation time has previously been set; if a deprecation time is already scheduled, this parameter is optional and only needs to be supplied to change it. When reactivating (-DeprecationState 'Active') with new deprecation data, this parameter must be supplied together with -DeprecationType.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -DeprecationState
The deprecation state to apply to the shared VM extension version.

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

### -DeprecationType
The scope of deprecation, indicating which set of versions are affected.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The shared VM extension version object, typically piped in from Get-AzSharedVMExtensionVersion.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSSharedVMExtensionVersion
Parameter Sets: InputObjectParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of the shared VM extension version.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SharedVMExtensionName
The name of the shared VM extension.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
The version of the shared VM extension.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSharedVMExtensionVersion

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSharedVMExtensionVersion

## NOTES

## RELATED LINKS

[Get-AzSharedVMExtensionVersion](./Get-AzSharedVMExtensionVersion.md)
