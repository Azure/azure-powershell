### Example 1: Fail Over to secondary namespace of an alias
```powershell
Set-AzEventHubGeoDRConfigurationFailOver -ResourceGroupName myResourceGroup -NamespaceName mySecondaryNamespace -Name myAlias
```

Fails over to `mySecondaryNamespace` which is secondary namespace of alias `myAlias`.

