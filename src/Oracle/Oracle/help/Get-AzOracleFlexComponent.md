---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracleflexcomponent
schema: 2.0.0
---

# Get-AzOracleFlexComponent

## SYNOPSIS
Get a FlexComponent

## SYNTAX

### List (Default)
```
Get-AzOracleFlexComponent -Location <String> [-SubscriptionId <String[]>] [-Shape <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleFlexComponent -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleFlexComponent -Name <String> -LocationInputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleFlexComponent -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a FlexComponent

## EXAMPLES

### Example 1: Get Oracle Flex Component
```powershell
Get-AzOracleFlexComponent -Location "eastus"
```

```output
minimumCoreCount           : 16
availableCoreCount         : 11
availableDbStorageInGbs    : 8
runtimeMinimumCoreCount    : 13
shape                      : Exadata.X11M
availableMemoryInGbs       : 15
availableLocalStorageInGbs : 13
computeModel               : ECPU
hardwareType               : COMPUTE
descriptionSummary         : The description summary for this Flex Component
id                         : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg000/providers/Oracle.Database/flexComponents/name
name                       : fc
type                       : Oracle.Database/flexComponents
createdBy                  : ilrpjodjmvzhybazxipoplnql
createdByType              : User
createdAt                  : 2024-12-09T21:02:12.592Z
lastModifiedBy             : lhjbxchqkaia
lastModifiedByType         : User
lastModifiedAt             : 2024-12-09T21:02:12.592Z
```

Get a list of flex component by location.
For more information, execute `Get-Help Get-AzOracleFlexComponent`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the FlexComponent

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: FlexComponentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Shape
If provided, filters the results for the given shape

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IFlexComponent

## NOTES

## RELATED LINKS
