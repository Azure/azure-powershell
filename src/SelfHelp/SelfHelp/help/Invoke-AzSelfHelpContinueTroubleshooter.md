---
external help file: Az.SelfHelp-help.xml
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/invoke-azselfhelpcontinuetroubleshooter
schema: 2.0.0
---

# Invoke-AzSelfHelpContinueTroubleshooter

## SYNOPSIS
Uses 'stepId' and 'responses' as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

## SYNTAX

### ContinueExpanded (Default)
```
Invoke-AzSelfHelpContinueTroubleshooter -Scope <String> -TroubleshooterName <String>
 [-Response <ITroubleshooterResponse[]>] [-StepId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Continue
```
Invoke-AzSelfHelpContinueTroubleshooter -Scope <String> -TroubleshooterName <String>
 -ContinueRequestBody <IContinueRequestBody> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ContinueViaIdentityExpanded
```
Invoke-AzSelfHelpContinueTroubleshooter -InputObject <ISelfHelpIdentity>
 [-Response <ITroubleshooterResponse[]>] [-StepId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ContinueViaIdentity
```
Invoke-AzSelfHelpContinueTroubleshooter -InputObject <ISelfHelpIdentity>
 -ContinueRequestBody <IContinueRequestBody> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Uses 'stepId' and 'responses' as the trigger to continue the troubleshooting steps for the respective troubleshooter resource name.
\<br/\>Continue API is used to provide inputs that are required for the specific troubleshooter to progress into the next step in the process.
This API is used after the Troubleshooter has been created using the Create API.

## EXAMPLES

### Example 1: Continue Troubleshooter to next step
```powershell
$continueRequest = [ordered]@{ 
    "StepId" ="15ebac6c-96a1-4a67-ae9d-b06011d232ff" 
} 

Invoke-AzSelfHelpContinueTroubleshooter  -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba"  -TroubleshooterName  "02d59989-f8a9-4b69-9919-1ef51df4eff6" -ContinueRequestBody $continueRequest
```

```output
[No Response Body If Success - HttpStatus Code 204]
```

If continue is success, you will see no response.
If continue is not success, you will see the error message.
You can see the status of the troubleshooter step by using `Get-AzSelfHelpTroubleshooter` cmdlet.

## PARAMETERS

### -ContinueRequestBody
Troubleshooter ContinueRequest body.
To construct, see NOTES section for CONTINUEREQUESTBODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.IContinueRequestBody
Parameter Sets: Continue, ContinueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
Parameter Sets: ContinueViaIdentityExpanded, ContinueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -Response
.
To construct, see NOTES section for RESPONSE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ITroubleshooterResponse[]
Parameter Sets: ContinueExpanded, ContinueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
scope = resourceUri of affected resource.\<br/\> For example: /subscriptions/0d0fcd2e-c4fd-4349-8497-200edb3923c6/resourcegroups/myresourceGroup/providers/Microsoft.KeyVault/vaults/test-keyvault-non-read

```yaml
Type: System.String
Parameter Sets: ContinueExpanded, Continue
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepId
Unique id of the result.

```yaml
Type: System.String
Parameter Sets: ContinueExpanded, ContinueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TroubleshooterName
Troubleshooter resource Name.

```yaml
Type: System.String
Parameter Sets: ContinueExpanded, Continue
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.IContinueRequestBody

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
