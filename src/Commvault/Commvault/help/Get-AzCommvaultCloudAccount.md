---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/get-azcommvaultcloudaccount
schema: 2.0.0
---

# Get-AzCommvaultCloudAccount

## SYNOPSIS
Get a CloudAccount

## SYNTAX

### List (Default)
```
Get-AzCommvaultCloudAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCommvaultCloudAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzCommvaultCloudAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCommvaultCloudAccount -InputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a CloudAccount

## EXAMPLES

### Example 1: List the cloud accounts in a subscription
```powershell
Get-AzCommvaultCloudAccount
```

Lists all cloud accounts in the current subscription.

### Example 2: List the cloud accounts in a resource group
```powershell
Get-AzCommvaultCloudAccount -ResourceGroupName rg-commvault
```

Lists the cloud accounts in the resource group.

### Example 3: Get a cloud account
```powershell
Get-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso
```

Gets the cloud account named cca-contoso.

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
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CloudAccountName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICloudAccount

## NOTES

## RELATED LINKS
