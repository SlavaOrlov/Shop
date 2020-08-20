using Shop.Api.Model.Input;

namespace Shop.Api.Validators
{
    public class OrderAndProductValidator
    {
        public string CheckInputModel(ProductInputModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.Name)) return ("Enter the name");
            if (inputModel.Price == null) return ("Enter the price");
            if (string.IsNullOrWhiteSpace(inputModel.Size)) return ("Enter the size");
            if (string.IsNullOrWhiteSpace(inputModel.Color)) return ("Enter the color");
            if (inputModel.Weight==null) return ("Enter the weiht");
            if (string.IsNullOrWhiteSpace(inputModel.Manufacturer)) return ("Enter the manufacture");
            if (inputModel.YearOfManufacture==null) return ("Enter the year of manufacture");
            if (inputModel.ConsumedPower==null) return ("Enter the consumed power");
            return "";
        }
        public string CheckInputModel(OrderInputModel inputModel)
        {
            if(string.IsNullOrWhiteSpace(inputModel.Fio))return ("Enter the FIO");
            if(string.IsNullOrWhiteSpace(inputModel.Address))return ("Enter the Address");
            if(inputModel.Quantity==null)return ("Enter the Quantity");
            if(inputModel.ProductDto==null)return ("Enter the product parametrs");
            return "";
        }
    }
}
