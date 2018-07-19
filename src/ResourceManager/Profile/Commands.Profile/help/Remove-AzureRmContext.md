---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/remove-azurermcontext
schema: 2.0.0
---

# Remove-AzureRmContext

## SYNOPSIS
Remove a context from the set of available contexts

## SYNTAX

### RemoveByInputObject (Default)
```
Remove-AzureRmContext -InputObject <PSAzureContext> [-Force] [-PassThru] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByName
```
Remove-AzureRmContext [-Force] [-PassThru] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Remove an azure context from the set of contexts

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmContext -Name Default
```

Remove the context named default

## PARAMETERS

### -DefaultProfile
The credentials, tenant and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Remove context even if it is the defualt

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
A context object, normally passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Profile.Models.PSAzureContext
Parameter Sets: RemoveByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the context

```yaml
Type: System.String
Parameter Sets: RemoveByName
Aliases:
Accepted values: Azure SDK Infrastructure, [maclayto@microsoft.com, 33f39d49-6173-49bf-9789-db5548ee6d73], AzureSDKADGraph2,  - 8bc48661-1801-4b7a-8ca1-6a3cadfb4870, [maddieclayton1@gmail.com], Node CLI Test, Azure SDK Powershell Test - Manual - 9e223dbe-3399-4e19-88eb-0975f02ac87f, Scottph Internal Consumption, AzureSDKADGraph2 - 0b1f6471-1bf0-4dda-aec3-cb9272f09590, Azure SDK Powershell Test - c9cbd920-c00c-427c-852b-8aaf38badaeb, [maclayto@microsoft.com, 92ad8d84-3287-4990-b83d-5e983832f7ce], Azure SDK Powershell Test - Manual, Network Traffic Analytics Subscription 3 - af15e575-f948-49ac-bce0-252d028e9379, Pay-As-You-Go, Azure SDK Powershell Test

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return the removed context

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

### -Scope
Determines the scope of context changes, for example, whether changes apply only to the current process, or to all sessions started by this user

```yaml
Type: Microsoft.Azure.Commands.Profile.Common.ContextModificationScope
Parameter Sets: (All)
Aliases:
Accepted values: Process, CurrentUser

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureContext
Parameters: InputObject (ByValue)

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureContext

## NOTES

## RELATED LINKS
