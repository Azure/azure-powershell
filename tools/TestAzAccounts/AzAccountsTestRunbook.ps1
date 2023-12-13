Param(
    [Parameter(Mandatory = $true)]
    [string]
    $ResourceGroupName,
    
    [Parameter(Mandatory = $true)]
    [string]
    $UserManagedIdentity,

    [Parameter(Mandatory = $true)]
    [string]
    $AutomationAccount,
    
    [Parameter(Mandatory = $true)]
    [string]
    $Method
)

Write-Output (Get-ChildItem -Path 'Env:')
Write-Output $PSVersionTable

# Ensures you do not inherit an AzContext in your runbook
Disable-AzContextAutosave -Scope Process | Out-Null

# Connect using a Managed Service Identity
try
{
    $AzureContext = (Connect-AzAccount -Identity).Context
}
catch
{
    Write-Output 'There is no system-assigned user identity. Aborting.'
    exit
}

# set and store context
$AzureContext = Set-AzContext -SubscriptionName $AzureContext.Subscription -DefaultProfile $AzureContext
Write-Output "Account ID of current context: $($AzureContext.Account.Id)"

if ($Method -eq 'SA')
{
    Write-Output 'Using system-assigned managed identity'
}
elseif ($Method -eq 'UA')
{
    Write-Output 'Using user-assigned managed identity'

    # Connects using the Managed Service Identity of the named user-assigned managed identity
    $identity = Get-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $UserManagedIdentity -DefaultProfile $AzureContext

    # validates assignment only, not perms
    $autoAccount = Get-AzAutomationAccount -ResourceGroupName $ResourceGroupName -Name $AutomationAccount -DefaultProfile $AzureContext
    if ($autoAccount.Identity.UserAssignedIdentities.Length -gt 0 -and $autoAccount.Identity.UserAssignedIdentities.Values.PrincipalId.Contains($identity.PrincipalId))
    {
        $AzureContext = (Connect-AzAccount -Identity -AccountId $identity.ClientId).context

        # set and store context
        $AzureContext = Set-AzContext -SubscriptionName $AzureContext.Subscription -DefaultProfile $AzureContext
    }
    else
    {
        Write-Output 'Invalid or unassigned user-assigned managed identity'
        exit
    }
}
else 
{
    Write-Output 'Invalid method. Choose UA or SA.'
    exit
}

Write-Output "Account ID of current context: $($AzureContext.Account.Id)"

Write-Output (Get-AzAccessToken)
Write-Output (Get-AzResource -ResourceGroupName $ResourceGroupName)