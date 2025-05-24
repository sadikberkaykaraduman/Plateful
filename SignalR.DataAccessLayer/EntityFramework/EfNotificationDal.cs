using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(RestorantDbContext context) : base(context)
        {
        }

        public void ChangeStatusToTrue(int id)
        {
            var context = new RestorantDbContext();
            var notification = context.Notifications.Find(id);
            notification.NotificationStatus = true;
            context.SaveChanges();
        }

        public List<Notification> GetActiveNotification()
        {
            var context = new RestorantDbContext();
            return context.Notifications.Where(x => x.NotificationStatus == false).ToList();
        }
    }
}
