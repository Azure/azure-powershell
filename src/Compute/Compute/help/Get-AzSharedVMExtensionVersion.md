---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azsharedvmextensionversion
schema: 2.0.0
---

# Get-AzSharedVMExtensionVersion

## SYNOPSIS
Gets a Shared VM Extension Version.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzSharedVMExtensionVersion -ResourceGroupName <String> -SharedVMExtensionName <String>
 -Version <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameter
```
Get-AzSharedVMExtensionVersion -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSharedVMExtensionVersion** cmdlet gets a specific version of a shared VM extension, including its current deprecation state.

## EXAMPLES

### Example 1
```powershell
Get-AzSharedVMExtensionVersion -ResourceGroupName 'myResourceGroup' -SharedVMExtensionName 'myVMExtension' -Version '1.0.0'
```

This command gets the version '1.0.0' of the shared VM extension 'myVMExtension'.

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSharedVMExtensionVersion

## NOTES

## RELATED LINKS

[Set-AzSharedVMExtensionVersionDeprecation](./Set-AzSharedVMExtensionVersionDeprecation.md)
