### Example 1: Saves an image of the VM to the Shared Image Gallery.
```powershell
<<<<<<< HEAD
Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabPlanName "Lab Plan Name" -Name "New Image Name" -LabVirtualMachineId "/subscriptions/<subscription Id>/resourceGroups/<group name>/providers/Microsoft.LabServices/labs/labName/virtualMachines/<vm name>"
=======
PS C:\> Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "New Image Name" -LabVirtualMachineId "/subscriptions/<subscription Id>/resourceGroups/<group name>/providers/Microsoft.LabServices/labs/labName/virtualMachines/<vm name>"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This creates a new image in the Shared Image Gallery.
