Import-Module -Name AzureRM.Bootstrapper
$RollupModule = 'AzureRM'
InModuleScope AzureRM.Bootstrapper {
    $ProfileMap = (Get-AzProfile)
    $ProfileCachePath = Get-ProfileCachePath

    # Helper function to uninstall all profiles
    function Remove-InstalledProfile {
        $installedProfiles = Get-ProfilesInstalled -ProfileMap $ProfileMap
        if ($installedProfiles.Keys -ne $null)
        {
            foreach ($profile in $installedProfiles.Keys)
            {
                Write-Host "Removing profile $profile"
                Uninstall-AzureRmProfile -Profile $profile -Force -ErrorAction SilentlyContinue
            }
            
            $profiles = (Get-ProfilesInstalled -ProfileMap $ProfileMap)
            if ($profiles.Count -ne 0)
            {
                Throw "Uninstallation was not successful: Profile(s) $(@($profiles.Keys) -join ',') were not uninstalled correctly."
            }
        }
    }

    Describe "A machine with no profile installed can install profile" {

        # Using Install-AzureRmProfile
        Context "New Profile Install - Latest" {
            # Arrange
            # Uninstall previously installed profiles
            Remove-InstalledProfile       

            # Launch the test in a new powershell session
            # Create a new PS session
            $session = New-PSSession

            # Act
            # Install latest version
            Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile 'Latest' -Force } 

            # Assert 
            It "Should return Latest Profile" {
                $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                $result[0].Contains('Latest') | Should Be $true
            }

            # Clean up
            Remove-PSSession -Session $session
        } 

        # Using Use-AzureRmProfile
        Context "New Profile Install - 2016-04-consistent" {
            # Arrange
            # Uninstall previously installed profiles
            Remove-InstalledProfile

            # Create a new PS session
            $session = New-PSSession

            # Act
            # Install profile '2016-04-consistent'
            Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile '2016-04-consistent' -Force }

            # Assert
            It "Should return 2016-04-consistent" {
                $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                $result[0].Contains('2016-04-consistent') | Should Be $true
            }

            # Clean up
            Remove-PSSession -Session $session
        }
    }

    Describe "Add: A Machine with a Profile installed can install latest profile" {
        InModuleScope AzureRM.Bootstrapper {

            Context "Profile 2016-04-consistent already installed" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Ensure 2016-09-consistent is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                $profilesInstalled[0].Contains('2016-04-consistent') | Should Be $true

                # Act
                # Install profile 'Latest'
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }
                $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }

                # Assert
                It "Should return 2016-09-consistent & Latest" {
                    ($result -like "*latest*") -ne $null | Should Be $true 
                    ($result -like "*2016-04-consistent*") -ne $null | Should Be $true
                }

                # Clean up
                Remove-PSSession -Session $session
            }
        }
    }

    Describe "Attempting to use already installed profile will import the modules to the current session" {
        InModuleScope AzureRM.Bootstrapper {
            Context "Profile Latest is installed" {
                # Should import Latest profile to current session
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Ensure profile Latest is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*latest*") -ne $null | Should Be $true

                # Act
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }

                # Get the version of the Latest profile
                $ProfileMap = Get-AzProfile
                $latestVersion = $ProfileMap.'Latest'.$RollupModule

                # Assert
                It "Should return AzureRm module Latest version" {
                    # Get-module script block
                    $getModule = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule 
                    }

                    $modules = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $latestVersion
                }

                # Cleanup
                Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'Latest' -Force -ea SilentlyContinue }
                Remove-PSSession -Session $session
            }
        }
    }

    Describe "User can update their machine to a latest profile" {
        InModuleScope AzureRM.Bootstrapper {
            # Using Use-AzureRmProfile
            Context "Profile 2016-09-consistent is installed: Use-AzureRmProfile" {
                # Should refresh profile map from Azure end point and update modules.
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Check if '2016-04-consistent' is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*2016-04-consistent*") -ne $null | Should Be $true

                # Remove latest profile map from cache for testing if it updates from online.
                $latestMap = Get-LatestProfileMapPath
                if (($latestMap -ne $null) -and (Test-Path $latestMap.FullName))
                {
                    Remove-Item -Path $latestMap.FullName -Force
                }
                
                # Act
                Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -Update }
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }
        
                # Assert
                It "Should return 2016-04-consistent & Latest" {
                    $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
                    ($result -like "*latest*") -ne $null | Should Be $true 
                    ($result -like "*2016-04-consistent*") -ne $null | Should Be $true
                }

                It "Latest version of modules are imported" {
                    # Get the version of the Latest profile
                    $ProfileMap = Get-AzProfile
                    $latestVersion = $ProfileMap.'Latest'.$RollupModule
                
                    # Get-module script block
                    $getModule = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule 
                    }

                    $modules = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                
                    # Are latest modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $latestVersion
                }
            
                It "Last Write Time should be less than 5 minutes" {
                    # Get LastWriteTime for ProfileMap
                    $lastWriteTime = (Get-Item -Path (Get-LatestProfileMapPath).FullName).LastWriteTime
                    (((Get-Date) - $lastWriteTime).TotalMinutes -lt 5) | Should Be $true
                }

                # Cleanup
                Remove-PSSession -Session $session
            }
        
            # Using Update-AzureRmProfile; Previous Versions do not exist
            Context "Profile 2016-04-consistent is installed: Update-AzureRmProfile" {
                # Arrange
                # Remove existing profiles
                Remove-InstalledProfile

                # Create a new PS session
                $session = New-PSSession

                # Install profile 2016-04-consistent
                Install-AzureRmProfile -Profile '2016-04-consistent' -Force

                # Ensure profile 2016-04-consistent is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*2016-04-consistent*") -ne $null | Should Be $true

                # Act
                # Update to profile 'Latest'
                Invoke-Command -Session $session -ScriptBlock { Update-AzureRmProfile -Profile 'Latest' -Force -RemovePreviousVersions }

                # Assert
                # Returns 2016-04-consistent & Latest
                It "Should Return 2016-04-consistent & Latest" {
                    $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
                    ($result -like "*latest*") -ne $null | Should Be $true 
                    ($result -like "*2016-04-consistent*") -ne $null | Should Be $true
                }

                It "Latest version of modules are imported" {
                    # Get the version of the Latest profile
                    $ProfileMap = Get-AzProfile
                    $latestVersion = $ProfileMap.'Latest'.$RollupModule
                
                    # Get-module script block
                    $getModule = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule 
                    }

                    $modules = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                
                    # Are latest modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $latestVersion
                }

                Remove-PSSession -Session $session
            }
            
            # Using Update-AzureRmProfile; Previous Versions exist
            Context "Profile 2016-04-consistent is installed: Update-AzureRmProfile with PreviousVerisons" {
                # Arrange
                # Remove existing profiles
                Remove-InstalledProfile
    
                # Create a new PS session
                $session = New-PSSession

                # Install profile 2016-04-consistent
                Install-AzureRmProfile -Profile '2016-04-consistent' -Force

                # Ensure profile 2016-04-consistent is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*2016-04-consistent*") -ne $null | Should Be $true

                # Remove latest profile map from cache for testing if it updates from online.
                $latestMap = Get-LatestProfileMapPath
                if (($latestMap -ne $null) -and (Test-Path $latestMap.FullName))
                {
                    Remove-Item -Path $latestMap.FullName -Force
                }

                # Add a version of old profilemap with older versions of 'latest' profile to cache
                $testProfileMap = "{`"Latest`": { `"AzureRM`": [`"3.3.0`"], `"Azure.Storage`": [`"2.4.0`"] }}" 
                $testProfileMap | Out-File -FilePath "$ProfileCachePath\TestMap.json" -Force

                # Install the modules from that profilemap
                $testProfileMap = ($testProfileMap | ConvertFrom-Json)
                
                foreach ($Module in ($testProfileMap.'Latest' | Get-Member -MemberType NoteProperty).Name)
                {
                    $oldVersion = $testProfileMap.'Latest'.$Module
                    Install-Module $Module -RequiredVersion $oldVersion[0] -ErrorAction Stop -AllowClobber
                }

                # Act
                # Invoke Update-AzureRmProfile 'latest' with -RemovePreviousVersions
                Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -update }
                Invoke-Command -Session $session -ScriptBlock { Update-AzureRmProfile -Profile 'Latest' -Force -RemovePreviousVersions }

                # Assert
                # Check if new versions of 'latest' are installed
                $latestVersion = $ProfileMap.'Latest'.$RollupModule

                It "Should return latest module versions" {
                    # Get-module script block
                    $getModule = {
                        Param($RollupModule)
                        Get-AzureRmModule -Profile 'Latest' -Module $RollupModule 
                    }
                
                    $version = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                    $version | Should Be $latestVersion
                }

                # Check if old versions of 'latest' are uninstalled
                It "Should return null for old versions" {
                    # Get-module script block
                    $getModule = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule -ListAvailable
                    }

                    $modules = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                    foreach ($module in $modules)
                    {
                        $module.Version -eq $oldVersion | Should Be $false
                    }
                }

                # Check if the old profilemap was removed
                It "Should return false for old profile map in cache" {
                    (Test-Path "$ProfileCachePath\TestMap.json") | Should Be $false
                }
            }
        }
    }

    Describe "User can uninstall a profile" {
        InModuleScope AzureRM.Bootstrapper {
            Context "Latest profile is installed" {
                # Should uninstall latest profile
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Check if 'Latest' is installed
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*latest*") -ne $null | Should Be $true

                # Get the version of the Latest profile
                $ProfileMap = Get-AzProfile
                $latestVersion = $ProfileMap.'Latest'.$RollupModule

                # Act
                Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'Latest' -Force }
            
                # Assert
                It "Profile Latest is uninstalled" {
                    $result = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
                    if($result -ne $null)
                    {
                        $result.Contains('Latest') | Should Be $false
                    }
                    else {
                        $true
                    }
                }

                It "Available Modules should not contain uninstalled modules" {
                    $getModule = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule -ListAvailable
                    }
                    $results = Invoke-Command -Session $session -ScriptBlock $getModule -ArgumentList $RollupModule
                    
                    # Result won't be null because profile 2016-04-consistent is installed.
                    foreach ($result in $results)
                    {
                        $result.Version -eq $latestVersion | Should Be $false
                    }
                        
                }

                # Cleanup
                Remove-PSSession -Session $session
            }
        }
    }

    Describe "Install Two named profiles and selecting each" {
        InModuleScope AzureRM.Bootstrapper {
            # Get the version of the respective profile
            $ProfileMap = Get-AzProfile
            $Version1 = $ProfileMap.'Latest'.$RollupModule
            $Version2 = $ProfileMap.'2016-04-consistent'.$RollupModule

            Context "Install Two Profiles" {
                # Arrange
                # Remove all profiles
                Remove-InstalledProfile

                # Create a new PS session
                $session = New-PSSession

                # Act
                # Install Profile: 2016-08 
                Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile 'Latest' -Force } 

                # Install Profile: 2016-04
                Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile '2016-04-consistent' -Force } 

                # Assert 
                It "Should return Profiles Latest & 2016-04-consistent" {
                $profilesInstalled = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile } 
                ($profilesInstalled -like "*2016-04-consistent*") -ne $null | Should Be $true
                ($profilesInstalled -like "*latest*") -ne $null | Should Be $true
            }

                # Clean up
                Remove-PSSession -Session $session        
            }

            Context "Select diff profiles" {
                # Arrange
                # Create two new PS sessions
                $session1 = New-PSSession
                $session2 = New-PSSession

                # Act
                # Use-AzureRmProfile will import the respective versions of modules in the session
                Invoke-Command -Session $session1 -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force }
                Invoke-Command -Session $session2 -ScriptBlock { Use-AzureRmProfile -Profile '2016-04-consistent' -Force } 
    
                $getModule = {
                    Param($RollupModule)
                    Get-Module -Name $RollupModule
                }

                $result = Invoke-Command -Session $session1 -ScriptBlock { Get-AzureRmProfile }
                $module1 = Invoke-Command -Session $session1 -ScriptBlock $getModule -ArgumentList $RollupModule
                $module2 = Invoke-Command -Session $session2 -ScriptBlock $getModule -ArgumentList $RollupModule

                # Assert
                It "Should return Latest & 2016-04-consistent" {
                    ($result -like "*latest*") -ne $null | Should Be $true 
                    ($result -like "*2016-04-consistent*") -ne $null | Should Be $true
                }

                It "Respective versions of modules are imported" {
                    # Are respective modules imported?
                    $module1.Name | Should Be $RollupModule
                    $module1.version | Should Be $Version1

                    $module2.Name | Should Be $RollupModule
                    $module2.version | Should Be $Version2
                }

                # "Uninstall All Profiles" 
                Remove-InstalledProfile

                It "Should return null" {
                    Get-AzureRmProfile | Should Be $null
                }

                It "Modules should return null" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -ListAvailable -Name $RollupModule
                    }

                    $result1 = Invoke-Command -Session $session1 -ScriptBlock $getModuleList  -ArgumentList $RollupModule
                    foreach ($result in $result1)
                    {
                        $result.Version -eq $Version1 | Should Be $false
                    }
                    $result2 = Invoke-Command -Session $session2 -ScriptBlock $getModuleList  -ArgumentList $RollupModule
                    foreach ($result in $result2)
                    {
                        $result.Version -eq $Version2 | Should Be $false
                    }
                }

                # Cleanup
                Remove-PSSession -Session $session1
                Remove-PSSession -Session $session2
            }
        }
    }

    Describe "Invalid Cases" {
        Context "Install wrong profile name" {
            # Install profile 'abcTest'
            It "Throws Invalid argument error" {
                { Install-AzureRmProfile -Profile 'abcTest' } | Should Throw
            }
        }

        Context "Install null profile name" {
            # Install profile 'null'
            It "Throws Invalid argument error" {
                { Install-AzureRmProfile -Profile $null } | Should Throw
            }
        }

        Context "Install already installed profile" {
            # Arrange
            # Create a new PS session
            $session = New-PSSession

            # Ensure profile 2016-09 is installed
            Install-AzureRmProfile -Profile '2016-04-consistent' -Force
            $installedProfile = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
            ($installedProfile -like "*2016-04-consistent*") -ne $null | Should Be $true
            
            # Act
            # Install profile '2016-04-consistent'
            $result = Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile '2016-04-consistent' -Force } 

            # Get modules imported into the session
            $getModuleList = {
                    Param($RollupModule)
                    Get-Module -Name $RollupModule
                }
            $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList $RollupModule

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

            # Ensure profile latest is not installed
            $installedProfile = Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile }
            ($installedProfile -like "*latest*") | Should Be $null

            # Act
            # Uninstall profile 'latest'
            $result = Invoke-Command -Session $session -ScriptBlock { Uninstall-AzureRmProfile -Profile 'latest' -Force} 

            It "Doesn't uninstall/throw" {
                $result | Should Be $null
            }

            # Cleanup
            Remove-PSSession -Session $session
        }

        Context "Use-AzureRmProfile with wrong profile name" {
            # Install profile 'abcTest'
            It "Throws Invalid argument error" {
                { Use-AzureRmProfile -Profile 'abcTest' } | Should Throw
            }
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
                Mock Get-AzureRmModule -Verifiable {}

                # Act & Assert
                It "Should not download/install the latest profile" {
                    { Get-AzureRmProfile -Update } | Should Throw
                    { Install-AzureRmProfile -Profile 'Latest' -Force } | Should Throw
                }

                It "Last Write time should not be less than 3 mins" {
                    # Get LastWriteTime for ProfileMap
                    $lastWriteTime = (Get-Item -Path (Get-LatestProfileMapPath).FullName).LastWriteTime
                    (((Get-Date) - $lastWriteTime).TotalMinutes -gt 3) | Should Be $true
                    Assert-VerifiableMock
                }
            }

            Context "Retry install after ProfileMap update" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove ProfileMap.json to test if it is updated from online
                Remove-Item -Path (Get-LatestProfileMapPath).FullName -Force

                # Act
                # Update ProfileMap
                Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -Update }

                # Install profile 'Latest'
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile 'Latest' -Force } 

                # Assert
                It "Installs & Imports Latest profile to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList $RollupModule

                    # Get the version of the Latest profile
                    $ProfileMap = Get-AzProfile
                    $latestVersion = $ProfileMap.'Latest'.$RollupModule
                
                    # Are latest modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $latestVersion
                }

                It "Last Write time should be less than 5 mins" {
                    # Get LastWriteTime for ProfileMap
                    $lastWriteTime = (Get-Item -Path (Get-LatestProfileMapPath).FullName).LastWriteTime
                    (((Get-Date) - $lastWriteTime).TotalMinutes -lt 5) | Should Be $true
                }

                # Cleanup
                Remove-PSSession -Session $session
            }
        }
    }

    Describe "Install profiles using Scope" {
        InModuleScope AzureRM.Bootstrapper {

            Context "Using Install-AzureRmProfile: Scope 'CurrentUser'" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove installed profiles
                Remove-InstalledProfile 

                # Act
                # Install profile Latest scope as current user
                Invoke-Command -Session $session -ScriptBlock { Install-AzureRmProfile -Profile 'Latest' -scope 'CurrentUser' -Force }

                # Assert
                It "Installs & Imports Latest profile to the session" {
                    # Get the version of the Latest profile
                    $ProfileMap = Get-AzProfile
                    $latestVersion = $ProfileMap.'Latest'.$RollupModule
                    
                    $getModuleList = {
                        Param($RollupModule, $latestVersion)
                        Get-Module -Name $RollupModule -ListAvailable | Where-Object {$_.Version -like $latestVersion}
                    }
                    $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList @($RollupModule, $latestVersion)

                    # Are latest modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $latestVersion
                }
            }

            Context "Using Use-AzureRmProfile: Scope 'AllUsers'" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove installed profiles
                Remove-InstalledProfile 

                # Act
                # Install profile 2016-04-consistent scope as all users
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile '2016-04-consistent' -scope 'AllUsers' -Force }

                # Assert
                It "Installs & Imports 2016-04-consistent profile to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList $RollupModule

                    # Get the version of the 2016-04-consistent profile
                    $ProfileMap = Get-AzProfile
                    $version = $ProfileMap.'2016-04-consistent'.$RollupModule
                
                    # Are appropriate modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $version
                }
            }

            Context "Using Update-AzureRmProfile: Scope 'CurrentUser' " {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove installed profiles
                Remove-InstalledProfile 

                # Act
                # Install profile 2016-04-consistent scope as current user
                Invoke-Command -Session $session -ScriptBlock { Update-AzureRmProfile -Profile '2016-04-consistent' -scope 'CurrentUser' -Force -r }

                # Assert
                It "Installs & Imports 2016-04-consistent profile to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList $RollupModule

                    # Get the version of the 2016-04-consistent profile
                    $ProfileMap = Get-AzProfile
                    $version = $ProfileMap.'2016-04-consistent'.$RollupModule
                
                    # Are correct modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $version
                }
            }
        }
    }

    Describe "Load/Import AzureRmProfile modules" {
        InModuleScope AzureRM.Bootstrapper {
        Context "Using Use-AzureRmProfile: Modules are not installed" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove installed profiles
                Remove-InstalledProfile 

                # Act
                # Use module from Latest profile scope as current user
                Invoke-Command -Session $session -ScriptBlock { Use-AzureRmProfile -Profile '2016-04-consistent' -Module 'AzureRM.Storage' -Force -scope 'CurrentUser'}

                # Assert
                $RollupModule = 'AzureRM.Storage'
                It "Installs & Imports 2016-04-consistent profile's module to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $modules = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList $RollupModule

                    # Get the version of the 2016-04-consistent profile
                    $ProfileMap = Get-AzProfile
                    $version = $ProfileMap.'2016-04-consistent'.$RollupModule
                
                    # Are 2016-04-consistent modules imported?
                    $modules.Name | Should Be $RollupModule
                    $modules.version | Should Be $version
                }
            }

            Context "Using Update-AzureRmProfile: Previous version of modules are installed" {
                # Arrange
                # Create a new PS session
                $session = New-PSSession

                # Remove installed profiles
                Remove-InstalledProfile 

                # Remove latest profile map from cache for testing if it updates from online.
                $latestMap = Get-LatestProfileMapPath
                if (($latestMap -ne $null) -and (Test-Path $latestMap.FullName))
                {
                    Remove-Item -Path $latestMap.FullName -Force
                }

                # Add a version of old profilemap with older versions of 'latest' profile to cache
                $testProfileMap = "{`"Latest`": {`"Azure.Storage`": [`"2.4.0`"], `"AzureRM.Storage`": [`"2.4.0`"] }}" 
                $testProfileMap | Out-File -FilePath "$ProfileCachePath\TestMap.json" -Force

                # Install the modules from that profilemap
                $testProfileMap = ($testProfileMap | ConvertFrom-Json)
                
                foreach ($Module in ($testProfileMap.'Latest' | Get-Member -MemberType NoteProperty).Name)
                {
                    $oldVersion = $testProfileMap.'Latest'.$Module
                    Install-Module $Module -RequiredVersion $oldVersion[0] -ErrorAction Stop -AllowClobber
                }

                # Act
                # Update profile Latest with -RemovePreviousVersions
                Invoke-Command -Session $session -ScriptBlock { Get-AzureRmProfile -Update }
                Invoke-Command -Session $session -ScriptBlock { Update-AzureRmProfile -Profile 'Latest' -Module 'AzureRM.Storage', 'Azure.Storage' -Force -r }

                # Assert
                It "Installs & Imports latest profile's module ('AzureRM.Storage') to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $module1 = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList 'AzureRM.Storage'

                    # Get the version of the latest profile
                    $ProfileMap = Get-AzProfile
                    $version1 = $ProfileMap.'Latest'.'AzureRM.Storage'
                    
                    # Are latest modules imported?
                    $module1.Name | Should Be 'AzureRM.Storage'
                    $module1.version | Should Be $version1
                }

                It "Installs & Imports latest profile's module ('Azure.Storage') to the session" {
                    $getModuleList = {
                        Param($RollupModule)
                        Get-Module -Name $RollupModule
                    }
                    $module2 = Invoke-Command -Session $session -ScriptBlock $getModuleList  -ArgumentList 'Azure.Storage'

                    # Get the version of the latest profile
                    $ProfileMap = Get-AzProfile
                    $version2 = $ProfileMap.'Latest'.'Azure.Storage'
                
                    # Are latest modules imported?
                    $module2.Name | Should Be 'Azure.Storage'
                    $module2.version | Should Be $version2
                }

                # Check if the old profilemap was removed
                It "Should return false for old profile map in cache" {
                    (Test-Path "$ProfileCachePath\TestMap.json") | Should Be $false
                }
            }
        }
    }
}