---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/get-azcommvaultcloudaccountlatestlinkedsaas
schema: 2.0.0
---

# Get-AzCommvaultCloudAccountLatestLinkedSaaS

## SYNOPSIS
Returns the latest SaaS linked to the cloud account.

## SYNTAX

### Latest (Default)
```
Get-AzCommvaultCloudAccountLatestLinkedSaaS -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### LatestViaIdentity
```
Get-AzCommvaultCloudAccountLatestLinkedSaaS -InputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the latest SaaS linked to the cloud account.

## EXAMPLES

### Example 1: Get the latest linked SaaS of a cloud account
```powershell
Get-AzCommvaultCloudAccountLatestLinkedSaaS -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Gets the SaaS resource that was most recently linked to the cloud account.

## PARAMETERS

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: Latest
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
Parameter Sets: LatestViaIdentity
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
Parameter Sets: Latest
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
Parameter Sets: Latest
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ILatestLinkedSaaSResponse

## NOTES

## RELATED LINKS
