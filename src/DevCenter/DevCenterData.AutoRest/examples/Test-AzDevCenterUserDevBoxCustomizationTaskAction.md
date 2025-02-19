### Example 1: Validate customization tasks by endpoint
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -Task $tasks
```
This command validates the task "choco" by the endpoint. 

### Example 2: Validate customization tasks by dev center
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "User"
    TimeoutInSecond = 120
}
$tasks = @($task)
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName Contoso -ProjectName DevProject -Task $tasks
```
This command validates the task "choco" by the dev center.

### Example 3: Validate customization tasks by endpoint and InputObject
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
$taskInput = @{"ProjectName" = "DevProject" }
Test-AzDevCenterUserDevBoxCustomizationTaskAction -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $taskInput -Task $tasks
```
This command validates the task "choco" by the endpoint and InputObject.

### Example 4: Validate customization tasks by dev center and InputObject
```powershell
$task = @{
    Name = "catalogName/choco"
    DisplayName = "choco"
    Parameter = @{
        PackageName = "vscode"
        PackageVersion = "1.0.0"
    }
    RunAs = "System"
    TimeoutInSecond = 120
}
$tasks = @($task)
$taskInput = @{"ProjectName" = "DevProject" }
Test-AzDevCenterUserDevBoxCustomizationTaskAction -DevCenterName Contoso -InputObject $taskInput -Task $tasks
```
This command validates the task "choco" by the dev center and InputObject.
