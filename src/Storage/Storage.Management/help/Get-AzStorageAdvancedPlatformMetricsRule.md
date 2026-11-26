---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstorageadvancedplatformmetricsrule
schema: 2.0.0
---

# Get-AzStorageAdvancedPlatformMetricsRule

## SYNOPSIS
Get the advanced platform metrics rule for the storage account by rule type.

## SYNTAX

### List (Default)
```
Get-AzStorageAdvancedPlatformMetricsRule -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageAdvancedPlatformMetricsRule -InputObject <IStorageIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the advanced platform metrics rule for the storage account by rule type.

## EXAMPLES

### Example 1: List the capacity metrics rules for an account
```powershell
Get-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount"
```

Lists the metrics rules for the storage account.
An account without configured rules returns no results.

### Example 2: Get a metrics rule by resource identity
```powershell
$rules = Get-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount"
Get-AzStorageAdvancedPlatformMetricsRule -InputObject @{ Id = $rules[0].Id }
```

Retrieves a specific existing rule using its resource identity.
This example requires at least one configured rule.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List
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
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IAdvancedPlatformMetricsRule

## NOTES

## RELATED LINKS
