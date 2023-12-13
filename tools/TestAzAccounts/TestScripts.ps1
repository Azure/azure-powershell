DeployRunBook.ps1 -AutomationAccount 'AzAccountsTestAutomation'`
                  -IdentityType @('SystemAssigned', 'UserAssigned')`
                  -UserManagedIdentity 'xUAMI'`
                  -ResourceGroupName 'AzAccountsTest'`
                  -Subscription 'Azure SDK Powershell Test - Manual'`
                  -Location 'eastus'

DeployRunBook.ps1 -AutomationAccount 'AzAccountsTestAutomation'`
                  -IdentityType 'UserAssigned'`
                  -UserManagedIdentity 'xUAMI'`
                  -ResourceGroupName 'AzAccountsTest'`
                  -Subscription 'Azure SDK Powershell Test - Manual'`
                  -Location 'eastus'

. "$PSScriptRoot/DeployUserManagedIdentity.ps1" -Tenant $tenantId -Subscription $subscription -ResourceGroupName $resourceGroupName`
                                                -UserManagedIdentity $userManagedIdentity -Location $location

$ModulePath = 'https://azposhpreview.blob.core.windows.net/public/Az.Accounts.2.14.1-preview.nupkg'
$ModuleVersion = '2.14.1'

.\TestAzAccountsManagedIdentity.ps1 -ModulePath 'https://azposhpreview.blob.core.windows.net/public/Az.Accounts.2.14.1-preview.nupkg' -ModuleVersion '2.14.1'


Set-AzAutomationModule -AutomationAccountName 'AzAccountsTestAutomation' -Name 'Az.Accounts' -ContentLinkUri $ModulePath -ContentLinkVersion $ModuleVersion -ResourceGroupName 'AzAccountsTest'