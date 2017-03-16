using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class TreeHeightCalculator_Tests
    {
        [Test]
        public void Calc_should_return_0_for_one_node_tree()
        {
            Node tree = new Node();

            TreeHeightCalculator.CalcHeighForEachNode(tree);

            tree.ht.Should().Be(0);
        }

        /// <summary>
        ///    0
        ///     \
        ///      1
        /// </summary>
        [Test]
        public void Calc_should_calc_for_tree_1()
        {
            Node tree = new Node()
            {
                right = new Node()
            };

            TreeHeightCalculator.CalcHeighForEachNode(tree);

            tree.ht.Should().Be(1);
            tree.right.ht.Should().Be(0);
        }

        /// <summary>
        ///    0
        ///   /  \
        ///  1    2
        /// </summary>
        [Test]
        public void Calc_should_calc_for_tree_2()
        {
            Node tree = new Node()
            {
                left = new Node(),
                right = new Node(),
            };

            TreeHeightCalculator.CalcHeighForEachNode(tree);

            tree.ht.Should().Be(1);
            tree.left.ht.Should().Be(0);
            tree.right.ht.Should().Be(0);
        }

        /// <summary>
        ///    0
        ///   /  \
        ///  1    2
        /// /
        /// 3
        /// </summary>
        [Test]
        public void Calc_should_calc_for_tree_3()
        {
            Node tree = new Node()
            {
                val = 0,
                left = new Node()
                {
                    left = new Node()
                },
                right = new Node()
            };

            TreeHeightCalculator.CalcHeighForEachNode(tree);

            tree.ht.Should().Be(2);
            tree.left.ht.Should().Be(1);
            tree.right.ht.Should().Be(0);

            tree.left.left.ht.Should().Be(0);
        }

        /// <summary>
        ///    0
        ///   /  \
        ///  1    2
        ///   \
        ///    3
        /// </summary>
        [Test]
        public void Calc_should_calc_for_tree_4()
        {
            Node tree = new Node()
            {
                val = 0,
                left = new Node()
                {
                    right = new Node()
                },
                right = new Node()
            };

            TreeHeightCalculator.CalcHeighForEachNode(tree);

            tree.ht.Should().Be(2);
            tree.left.ht.Should().Be(1);
            tree.right.ht.Should().Be(0);

            tree.left.right.ht.Should().Be(0);
        }
    }
}