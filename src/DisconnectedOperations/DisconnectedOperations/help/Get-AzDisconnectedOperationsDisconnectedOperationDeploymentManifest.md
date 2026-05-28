---
external help file: Az.DisconnectedOperations-help.xml
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/get-azdisconnectedoperationsdisconnectedoperationdeploymentmanifest
schema: 2.0.0
---

# Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest

## SYNOPSIS
Get deployment manifest.

## SYNTAX

```
Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get deployment manifest.

## EXAMPLES

### Example 1: Get deployment manifest for a DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsDisconnectedOperationDeploymentManifest -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2"
```

```output
BenefitPlanAzureHybridWindowsServerBenefit : Enabled
BenefitPlanWindowsServerVMCount            : 10
BillingConfigurationAutoRenew              : Disabled
BillingConfigurationBillingStatus          : Enabled
BillingModel                               : Capacity
Cloud                                      : AzureCloud
ConnectionIntent                           : Disconnected
CurrentCore                                : 8
CurrentEndDate                             : 03/01/2027 00:00:00
CurrentPricingModel                        : Annual
CurrentStartDate                           : 03/02/2026 00:00:00
Location                                   : eastus2euap
ResourceId                                 : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/winfield-demo-rg-2/providers/Microsoft.Edge/disconnectedOperations/winfield-ps-test
ResourceName                               : winfield-ps-test
StampId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx
UpcomingCore                               : 0
UpcomingEndDate                            :
UpcomingPricingModel                       :
UpcomingStartDate                          :
```

This command gets the deployment manifest for the DisconnectedOperation `winfield-ps-test` in resource group `winfield-demo-rg-2`.

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

### -Name
Name of the resource

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest

## NOTES

## RELATED LINKS
