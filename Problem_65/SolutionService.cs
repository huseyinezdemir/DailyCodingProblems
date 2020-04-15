using System.Collections.Generic;
using System.Linq;

namespace Problem_65
{
    public class SolutionService
    {
        private List<int> _result;
        private Direction _currentDirection;


        public int[] Execute(List<int[]> input)
        {
            ResetPrivateObjects();

            while (input.Count > 0)
            {
                switch (_currentDirection)
                {
                    case Direction.Right:
                        WriteLeftToRight(input[0]);
                        input.Remove(input[0]);
                        _currentDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        WriteDownDirection(0, input.Count - 1, input);
                        _currentDirection = Direction.Left;
                        break;
                    case Direction.Left:
                        WriteRightToLeft(input[^1]);
                        input.Remove(input[^1]);
                        _currentDirection = Direction.Up;
                        break;
                    case Direction.Up:
                        WriteUpDirection(input);
                        _currentDirection = Direction.Right;
                        break;
                }
            }

            return _result.ToArray();
        }

        private void ResetPrivateObjects()
        {
            _result = new List<int>();
            _currentDirection = Direction.Right;
        }

        private void WriteDownDirection(int startArrayIndex, int endArrayIndex, List<int[]> input)
        {
            if (input.Count - 1 >= startArrayIndex && input.Count - 1 == endArrayIndex)
            {
                for (int i = startArrayIndex; i < input.Count; i++)
                {
                    int selectedItemIndex = input[i].Length - 1;

                    _result.Add(input[i][selectedItemIndex]);
                    var newArray = input[i].ToList();
                    newArray.Remove(input[i][selectedItemIndex]);
                    input[i] = newArray.ToArray();
                }
            }
        }

        private void WriteUpDirection(IList<int[]> input)
        {
            if (input.Count > 1)
            {
                //reverse
                for (int i = input.Count - 1; i >= 0; i--)
                {
                    _result.Add(input[i][0]);
                    var newArray = input[i].ToList();
                    newArray.Remove(input[i][0]);
                    input[i] = newArray.ToArray();
                }
            }
            else
            {
                //Tek array kaldi
                _result.Add(input[0][0]);
                var newArray = input[0].ToList();
                newArray.Remove(input[0][0]);
                input[0] = newArray.ToArray();
            }
        }


        private void WriteLeftToRight(int[] input, int? writeoutIndex = null)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!writeoutIndex.HasValue || writeoutIndex != i)
                    _result.Add(input[i]);
            }
        }

        private void WriteRightToLeft(int[] input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                _result.Add(input[i]);
            }
        }
    }
}