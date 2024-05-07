using System;
using LaporanKtmAPI.Model;
using Microsoft.AspNetCore.Mvc;
using LaporanKtmAPI.Services;

namespace LaporanKtmAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaporanController : ControllerBase
    {
        private readonly ILaporanService _laporan;

        public LaporanController(ILaporanService laporan)
        {
            _laporan = laporan;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Laporan> allReport = _laporan.GetAll();
                return Ok(allReport);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Laporan> Show(int id)
        {
            try
            {
                Laporan idLaporan = _laporan.GetById(id);
                return idLaporan;
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public void Update(int id, Laporan laporan)
        {
            try
            {
              _laporan.Edit(id, laporan);
              
            }
            catch (Exception e)
            {
                if (e is ArgumentOutOfRangeException)
                {
                    NotFound();
                }

                StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<List<Laporan>> Save(Laporan laporan)
        {
            try
            {
                var result = _laporan.Add(laporan);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
               _laporan.Delete(id);
            }
            catch (Exception e)
            {
                 StatusCode(500, e.Message);
            }
        }
    }
}

