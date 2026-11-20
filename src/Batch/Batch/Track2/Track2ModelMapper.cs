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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Track2.Workarounds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AzureETag = Azure.ETag;
using ResourceIdentifier = Azure.Core.ResourceIdentifier;
using T1 = Microsoft.Azure.Batch;
using T1C = Microsoft.Azure.Batch.Common;
using T2 = Azure.Compute.Batch;

namespace Microsoft.Azure.Commands.Batch.Track2
{
    /// <summary>
    /// Maps between Track 2 (Azure.Compute.Batch) models and the PS objects, so the PS objects stay the same: names,
    /// types and values. Track 2 -> PS goes through each PS class's public constructors and setters, so the objects are
    /// backed by Track 1 objects as today and can still be passed to cmdlets that use Track 1. PS -> Track 2 builds the
    /// objects for requests, with the same JSON as Track 1 sends. This file has the rules and the classes that several
    /// groups of cmdlets share; each group adds its own classes when it moves to Track 2.
    /// </summary>
    internal static partial class Track2ModelMapper
    {
        #region Rules

        /// <summary>
        /// Track 2 uses DateTimeOffset, and default(DateTimeOffset) for a required value the service didn't send (for
        /// example with -Select). Track 1 gave a UTC DateTime, or null.
        /// </summary>
        internal static DateTime? ToDateTimeOrNull(DateTimeOffset? value)
        {
            return value.HasValue && value.Value != default(DateTimeOffset) ? value.Value.UtcDateTime : (DateTime?)null;
        }

        internal static DateTime ToDateTime(DateTimeOffset value)
        {
            return value.UtcDateTime;
        }

        /// <summary>A URL as the service sent it.</summary>
        internal static string ToUrl(Uri uri)
        {
            return uri?.OriginalString;
        }

        internal static string ToETag(AzureETag etag)
        {
            return etag == default(AzureETag) ? null : etag.ToString();
        }

        /// <summary>
        /// Whether the service sent a property: with -Select, Track 2 gives 0 or false for a required value the service
        /// didn't send, where Track 1 gave null. <paramref name="selected"/> is null without -Select.
        /// </summary>
        internal static bool IsSelected(ISet<string> selected, string restPropertyName)
        {
            return selected == null || selected.Contains(restPropertyName);
        }

        /// <summary>
        /// A list the service sent, mapped; null when the service didn't send it, as with Track 1. Azure.Compute.Batch
        /// keeps a list the service sent (even an empty one) as a List, and uses an empty list of its own otherwise.
        /// </summary>
        internal static List<TOut> ToList<TIn, TOut>(IEnumerable<TIn> items, Func<TIn, TOut> map)
        {
            if (items == null)
            {
                return null;
            }

            List<TOut> list = items.Select(map).ToList();
            return list.Count == 0 && !(items is List<TIn>) ? null : list;
        }

        /// <summary>
        /// Name and value pairs (environment settings, metadata) as the dictionary the PS objects show, or null when the
        /// service didn't send them (same rule as <see cref="ToList"/>).
        /// </summary>
        internal static IDictionary ToDictionary<T>(IEnumerable<T> items, Func<T, string> name, Func<T, string> value)
        {
            if (items == null || (!(items is List<T>) && !items.Any()))
            {
                return null;
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (T item in items)
            {
                dictionary.Add(name(item), value(item));
            }

            return dictionary;
        }

        /// <summary>
        /// Puts the items of a PS collection in a list of a Track 2 request. An empty PS collection is sent as an empty
        /// list, as Track 1 does (for an update that removes the values); Azure.Compute.Batch sends a list only once it
        /// has been changed, so for an empty collection this adds and removes one item.
        /// </summary>
        internal static void SetList<T>(IList<T> target, IEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }

            int count = 0;
            foreach (T item in items)
            {
                target.Add(item);
                count++;
            }

            if (count == 0)
            {
                target.Add(default(T));
                target.RemoveAt(target.Count - 1);
            }
        }

        #endregion

        #region Track 2 -> PS

        internal static PSApplicationPackageReference ToPS(T2.BatchApplicationPackageReference reference)
        {
            return reference == null ? null : new PSApplicationPackageReference { ApplicationId = reference.ApplicationId, Version = reference.Version };
        }

        internal static IDictionary ToPS(IEnumerable<T2.BatchMetadataItem> metadata)
        {
            return ToDictionary(metadata, m => m.Name, m => m.Value);
        }

