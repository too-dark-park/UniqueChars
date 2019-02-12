using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniqueChars.Application.Validation;
using UniqueChars.Application.Extensions;

namespace UniqueCharsTests
{
    [TestClass]
    public class AsciiTests
    {
        public TestContext TestContext { get; set; }
        private ASCIIEncoding _ascii { get; } = new ASCIIEncoding();
        private string _uniqueSequence { get; set; }
        private string _nonUniqueSequence { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.Contains("IsUnique"))
            {
                _uniqueSequence    = _ascii.GetUniqueSequence();
            }
            if (TestContext.TestName.Contains("IsNotUnique"))
            {
                _nonUniqueSequence = _ascii.GetNonUniqueSequence();
            }
        }

        [TestMethod]
        public void SequenceIsUnique_UsingCollection()
        {
            var isUnique = SequenceChecker.IsUnique_UsingCollection(_uniqueSequence);
            Assert.IsTrue(isUnique);
        }

        [TestMethod]
        public void SequenceIsNotUnique_UsingCollection()
        {
            var isUnique = SequenceChecker.IsUnique_UsingCollection(_nonUniqueSequence);
            Assert.IsFalse(isUnique);
        }

        [TestMethod]
        public void IsUnique_UsingHash()
        {
            var isUnique = SequenceChecker.IsUnique_UsingHash(_uniqueSequence);
            Assert.IsTrue(isUnique);
        }

        [TestMethod]
        public void IsNotUnique_UsingHash()
        {
            var isUnique = SequenceChecker.IsUnique_UsingHash(_nonUniqueSequence);
            Assert.IsFalse(isUnique);
        }

        [TestMethod]
        public void IsUnique_UsingDistinct()
        {
            var isUnique = SequenceChecker.IsUnique_UsingDistinct(_uniqueSequence);
            Assert.IsTrue(isUnique);
        }

        [TestMethod]
        public void IsNotUnique_UsingDistinct()
        {
            var isUnique = SequenceChecker.IsUnique_UsingDistinct(_nonUniqueSequence);
            Assert.IsFalse(isUnique);
        }

        [TestMethod]
        public void DoesExceedCharacterLimit()
        {
            var exceeds = _ascii.IsExceedingCharacterLimit(_ascii.GetNonUniqueSequence(2000000));
            Assert.IsTrue(exceeds);
        }

        [TestMethod]
        public void DoesNotExceedCharacterLimit()
        {
            var exceeds = _ascii.IsExceedingCharacterLimit(_ascii.GetUniqueSequence(100));
            Assert.IsFalse(exceeds);
        }
    }
}