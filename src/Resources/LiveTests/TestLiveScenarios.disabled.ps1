Invoke-LiveTestScenario -Name "Test Application" -Description "Test the process of create an application." -NoResourceGroup -ScenarioScript `
{
    try {
        $today = (Get-Date).tostring('yyyy-MM-dd')
        $appName1 = $today + 'testapp' + (New-LiveTestRandomName)
        $replyUrl1 = 'https://' + $appName1 + '-reply.com'
        $homePage1 = 'https://' + $appName1 + '-home.com'
    
        $appName2 = $today + 'testapp' + (New-LiveTestRandomName)
        $replyUrl2 = 'https://' + $appName2 + '-reply.com'
        $homePage2 = 'https://' + $appName2 + '-home.com'
    
        $spName1 = $today + 'testsp' + (New-LiveTestRandomName)
        $spName2 = $today + 'testsp' + (New-LiveTestRandomName)
    
        $app1 = New-AzADApplication -DisplayName $appName1 -ReplyUrls $replyUrl1 -HomePage $homePage1 -AvailableToOtherTenants $true -StartDate (Get-Date)
        $app1 = Get-AzADApplication -DisplayName $appName1
        Assert-NotNullOrEmpty $app1.Id
        Assert-AreEqual $replyUrl1 $app1.Web.RedirectUri
        Assert-AreEqual $homepage1 $app1.Web.HomePageUrl
        Assert-AreEqual 'AzureADMultipleOrgs' $app1.SignInAudience
    
        Assert-AreEqual $app1.Id (Get-AzADApplication -ObjectId $app1.id -Select Id).Id
        Assert-AreEqual $app1.Id (Get-AzADApplication -ApplicationId $app1.AppId -Select Id).Id
    
        $app1Update = Update-AzADApplication -ObjectId $app1.Id -ReplyUrl $replyUrl2 -HomePage $homepage2 -AvailableToOtherTenants $false
        $app1Update = Get-AzADApplication -DisplayName $appName1

        Assert-AreEqual $replyUrl2 $app1Update.Web.RedirectUri
        Assert-AreEqual $homepage2 $app1Update.Web.HomePageUrl
        Assert-AreEqual 'AzureADMyOrg' $app1Update.SignInAudience
        $pw = New-AzADAppCredential -ObjectId $app1.Id -StartDate (get-date)
        Assert-NotNullOrEmpty (Get-AzADAppCredential -ObjectId $app1.Id).KeyId
    
        $certFile = Join-Path $PSScriptRoot 'msgraphtest2.cer'
        $content = get-content $certFile -AsByteStream
        $certvalue = [System.Convert]::ToBase64String($content)
        $cert = New-AzADAppCredential -ObjectId $app1.Id -CertValue $certvalue
    
        Remove-AzADAppCredential -ObjectId $app1.Id -KeyId $pw.KeyId
    
        $sp1 = New-AzADServicePrincipal -ApplicationId $app1.AppId
        $sp1 = Get-AzADServicePrincipal -ApplicationId $app1.AppId
        $sp2 = New-AzADServicePrincipal -DisplayName $spName2        
        $sp2 = Get-AzADServicePrincipal -DisplayName $spName2
        $app2 = Get-AzADApplication -DisplayName $spName2
    } finally {
        if ($sp1) {
            Remove-AzADServicePrincipal -ServicePrincipalName $sp1.ServicePrincipalName[0]
        }
        if ($sp2) {
            Remove-AzADServicePrincipal -ObjectId $sp2.Id
        }
        if ($app1) {
            Remove-AzADApplication -DisplayName $appName1
        }
        if ($app2) {
            Remove-AzADApplication -DisplayName $spName2
        }
    }
}

Invoke-LiveTestScenario -Name "Test Group Member" -Description "Test the process of create groups and members." -NoResourceGroup -ScenarioScript `
{
    try {
        $today = (Get-Date).tostring('yyyy-MM-dd')
        $groupName1 = $today + 'testgroup' + (New-LiveTestRandomName)
        $groupName2 = $today + 'testgroup' + (New-LiveTestRandomName)
        $userName1 = $today + 'testuser1' + (New-LiveTestRandomName)
        $userName2 = $today + 'testuser2' + (New-LiveTestRandomName)
        
        $groupMailNickName1 = New-LiveTestRandomName
        $groupMailNickName2 = New-LiveTestRandomName
        $userMailNickName1 = New-LiveTestRandomName
        $userPrincipalName1 = $userMailNickName1 + 'microsoft.com#EXT#@AzureSDKTeam.onmicrosoft.com'
        $userMailNickName2 = New-LiveTestRandomName
        $userPrincipalName2 = $userMailNickName2 + 'microsoft.com#EXT#@AzureSDKTeam.onmicrosoft.com'

        $group1 = New-AzADGroup -DisplayName $groupName1 -MailNickname $groupMailNickName1
        $group1 = Get-AzADGroup -DisplayName $groupName1
        $group2 = New-AzADGroup -DisplayName $groupName2 -MailNickname $groupMailNickName2
        $group2 = Get-AzADGroup -DisplayName $groupName2

        #Password has to contain at least one upper case letter
        $password = 'A' + (New-LiveTestRandomName)
        $password = ConvertTo-SecureString -AsPlainText -Force $password
        $user1 = New-AzADUser -DisplayName $userName1 -Password $password -AccountEnabled $true -MailNickname $userMailNickname1 -UserPrincipalName $userPrincipalName1
        $user1 = Get-AzADUser -DisplayName $userName1
        $user2 = New-AzADUser -DisplayName $userName2 -Password $password -AccountEnabled $true -MailNickname $userMailNickname2 -UserPrincipalName $userPrincipalName2
        $user2 = Get-AzADUser -DisplayName $userName2

        Add-AzADGroupMember -TargetGroupObjectId $group1.Id -MemberObjectId $group2.Id, $user1.Id

        New-AzADGroupOwner -GroupId $group1.Id -OwnerId $user2.Id
        New-AzADGroupOwner -GroupId $group1.Id -OwnerId $user1.Id
        $owners = Get-AzADGroupOwner -GroupId $group1.Id
        Assert-NotNullOrEmpty $owners[0]
        Remove-AzADGroupOwner -GroupId $group1.Id -OwnerId $owners[0].Id

        $members = Get-AzADGroupMember -GroupObjectId $group1.Id
        foreach ($member in $members) {
            switch ($member.OdataType) {
                '#microsoft.graph.user' {
                    Assert-AreEqual $user1.Id $member.Id
                    Assert-AreEqual $userPrincipalName1 $member.UserPrincipalName
                    Remove-AzADGroupMember -GroupObjectId $group1.Id -MemberObjectId $user1.Id
                }
                '#microsoft.graph.group' {
                    Assert-AreEqual $group2.Id $member.Id
                    Remove-AzADGroupMember -GroupObjectId $group1.Id -MemberObjectId $group2.Id
                }
            }
        }
    } finally {
        if ($user1) {
            Remove-AzADUser -ObjectId $user1.Id
        }
        if ($user2) {
            Remove-AzADUser -ObjectId $user2.Id
        }
        if ($group2) {
            Remove-AzADGroup -ObjectId $group2.Id
        }
        if ($group1) {
            Remove-AzADGroup -ObjectId $group1.Id
        }
    }
}

