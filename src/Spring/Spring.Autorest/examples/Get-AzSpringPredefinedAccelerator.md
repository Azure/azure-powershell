### Example 1: Get the predefined accelerator.
```powershell
Get-AzSpringPredefinedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorName default
```

```output
Name                        DisplayName                ProvisioningState ResourceGroupName
----                        -----------                ----------------- -----------------
asa-acme-fitness-store      Acme Fitness Store         Succeeded         azps_test_group_spring
asa-java-rest-service       Tanzu Java Restful Web App Succeeded         azps_test_group_spring
asa-node-express            Node Express               Succeeded         azps_test_group_spring
asa-spring-cloud-serverless Spring Cloud Serverless    Succeeded         azps_test_group_spring
asa-weatherforecast-csharp  C# Weather Forecast        Succeeded         azps_test_group_spring
```

Get the predefined accelerator.

### Example 2: Get the predefined accelerator.
```powershell
Get-AzSpringPredefinedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorName default -Name asa-node-express
```

```output
AcceleratorTag               :
Description                  :
DisplayName                  : Node Express
IconUrl                      :
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps_test_group_spring/providers/Microsoft.AppPlatform/Spring/azps-spring-01/applicationAccelerators/default/p
                               redefinedAccelerators/asa-node-express
Name                         : asa-node-express
ProvisioningState            : Succeeded
ResourceGroupName            : azps_test_group_spring
SkuCapacity                  :
SkuName                      :
SkuTier                      :
State                        : Enabled
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AppPlatform/Spring/applicationAccelerators/predefinedAccelerators
```

Get the predefined accelerator.