### Example 1: Activate a SaaS resource
```powershell
Initialize-AzCommvaultSaaS -SaasGuid '55555555-6666-7777-8888-999999999999' -PublisherId 'contoso-publisher' -ActivateSaaSRequestParamSaasResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas' -UserFirstName 'John' -UserLastName 'Smith' -UserEmailAddress 'john.smith@contoso.com' -UserUpn 'john.smith@contoso.com' -CompanyName 'Contoso'
```

Activates the SaaS resource for the specified user and company.

### Example 2: Activate a SaaS resource by using a JSON request
```powershell
Initialize-AzCommvaultSaaS -JsonString '{"saasGuid":"55555555-6666-7777-8888-999999999999","publisherId":"contoso-publisher","activateSaaSRequestParam":{"saasResourceId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas","user":{"firstName":"John","lastName":"Smith","emailAddress":"john.smith@contoso.com","upn":"john.smith@contoso.com"},"company":{"companyName":"Contoso"}}}'
```

Activates the SaaS resource by passing the request body as a JSON string.

