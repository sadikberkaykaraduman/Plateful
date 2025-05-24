namespace Restorant.WebUI.Dtos.MessageDtos
{
    public class GetMessageDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
    }
}
