using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyId.Net.Tests
{
    internal class Base62Test
    {
        [Test]
        public void DecodingValuePrefixedWithZeros()
        {
            Assert.That(Base62.Encode(Base62.Decode("00001")) == "1");
            Assert.That(Base62.Encode(Base62.Decode("01001")) == "1001");
            Assert.That(Base62.Encode(Base62.Decode("00abcd")) == "abcd");
        }

        [Test]
        public void ShouldCheck128BitLimits()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Base62.Decode("1Vkp6axDWu5pI3q1xQO3oO0");
            });
        }
    }
}
