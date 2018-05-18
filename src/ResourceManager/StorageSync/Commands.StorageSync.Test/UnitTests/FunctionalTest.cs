using System.Collections;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using System.Security;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Cmdlets;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class FunctionalTest
    {

        private readonly string _computerName;
        public FunctionalTest()
        {
            _computerName = "windows-2012-r2.redmond.corp.microsoft.com";
        }

        [Fact(Skip = "Depends on external artefacts")]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenComputerNameDoestNotExistsItThrows()
        {
            // Prepare
            InvokeCompatibilityCheckCmdlet cmdlet = new InvokeCompatibilityCheckCmdlet()
            {
                ComputerName = "non_existent_computer_name"
            };

            // Exercise
            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            PSRemotingTransportException thrownException = Assert.Throws<PSRemotingTransportException>(() => results.MoveNext());

            // Verify
            Assert.Contains("Cannot find the computer", thrownException.Message);

        }

        [Fact(Skip = "Depends on external artefacts")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenCredentialsAreIncorrectItThrows()
        {
            SecureString secureInvalidPassword = CreateSecureStringFrom("invalid_password");
            InvokeCompatibilityCheckCmdlet cmdlet = new InvokeCompatibilityCheckCmdlet
            {
                ComputerName = _computerName,
                Credential = new PSCredential("invalid_username", secureInvalidPassword)
            };
           

            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            PSRemotingTransportException thrownException = Assert.Throws<PSRemotingTransportException>(() => results.MoveNext());

            // Verify
            Assert.Contains("The user name or password is incorrect.", thrownException.Message);
        }

        private SecureString CreateSecureStringFrom(string s)
        {
            SecureString ss = new SecureString();
            foreach (char c in s)
            {
                ss.AppendChar(c);
            }

            return ss;
        }

        /*
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItRunsAllSystemValidations()
        {
            string username = "testuser";
            string password = "testpassword";
            CreateUserOn(username, password, _computerName);
            
            string shareName = CreateShareOn(_computerName);
            GiveAccessToOn(username, shareName, _computerName);
            
            InvokeStorageSyncEvalCmdlet cmdlet = new InvokeStorageSyncEvalCmdlet
            {
                ComputerName = _computerName,
                Credential = new PSCredential(username, CreateSecureStringFrom(password))
            };


            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            results.MoveNext();
            results.MoveNext();
            results.MoveNext();
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItRunsNamespaceValidations()
        {
            string username = "AFS_test_username";
            string password = "AFS_test_password";
            CreateUserOn(username, password, _computerName);
            
            string shareName = CreateShareOn(_computerName);
            GiveAccessToOn(username, shareName, _computerName);
            
            InvokeStorageSyncEvalCmdlet cmdlet = new InvokeStorageSyncEvalCmdlet
            {
                ComputerName = _computerName,
                Credential = new PSCredential(username, CreateSecureStringFrom(password))
            };


            IEnumerator results = cmdlet.Invoke().GetEnumerator();
            results.MoveNext();
            results.MoveNext();
            results.MoveNext();
        }

        private void CreateUserOn(string username, string password, string computerName)
        {
            IPowershellCommandRunner commandRunner = new PowerShellCommandRunner(computerName, new PSCredential("", CreateSecureStringFrom("")));
            commandRunner.AddScript($"New-LocalUser -Name {username} -Password (ConvertTo-SecureString \"{password}\" -AsPlainText -Force) -AccountExpires ((Get-Date).AddMinutes(2))");
            Collection<PSObject> results = commandRunner.Invoke();
        }
        */

    }
}
