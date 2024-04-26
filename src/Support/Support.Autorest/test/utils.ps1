function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.

    # Get subscription and tenant id
    $sub = (Get-AzContext).Subscription.Id
    $tenant = (Get-AzContext).Tenant.Id
    $env.AddWithCache("SubscriptionId", $sub, $UsePreviousConfigForRecord)
    $env.AddWithCache("TenantId", $tenant, $UsePreviousConfigForRecord)
    Write-Host "SubscriptionId: $($env.SubscriptionId)"
    $hasSubscription = $sub -ne $null
    $isNoSubscriptionAccount = (Get-AzContext).Account.Id -eq "bhshah@TestTest06172019GBL.onmicrosoft.com" -and $tenant -eq "2e6a0c9f-986d-480e-ad4b-bdfddc047aba"
    if(!$isNoSubscriptionAccount -and $sub -eq $null){
        Write-Host "Use account bhshah@TestTest06172019GBL.onmicrosoft.com to test no subscription scenarios. The tests will fail otherwise"
    }
    Write-Host "HasSubscription: $($env.HasSubscription)"
    if($hasSubscription){
        Write-Host "Running subscription level tests"
    }
    else{
        Write-Host "Running no subscription level tests"
    }
    
    # $env.Tenant = (Get-AzContext).Tenant.Id
    $testGuid = [guid]::NewGuid().ToString()
    $env.BillingServiceId = "517f2da6-78fd-0498-4e22-ad26996b1dfc"
    $env.BillingProblemClassificationId = "d0f16bf7-e011-3f3b-1c26-3147f84e0896"

    # File workspace names for get file tests
    $fileWorkspaceNameSubscription = "test-ps-$testGuid"
    $fileWorkspaceNameNoSubscription = "test-ps-$testGuid"

    # File workpace names for create file tests
    $fileWorkspaceNameSubscriptionForCreate = "test-for-create-ps-$testGuid"
    $fileWorkspaceNameNoSubscriptionForCreate = "test-for-create-ps-$testGuid"

    #File workspace names for check name availability tests
    $fileWorkspaceNameSubscriptionForCheckName = "test-for-check-ps-$testGuid"
    $fileWorkspaceNameNoSubscriptionForCheckName= "test-for-check-ps-$testGuid"

    $env.AddWithCache("FileWorkspaceNameSubscription", $fileWorkspaceNameSubscription, $UsePreviousConfigForRecord)
    $env.AddWithCache("FileWorkspaceNameNoSubscription", $fileWorkspaceNameNoSubscription, $UsePreviousConfigForRecord)
    $env.AddWithCache("FileWorkspaceNameSubscriptionForCreate", $fileWorkspaceNameSubscriptionForCreate, $UsePreviousConfigForRecord)
    $env.AddWithCache("FileWorkspaceNameNoSubscriptionForCreate", $fileWorkspaceNameNoSubscriptionForCreate, $UsePreviousConfigForRecord)
    $env.AddWithCache("FileWorkspaceNameSubscriptionForCheckName", $fileWorkspaceNameSubscriptionForCheckName, $UsePreviousConfigForRecord)
    $env.AddWithCache("FileWorkspaceNameNoSubscriptionForCheckName", $fileWorkspaceNameNoSubscriptionForCheckName, $UsePreviousConfigForRecord)

    # Creating and uploading file workspace and files
    $testFilePath = Join-Path $PSScriptRoot files test2.txt
    Write-Host "creating file workspaces and uploading files for tests"
    if($hasSubscription){
        New-AzSupportFileWorkspace -Name $env.FileWorkspaceNameSubscription
        New-AzSupportFileAndUpload -WorkspaceName $env.FileWorkspaceNameSubscription -FilePath $testFilePath
    }
    else{
        New-AzSupportFileWorkspacesNoSubscription -Name $env.FileWorkspaceNameNoSubscription
        New-AzSupportFileAndUploadNoSubscription -WorkspaceName $env.FileWorkspaceNameNoSubscription -FilePath $testFilePath
    }

    # Test ticket and communication information for get ticket tests
    $testTicketName = "test-$testGuid"
    $advancedDiagnosticConsent = "no"
    $contactDetailPrimaryEmailAddress = "test@test.com" 
    $contactDetailFirstName = "test" 
    $contactDetailLastName = "test" 
    $contactDetailPreferredContactMethod = "email" 
    $contactDetailPreferredTimeZone = "Pacific Standard Time" 
    $contactDetailPreferredSupportLanguage = "en-US" 
    $contactDetailCountry = "usa" 
    $description = "test ticket - please ignore and close" 
    $severity = "minimal" 
    $title = "test ticket - please ignore and close" 
    $serviceId = "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc" 
    $problemClassificationId = "/providers/Microsoft.Support/services/517f2da6-78fd-0498-4e22-ad26996b1dfc/problemClassifications/3ec1a070-f242-9ecf-5a7c-e1a88ce029ef"
    $communicationName = "test-msg-$testGuid"

    $env.AddWithCache("Name", $testTicketName, $UsePreviousConfigForRecord)
    $env.AddWithCache("AdvancedDiagnosticConsent", $advancedDiagnosticConsent, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailPrimaryEmailAddress", $contactDetailPrimaryEmailAddress, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailFirstName", $contactDetailFirstName, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailLastName", $contactDetailLastName, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailPreferredContactMethod", $contactDetailPreferredContactMethod, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailPreferredTimeZone", $contactDetailPreferredTimeZone, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailPreferredSupportLanguage", $contactDetailPreferredSupportLanguage, $UsePreviousConfigForRecord)
    $env.AddWithCache("ContactDetailCountry", $contactDetailCountry, $UsePreviousConfigForRecord)
    $env.AddWithCache("Description", $description, $UsePreviousConfigForRecord)
    $env.AddWithCache("Severity", $severity, $UsePreviousConfigForRecord)
    $env.AddWithCache("Title", $title, $UsePreviousConfigForRecord)
    $env.AddWithCache("ServiceId", $serviceId, $UsePreviousConfigForRecord)
    $env.AddWithCache("ProblemClassificationId", $problemClassificationId, $UsePreviousConfigForRecord)
    $env.AddWithCache("CommunicationName", $communicationName, $UsePreviousConfigForRecord)

    # Test ticket and communication information for create ticket tests
    $testTicketNameForCreate = "test-for-create-$testGuid"
    $communicationNameForCreate = "test-for-create-msg-$testGuid"
    $env.AddWithCache("NameForCreate", $testTicketNameForCreate, $UsePreviousConfigForRecord)
    $env.AddWithCache("CommunicationNameForCreate", $communicationNameForCreate, $UsePreviousConfigForRecord)

    # Test ticket and communication information for check name availability tests
    $testTicketNameForCheck = "test-for-check-$testGuid"
    $communicationNameForCheck = "test-for-check-msg-$testGuid"
    $env.AddWithCache("NameForCheck", $testTicketNameForCheck, $UsePreviousConfigForRecord)
    $env.AddWithCache("CommunicationNameForCheck", $communicationNameForCheck, $UsePreviousConfigForRecord)
    
    $msgSender = "sender@sender.com"
    $subject = "this is a test subject"
    $body = "this is a test body"
    
    $env.AddWithCache("Sender", $msgSender, $UsePreviousConfigForRecord)
    $env.AddWithCache("Subject", $subject, $UsePreviousConfigForRecord)
    $env.AddWithCache("Body", $body, $UsePreviousConfigForRecord)

    Write-Host "creating support ticket request and adding a message"
    if($hasSubscription){
        write-host "creating a support ticket request at subscription level"
        $supportTicketSubscription =  New-AzSupportTicket -Name $env.Name -AdvancedDiagnosticConsent $env.AdvancedDiagnosticConsent -ContactDetailCountry $env.ContactDetailCountry -ContactDetailFirstName $env.ContactDetailFirstName -ContactDetailLastName $env.ContactDetailLastName -ContactDetailPreferredContactMethod $env.ContactDetailPreferredContactMethod -ContactDetailPreferredSupportLanguage $env.ContactDetailPreferredSupportLanguage -ContactDetailPreferredTimeZone $env.ContactDetailPreferredTimeZone -ContactDetailPrimaryEmailAddress $env.ContactDetailPrimaryEmailAddress -Description $env.Description -ProblemClassificationId $env.ProblemClassificationId -ServiceId $env.ServiceId -Severity $env.Severity -Title $env.Title
        write-host "adding a message at subscription level"
        New-AzSupportCommunication -Name $env.CommunicationName -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
        $env.AddWithCache("SupportPlanSubscription", $supportTicketSubscription.SupportPlanDisplayName.ToString(), $UsePreviousConfigForRecord)
    }
    else{
        write-host "creating a support ticket request at tenant level"
        $supportTicketTenant = New-AzSupportTicketsNoSubscription -SupportTicketName $env.Name -AdvancedDiagnosticConsent $env.AdvancedDiagnosticConsent -ContactDetailCountry $env.ContactDetailCountry -ContactDetailFirstName $env.ContactDetailFirstName -ContactDetailLastName $env.ContactDetailLastName -ContactDetailPreferredContactMethod $env.ContactDetailPreferredContactMethod -ContactDetailPreferredSupportLanguage $env.ContactDetailPreferredSupportLanguage -ContactDetailPreferredTimeZone $env.ContactDetailPreferredTimeZone -ContactDetailPrimaryEmailAddress $env.ContactDetailPrimaryEmailAddress -Description $env.Description -ProblemClassificationId $env.ProblemClassificationId -ServiceId $env.ServiceId -Severity $env.Severity -Title $env.Title
        write-host "adding a message at tenant level"
        New-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
        $env.AddWithCache("SupportPlanTenant", $supportTicketTenant.SupportPlanDisplayName.ToString(), $UsePreviousConfigForRecord)   
    }
    
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

