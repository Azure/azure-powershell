### Example 1: Execute a command in a specific container instance
```powershell
Invoke-AzContainerInstanceCommand -ContainerGroupName test-cg -ContainerName test-container -ResourceGroupName test-rg -Command "echo hello"
```

```output
hello
```

Executes command "echo hello" in a container instance `test-container`.
