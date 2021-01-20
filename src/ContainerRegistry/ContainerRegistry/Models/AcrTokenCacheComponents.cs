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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class AcrTokenCacheComponents : IAzureSessionComponentListener
    {
        private IDictionary<string, AcrToken> _component;

        public AcrTokenCacheComponents()
        {
        }

        public IDictionary<string, AcrToken> GetComponent()
        {
            return _component;
        }

        //clear component on clear-azcontext
        public void OnEvent(object sender, EventArgs e)
        {
            _component.Clear();
        }

        public void Register(string componentName, IAzureSession session)
        {
            if (!session.TryGetComponent(componentName, out _component))
            {
                _component = new Dictionary<string, AcrToken>();
                session.RegisterComponentListener(componentName, this);
                session.RegisterComponent<IDictionary<string, AcrToken>>(componentName, () => _component);
            }
        }

        public void Unregister(string componentName, IAzureSession session)
        {
            if (!session.TryGetComponent(componentName, out _component))
            {
                session.UnregisterComponentListener(componentName);
                session.UnregisterComponent<IDictionary<string, AcrToken>>(componentName);
                _component = null;
            }
        }
    }
}
