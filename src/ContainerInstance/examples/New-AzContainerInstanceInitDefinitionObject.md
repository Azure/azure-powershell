### Example 1: Set up the init container definition
```powershell
PS C:\> New-AzContainerInstanceInitDefinitionObject -Name "initDefinition" -Command "/bin/sh -c myscript.sh"

Name
----
initDefinition
```

This command sets up the init container definition with command `/bin/sh -c myscript.sh`