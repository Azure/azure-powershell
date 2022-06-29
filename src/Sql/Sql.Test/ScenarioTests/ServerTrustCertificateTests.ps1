# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# Location to use for provisioning test managed instances
$instanceLocation = "westcentralus"

# Test constants
$certType = "Microsoft.Sql/managedInstances/serverTrustCertificates"

$certName1 = "test_cert1"
$certVal1 = "0x3082031E30820206A00302010202107339C358890D88B04D584E95AD40EFA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F0053006D006F0045007800740065006E006400650064005300690067006E0069006E006700430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A304B3149304706035504031E40004D0053005F0053006D006F0045007800740065006E006400650064005300690067006E0069006E00670043006500720074006900660069006300610074006530820122300D06092A864886F70D01010105000382010F003082010A0282010100B796616200301A3E8E06A594CD45EB665676E23368222D7F7F70E6474B602978A7A3D45381B293D6FE5C4EB47298496CDA2599DBC2645B2A1CEB311FC4D5AD5AE162E337776D90B8D1E30BF2BB1D19783B22AA261EBA70FBF6896FFE356ED7A7E09EA71F67B6E2213ACE95E8DA12038B6D2D2C986D56CA0859D6A1BDA7DA08DCFFE11FF1E59EDA4225BC0A252405025E49F5C34B65E9614DF8BBD78AFE33CD14E32F2043D833EE7EF6CE3E663BF437A72DE2933D6FC62FB5E87F6B443A0257135C09B8308B231358594EE2FD3A384B3AD5B7D22B1B35E1682F28CC5F7F27A233D704E7DE46126B811E5CF4D2835C316DBD9A4288DA02B2481FF8FCEF754F957D0203010001300D06092A864886F70D01010B0500038201010029577117B09612B085B6AE47417C556013DEF38F61E726E1DEE908332BDD50F830CE43B7D61F20E300E50E23305C94D19DB5FF0F66D0E7B6DAB6510680A10B346653359C1B20F219BF1EB4217B6AEC4CD01BB96F0E84CC9C5DC6DA325EB8979DCA9E9F61AF1C2BB3E3DAB4DE7D118588184FF98FE8E803F3374392464A64563D097AB878DB01115CD443EAF58B0705E13A1E27021F6C0E0104CF5307DCCA79D4CA70F26A3FD2CE89AAE0AD1C08E884AB1BD8FAF3983A0667820BB122688E30C873932FB25BF85EA0B23E651D4DBA5436EC6F17D770832E7041ED44952883470E1B599FDB0E518E663CBD6FED7983849101A89497CF4D0C9FE2DF7F9C2BE3C21A"
$thumbprint1 = "0x5E1C40529126487B5B20C0E7E299FFF7190E94D7"

$certName2 = "test_cert2"
$certVal2 = "0x3082031E30820206A003020102021015ECCB530A52D0874A9B4DFB69FFCAA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F00530051004C005200650073006F0075007200630065005300690067006E0069006E006700430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A304B3149304706035504031E40004D0053005F00530051004C005200650073006F0075007200630065005300690067006E0069006E00670043006500720074006900660069006300610074006530820122300D06092A864886F70D01010105000382010F003082010A0282010100C3BC903BD030D2EE904E941B603040F7DF38262BBA86AD3B9AD4BFE361D910378C5459DE540398E43124272BAE97AE502490F5140393A66EC49667D1B64449EAECC0DCB7FCA5BBF2E214F0AF8A697CBAF790B0FCD086C69C06A363849D7481468894E40F0B6466591775FFA6B3E387F5C56126078EBB69CB7EA9FD842233A29C9D92EE0ED2D9D09C96EBE2B4089EBE9A2D2276F75F506FD09CB3DF312C2B737E8E20AB4C7F48EF5D730D8AB4BB7234315ABD4CB2568896801CECB2B6452EADAEE2DFC7E8B03B01B0F8742BF9DA941E5449F14ABA8BAA58189D4F7558068E782580181038EB3DBAC7FD53D200357298258F3AC9ACCA4845F83C8539E35FC36B750203010001300D06092A864886F70D01010B0500038201010072200767AE16B164DCC9A7439F96CA3EBFDEEF8440B2BD9356E0257520FB8A2763E90BB6D727F7CE63CC40B40872A7C77B451EFD5CB022D349303C75956CA372D3FF513516EEA0F545240D451FC98EA743008EFDE63ABC003AEE3FA80CA05425CA3FD9C0EC8123BD6F1E9DAFE5AC33AF3A1DE89E6F28349DE7A5EE5AE39F0E6AD87B3D03037FDB9F1B1A7BB1B55A51A70C9E0604BC9EDDFA4BF1582C039826E89F960720FC6B6AB398DFFC4B38A2F7C526C9AC31D96BA40D9B02FC58FFAA37BE5B3DC0DCCF9F1ED1358A23E4E7D0E3A397B841BCFB7AE8405DE8A42511C2C3B14DFB13F467F16ED63EEB0E22127E281EEDCBD9A3D3C957AC51D5D75FBB713018"
$thumbprint2 = "0x3B3209B3F06A633946AB89FA5E18D7A7E81A066E"
 
