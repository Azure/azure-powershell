Import-Module -Name AzureRM.Bootstrapper
$RollupModule = 'AzureRM'

function Remove-InstalledProfile { 
    $installedProfiles = Get-AzureRmProfile
    if ($installedProfiles -ne $null)
    {
        foreach ($profile in $installedProfiles)
        {
            Write-Host "Removing profile $profile"
            Uninstall-AzureRmProfile -Profile $profile -Force -ErrorAction Stop
        }
    }
}

Describe "A machine with no profile installed can install profile" {
    # Using Install-AzureRmProfile
    Context "New Profile Install - Latest" {
        # Launch the test in a new powershell session
        # Arrange
        # Uninstall previously installed profiles
        Remove-InstalledProfile       

        # Create a new PS session
        $session = New-PSSession

        # Act
        # Install latest version
        Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile 'Latest' } 

        # Assert 
        It "Should return Latest Profile" {
            Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } | Should Be 'Latest'
        }

        # Clean up
        Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'Latest' -Force }
        Remove-PSSession -Session $session
    } 

    # Using Use-AzureRmProfile
    Context "New Profile Install - 2016-09" {
        # Arrange
        # Uninstall previously installed profiles
        Remove-InstalledProfile

        # Create a new PS session
        $session = New-PSSession

        # Act
        # Install profile '2016-09'
        Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile '2016-09' -Force }

        # Assert
        It "Should return 2016-09" {
            Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } | Should Be '2016-09'
        }

        # Clean up
        # Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile '2016-09' -Force -ea SilentlyContinue }
        Remove-PSSession -Session $session
    }

}

Describe "Add: A Machine with a Profile installed can install latest profile" {
    Context "Profile 2016-09 already installed" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Ensure 2016-09 is installed
        $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
        $profilesInstalled | Should Be '2016-09'

        # Act
        # Install profile 'Latest'
        Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }
        $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }

        # Assert
        It "Should return 2016-09 & Latest" {
            $result.Length | Should Be 2
            $result.Contains('2016-09') | Should Be $true 
            $result.Contains('Latest') | Should Be $true
        }

        # Clean up
        Remove-PSSession -Session $session
    }
}

Describe "Attempting to use already installed profile will import the modules to the current session" {
    Context "Profile Latest is installed" {
        # Should import Latest profile to current session
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Ensure profile Latest is installed
        $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
        $profilesInstalled.Contains('Latest') | Should Be $true

        # Act
        Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' }
        $result = Invoke-Command -Session $session -ScriptBlock { Get-Module -FullyQualifiedName 'AzureRm' }

        # Get the version of the Latest profile
        $ProfileMap = Get-AzProfile
        $latestVersion = $ProfileMap.'Latest'.$RollupModule

        # Assert
        It "Should return AzureRm module Latest version" {
            $result.Name | Should Be $RollupModule
            $result.version | Should Be $latestVersion
        }

        # Cleanup
        Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'Latest' -Force -ea SilentlyContinue }
        Remove-PSSession -Session $session
    }
}

Describe "User can update their machine to a latest profile" {
    Context "Profile 2016-09 is installed" {
        # Should refresh profile map from Azure end point and update modules.
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Check if '2016-09' is installed
        $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
        $profilesInstalled | Should Be '2016-09'

        # Act
        Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -Update }
        Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }
        $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
        $modules = Invoke-Command -Session $session -ScriptBlock { Get-Module -FullyQualifiedName 'AzureRm' }

        # Assert
        It "Should return 2016-09 & Latest" {
            $result.Length | Should Be 2
            $result.Contains('2016-09') | Should Be $true 
            $result.Contains('Latest') | Should Be $true
        }

        It "Latest version of modules are imported" {
            # Get the version of the Latest profile
            $ProfileMap = Get-AzProfile
            $latestVersion = $ProfileMap.'Latest'.$RollupModule
            
            # Are latest modules imported?
            $modules.Name | Should Be $RollupModule
            $modules.version | Should Be $latestVersion
        }

        It "Last Write Time should be less than 5 minutes" {
            # Get LastWriteTime for ProfileMap
            $lastWriteTime = (Get-Item -Path (Join-Path $Env:LocalAppData -ChildPath 'Microsoft\AzurePowerShell\ProfileCache\ProfileMap.json')).LastWriteTime
            (((Get-Date) - $lastWriteTime).TotalMinutes -lt 5) | Should Be $true
        }

        # Cleanup
        Remove-PSSession -Session $session
    }
}

