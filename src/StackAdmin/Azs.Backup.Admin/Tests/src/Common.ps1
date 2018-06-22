
$global:SkippedTests = @(
    'TestCreateBackup',
    'TestRestoreBackup'
)

$global:Location = "local"
$global:Provider = "Microsoft.Backup.Admin"
$global:ResourceGroupName = "System.local"
$global:username = "azurestack\AzureStackAdmin"
[SecureString]$global:password = ConvertTo-SecureString -String "password" -AsPlainText -Force
$global:path = "\\su1fileserver\SU1_Infrastructure_2\BackupStore"
[SecureString]$global:encryptionKey = ConvertTo-SecureString -String "YVVOa0J3S2xTamhHZ1lyRU9wQ1pKQ0xWanhjaHlkaU5ZQnNDeHRPTGFQenJKdWZsRGtYT25oYmlaa1RMVWFKeQ==" -AsPlainText -Force
$global:isBackupSchedulerEnabled = $false
$global:backupFrequencyInHours = 10
$global:backupRetentionPeriodInDays = 6

if (-not $global:RunRaw) {
    $scriptBlock = {
        Get-MockClient -ClassName 'BackupAdminClient' -TestName $global:TestName -Verbose
    }
    Mock New-ServiceClient $scriptBlock -ModuleName $global:ModuleName
}

# Extracts the name needed for parameters
function Select-Name {
    param($Name)
    if ($name.contains("/")) {
        $Name = $Name.Substring($Name.LastIndexOf("/") + 1)
    }
    $Name
}

if (Test-Path "$PSScriptRoot\Override.ps1") {
    . $PSScriptRoot\Override.ps1
}
