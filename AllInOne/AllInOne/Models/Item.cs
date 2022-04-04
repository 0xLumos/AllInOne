using System;

namespace AllInOne.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Icon {get; set; }
        public string IconTwo { get; internal set; }
        public string IconThree { get; internal set; }
    }
}