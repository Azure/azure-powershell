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

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Interface for a service that manages the frequency of business logic execution based on configured feature flags.
    /// </summary>
    public interface IFrequencyService
    {
        /// <summary>
        /// Checks if the specified feature is enabled and if it's time to run the business logic based on the feature's frequency. 
        /// If both conditions are met, it runs the specified business action.
        /// </summary>
        /// <param name="featureName">The name of the feature to check.</param>
        /// <param name="businessCheck">A function that returns true if the business logic should be executed.</param>
        /// <param name="business">An action to execute if the business logic should be executed.</param>
        void Check(string featureName, Func<bool> businessCheck, Action business);
        
        /// <summary>
        /// Adds a feature with the specified name and frequency to the service.
        /// </summary>
        /// <param name="featureName">The name of the feature to add.</param>
        /// <param name="frequency">The frequency at which the business logic should be executed for the feature.</param>
        void Add(string featureName, TimeSpan frequency);
        
        /// <summary>
        /// Adds the specified feature to the service's per-PSsession registry.
        /// </summary>
        /// <param name="featureName">The name of the feature to add.</param>
        void AddSession(string featureName);

        /// <summary>
        /// Saves the current state of the service to persistent storage.
        /// </summary>
        void Save();
    }

}
