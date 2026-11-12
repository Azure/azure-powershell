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
The **Set-AzSharedVMExtensionVersionDeprecation** cmdlet updates the deprecation status of a published shared VM extension version. A fresh deprecation status is built from the supplied parameters on every call; the previous status is not merged.

The required parameters depend on **-DeprecationState**:
- **Active**: neither **-DaysUntilDeprecation** nor **-DeprecationType** may be supplied; the deprecation status is cleared.
- **ScheduledForDeprecation**: both **-DaysUntilDeprecation** and **-DeprecationType** are required. The deprecation time is set to the current time plus the specified number of days.
- **Deprecated**: **-DeprecationType** is required and **-DaysUntilDeprecation** is not allowed. The version is deprecated immediately.

## EXAMPLES

### Example 1: Schedule a version for future deprecation
```powershell
Set-AzSharedVMExtensionVersionDeprecation -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0' -DeprecationState 'ScheduledForDeprecation' -DaysUntilDeprecation 90 -DeprecationType 'Minor'
```

This command schedules version '1.0.0' of the shared VM extension 'myVMExtension' to be deprecated 90 days from now, for the 'Minor' deprecation scope.

### Example 2: Deprecate a version immediately
```powershell
Set-AzSharedVMExtensionVersionDeprecation -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0' -DeprecationState 'Deprecated' -DeprecationType 'Major'
```

This command deprecates version '1.0.0' immediately for the 'Major' deprecation scope. -DaysUntilDeprecation must not be supplied for the 'Deprecated' state.

### Example 3: Reactivate a version
```powershell
Get-AzSharedVMExtensionVersion -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0' | Set-AzSharedVMExtensionVersionDeprecation -DeprecationState 'Active'
```

This command pipes the shared VM extension version object into `Set-AzSharedVMExtensionVersionDeprecation` and resets it back to the 'Active' state, clearing any deprecation time and type.

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
The number of days from now after which the shared VM extension version is scheduled for deprecation. Required together with -DeprecationType when -DeprecationState is 'ScheduledForDeprecation'. Not allowed when -DeprecationState is 'Active' or 'Deprecated'.

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
The scope of deprecation, indicating which set of versions are affected. Required when -DeprecationState is 'ScheduledForDeprecation' or 'Deprecated'. Not allowed when -DeprecationState is 'Active'.

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