$invalidCertName1 = "invalid_cert1";
$invalidCertName2 = "invalid_cert2";
$invalidCertName3 = "invalid_cert3";
$invalidCertVal = "0x3082031E30820206A00302010202107339C358890D88B04D584E95AD40EFA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F0053006D006F0045007800740065";
$certVal3 = "0x30820316308201FEA003020102021072F30C6F228A33B64405E7EA8BB1C949300D06092A864886F70D01010B050030473145304306035504031E3C004D0053005F00530051004C00410075007400680065006E00740069006300610074006F007200430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A30473145304306035504031E3C004D0053005F00530051004C00410075007400680065006E00740069006300610074006F00720043006500720074006900660069006300610074006530820122300D06092A864886F70D01010105000382010F003082010A0282010100C6DB530E4E055B502D75A1E25EE65403B754A4079898027018E3032DDD42A67C243797DAA737C32E933E4582DC2BBADE16F35C41E55ED77B6AC640F7DE788FCD617A594FD6A4A0BC4F2FCAC84D031F1D1F4DD82225E953918550DF657633C1FB1D5D227DCBF7A924122165E3C67F5E88AA68EA509BAB82966C377C1F3CF83A0AEAFFD18B3C24D631FE12DF7D10659A6601ACD55CAA95CC57CD3E4B29B01271F0FA64725E288BEAEB7792B15FE2FD36EF8A86CEBF3AAEFCCAD3A84295EB01E0AD776617FB42A470A9F5956011C11BFFB881C97650647C734393A68AC379EB9187DEBAD9C61F26BB8AEFE5A1AD549010DA7DBF0478EEEBB4D55C5863DB336A7F7D0203010001300D06092A864886F70D01010B05000382010100C052781B299ECFB0B833B5DC3CC96E0C9DAB6900708F16059E13A8A5D07493A7BB551E7E2513284F11AA8D6F8AB85374B43A97388387FC8E0DB45650D68E61F634E1CD86D064F8831CD5E353FD6D304087A604CEB4388866BCB64CD95F3F45D76D4A97C4ECAA1512202F24001784C00243D63AFC402247A961FB48578B28BBC8496A4441A0A72BF12755F1C16810A53723510F498908C824340F0B18081615A2EF75B4B94F5A22D9D1B4A0AA483006B0A8B035F4D5D0E5FD247C7199874C3E0BD4E80DF013BA7636BE906146C888B1C4848A729797A971C74D67FFC6A926978F6F9A3A222AD534F27A1F7FEFB48E54C335050447BF41D8CCB71889D836BB6AC6"
$thumbprint3 = "0xC8002E47F5BC5A3D3692B57D6987C7D9D79863DA";

<#
    .SYNOPSIS
    Tests creating a server trust certificate
