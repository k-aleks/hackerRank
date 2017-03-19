using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    class MinHeap_Tests : IMinHeap_Tests<MinHeap>
    {
        protected override MinHeap CreateHeap()
        {
            return new MinHeap();
        }
    }
}