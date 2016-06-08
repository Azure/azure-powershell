Configuration DummyConfig
{
    Import-DscResource -ModuleName PSDesiredStateConfiguration

    Script dummyscript
   {
      SetScript = 'Write-Verbose -Verbose "Testing Dummy script!!"'
      GetScript = "Test dummyscript"
      TestScript = {$false}
   }
}

