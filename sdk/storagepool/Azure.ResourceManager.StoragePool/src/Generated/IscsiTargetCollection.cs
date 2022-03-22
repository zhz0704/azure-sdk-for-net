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
using Azure.ResourceManager.StoragePool.Models;

namespace Azure.ResourceManager.StoragePool
{
    /// <summary> A class representing collection of IscsiTarget and their operations over its parent. </summary>
    public partial class IscsiTargetCollection : ArmCollection, IEnumerable<IscsiTarget>, IAsyncEnumerable<IscsiTarget>
    {
        private readonly ClientDiagnostics _iscsiTargetClientDiagnostics;
        private readonly IscsiTargetsRestOperations _iscsiTargetRestClient;

        /// <summary> Initializes a new instance of the <see cref="IscsiTargetCollection"/> class for mocking. </summary>
        protected IscsiTargetCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="IscsiTargetCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal IscsiTargetCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _iscsiTargetClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.StoragePool", IscsiTarget.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(IscsiTarget.ResourceType, out string iscsiTargetApiVersion);
            _iscsiTargetRestClient = new IscsiTargetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, iscsiTargetApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != DiskPool.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, DiskPool.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or Update an iSCSI Target.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="iscsiTargetCreatePayload"> Request payload for iSCSI Target create operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> or <paramref name="iscsiTargetCreatePayload"/> is null. </exception>
        public virtual async Task<ArmOperation<IscsiTarget>> CreateOrUpdateAsync(WaitUntil waitUntil, string iscsiTargetName, IscsiTargetCreate iscsiTargetCreatePayload, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));
            Argument.AssertNotNull(iscsiTargetCreatePayload, nameof(iscsiTargetCreatePayload));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _iscsiTargetRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, iscsiTargetCreatePayload, cancellationToken).ConfigureAwait(false);
                var operation = new StoragePoolArmOperation<IscsiTarget>(new IscsiTargetOperationSource(Client), _iscsiTargetClientDiagnostics, Pipeline, _iscsiTargetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, iscsiTargetCreatePayload).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create or Update an iSCSI Target.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="iscsiTargetCreatePayload"> Request payload for iSCSI Target create operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> or <paramref name="iscsiTargetCreatePayload"/> is null. </exception>
        public virtual ArmOperation<IscsiTarget> CreateOrUpdate(WaitUntil waitUntil, string iscsiTargetName, IscsiTargetCreate iscsiTargetCreatePayload, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));
            Argument.AssertNotNull(iscsiTargetCreatePayload, nameof(iscsiTargetCreatePayload));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _iscsiTargetRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, iscsiTargetCreatePayload, cancellationToken);
                var operation = new StoragePoolArmOperation<IscsiTarget>(new IscsiTargetOperationSource(Client), _iscsiTargetClientDiagnostics, Pipeline, _iscsiTargetRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, iscsiTargetCreatePayload).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Get an iSCSI Target.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual async Task<Response<IscsiTarget>> GetAsync(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.Get");
            scope.Start();
            try
            {
                var response = await _iscsiTargetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IscsiTarget(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an iSCSI Target.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual Response<IscsiTarget> Get(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.Get");
            scope.Start();
            try
            {
                var response = _iscsiTargetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new IscsiTarget(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get iSCSI Targets in a Disk pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets
        /// Operation Id: IscsiTargets_ListByDiskPool
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="IscsiTarget" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<IscsiTarget> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<IscsiTarget>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _iscsiTargetRestClient.ListByDiskPoolAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new IscsiTarget(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<IscsiTarget>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _iscsiTargetRestClient.ListByDiskPoolNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new IscsiTarget(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get iSCSI Targets in a Disk pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets
        /// Operation Id: IscsiTargets_ListByDiskPool
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="IscsiTarget" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<IscsiTarget> GetAll(CancellationToken cancellationToken = default)
        {
            Page<IscsiTarget> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _iscsiTargetRestClient.ListByDiskPool(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new IscsiTarget(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<IscsiTarget> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _iscsiTargetRestClient.ListByDiskPoolNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new IscsiTarget(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(iscsiTargetName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual Response<bool> Exists(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(iscsiTargetName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual async Task<Response<IscsiTarget>> GetIfExistsAsync(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _iscsiTargetRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<IscsiTarget>(null, response.GetRawResponse());
                return Response.FromValue(new IscsiTarget(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StoragePool/diskPools/{diskPoolName}/iscsiTargets/{iscsiTargetName}
        /// Operation Id: IscsiTargets_Get
        /// </summary>
        /// <param name="iscsiTargetName"> The name of the iSCSI Target. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="iscsiTargetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="iscsiTargetName"/> is null. </exception>
        public virtual Response<IscsiTarget> GetIfExists(string iscsiTargetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(iscsiTargetName, nameof(iscsiTargetName));

            using var scope = _iscsiTargetClientDiagnostics.CreateScope("IscsiTargetCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _iscsiTargetRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, iscsiTargetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<IscsiTarget>(null, response.GetRawResponse());
                return Response.FromValue(new IscsiTarget(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<IscsiTarget> IEnumerable<IscsiTarget>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<IscsiTarget> IAsyncEnumerable<IscsiTarget>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
