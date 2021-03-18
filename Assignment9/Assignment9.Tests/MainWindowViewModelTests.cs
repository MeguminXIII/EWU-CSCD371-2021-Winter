using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            mvvm.EditContactCmd.Execute(null);
            Assert.IsTrue(mvvm.InEdit);
        }

        [TestMethod]
        public void SaveContact_ReturnsFalse()
        {
            MainWindowViewModel mvvm = new();
            mvvm.InEdit = true;
            mvvm.SaveContactCmd.Execute(null);
            Assert.IsFalse(mvvm.InEdit);
        }

        [TestMethod]
        public void SaveContact_NoContacts_NewContactIsGeneratedAndInEditForm()
        {
            MainWindowViewModel mvvm = new();
            mvvm.ContactList.Clear();
            Assert.AreEqual<int>(0, mvvm.ContactList.Count);
            mvvm.SaveContactCmd.Execute(null);
            Assert.AreEqual<int>(1, mvvm.ContactList.Count);
        }
    }
}
