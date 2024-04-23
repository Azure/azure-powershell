---
external help file: Az.BillingBenefits-help.xml
Module Name: Az.BillingBenefits
online version: https://learn.microsoft.com/powershell/module/az.billingbenefits/invoke-azbillingbenefitselevatesavingplanorder
schema: 2.0.0
---

# Invoke-AzBillingBenefitsElevateSavingPlanOrder

## SYNOPSIS
Elevate as owner on savings plan order based on billing permissions.

## SYNTAX

### Elevate (Default)
```
Invoke-AzBillingBenefitsElevateSavingPlanOrder -SavingsPlanOrderId <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ElevateViaIdentity
```
Invoke-AzBillingBenefitsElevateSavingPlanOrder -InputObject <IBillingBenefitsIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Elevate as owner on savings plan order based on billing permissions.

## EXAMPLES

### Example 1: Elevate savings plan order
```powershell
Invoke-AzBillingBenefitsElevateSavingPlanOrder -SavingsPlanOrderId "e0b1f446-5684-4fa6-a0c8-d394368eda11"
```

```output
Name                                 PrincipalId                          RoleDefinitionId                                                                        Scope
----                                 -----------                          ----------------                                                                        -----
5c545baf-2ef5-4016-9c31-6e0e23c397a0 067e7443-3a55-40b6-a2d8-0a7a12a9da2d /providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635 /providers/Microsoft.BillingBenefits/savingsplanorders/e45905d2-9207-4f24-8549-f615c203b49b
```

Elevate savings plan order

### Example 2: Elevate savings plan order via identiy
```powershell
$identity = @{
            SavingsPlanOrderId = "e45905d2-9207-4f24-8549-f615c203b49b"
}

$response = Invoke-AzBillingBenefitsElevateSavingPlanOrder -InputObject $identity
```

```output
Name                                 PrincipalId                          RoleDefinitionId                                                                        Scope
----                                 -----------                          ----------------                                                                        -----
5c545baf-2ef5-4016-9c31-6e0e23c397a0 067e7443-3a55-40b6-a2d8-0a7a12a9da2d /providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635 /providers/Microsoft.BillingBenefits/savingsplanorders/e45905d2-9207-4f24-8549-f615c203b49b
```

Elevate savings plan order

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
Type: Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity
Parameter Sets: ElevateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SavingsPlanOrderId
Order ID of the savings plan

```yaml
Type: System.String
Parameter Sets: Elevate
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

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.IBillingBenefitsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BillingBenefits.Models.Api20221101.IRoleAssignmentEntity

## NOTES

## RELATED LINKS
