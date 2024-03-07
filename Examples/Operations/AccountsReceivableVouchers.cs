using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountsReceivableVouchers : Base
  {
    public AccountsReceivableVouchers(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountsReceivableVouchersModel Get(string orgCode, int voucherSequence)
    {
      return apiClient.Endpoints.AccountsReceivableVouchers.Get( orgCode, voucherSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AccountsReceivableVouchersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountsReceivableVouchers.Search(orgCode, $"{nameof(AccountsReceivableVouchersModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example for reference 
    /// </summary>  
    public AccountsReceivableVouchersModel Add(string organizationCode, string reference, string description, decimal amount)
    {
      var accountsReceivableVoucher = new AccountsReceivableVouchersModel
      {
        OrganizationCode = organizationCode,
        Reference = reference,
        Description = description,
        Amount = amount
      };

      return apiClient.Endpoints.AccountsReceivableVouchers.Add(accountsReceivableVoucher);
    }

    /// <summary>
    /// A basic edit example for reference 
    /// </summary> 
    public AccountsReceivableVouchersModel Edit(string organizationCode, int voucherSequence, string description)
    {
      var accountsReceivableVoucher = apiClient.Endpoints.AccountsReceivableVouchers.Get(organizationCode, voucherSequence);
      accountsReceivableVoucher.Description = description;

      return apiClient.Endpoints.AccountsReceivableVouchers.Update(accountsReceivableVoucher);
    }

  }
}
