namespace Restorant.WebUI.Dtos.ContactDtos
{
    public class GetContactDto
    {
        public int ContactId { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string FooterDescription { get; set; }
    }
}
