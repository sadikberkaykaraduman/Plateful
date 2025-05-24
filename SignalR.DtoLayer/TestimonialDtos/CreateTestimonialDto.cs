using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialCommnet { get; set; }
        public string TestimonialImageUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
