---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworkspaloaltonetworkscloudngfwoperationsupportinfo
schema: 2.0.0
---

# Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationSupportInfo

## SYNOPSIS
Get Support information for the subscription

## SYNTAX

```
Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationSupportInfo [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get Support information for the subscription

## EXAMPLES

### Example 1: Get Support information for the subscription
```powershell
Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationSupportInfo
```

```output
AccountId                 : 1768331
AccountRegistrationStatus : Registered
Credit                    : 0
EndDateForCredit          :
FreeTrial                 : Disabled
FreeTrialCreditLeft       : 0
FreeTrialDaysLeft         : 0
HelpUrl                   : https://live.paloaltonetworks.com?productSku=PAN-CLOUD-NGFW-AZURE-PAYG
HubUrl                    :
MonthlyCreditLeft         : 0
ProductSerial             : 001990770730
ProductSku                : PAN-CLOUD-NGFW-AZURE-PAYG
RegisterUrl               : https://support.paloaltonetworks.com/Home/Register?tenantId=888d76fa-54b2-4ced-8ee5-aac1585
                            adee7&productSku=PAN-CLOUD-NGFW-AZURE-PAYG&productSerial=001990770730&userEmail=prakgupta@m
                            icrosoft.com
StartDateForCredit        :
SupportUrl                : https://support.paloaltonetworks.com?productSku=PAN-CLOUD-NGFW-AZURE-PAYG&cspAccount=176833
                            1&userEmail=prakgupta@microsoft.com
```

Get Support information for the subscription.

## PARAMETERS

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ISupportInfoModel

## NOTES

## RELATED LINKS
