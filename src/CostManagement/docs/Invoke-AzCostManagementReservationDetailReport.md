---
external help file:
Module Name: Az.CostManagement
online version: https://learn.microsoft.com/powershell/module/az.costmanagement/invoke-azcostmanagementreservationdetailreport
schema: 2.0.0
---

# Invoke-AzCostManagementReservationDetailReport

## SYNOPSIS
Generates the reservations details report for provided date range asynchronously based on enrollment id.
The Reservation usage details can be viewed only by certain enterprise roles.
For more details on the roles see, https://learn.microsoft.com/en-us/azure/cost-management-billing/manage/understand-ea-roles#usage-and-costs-access-by-role

## SYNTAX

### By (Default)
```
Invoke-AzCostManagementReservationDetailReport -BillingAccountId <String> -EndDate <String>
 -StartDate <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### By1
```
Invoke-AzCostManagementReservationDetailReport -BillingAccountId <String> -BillingProfileId <String>
 -EndDate <String> -StartDate <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Generates the reservations details report for provided date range asynchronously based on enrollment id.
The Reservation usage details can be viewed only by certain enterprise roles.
For more details on the roles see, https://learn.microsoft.com/en-us/azure/cost-management-billing/manage/understand-ea-roles#usage-and-costs-access-by-role

## EXAMPLES

### Example 1: Generates the reservations details report for provided date range asynchronously based on billing account id
```powershell
Invoke-AzCostManagementReservationDetailReport -BillingAccountId "00000000-0000-0000-0000-0000000000" -StartDate "2022-10-01" -EndDate "2022-10-20"
```

This command generates the reservations details report for provided date range asynchronously based on billing account id.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -BillingAccountId
Enrollment ID (Legacy BillingAccount ID)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BillingProfileId
BillingProfile ID

```yaml
Type: System.String
Parameter Sets: By1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -EndDate
End Date

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -StartDate
Start Date

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20211001.IOperationStatus

## NOTES

ALIASES

## RELATED LINKS

