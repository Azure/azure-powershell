### Example 1: Create extension data source object
```powershell
New-AzExtensionDataSourceObject -ExtensionName AzureSecurityLinuxAgent -ExtensionSetting @{auditLevel='4'; maxQueueSize='1234'} -Name "myExtensionDataSource1" -Stream "Microsoft-OperationLog"
```

```output
ExtensionName    : AzureSecurityLinuxAgent
ExtensionSetting : {
                     "maxQueueSize": "1234",
                     "auditLevel": "4"
                   }
InputDataSource  : 
Name             : myExtensionDataSource1
Stream           : {Microsoft-OperationLog}
```

This command creates a extension data source object.
