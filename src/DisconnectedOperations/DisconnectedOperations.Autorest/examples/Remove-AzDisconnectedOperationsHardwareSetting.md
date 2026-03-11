### Example 1: Delete a hardware setting for a specific resource with expanded parameters
```powershell
Remove-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default"
```

This command deletes the hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2". You can specify additional parameters such as SubscriptionId if you want to target a different subscription, or use -Confirm and -WhatIf for safer execution.

### Example 2: Delete a hardware setting for a specific resource using identity.
```powershell
$inputObject = @{
  "HardwareSettingName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Remove-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject
```

This command deletes the hardware setting named "default" for the resource identified by the input object, which includes the name of the disconnected operation, resource group, and subscription ID.

### Example 3: Delete a hardware setting for a specific resource using DisconnectedOperation identity
```powershell
$disconnectedOperations = @{
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

This command deletes the hardware setting named "default" for the resource identified by the DisconnectedOperation identity, which includes the name of the disconnected operation, resource group, and subscription ID.