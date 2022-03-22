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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of InstancePool and their operations over its parent. </summary>
    public partial class InstancePoolCollection : ArmCollection, IEnumerable<InstancePool>, IAsyncEnumerable<InstancePool>
    {
        private readonly ClientDiagnostics _instancePoolClientDiagnostics;
        private readonly InstancePoolsRestOperations _instancePoolRestClient;

        /// <summary> Initializes a new instance of the <see cref="InstancePoolCollection"/> class for mocking. </summary>
        protected InstancePoolCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="InstancePoolCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal InstancePoolCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _instancePoolClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", InstancePool.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(InstancePool.ResourceType, out string instancePoolApiVersion);
            _instancePoolRestClient = new InstancePoolsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, instancePoolApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates an instance pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instancePoolName"> The name of the instance pool to be created or updated. </param>
        /// <param name="parameters"> The requested instance pool resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<InstancePool>> CreateOrUpdateAsync(WaitUntil waitUntil, string instancePoolName, InstancePoolData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<InstancePool>(new InstancePoolOperationSource(Client), _instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates an instance pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="instancePoolName"> The name of the instance pool to be created or updated. </param>
        /// <param name="parameters"> The requested instance pool resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<InstancePool> CreateOrUpdate(WaitUntil waitUntil, string instancePoolName, InstancePoolData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, parameters, cancellationToken);
                var operation = new SqlArmOperation<InstancePool>(new InstancePoolOperationSource(Client), _instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an instance pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual async Task<Response<InstancePool>> GetAsync(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.Get");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstancePool(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an instance pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual Response<InstancePool> Get(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.Get");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstancePool(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of instance pools in the resource group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools
        /// Operation Id: InstancePools_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="InstancePool" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<InstancePool> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<InstancePool>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _instancePoolRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new InstancePool(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<InstancePool>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _instancePoolRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new InstancePool(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of instance pools in the resource group
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools
        /// Operation Id: InstancePools_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="InstancePool" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<InstancePool> GetAll(CancellationToken cancellationToken = default)
        {
            Page<InstancePool> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _instancePoolRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new InstancePool(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<InstancePool> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _instancePoolRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new InstancePool(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(instancePoolName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual Response<bool> Exists(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(instancePoolName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual async Task<Response<InstancePool>> GetIfExistsAsync(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<InstancePool>(null, response.GetRawResponse());
                return Response.FromValue(new InstancePool(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// Operation Id: InstancePools_Get
        /// </summary>
        /// <param name="instancePoolName"> The name of the instance pool to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="instancePoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="instancePoolName"/> is null. </exception>
        public virtual Response<InstancePool> GetIfExists(string instancePoolName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(instancePoolName, nameof(instancePoolName));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePoolCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, instancePoolName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<InstancePool>(null, response.GetRawResponse());
                return Response.FromValue(new InstancePool(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<InstancePool> IEnumerable<InstancePool>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<InstancePool> IAsyncEnumerable<InstancePool>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
