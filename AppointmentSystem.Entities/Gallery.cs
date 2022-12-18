using System;
namespace AppointmentSystem.Entities
{
    public class Gallery : BaseEntity
    {
        public string ImageSrc { get; set; }
        public GalleryType GalleryType { get; set; }
    }
}

