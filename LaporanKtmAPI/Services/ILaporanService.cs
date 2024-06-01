using System;
using LaporanKtmAPI.Model;
namespace LaporanKtmAPI.Services
{
	public interface ILaporanService
	{
		List<Laporan> GetAll();
		Laporan GetById(int id);
		List<Laporan> Add(Laporan laporan);
		List<Laporan> Delete(int id);
		List<Laporan> Edit(int id, Laporan laporan);
	}
}

