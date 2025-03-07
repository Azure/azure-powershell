### Example 1: Update a dataflow
```powershell
Set-AzIoTOperationsServiceDataflow -InstanceName  "aio-instance-name"  -Name "dataflow-name"   -ProfileName "dataflowprofile-name"  -ResourceGroupName "aio-validation-116116143"  -ExtendedLocationName "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-116116143/providers/Microsoft.ExtendedLocation/customLocations/location-116116143"  -Operation @(@{ operationType = "Source" })
```

```output
sample output
```

Updates a dataflow


