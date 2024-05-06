using System;
using LaporanKtmAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<Laporan>> Get()
        {
            try
            {
                List<Laporan> allReport = _laporan.GetAll();
                return allReport;
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
        public void Save([FromBody] Laporan laporan)
        {
            try
            {
                 _laporan.Add(laporan);
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
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

