---
external help file:
Module Name: DataDog
online version: https://docs.microsoft.com/powershell/module/datadog/get-azdatadogmonitorlinkedresource
schema: 2.0.0
---

# Get-AzDataDogMonitorLinkedResource

## SYNOPSIS
List all Azure resources associated to the same Datadog organization as the target resource.

## SYNTAX

```
Get-AzDataDogMonitorLinkedResource -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List all Azure resources associated to the same Datadog organization as the target resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogMonitorLinkedResource -ResourceGroupName lucas-dog -Name lucasdatadog

Id
--
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/EUAP-ACR-01266F2538192A/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-ACR-0126693370263
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/PROD-SUB-01278F01924690/PROVIDERS/MICROSOFT.DATADOG/MONITORS/SUB01273EE24900C6832
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/CREATE-SSO-E4E2467832A/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-CREATE-SSO-53326702
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/PROD-MUL-ACR-01277F790629/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-ACR1-A3C8604150D
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/CREATE-68A6706056D95/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-CREATE-2E312735B8
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/PROD-MUL-ACR-01279F943670/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-ACR2-D46323262B4
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/CREATE-8288834488516/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-CREATE-C7585255D1
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/CREATE-SSO-6E6618601FF/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-CREATE-SSO-C5065109
/SUBSCRIPTIONS/xxxxxxxxxxxxxx-xxxxxxx-xxxxxx/RESOURCEGROUPS/PROD-MUL-ACR-012774705865/PROVIDERS/MICROSOFT.DATADOG/MONITORS/LIFTR-ACR2-E2560749186
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Name
Monitor resource name

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20210301.ILinkedResource

## NOTES

ALIASES

## RELATED LINKS

