## EXAMPLES

### Example 1: Create a container instance
```powershell
New-AzContainerInstanceNoDefaultObject -Name "test-container"
```

```output
Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: Create a container group with a container instance
```powershell
$container = New-AzContainerInstanceNoDefaultObject -Name test-container
New-AzContainerGroup -ResourceGroupName testrg-rg -Name test-cg -Location eastus -Container $container
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

Create a container group with a container instance