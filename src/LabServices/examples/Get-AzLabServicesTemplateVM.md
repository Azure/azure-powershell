### Example 1: Get the template for the lab.
```powershell
<<<<<<< HEAD
Get-AzLabServicesTemplateVM -ResourceGroupName "group name" -LabName "lab name"
```

```output
Name Type
---- ----
0    Microsoft.LabServices/labs/virtualMachines
=======
PS C:\> Get-AzLabTemplateVM  -ResourceGroupName "group name" -LabName "lab name"

Name Type
---- ----
0    Microsoft.LabServices/labs/virtualMachines

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Returns the template VM for the lab.