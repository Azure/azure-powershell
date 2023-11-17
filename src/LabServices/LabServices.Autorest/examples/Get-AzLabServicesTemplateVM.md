### Example 1: Get the template for the lab.
```powershell
PS C:\> Get-AzLabTemplateVM  -ResourceGroupName "group name" -LabName "lab name"

Name Type
---- ----
0    Microsoft.LabServices/labs/virtualMachines

```

Returns the template VM for the lab.