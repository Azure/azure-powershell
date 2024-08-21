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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Threading;
using System.Collections.Generic;

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
        AzureRmProfile Profile
        {
            get { return _current; }
        }

        public IAzureContext DefaultContext
        {
            get
            {
                return Profile.DefaultContext;
            }
        }

        public IEnumerable<IAzureEnvironment> Environments
        {
            get
            {
                return Profile.Environments;
            }
        }

        public bool TryAddContext(IAzureContext context, out string name)
        {
            bool local = Profile.TryAddContext(context, out name);
            string remoteName;
            bool remote = DefaultProfile.TryAddContext(context, out remoteName);
            return local || remote;
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

        public bool TryFindContext(IAzureContext context, out string name)
        {
            return Profile.TryFindContext(context, out name);
        }

        public bool TryGetContextName(IAzureContext context, out string name)
        {
            return Profile.TryGetContextName(context, out name);
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

        public bool TrySetContext(IAzureContext context, out string name)
        {

            bool local = Profile.TrySetContext(context, out name);
            string remoteName;
            bool remote = DefaultProfile.TrySetContext(context, out remoteName);
            return local || remote;
        }

        public bool TrySetContext(string name, IAzureContext context)
        {
            bool result = Profile.TrySetContext(name, context);
            DefaultProfile.TrySetContext(name, context);
            return result;
        }

        public bool TrySetDefaultContext(string name)
        {
            bool result = Profile.TrySetDefaultContext(name);
            if (result)
            {
                if (!DefaultProfile.Contexts.ContainsKey(name))
                {
                    var localContext = Profile.Contexts[name];
                    DefaultProfile.TrySetContext(name, localContext);
                }

                DefaultProfile.TrySetDefaultContext(name);
            }

            return result;
        }

        public bool TrySetDefaultContext(IAzureContext context)
        {
            bool result = false;
            if (Profile.TrySetDefaultContext(context))
            {
                result = true;
                DefaultProfile.TrySetDefaultContext(context);
            }

            return result;
        }

        public bool TrySetDefaultContext(string name, IAzureContext context)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(name))
            {
                result = TrySetDefaultContext(context);
            }
            else if (TrySetContext(name, context))
            {
                result = TrySetDefaultContext(name);
            }

            return result;
        }

        public bool TrySetEnvironment(IAzureEnvironment environment, out IAzureEnvironment mergedEnvironment)
        {
            bool result = Profile.TrySetEnvironment(environment, out mergedEnvironment);
            IAzureEnvironment other;
            DefaultProfile.TrySetEnvironment(environment, out other);
            return result;
        }

        public bool HasEnvironment(string name)
        {
            return Profile.HasEnvironment(name);
        }

        public bool TryGetEnvironment(string name, out IAzureEnvironment environment)
        {
            return Profile.TryGetEnvironment(name, out environment);
        }

        public bool TryRemoveEnvironment(string name, out IAzureEnvironment environment)
        {
            bool result = Profile.TryRemoveEnvironment(name, out environment);
            IAzureEnvironment other;
            DefaultProfile.TryRemoveEnvironment(name, out other);
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IFileProvider disposable = Interlocked.Exchange(ref _provider, null);
                if (disposable != null && _default != null)
                {
                    // do not serialize the cache when autosaving the profile
                    _default.Save(disposable, false);
                    _default = null;
                    disposable.Dispose();
                }
            }
        }

        public bool TryCopyProfile(AzureRmProfile other)
        {
            bool result = _current.TryCopyProfile(other);
            foreach (var environment in other.EnvironmentTable)
            {
                if (!AzureEnvironment.PublicEnvironments.ContainsKey(environment.Key))
                {
                    IAzureEnvironment merged;
                    result &= TrySetEnvironment(environment.Value, out merged);
                }
            }

            foreach (var context in other.Contexts)
            {
                result &= TryAddContext(context.Key, context.Value);
            }

            _default.CopyPropertiesFrom(other);
            return result;
        }

        public AzureRmProfile ToProfile()
        {
            return Profile;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
