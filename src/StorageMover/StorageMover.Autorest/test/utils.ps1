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
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $env.RandomString = (RandomString $false 8)
    $env.ResourceGroupName = "choudharysutest"
    $env.StorageMoverNameWithAgent = "testmoverpreview1"
    $env.AgentName = "testagent12"
    $env.Location = "eastus2euap"
    $env.InitialStoMoverName = "testStoMover1" + $env.RandomString
    $env.InitialSMDescription = "initial test SM description"
    $env.InitialStoMoverTag = @{"tag1" = "value1"; "tag2" = "value2"}

    #Create Resource Group Name: teststoragemover Location: eastus2 Tag: @{"DateCreated" = "$(Get-Date -Format 'yyyy-MM-dd')"}
    #Create Storage Mover with name: testmoverpreview1, agent name: testagent12, resource group: teststoragemover, location: eastus2
    
    $stomover1 = New-AzStorageMover -ResourceGroupName $env.ResourceGroupName -Name $env.InitialStoMoverName -Location $env.Location -Description $env.InitialSMDescription -Tag $env.InitialStoMoverTag

    # Initialize a Storage account and a Blob container
    $env.StorageAccountName = "storacc" + $env.RandomString
    $env.ContainerName = "container" + $env.RandomString

    $storacc = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $env.StorageAccountName -SkuName Standard_LRS -Location $env.Location -AllowBlobPublicAccess $false -AllowSharedKeyAccess $false -RequireInfrastructureEncryption -EnableHttpsTrafficOnly $true -MinimumTlsVersion TLS1_2
    $env.StoraccId = $storacc.Id
    # Create storage context using Azure AD authentication instead of keys
    $storageContext = New-AzStorageContext -StorageAccountName $env.StorageAccountName `
        -UseConnectedAccount
    
    # Ensure current user has Storage Blob Data Contributor role
    $currentUserId = (Get-AzContext).Account.Id
    $roleAssignment = Get-AzRoleAssignment -SignInName $currentUserId `
        -RoleDefinitionName "Storage Blob Data Contributor" `
        -Scope $storacc.Id -ErrorAction SilentlyContinue
    
    if (-not $roleAssignment) {
        Write-Host "Assigning Storage Blob Data Contributor role..." -ForegroundColor Yellow
        New-AzRoleAssignment -SignInName $currentUserId `
            -RoleDefinitionName "Storage Blob Data Contributor" `
            -Scope $storacc.Id
        
        # Wait for role assignment to propagate
        Start-TestSleep -Seconds 30
    }
    
    $container = New-AzStorageContainer -Name $env.ContainerName -Context $storageContext

    $env.ContainerEndpointName = "containerEndpoint" + $env.RandomString
    $env.NfsEndpointName = "nfsEndpoint" + $env.RandomString
    $containerEndpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $env.ContainerEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -BlobContainerName $env.ContainerName -StorageAccountResourceId $env.StoraccId
    $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $env.NfsEndpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Host "10.0.0.1" -Export "/"

    $env.ProjectName = "testProject" + $env.RandomString
    $env.ProjectName2 = "testProject2" + $env.RandomString
    $project1 = New-AzStorageMoverProject -Name $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
    $project2 = New-AzStorageMoverProject -Name $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent

    $env.JobDefinitionName = "testJob" + $env.RandomString
    $jobDefinition = New-AzStorageMoverJobDefinition -Name $env.JobDefinitionName -ProjectName $env.ProjectName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -AgentName $env.AgentName -CopyMode "Additive" -SourceName $env.NfsEndpointName -TargetName $env.ContainerEndpointName

    $env.MultiCloudConnectorId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/E2E-Management-RGsyn/providers/Microsoft.HybridConnectivity/publicCloudConnectors/e2e-sm-rp-connector"
    $env.AwsS3BucketId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/aws_640698235822/providers/Microsoft.AWSConnector/s3Buckets/e2e-sm-rp-bucket"
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    # Remove-AzResourceGroup -Name $env.ResourceGroupName
}

