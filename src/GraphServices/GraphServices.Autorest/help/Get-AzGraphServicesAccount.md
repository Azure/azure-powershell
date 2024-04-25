---
external help file:
Module Name: Az.GraphServices
online version: https://learn.microsoft.com/powershell/module/az.graphservices/get-azgraphservicesaccount
schema: 2.0.0
---

# Get-AzGraphServicesAccount

## SYNOPSIS
Returns account resource for a given name.

## SYNTAX

### List1 (Default)
```
Get-AzGraphServicesAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGraphServicesAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGraphServicesAccount -InputObject <IGraphServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzGraphServicesAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns account resource for a given name.

## EXAMPLES

### Example 1: Get resources by ResourceGroupName
```powershell
Get-AzGraphServicesAccount -ResourceGroupName myRG
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
Global   myGraphAppBilling1 myRG
Global   myGraphAppBilling2 myRG
```

This command gets all the GraphServices Account resources for a resource group.

### Example 2: Get resources by Name
```powershell
Get-AzGraphServicesAccount -ResourceGroupName myRG -Name myGraphAppBilling
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
Global   myGraphAppBilling myRG
```

This command gets a GraphServices Account resource.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.IGraphServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.IGraphServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GraphServices.Models.Api20230413.IAccountResource

## NOTES

## RELATED LINKS

