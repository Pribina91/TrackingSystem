using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TrackingSystem.Controllers;
using TrackingSystem.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TrackingSystem.Tests.Controllers
{
    [TestClass]
    public class VisitorCardsTest
    {
        private VisitorCardController controller;

        [TestInitialize]
        public void InitVisitorCardsTest()
        {
            controller = new VisitorCardController();
        }

        [TestMethod]
        public void Should_Create_GetView()
        {
            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
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

        [TestMethod]
        public
            void Should_Create_FailCreateDuplicate()
        {
            var vc = new VisitorCard()
            {
                VisitorName = "Name_" + Guid.NewGuid(),
                Active = true,
            };

            controller.Create(vc);

            var vc2 = new VisitorCard()
            {
                VisitorName = vc.VisitorName,
                Active = true,
            };

            controller.ViewData.ModelState.Clear();
            controller.Create(vc2);
            Assert.IsFalse(controller.ViewData.ModelState.IsValid);
        }
    }
}