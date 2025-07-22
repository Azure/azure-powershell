### Example 1: Create a customization group by endpoint
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
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId 786a823c-8037-48ab-89b8-8599901e67d0 -DevBoxName myDevBox -CustomizationGroupName Provisioning -Task $tasks
```
This command creates the customization group "Provisioning" for the dev box "myDevBox".

### Example 2: Create a customization group by dev center
```powershell
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -UserId "me" -DevBoxName myDevBox -CustomizationGroupName Provisioning -Task $tasks
```
This command creates the customization group "Provisioning" for the dev box "myDevBox".

### Example 3: Create a customization group by endpoint and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "DevBoxName" = "myDevBox"; "UserId" = "me"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationGroupInput -Task $tasks
```
This command creates the customization group "Provisioning" for the dev box "myDevBox".

### Example 4: Create a customization group by dev center and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "DevBoxName" = "myDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject" }
New-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -InputObject $customizationGroupInput -Task $tasks
```
This command creates the customization group "Provisioning" for the dev box "myDevBox".