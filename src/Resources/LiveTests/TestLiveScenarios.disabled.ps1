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
        $userName = $today + 'testuser' + (New-LiveTestRandomName)
        
        $groupMailNickName1 = New-LiveTestRandomName
        $groupMailNickName2 = New-LiveTestRandomName
        $userMailNickName = New-LiveTestRandomName
        $userPrincipalName = $userMailNickName + 'microsoft.com#EXT#@AzureSDKTeam.onmicrosoft.com'

        $group1 = New-AzADGroup -DisplayName $groupName1 -MailNickname $groupMailNickName1
        $group1 = Get-AzADGroup -DisplayName $groupName1
        $group2 = New-AzADGroup -DisplayName $groupName2 -MailNickname $groupMailNickName2
        $group2 = Get-AzADGroup -DisplayName $groupName2

        $password = 'A' + (New-LiveTestRandomName)
        $password = ConvertTo-SecureString -AsPlainText -Force $password
        $user = New-AzADUser -DisplayName $userName -Password $password -AccountEnabled $true -MailNickname $userMailNickname -UserPrincipalName $userPrincipalName
        $user = Get-AzADUser -DisplayName $userName

        Add-AzADGroupMember -TargetGroupObjectId $group1.Id -MemberObjectId $group2.Id, $user.Id

        #TODO: test type of group member and properties, for example, user principal name from user
        $members = Get-AzADGroupMember -GroupObjectId $group1.Id
        foreach ($member in $members) {
            switch ($member.OdataType) {
                '#microsoft.graph.user' {
                    Assert-AreEqual $user.Id $member.Id
                    Assert-AreEqual $userPrincipalName $member.UserPrincipalName
                    Remove-AzADGroupMember -GroupObjectId $group1.Id -MemberObjectId $user.Id
                }
                '#microsoft.graph.group' {
                    Assert-AreEqual $group2.Id $member.Id
                    Remove-AzADGroupMember -GroupObjectId $group1.Id -MemberObjectId $group2.Id
                }
            }
        }
    } finally {
        if ($user) {
            Remove-AzADUser -ObjectId $user.Id
        }
        if ($group2) {
            Remove-AzADGroup -ObjectId $group2.Id
        }
        if ($group1) {
            Remove-AzADGroup -ObjectId $group1.Id
        }
    }
}
