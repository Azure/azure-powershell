---
external help file: Az.DynatraceObservability-help.xml
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/invoke-azdynatracemanagemonitoragentinstallation
schema: 2.0.0
---

# Invoke-AzDynatraceManageMonitorAgentInstallation

## SYNOPSIS
Performs Dynatrace agent install/uninstall action through the Azure Dynatrace resource on the provided list of resources.

## SYNTAX

### ManageViaIdentity (Default)
```
Invoke-AzDynatraceManageMonitorAgentInstallation -InputObject <IDynatraceObservabilityIdentity>
 -Request <IManageAgentInstallationRequest> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaJsonString
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaJsonFilePath
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageExpanded
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Action <String> -ManageAgentInstallationList <IManageAgentList[]>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Manage
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Request <IManageAgentInstallationRequest> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzDynatraceManageMonitorAgentInstallation -InputObject <IDynatraceObservabilityIdentity>
 -Action <String> -ManageAgentInstallationList <IManageAgentList[]> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Performs Dynatrace agent install/uninstall action through the Azure Dynatrace resource on the provided list of resources.

## EXAMPLES

### Example 1: Install the Dynatrace agent on a virtual machine
```powershell
$targets = @(
	@{ resourceId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/rg-dynatrace/providers/Microsoft.Compute/virtualMachines/vm1" }
)
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName "rg-dynatrace" -MonitorName "dynatrace-monitor1" -Action Install -ManageAgentInstallationList $targets -PassThru
```

Initiates agent installation on the specified VM through the Dynatrace monitor, returning True on success.

### Example 2: Uninstall the Dynatrace agent using a JSON request
```powershell
$json = @{ 
	action = "Uninstall"; 
	manageAgentInstallationList = @(
		@{ resourceId = "/subscriptions/$(Get-AzContext).Subscription.Id/resourceGroups/rg-dynatrace/providers/Microsoft.Compute/virtualMachines/vm1" }
	) 
} | ConvertTo-Json -Depth 4
Invoke-AzDynatraceManageMonitorAgentInstallation -ResourceGroupName "rg-dynatrace" -MonitorName "dynatrace-monitor1" -JsonString $json -PassThru
```

Performs an uninstall using a JSON payload, simplifying scenarios where target resource lists are generated programmatically.

## PARAMETERS

### -Action
Install/Uninstall action.

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: ManageViaIdentity, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManageAgentInstallationList
The list of resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IManageAgentList[]
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
Request for performing Dynatrace agent install/uninstall action through the Azure Dynatrace resource on the provided list of agent resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IManageAgentInstallationRequest
Parameter Sets: ManageViaIdentity, Manage
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
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
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
Type: System.String
Parameter Sets: ManageViaJsonString, ManageViaJsonFilePath, ManageExpanded, Manage
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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IManageAgentInstallationRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
