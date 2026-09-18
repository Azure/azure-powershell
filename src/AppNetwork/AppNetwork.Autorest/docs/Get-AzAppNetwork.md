---
external help file:
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/get-azappnetwork
schema: 2.0.0
---

# Get-AzAppNetwork

## SYNOPSIS
Get an AppLink.

## SYNTAX

### List1 (Default)
```
Get-AzAppNetwork [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAppNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAppNetwork -InputObject <IAppNetworkIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzAppNetwork -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an AppLink.

## EXAMPLES

### Example 1: List Application Networks in the current subscription
```powershell
Get-AzAppNetwork
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
appnet-test-02 eastus   Succeeded         other_rg
```

Lists all Application Network resources in the current subscription.

### Example 2: List Application Networks in a resource group
```powershell
Get-AzAppNetwork -ResourceGroupName test_rg
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Lists the Application Network resources in the `test_rg` resource group.

### Example 3: Get an Application Network resource
```powershell
Get-AzAppNetwork -Name appnet-test-01 -ResourceGroupName test_rg
```

```output
Name           Location ProvisioningState ResourceGroupName
----           -------- ----------------- -----------------
appnet-test-01 westus2  Succeeded         test_rg
```

Gets the details of the Application Network resource named `appnet-test-01`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the AppLink

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AppLinkName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLink

## NOTES

## RELATED LINKS

