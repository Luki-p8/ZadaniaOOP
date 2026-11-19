using PeselValidator;

namespace TestPeselValidator
{
    [TestClass]
    public class PeselTests
    {
        [TestMethod]
        public void IsValid_PersonBornInTwentiethCentury_ReturnsTrue()
        {
            Assert.IsTrue(Pesel.IsValid("44051401359"));
        }

        [TestMethod]
        public void IsValid_PersonBornInTwentyFirstCentury_ReturnsTrue()
        {
            Assert.IsTrue(Pesel.IsValid("02270803624"));
        }

        [TestMethod]
        public void IsValid_WrongControlDigit_ReturnsFalse()
        {
            Assert.IsFalse(Pesel.IsValid("44051401358"));
        }

        [TestMethod]
        public void IsValid_WrongLength_ReturnsFalse()
        {
            Assert.IsFalse(Pesel.IsValid("1234"));
        }

        [TestMethod]
        public void IsValid_ContainsLetter_ReturnsFalse()
        {
            Assert.IsFalse(Pesel.IsValid("4405140135A"));
        }
    }
}
