### Example 1: Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb
```powershell
New-AzContainerInstanceObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb
```powershell
New-AzContainerInstanceObject -Image alpine -Name "test-container" -LimitCpu 2 -LimitMemoryInGb 2.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb

### Example 3: Create a container group with a container instance
```powershell
$container = New-AzContainerInstanceObject -Name test-container -Image alpine
New-AzContainerGroup -ResourceGroupName testrg-rg -Name test-cg -Location eastus -Container $container
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```
Create a container group with a container instance