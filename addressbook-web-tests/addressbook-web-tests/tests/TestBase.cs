using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
       
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomepage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
