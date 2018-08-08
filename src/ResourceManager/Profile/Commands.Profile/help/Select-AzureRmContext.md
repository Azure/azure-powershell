---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/select-azurermcontext
schema: 2.0.0
---

# Select-AzureRmContext

## SYNOPSIS
Select a subscription and account to target in Azure PowerShell cmdlets

## SYNTAX

### SelectByInputObject (Default)
```
Select-AzureRmContext -InputObject <PSAzureContext> [-Scope <ContextModificationScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SelectByName
```
Select-AzureRmContext [-Scope <ContextModificationScope>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Select a  subscription to target (or account or tenant) in Azure PowerShell cmdlets.  After this cmdlet, future cmdlets will target the 
selected context.

## EXAMPLES

### Example 1 : Target a named context
```
PS C:\> Select-AzureRmContext "Work"
```

Target future Azure PowerShell cmdlets at the account, tenant, and subscription in the 'Work' context.

## PARAMETERS

### -DefaultProfile
The credentials, tenant and subscription used for communication with azure

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

### -InputObject
A context object, normally passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Profile.Models.PSAzureContext
Parameter Sets: SelectByInputObject
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
Parameter Sets: SelectByName
Aliases:
Accepted values: Node CLI Test - 2c224e7e-3ef5-431d-a57b-e71f4662e3a6, VS Telemetry - Data Catalog - a7bb576c-291e-4553-965a-1c588b3f29d8, Azure SDK Powershell Test - Manual - 9e223dbe-3399-4e19-88eb-0975f02ac87f, Core-ES-BLD - 54e18c35-3863-4a17-8e52-b5aa1e65847e, Cosmos_WDG_Core_BnB_100348 - dae41bd3-9db4-4b9b-943e-832b57cac828, Scottph Internal Consumption - 8bc48661-1801-4b7a-8ca1-6a3cadfb4870, DDXLABDTL-01 - e2dc3810-f8e5-4337-a41c-8b9ec7d954ee, Azure SDK Powershell Test - c9cbd920-c00c-427c-852b-8aaf38badaeb, Pay-As-You-Go - 92ad8d84-3287-4990-b83d-5e983832f7ce, Azure SDK Infrastructure - 6b085460-5f21-477e-ba44-1035046e9101, DevDiv Key Vault - bd62906c-0a81-43c3-a2f8-126e4cf66ada, Key Vault Engineering Subscription - 33f39d49-6173-49bf-9789-db5548ee6d73

Required: True
Position: 0
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
