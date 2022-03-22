// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteSlotSourcecontrol along with the instance operations that can be performed on it. </summary>
    public partial class SiteSlotSourcecontrol : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteSlotSourcecontrol"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteSlotSourcecontrolWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotSourcecontrolWebAppsRestClient;
        private readonly SiteSourceControlData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotSourcecontrol"/> class for mocking. </summary>
        protected SiteSlotSourcecontrol()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteSlotSourcecontrol"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteSlotSourcecontrol(ArmClient client, SiteSourceControlData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotSourcecontrol"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteSlotSourcecontrol(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotSourcecontrolWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string siteSlotSourcecontrolWebAppsApiVersion);
            _siteSlotSourcecontrolWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, siteSlotSourcecontrolWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/sourcecontrols";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SiteSourceControlData Data
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
        /// Description for Gets the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_GetSourceControlSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SiteSlotSourcecontrol>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotSourcecontrolWebAppsRestClient.GetSourceControlSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotSourcecontrol(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_GetSourceControlSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteSlotSourcecontrol> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Get");
            scope.Start();
            try
            {
                var response = _siteSlotSourcecontrolWebAppsRestClient.GetSourceControlSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotSourcecontrol(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Deletes the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_DeleteSourceControlSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="additionalFlags"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string additionalFlags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Delete");
            scope.Start();
            try
            {
                var response = await _siteSlotSourcecontrolWebAppsRestClient.DeleteSourceControlSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, additionalFlags, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation(response);
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
        /// Description for Deletes the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_DeleteSourceControlSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="additionalFlags"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, string additionalFlags = null, CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Delete");
            scope.Start();
            try
            {
                var response = _siteSlotSourcecontrolWebAppsRestClient.DeleteSourceControlSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, additionalFlags, cancellationToken);
                var operation = new AppServiceArmOperation(response);
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
        /// Description for Updates the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_UpdateSourceControlSlot
        /// </summary>
        /// <param name="siteSourceControl"> JSON representation of a SiteSourceControl object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteSourceControl"/> is null. </exception>
        public virtual async Task<Response<SiteSlotSourcecontrol>> UpdateAsync(SiteSourceControlData siteSourceControl, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteSourceControl, nameof(siteSourceControl));

            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Update");
            scope.Start();
            try
            {
                var response = await _siteSlotSourcecontrolWebAppsRestClient.UpdateSourceControlSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotSourcecontrol(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_UpdateSourceControlSlot
        /// </summary>
        /// <param name="siteSourceControl"> JSON representation of a SiteSourceControl object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteSourceControl"/> is null. </exception>
        public virtual Response<SiteSlotSourcecontrol> Update(SiteSourceControlData siteSourceControl, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteSourceControl, nameof(siteSourceControl));

            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.Update");
            scope.Start();
            try
            {
                var response = _siteSlotSourcecontrolWebAppsRestClient.UpdateSourceControlSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl, cancellationToken);
                return Response.FromValue(new SiteSlotSourcecontrol(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Updates the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_CreateOrUpdateSourceControlSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteSourceControl"> JSON representation of a SiteSourceControl object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteSourceControl"/> is null. </exception>
        public virtual async Task<ArmOperation<SiteSlotSourcecontrol>> CreateOrUpdateAsync(WaitUntil waitUntil, SiteSourceControlData siteSourceControl, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteSourceControl, nameof(siteSourceControl));

            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotSourcecontrolWebAppsRestClient.CreateOrUpdateSourceControlSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteSlotSourcecontrol>(new SiteSlotSourcecontrolOperationSource(Client), _siteSlotSourcecontrolWebAppsClientDiagnostics, Pipeline, _siteSlotSourcecontrolWebAppsRestClient.CreateCreateOrUpdateSourceControlSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl).Request, response, OperationFinalStateVia.Location);
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
        /// Description for Updates the source control configuration of an app.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/sourcecontrols/web
        /// Operation Id: WebApps_CreateOrUpdateSourceControlSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteSourceControl"> JSON representation of a SiteSourceControl object. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="siteSourceControl"/> is null. </exception>
        public virtual ArmOperation<SiteSlotSourcecontrol> CreateOrUpdate(WaitUntil waitUntil, SiteSourceControlData siteSourceControl, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(siteSourceControl, nameof(siteSourceControl));

            using var scope = _siteSlotSourcecontrolWebAppsClientDiagnostics.CreateScope("SiteSlotSourcecontrol.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotSourcecontrolWebAppsRestClient.CreateOrUpdateSourceControlSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl, cancellationToken);
                var operation = new AppServiceArmOperation<SiteSlotSourcecontrol>(new SiteSlotSourcecontrolOperationSource(Client), _siteSlotSourcecontrolWebAppsClientDiagnostics, Pipeline, _siteSlotSourcecontrolWebAppsRestClient.CreateCreateOrUpdateSourceControlSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, siteSourceControl).Request, response, OperationFinalStateVia.Location);
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
    }
}
