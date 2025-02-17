---
Module Name: Az.ComputeSchedule
Module Guid: 76375f5d-b721-447e-ba62-aa330dbf596a
Download Help Link: https://learn.microsoft.com/powershell/module/az.computeschedule
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ComputeSchedule Module
## Description
Microsoft Azure PowerShell: ComputeSchedule cmdlets

## Az.ComputeSchedule Cmdlets
### [Get-AzComputeScheduleOperationError](Get-AzComputeScheduleOperationError.md)
VirtualMachinesGetOperationErrors: Get error details on operation errors (like transient errors encountered, additional logs) if they exist.

### [Get-AzComputeScheduleOperationStatus](Get-AzComputeScheduleOperationStatus.md)
VirtualMachinesGetOperationStatus: Polling endpoint to read status of operations performed on virtual machines

### [Invoke-AzComputeScheduleExecuteDeallocate](Invoke-AzComputeScheduleExecuteDeallocate.md)
VirtualMachinesExecuteDeallocate: Execute deallocate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.

### [Invoke-AzComputeScheduleExecuteHibernate](Invoke-AzComputeScheduleExecuteHibernate.md)
VirtualMachinesExecuteHibernate: Execute hibernate operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.

### [Invoke-AzComputeScheduleExecuteStart](Invoke-AzComputeScheduleExecuteStart.md)
VirtualMachinesExecuteStart: Execute start operation for a batch of virtual machines, this operation is triggered as soon as Computeschedule receives it.

### [Invoke-AzComputeScheduleSubmitDeallocate](Invoke-AzComputeScheduleSubmitDeallocate.md)
VirtualMachinesSubmitDeallocate: Schedule deallocate operation for a batch of virtual machines at datetime in future.

### [Invoke-AzComputeScheduleSubmitHibernate](Invoke-AzComputeScheduleSubmitHibernate.md)
VirtualMachinesSubmitHibernate: Schedule hibernate operation for a batch of virtual machines at datetime in future.

### [Invoke-AzComputeScheduleSubmitStart](Invoke-AzComputeScheduleSubmitStart.md)
VirtualMachinesSubmitStart: Schedule start operation for a batch of virtual machines at datetime in future.

### [Stop-AzComputeScheduleScheduledAction](Stop-AzComputeScheduleScheduledAction.md)
VirtualMachinesCancelOperations: Cancel a previously submitted (start/deallocate/hibernate) request