#>
function Test-ServerTrustCertificate
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName
                
        # generate expected cert ids
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName
        $instanceId = $instance.Id
        $certId1 = $instanceId + "/serverTrustCertificates/" + $certName1
        $certId2 = $instanceId + "/serverTrustCertificates/" + $certName2
        $certId3 = $instanceId + "/serverTrustCertificates/" + $certName3

        # temp cleanup
        # try { Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName | Get-AzSqlInstanceServerTrustCertificate | Remove-AzSqlInstanceServerTrustCertificate } catch { }

        # List 0 certs
        $listCertsZero = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCertsZero is ' + (ConvertTo-Json $listCertsZero))
        Assert-Null $listCertsZero

        # Upsert valid certificate #1 via CreateByNameParameterSet
        $newCert1 = New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 -PublicKey $certVal1
        Write-Debug ('$newCert1 is ' + (ConvertTo-Json $newCert1))
        Assert-NotNull $newCert1
        Assert-AreEqual	$newCert1.ResourceGroupName $rgName
        Assert-AreEqual	$newCert1.InstanceName $miName
        Assert-AreEqual $newCert1.Id $certId1
        Assert-AreEqual	$newCert1.Type $certType
        Assert-AreEqual	$newCert1.Name $certName1
        Assert-AreEqual	$newCert1.Thumbprint $thumbprint1
        Assert-AreEqual $newCert1.PublicKey $certVal1

        # Upsert valid certificate #2 via CreateByParentObjectParameterSet
        $newCert2 = New-AzSqlInstanceServerTrustCertificate -InstanceObject $instance -CertificateName $certName2 -PublicKey $certVal2
        Write-Debug ('$newCert2 is ' + (ConvertTo-Json $newCert2))
        Assert-NotNull $newCert2
        Assert-AreEqual	$newCert2.ResourceGroupName $rgName
        Assert-AreEqual	$newCert2.InstanceName $miName
        Assert-AreEqual $newCert2.Id $certId2
        Assert-AreEqual	$newCert2.Type $certType
        Assert-AreEqual	$newCert2.Name $certName2
        Assert-AreEqual	$newCert2.Thumbprint $thumbprint2
        Assert-AreEqual $newCert2.PublicKey $certVal2

        # Test all 4 parameter sets for GET:
        # GetByNameParameterSet
        # GetByParentObjectParameterSet
        # GetByResourceIdParameterSet
        # GetByInstanceResourceIdParameterSet

        # Get valid certificate #1 - (GetByNameParameterSet)
        $getCert1ByNameParameterSet = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1
        Write-Debug ('$getCert1ByNameParameterSet is ' + (ConvertTo-Json $getCert1ByNameParameterSet))
        Assert-NotNull $getCert1ByNameParameterSet
        Assert-AreEqual	$getCert1ByNameParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByNameParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByNameParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByNameParameterSet.Type $certType
        Assert-AreEqual	$getCert1ByNameParameterSet.Name $certName1
        Assert-AreEqual	$getCert1ByNameParameterSet.Thumbprint $thumbprint1
        Assert-AreEqual $getCert1ByNameParameterSet.PublicKey $certVal1

        # Get valid certificate #1 - (GetByParentObjectParameterSet)
        $getCert1ByParentObjectParameterSet = Get-AzSqlInstanceServerTrustCertificate -InstanceObject $instance -CertificateName $certName1
        Write-Debug ('$getCert1ByParentObjectParameterSet is ' + (ConvertTo-Json $getCert1ByParentObjectParameterSet))
        Assert-NotNull $getCert1ByParentObjectParameterSet
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByParentObjectParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.Type $certType
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.Name $certName1
        Assert-AreEqual	$getCert1ByParentObjectParameterSet.Thumbprint $thumbprint1
        Assert-AreEqual $getCert1ByParentObjectParameterSet.PublicKey $certVal1

        # Get valid certificate #1 - (GetByResourceIdParameterSet)
        $getCert1ByResourceIdParameterSet = Get-AzSqlInstanceServerTrustCertificate -ResourceId $certId1
        Write-Debug ('$getCert1ByResourceIdParameterSet is ' + (ConvertTo-Json $getCert1ByResourceIdParameterSet))
        Assert-NotNull $getCert1ByResourceIdParameterSet
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByResourceIdParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.Type $certType
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.Name $certName1
        Assert-AreEqual	$getCert1ByResourceIdParameterSet.Thumbprint $thumbprint1
        Assert-AreEqual $getCert1ByResourceIdParameterSet.PublicKey $certVal1

        # Get valid certificate #1 - (GetByInstanceResourceIdParameterSet)
        $getCert1ByInstanceResourceIdParameterSet = Get-AzSqlInstanceServerTrustCertificate -InstanceResourceId $instanceId -CertificateName $certName1
        Write-Debug ('$getCert1ByInstanceResourceIdParameterSet is ' + (ConvertTo-Json $getCert1ByInstanceResourceIdParameterSet))
        Assert-NotNull $getCert1ByInstanceResourceIdParameterSet
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.ResourceGroupName $rgName
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.InstanceName $miName
        Assert-AreEqual $getCert1ByInstanceResourceIdParameterSet.Id $certId1
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.Type $certType
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.Name $certName1
        Assert-AreEqual	$getCert1ByInstanceResourceIdParameterSet.Thumbprint $thumbprint1
        Assert-AreEqual $getCert1ByInstanceResourceIdParameterSet.PublicKey $certVal1

        # Get valid certificate #2
        $getCert2 = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName2
        Write-Debug ('$getCert2 is ' + (ConvertTo-Json $getCert2))
        Assert-NotNull $getCert2
        Assert-AreEqual	$getCert2.ResourceGroupName $rgName
        Assert-AreEqual	$getCert2.InstanceName $miName
        Assert-AreEqual $getCert2.Id $certId2
        Assert-AreEqual	$getCert2.Type $certType
        Assert-AreEqual	$getCert2.Name $certName2
        Assert-AreEqual	$getCert2.Thumbprint $thumbprint2
        Assert-AreEqual $getCert2.PublicKey $certVal2

        # List all certificates
        $listCerts = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCerts is ' + (ConvertTo-Json $listCerts))
        Assert-NotNull $listCerts
        Assert-AreEqual	$listCerts.Count 2

        # Delete certificate #1 via DeleteByNameParameterSet
        $delCert1 = Remove-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -Name $certName1 -PassThru
        Write-Debug ('$delCert1 is ' + (ConvertTo-Json $delCert1))
        Assert-NotNull $delCert1
        Assert-AreEqual	$delCert1.ResourceGroupName $rgName
        Assert-AreEqual	$delCert1.InstanceName $miName
        Assert-AreEqual $delCert1.Id $certId1
        Assert-AreEqual	$delCert1.Type $certType
        Assert-AreEqual	$delCert1.Name $certName1
        Assert-AreEqual	$delCert1.Thumbprint $thumbprint1
        Assert-AreEqual $delCert1.PublicKey $certVal1

        # Delete non existant cert #1 THROWS (via DeleteByParentObjectParameterSet)
        $msgExcDel = "The requested resource of type '" + $certType + "' with name '" + $certName1 + "' was not found."
        Assert-Throws { Remove-AzSqlInstanceServerTrustCertificate -InstanceObject $instance -CertificateName $certName1 } $msgExc
        
        # Delete non existant cert #1 THROWS (via DeleteByInputObjectParameterSet)
        $msgExcDel = "The requested resource of type '" + $certType + "' with name '" + $certName1 + "' was not found."
        Assert-Throws { Remove-AzSqlInstanceServerTrustCertificate -InputObject $getCert1ByInstanceResourceIdParameterSet} $msgExc

        # Get non existant cert #1 THROWS (via DeleteByInputObjectParameterSet)
        $msgExcGet = "The requested resource of type '" + $certType + "' with name '" + $certName1 + "' was not found."
        Assert-Throws { Get-AzSqlInstanceServerTrustCertificate -InputObject $getCert1ByInstanceResourceIdParameterSet } $msgExc
        
        # Delete certificate #2 via DeleteByResourceIdParameterSet
        $delCert2 = Remove-AzSqlInstanceServerTrustCertificate -ResourceId $certId2 -PassThru
        Write-Debug ('$delCert2 is ' + (ConvertTo-Json $delCert2))
        Assert-NotNull $delCert2
        Assert-AreEqual	$delCert2.ResourceGroupName $rgName
        Assert-AreEqual	$delCert2.InstanceName $miName
        Assert-AreEqual $delCert2.Id $certId2
        Assert-AreEqual	$delCert2.Type $certType
        Assert-AreEqual	$delCert2.Name $certName2
        Assert-AreEqual	$delCert2.Thumbprint $thumbprint2
        Assert-AreEqual $delCert2.PublicKey $certVal2

        # List 0 certs
        $listCertsZero = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCertsZero is ' + (ConvertTo-Json $listCertsZero))
        Assert-Null $listCertsZero

    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}

