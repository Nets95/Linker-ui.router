using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinkEntities.LinkEntity;


namespace HomeTaskAngular.Models
{
    public class Link
    {
        public int Id { get; set; }

        public string LinkTitle { get; set; }

        public string CurrentDate { get; set; }

        public static explicit operator LinkEntity(Link link)
        {
            LinkEntity linkModel = new LinkEntity()
            {
                Id = link.Id,
                CurrentDate = link.CurrentDate,
                LinkTitle = link.LinkTitle
            };
            return linkModel;
        }

        public static explicit operator Link(LinkEntity link)
        {
            Link linkModel = new Link()
            {
                Id = link.Id,
                LinkTitle = link.LinkTitle,
                CurrentDate = link.CurrentDate
            };
            return linkModel;
        }


    }
}