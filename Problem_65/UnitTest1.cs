using System.Collections.Generic;
using Xunit;

namespace Problem_65
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var input = new List<int[]>
            {
                new[] {1, 2, 3, 4, 5},
                new[] {6, 7, 8, 9, 10},
                new[] {11, 12, 13, 14, 15},
                new[] {16, 17, 18, 19, 20}
            };

            var solve = new SolutionService();
            var result = solve.Execute(input);

            int[] expected = {1, 2, 3, 4, 5, 10, 15, 20, 19, 18, 17, 16, 11, 6, 7, 8, 9, 14, 13, 12};

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2()
        {
            var input = new List<int[]> {new[] {1, 2, 3, 4, 5}, new[] {6, 7, 8, 9, 10}};

            var solve = new SolutionService();
            int[] result = solve.Execute(input);


            int[] expected = {1, 2, 3, 4, 5, 10, 9, 8, 7, 6};

            Assert.Equal(expected, result);
        }
    }
}