Invoke-LiveTestScenario -Name "Test Service Principal app role assignment" -Description "Test the process of service principal app role assignment." -NoResourceGroup -ScenarioScript `
{
    try {
        $today = (Get-Date).tostring('yyyy-MM-dd')
        $appName1 = $today + 'testapp' + (New-LiveTestRandomName)
        $approleName1 = $today + 'testapprole' + (New-LiveTestRandomName)
        $approleName2 = $today + 'testapprole' + (New-LiveTestRandomName)
    
        $spName1 = $today + 'testsp' + (New-LiveTestRandomName)
    
        $approle = New-Object Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphAppRole
        $approle.id = New-Guid
        $approle.DisplayName = $approleName1
        $approle.Description = $approleName1 + "for test"
        $approle.IsEnabled = $true
        $approle.AllowedMemberType = @("User", "Application")
        $approle.value = New-Guid

        $app1 = New-AzADApplication -DisplayName $appName1 -StartDate (Get-Date) -AppRole $approle
        $app1 = Get-AzADApplication -DisplayName $appName1
        Assert-NotNullOrEmpty $app1.AppRole
        $approleId = $app1.AppRole.Id
        
        $resourceSp = New-AzADServicePrincipal -ApplicationObject $app1
        $sp1 = New-AzADServicePrincipal -DisplayName $spName1     
        $sp1 = Get-AzADServicePrincipal -DisplayName $spName1
        $approleAssignment1 = New-AzADServicePrincipalAppRoleAssignment -ServicePrincipalDisplayName $spName1 -ResourceId $resourceSp.Id -AppRoleId $approleId
        $approleAssignmentId1 = $approleAssignment1.Id
        Assert-AreEqual $approleId $approleAssignment1.AppRoleId

        $approleAssignment1 = Get-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId $approleAssignmentId1 -ServicePrincipalId $sp1.Id
        Assert-AreEqual $approleId $approleAssignment1.AppRoleId
        Assert-AreEqual $spName1 $approleAssignment1.PrincipalDisplayName

        $null = Remove-AzADServicePrincipalAppRoleAssignment -AppRoleAssignmentId $approleAssignmentId1 -ServicePrincipalId $sp1.Id
    } finally {
        if ($sp1) {
            Remove-AzADServicePrincipal -ServicePrincipalName $sp1.ServicePrincipalName[0]
        }
        if ($resourceSp) {
            Remove-AzADServicePrincipal -ObjectId $resourceSp.Id
        }
        if ($app1) {
            Remove-AzADApplication -DisplayName $appName1
        }
    }
}
