---
external help file:
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/new-azsubscriptionalias
schema: 2.0.0
---

# New-AzSubscriptionAlias

## SYNOPSIS
Create Alias Subscription.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSubscriptionAlias -AliasName <String> -SubscriptionId <String> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### WorkloadCreateExpanded
```
New-AzSubscriptionAlias -AliasName <String> -BillingScope <String> -SubscriptionName <String>
 -Workload <Workload> [-ManagementGroupId <String>] [-ResellerId <String>] [-SubscriptionOwnerId <String>]
 [-SubscriptionTenantId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create Alias Subscription.

## EXAMPLES

### Example 1: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -SubscriptionId XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.

### Example 2: Create Alias Subscription.
```powershell
New-AzSubscriptionAlias -AliasName test-subscription -SubscriptionName "createSub" -BillingScope "/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}" -Workload 'Production' 
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Create Alias Subscription.

## PARAMETERS

### -AliasName
AliasName is the name for the subscription creation request.
Note that this is not the same as subscription name and this doesn’t have any other lifecycle need beyond the request for subscription creation.

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

### -BillingScope
Billing scope of the subscription.For CustomerLed and FieldLed - /billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoiceSections/{invoiceSectionName}For PartnerLed - /billingAccounts/{billingAccountName}/customers/{customerName}For Legacy EA - /billingAccounts/{billingAccountName}/enrollmentAccounts/{enrollmentAccountName}

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -ManagementGroupId
Management group Id for the subscription.

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases:

Required: False
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

### -ResellerId
Reseller Id

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
This parameter can be used to create alias for existing subscription Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionName
The friendly name of the subscription.

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases: DisplayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionOwnerId
Owner Id of the subscription

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionTenantId
Tenant Id of the subscription

```yaml
Type: System.String
Parameter Sets: WorkloadCreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags for the subscription

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Workload
The workload type of the subscription.
It can be either Production or DevTest.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Support.Workload
Parameter Sets: WorkloadCreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.ISubscriptionAliasResponse

## NOTES

## RELATED LINKS

