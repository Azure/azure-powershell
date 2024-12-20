### Example 1: Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization.
$EmailIdObject = [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20240301.UserEmailId]::new()
$EmailIdObject.EmailId = "jkore@microsoft.com"
```powershell
Get-AzElasticOrganizationApiKey -Body $EmailIdObject
```

This command will Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization.