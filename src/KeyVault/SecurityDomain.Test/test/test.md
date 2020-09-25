openssl req -x509 -newkey rsa:2048 -keyout sd1.key -out sd1.cer -days 365 -nodes
openssl req -x509 -newkey rsa:2048 -keyout sd2.key -out sd2.cer -days 365 -nodes
openssl req -x509 -newkey rsa:2048 -keyout sd3.key -out sd3.cer -days 365 -nodes

openssl req -x509 -newkey rsa:2048 -keyout sd1.key -out sd1.cer -days 365
openssl req -x509 -newkey rsa:2048 -keyout sd2.key -out sd2.cer -days 365
openssl req -x509 -newkey rsa:2048 -keyout sd3.key -out sd3.cer -days 365

<!-- backup -->
Backup-AzManagedHsmSecurityDomain -Name yemingmhsm09 -Certificates  C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd1.cer,C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd2.cer,C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd3.cer -OutputPath C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd.ps.json -Quorum 2

az keyvault security-domain download --sd-quorum 2 --sd-wrapping-keys "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd1.cer" "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd2.cer" "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd3.cer" --security-domain-file "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd.cli.json" --hsm-name yemingmhsm03


<!-- new & backup key  -->
az keyvault key create --hsm-name yemingmhsm06 --name rsa
az keyvault key backup --hsm-name yemingmhsm06 --name rsa --file "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\backup\rsa.key"
az keyvault key delete --hsm-name yemingmhsm06 --name rsa
az keyvault key purge --hsm-name yemingmhsm06 --name rsa
az keyvault key show --hsm-name yemingmhsm06 --name rsa
az keyvault key restore --hsm-name yemingmhsm06 --file "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\backup\rsa.key"
az keyvault key show --hsm-name yemingmhsm06 --name rsa

<!-- remove -->
remove-azkeyvault -Hsm -ResourceGroupName yemingmhsm -Name yemingmhsm06 -Force

<!-- new -->
new-azkeyvault -Hsm -Name yemingmhsm10 -ResourceGroupName yemingmhsm -Location eastus2euap -Administrator 'd7e17135-d5a7-4b8b-89e5-252aa15b7e01','c1be1392-39b8-4521-aafc-819a47008545'

<!-- restore key: fail -->
az keyvault key restore --hsm-name yemingmhsm06 --file "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\backup\rsa.key"

<!-- restore -->
$keys = @{PublicKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd1.cer"; PrivateKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd1.key"},
@{PublicKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd2.cer"; PrivateKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd2.key"},
@{PublicKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd3.cer"; PrivateKey = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd3.key"}

Restore-AzManagedHsmSecurityDomain -Name yemingmhsm10 -Keys $keys -SecurityDomainPath C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd.ps.json

<!-- restore key: success -->
az keyvault key restore --hsm-name yemingmhsm06 --file "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\backup\rsa.key"


manual: 10
powershell: 09