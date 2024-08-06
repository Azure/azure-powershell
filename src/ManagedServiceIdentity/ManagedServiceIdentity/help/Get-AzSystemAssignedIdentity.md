---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azsystemassignedidentity
schema: 2.0.0
---

# Get-AzSystemAssignedIdentity

## SYNOPSIS
Gets the systemAssignedIdentity available under the specified RP scope.

## SYNTAX

```
Get-AzSystemAssignedIdentity -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the systemAssignedIdentity available under the specified RP scope.

## EXAMPLES

### Example 1: Gets the system assigned identity available under the specified RP scope
```powershell
Get-AzSystemAssignedIdentity -Scope "/subscriptions/00000000-0000-0000-00000000000/resourcegroups/lucas-rg-test/providers/Microsoft.Web/sites/functionportal01"
```

```output
Name            Location ResourceGroupName
----            -------- -----------------
ubuntu-portal01 eastus   azure-rg-test
```

This command gets the system assigned identity available under the specified RP scope.

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

### -Scope
The resource provider scope of the resource.
Parent resource being extended by Managed Identities.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.ISystemAssignedIdentity

## NOTES

## RELATED LINKS
