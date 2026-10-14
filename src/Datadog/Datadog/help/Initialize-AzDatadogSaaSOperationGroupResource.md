---
external help file: Az.Datadog-help.xml
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/initialize-azdatadogsaasoperationgroupresource
schema: 2.0.0
---

# Initialize-AzDatadogSaaSOperationGroupResource

## SYNOPSIS
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzDatadogSaaSOperationGroupResource [-SubscriptionId <String>] -SaaSResourceId <String>
 [-DatadogOrganizationPropertyApiKey <SecureString>]
 [-DatadogOrganizationPropertyApplicationKey <SecureString>] [-DatadogOrganizationPropertyCspm]
 [-DatadogOrganizationPropertyEnterpriseAppId <String>] [-DatadogOrganizationPropertyId <String>]
 [-DatadogOrganizationPropertyLinkingAuthCode <SecureString>]
 [-DatadogOrganizationPropertyLinkingClientId <SecureString>] [-DatadogOrganizationPropertyName <String>]
 [-DatadogOrganizationPropertyRedirectUri <String>] [-DatadogOrganizationPropertyResourceCollection]
 [-UserInfoEmailAddress <String>] [-UserInfoName <String>] [-UserInfoPhoneNumber <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Activate
```
Initialize-AzDatadogSaaSOperationGroupResource [-SubscriptionId <String>] -Body <IActivateSaaSParameterRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzDatadogSaaSOperationGroupResource [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzDatadogSaaSOperationGroupResource [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## EXAMPLES

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

## PARAMETERS

### -Body
SaaS resource details for Activate and Validate SaaS Resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IActivateSaaSParameterRequest
Parameter Sets: Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyApiKey
Api key associated to the Datadog organization.

```yaml
Type: System.Security.SecureString
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyApplicationKey
Application key associated to the Datadog organization.

```yaml
Type: System.Security.SecureString
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyCspm
The configuration which describes the state of cloud security posture management.
This collects configuration information for all resources in a subscription and track conformance to industry benchmarks.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyEnterpriseAppId
The Id of the Enterprise App used for Single sign on.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyId
Id of the Datadog organization.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyLinkingAuthCode
The auth code used to linking to an existing Datadog organization.

```yaml
Type: System.Security.SecureString
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyLinkingClientId
The client_id from an existing in exchange for an auth token to link organization.

```yaml
Type: System.Security.SecureString
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyName
Name of the Datadog organization.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyRedirectUri
The redirect URI for linking.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyResourceCollection
The configuration which describes the state of resource collection.
This collects configuration information for all resources in a subscription.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaaSResourceId
SaaS resource id of marketplace saas subscription to be activated.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoEmailAddress
Email of the user used by Datadog for contacting them if needed

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoName
Name of the user

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoPhoneNumber
Phone number of the user used by Datadog for contacting them if needed

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IActivateSaaSParameterRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ISaaSResourceDetailsResponse

## NOTES

## RELATED LINKS
