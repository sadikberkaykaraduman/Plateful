﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TChangeStatusToTrue(int id)
        {
            _notificationDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetActiveNotification()
        {
            return _notificationDal.GetActiveNotification();
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
