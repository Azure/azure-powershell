---
external help file:
Module Name: Az.SapVirtualInstance
online version: https://learn.microsoft.com/powershell/module/az.sapvirtualinstance/start-azworkloadssapapplicationinstance
schema: 2.0.0
---

# Start-AzWorkloadsSapApplicationInstance

## SYNOPSIS
Starts the SAP Application Server Instance.

## SYNTAX

### StartExpanded (Default)
```
Start-AzWorkloadsSapApplicationInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String>] [-StartVM] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Start
```
Start-AzWorkloadsSapApplicationInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> -Body <IStartRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzWorkloadsSapApplicationInstance -InputObject <ISapVirtualInstanceIdentity> -Body <IStartRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentityExpanded
```
Start-AzWorkloadsSapApplicationInstance -InputObject <ISapVirtualInstanceIdentity> [-StartVM]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Starts the SAP Application Server Instance.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Start SAP instance(s) request body.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.IStartRequest
Parameter Sets: Start, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: StartViaIdentity, StartViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of SAP Application Server instance resource.

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapVirtualInstanceName
The name of the Virtual Instances for SAP solutions resource

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartVM
The boolean value indicates whether to start the virtual machines before starting the SAP instances.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: StartExpanded, StartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Start, StartExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.IStartRequest

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api30.IOperationStatusResult

## NOTES

## RELATED LINKS


