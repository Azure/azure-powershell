### Example 1: Delete the AzADDomain by ResourceGroupName and Name
```powershell
PS C:\> Remove-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName

```

Delete the AzADDomain by ResourceGroupName and Name

### Example 2: Delete the AzADDomain by InputObject
```powershell
PS C:\> $GetADDomainExample = Get-AzADDomainService -ResourceGroupName $env.ResourceGroupName -Name $env.ADdomainName
Remove-AzADDomainService -InputObject $GetADDomainExample

```

Delete the AzADDomain by InputObject 

