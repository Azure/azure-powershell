### Example 1: Delete the AzADDomain by ResourceGroupName and Name
```powershell
Remove-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
```

Delete the AzADDomain by ResourceGroupName and Name

### Example 2: Delete the AzADDomain by InputObject
```powershell
$GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
Remove-AzADDomainService -InputObject $GetADDomainExample
```

Delete the AzADDomain by InputObject 

