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

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation
{
    /// <summary>
    ///     Locates services that ViewModels need.
    /// </summary>
    internal interface IServiceLocationManager
    {
        /// <summary>
        ///     Registers a new instance with of a service with the container.
        /// </summary>
        /// <typeparam name="TService">
        ///     The type to register.
        /// </typeparam>
        /// <param name="instance">
        ///     The instance to register.
        /// </param>
        void RegisterInstance<TService>(TService instance);

        /// <summary>
        ///     Registers a new instance with of a service with the container.
        /// </summary>
        /// <param name="type">
        ///     The type to register.
        /// </param>
        /// <param name="instance">
        ///     The instance to register.
        /// </param>
        void RegisterInstance(Type type, object instance);

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <typeparam name="T">Type to map.</typeparam>
        /// <param name="type">Type to map to.</param>
        void RegisterType<T>(Type type);

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <typeparam name="TInterface">The service interface.</typeparam>
        /// <typeparam name="TConcretion">The implementation type.</typeparam>
        void RegisterType<TInterface, TConcretion>() where TConcretion : class, TInterface;

        /// <summary>
        ///     Register type.
        /// </summary>
        /// <param name="type">Type to map.</param>
        /// <param name="registrationValue">Type to map to.</param>
        void RegisterType(Type type, Type registrationValue);
    }
}
