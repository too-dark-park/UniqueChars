using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using UniqueChars.Application.Extensions;

namespace UniqueCharsTests
{
    [TestClass]
    public class Utf8Tests
    {
        public TestContext TestContext { get; set; }
        private UTF8Encoding _utf8 { get; } = new UTF8Encoding();
        private string _uniqueSequence { get; } = "𠀋𠍱𠌫𠈓1234";

        [TestMethod] // Fails
        public void SequenceIsUnique_UsingCollection()
        {
            var isUnique = _utf8.IsUnique_UsingCollection(_uniqueSequence);
            Assert.IsTrue(isUnique);
        }
    }
}