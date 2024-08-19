---
external help file: Az.Subscription-help.xml
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/get-azsubscriptionalias
schema: 2.0.0
---

# Get-AzSubscriptionAlias

## SYNOPSIS
Get Alias Subscription.

## SYNTAX

### List (Default)
```
Get-AzSubscriptionAlias [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSubscriptionAlias -AliasName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSubscriptionAlias -InputObject <ISubscriptionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Alias Subscription.

## EXAMPLES

### Example 1: List Alias Subscription.
```powershell
Get-AzSubscriptionAlias
```

```output
AliasName          SubscriptionId                       ProvisioningState
---------          --------------                       -----------------
test-subscription  XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
test-subscription2 XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

List Alias Subscription.

### Example 2: Get Alias Subscription.
```powershell
Get-AzSubscriptionAlias -AliasName test-subscription
```

```output
AliasName         SubscriptionId                       ProvisioningState
---------         --------------                       -----------------
test-subscription XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX Succeeded
```

Get Alias Subscription.

## PARAMETERS

### -AliasName
AliasName is the name for the subscription creation request.
Note that this is not the same as subscription name and this doesn't have any other lifecycle need beyond the request for subscription creation.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.ISubscriptionAliasListResult

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.Api20211001.ISubscriptionAliasResponse

## NOTES

## RELATED LINKS
