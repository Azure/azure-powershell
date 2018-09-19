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
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Test.Websites.Services
{
    
    public class GithubClientTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRepositories()
        {
            // Setup
            SimpleGithubManagement channel = new SimpleGithubManagement();

            channel.GetRepositoriesThunk = ar => new List<GithubRepository> { new GithubRepository { Name = "userrepo1" } };
            channel.GetOrganizationsThunk = ar => new List<GithubOrganization> { new GithubOrganization { Login = "org1" }, new GithubOrganization { Login = "org2" } };
            channel.GetRepositoriesFromOrgThunk = ar => 
            {
                if (ar.Values["organization"].Equals("org1"))
                {
                    return new List<GithubRepository> { new GithubRepository { Name = "org1repo1" } };
                }
                
                if (ar.Values["organization"].Equals("org2"))
                {
                    return new List<GithubRepository> { new GithubRepository { Name = "org2repo1" } };
                }

                return new List<GithubRepository> { new GithubRepository { Name = "other" } };
            };


            // Test
            CmdletAccessor cmdletAccessor = new CmdletAccessor();
            cmdletAccessor.GithubChannel = channel;
            
            GithubClientAccessor githubClientAccessor = new GithubClientAccessor(cmdletAccessor, null, null);
            var repositories = githubClientAccessor.GetRepositoriesAccessor();

            Assert.Equal(3, repositories.Count);
            Assert.NotNull(repositories.FirstOrDefault(r => r.Name.Equals("userrepo1")));
            Assert.NotNull(repositories.FirstOrDefault(r => r.Name.Equals("org1repo1")));
            Assert.NotNull(repositories.FirstOrDefault(r => r.Name.Equals("org2repo1")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOrUpdateHookAlreadyExists()
        {
            // Setup
            SimpleGithubManagement channel = new SimpleGithubManagement();

            channel.GetRepositoryHooksThunk = ar => new List<GithubRepositoryHook> { new GithubRepositoryHook { Name = "web", Config = new GithubRepositoryHookConfig { Url = "https://$username:password@mynewsite999.scm.azurewebsites.net:443/deploy" } } };

            Site website = new Site
            {
                SiteProperties = new SiteProperties
                {
                    Properties = new List<NameValuePair>
                    {
                        new NameValuePair 
                        {
                            Name = "RepositoryUri",
                            Value = "https://mynewsite999.scm.azurewebsites.net:443"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingUsername",
                            Value = "$username"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingPassword",
                            Value = "password"
                        }
                    }
                }
            };

            // Test
            CmdletAccessor cmdletAccessor = new CmdletAccessor();
            cmdletAccessor.GithubChannel = channel;

            GithubClientAccessor githubClientAccessor = new GithubClientAccessor(cmdletAccessor, null, null);
            
            try
            {
                githubClientAccessor.CreateOrUpdateHookAccessor("owner", "repository", website);
                Assert.True(false, "Fail");
            }
            catch (Exception e)
            {
                Assert.Equal("Link already established", e.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOrUpdateHookCreate()
        {
            // Setup
            SimpleGithubManagement channel = new SimpleGithubManagement();

            GithubRepositoryHook createdHook = null;
            bool tested = false;

            channel.GetRepositoryHooksThunk = ar => new List<GithubRepositoryHook>();
            channel.CreateRepositoryHookThunk = ar =>
            {
                createdHook = ar.Values["hook"] as GithubRepositoryHook;
                createdHook.Id = "id";
                return createdHook;
            };

            channel.TestRepositoryHookThunk = ar =>
            {
                if (ar.Values["id"].Equals("id"))
                {
                    tested = true;
                }
            };

            Site website = new Site
            {
                SiteProperties = new SiteProperties
                {
                    Properties = new List<NameValuePair>
                    {
                        new NameValuePair 
                        {
                            Name = "RepositoryUri",
                            Value = "https://mynewsite999.scm.azurewebsites.net:443"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingUsername",
                            Value = "$username"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingPassword",
                            Value = "password"
                        }
                    }
                }
            };

            // Test
            CmdletAccessor cmdletAccessor = new CmdletAccessor();
            cmdletAccessor.GithubChannel = channel;

            GithubClientAccessor githubClientAccessor = new GithubClientAccessor(cmdletAccessor, null, null);
            githubClientAccessor.CreateOrUpdateHookAccessor("owner", "repository", website);
            Assert.NotNull(createdHook);
            Assert.True(tested);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOrUpdateHookUpdate()
        {
            // Setup
            SimpleGithubManagement channel = new SimpleGithubManagement();

            GithubRepositoryHook createdHook = null;
            bool tested = false;

            channel.GetRepositoryHooksThunk = ar => new List<GithubRepositoryHook> { new GithubRepositoryHook { Name = "web", Config = new GithubRepositoryHookConfig { Url = "https://$username:password@mynewsite999.scm.azurewebsites.net:443/deploy" } } };
            channel.UpdateRepositoryHookThunk = ar =>
            {
                createdHook = ar.Values["hook"] as GithubRepositoryHook;
                createdHook.Id = "id";
                return createdHook;
            };

            channel.TestRepositoryHookThunk = ar =>
            {
                if (ar.Values["id"].Equals("id"))
                {
                    tested = true;
                }
            };

            Site website = new Site
            {
                SiteProperties = new SiteProperties
                {
                    Properties = new List<NameValuePair>
                    {
                        new NameValuePair 
                        {
                            Name = "RepositoryUri",
                            Value = "https://mynewsite999.scm.azurewebsites.net:443"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingUsername",
                            Value = "$usernamenew"
                        },
                        new NameValuePair 
                        {
                            Name = "PublishingPassword",
                            Value = "password"
                        }
                    }
                }
            };

            // Test
            CmdletAccessor cmdletAccessor = new CmdletAccessor();
            cmdletAccessor.GithubChannel = channel;

            GithubClientAccessor githubClientAccessor = new GithubClientAccessor(cmdletAccessor, null, null);
            githubClientAccessor.CreateOrUpdateHookAccessor("owner", "repository", website);
            Assert.NotNull(createdHook);
            Assert.True(tested);
        }
    }

    internal class GithubClientAccessor : GithubClient
    {
        public GithubClientAccessor(IGithubCmdlet pscmdlet, PSCredential githubCredentials, string githubRepository)
            : base (pscmdlet, githubCredentials, githubRepository)
        {
        }

        public IList<GithubRepository> GetRepositoriesAccessor()
        {
            return GetRepositories();
        }

        public void CreateOrUpdateHookAccessor(string owner, string repository, Site website)
        {
            CreateOrUpdateHook(owner, repository, website);
        }
    }

    internal class CmdletAccessor : IGithubCmdlet
    {
        public IGithubServiceManagement GithubChannel { get; set; }

        public bool ShareChannel
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public InvocationInfo MyInvocation
        {
            get { return null; }
        }

        public PSHost Host
        {
            get { throw new NotImplementedException(); }
        }

        public Action<string> GetLogger()
        {
            throw new NotImplementedException();
        }
    }
}