<#
    .SYNOPSIS
    Tests removing a server trust certificate
#>
function Test-ServerTrustCertificateErrHandling
{
    try
    {		
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName

        # temp cleanup
        #try { Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName | Get-AzSqlInstanceServerTrustCertificate | Remove-AzSqlInstanceServerTrustCertificate } catch { }
        
        # List 0 certs
        $listCertsZero = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCertsZero is ' + (ConvertTo-Json $listCertsZero))
        Assert-Null $listCertsZero

        # Upsert Cert with invalid public key blob
        $exc1 = "Invalid public blob"
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $invalidCertName1 -PublicKey $invalidCertVal } $exc1
        # Upsert Cert without public key blob
        $exc2 = "Cannot validate argument on parameter 'PublicKey'. The argument is null or empty."
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $invalidCertName2 -PublicKey $null } $exc2
        # Upsert valid certificate #1
        $newCert1 = New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 -PublicKey $certVal1
        Assert-NotNull $newCert1
        # Upsert Cert with a public blob that already exist on the instance under a different name
        $exc3 = "Long running operation failed with status 'Failed'"
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $invalidCertName3 -PublicKey $certVal1 } $exc3
        # Upsert Cert blob empty
        $exc4 = "Cannot validate argument on parameter 'PublicKey'. The argument is null or empty."
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $invalidCertName3 -PublicKey "" } $exc4
        # Upsert Cert name exists, different blob
        $exc5 = "Certificate with name '" + $certName1 + "' already exists on managed instance '" + $miName + "'."
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 -PublicKey $certVal3 } $exc5
        # Upsert Cert name empty
        $exc6 = "Cannot validate argument on parameter 'Name'. The argument is null or empty."
        Assert-ThrowsContains { New-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName "" -PublicKey $certVal1 } $exc6

        # Delete certificate #1
        $delCert1 = Remove-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 -PassThru
        Assert-NotNull $delCert1
        # Delete non existant cert #1 THROWS
        $msgExcDel = "The requested resource of type '" + $certType + "' with name '" + $certName1 + "' was not found."
        Assert-Throws { Remove-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 } $msgExc
        
        # Get non existant cert #1 THROWS
        $msgExcGet = "The requested resource of type '" + $certType + "' with name '" + $certName1 + "' was not found."
        Assert-Throws { Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName -CertificateName $certName1 } $msgExc

        # List 0 certs
        $listCertsZero = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName $rgName -InstanceName $miName
        Write-Debug ('$listCertsZero is ' + (ConvertTo-Json $listCertsZero))
        Assert-Null $listCertsZero

    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}


