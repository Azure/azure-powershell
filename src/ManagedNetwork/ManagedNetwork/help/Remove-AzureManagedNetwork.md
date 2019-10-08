---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
online version: https://docs.microsoft.com/en-us/powershell/module/az.managednetwork/remove-azmanagednetwork
schema: 2.0.0
---

# Remove-AzManagedNetwork

## SYNOPSIS
Removes a Managed Network.

## SYNTAX

### Remove by Name
```
Remove-AzManagedNetwork -ResourceGroupName <String> -Name <String> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Remove by ResourceId
```
Remove-AzManagedNetwork -ResourceId <String> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

### Remove by Input Object
```
Remove-AzManagedNetwork -InputObject <PSManagedNetwork> [-PassThru][-Force][-AsJob][-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzManagedNetwork** cmdlet removes a managed Network.

## EXAMPLES

### 1:  delete a Managed Network by name
```
Remove-AzManagedNetwork -ResourceGroupName TestRG -Name TestMN
```

This example remove a managednetwork by Name


### 2:  delete a Managed Network by resourceId
```
Remove-AzManagedNetwork -ResourceId $resourceId
```

This example remove a managednetwork by resourceId


### 3:  delete a Managed Network by InputObject
```
Remove-AzManagedNetwork -InputObject $managedNetwork
```

This example remove a managednetwork by inputObject

## PARAMETERS

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

### -Force
Forces the command to run without asking for user confirmation.

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
Specifies the name of the managedNetwork that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Specifies the resourceId of the managedNetwork that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Specifies the InputObject of the managedNetwork that this cmdlet removes.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSManagedNetwork
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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
Specifies the name of the resource group that contains the managedNetwork that this cmdlet removes.

```yaml
Type: System.String
Parameter Sets: NameParameterSet
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzManagedNetwork](./Get-AzManagedNetwork.md)

[New-AzManagedNetwork](./New-AzManagedNetwork.md)

[Update-AzManagedNetwork](./Update-AzManagedNetwork.md)


