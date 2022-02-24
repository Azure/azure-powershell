### Example 1: Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb
```powershell
PS C:\> New-AzContainerInstanceObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5

Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb
```powershell
PS C:\> New-AzContainerInstanceObject -Image alpine -Name "test-container" -LimitCpu 2 -LimitMemoryInGb 2.5

Name
----
test-container
```

Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb

### Example 3: Create a container group with a container instance
```powershell
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image alpine
PS C:\> New-AzContainerGroup -ResourceGroupName testrg-rg -Name test-cg -Location eastus -Container $container

Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```
Create a container group with a container instance