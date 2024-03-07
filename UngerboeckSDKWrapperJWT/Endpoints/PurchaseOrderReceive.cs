using System;
using System.Collections.Generic;
using System.Text;
using Ungerboeck.Api.Models.Subjects;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  public class PurchaseOrderReceive : Base<PurchaseOrderReceiveRequestModel>
  {
    protected internal PurchaseOrderReceive(ApiClient api) : base(api) { }
  }
}
