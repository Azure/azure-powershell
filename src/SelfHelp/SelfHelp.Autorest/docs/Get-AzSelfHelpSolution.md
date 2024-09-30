---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/get-azselfhelpsolution
schema: 2.0.0
---

# Get-AzSelfHelpSolution

## SYNOPSIS
Get the solution using the applicable solutionResourceName while creating the solution.

## SYNTAX

### Get (Default)
```
Get-AzSelfHelpSolution -ResourceName <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSelfHelpSolution -InputObject <ISelfHelpIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the solution using the applicable solutionResourceName while creating the solution.

## EXAMPLES

### Example 1: Get-AzSelfHelpSolution by resource id
```powershell
Get-AzSelfHelpSolution -ResourceName test-resource234 -Scope  /subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba/resourceGroups/DiagnosticsRp-Ev2AssistId-Public-Dev/providers/Microsoft.KeyVault/vaults/DiagRp-Ev2PublicDev
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
        test-resource234    DiagnosticsRp-Ev2AssistId-Public-Dev
```

Get SelfHelp Solution by resource id

## PARAMETERS

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceName
Solution resource Name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SolutionResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
scope = resourceUri of affected resource.\<br/\> For example: /subscriptions/0d0fcd2e-c4fd-4349-8497-200edb3923c6/resourcegroups/myresourceGroup/providers/Microsoft.KeyVault/vaults/test-keyvault-non-read

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ISolutionResource

## NOTES

## RELATED LINKS

