### Example 1: Create a container group with a container instance and request a public IP address with opening ports
```powershell
PS C:\> $port1 = New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
PS C:\> $port2 = New-AzContainerInstancePortObject -Port 8001 -Protocol TCP
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is latest nginx, and requests a public IP address with opening port 8000 and 8001.

### Example 2: Create container group and runs a custom script inside the container.
```powershell
PS C:\>  $env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
PS C:\>  $env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "value2" -AsPlainText -Force)
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "/bin/sh -c myscript.sh" -EnvironmentVariable @($env1, $env2)
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group and runs a custom script inside the container.

### Example 3: Create a run-to-completion container group
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "echo hello" 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group which prints out 'hello' and stops.

### Example 4: Create a container group with a container instance using image nginx in Azure Container Registry
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image myacr.azurecr.io/nginx:latest
PS C:\>  $imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myacr.azurecr.io" -Username "username" -Password (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force) 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is nginx in Azure Container Registry.

### Example 5: Create a container group with a container instance using image nginx in custom container image Registry
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image myserver.com/nginx:latest
PS C:\>  $imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force) 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 6: Create a container group that mounts Azure File volume
```powershell
PS C:\>  $volume = New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force)
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -Volume $volume

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 7: Create a container group with system assigned and user assigned identity
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity /subscriptions/<subscriptionId>/resourceGroups/<resourceGroup>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<UserIdentityName>

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with system assigned and user assigned identity.
