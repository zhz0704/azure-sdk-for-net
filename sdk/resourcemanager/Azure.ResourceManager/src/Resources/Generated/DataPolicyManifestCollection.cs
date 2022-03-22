// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of DataPolicyManifest and their operations over its parent. </summary>
    public partial class DataPolicyManifestCollection : ArmCollection, IEnumerable<DataPolicyManifest>, IAsyncEnumerable<DataPolicyManifest>
    {
        private readonly ClientDiagnostics _dataPolicyManifestClientDiagnostics;
        private readonly DataPolicyManifestsRestOperations _dataPolicyManifestRestClient;

        /// <summary> Initializes a new instance of the <see cref="DataPolicyManifestCollection"/> class for mocking. </summary>
        protected DataPolicyManifestCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DataPolicyManifestCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DataPolicyManifestCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dataPolicyManifestClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", DataPolicyManifest.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DataPolicyManifest.ResourceType, out string dataPolicyManifestApiVersion);
            _dataPolicyManifestRestClient = new DataPolicyManifestsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dataPolicyManifestApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Tenant.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Tenant.ResourceType), nameof(id));
        }

        /// <summary>
        /// This operation retrieves the data policy manifest with the given policy mode.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual async Task<Response<DataPolicyManifest>> GetAsync(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.Get");
            scope.Start();
            try
            {
                var response = await _dataPolicyManifestRestClient.GetByPolicyModeAsync(policyMode, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataPolicyManifest(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the data policy manifest with the given policy mode.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual Response<DataPolicyManifest> Get(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.Get");
            scope.Start();
            try
            {
                var response = _dataPolicyManifestRestClient.GetByPolicyMode(policyMode, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataPolicyManifest(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves a list of all the data policy manifests that match the optional given $filter. Valid values for $filter are: &quot;$filter=namespace eq &apos;{0}&apos;&quot;. If $filter is not provided, the unfiltered list includes all data policy manifests for data resource types. If $filter=namespace is provided, the returned list only includes all data policy manifests that have a namespace matching the provided value.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests
        /// Operation Id: DataPolicyManifests_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &quot;namespace eq &apos;{value}&apos;&quot;. If $filter is not provided, no filtering is performed. If $filter=namespace eq &apos;{value}&apos; is provided, the returned list only includes all data policy manifests that have a namespace matching the provided value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataPolicyManifest" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataPolicyManifest> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DataPolicyManifest>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataPolicyManifestRestClient.ListAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataPolicyManifest(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DataPolicyManifest>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataPolicyManifestRestClient.ListNextPageAsync(nextLink, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataPolicyManifest(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// This operation retrieves a list of all the data policy manifests that match the optional given $filter. Valid values for $filter are: &quot;$filter=namespace eq &apos;{0}&apos;&quot;. If $filter is not provided, the unfiltered list includes all data policy manifests for data resource types. If $filter=namespace is provided, the returned list only includes all data policy manifests that have a namespace matching the provided value.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests
        /// Operation Id: DataPolicyManifests_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &quot;namespace eq &apos;{value}&apos;&quot;. If $filter is not provided, no filtering is performed. If $filter=namespace eq &apos;{value}&apos; is provided, the returned list only includes all data policy manifests that have a namespace matching the provided value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataPolicyManifest" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataPolicyManifest> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<DataPolicyManifest> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataPolicyManifestRestClient.List(filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataPolicyManifest(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DataPolicyManifest> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataPolicyManifestRestClient.ListNextPage(nextLink, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataPolicyManifest(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policyMode, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual Response<bool> Exists(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policyMode, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual async Task<Response<DataPolicyManifest>> GetIfExistsAsync(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _dataPolicyManifestRestClient.GetByPolicyModeAsync(policyMode, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DataPolicyManifest>(null, response.GetRawResponse());
                return Response.FromValue(new DataPolicyManifest(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}
        /// Operation Id: DataPolicyManifests_GetByPolicyMode
        /// </summary>
        /// <param name="policyMode"> The policy mode of the data policy manifest to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyMode"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyMode"/> is null. </exception>
        public virtual Response<DataPolicyManifest> GetIfExists(string policyMode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyMode, nameof(policyMode));

            using var scope = _dataPolicyManifestClientDiagnostics.CreateScope("DataPolicyManifestCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _dataPolicyManifestRestClient.GetByPolicyMode(policyMode, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DataPolicyManifest>(null, response.GetRawResponse());
                return Response.FromValue(new DataPolicyManifest(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DataPolicyManifest> IEnumerable<DataPolicyManifest>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DataPolicyManifest> IAsyncEnumerable<DataPolicyManifest>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
