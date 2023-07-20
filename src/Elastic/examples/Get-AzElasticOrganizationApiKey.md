### Example 1: Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization
```powershell
Get-AzElasticOrganizationApiKey -EmailId user@contoso.com
```

```output
ApiKey
------
NOTGENERATED
```

Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization.

### Example 2: Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization via JSON string
```powershell
$orgApiKeyProps = @{
    emailId = "user@contoso.com"
}
$orgApiKeyPropsJson = ConvertTo-Json -InputObject $orgApiKeyProps
Get-AzElasticOrganizationApiKey -JsonString $orgApiKeyPropsJson
```

```output
ApiKey
------
NOTGENERATED
```

Fetch User API Key from internal database, if it was generated and stored while creating the Elasticsearch Organization via JSON string.
