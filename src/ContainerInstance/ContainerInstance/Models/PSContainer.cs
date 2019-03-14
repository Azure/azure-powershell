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

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Azure.Management.ContainerInstance.Models;

namespace Microsoft.Azure.Commands.ContainerInstance.Models
{
    /// <summary>
    /// PSObject for a container.
    /// </summary>
    public class PSContainer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public IList<string> Command { get; set; }

        /// <summary>
        /// Gets or sets the ports.
        /// </summary>
        public IList<int> Ports { get; set; }

        /// <summary>
        /// Gets or sets the environment variables.
        /// </summary>
        public IDictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// Gets or sets the current state.
        /// </summary>
        public PSContainerState CurrentState { get; set; }

        /// <summary>
        /// Gets or sets the previous state.
        /// </summary>
        public PSContainerState PreviousState { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public IList<PSEvent> Events { get; set; }

        /// <summary>
        /// Gets or sets the restart count.
        /// </summary>
        public int? RestartCount { get; set; }

        /// <summary>
        /// Gets or sets the CPU.
        /// </summary>
        public double? Cpu { get; set; }

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        public double? MemoryInGb { get; set; }

        /// <summary>
        /// Gets or sets the CPU limit.
        /// </summary>
        public double? CpuLimit { get; set; }

        /// <summary>
        /// Gets or sets the memory limit.
        /// </summary>
        public double? MemoryLimitInGb { get; set; }

        /// <summary>
        /// Gets or sets the volume mounts.
        /// </summary>
        public IList<VolumeMount> VolumeMounts { get; set; }

        /// <summary>
        /// Build a PSContainer from a Container object.
        /// </summary>
        public static PSContainer FromContainer(Container container)
        {
            return new PSContainer()
            {
                Name = container?.Name,
                Image = container?.Image,
                Command = container?.Command,
                Ports = container?.Ports?.Select(p => p.Port).ToList(),
                EnvironmentVariables = container?.EnvironmentVariables?.ToDictionary(e => e.Name, e => e.Value),
                CurrentState = ContainerInstanceAutoMapperProfile.Mapper.Map<PSContainerState>(container?.InstanceView?.CurrentState),
                PreviousState = ContainerInstanceAutoMapperProfile.Mapper.Map<PSContainerState>(container?.InstanceView?.PreviousState),
                Events = container?.InstanceView?.Events?.Select(e => ContainerInstanceAutoMapperProfile.Mapper.Map<PSEvent>(e)).ToList(),
                RestartCount = container?.InstanceView?.RestartCount,
                Cpu = container?.Resources?.Requests?.Cpu,
                MemoryInGb = container?.Resources?.Requests?.MemoryInGB,
                CpuLimit = container?.Resources?.Limits?.Cpu,
                MemoryLimitInGb = container?.Resources?.Limits?.MemoryInGB,
                VolumeMounts = container?.VolumeMounts
            };
        }
    }
}
