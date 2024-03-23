using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyTests.PlaywrightFixture;

namespace MyTests
{
    /// <summary>
    /// The test class that is using the PlaywrightFixture
    /// </summary>
    [Collection(PlaywrightFixture.PlaywrightCollection)]
    public class MyTestClass
    {
        private readonly PlaywrightFixture playwrightFixture;
        /// <summary>
        /// Setup test class injecting a playwrightFixture instance.
        /// </summary>
        /// <param name="playwrightFixture">The playwrightFixture
        /// instance.</param>
        public MyTestClass(PlaywrightFixture playwrightFixture)
        {
            this.playwrightFixture = playwrightFixture;
        }

        [Fact]
        public async Task MyFirstTest()
        {
            var url = "https://my.test.url";
            // Open a page and run test logic.
            await this.playwrightFixture.GotoPageAsync(
              url,
              async (page) =>
              {
                  // Apply the test logic on the given page.
              },
              Browser.Chromium);
        }
    }
}
