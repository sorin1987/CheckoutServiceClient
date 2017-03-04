using Checkout.ApiServices.Cards.RequestModels;
using Checkout.ApiServices.DrinksService.RequestModels;
using Checkout.ApiServices.DrinksService.ResponseModels;
using Checkout.ApiServices.SharedModels;
using Checkout.Utilities;

namespace Checkout.ApiServices.DrinksService
{
    public class DrinkService
    {
        public HttpResponse<Drink> CreateDrink(DrinkCreate requestModel)
        {
            return new ApiHttpClient().PostRequest<Drink>(ApiUrls.Drinks, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<Drink> GetDrink(string drinkName)
        {
            var getDrinkUri = string.Format(ApiUrls.Drink, drinkName);
            return new ApiHttpClient().GetRequest<Drink>(getDrinkUri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> UpdateDrink(string drinkName, DrinkUpdate requestModel)
        {
            var updateDrinkUri = string.Format(ApiUrls.Drink, drinkName);
            return new ApiHttpClient().PutRequest<OkResponse>(updateDrinkUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteDrink(string drinkName)
        {
            var deleteDrinkUri = string.Format(ApiUrls.Drink, drinkName);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteDrinkUri, AppSettings.SecretKey);
        }

        public HttpResponse<DrinkList> GetDrinkList(DrinkGetList request)
        {
            var getDrinkListUri = ApiUrls.Drinks;

            if (request.Count.HasValue)
            {
                getDrinkListUri = UrlHelper.AddParameterToUrl(getDrinkListUri, "count", request.Count.ToString());
            }

            if (request.Offset.HasValue)
            {
                getDrinkListUri = UrlHelper.AddParameterToUrl(getDrinkListUri, "offset", request.Offset.ToString());
            }

            if (request.FromDate.HasValue)
            {
                getDrinkListUri = UrlHelper.AddParameterToUrl(getDrinkListUri, "fromDate", DateTimeHelper.FormatAsUtc(request.FromDate.Value));
            }

            if (request.ToDate.HasValue)
            {
                getDrinkListUri = UrlHelper.AddParameterToUrl(getDrinkListUri, "toDate", DateTimeHelper.FormatAsUtc(request.ToDate.Value));
            }

            return new ApiHttpClient().GetRequest<DrinkList>(getDrinkListUri, AppSettings.SecretKey);
        }
    }
}
