### Example 1: Saves an image of the VM to the Shared Image Gallery.
```powershell
Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabPlanName "Lab Plan Name" -Name "New Image Name" -LabVirtualMachineId "/subscriptions/<subscription Id>/resourceGroups/<group name>/providers/Microsoft.LabServices/labs/labName/virtualMachines/<vm name>"
```

This creates a new image in the Shared Image Gallery.
