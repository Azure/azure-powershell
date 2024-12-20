---
external help file: Az.Terraform-help.xml
Module Name: Az.Terraform
online version: https://learn.microsoft.com/powershell/module/az.terraform/export-azterraform
schema: 2.0.0
---

# Export-AzTerraform

## SYNOPSIS
Exports the Terraform configuration of the specified resource(s).

## SYNTAX

### Export (Default)
```
Export-AzTerraform [-SubscriptionId <String>] -ExportParameter <IBaseExportModel> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExportViaJsonFilePath
```
Export-AzTerraform [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExportViaJsonString
```
Export-AzTerraform [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Exports the Terraform configuration of the specified resource(s).

## EXAMPLES

### Example 1: Export Resources by Resource Id
```powershell
Export-AzTerraform -ExportParameter $(New-AzTerraformExportResourceObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-pwsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet")
```

```output
AdditionalInfo    :
Code              :
Configuration     : terraform {
                      required_providers {
                        azurerm = {
                          source  = "azurerm"
                          version = "4.0.1"
                        }
                      }
                    }
                    provider "azurerm" {
                      features {}
                    }
                    resource "azurerm_virtual_network" "res-0" {
                      address_space           = ["10.0.0.0/16"]
                      bgp_community           = ""
                      dns_servers             = []
                      edge_zone               = ""
                      flow_timeout_in_minutes = 0
                      location                = "westus3"
                      name                    = "test-vnet"
                      resource_group_name     = "aztfy-pwsh-test-rg"
                      subnet = [{
                        address_prefixes                              = ["10.0.0.0/24"]
                        default_outbound_access_enabled               = false
                        delegation                                    = []
                        id                                            = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-p
                    wsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"
                        name                                          = "default"
                        private_endpoint_network_policies             = "Disabled"
                        private_link_service_network_policies_enabled = true
                        route_table_id                                = ""
                        security_group                                = ""
                        service_endpoint_policy_ids                   = []
                        service_endpoints                             = []
                      }]
                      tags = {}
                    }

Detail            :
EndTime           : 9/11/2024 2:32:17 AM
Errors            :
Id                : /subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.AzureTerraform/operationStatuses/00000000-0000-0000-0000-000000000002*A034E6455B3397057968069439403400471981A03C6A372DB86AB63D04A41AD4
Message           :
Name              : 00000000-0000-0000-0000-000000000002*A034E6455B3397057968069439403400471981A03C6A372DB86AB63D04A41AD4
PercentComplete   :
ResourceGroupName :
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000001/providers/
SkippedResource   :
StartTime         : 9/11/2024 2:32:14 AM
Status            : Succeeded
Target            :
```

Export a resource by its resource ID

### Example 2: Export a Resource Group by its name
```powershell
Export-AzTerraform -ExportParameter $(New-AzTerraformExportResourceGroupObject -ResourceGroupName "aztfy-pwsh-test-rg")
```

```output
AdditionalInfo    :
Code              :
Configuration     :
Detail            :
EndTime           : 9/11/2024 2:45:04 AM
Errors            :
Id                : /subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.AzureTerraform/operationStatuses/96e64a19-eed2-4d98-9d5
                    a-58c0b8a0aff0*A034E6455B3397057968069439403400471981A03C6A372DB86AB63D04A41AD4
Message           :
Name              : 96e64a19-eed2-4d98-9d5a-58c0b8a0aff0*A034E6455B3397057968069439403400471981A03C6A372DB86AB63D04A41AD4
PercentComplete   :
ResourceGroupName :
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000001/providers/
SkippedResource   : {/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups//subscriptions/00000000-0000-0000-0000-000000000001/resourc
                    eGroups/aztfy-pwsh-test-rg}
StartTime         : 9/11/2024 2:45:02 AM
Status            : Succeeded
Target            :
```

Export a resource group by its name

### Example 3: Export resources by an ARG query
```powershell
Export-AzTerraform -ExportParameter $(New-AzTerraformExportQueryObject -Query "type =~ `"microsoft.network/virtualnetworks`"")
```

```output
AdditionalInfo    :
Code              :
Configuration     : terraform {
                      required_providers {
                        azurerm = {
                          source  = "azurerm"
                          version = "4.0.1"
                        }
                      }
                    }
                    provider "azurerm" {
                      features {}
                    }
                    resource "azurerm_virtual_network" "res-0" {
                      address_space           = ["10.0.0.0/16"]
                      bgp_community           = ""
                      dns_servers             = []
                      edge_zone               = ""
                      flow_timeout_in_minutes = 0
                      location                = "westus3"
                      name                    = "test-vnet"
                      resource_group_name     = "aztfy-pwsh-test-rg"
                      subnet = [{
                        address_prefixes                              = ["10.0.0.0/24"]
                        default_outbound_access_enabled               = false
                        delegation                                    = []
                        id                                            = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/aztfy-p
                    wsh-test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"
                        name                                          = "default"
                        private_endpoint_network_policies             = "Disabled"
                        private_link_service_network_policies_enabled = true
                        route_table_id                                = ""
                        security_group                                = ""
                        service_endpoint_policy_ids                   = []
                        service_endpoints                             = []
                      }]
                      tags = {}
                    }

Detail            :
EndTime           : 9/11/2024 7:40:17 AM
Errors            :
Id                : /subscriptions/00000000-0000-0000-0000-000000000001/providers/Microsoft.AzureTerraform/operationStatuses/5cf722ab-84a1-4a94-a58
                    6-356b6db6bb86*BED64399B6CC85896CB12E2360BF08E2FDF3132D587CEED230628920BA5D959D
Message           :
Name              : 5cf722ab-84a1-4a94-a586-356b6db6bb86*BED64399B6CC85896CB12E2360BF08E2FDF3132D587CEED230628920BA5D959D
PercentComplete   :
ResourceGroupName :
ResourceId        : /subscriptions/00000000-0000-0000-0000-000000000001/providers/
SkippedResource   :
StartTime         : 9/11/2024 7:40:12 AM
Status            : Succeeded
Target            :
```

Export resources by an ARG query

## PARAMETERS

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

### -ExportParameter
The base export parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IBaseExportModel
Parameter Sets: Export
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Export operation

```yaml
Type: System.String
Parameter Sets: ExportViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Export operation

```yaml
Type: System.String
Parameter Sets: ExportViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IBaseExportModel

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Terraform.Models.IOperationStatus

## NOTES

## RELATED LINKS
