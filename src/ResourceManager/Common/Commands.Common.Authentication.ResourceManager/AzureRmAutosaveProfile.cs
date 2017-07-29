using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    public class AzureRmAutosaveProfile : IProfileOperations, IDisposable
    {
        AzureRmProfile _current, _default;
        IFileProvider _provider;

        AzureRmProfile DefaultProfile
        {
            get
            {
                if (_default == null)
                {
                    _default = new AzureRmProfile(_provider);
                }
                return _default;
            }
        }

        public AzureRmAutosaveProfile(AzureRmProfile currentProfile, IFileProvider defaultProvider)
        {
            _current = currentProfile;
            _provider = defaultProvider;
        }

        public AzureRmProfile Profile
        {
            get
            {
                return _current;
            }
        }

        public string GetContextName(IAzureContext context)
        {
            return Profile.GetContextName(context);
        }

        public bool TryAddContext(string name, IAzureContext context)
        {
            bool result = false;
            if (!(Profile.Contexts.ContainsKey(name) || DefaultProfile.Contexts.ContainsKey(name)))
            {
                result = Profile.TryAddContext(name, context) && DefaultProfile.TryAddContext(name, context);
            }

            return result;
        }

        public bool TryRemoveContext(string name)
        {
            bool result = false;

            if (Profile.TryRemoveContext(name))
            {
                DefaultProfile.TryRemoveContext(name);
                result = true;
            }

            return result;
        }

        public bool TryRenameContext(string sourceName, string targetName)
        {
            bool result = false;
            if (Profile.TryRenameContext(sourceName, targetName))
            {
                DefaultProfile.TryRenameContext(sourceName, targetName);
                result = true;
            }

            return result;
        }

        public bool TrySetContext(string name, IAzureContext context)
        {
            bool result = false;

        }

        public bool TrySetDefaultContext(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
