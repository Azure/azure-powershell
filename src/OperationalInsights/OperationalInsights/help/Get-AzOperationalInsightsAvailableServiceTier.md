---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/get-AzOperationalInsightsAvailableServiceTier
schema: 2.0.0
---

# Get-AzOperationalInsightsAvailableServiceTier

## SYNOPSIS
This command gets all available service tiers for a given worksapce.

## SYNTAX

```
Get-AzOperationalInsightsAvailableServiceTier [-ResourceGroupName] <String> [-WorkspaceName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This command gets all available service tiers for a given worksapce.

## EXAMPLES

### Example 1
```powershell
Get-AzOperationalInsightsAvailableServiceTier -ResourceGroupName ContosoResourceGroup -WorkspaceName MyWorkspace
```

```output
ServiceTier              : PerGB2018
Enabled                  : True
MinimumRetention         : 30
MaximumRetention         : 730
DefaultRetention         : 30
CapacityReservationLevel :
LastSkuUpdate            :

ServiceTier              : CapacityReservation
Enabled                  : True
MinimumRetention         : 30
MaximumRetention         : 730
DefaultRetention         : 31
CapacityReservationLevel :
LastSkuUpdate            : Tue, 16 Nov 2021 13:20:32 GMT
```

This command gets all available service tiers for a given worksapce.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace that contains the table.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSAvailableServiceTier

## NOTES

## RELATED LINKS
