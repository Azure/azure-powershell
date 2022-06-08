---
external help file:
Module Name: Az.MachineLearningServices
online version: https://docs.microsoft.com/powershell/module/az.machinelearningservices/get-azmlservicequota
schema: 2.0.0
---

# Get-AzMLServiceQuota

## SYNOPSIS
Gets the currently assigned Workspace Quotas based on VMFamily.

## SYNTAX

```
Get-AzMLServiceQuota -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the currently assigned Workspace Quotas based on VMFamily.

## EXAMPLES

### Example 1: Gets the currently assigned Workspace Quotas based on VMFamily
```powershell
Get-AzMLServiceQuota -Location eastus
```

```output
AmlWorkspaceLocation Limit Unit
-------------------- ----- ----
                     100   Count
                     100   Count
                     100   Count
                     100   Count
                     100   Count
```

Gets the currently assigned Workspace Quotas based on VMFamily.

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

### -Location
The location for which resource usage is queried.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceQuota

## NOTES

ALIASES

## RELATED LINKS