        internal static PSStartTask ToPS(T2.BatchStartTask task)
        {
            if (task == null)
            {
                return null;
            }

            return new PSStartTask(task.CommandLine)
            {
                ContainerSettings = ToPS(task.ContainerSettings),
                EnvironmentSettings = ToDictionary(task.EnvironmentSettings, e => e.Name, e => e.Value),
                MaxTaskRetryCount = task.MaxTaskRetryCount,
                ResourceFiles = ToList(task.ResourceFiles, ToPS),
                UserIdentity = ToPS(task.UserIdentity),
                WaitForSuccess = task.WaitForSuccess,
            };
        }

        /// <summary>
        /// PSResourceFile has no public constructor: New-AzBatchResourceFile builds it with Track 1's factory methods, so
        /// this does the same.
        /// </summary>
        internal static PSResourceFile ToPS(T2.ResourceFile file)
        {
            if (file == null)
            {
                return null;
            }

            T1.ComputeNodeIdentityReference identity = file.IdentityReference == null
                ? null
                : new T1.ComputeNodeIdentityReference { ResourceId = file.IdentityReference.ResourceId?.ToString() };
            T1.ResourceFile track1;
            if (file.HttpUri != null)
            {
                track1 = identity == null
                    ? T1.ResourceFile.FromUrl(ToUrl(file.HttpUri), file.FilePath, file.FileMode)
                    : T1.ResourceFile.FromUrl(ToUrl(file.HttpUri), identity, file.FilePath, file.FileMode);
            }
            else if (file.StorageContainerUri != null)
            {
                track1 = identity == null
                    ? T1.ResourceFile.FromStorageContainerUrl(ToUrl(file.StorageContainerUri), file.FilePath, file.BlobPrefix, file.FileMode)
                    : T1.ResourceFile.FromStorageContainerUrl(ToUrl(file.StorageContainerUri), identity, file.FilePath, file.BlobPrefix, file.FileMode);
            }
            else
            {
                track1 = T1.ResourceFile.FromAutoStorageContainer(file.AutoStorageContainerName, file.FilePath, file.BlobPrefix, file.FileMode);
            }

            return new PSResourceFile(track1);
        }

        internal static PSUserIdentity ToPS(T2.UserIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            if (identity.AutoUser != null)
            {
                return new PSUserIdentity(new PSAutoUserSpecification(
                    Track2Enums.ToTrack1<T1C.AutoUserScope>(identity.AutoUser.Scope),
                    Track2Enums.ToTrack1<T1C.ElevationLevel>(identity.AutoUser.ElevationLevel)));
            }

            return new PSUserIdentity(identity.Username);
        }

        /// <summary>
        /// The bind mounts go through the constructor, into the Track 1 object, as when Track 1 reads them: a list set
        /// through the ContainerHostBatchBindMounts property isn't sent by Track 1.
        /// </summary>
        internal static PSTaskContainerSettings ToPS(T2.BatchTaskContainerSettings settings)
        {
            if (settings == null)
            {
                return null;
            }

            return new PSTaskContainerSettings(
                settings.ImageName,
                settings.ContainerRunOptions,
                ToPS(settings.Registry),
                Track2Enums.ToTrack1<T1C.ContainerWorkingDirectory>(settings.WorkingDirectory),
                ToList(settings.ContainerHostBatchBindMounts, m => new T1.ContainerHostBatchBindMountEntry
                {
                    IsReadOnly = m.IsReadOnly,
                    Source = m.Source?.ToString(),
                }));
        }

        internal static PSContainerRegistry ToPS(T2.ContainerRegistryReference registry)
        {
            return registry == null
                ? null
                : new PSContainerRegistry(registry.Username, registry.Password, ToUrl(registry.RegistryServerUri), ToPS(registry.IdentityReference));
        }

        internal static PSComputeNodeIdentityReference ToPS(T2.BatchNodeIdentityReference identity)
        {
            return identity == null ? null : new PSComputeNodeIdentityReference { ResourceId = identity.ResourceId?.ToString() };
        }

        #endregion

        #region PS -> Track 2

        internal static T2.BatchApplicationPackageReference ToTrack2(PSApplicationPackageReference reference)
        {
            return reference == null ? null : new T2.BatchApplicationPackageReference(reference.ApplicationId) { Version = reference.Version };
        }

        /// <summary>The metadata of a PS object (a dictionary), for a request.</summary>
        internal static void SetMetadata(IList<T2.BatchMetadataItem> target, IDictionary metadata)
        {
            SetList(target, Entries(metadata)?.Select(item => new T2.BatchMetadataItem(item.Key.ToString(), item.Value?.ToString())));
        }

