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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions.ADDomain;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public abstract class BaseAzureServiceADDomainExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
        protected const string DomainExtensionNamespace = "Microsoft.Windows.Azure.Extensions";
        protected const string DomainExtensionType = "ADDomain";

        protected const string ADDomainExtensionNoun = "AzureServiceADDomainExtension";
        protected const string ADDomainExtensionConfigNoun = "AzureServiceADDomainExtensionConfig";

        protected const string DomainParameterSet = "JoinDomainUsingEnumOptions";
        protected const string DomainThumbprintParameterSet = "JoinDomainUsingEnumOptionsAndThumbprint";
        protected const string DomainJoinOptionParameterSet = "JoinDomainUsingJoinOption";
        protected const string DomainJoinOptionThumbprintParameterSet = "JoinDomainUsingJoinOptionAndThumbprint";
        protected const string WorkgroupParameterSet = "WorkGroupName";
        protected const string WorkgroupThumbprintParameterSet = "WorkGroupNameThumbprint";

        protected PublicConfig publicConfig;
        protected PrivateConfig privateConfig;

        protected PublicConfig PublicConfig
        {
            get
            {
                if (this.publicConfig == null)
                {
                    this.publicConfig = new PublicConfig();
                }

                return this.publicConfig;
            }

            private set
            {
                this.publicConfig = value;
            }
        }

        protected PrivateConfig PrivateConfig
        {
            get
            {
                if (this.privateConfig == null)
                {
                    this.privateConfig = new PrivateConfig();
                }

                return this.privateConfig;
            }

            private set
            {
                this.privateConfig = value;
            }
        }

        public virtual string DomainName
        {
            get
            {
                return (Options & JoinOptions.JoinDomain) == JoinOptions.JoinDomain ? PublicConfig.Name : null;
            }
            set
            {
                /// To make the lowest bit of 'Options' always '1'.
                Options |= JoinOptions.JoinDomain;
                PublicConfig.Name = value;
            }
        }

        public virtual string WorkgroupName
        {
            get
            {
                return (Options & JoinOptions.JoinDomain) != JoinOptions.JoinDomain ? PublicConfig.Name : null;
            }
            set
            {
                /// It is to set the lowest bit to 0 without using shift operation.
                /// Since 'JoinOptions.JoinDomain' is equal to '1', the operation
                /// 'Options ^ JoinOptions.JoinDomain' will flip the last bit of
                /// 'Options' ('0' -> '1', '1' -> '0').
                /// And then doing an '&' operation with the original value will
                /// make the last bit always '0'.
                Options &= (Options ^ JoinOptions.JoinDomain);
                PublicConfig.Name = value;
            }
        }

        public virtual JoinOptions Options
        {
            get
            {
                return (JoinOptions)PublicConfig.Options;
            }
            set
            {
                PublicConfig.Options = (uint)value;
            }
        }

        public virtual uint JoinOption
        {
            get
            {
                return PublicConfig.Options;
            }
            set
            {
                PublicConfig.Options = value;
            }
        }

        public virtual string OUPath
        {
            get
            {
                return PublicConfig.OUPath;
            }
            set
            {
                PublicConfig.OUPath = value;
            }
        }

        public virtual SwitchParameter Restart
        {
            get
            {
                return PublicConfig.Restart;
            }
            set
            {
                PublicConfig.Restart = value;
            }
        }

        public virtual PSCredential Credential
        {
            get
            {
                return new PSCredential(PublicConfig.User, GetSecurePassword(PrivateConfig.Password));
            }
            set
            {
                PublicConfig.User = value.UserName;
                PrivateConfig.Password = value.Password == null ? string.Empty : value.Password.ConvertToUnsecureString();
            }
        }

        public virtual PSCredential UnjoinDomainCredential
        {
            get
            {
                return new PSCredential(PublicConfig.User, GetSecurePassword(PrivateConfig.UnjoinDomainPassword));
            }
            set
            {
                PublicConfig.UnjoinDomainUser = value.UserName;
                PrivateConfig.UnjoinDomainPassword = value.Password == null ? string.Empty : value.Password.ConvertToUnsecureString();
            }
        }

        public BaseAzureServiceADDomainExtensionCmdlet()
            : base()
        {
            PrivateConfig.Password = string.Empty;
            PrivateConfig.UnjoinDomainPassword = string.Empty;
        }

        protected override void ValidateParameters()
        {
            base.ValidateParameters();
            ProviderNamespace = DomainExtensionNamespace;
            ExtensionName = DomainExtensionType;
        }

        protected override void ValidateConfiguration()
        {
            PublicConfiguration = Serialize(PublicConfig);
            PrivateConfiguration = Serialize(PrivateConfig);
        }

        protected override ExtensionContext GetContext(OperationStatusResponse op, ExtensionRole role, HostedServiceListExtensionsResponse.Extension ext)
        {
            var config = Deserialize(ext.PublicConfiguration, typeof(PublicConfig)) as PublicConfig;
            return new ADDomainExtensionContext
            {
                OperationId = op.Id,
                OperationDescription = CommandRuntime.ToString(),
                OperationStatus = op.Status.ToString(),
                Extension = ext.Type,
                ProviderNameSpace = ext.ProviderNamespace,
                Id = ext.Id,
                Role = role,
                Name = config.Name,
                OUPath = config.OUPath,
                JoinOption = config.Options,
                User = config.User,
                UnjoinDomainUser = config.UnjoinDomainUser,
                Restart = config.Restart,
                Version = ext.Version
            };
        }
    }
}
