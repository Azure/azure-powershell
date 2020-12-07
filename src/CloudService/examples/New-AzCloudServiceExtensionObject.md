### Example 1: Create Geneva extension object

```powershell
PS C:\> $extension = New-AzCloudServiceExtensionObject -Name "GenevaExtension" -Publisher "Microsoft.Azure.Geneva" -Type "GenevaMonitoringPaaS" -TypeHandlerVersion "2.14.0.2"
```

This command creates Geneva extension object which is used for creating or updating a cloud service. For more details see New-AzCloudService.
