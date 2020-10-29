### Example 1: Update role instance in update domain

```powershell
PS C:\> $extension = New-AzCloudServiceExtensionObject -Name "GenevaExtension" -Publisher "Microsoft.Azure.Geneva" -Type "GenevaMonitoringPaaS" -TypeHandlerVersion "2.14.0.2"
Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"

PS C:\> Set-AzCloudServiceUpdateDomain -CloudServiceName "ContosoCS" -ResourceGroupName "ContosOrg" -UpdateDomain 0
```

This command updates role instances in update domain 0 of cloud service named ContosoCS that belongs to the resource group named ContosOrg.
