### Example 1: Get a customization task by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -DevBoxName MyDevBox -CustomizationGroupName Provisioning -CustomizationTaskId "91835dc0-ef5a-4f58-9e3a-099aea8481f4"
```
This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provisioning" in the dev box "MyDevBox".

### Example 2: Get a customization task by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName Contoso -ProjectName DevProject -DevBoxName MyDevBox -CustomizationGroupName Provisioning -CustomizationTaskId "91835dc0-ef5a-4f58-9e3a-099aea8481f4"
```
This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provisioning" in the dev box "MyDevBox".

### Example 3: Get a customization task by endpoint and InputObject
```powershell
$customizationTaskLogInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" ="DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "me"; "CustomizationTaskId" = "91835dc0-ef5a-4f58-9e3a-099aea8481f4" }
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationTaskInput
```
This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provisioning" in the dev box "MyDevBox".

### Example 4: Get a customization task by dev center and InputObject
```powershell
$customizationTaskLogInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" = "DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "CustomizationTaskId" = "91835dc0-ef5a-4f58-9e3a-099aea8481f4" }
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName Contoso -InputObject $customizationTaskInput 
```
This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provisioning" in the dev box "MyDevBox".