<#
    .SYNOPSIS
    Tests creating a server trust certificate
#>
function Test-ServerTrustCertificatePiping
{
    try
    {
        # Setup
        $rg = Create-ResourceGroupForTest
        $managedInstance = Create-ManagedInstanceForTest $rg
        $rgName = $rg.ResourceGroupName
        $miName = $managedInstance.ManagedInstanceName

        # temp cleanup
        #try { Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName | Get-AzSqlInstanceServerTrustCertificate | Remove-AzSqlInstanceServerTrustCertificate } catch { }
        
        $instance = Get-AzSqlInstance -ResourceGroupName $rgName -Name $miName 

        # Upsert certificate #1 and #2 via ParentObject piping
        $newCert1 = $instance | New-AzSqlInstanceServerTrustCertificate -CertificateName $certName1 -PublicKey $certVal1
        $newCert2 = $instance | New-AzSqlInstanceServerTrustCertificate -CertificateName $certName2 -PublicKey $certVal2
        Write-Debug ('$newCert1 is ' + (ConvertTo-Json $newCert1))
        Write-Debug ('$newCert2 is ' + (ConvertTo-Json $newCert2))
        Assert-NotNull $newCert1
        Assert-NotNull $newCert2

        # Grab certificates #1 and #2 via ParentObject piping
        $listCertRespByParentObjectPipe = $instance | Get-AzSqlInstanceServerTrustCertificate
        $getCertRespByParentObjectPipe =  $instance | Get-AzSqlInstanceServerTrustCertificate -CertificateName $certName1
        $getCertRespByParentObjectPipe =  $instance | Get-AzSqlInstanceServerTrustCertificate -CertificateName $certName2
        Write-Debug ('$listCertRespByParentObjectPipe is ' + (ConvertTo-Json $listCertRespByParentObjectPipe))
        Write-Debug ('$getCertRespByParentObjectPipe is ' + (ConvertTo-Json $getCertRespByParentObjectPipe))
        Write-Debug ('$getCertRespByParentObjectPipe is ' + (ConvertTo-Json $getCertRespByParentObjectPipe))
        Assert-NotNull $listCertRespByParentObjectPipe
        Assert-NotNull $getCertRespByParentObjectPipe
        Assert-NotNull $getCertRespByParentObjectPipe

        # Delete certificates
        $removeCertCollectionPipe = $listCertRespByParentObjectPipe | Remove-AzSqlInstanceServerTrustCertificate -PassThru
        Write-Debug ('$removeCertCollectionPipe is ' + (ConvertTo-Json $removeCertCollectionPipe))
        Assert-NotNull $removeCertCollectionPipe

    }
    finally
    {
        Remove-ResourceGroupForTest $rg
    }
}
