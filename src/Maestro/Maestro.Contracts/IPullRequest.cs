// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.DotNet.DarcLib;
using System.Collections.Generic;

namespace Maestro.Contracts
{
    public interface IPullRequest
    {
        string Url { get; set; }

        List<(UpdateAssetsParameters update, List<DependencyUpdate> deps)> RequiredUpdates { get; set; }
    }

    [DataContract]
    public class UpdateAssetsParameters
    {
        [DataMember]
        public Guid SubscriptionId { get; set; }

        [DataMember]
        public int BuildId { get; set; }

        [DataMember]
        public string SourceSha { get; set; }

        [DataMember]
        public string SourceRepo { get; set; }

        [DataMember]
        public List<Asset> Assets { get; set; }

        /// <summary>
        ///     If true, this is a coherency update and not driven by specific
        ///     subscription ids (e.g. could be multiple if driven by a batched subscription)
        /// </summary>
        [DataMember]
        public bool IsCoherencyUpdate { get; set; }
    }
}