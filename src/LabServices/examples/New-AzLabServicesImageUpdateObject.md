### Example 1: Create the update plan image body.
```powershell
PS C:\> $body = New-AzLabServicesImageUpdateObject -EnabledState "Enabled"
PS C:\> Update-AzLabServicesLabPlanImage -ImageName 'canonical.0001-com-ubuntu-server-focal.20_04-lts' -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -Body $body

Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

This cmdlet creates the minimum information to update an image in a lab plan using the body parameter.
