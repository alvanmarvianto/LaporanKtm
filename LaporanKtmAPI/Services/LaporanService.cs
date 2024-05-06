using System;
using LaporanKtmAPI.Model;
using LaporanKtmLibrary.Helper;

namespace LaporanKtmAPI.Services
{
    public class LaporanService : ILaporanService
    {
        private readonly List<Laporan> _laporan;

        public LaporanService()
        {
            _laporan = new List<Laporan>();
        }

        public List<Laporan> Add(Laporan laporan)
        {
            try
            {
                return CollectionHelper.Add(_laporan, laporan);
            } catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public List<Laporan> Delete(int id)
        {
            try
            {
                return CollectionHelper.Delete(_laporan, id);
            } catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public List<Laporan> Edit(int id, Laporan laporan)
        {
            try
            {
                return CollectionHelper.Update(_laporan, laporan, id);
            } catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public List<Laporan> GetAll()
        {
            try
            {
                return CollectionHelper.GetAll(_laporan);
            } catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public Laporan GetById(int id)
        {
            try
            {
                return CollectionHelper.GetById(_laporan, id);
            } catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
     
    }
}

