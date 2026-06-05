if(($null -eq $TestName) -or ($TestName -contains 'Test-AzPostgreSqlFlexibleServerNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzPostgreSqlFlexibleServerNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzPostgreSqlFlexibleServerNameAvailability' {
    BeforeAll {
        $existingServerName = $env.ServerName
        if ([string]::IsNullOrWhiteSpace($existingServerName)) {
            $existingServerName = $env.ServerName1
        }

        $invalidNameMessage = "Specified server name contains unsupported characters or is too long. Server name must be no longer than 63 characters long, contain only lower-case characters or digits, cannot contain '.' or '_' characters and can't start or end with '-' character."
        $alreadyExistsMessage = 'Specified server name is already used.'
    }

    It 'CheckExpandedShouldReturnInvalidForWrongCharacters' {
        $result = Test-AzPostgreSqlFlexibleServerNameAvailability `
            -LocationName $env.mainLocation `
            -Name 'wrong-~server'

        $result.NameAvailable | Should -Be $false
        $result.Reason | Should -Be 'Invalid'
        $result.Message | Should -Be $invalidNameMessage
    }

    It 'CheckExpandedShouldReturnAvailableForRandom63CharName' {
        $chars = 'abcdefghijklmnopqrstuvwxyz0123456789'.ToCharArray()
        $availableServerName = -join (1..63 | ForEach-Object { $chars[(Get-Random -Minimum 0 -Maximum $chars.Length)] })

        $result = Test-AzPostgreSqlFlexibleServerNameAvailability `
            -LocationName $env.mainLocation `
            -Name $availableServerName

        $result.NameAvailable | Should -Be $true
        [string]::IsNullOrEmpty($result.Reason) | Should -Be $true
        [string]::IsNullOrEmpty($result.Message) | Should -Be $true
    }

    It 'CheckShouldReturnAlreadyExistsForExistingServerName' -Skip:([string]::IsNullOrWhiteSpace($existingServerName)) {
        $result = Test-AzPostgreSqlFlexibleServerNameAvailability `
            -LocationName $env.mainLocation `
            -Name $existingServerName

        $result.NameAvailable | Should -Be $false
        $result.Reason | Should -Be 'AlreadyExists'
        $result.Message | Should -Be $alreadyExistsMessage
    }
}
