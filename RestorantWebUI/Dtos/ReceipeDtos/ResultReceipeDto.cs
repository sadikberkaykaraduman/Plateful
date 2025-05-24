namespace Restorant.WebUI.Dtos.ReceipeDtos
{
    public class RootReceipeDto
    {
        public List<ResultReceipeDto> Results { get; set; }
    }
    public class ResultReceipeDto
    {
        public string Name { get; set; }
        public string original_video_url { get; set; }
        public int total_time_minutes { get; set; }
        public string thumbnail_url { get; set; }
    }
}
