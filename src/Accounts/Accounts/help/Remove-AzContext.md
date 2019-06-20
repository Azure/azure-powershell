---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/en-us/powershell/module/az.accounts/remove-azcontext
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
Aliases: AzContext, AzureRmContext, AzureCredential

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
Accepted values: VSTS Community (33b1bf3d-53dc-432d-ac1c-ae964ceb1c9b) - markcowl@microsoft.com, Azure SDK Powershell Test (c9cbd920-c00c-427c-852b-8aaf38badaeb) - markcowl@microsoft.com, DDJenkinsClients-Corp (57f0a992-391e-462b-9c7d-a22f11c19153) - markcowl@microsoft.com, DevDiv Test Labs (4569f501-239f-4c48-a7c0-a3b1f507720c) - markcowl@microsoft.com, CAT_Eng (eb87f285-893a-4f0f-8c55-7b4f67b1d097) - markcowl@microsoft.com, Azure SDK CI (279b0675-cf67-467f-98f0-67ae31eb540f) - markcowl@microsoft.com, vsclk-core-prod (979523fb-a19c-4bb0-a8ee-cef29597b0a4) - markcowl@microsoft.com, Node CLI Test (2c224e7e-3ef5-431d-a57b-e71f4662e3a6) - markcowl@microsoft.com, node (00977cdb-163f-435f-9c32-39ec8ae61f4d) - markcowl@microsoft.com, Azure Storage DM Test (ce4a7590-4722-4bcf-a2c6-e473e9f11778) - markcowl@microsoft.com, PowerShell_in_Azure_Cloud_Shell (ae78d803-0528-4da1-ba66-2e6ddd4423fa) - markcowl@microsoft.com, DDXLABDTL-01 (e2dc3810-f8e5-4337-a41c-8b9ec7d954ee) - markcowl@microsoft.com, FISMA Pen Testing Subscription (9ed7cca5-c306-4f66-9d1c-2766e67013d8) - markcowl@microsoft.com, Test Subscription 1 for Migration (d1e52cbc-b073-42e2-a0a0-c2f547118a6e) - markcowl@microsoft.com, AzureSDKADGraph1 (e97029cb-78d9-49b1-a92f-b92f40a8b859) - markcowl@microsoft.com, Falcon Compliant Build (293df7f9-f218-4ba5-b165-46106210024b) - markcowl@microsoft.com, Azure SDK Infrastructure (6b085460-5f21-477e-ba44-1035046e9101) - markcowl@microsoft.com, AzureDevOpsCommunity (33b1bf3d-53dc-432d-ac1c-ae964ceb1c9b) - markcowl@microsoft.com, Cosmos_WDG_Core_BnB_100348 (dae41bd3-9db4-4b9b-943e-832b57cac828) - markcowl@microsoft.com, AAPT FXT Binary Repository (PROD) (e0f413ab-64d5-48c2-859b-af46b7e8d80b) - markcowl@microsoft.com, DevDiv Test Labs Public (d60c2e3b-00e6-48f3-a069-542c17981e1f) - markcowl@microsoft.com, Azure SDK sandbox (db1ab6f0-4769-4b27-930e-01e2ef9c123c) - markcowl@microsoft.com, Visual Studio Enterprise (fb3b8680-0a17-4e3a-8f80-5ae374bba41e) - markcowl@microsoft.com, Azure SDK Engineering System (a18897a6-7e44-457d-9260-f2854c0aca42) - markcowl@microsoft.com, DevDiv Key Vault (bd62906c-0a81-43c3-a2f8-126e4cf66ada) - markcowl@microsoft.com, AzureSDKADGraph2 (0b1f6471-1bf0-4dda-aec3-cb9272f09590) - markcowl@microsoft.com, Kubernetes Shared Tools - PROD (db67ee91-0665-44d4-b451-31faee93c5fd) - markcowl@microsoft.com, Core-ES-WorkManagement (52a442a2-31e9-42f9-8e3e-4b27dbf82673) - markcowl@microsoft.com

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

### Microsoft.Azure.Commands.Profile.Models.Core.PSAzureContext

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.Core.PSAzureContext

## NOTES

## RELATED LINKS
