using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    class MinHeapForUniqElements_Tests : IMinHeap_Tests<MinHeapForUniqElements>
    {
        protected override MinHeapForUniqElements CreateHeap()
        {
            return new MinHeapForUniqElements();
        }
    }
}