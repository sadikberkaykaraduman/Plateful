using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICashRegisterService _cashRegisterService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, ICashRegisterService cashRegisterService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _cashRegisterService = cashRegisterService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPasssiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByHamburgerCategory();
            await Clients.All.SendAsync("ReceiveProductCountByHamburgerCategory", value5);

            var value6 = _productService.TProductCountByWrapsCategory();
            await Clients.All.SendAsync("ReceiveProductCountByWrapsCategory", value6);

            var value7 = _productService.TAverageProductPrice();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", value7.ToString("0.00") + "$");

            var value8 = _productService.TGetExpesive();
            await Clients.All.SendAsync("ReceiveGetExpesive", value8);

            var value9 = _productService.TGetCheapest();
            await Clients.All.SendAsync("ReceiveGetCheapest", value9);

            var value10 = _productService.TAverageHamburgerPrice();
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", value10.ToString("0.00") + "$");

            var value11 = _orderService.TOrderCount();
            await Clients.All.SendAsync("ReceiveOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderAmount();
            await Clients.All.SendAsync("ReceiveLastOrderAmount", value13.ToString("0.00") + "$");

            var value14 = _cashRegisterService.TGetTotalCashRegisterAmount();
            await Clients.All.SendAsync("ReceiveGetTotalCashRegisterAmount", value14.ToString("0.00") + "$");

            var value15 = _orderService.TTodayIncome();
            await Clients.All.SendAsync("ReceiveTodayIncome", value15.ToString("0.00") + "$");

            var value16 = _menuTableService.TGetMenuTableCount();
            await Clients.All.SendAsync("ReceiveGetMenuTableCount", value16);
        }
        public async Task SendProgress()
        {
            var value = _cashRegisterService.TGetTotalCashRegisterAmount();
            await Clients.All.SendAsync("ReceiveGetTotalCashRegisterAmount", value.ToString("0.00") + "$");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _menuTableService.TGetMenuTableCount();
            await Clients.All.SendAsync("ReceiveGetMenuTableCount", value3);

            var value5 = _productService.TAverageProductPrice();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", value5);

            var value6 = _productService.TAverageHamburgerPrice();
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", value6);

            var value7 = _productService.TProductCountByBeveragesCategory();
            await Clients.All.SendAsync("ReceiveProductCountByBeveragesCategory", value7);

            var value8 = _orderService.TOrderCount();
            await Clients.All.SendAsync("ReceiveOrderCount", value8);

            var value9 = _productService.TProductPriceByBaconBurger();
            await Clients.All.SendAsync("ReceiveProductPriceByBaconBurger", value9);

            var value10 = _productService.TTotalPriceByDessertsCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceByDessertsCategory", value10);

            var value11 = _productService.TTotalPriceBySaladCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11);

            var value12 = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value12);

            var value13 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value13);

            var value14 = _productService.TProductPriceSummary();
            await Clients.All.SendAsync("ReceiveProductPriceSummary", value14.ToString("0.00") + "$");

            var value15 = _productService.TAverageProductPrice();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", value15.ToString("0.00") + "$");

            var value16 = _orderService.TLastOrderAmount();
            await Clients.All.SendAsync("ReceiveLastOrderAmount", value16.ToString("0.00") + "$");
        }
        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }
    }
}


