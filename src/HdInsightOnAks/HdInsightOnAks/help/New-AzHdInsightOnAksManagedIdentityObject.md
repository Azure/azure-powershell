---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksmanagedidentityobject
schema: 2.0.0
---

# New-AzHdInsightOnAksManagedIdentityObject

## SYNOPSIS
Create an in-memory object for ManagedIdentitySpec.

## SYNTAX

```
New-AzHdInsightOnAksManagedIdentityObject -ClientId <String> -ObjectId <String> -ResourceId <String>
 -Type <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedIdentitySpec.

## EXAMPLES

### Example 1: Create a Managed Identity object
```powershell
New-AzHdInsightOnAksManagedIdentityObject -ClientId 00000000-0000-0000-0000-000000000000 -ObjectId 00000000-0000-0000-0000-000000000000 -ResourceId /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/msi -Type cluster
```

```output
ClientId                             ObjectId                             ResourceId                                                                                                                              Type
--------                             --------                             ----------                                                                                                                              ----
00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-000000000000 /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/msi cluster
```

Create a Managed Identity object

## PARAMETERS

### -ClientId
ClientId of the managed identity.

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

### -ObjectId
ObjectId of the managed identity.

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

### -ResourceId
ResourceId of the managed identity.

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

### -Type
The type of managed identity.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ManagedIdentitySpec

## NOTES

## RELATED LINKS
