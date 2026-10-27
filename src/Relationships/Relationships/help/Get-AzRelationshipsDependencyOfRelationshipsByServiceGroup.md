---
external help file: Az.Relationships-help.xml
Module Name: Az.Relationships
online version: https://learn.microsoft.com/powershell/module/az.relationships/get-azrelationshipsdependencyofrelationshipsbyservicegroup
schema: 2.0.0
---

# Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup

## SYNOPSIS
Get a DependencyOfRelationship

## SYNTAX

### List (Default)
```
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -Name <String>
 -ServiceGroupInputObject <IRelationshipsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -Name <String> -ServiceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -InputObject <IRelationshipsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DependencyOfRelationship

## EXAMPLES

### Example 1: List dependency relationships for a Service Group
```powershell
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup"
```

Lists dependency relationships whose source is the specified Service Group.

### Example 2: Get a Service Group dependency relationship
```powershell
Get-AzRelationshipsDependencyOfRelationshipsByServiceGroup -ServiceGroupName "myServiceGroup" -Name "myDependency"
```

Gets the named dependency relationship from the Service Group.

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
Parameter Sets: GetViaIdentityServiceGroup, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipsIdentity
Parameter Sets: GetViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: List, Get
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
