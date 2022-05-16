---
Module Name: Az.LabServices
Module Guid: 0d0952f2-9bc4-46b9-bc17-ab665c85916f
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.labservices
Help Version: 1.0.0.0
Locale: en-US
---

# Az.LabServices Module
## Description
Microsoft Azure PowerShell: LabServices cmdlets

## Az.LabServices Cmdlets
### [Get-AzLabServicesImage](Get-AzLabServicesImage.md)
Gets an image resource.

### [Get-AzLabServicesLab](Get-AzLabServicesLab.md)
Returns the properties of a lab resource.

### [Get-AzLabServicesLabPlan](Get-AzLabServicesLabPlan.md)
Retrieves the properties of a Lab Plan.

### [Get-AzLabServicesOperationResult](Get-AzLabServicesOperationResult.md)
Returns an azure operation result.

### [Get-AzLabServicesSchedule](Get-AzLabServicesSchedule.md)
Returns the properties of a lab Schedule.

### [Get-AzLabServicesSku](Get-AzLabServicesSku.md)
Returns a list of all the Azure Lab Services resource SKUs.

### [Get-AzLabServicesUsage](Get-AzLabServicesUsage.md)
Returns list of usage per SKU family for the specified subscription in the specified region.

### [Get-AzLabServicesUser](Get-AzLabServicesUser.md)
Returns the properties of a lab user.

### [Get-AzLabServicesVirtualMachine](Get-AzLabServicesVirtualMachine.md)
Returns the properties for a lab virtual machine.

### [Invoke-AzLabServicesInviteUser](Invoke-AzLabServicesInviteUser.md)
Operation to invite a user to a lab.

### [Invoke-AzLabServicesRedeployVirtualMachine](Invoke-AzLabServicesRedeployVirtualMachine.md)
Action to redeploy a lab virtual machine to a different compute node.
For troubleshooting connectivity.

### [New-AzLabServicesImage](New-AzLabServicesImage.md)
Updates an image resource via PUT.
Creating new resources via PUT will not function.

### [New-AzLabServicesLab](New-AzLabServicesLab.md)
Operation to create or update a lab resource.

### [New-AzLabServicesLabPlan](New-AzLabServicesLabPlan.md)
Operation to create or update a Lab Plan resource.

### [New-AzLabServicesSchedule](New-AzLabServicesSchedule.md)
Operation to create or update a lab schedule.

### [New-AzLabServicesUser](New-AzLabServicesUser.md)
Operation to create or update a lab user.

### [Publish-AzLabServicesLab](Publish-AzLabServicesLab.md)
Publish or re-publish a lab.
This will create or update all lab resources, such as virtual machines.

### [Remove-AzLabServicesLab](Remove-AzLabServicesLab.md)
Operation to delete a lab resource.

### [Remove-AzLabServicesLabPlan](Remove-AzLabServicesLabPlan.md)
Operation to delete a Lab Plan resource.
Deleting a lab plan does not delete labs associated with a lab plan, nor does it delete shared images added to a gallery via the lab plan permission container.

### [Remove-AzLabServicesSchedule](Remove-AzLabServicesSchedule.md)
Operation to delete a schedule resource.

### [Remove-AzLabServicesUser](Remove-AzLabServicesUser.md)
Operation to delete a user resource.

### [Reset-AzLabServicesVirtualMachinePassword](Reset-AzLabServicesVirtualMachinePassword.md)
Resets a lab virtual machine password.

### [Save-AzLabServicesLabPlanImage](Save-AzLabServicesLabPlanImage.md)
Saves an image from a lab VM to the attached shared image gallery.

### [Start-AzLabServicesVirtualMachine](Start-AzLabServicesVirtualMachine.md)
Action to start a lab virtual machine.

### [Stop-AzLabServicesVirtualMachine](Stop-AzLabServicesVirtualMachine.md)
Action to stop a lab virtual machine.

### [Sync-AzLabServicesLabGroup](Sync-AzLabServicesLabGroup.md)
Action used to manually kick off an AAD group sync job.

### [Update-AzLabServicesImage](Update-AzLabServicesImage.md)
Updates an image resource.

### [Update-AzLabServicesLab](Update-AzLabServicesLab.md)
Operation to update a lab resource.

### [Update-AzLabServicesLabPlan](Update-AzLabServicesLabPlan.md)
Operation to update a Lab Plan resource.

### [Update-AzLabServicesSchedule](Update-AzLabServicesSchedule.md)
Operation to update a lab schedule.

### [Update-AzLabServicesUser](Update-AzLabServicesUser.md)
Operation to update a lab user.

### [Update-AzLabServicesVirtualMachine](Update-AzLabServicesVirtualMachine.md)
Re-image a lab virtual machine.
The virtual machine will be deleted and recreated using the latest published snapshot of the reference environment of the lab.

