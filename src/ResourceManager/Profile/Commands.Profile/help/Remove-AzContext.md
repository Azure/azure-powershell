---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: Az.Profile
online version: https://docs.microsoft.com/en-us/powershell/module/az.profile/remove-azcontext
schema: 2.0.0
---

# Remove-AzContext

## SYNOPSIS
Remove a context from the set of available contexts

## SYNTAX

### RemoveByInputObject (Default)
```
Remove-AzContext -InputObject <PSAzureContext> [-Force] [-PassThru] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveByName
```
Remove-AzContext [-Force] [-PassThru] [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Remove an azure context from the set of contexts

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzContext -Name Default
```

Remove the context named default

## PARAMETERS

### -DefaultProfile
The credentials, tenant and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
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
Type: Microsoft.Azure.Commands.Profile.Models.Core.PSAzureContext
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
Accepted values: Core-ES-BLD (54e18c35-3863-4a17-8e52-b5aa1e65847e) - maclayto@microsoft.com, DDXLABDTL-01 (e2dc3810-f8e5-4337-a41c-8b9ec7d954ee) - maclayto@microsoft.com, Pay-As-You-Go (92ad8d84-3287-4990-b83d-5e983832f7ce) - maclayto@microsoft.com, DevDiv Key Vault (bd62906c-0a81-43c3-a2f8-126e4cf66ada) - maclayto@microsoft.com, Azure SDK Powershell Test (c9cbd920-c00c-427c-852b-8aaf38badaeb) - maclayto@microsoft.com, Azure SDK Infrastructure (6b085460-5f21-477e-ba44-1035046e9101) - maclayto@microsoft.com, Azure SDK Powershell Test - Manual (9e223dbe-3399-4e19-88eb-0975f02ac87f) - maclayto@microsoft.com, Cosmos_WDG_Core_BnB_100348 (dae41bd3-9db4-4b9b-943e-832b57cac828) - maclayto@microsoft.com, Node CLI Test (2c224e7e-3ef5-431d-a57b-e71f4662e3a6) - maclayto@microsoft.com, Key Vault Engineering Subscription (33f39d49-6173-49bf-9789-db5548ee6d73) - maclayto@microsoft.com, VS Telemetry - Data Catalog (a7bb576c-291e-4553-965a-1c588b3f29d8) - maclayto@microsoft.com

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
