### Example 1: Create save image body.
```powershell
PS C:\> $saveBody = New-AzLabServicesSaveImageObject -Name "Image Name" -VirtualMachineId "Virtual Machine Id"
Save-AzLabServicesLabPlanImage -ResourceGroupName "Group Name" -LabPlanName "Lab Plan Name" -Body $saveBody

```

This cmdlet creates the minimum information to save an image using the body parameter.
