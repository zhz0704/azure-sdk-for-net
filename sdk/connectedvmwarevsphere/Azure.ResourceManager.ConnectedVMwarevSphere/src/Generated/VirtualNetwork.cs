// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ConnectedVMwarevSphere
{
    /// <summary> A Class representing a VirtualNetwork along with the instance operations that can be performed on it. </summary>
    public partial class VirtualNetwork : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualNetwork"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualNetworkClientDiagnostics;
        private readonly VirtualNetworksRestOperations _virtualNetworkRestClient;
        private readonly VirtualNetworkData _data;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetwork"/> class for mocking. </summary>
        protected VirtualNetwork()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualNetwork"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualNetwork(ArmClient client, VirtualNetworkData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetwork"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualNetwork(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualNetworkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ConnectedVMwarevSphere", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string virtualNetworkApiVersion);
            _virtualNetworkRestClient = new VirtualNetworksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualNetworkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.ConnectedVMwarevSphere/virtualNetworks";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VirtualNetworkData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Implements virtual network GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VirtualNetwork>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Get");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetwork(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements virtual network GET method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualNetwork> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Get");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetwork(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements virtual network DELETE method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="force"> Whether force delete was specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? force = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Delete");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, force, cancellationToken).ConfigureAwait(false);
                var operation = new ConnectedVMwarevSphereArmOperation(_virtualNetworkClientDiagnostics, Pipeline, _virtualNetworkRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, force).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Implements virtual network DELETE method.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="force"> Whether force delete was specified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? force = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Delete");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, force, cancellationToken);
                var operation = new ConnectedVMwarevSphereArmOperation(_virtualNetworkClientDiagnostics, Pipeline, _virtualNetworkRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, force).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<VirtualNetwork>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagHelper.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues[key] = value;
                await TagHelper.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _virtualNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<VirtualNetwork> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagHelper.Get(cancellationToken);
                originalTags.Value.Data.TagValues[key] = value;
                TagHelper.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _virtualNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<VirtualNetwork>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.SetTags");
            scope.Start();
            try
            {
                await TagHelper.DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagHelper.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                await TagHelper.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _virtualNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<VirtualNetwork> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.SetTags");
            scope.Start();
            try
            {
                TagHelper.Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                var originalTags = TagHelper.Get(cancellationToken);
                originalTags.Value.Data.TagValues.ReplaceWith(tags);
                TagHelper.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _virtualNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<VirtualNetwork>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagHelper.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.TagValues.Remove(key);
                await TagHelper.CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _virtualNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/{virtualNetworkName}
        /// Operation Id: VirtualNetworks_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<VirtualNetwork> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagHelper.Get(cancellationToken);
                originalTags.Value.Data.TagValues.Remove(key);
                TagHelper.CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _virtualNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new VirtualNetwork(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
