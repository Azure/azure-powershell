# PowerBI Embedded Capacity

## Planned PowerShell Release Milestone
- November 2017

## Service Release Details
- General Release
- The service already released
## Contact Information
- Main developer contacts [email - sagis@microsoft.com, github alias - selasagi]
- PM contact [avive@microsoft.com] 
- Other people who should attend a design review [tarostok@microsoft.com]

## High Level Scenarios
- Power BI Embedded is intended to simplify how ISVs and developers use Power BI capabilities, helping them quickly add stunning visuals, reports and dashboards into their apps see [Power BI Embedded](https://azure.microsoft.com/en-us/services/power-bi-embedded/ "Power BI Embedded"). Power BI Embedded offer SKUs in Azure called **PowerBI Embedded Capacity**. 
- Piping supported  
- Sample:
 ```
 > PS G:> Get-AzureRmPowerBIEmbeddedCapacity -Name capac1 
   Sku : {[Name, A1], [Tier, PBIE_Azure]} 
   Administrators : {sagis@microsoft.com} 
   State : Succeeded 
   ProvisioningState : Succeeded 
   Id : /subscriptions/78e47976-009f-4d4a-a961-6046cdabf459/resourceGroups/Sharetest/providers/Microsoft.PowerBIDedicated/capacities/capac1 
   Name : capac1 
   Type : Microsoft.PowerBIDedicated/capacities 
   Location : North Central US 
   Tag : {[tagName, MyTag]}
 ```

## Syntax changes

> ### New Cmdlet
> Sample syntax:
> ```powershell
> PS C:\> Get-AzureRmPowerBIEmbeddedCapacity [[-ResourceGroupName]] [[-Name]]
> PS C:\> New-AzureRmPowerBIEmbeddedCapacity [-ResourceGroupName] [-Name] [-Location] [-Sku] [[-Tag]] [[-Administrator]] [-WhatIf] [-Confirm]
> PS C:\> Remove-AzureRmPowerBIEmbeddedCapacity [-Name] [[-ResourceGroupName]] [-PassThru] [-WhatIf] [-Confirm]
> PS C:\> Resume-AzureRmPowerBIEmbeddedCapacity [[-ResourceGroupName]] [-Name] [-PassThru] [-WhatIf] [-Confirm]
> PS C:\> Set-AzureRmPowerBIEmbeddedCapacity [-Name] [[-ResourceGroupName]] [[-Sku]] [[-Tag]] [[-Administrator]] [-PassThru] [-WhatIf] [-Confirm]
> PS C:\> Suspend-AzureRmPowerBIEmbeddedCapacity [[-ResourceGroupName]] [-Name] [-PassThru] [-WhatIf] [-Confirm]
> PS C:\> Test-AzureRmPowerBIEmbeddedCapacity [-Name] [[-ResourceGroupName]]
> 
> ```
