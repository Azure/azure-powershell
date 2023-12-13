
[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [string]
    $AutomationAccount,

    [Parameter(Mandatory = $true)]
    [string[]]
    $IdentityType,

    [Parameter()]
    [string]
    $UserManagedIdentity,

    [Parameter(Mandatory = $true)]
    [string]
    $ResourceGroupName,

    [Parameter(Mandatory = $true)]
    [string]
    $Subscription,

    [Parameter(Mandatory = $true)]
    [string]
    $Location
)

$types = [Array]$IdentityType

#$ResourceGroupName = 'AzAccountsTest'
#$AutomationAccount = 'AzAccountsTestAutomation'
#$Location = 'eastus'
#$UserManagedIdentity = 'xUAMI'

if ($Subscription.Length -le 0)
{
    $Subscription = 'Azure SDK Powershell Test - Manual'
}
Set-AzContext -SubscriptionName $Subscription

$automationParams = @{
    'ResourceGroupName' = $ResourceGroupName;
    'Name' = $AutomationAccount;
    'Location' = $Location;
}

if ($types -Contains 'SystemAssigned')
{
    $automationParams['AssignSystemIdentity'] = $true
}

if ($types -Contains 'UserAssigned')
{
    $userIdentity = Get-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $UserManagedIdentity
    if ($null -eq $userIdentity)
    {
        $userIdentity = New-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $UserManagedIdentity -Location $Location
    }
    $automationParams['AssignUserIdentity'] = $userIdentity.Id;
}

$autoAccount = New-AzAutomationAccount @automationParams

$RunbookName = 'AzAccountsTestRunbook'
Import-AzAutomationRunbook -Path 'AzAccountsTestRunbook.ps1'  -Name $RunbookName -Type 'PowerShell' -AutomationAccountName $AutomationAccount -ResourceGroupName $ResourceGroupName -Force
Publish-AzAutomationRunbook -Name $RunbookName -AutomationAccountName $AutomationAccount  -ResourceGroupName $ResourceGroupName

$roleDevTest = 'DevTest Labs User'
$roleReader = 'Reader'
$scope = "/subscriptions/$($autoAccount.SubscriptionId)"
#$scope = "/subscriptions/$($autoAccount.SubscriptionId)/resourceGroups/$($autoAccount.ResourceGroupName)/providers/Microsoft.Automation/automationAccounts/$($autoAccount.AutomationAccountName)"
New-AzRoleAssignment -ObjectId $autoAccount.Identity.PrincipalId -RoleDefinitionName $roleDevTest -Scope $scope
New-AzRoleAssignment -ObjectId $autoAccount.Identity.PrincipalId -RoleDefinitionName $roleReader -Scope $scope
New-AzRoleAssignment -ObjectId $userIdentity.PrincipalId -RoleDefinitionName $roleDevTest -Scope $scope
New-AzRoleAssignment -ObjectId $userIdentity.PrincipalId -RoleDefinitionName $roleReader -Scope $scope
Write-Output $RunbookName