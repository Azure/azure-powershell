---
external help file:
Module Name: Az.Relationships
online version: https://learn.microsoft.com/powershell/module/az.relationships/get-azrelationshipsdependencyofrelationship
schema: 2.0.0
---

# Get-AzRelationshipsDependencyOfRelationship

## SYNOPSIS
Get a DependencyOfRelationship

## SYNTAX

### Get (Default)
```
Get-AzRelationshipsDependencyOfRelationship -Name <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRelationshipsDependencyOfRelationship -InputObject <IRelationshipsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DependencyOfRelationship

## EXAMPLES

### Example 1: Get a DependencyOf relationship by name
```powershell
Get-AzRelationshipsDependencyOfRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myDependency"
```

Retrieves the DependencyOf relationship named 'myDependency' scoped to the resource group 'myRG'.

### Example 2: Get a DependencyOf relationship using identity input
```powershell
$identity = @{ ResourceUri = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG"; Name = "myDependency" }
Get-AzRelationshipsDependencyOfRelationship -InputObject $identity
```

Retrieves the relationship by constructing an identity hashtable with ResourceUri and Name keys.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of dependencyOf relationship.

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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IDependencyOfRelationship

## NOTES

## RELATED LINKS

