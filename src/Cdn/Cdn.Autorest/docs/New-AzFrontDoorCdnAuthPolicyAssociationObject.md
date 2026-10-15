---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnauthpolicyassociationobject
schema: 2.0.0
---

# New-AzFrontDoorCdnAuthPolicyAssociationObject

## SYNOPSIS
Create an in-memory object for AuthPolicyAssociation.

## SYNTAX

```
New-AzFrontDoorCdnAuthPolicyAssociationObject [-Domain <IActivatedResourceReference[]>]
 [-IsProfileLevel <Boolean>] [-Route <IResourceReference[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AuthPolicyAssociation.

## EXAMPLES

### Example 1: Create a profile-level association
```powershell
New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel $true
```

Creates an in-memory association object that applies an authentication policy at the profile level.
This command does not create or update an Azure resource.

### Example 2: Create an association for a route
```powershell
$route = @{ Id = "/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/myResourceGroup/providers/Microsoft.Cdn/profiles/myProfile/afdEndpoints/myEndpoint/routes/myRoute" }
New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel:$false -Route $route
```

Creates an in-memory association object for the specified route.
Pass the object to an authentication policy create or update command.

## PARAMETERS

### -Domain
Domains associated with the authorization policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IActivatedResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsProfileLevel
Indicates whether the policy is associated at the profile level.
When omitted during creation, the service defaults this value to false.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Route
Routes associated with the authorization policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AuthPolicyAssociation

## NOTES

## RELATED LINKS
