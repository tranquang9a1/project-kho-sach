using DataAccessLayer.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLayer.DTO;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for IEDetailDALTest and is intended
    ///to contain all IEDetailDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IEDetailDALTest
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
        ///A test for IEDetailDAL Constructor
        ///</summary>
        [TestMethod()]
        public void IEDetailDALConstructorTest()
        {
            IEDetailDAL target = new IEDetailDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateIEDetail
        ///</summary>
        [TestMethod()]
        public void CreateIEDetailTest()
        {
            IEDetailDAL target = new IEDetailDAL(); // TODO: Initialize to an appropriate value
            IEDetail iedetail = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CreateIEDetail(iedetail);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeletePublisherByCheckNoAndISBN
        ///</summary>
        [TestMethod()]
        public void DeletePublisherByCheckNoAndISBNTest()
        {
            IEDetailDAL target = new IEDetailDAL(); // TODO: Initialize to an appropriate value
            int no = 0; // TODO: Initialize to an appropriate value
            string ISBN = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeletePublisherByCheckNoAndISBN(no, ISBN);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllProduct
        ///</summary>
        [TestMethod()]
        public void GetAllProductTest()
        {
            IEDetailDAL target = new IEDetailDAL(); // TODO: Initialize to an appropriate value
            List<IEDetail> expected = null; // TODO: Initialize to an appropriate value
            List<IEDetail> actual;
            actual = target.GetAllProduct();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPublisherByCheckNoAndISBN
        ///</summary>
        [TestMethod()]
        public void GetPublisherByCheckNoAndISBNTest()
        {
            IEDetailDAL target = new IEDetailDAL(); // TODO: Initialize to an appropriate value
            int no = 0; // TODO: Initialize to an appropriate value
            string isbn = string.Empty; // TODO: Initialize to an appropriate value
            IEDetail expected = null; // TODO: Initialize to an appropriate value
            IEDetail actual;
            actual = target.GetPublisherByCheckNoAndISBN(no, isbn);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateIEDetail
        ///</summary>
        [TestMethod()]
        public void UpdateIEDetailTest()
        {
            IEDetailDAL target = new IEDetailDAL(); // TODO: Initialize to an appropriate value
            IEDetail iedetail = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateIEDetail(iedetail);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