        // The entries of a PS dictionary (IDictionary's own enumerator: a Dictionary<,> enumerated as IEnumerable gives
        // KeyValuePair items, not DictionaryEntry), or null.
        private static IEnumerable<DictionaryEntry> Entries(IDictionary dictionary)
        {
            return dictionary == null ? null : EntriesOf(dictionary);
        }

        private static IEnumerable<DictionaryEntry> EntriesOf(IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                yield return entry;
            }
        }

        internal static T2.BatchStartTask ToTrack2(PSStartTask task)
        {
            if (task == null)
            {
                return null;
            }

            T2.BatchStartTask track2 = new T2.BatchStartTask(task.CommandLine)
            {
                ContainerSettings = ToTrack2(task.ContainerSettings),
                MaxTaskRetryCount = task.MaxTaskRetryCount,
                UserIdentity = ToTrack2(task.UserIdentity),
                WaitForSuccess = task.WaitForSuccess,
            };
            SetList(track2.ResourceFiles, task.ResourceFiles?.Select(ToTrack2));
            SetList(track2.EnvironmentSettings, Entries(task.EnvironmentSettings)
                ?.Select(setting => new T2.EnvironmentSetting(setting.Key.ToString()) { Value = setting.Value?.ToString() }));
            return track2;
        }

        /// <summary>URLs go as typed (<see cref="Track2Workarounds.ToExactUrl"/>), as with Track 1.</summary>
        internal static T2.ResourceFile ToTrack2(PSResourceFile file)
        {
            if (file == null)
            {
                return null;
            }

            return new T2.ResourceFile
            {
                AutoStorageContainerName = file.AutoStorageContainerName,
                BlobPrefix = file.BlobPrefix,
                FileMode = file.FileMode,
                FilePath = file.FilePath,
                HttpUri = Track2Workarounds.ToExactUrl(file.HttpUrl),
                IdentityReference = ToTrack2(file.IdentityReference),
                StorageContainerUri = Track2Workarounds.ToExactUrl(file.StorageContainerUrl),
            };
        }

        internal static T2.UserIdentity ToTrack2(PSUserIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            return new T2.UserIdentity
            {
                Username = identity.UserName,
                AutoUser = identity.AutoUser == null ? null : new T2.AutoUserSpecification
                {
                    Scope = Track2Enums.ToTrack2OrNull<T2.AutoUserScope>(identity.AutoUser.Scope),
                    ElevationLevel = Track2Enums.ToTrack2OrNull<T2.ElevationLevel>(identity.AutoUser.ElevationLevel),
                },
            };
        }

        internal static T2.BatchTaskContainerSettings ToTrack2(PSTaskContainerSettings settings)
        {
            if (settings == null)
            {
                return null;
            }

            T2.BatchTaskContainerSettings track2 = new T2.BatchTaskContainerSettings(settings.ImageName)
            {
                ContainerRunOptions = settings.ContainerRunOptions,
                Registry = ToTrack2(settings.Registry),
                WorkingDirectory = Track2Enums.ToTrack2OrNull<T2.ContainerWorkingDirectory>(settings.WorkingDirectory),
            };
            SetList(track2.ContainerHostBatchBindMounts, settings.ContainerHostBatchBindMounts?.Select(m => new T2.ContainerHostBatchBindMountEntry
            {
                IsReadOnly = m.IsReadOnly,
                Source = Track2Enums.FromString<T2.ContainerHostDataPath>(m.Source),
            }));
            return track2;
        }

        /// <summary>The registry server goes as typed (<see cref="Track2Workarounds.ToExactUrl"/>), as with Track 1.</summary>
        internal static T2.ContainerRegistryReference ToTrack2(PSContainerRegistry registry)
        {
            if (registry == null)
            {
                return null;
            }

            return new T2.ContainerRegistryReference
            {
                IdentityReference = ToTrack2(registry.IdentityReference),
                Password = registry.Password,
                RegistryServerUri = Track2Workarounds.ToExactUrl(registry.RegistryServer),
                Username = registry.UserName,
            };
        }

        internal static T2.BatchNodeIdentityReference ToTrack2(PSComputeNodeIdentityReference identity)
        {
            return identity == null
                ? null
                : new T2.BatchNodeIdentityReference { ResourceId = identity.ResourceId == null ? null : new ResourceIdentifier(identity.ResourceId) };
        }

        #endregion
    }
}
