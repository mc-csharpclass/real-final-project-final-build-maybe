using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite
{
    public class DatabaseAccessor
    {
        private static readonly EduWebSiteEntities entities;

        static DatabaseAccessor()
        {
            entities = new EduWebSiteEntities();
            entities.Database.Connection.Open();
        }

        public static EduWebSiteEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}