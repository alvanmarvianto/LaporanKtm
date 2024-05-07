using System;
using LaporanKtmAPI.Controllers;
using LaporanKtmAPI.Services;
using LaporanKtmAPI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace LaporanKtmTest
{
	[TestClass]
	public class LaporanTest
	{
		private readonly LaporanController _controller;
		private readonly ILaporanService _service;
		public LaporanTest()
		{
			_service = new LaporanService();
			_controller = new LaporanController(_service);
		}

		[TestMethod]
		public void CreateReport_ShouldNotBeNull()
		{
			var result = _controller.Save(new Laporan(0, "Test", "test@gmail.com", "1302223047", 0, default));

			Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		}


	}
}

