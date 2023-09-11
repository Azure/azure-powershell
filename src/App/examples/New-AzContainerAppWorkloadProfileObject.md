### Example 1: Create an in-memory object for WorkloadProfile.
```powershell
New-AzContainerAppWorkloadProfileObject -Name "My-GP-01" -Type "GeneralPurpose" -MaximumCount 12 -MinimumCount 3
```

```output
MaximumCount MinimumCount Name
------------ ------------ ----
12           3            My-GP-01
```

Create an in-memory object for WorkloadProfile.