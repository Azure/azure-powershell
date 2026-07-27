### Example 1: Resolve the token and activate a marketplace SaaS resource
```powershell
Initialize-AzDatadogSaaSOperationGroupResource -SaaSResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/mySaaSResource" -UserInfoName "Alice" -UserInfoEmailAddress "alice@example.com" -DatadogOrganizationPropertyName "myOrganization" -DatadogOrganizationPropertyId "org123456"
```

```output
Id                           :
Name                         :
ResourceGroupName            :
SaaSId                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/mySaaSResource
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         :
```

This command resolves the token to get the SaaS resource ID and activates the SaaS resource.

