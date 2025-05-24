using FluentValidation;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using System.Reflection;

namespace SignalR.Api.Extension
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddDbContext<RestorantDbContext>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
            services.AddScoped<IMenuTableDal, EfMenuTableDal>();
            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<INotificationDal, EfNotificationDal>();
            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<ICashRegisterDal, EfCashRegisterDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IMenuTableService, MenuTableManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<ICashRegisterService, CashRegisterManager>();

            services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
