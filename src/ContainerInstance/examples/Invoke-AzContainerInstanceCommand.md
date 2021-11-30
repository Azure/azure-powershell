### Example 1: Execute a command in a specific container instance
```powershell
PS C:\> Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName　test-rg -Command "echo hello"

hello
```

Executes command "echo hello" in a container instance `test-container`.
