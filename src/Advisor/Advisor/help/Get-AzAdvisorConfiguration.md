---
external help file: Az.Advisor-help.xml
Module Name: Az.Advisor
online version: https://learn.microsoft.com/powershell/module/az.advisor/get-azadvisorconfiguration
schema: 2.0.0
---

# Get-AzAdvisorConfiguration

## SYNOPSIS
Retrieve Azure Advisor configurations and also retrieve configurations of contained resource groups.

## SYNTAX

### List (Default)
```
Get-AzAdvisorConfiguration [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzAdvisorConfiguration [-SubscriptionId <String[]>] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve Azure Advisor configurations and also retrieve configurations of contained resource groups.

## EXAMPLES

### Example 1: Get Configuration by SubscriptionId
```powershell
Get-AzAdvisorConfiguration
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default False   10
```

Get Configuration by SubscriptionId

### Example 2: Get Configuration by ResourceGroupName
```powershell
Get-AzAdvisorConfiguration -ResourceGroupName lnxtest
```

```output
Name                                         Exclude LowCpuThreshold
----                                         ------- ---------------
9e223dbe-3399-4e19-88eb-0975f02ac87f-lnxtest False
```

Get Configuration by ResourceGroupName

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData

## NOTES

## RELATED LINKS
