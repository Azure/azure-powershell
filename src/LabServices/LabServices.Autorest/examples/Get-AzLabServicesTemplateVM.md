### Example 1: Get the template for the lab.
```powershell
Get-AzLabServicesTemplateVM -ResourceGroupName "group name" -LabName "lab name"
```

```output
Name Type
---- ----
0    Microsoft.LabServices/labs/virtualMachines
```

Returns the template VM for the lab.