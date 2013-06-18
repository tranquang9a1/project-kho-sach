using DataAccessLayer.cs.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer.cs.DTO;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PublisherDALTest and is intended
    ///to contain all PublisherDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PublisherDALTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for PublisherDAL Constructor
        ///</summary>
        [TestMethod()]
        public void PublisherDALConstructorTest()
        {
            PublisherDAL target = new PublisherDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreatePulisher
        ///</summary>
        [TestMethod()]
        public void CreatePulisherTest()
        {
            PublisherDAL target = new PublisherDAL(); // TODO: Initialize to an appropriate value
            Publisher publisher = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CreatePulisher(publisher);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeletePublisherByID
        ///</summary>
        [TestMethod()]
        public void DeletePublisherByIDTest()
        {
            PublisherDAL target = new PublisherDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeletePublisherByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllProduct
        ///</summary>
        [TestMethod()]
        public void GetAllProductTest()
        {
            PublisherDAL target = new PublisherDAL(); // TODO: Initialize to an appropriate value
            List<Publisher> expected = null; // TODO: Initialize to an appropriate value
            List<Publisher> actual;
            actual = target.GetAllPublisher();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPublisherById
        ///</summary>
        [TestMethod()]
        public void GetPublisherByIdTest()
        {
            PublisherDAL target = new PublisherDAL(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            Publisher expected = null; // TODO: Initialize to an appropriate value
            Publisher actual;
            actual = target.GetPublisherById(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdatePublisher
        ///</summary>
        [TestMethod()]
        public void UpdatePublisherTest()
        {
            PublisherDAL target = new PublisherDAL(); // TODO: Initialize to an appropriate value
            Publisher publisher = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdatePublisher(publisher);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
