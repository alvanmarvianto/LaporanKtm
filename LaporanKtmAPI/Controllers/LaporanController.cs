using System;
using LaporanKtmAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LaporanKtmAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaporanController : ControllerBase
    {
        private static List<Laporan> reportList = new List<Laporan>();

        [HttpGet]
        public ActionResult<IEnumerable<Laporan>> Get()
        {
            try
            {
                return CollectionHelper.GetAll<Laporan>(reportList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

