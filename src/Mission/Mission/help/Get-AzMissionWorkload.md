---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/get-azmissionworkload
schema: 2.0.0
---

# Get-AzMissionWorkload

## SYNOPSIS
Get a WorkloadResource

## SYNTAX

### List (Default)
```
Get-AzMissionWorkload [-SubscriptionId <String[]>] -VirtualEnclaveName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityVirtualEnclave
```
Get-AzMissionWorkload -Name <String> -VirtualEnclaveInputObject <IMissionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMissionWorkload -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VirtualEnclaveName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzMissionWorkload -ResourceGroupName <String> [-SubscriptionId <String[]>] -VirtualEnclaveName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMissionWorkload -InputObject <IMissionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a WorkloadResource

## EXAMPLES

### Example 1: Get a workload by name
```powershell
Get-AzMissionWorkload -Name 'contoso-workload' -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave'
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Gets the workload named `contoso-workload` in the `contoso-enclave` virtual enclave.

### Example 2: List all workloads in a virtual enclave
```powershell
Get-AzMissionWorkload -ResourceGroupName 'mission-rg' -VirtualEnclaveName 'contoso-enclave'
```

```output
Name              Location ResourceGroupName ProvisioningState
----              -------- ----------------- -----------------
contoso-workload  eastus   mission-rg        Succeeded
```

Lists every workload in the `contoso-enclave` virtual enclave.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the workloadResource Resource

```yaml
Type: System.String
Parameter Sets: GetViaIdentityVirtualEnclave, Get
Aliases: WorkloadName

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
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualEnclaveInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentityVirtualEnclave
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualEnclaveName
The name of the enclaveResource Resource

```yaml
Type: System.String
Parameter Sets: List, Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IWorkloadResource

## NOTES

## RELATED LINKS
