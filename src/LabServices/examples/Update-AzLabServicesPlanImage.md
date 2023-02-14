### Example 1: Update a lab plan image.
```powershell
<<<<<<< HEAD
Update-AzLabServicesPlanImage -ResourceGroupName "Group Name" -LabPlanName "LabPlan Name" -Name "Image Name" -EnabledState "Enabled"
```

```output
=======
PS C:\> Update-AzLabServicesPlanImage -ResourceGroupName "Group Name" -LabPlanName "LabPlan Name" -Name "Image Name" -EnabledState "Enabled"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
Image Name
```

This example enables the image for use in labs.
