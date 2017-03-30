using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using TrackingSystem.Controllers;
using TrackingSystem.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TrackingSystem.Tests.Controllers
{
    [TestFixture]
    public class VisitorCardsTest
    {
        private VisitorCardController controller;

        [SetUp]
        public void InitVisitorCardsTest()
        {
            controller = new VisitorCardController();
        }

        [Test]
        public void Should_Create_GetView()
        {
            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Should_Create_CreateCard()
        {
            var vc = new VisitorCard()
            {
                VisitorName = "Name_" + Guid.NewGuid(),
                Active = true,
            };

            ViewResult result = controller.Create(vc) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}