// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    public static class SecureStringExtensionMethods
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    public class GithubClient : LinkedRevisionControl
    {
        private static Dictionary<string, WebChannelFactory<IGithubServiceManagement>> _factories =
            new Dictionary<string, WebChannelFactory<IGithubServiceManagement>>();

        public const string GithubEndpoint = "https://api.github.com";

        protected GithubRepository LinkedRepository;
        protected PSCredential Credentials;
        protected string RepositoryFullName;
        protected IGithubCmdlet PSCmdlet;

        public GithubClient(
            IGithubCmdlet pscmdlet,
            PSCredential credentials,
            string githubRepository)
        {
            _factories = new Dictionary<string, WebChannelFactory<IGithubServiceManagement>>();
            PSCmdlet = pscmdlet;
            if (PSCmdlet.MyInvocation != null)
            {
                InvocationPath = PSCmdlet.MyInvocation.MyCommand.Module.Path;
            }

            Credentials = credentials;
            RepositoryFullName = githubRepository;
        }

        private void Authenticate()
        {
            EnsureCredentials();

            PSCmdlet.GithubChannel = CreateGithubChannel();
        }

        private void EnsureCredentials()
        {
            // Ensure credentials
            if (Credentials == null)
            {
                Credentials = PSCmdlet.Host.UI.PromptForCredential("Enter username/password",
                                                     "", "", "");
                if (Credentials == null || string.IsNullOrEmpty(Credentials.UserName) || Credentials.Password == null)
                {
                    throw new Exception("Invalid credentials");
                }
            }
        }

        protected IList<GithubRepository> GetRepositories()
        {
            List<GithubRepository> repositories = null;
            InvokeInGithubOperationContext(() => { repositories = PSCmdlet.GithubChannel.GetRepositories(); });

            List<GithubOrganization> organizations = null;
            InvokeInGithubOperationContext(() => { organizations = PSCmdlet.GithubChannel.GetOrganizations(); });

            List<GithubRepository> orgRepositories = new List<GithubRepository>();
            foreach (var organization in organizations)
            {
                List<GithubRepository> currentOrgRepositories = null;
                InvokeInGithubOperationContext(() => { currentOrgRepositories = PSCmdlet.GithubChannel.GetRepositoriesFromOrg(organization.Login); });
                orgRepositories.AddRange(currentOrgRepositories);
            }

            repositories.Sort();
            orgRepositories.Sort();
            repositories.AddRange(orgRepositories);
            return repositories.Where(r => r.Private == false).ToList();
        }

        protected void CreateOrUpdateHook(string owner, string repository, Site website)
        {
            string baseUri = website.GetProperty("repositoryuri");
            string publishingUsername = website.GetProperty("publishingusername");
            string publishingPassword = website.GetProperty("publishingpassword");
            UriBuilder newUri = new UriBuilder(baseUri);
            newUri.UserName = publishingUsername;
            newUri.Password = publishingPassword;
            newUri.Path = "/deploy";

            string deployUri = newUri.ToString();

            List<GithubRepositoryHook> repositoryHooks = new List<GithubRepositoryHook>();
            InvokeInGithubOperationContext(() => { repositoryHooks = PSCmdlet.GithubChannel.GetRepositoryHooks(owner, repository); });

            var existingHook = repositoryHooks.FirstOrDefault(h => h.Name.Equals("web") && new Uri(h.Config.Url).Host.Equals(new Uri(deployUri).Host));
            if (existingHook != null)
            {
                if (!existingHook.Config.Url.Equals(newUri.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    existingHook.Config.Url = deployUri;
                    InvokeInGithubOperationContext(() => PSCmdlet.GithubChannel.UpdateRepositoryHook(owner, repository, existingHook.Id, existingHook));
                    InvokeInGithubOperationContext(() => PSCmdlet.GithubChannel.TestRepositoryHook(owner, repository, existingHook.Id));
                }
                else
                {
                    throw new Exception(Resources.LinkAlreadyEstablished);
                }
            }
            else
            {
                GithubRepositoryHook githubRepositoryHook = new GithubRepositoryHook()
                {
                    Name = "web",
                    Active = true,
                    Events = new List<string> { "push" },
                    Config = new GithubRepositoryHookConfig
                    {
                        Url = deployUri,
                        InsecureSsl = "1",
                        ContentType = "form"
                    }
                };

                InvokeInGithubOperationContext(() => { githubRepositoryHook = PSCmdlet.GithubChannel.CreateRepositoryHook(owner, repository, githubRepositoryHook); });
                InvokeInGithubOperationContext(() => PSCmdlet.GithubChannel.TestRepositoryHook(owner, repository, githubRepositoryHook.Id));
            }  
        }

        private bool RepositoryMatchUri(GithubRepository githubRepository, string remoteUri)
        {
            string cleanUri;
            try
            {
                UriBuilder uri = new UriBuilder(remoteUri) {UserName = null, Password = null};
                cleanUri = uri.ToString();
            }
            catch
            {
                // Fail gracefully to handle ssh scenario
                cleanUri = remoteUri;
            }

            return new UriBuilder(githubRepository.CloneUrl).ToString().Equals(cleanUri, StringComparison.InvariantCultureIgnoreCase)
                || new UriBuilder(githubRepository.HtmlUrl).ToString().Equals(cleanUri, StringComparison.InvariantCultureIgnoreCase)
                || new UriBuilder(githubRepository.GitUrl).ToString().Equals(cleanUri, StringComparison.InvariantCultureIgnoreCase)
                || githubRepository.SshUrl.Equals(cleanUri, StringComparison.InvariantCultureIgnoreCase);
        }

        public override void Init()
        {
            Authenticate();

            if (!IsGitWorkingTree())
            {
                // Init git in current directory
                InitGitOnCurrentDirectory();
            }

            IList<GithubRepository> repositories = GetRepositories();
            if (!string.IsNullOrEmpty(RepositoryFullName))
            {
                LinkedRepository = repositories.FirstOrDefault(r => r.FullName.Equals(RepositoryFullName, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                var remoteUris = Git.GetRemoteUris();
                if (remoteUris.Count == 1)
                {
                    LinkedRepository = repositories.FirstOrDefault(r => RepositoryMatchUri(r, remoteUris.First()));
                }
                else if (remoteUris.Count > 0)
                {
                    // filter repositories to reduce prompt options
                    repositories = repositories.Where(r => remoteUris.Any(u => RepositoryMatchUri(r, u))).ToList();
                }
            }

            if (LinkedRepository == null)
            {
                Collection<ChoiceDescription> choices = new Collection<ChoiceDescription>(repositories.Select(item => new ChoiceDescription(item.FullName)).ToList<ChoiceDescription>());
                var choice = ((PSCmdlet)PSCmdlet).Host.UI.PromptForChoice(
                    "Choose a repository",
                    "",
                    choices,
                    0
                );

                LinkedRepository = repositories.FirstOrDefault(r => r.FullName.Equals(choices[choice].Label));
            }
        }

        public override void Deploy(Site website)
        {
            CreateOrUpdateHook(LinkedRepository.Owner.Login, LinkedRepository.Name, website);
        }

        protected IGithubServiceManagement CreateGithubChannel()
        {
            // If ShareChannel is set by a unit test, use the same channel that
            // was passed into out constructor.  This allows the test to submit
            // a mock that we use for all network calls.
            if (PSCmdlet.ShareChannel)
            {
                return PSCmdlet.GithubChannel;
            }

            return CreateServiceManagementChannel(
                new Uri(GithubEndpoint),
                Credentials.UserName,
                Credentials.Password.ConvertToUnsecureString(),
                PSCmdlet.GetLogger());
        }

        public static IGithubServiceManagement CreateServiceManagementChannel(
            Uri remoteUri,
            string username,
            string password,
            Action<string> logger)
        {
            WebChannelFactory<IGithubServiceManagement> factory;
            if (_factories.ContainsKey(remoteUri.ToString()))
            {
                factory = _factories[remoteUri.ToString()];
            }
            else
            {
                factory = new WebChannelFactory<IGithubServiceManagement>(remoteUri);
                factory.Endpoint.Behaviors.Add(new GithubAutHeaderInserter {Username = username, Password = password});
                factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
                factory.Endpoint.Behaviors.Add(new HttpRestMessageInspector(logger));

                WebHttpBinding wb = factory.Endpoint.Binding as WebHttpBinding;
                wb.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                wb.Security.Mode = WebHttpSecurityMode.Transport;
                wb.MaxReceivedMessageSize = 10000000;

                if (!string.IsNullOrEmpty(username))
                {
                    factory.Credentials.UserName.UserName = username;
                }
                if (!string.IsNullOrEmpty(password))
                {
                    factory.Credentials.UserName.Password = password;
                }

                _factories[remoteUri.ToString()] = factory;
            }

            return factory.CreateChannel();
        }

        /// <summary>
        /// Invoke the given operation within an OperationContextScope if the
        /// channel supports it.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        protected void InvokeInGithubOperationContext(Action action)
        {
            IContextChannel contextChannel = PSCmdlet.GithubChannel as IContextChannel;
            if (contextChannel != null)
            {
                using (new OperationContextScope(contextChannel))
                {
                    action();
                }
            }
            else
            {
                action();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var factory in _factories.Values)
                {
                    factory.Close();
                }
            }
        }
    }
}