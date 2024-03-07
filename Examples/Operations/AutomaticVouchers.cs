using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using static Ungerboeck.Api.Models.USISDKConstants;

namespace Examples.Operations
{
  public class AutomaticVouchers: Base
  {
    public AutomaticVouchers(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public AutomaticVouchersModel Get(int automaticVoucherId)
    {
      return apiClient.Endpoints.AutomaticVouchers.Get(automaticVoucherId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AutomaticVouchersModel> Search(string searchValue)
    {
      return apiClient.Endpoints.AutomaticVouchers.Search($"{nameof(AutomaticVouchersModel.RegistrationConfigurationCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="registrationConfigurationCode"></param>
    /// <param name="amount"></param>
    /// <param name="amountType">Pass an amount type either 1 = Dollars or 2 = Percent </param>
    /// <param name="amountAppliedTo">Pass an amount applied value either 1 = Per Order or 2 = Per Registrant</param>
    /// <param name="voucherReference"></param>
    /// <returns></returns>
    public AutomaticVouchersModel Add(string orgCode, string registrationConfigurationCode, decimal amount, int amountType, int amountAppliedTo, string voucherReference)
    {
      var model = new AutomaticVouchersModel
      {
        OrganizationCode = orgCode,
        RegistrationConfigurationCode = registrationConfigurationCode,
        Amount = amount,
        AmountAppliedTo = amountAppliedTo,
        AmountType = amountType,
        Active = true,
        VoucherReference = voucherReference
      };

      return apiClient.Endpoints.AutomaticVouchers.Add(model);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <returns>The updated automatic voucher</returns>
    public AutomaticVouchersModel Edit(int automaticVoucherId, bool active)
    {
      var model = apiClient.Endpoints.AutomaticVouchers.Get(automaticVoucherId);

      model.Active = active;

      return apiClient.Endpoints.AutomaticVouchers.Update(model);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int automaticVoucherId)
    {
      apiClient.Endpoints.AutomaticVouchers.Delete(automaticVoucherId);
    }

    /// <summary>
    /// This shows example values of every editable field for AutomaticVouchers
    /// </summary>
    /// <param name="automaticVoucherId">This is the identifying id for automatic voucher</param>
    /// <returns>The newly updated automatic voucher</returns>
    public AutomaticVouchersModel EditAdvanced(int automaticVoucherId)
    {
      AutomaticVouchersModel automaticVoucher = apiClient.Endpoints.AutomaticVouchers.Get(automaticVoucherId);

      automaticVoucher = GenerateEditAutomaticVoucher(automaticVoucher);

      return apiClient.Endpoints.AutomaticVouchers.Update(automaticVoucher);
    }

    /// <summary>
    /// This changes all possible writable fields on add
    /// </summary>    
    public AutomaticVouchersModel AddAdvanced()
    {
      AutomaticVouchersModel model = GenerateAddAutomaticVoucher();

      return apiClient.Endpoints.AutomaticVouchers.Add(model);
    }

    public AutomaticVouchersModel GenerateAddAutomaticVoucher()
    {
      return new AutomaticVouchersModel
      {
        OrganizationCode = "10",
        RegistrationConfigurationCode = "118071294420",
        Amount = 10M,
        AmountType = AutomaticVoucherAmountType.Percent, // 1 = Dollars and 2 = Percent
        AmountAppliedTo = AutomaticVoucherAmountAppliedTo.PerOrder, // 1 = Per Order and 2 = Per Registrant
        Active = true,
        ExcludeAddonItems = false,
        ExcludeFunctionItems = true,
        SelectedFunctionItems = "5|3999|NONMBR,7|3999|NONMBR",  //  FunctionID|ER103.ER103_NEW_RES_TYPE|ER103.ER103_RES_CODE for function item
        ExcludeMerchandiseItems = true,
        SelectedMerchandiseItems = "6|2000|2045-FD",  // FunctionID|ER103.ER103_NEW_RES_TYPE|ER103.ER103_RES_CODE for merchandise item
        VoucherReference = "DDELEMT2018",
        NumberAvailable = 5,
        SortSequence = 0
      };
    }

    public AutomaticVouchersModel GenerateEditAutomaticVoucher(AutomaticVouchersModel editAutomaticVoucher)
    {
      editAutomaticVoucher.Amount = 100M;
      editAutomaticVoucher.AmountAppliedTo = AutomaticVoucherAmountAppliedTo.PerOrder; // 1 = Per Order and 2 = Per Registrant
      editAutomaticVoucher.AmountType = AutomaticVoucherAmountType.Dollars; // 1 = Dollars and 2 = Percent
      editAutomaticVoucher.Active = false;
      editAutomaticVoucher.ExcludeAddonItems = true;
      editAutomaticVoucher.ExcludeFunctionItems = true;
      editAutomaticVoucher.SelectedFunctionItems = "5|3999|NONMBR,7|3999|NONMBR";  //  FunctionID|ER103.ER103_NEW_RES_TYPE|ER103.ER103_RES_CODE for function item
      editAutomaticVoucher.ExcludeMerchandiseItems = false;
      editAutomaticVoucher.SelectedMerchandiseItems = "";
      editAutomaticVoucher.VoucherReference = "DDELEMT2018";

      return editAutomaticVoucher;
    }
  }
}
