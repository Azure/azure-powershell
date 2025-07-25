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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $rstr1 = RandomString -allChars $false -len 6
    $rstr2 = RandomString -allChars $false -len 6
    $env.Add("rstr1", $rstr1)
    $env.Add("rstr2", $rstr2)
    
    # Create the test group
    write-host "creating test resource group..."
    $resourceGroup = "testgroup" + $rstr1
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $resourceGroup -Location eastus
    write-host "ResourceGroup : " $resourceGroup
   
    # Create the resource name for New-AzEmailService
    $resourceName = "acsResource" + $rstr1
    $env.Add("resourceName", $resourceName)
 
    # Create the domain resource name for New-AzEmailServiceDomain
    $domainResourceName = "acsDomainResource" + $rstr1 + ".net"
    $env.Add("domainResourceName", $domainResourceName)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName1 = "acsDomainResource1" + $rstr1 + ".net"
    $env.Add("domainResourceName1", $domainResourceName1)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName2 = "acsDomainResource2" + $rstr1 + ".net"
    $env.Add("domainResourceName2", $domainResourceName2)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName3 = "acsDomainResource3" + $rstr1 + ".net"
    $env.Add("domainResourceName3", $domainResourceName3)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName4 = "acsDomainResource4" + $rstr1 + ".net"
    $env.Add("domainResourceName4", $domainResourceName4)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName5 = "acsDomainResource5" + $rstr1 + ".net"
    $env.Add("domainResourceName5", $domainResourceName5)

    # Create the domain resource name for Invoke-AzEmailServiceInitiateDomainVerification
    $domainResourceName6 = "acsDomainResource6" + $rstr1 + ".net"
    $env.Add("domainResourceName6", $domainResourceName6)    

    # Create the domain resource name for New-AzEmailServiceSenderUsername
    $senderUsername = "acsDomainSenderUsername" + $rstr1
    $env.Add("senderUsername", $senderUsername)
    
    # Create an unused resource name for Test-AzEmailServiceNameAvailability
    $resourceNameAvailable = "acsResource" + $rstr2
    $env.Add("resourceNameAvailable", $resourceNameAvailable)
    
    # Add location values
    $dataLocation = "UnitedStates"
    $location = "Global"
    $env.Add("dataLocation", $dataLocation)
    $env.Add("location", $location)

    $domainManagement = "CustomerManaged"
    $env.Add("domainManagement", $domainManagement)

    $verificationType = "Domain"
    $env.Add("verificationType", $verificationType)

    #Add display Name
    $displayName = "TestDisplayName"
    $env.Add("displayName", $displayName)

    write-host "creating a persistent test resource..."
    # Create a persistent test resource
    $persistentResourceName = "persistentResourceName" + $rstr1
    $env.Add("persistentResourceName", $persistentResourceName)
    $persistentResource = New-AzEmailService -ResourceGroupName $resourceGroup -Name $persistentResourceName -DataLocation $dataLocation -Location $location
    
    write-host "creating a persistent test domain..."
    # Create a persistent test domain
    $persistentResourceDomainName = "persistentResourceDomainName" + $rstr1 +".net"
    $env.Add("persistentResourceDomainName", $persistentResourceDomainName)
    $persistentResourceDomain = New-AzEmailServiceDomain -ResourceGroupName $resourceGroup -EmailServiceName $persistentResourceName -Name $persistentResourceDomainName -Location $location -DomainManagement $domainManagement
    
     write-host "creating a persistent test senderusername..."
    # Create a persistent test senderusername
    $persistentResourceDomainSenderUsername = "persistentResourceDomainSenderUsername" + $rstr1
    $env.Add("persistentResourceDomainSenderUsername", $persistentResourceDomainSenderUsername)
    $persistentResourceDomainSenderusername = New-AzEmailServiceSenderUsername -SenderUsername $persistentResourceDomainSenderUsername -DomainName $persistentResourceDomainName -EmailServiceName $persistentResourceName -ResourceGroupName $resourceGroup -Username $persistentResourceDomainSenderUsername -DisplayName $displayName    

    # Add tag values
    $env.Add("exampleKey1", "ExampleKey1")
    $env.Add("exampleKey2", "ExampleKey2")
    $env.Add("exampleValue1", "ExampleValue1")
    $env.Add("exampleValue2", "ExampleValue2")

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

