### Example 1: Get all labs
```powershell
Get-AzLabServicesLab
```

```output
Location      Name                                               Type
--------      ----                                               ----
westus2       Lab1                                               Microsoft.LabServices/labs
westus2       Lab2                                               Microsoft.LabServices/labs
westus2       Lab3                                               Microsoft.LabServices/labs
westus2       Lab4                                               Microsoft.LabServices/labs
```

Returns all labs for the current subscription.

### Example 2: Get a specific lab
```powershell
Get-AzLabServicesLab -ResourceGroupName 'yourgroupname' -Name 'yourlabname'
```

```output
Location      Name                                               Type
--------      ----                                               ----
westus2       yourlabName                                        Microsoft.LabServices/labs
```

Get a specific lab using the resource group name and the lab name.


### Example 3: Get all labs created with a lab plan
```powershell
$plan = Get-AzLabServicesLabPlan -LabPlanName 'lab plan name'
$plan | Get-AzLabServicesLab -Name 'lab name'
```

```output
Location      Name                                               Type
--------      ----                                               ----
westus2       lab Name                                        Microsoft.LabServices/labs
```

Get the specific lab in a lab plan using the lab plan object and the lab name.


### Example 4: Get labs using wildcards in the lab name.
```powershell
Get-AzLabServicesLab -ResourceGroupName 'group name' -Name '*lab name'
```

```output
Location      Name                                               Type
--------      ----                                               ----
westus2       yourlab Name                                        Microsoft.LabServices/labs
westus2       anotherlab Name                                     Microsoft.LabServices/labs
```

Using the Name parameter and a wildcard all labs in the resource group like the name are returned.