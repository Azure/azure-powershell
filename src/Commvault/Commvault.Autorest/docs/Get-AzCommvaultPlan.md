---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/get-azcommvaultplan
schema: 2.0.0
---

# Get-AzCommvaultPlan

## SYNOPSIS
Get a CommvaultPlan

## SYNTAX

### List (Default)
```
Get-AzCommvaultPlan -CloudAccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCommvaultPlan -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCommvaultPlan -InputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCloudAccount
```
Get-AzCommvaultPlan -CloudAccountInputObject <ICommvaultIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a CommvaultPlan

## EXAMPLES

### Example 1: List the backup plans of a cloud account
```powershell
Get-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Lists the backup plans of the cloud account.

### Example 2: Get a backup plan
```powershell
Get-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily
```

Gets the backup plan named plan-daily.

## PARAMETERS

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: GetViaIdentityCloudAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Plan resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCloudAccount
Aliases: PlanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultPlan

## NOTES

## RELATED LINKS

