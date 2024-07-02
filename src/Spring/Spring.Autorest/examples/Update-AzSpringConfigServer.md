### Example 1: Update the config server.
```powershell
Update-AzSpringConfigServer -ResourceGroupName azps_test_group_spring -Name azps-spring-02 -GitLabel "master" -GitUri "https://github.com/lijinpei2008/ghatest" -GitUsername "ghatest"
```

```output
Code                             :
GitPropertyHostKey               :
GitPropertyHostKeyAlgorithm      :
GitPropertyLabel                 : master
GitPropertyPassword              :
GitPropertyPrivateKey            :
GitPropertyRepository            :
GitPropertySearchPath            :
GitPropertyStrictHostKeyChecking :
GitPropertyUri                   : https://github.com/lijinpei2008/ghatest
GitPropertyUsername              : *
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-02/configServers/default
Message                          :
Name                             : default
ProvisioningState                : Succeeded
ResourceGroupName                : azps_test_group_spring
SystemDataCreatedAt              : 2024-05-28 上午 10:37:15
SystemDataCreatedBy              : v-jinpel@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 2024-05-28 上午 10:37:15
SystemDataLastModifiedBy         : v-jinpel@microsoft.com
SystemDataLastModifiedByType     : User
Type                             : Microsoft.AppPlatform/Spring/configServers
```

Update the config server.