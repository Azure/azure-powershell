### Example 1: Create a container group profile with a container instance and request a public IP address with opening ports
```powershell
$port1 = New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
$port2 = New-AzContainerInstancePortObject -Port 8001 -Protocol TCP
$container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
$containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName test-rg -Name test-cgp -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cgp      test-rg
```

This commands creates a container group profile with a container instance, whose image is latest nginx, and requests a public IP address with opening port 8000 and 8001.

### Example 2: Create container group profile and runs a custom script inside the container.
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
$env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue $pwd
$container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "/bin/sh -c myscript.sh" -EnvironmentVariable @($env1, $env2) -RequestCpu 1 -RequestMemoryInGb 1.5
$containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName test-rg -Name test-cgp -Location eastus -Container $container -OsType Linux
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cgp      test-rg
```

This commands creates a container group profile and runs a custom script inside the container.

### Example 3: Create a container group profile with a container instance using image nginx in Azure Container Registry
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$container = New-AzContainerInstanceObject -Name test-container -Image myacr.azurecr.io/nginx:latest -RequestCpu 1 -RequestMemoryInGb 1.5
$imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myacr.azurecr.io" -Username "username" -Password $pwd
$containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName test-rg -Name test-cgp -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential -OsType Linux
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cgp      test-rg
```

This commands creates a container group profile with a container instance, whose image is nginx in Azure Container Registry.

### Example 4: Create a container group profile with Spot priority and a container instance using nginx image 
```powershell
$container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5
$containerGroupProfile = New-AzContainerInstanceContainerGroupProfile -ResourceGroupName test-rg -Name test-cgp -Location eastus -Container $container -OsType Linux -RestartPolicy Never -Priority Spot
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cgp      test-rg
```

This commands creates a container group profile with spot priority and a container instance, whose image is nginx.
