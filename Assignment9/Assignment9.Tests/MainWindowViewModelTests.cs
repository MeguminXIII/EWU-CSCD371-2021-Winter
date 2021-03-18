using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment9.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void CreateNewContact_GeneratesNewContact()
        {
            MainWindowViewModel mvvm = new();

            int start = mvvm.ContactList.Count;

            mvvm.NewContactCmd.Execute(null);

            Assert.AreEqual<int>(start + 1, mvvm.ContactList.Count);
        }

        [TestMethod]
        public void DeleteContact_DeletesContact()
        {
            MainWindowViewModel mvvm = new();

            int start = mvvm.ContactList.Count;

            mvvm.DeleteContactCmd.Execute(null);

            Assert.AreEqual<int>(start - 1, mvvm.ContactList.Count);
        }

        [TestMethod]
        public void EditContact_ReturnsTrue()
        {
            MainWindowViewModel mvvm = new();
            mvvm.InEdit = false;
            mvvm.EditContactCmd.Execute(null);
            Assert.IsTrue(mvvm.InEdit);
        }

        [TestMethod]
        public void SaveContact_WithContactsInList_GoesFromInEditModeToViewMode()
        {
            MainWindowViewModel mvvm = new();
            mvvm.InEdit = true;
            mvvm.SaveContactCmd.Execute(null);
            Assert.IsFalse(mvvm.InEdit);
        }

        [TestMethod]
        public void SaveContact_NoContacts_NewContactIsGenerated()
        {
            MainWindowViewModel mvvm = new();
            mvvm.ContactList.Clear();
            Assert.AreEqual<int>(0, mvvm.ContactList.Count);
            mvvm.SaveContactCmd.Execute(null);
            Assert.AreEqual<int>(1, mvvm.ContactList.Count);
        }

        [TestMethod]
        public void SaveContact_NoContactInList_PutsViewInEditForm()
        {
            MainWindowViewModel mvvm = new();
            mvvm.ContactList.Clear();
            mvvm.InEdit = false;
            mvvm.SaveContactCmd.Execute(null);
            Assert.IsTrue(mvvm.InEdit);
        }

        [TestMethod]
        public void SaveContact_UpdatesLastModifiedTime()
        {
            MainWindowViewModel mvvm = new();

            DateTime now = DateTime.Now;

            mvvm.CurrentContact.LastModifiedTime = now;

            mvvm.SaveContactCmd.Execute(null);

            Assert.AreNotEqual<DateTime>(now, mvvm.CurrentContact.LastModifiedTime);
        }
    }
}
