[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]
    $ModulePath,

    [Parameter(Mandatory = $true)]
    [string]
    $ModuleVersion
)
$subscription = 'Azure SDK Powershell Test - Manual'
$resourceGroupName = 'AzAccountsTest'
$automationAccount = 'AzAccountsTestAutomation'
$location = 'eastus'
$userManagedIdentity = 'AzAccountsTestUMI'

Set-AzContext -SubscriptionName $subscription
New-AzResourceGroup -Name $ResourceGroupName -Location $Location

. "$PSScriptRoot/DeployRunbook.ps1" -AutomationAccount $automationAccount -IdentityType @('SystemAssigned', 'UserAssigned') -UserManagedIdentity $userManagedIdentity -ResourceGroupName $resourceGroupName -Subscription $subscription -Location $location
Set-AzAutomationModule -AutomationAccountName $automationAccount -Name 'Az.Accounts' -ContentLinkUri $ModulePath -ContentLinkVersion $ModuleVersion -ResourceGroupName $resourceGroupName

$runbookName = 'AzAccountsTestRunbook'
$params = [ordered]@{
    "ResourceGroupName" = $resourceGroupName;
    "UserManagedIdentity" = $userManagedIdentity;
    "AutomationAccount" = $automationAccount;
    "Method" = "UA"
}
Start-AzAutomationRunbook -AutomationAccountName $automationAccount -Name $runbookName -ResourceGroupName $resourceGroupName -Parameters $params

$job = Get-AzAutomationJob -RunbookName $runbookName -AutomationAccountName $automationAccount -ResourceGroupName $resourceGroupName
$output = $null
while ($null -eq $output)
{
    $output = Get-AzAutomationJobOutput -Id $job.JobId -AutomationAccountName $automationAccount -ResourceGroupName $resourceGroupName -Stream 'Any'
    Start-Sleep -Seconds 2
}

$errOutput = $output | Where-Object {$_.Type -eq 'Error'}
if ($null -eq $errOutput -or 0 -eq $errOutput.Count)
{
    Write-Output "Job run successfully!"
    Write-Host 'Press any key to continue'
    $null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
    Remove-AzAutomationAccount -Name $automationAccount -ResourceGroupName $resourceGroupName -Force
}
else
{
    Write-Output "Job error count: $($errOutput.Count)"
}
