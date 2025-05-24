namespace Restorant.WebUI.Dtos.NotifocationDtos
{
    public class CreateNotificationDto
    {
        public string NotificationType { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
