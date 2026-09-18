### Example 1: List customization groups by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -DevBoxName MyDevBox
```
This command lists customization groups for the dev box "MyDevBox" in the project "DevProject".

### Example 2: List customization groups by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -DevBoxName MyDevBox -Include tasks
```
This command lists customization groups for the dev box "MyDevBox" in the project "DevProject".

### Example 3: Get a customization group by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```
This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 4: Get a customization group by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```
This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 5: Get a customization group by endpoint and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" ="DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "me" }
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationGroupInput
```
This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".

### Example 6: Get a customization group by dev center and InputObject
```powershell
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" = "DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0" }
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -InputObject $customizationGroupInput 
```
This command gets a customization group named "Provisioning" for the dev box "MyDevBox" in the project "DevProject".
