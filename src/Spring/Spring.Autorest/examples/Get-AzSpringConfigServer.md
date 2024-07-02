### Example 1: Get the config server and its properties.
```powershell
Get-AzSpringConfigServer -ResourceGroupName azps_test_group_spring -Name azps-spring-02
```

```output
Code                             :
GitPropertyHostKey               :
GitPropertyHostKeyAlgorithm      :
GitPropertyLabel                 :
GitPropertyPassword              :
GitPropertyPrivateKey            :
GitPropertyRepository            :
GitPropertySearchPath            :
GitPropertyStrictHostKeyChecking :
GitPropertyUri                   :
GitPropertyUsername              :
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/configServers/default
Message                          :
Name                             : default
ProvisioningState                : Succeeded
ResourceGroupName                : azps_test_group_spring
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
Type                             : Microsoft.AppPlatform/Spring/configServers
```

Get the config server and its properties.