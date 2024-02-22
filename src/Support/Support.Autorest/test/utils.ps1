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
    $env.SubscriptionId = $sub = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $testGuid = [guid]::NewGuid().ToString()
    $env.BillingServiceId = "517f2da6-78fd-0498-4e22-ad26996b1dfc"
    $env.BillingProblemClassificationId = "d0f16bf7-e011-3f3b-1c26-3147f84e0896"
    $env.FileWorkspaceNameSubscription = "test-ps-$(New-Guid)"
    $env.FileWorkspaceNameNoSubscription = "test-ps-$(New-Guid)"

    New-AzSupportFileWorkspace -Name $env.FileWorkspaceNameSubscription
    New-AzSupportFileWorkspacesNoSubscription -Name $env.FileWorkspaceNameNoSubscription

    $testFilePath = Join-Path $PSScriptRoot files test2.txt
    New-AzSupportFileAndUpload -WorkspaceName $env.FileWorkspaceNameSubscription -FilePath $testFilePath
    New-AzSupportFileAndUploadNoSubscription -WorkspaceName $env.FileWorkspaceNameNoSubscription -FilePath $testFilePath

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
    write-host "creating test ticket"
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

    $testTicketName1 = "test1-$testGuid"
    $communicationName = "test-msg-$testGuid"
    $communicationName1 = "test1-msg-$testGuid"
    $msgSender = "sender@sender.com"
    $subject = "this is a test subject"
    $body = "this is a test body"

    write-host "creating test message"
    $env.AddWithCache("Name1", $testTicketName1, $UsePreviousConfigForRecord)
    $env.AddWithCache("CommunicationName", $communicationName, $UsePreviousConfigForRecord)
    $env.AddWithCache("CommunicationName1", $communicationName1, $UsePreviousConfigForRecord)
    $env.AddWithCache("Sender", $msgSender, $UsePreviousConfigForRecord)
    $env.AddWithCache("Subject", $subject, $UsePreviousConfigForRecord)
    $env.AddWithCache("Body", $body, $UsePreviousConfigForRecord)

    write-host "creating a support ticket request at subscription level"
    $supportTicketSubscription =  New-AzSupportTicket -Name $env.Name -AdvancedDiagnosticConsent $env.AdvancedDiagnosticConsent -ContactDetailCountry $env.ContactDetailCountry -ContactDetailFirstName $env.ContactDetailFirstName -ContactDetailLastName $env.ContactDetailLastName -ContactDetailPreferredContactMethod $env.ContactDetailPreferredContactMethod -ContactDetailPreferredSupportLanguage $env.ContactDetailPreferredSupportLanguage -ContactDetailPreferredTimeZone $env.ContactDetailPreferredTimeZone -ContactDetailPrimaryEmailAddress $env.ContactDetailPrimaryEmailAddress -Description $env.Description -ProblemClassificationId $env.ProblemClassificationId -ServiceId $env.ServiceId -Severity $env.Severity -Title $env.Title
    
    write-host "adding a message at subscription level"
    if($supportTicketSubscription.SupportPlanDisplayName -eq "Basic support" || $supportTicket.SupportPlanDisplayName -eq "Free"){
        write-host "cannot create, update support tickets and add communication operations for tickets with free support plan"
    }
    else{
    New-AzSupportCommunication -Name $env.CommunicationName -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
    }
    write-host "creating a support ticket request at tenant level"
    $supportTicketTenant = New-AzSupportTicketsNoSubscription -SupportTicketName $env.Name -AdvancedDiagnosticConsent $env.AdvancedDiagnosticConsent -ContactDetailCountry $env.ContactDetailCountry -ContactDetailFirstName $env.ContactDetailFirstName -ContactDetailLastName $env.ContactDetailLastName -ContactDetailPreferredContactMethod $env.ContactDetailPreferredContactMethod -ContactDetailPreferredSupportLanguage $env.ContactDetailPreferredSupportLanguage -ContactDetailPreferredTimeZone $env.ContactDetailPreferredTimeZone -ContactDetailPrimaryEmailAddress $env.ContactDetailPrimaryEmailAddress -Description $env.Description -ProblemClassificationId $env.ProblemClassificationId -ServiceId $env.ServiceId -Severity $env.Severity -Title $env.Title
    
    write-host "adding a message at tenant level"
    if($supportTicketTenant.SupportPlanDisplayName -eq "Basic support" || $supportTicket.SupportPlanDisplayName -eq "Free"){
        write-host "cannot create, update support tickets and add communication operations for tickets with free support plan"
    }
    else{
        New-AzSupportCommunicationsNoSubscription -CommunicationName $env.CommunicationName -SupportTicketName $env.Name -Body $env.Body -Sender $env.Sender -Subject $env.Subject
    }

    $env.AddWithCache("SupportPlanSubscription", $supportTicketSubscription.SupportPlanDisplayName.ToString(), $UsePreviousConfigForRecord)
    $env.AddWithCache("SupportPlanTenant", $supportTicketTenant.SupportPlanDisplayName.ToString(), $UsePreviousConfigForRecord)   
    
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

