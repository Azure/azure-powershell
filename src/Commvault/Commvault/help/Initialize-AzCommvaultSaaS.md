---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/initialize-azcommvaultsaas
schema: 2.0.0
---

# Initialize-AzCommvaultSaaS

## SYNOPSIS
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzCommvaultSaaS [-SubscriptionId <String>] -SaasGuid <String>
 [-ActivateSaaSRequestParamSaasResourceId <String>] [-CompanyCity <String>] [-CompanyCountry <String>]
 [-CompanyJobTitle <String>] [-CompanyName <String>] [-CompanyPostalCode <String>] [-CompanyState <String>]
 [-CompanyStreet <String>] [-CompanyWebsite <String>] [-PublisherId <String>] [-UserEmailAddress <String>]
 [-UserFirstName <String>] [-UserLastName <String>] [-UserPhoneNumber <String>] [-UserUpn <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Activate
```
Initialize-AzCommvaultSaaS [-SubscriptionId <String>] -Body <IActivateSaaSParameterRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzCommvaultSaaS [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzCommvaultSaaS [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## EXAMPLES

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

## PARAMETERS

### -ActivateSaaSRequestParamSaasResourceId
Optional Marketplace SaaS resource identifier

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

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
SaaS guid for Activate and Validate SaaS Resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IActivateSaaSParameterRequest
Parameter Sets: Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CompanyCity
City of the company address.

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

### -CompanyCountry
Country of the company address.

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

### -CompanyJobTitle
Job title

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

### -CompanyName
Company name

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

### -CompanyPostalCode
Postal code

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

### -CompanyState
State or province of the company address.

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

### -CompanyStreet
Street address

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

### -CompanyWebsite
Company website

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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherId
Optional publisher identifier

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

### -SaasGuid
SaaS guid for Activate and Validate SaaS Resource

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
The value must be an UUID.

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

### -UserEmailAddress
Email address of the user

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

### -UserFirstName
First name of the user

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

### -UserLastName
Last name of the user

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

### -UserPhoneNumber
User's phone number

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

### -UserUpn
User's principal name

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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IActivateSaaSParameterRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ISaaSResourceDetailsResponse

## NOTES

## RELATED LINKS
