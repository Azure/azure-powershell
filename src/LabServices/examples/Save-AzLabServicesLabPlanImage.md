### Example 1: Saves an image of the VM to the Shared Image Gallery.
```powershell
PS C:\> Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "New Image Name" -LabVirtualMachineId "/subscriptions/<subscription Id>/resourceGroups/<group name>/providers/Microsoft.LabServices/labs/labName/virtualMachines/<vm name>"

```

This creates a new image in the Shared Image Gallery.
