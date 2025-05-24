namespace Restorant.WebUI.Dtos.NotifocationDtos
{
    public class UpdateNotificationDto
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationDescription { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}
