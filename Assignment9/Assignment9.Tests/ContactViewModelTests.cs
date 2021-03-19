using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9.Tests
{
    [TestClass]
    public class ContactViewModelTests
    {

        [TestMethod]
        public void ContactViewModel_SettingFirstName_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            Assert.AreEqual<string>("Inigo", mvvm.CurrentContact.FirstName);
            mvvm.CurrentContact.FirstName = "Jeff";
            Assert.AreEqual<string>("Jeff", mvvm.CurrentContact.FirstName);
        }

        [TestMethod]
        public void ContactViewModel_SettingLastName_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            Assert.AreEqual<string>("Montoya", mvvm.CurrentContact.LastName);
            mvvm.CurrentContact.LastName = "Jeff";
            Assert.AreEqual<string>("Jeff", mvvm.CurrentContact.LastName);
        }

        [TestMethod]
        public void ContactViewModel_SettingPhoneNumber_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            Assert.AreEqual<string>("424-424-4242", mvvm.CurrentContact.PhoneNumber);
            mvvm.CurrentContact.PhoneNumber = "Jeff";
            Assert.AreEqual<string>("Jeff", mvvm.CurrentContact.PhoneNumber);
        }

        [TestMethod]
        public void ContactViewModel_SettingEmailAddress_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            Assert.AreEqual<string>("MontoyaI@email.com", mvvm.CurrentContact.EmailAddress);
            mvvm.CurrentContact.EmailAddress = "Jeff";
            Assert.AreEqual<string>("Jeff", mvvm.CurrentContact.EmailAddress);
        }

        [TestMethod]
        public void ContactViewModel_SettingTwitterName_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            Assert.AreEqual<string>("@42%", mvvm.CurrentContact.TwitterName);
            mvvm.CurrentContact.TwitterName = "Jeff";
            Assert.AreEqual<string>("Jeff", mvvm.CurrentContact.TwitterName);
        }

        [TestMethod]
        public void ContactViewModel_SettingLastModifiedTime_ReturnsSetValue()
        {
            MainWindowViewModel mvvm = new();
            DateTime timeSet = DateTime.Now;
            mvvm.CurrentContact.LastModifiedTime = timeSet;
            Assert.AreEqual<DateTime>(timeSet, mvvm.CurrentContact.LastModifiedTime);
        }
    }
}
