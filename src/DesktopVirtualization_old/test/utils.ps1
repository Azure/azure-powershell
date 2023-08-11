function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function setupEnv() {
    $env = @{}
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    #---------- Self Contained Resources ----------
    # The following resources are created and removed within each test.
    $envFile = 'env.json'
    $null = $env.Add("ResourceGroup", "alecbUserSessionTests")
    $null = $env.Add("Location", "westus2")
    $null = $env.Add("HostPool", "HostPoolPowershellContained1")
    $null = $env.Add("HostPool2", "HostPoolPowershellContained2")
    $null = $env.Add("RemoteApplicationGroup", "ApplicationGroupPowershell2")
    $null = $env.Add("DesktopApplicationGroup", "ApplicationGroupPowershell1")
    $null = $env.Add("MSIXImagePath", "C:\AppAttach\Firefox20110.0.1.vhdx")

    #auto-set based on the values above, do not edit
    $null = $env.Add("HostPoolArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool)
    $null = $env.Add("HostPoolArmPath2", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPool2)
    $null = $env.Add("DesktopApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.DesktopApplicationGroup)
    $null = $env.Add("RemoteApplicationGroupPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroup + "/providers/Microsoft.DesktopVirtualization/applicationgroups/" + $env.RemoteApplicationGroup)
    
    #---------- Persistent Resources ----------
    # The following resources are manually created and removed by the operator.
    $null = $env.Add("ResourceGroupPersistent", "alecbUserSessionTests")
    $null = $env.Add("HostPoolPersistent", "alecbUserSessionHP")
    $null = $env.Add("HostPoolPersistent2", "alecbRemoteAppHP")
    $null = $env.Add("HostPoolPersistentArmPath", "/subscriptions/"+ $env.SubscriptionId + "/resourcegroups/"+ $env.ResourceGroupPersistent + "/providers/Microsoft.DesktopVirtualization/hostpools/"+ $env.HostPoolPersistent)
    $null = $env.Add("SessionHostName", "pwsh-0")
    $null = $env.Add("SessionHostNameRemove", "userSess-sh-2")
    $null = $env.Add("PersistentDesktopAppGroup", "alecbUserSessionHP-DAG")
    $null = $env.Add("PersistentRemoteAppGroup", "alecbRemoteAppHP-RAG")
    # The context in which the tests are run will change the tenant and subscription ID when -record is run. 
    # Currently the scaling tests need to be run in a context with @microsoft, while the other tests are run with a test account
    # Modify the env.json manually after recording the necessary tests to get around this issue.

    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

