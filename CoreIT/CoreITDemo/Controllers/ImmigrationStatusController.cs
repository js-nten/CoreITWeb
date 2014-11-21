using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreITDemo.Models;
using CoreITDemo.ViewModels;

namespace CoreITDemo.Controllers
{
    public class ImmigrationStatusController : ApiController
    {
        // GET api/ImmigrationStatus
        public List<ImmigrationStatusDTO> GetImmigrationStatus()
        {
            //return db.Employees.AsEnumerable()
            List<ImmigrationStatusDTO> imList = new List<ImmigrationStatusDTO>();

            foreach (int im in Enum.GetValues(typeof(ImmigrationStatus)))
            {
                imList.Add(new ImmigrationStatusDTO() { ImmigrationStatusId = im, ImmigrationStatusDesc = Enum.GetName(typeof(ImmigrationStatus), im) });
            }

            return imList;
        }
    }
}