Describe "User can uninstall a profile" {
    Context "Latest profile is installed" {
        # Should uninstall latest profile
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Check if 'Latest' is installed
        $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
        $profilesInstalled.Contains('Latest') | Should Be $true

        # Act
        Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'Latest' -Force }
        $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
        
        # Assert
        It "Profile Latest is uninstalled" {
            $result.Contains('Latest') | Should Be $false
        }

        # Cleanup
        Remove-PSSession -Session $session
    }
}

Describe "Invalid Cases" {
    Context "Install wrong profile name" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Act & Assert
        # Install profile 'abcTest'
        It "Throws Invalid argument error" {
            Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile 'abcTest' } | Should Throw
        }

        # Cleanup
        Remove-PSSession -Session $session
    }

    Context "Install null profile name" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Act & Assert
        # Install profile 'null'
        It "Throws Invalid argument error" {
            Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile $null } | Should Throw
        }

        # Cleanup
        Remove-PSSession -Session $session
    }

    Context "Install already installed profile" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Ensure profile 2016-09 is installed
        $installedProfile = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
        $installedProfile.contains('2016-09') | Should Be $true

        # Act
        # Install profile '2016-09'
        $result = Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile '2016-09' } 

        # Get modules imported into the session
        $modules = Invoke-Command -Session $session -ScriptBlock { Get-Module -FullyQualifiedName 'AzureRm' }

        It "Doesn't install/import the profile" {
            $result | Should Be $null
            $modules | Should Be $null
        }

        # Cleanup
        Remove-PSSession -Session $session
    }

    Context "Uninstall not installed profile" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Ensure profile 2015-05 is not installed
        $installedProfile = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
        $installedProfile.contains('2015-05') | Should Be $false

        # Act
        # Uninstall profile '2015-05'
        $result = Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile '2015-05'} 

        It "Doesn't uninstall/throw" {
            $result | Should Be $null
        }

        # Cleanup
        Remove-PSSession -Session $session
    }

    Context "Use-AzureRmProfile with wrong profile name" {
        # Arrange
        # Create a new PS session
        $session = New-PSSession

        # Act
        # Install profile 'abcTest'
        It "Throws Invalid argument error" {
            Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'abcTest' } | Should Throw
        }

        # Cleanup
        Remove-PSSession -Session $session
    }
}

Describe "Failure Recovery: Attempt to install profile recovers from error" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Azure ProfileMap endpoint threw exception" {
            # Arrange
            # Mock Get-ProfileMap returns error
            Mock Get-AzureProfileMap -Verifiable { throw [System.Net.WebException] }
        
            # Mock Install-Modules returns error
            Mock Install-Module -Verifiable { throw }

            # Act & Assert
            It "Should not download/install the latest profile" {
                { Get-AzureRmProfile -Update } | Should Throw
                { Install-AzureRmProfile -Profile 'Latest' } | Should Throw
            }

            It "Last Write time should not be less than 5 mins" {
                # Get LastWriteTime for ProfileMap
                $lastWriteTime = (Get-Item -Path (Join-Path $Env:LocalAppData -ChildPath 'Microsoft\AzurePowerShell\ProfileCache\ProfileMap.json')).LastWriteTime
                (((Get-Date) - $lastWriteTime).TotalMinutes -gt 5) | Should Be $true
                Assert-VerifiableMocks
            }
        }

        Context "Retry install after ProfileMap update" {
            # Arrange
            # Create a new PS session
            $session = New-PSSession

            # Act
            # Update ProfileMap
            Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -Update }

            # Install profile 'Latest'
            Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force } 

            # Assert
            It "Installs & Imports Latest profile to the session" {
                $modules = Invoke-Command -Session $session -ScriptBlock { Get-Module -FullyQualifiedName 'AzureRm' }
                # Get the version of the Latest profile
                $ProfileMap = Get-AzProfile
                $latestVersion = $ProfileMap.'Latest'.$RollupModule
            
                # Are latest modules imported?
                $modules.Name | Should Be $RollupModule
                $modules.version | Should Be $latestVersion
            }

            It "Last Write time should be less than 5 mins" {
                # Get LastWriteTime for ProfileMap
                $lastWriteTime = (Get-Item -Path (Join-Path $Env:LocalAppData -ChildPath 'Microsoft\AzurePowerShell\ProfileCache\ProfileMap.json')).LastWriteTime
                (((Get-Date) - $lastWriteTime).TotalMinutes -lt 5) | Should Be $true
            }

            # Cleanup
            Remove-PSSession -Session $session
        }
    }
}
