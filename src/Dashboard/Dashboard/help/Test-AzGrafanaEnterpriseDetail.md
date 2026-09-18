---
external help file: Az.Dashboard-help.xml
Module Name: Az.Dashboard
online version: https://learn.microsoft.com/powershell/module/az.dashboard/test-azgrafanaenterprisedetail
schema: 2.0.0
---

# Test-AzGrafanaEnterpriseDetail

## SYNOPSIS
Retrieve enterprise add-on details information

## SYNTAX

### Check (Default)
```
Test-AzGrafanaEnterpriseDetail -ResourceGroupName <String> [-SubscriptionId <String>] -WorkspaceName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzGrafanaEnterpriseDetail -InputObject <IDashboardIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Retrieve enterprise add-on details information

## EXAMPLES

### Example 1: Retrieve enterprise add-on details for a Grafana workspace
```powershell
Test-AzGrafanaEnterpriseDetail -ResourceGroupName azpstest-gp -WorkspaceName azpstest-grafana
```

```output
MarketplaceTrialQuota SaasSubscriptionDetail
--------------------- ----------------------
14                    Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.SubscriptionDetails
```

Retrieves the enterprise add-on details and subscription information for the specified Azure Managed Grafana workspace.

### Example 2: Retrieve enterprise details using pipeline input
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -Name azpstest-grafana | Test-AzGrafanaEnterpriseDetail
```

```output
MarketplaceTrialQuota SaasSubscriptionDetail
--------------------- ----------------------
14                    Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.SubscriptionDetails
```

Retrieves enterprise add-on details by piping a Grafana workspace object from Get-AzGrafana.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity
Parameter Sets: CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Check
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
Type: System.String
Parameter Sets: Check
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The workspace name of Azure Managed Grafana.

```yaml
Type: System.String
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IDashboardIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dashboard.Models.IEnterpriseDetails

## NOTES

## RELATED LINKS
