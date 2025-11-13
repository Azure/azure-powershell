---
external help file:
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
 -Request <IManageAgentInstallationRequest> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Manage
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 -Request <IManageAgentInstallationRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageExpanded
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 -Action <String> -ManageAgentInstallationList <IManageAgentList[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzDynatraceManageMonitorAgentInstallation -InputObject <IDynatraceObservabilityIdentity>
 -Action <String> -ManageAgentInstallationList <IManageAgentList[]> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaJsonFilePath
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ManageViaJsonString
```
Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Performs Dynatrace agent install/uninstall action through the Azure Dynatrace resource on the provided list of resources.

## EXAMPLES

### Example 1: Install Dynatrace agent on a VM using a request object
```powershell
$subId = (Get-AzContext).Subscription.Id
$vmId  = "/subscriptions/$subId/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/appvm1"

$request = New-Object Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentInstallationRequest
$request.Action = "Install"
$vmEntry = New-Object Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.ManageAgentList
$vmEntry.Id = $vmId
$request.ManageAgentInstallationList = @($vmEntry)

Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup" -Request $request -PassThru
```

Creates a ManageAgentInstallationRequest to install the Dynatrace agent on the specified virtual machine and invokes the operation. PassThru returns true on success.

### Example 2: Uninstall Dynatrace agent using a JSON string
```powershell
$subId = (Get-AzContext).Subscription.Id
$json = @{ 
	action = "Uninstall"; 
	manageAgentInstallationList = @(
		@{ id = "/subscriptions/$subId/resourceGroups/myResourceGroup/providers/Microsoft.Compute/virtualMachines/appvm1" }
	)
} | ConvertTo-Json -Depth 5

Invoke-AzDynatraceManageMonitorAgentInstallation -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup" -JsonString $json -PassThru
```

Provides the request payload as a JSON string to uninstall the Dynatrace agent from the target VM. Using -JsonString avoids manually constructing typed objects.

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
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
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
Parameter Sets: Manage, ManageViaIdentity
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
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
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
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
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

