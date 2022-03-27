---
external help file:
Module Name: Az.ConnectedMachine
online version: https://docs.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedprivatelinkscope
schema: 2.0.0
---

# Get-AzConnectedPrivateLinkScope

## SYNOPSIS
Returns a Azure Arc PrivateLinkScope.

## SYNTAX

### List (Default)
```
Get-AzConnectedPrivateLinkScope [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedPrivateLinkScope -ResourceGroupName <String> -ScopeName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzConnectedPrivateLinkScope -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a Azure Arc PrivateLinkScope.

## EXAMPLES

### Example 1: List all private link scopes in a resource group
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName
```

```output
Name              Location    PublicNetworkAccess ProvisioningState Tag
----              --------    ------------------- ----------------- ---
name1 		eastus2euap Enabled             Succeeded 	  Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesResourceTags
name2		eastus2euap Disabled            Succeeded         Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesResourceTags
name3		eastus2euap Enabled             Succeeded         Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesResourceTags
```

Lists all private link scopes in a specified resource group

### Example 2: Get a private link scope in a resource group by name
```powershell
Get-AzConnectedPrivateLinkScope -ResourceGroupName $resourceGroupName -ScopeName $scopeName
```

```output
Name         Location    PublicNetworkAccess ProvisioningState Tag
----         --------    ------------------- ----------------- ---
name1	     eastus2euap Enabled             Succeeded         Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.PrivateLinkScopesRes…
```

Gets a private link scope in a specified resource group by name

## PARAMETERS

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

### -ScopeName
The name of the Azure Arc PrivateLinkScope resource.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20210520.IHybridComputePrivateLinkScope

## NOTES

ALIASES

## RELATED LINKS

