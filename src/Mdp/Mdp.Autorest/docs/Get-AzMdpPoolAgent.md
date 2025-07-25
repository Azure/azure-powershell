---
external help file:
Module Name: Az.Mdp
online version: https://learn.microsoft.com/powershell/module/az.mdp/get-azmdppoolagent
schema: 2.0.0
---

# Get-AzMdpPoolAgent

## SYNOPSIS
List ResourceDetailsObject resources by Pool

## SYNTAX

```
Get-AzMdpPoolAgent -PoolName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List ResourceDetailsObject resources by Pool

## EXAMPLES

### Example 1: List agents for a pool in a resource group  
```powershell
Get-AzMdpPoolAgent -ResourceGroupName testRg -PoolName Contoso
```

This command gets the agents for Managed DevOps Pool named "Contoso" under the resource group "testRg".

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

### -PoolName
Name of the pool.
It needs to be globally unique.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IResourceDetailsObject

## NOTES

## RELATED LINKS

