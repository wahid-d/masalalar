using Xunit;
using Masalalar.Arrays;

namespace Masalalar.Arrays.Tests;

public class ArrayTests
{
    public static IEnumerable<object[]> FindMaxElement_TestData()
    {
        yield return new object[] { new int[][] { new int[] { 1 } }, 1 };
        yield return new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }, 4 };
        yield return new object[]
        {
            new int[][]
            {
                new int[] { -1, -2, -3 },
                new int[] { -4, -5, -6 },
                new int[] { -7, -8, -9 }
            },
            -1
        };
        yield return new object[]
        {
            new int[][]
            {
                new int[] { 10, 20, 30, 40 },
                new int[] { 50, 60, 70, 80 },
                new int[] { 90, 100, 110, 120 }
            },
            120
        };
        yield return new object[]
        {
            new int[][] { new int[] { 5, 12, 9 }, new int[] { 15, 8, 6 }, new int[] { 3, 7, 11 } },
            15
        };
        yield return new object[] { new int[][] { new int[] { 2 } }, 2 };
        yield return new object[]
        {
            new int[][]
            {
                new int[] { -2, -1, 0 },
                new int[] { 0, -3, -4 },
                new int[] { -5, -6, -7 }
            },
            0
        };
        yield return new object[] { new int[][] { new int[] { int.MaxValue } }, int.MaxValue };
        yield return new object[] { new int[][] { new int[] { int.MinValue } }, int.MinValue };
        yield return new object[]
        {
            new int[][] { new int[] { int.MinValue, int.MaxValue } },
            int.MaxValue
        };
    }

    [Theory]
    [MemberData(nameof(FindMaxElement_TestData))]
    public void FindMaxElement_ReturnsMaxElement(int[][] arr, int expectedMax)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int maxElement = solution.FindMaxElement(arr);

        // Assert
        Assert.Equal(expectedMax, maxElement);
    }

    public static IEnumerable<object[]> CalculateTranspose_TestData()
    {
        yield return new object[]
        {
            new int[][] { new int[] { 1 } },
            new int[][] { new int[] { 1 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } },
            new int[][] { new int[] { 1, 3 }, new int[] { 2, 4 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } },
            new int[][] { new int[] { 1, 4 }, new int[] { 2, 5 }, new int[] { 3, 6 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
            new int[][] { new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, new int[] { 3, 6, 9 } }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
            },
            new int[][]
            {
                new int[] { 1, 5, 9 },
                new int[] { 2, 6, 10 },
                new int[] { 3, 7, 11 },
                new int[] { 4, 8, 12 }
            }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
                new int[] { 5, 6 },
                new int[] { 7, 8 }
            },
            new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 2, 4, 6, 8 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 3 }, new int[] { 4 } },
            new int[][] { new int[] { 1, 2, 3, 4 } }
        };

        yield return new object[] { new int[][] { }, new int[][] { } };

        yield return new object[] { new int[][] { new int[] { } }, new int[][] { } };

        yield return new object[]
        {
            new int[][] { new int[] { }, new int[] { }, new int[] { } },
            new int[][] { }
        };
    }

    [Theory]
    [MemberData(nameof(CalculateTranspose_TestData))]
    public void CalculateTranspose_ReturnsTransposedMatrix(
        int[][] matrix,
        int[][] expectedTranspose
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int[][] transpose = solution.CalculateTranspose(matrix);

        // Assert
        Assert.Equal(expectedTranspose, transpose);
    }

    public static IEnumerable<object[]> SortJaggedArray_TestData()
    {
        yield return new object[]
        {
            new int[][] { new int[] { 1 } },
            new int[][] { new int[] { 1 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 3, 2, 1 } },
            new int[][] { new int[] { 1, 2, 3 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 9, 4, 7 }, new int[] { 1, 5, 3 }, new int[] { 6, 2, 8 } },
            new int[][] { new int[] { 4, 7, 9 }, new int[] { 1, 3, 5 }, new int[] { 2, 6, 8 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 9, 2, 5, 1 }, new int[] { 4, 6 }, new int[] { 7, 3, 8 } },
            new int[][] { new int[] { 1, 2, 5, 9 }, new int[] { 4, 6 }, new int[] { 3, 7, 8 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 5, 7 }, new int[] { 1, 4, 2, 3 }, new int[] { 6 } },
            new int[][] { new int[] { 5, 7 }, new int[] { 1, 2, 3, 4 }, new int[] { 6 } }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 3, 2, 1 },
                new int[] { },
                new int[] { 4, 5 },
                new int[] { 6 }
            },
            new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { },
                new int[] { 4, 5 },
                new int[] { 6 }
            }
        };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(SortJaggedArray_TestData))]
    public void SortJaggedArray_SortsArrayInAscendingOrder(int[][] arr, int[][] expectedSortedArray)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        solution.SortJaggedArray(arr);

        // Assert
        Assert.Equal(expectedSortedArray, arr);
    }

    public static IEnumerable<object[]> CalculateSumOfElements_TestData()
    {
        yield return new object[] { new int[][] { new int[] { 1 } }, 1 };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } },
            21
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { -1, -2, -3 },
                new int[] { -4, -5, -6 },
                new int[] { -7, -8, -9 }
            },
            -45
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 10, 20, 30 },
                new int[] { 40, 50 },
                new int[] { 60, 70, 80, 90 }
            },
            450
        };

        yield return new object[]
        {
            new int[][] { new int[] { 5, 12, 9 }, new int[] { 15, 8, 6 }, new int[] { 3, 7, 11 } },
            76
        };

        yield return new object[] { new int[][] { new int[] { 2 } }, 2 };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { -2, -1, 0 },
                new int[] { 0, -3, -4 },
                new int[] { -5, -6, -7 }
            },
            -28
        };

        yield return new object[] { new int[][] { }, 0 };

        yield return new object[]
        {
            new int[][] { new int[] { }, new int[] { }, new int[] { } },
            0
        };

        yield return new object[] { new int[][] { new int[] { int.MaxValue } }, int.MaxValue };

        yield return new object[] { new int[][] { new int[] { int.MinValue } }, int.MinValue };
    }

    [Theory]
    [MemberData(nameof(CalculateSumOfElements_TestData))]
    public void CalculateSumOfElements_ReturnsSumOfAllElements(int[][] arr, int expectedSum)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int sum = solution.CalculateSumOfElements(arr);

        // Assert
        Assert.Equal(expectedSum, sum);
    }

    public static IEnumerable<object[]> SortRowsBySum_TestData()
    {
        yield return new object[]
        {
            new int[][] { new int[] { 1 } },
            new int[][] { new int[] { 1 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 3, 2, 1 } },
            new int[][] { new int[] { 1, 2, 3 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 9, 4, 7 }, new int[] { 1, 5, 3 }, new int[] { 6, 2, 8 } },
            new int[][] { new int[] { 1, 5, 3 }, new int[] { 6, 2, 8 }, new int[] { 9, 4, 7 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 9, 2, 5, 1 }, new int[] { 4, 6 }, new int[] { 7, 3, 8 } },
            new int[][] { new int[] { 4, 6 }, new int[] { 7, 3, 8 }, new int[] { 9, 2, 5, 1 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 5, 7 }, new int[] { 1, 4, 2, 3 }, new int[] { 6 } },
            new int[][] { new int[] { 6 }, new int[] { 1, 4, 2, 3 }, new int[] { 5, 7 } }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 3, 2, 1 },
                new int[] { },
                new int[] { 4, 5 },
                new int[] { 6 }
            },
            new int[][]
            {
                new int[] { },
                new int[] { 3, 2, 1 },
                new int[] { 4, 5 },
                new int[] { 6 }
            }
        };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(SortRowsBySum_TestData))]
    public void SortRowsBySum_SortsRowsBasedOnSum(int[][] arr, int[][] expectedSortedArray)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        solution.SortRowsBySum(arr);

        // Assert
        Assert.Equal(expectedSortedArray, arr);
    }

    public static IEnumerable<object[]> ConvertToJaggedArray_TestData()
    {
        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            },
            new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            },
            new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } }
        };

        yield return new object[]
        {
            new int[,]
            {
                { -1, -2 },
                { -3, -4 },
                { -5, -6 }
            },
            new int[][] { new int[] { -1, -2 }, new int[] { -3, -4 }, new int[] { -5, -6 } }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 10, 20, 30 },
                { 40, 50, 60 },
                { 70, 80, 90 }
            },
            new int[][]
            {
                new int[] { 10, 20, 30 },
                new int[] { 40, 50, 60 },
                new int[] { 70, 80, 90 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 5, 12 },
                { 15, 8 },
                { 3, 7 }
            },
            new int[][] { new int[] { 5, 12 }, new int[] { 15, 8 }, new int[] { 3, 7 } }
        };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(ConvertToJaggedArray_TestData))]
    public void ConvertToJaggedArray_ConvertsMultiDimensionalArrayToJaggedArray(
        int[,] array,
        int[][] expectedJaggedArray
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int[][] jaggedArray = solution.ConvertToJaggedArray(array);

        // Assert
        Assert.Equal(expectedJaggedArray, jaggedArray);
    }

    public static IEnumerable<object[]> ReshapeArray_TestData()
    {
        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            },
            2,
            2,
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            },
            3,
            2,
            new int[,]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            },
            1,
            6,
            new int[,]
            {
                { 1, 2, 3, 4, 5, 6 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            },
            2,
            6,
            new int[,]
            {
                { 1, 2, 3, 4, 5, 6 },
                { 7, 8, 9, 10, 11, 12 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            },
            6,
            2,
            new int[,]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 },
                { 7, 8 },
                { 9, 10 },
                { 11, 12 }
            }
        };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(ReshapeArray_TestData))]
    public void ReshapeArray_ReshapesArrayWithNewShape(
        int[,] array,
        int rows,
        int columns,
        int[,] expectedReshapedArray
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int[,] reshapedArray = solution.ReshapeArray(array, rows, columns);

        // Assert
        Assert.Equal(expectedReshapedArray, reshapedArray);
    }

    public static IEnumerable<object[]> GenerateSpiralMatrix_TestData()
    {
        yield return new object[]
        {
            1,
            new int[,]
            {
                { 1 }
            }
        };

        yield return new object[]
        {
            2,
            new int[,]
            {
                { 1, 2 },
                { 4, 3 }
            }
        };

        yield return new object[]
        {
            3,
            new int[,]
            {
                { 1, 2, 3 },
                { 8, 9, 4 },
                { 7, 6, 5 }
            }
        };

        yield return new object[]
        {
            4,
            new int[,]
            {
                { 1, 2, 3, 4 },
                { 12, 13, 14, 5 },
                { 11, 16, 15, 6 },
                { 10, 9, 8, 7 }
            }
        };

        yield return new object[]
        {
            5,
            new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 16, 17, 18, 19, 6 },
                { 15, 24, 25, 20, 7 },
                { 14, 23, 22, 21, 8 },
                { 13, 12, 11, 10, 9 }
            }
        };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(GenerateSpiralMatrix_TestData))]
    public void GenerateSpiralMatrix_GeneratesSpiralMatrix(int n, int[,] expectedSpiralMatrix)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int[,] spiralMatrix = solution.GenerateSpiralMatrix(n);

        // Assert
        Assert.Equal(expectedSpiralMatrix, spiralMatrix);
    }

    public static IEnumerable<object[]> SearchElement_TestData()
    {
        yield return new object[] { new int[][] { new int[] { 1 } }, 1, 0, 0 };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } },
            4,
            1,
            1
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { -1, -2, -3 },
                new int[] { -4, -5, -6 },
                new int[] { -7, -8, -9 }
            },
            -5,
            1,
            1
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 10, 20, 30, 40 },
                new int[] { 50, 60, 70, 80 },
                new int[] { 90, 100, 110, 120 }
            },
            110,
            2,
            2
        };

        yield return new object[]
        {
            new int[][] { new int[] { 5, 12, 9 }, new int[] { 15, 8, 6 }, new int[] { 3, 7, 11 } },
            8,
            1,
            1
        };

        yield return new object[] { new int[][] { new int[] { 2 } }, 5, -1, -1 };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(SearchElement_TestData))]
    public void SearchElement_ReturnsIndicesIfElementFound(
        int[][] arr,
        int target,
        int expectedRowIndex,
        int expectedColumnIndex
    )
    {
        // Arrange
        Solution solution = new Solution();
        int rowIndex,
            columnIndex;

        // Act
        solution.SearchElement(arr, target, out rowIndex, out columnIndex);

        // Assert
        Assert.Equal(expectedRowIndex, rowIndex);
        Assert.Equal(expectedColumnIndex, columnIndex);
    }

    public static IEnumerable<object[]> CalculateMinScalarMultiplications_TestData()
    {
        yield return new object[] { new int[] { 5 }, 0 };

        yield return new object[] { new int[] { 2, 3, 4 }, 24 };

        yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 38 };

        yield return new object[] { new int[] { 10, 20, 30, 40 }, 24000 };

        yield return new object[] { new int[] { 3, 5, 2, 6, 8 }, 348 };

        yield return new object[] { new int[] { 2, 3 }, 0 };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(CalculateMinScalarMultiplications_TestData))]
    public void CalculateMinScalarMultiplications_ReturnsMinMultiplications(
        int[] chain,
        int expectedMinMultiplications
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int minMultiplications = solution.CalculateMinScalarMultiplications(chain);

        // Assert
        Assert.Equal(expectedMinMultiplications, minMultiplications);
    }

    public static IEnumerable<object[]> FindMaxSubarraySum_TestData()
    {
        yield return new object[] { new int[] { 1 }, 1 };

        yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 15 };

        yield return new object[] { new int[] { -2, -3, 4, -1, -2, 1, 5, -3 }, 7 };

        yield return new object[] { new int[] { -1, -2, -3, -4, -5 }, -1 };

        yield return new object[] { new int[] { 5, -8, 3, 2, 1, -10, 5 }, 8 };

        yield return new object[] { new int[] { -10, -5, -2, -3, -1 }, -1 };

        // Add more test cases for edge cases and special scenarios
    }

    [Theory]
    [MemberData(nameof(FindMaxSubarraySum_TestData))]
    public void FindMaxSubarraySum_ReturnsMaxSubarraySum(int[] arr, int expectedMaxSum)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int maxSum = solution.FindMaxSubarraySum(arr);

        // Assert
        Assert.Equal(expectedMaxSum, maxSum);
    }

    public static IEnumerable<object[]> FindMaxValueInRectangle_TestData()
    {
        yield return new object[]
        {
            new int[,]
            {
                { 1 }
            },
            1
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            },
            4
        };

        yield return new object[]
        {
            new int[,]
            {
                { -1, -2, -3 },
                { -4, -5, -6 },
                { -7, -8, -9 }
            },
            -1
        };

        yield return new object[]
        {
            new int[,]
            {
                { 10, 20, 30, 40 },
                { 50, 60, 70, 80 },
                { 90, 100, 110, 120 }
            },
            120
        };

        yield return new object[]
        {
            new int[,]
            {
                { 5, 12, 9 },
                { 15, 8, 6 },
                { 3, 7, 11 }
            },
            15
        };

        yield return new object[]
        {
            new int[,]
            {
                { 2 }
            },
            2
        };

        yield return new object[]
        {
            new int[,]
            {
                { -2, -1, 0 },
                { 0, -3, -4 },
                { -5, -6, -7 }
            },
            0
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MaxValue }
            },
            int.MaxValue
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MinValue }
            },
            int.MinValue
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MinValue, int.MaxValue }
            },
            int.MaxValue
        };

        yield return new object[]
        {
            new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            },
            0
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MinValue, int.MaxValue },
                { int.MinValue, int.MaxValue }
            },
            int.MaxValue
        };

        // Add more edge test cases if needed
    }

    [Theory]
    [MemberData(nameof(FindMaxValueInRectangle_TestData))]
    public void FindMaxValueInRectangle_ReturnsMaxValue(int[,] array, int expectedMaxValue)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int maxValue = solution.FindMaxValueInRectangle(array);

        // Assert
        Assert.Equal(expectedMaxValue, maxValue);
    }

    public static IEnumerable<object[]> SortJaggedArrayByRowSum_TestData()
    {
        yield return new object[]
        {
            new int[][] { new int[] { 1 } },
            new int[][] { new int[] { 1 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 4, 3 }, new int[] { 2, 1 } },
            new int[][] { new int[] { 2, 1 }, new int[] { 4, 3 } }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { -1, -2, -3 },
                new int[] { -4, -5, -6 },
                new int[] { -7, -8, -9 }
            },
            new int[][]
            {
                new int[] { -7, -8, -9 },
                new int[] { -4, -5, -6 },
                new int[] { -1, -2, -3 }
            }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 10, 20, 30, 40 },
                new int[] { 50, 60, 70, 80 },
                new int[] { 90, 100, 110, 120 }
            },
            new int[][]
            {
                new int[] { 10, 20, 30, 40 },
                new int[] { 50, 60, 70, 80 },
                new int[] { 90, 100, 110, 120 }
            }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 5, 12, 9 }, new int[] { 15, 8, 6 }, new int[] { 3, 7, 11 } },
            new int[][] { new int[] { 3, 7, 11 }, new int[] { 5, 12, 9 }, new int[] { 15, 8, 6 } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { 2 } },
            new int[][] { new int[] { 2 } }
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { -2, -1, 0 },
                new int[] { 0, -3, -4 },
                new int[] { -5, -6, -7 }
            },
            new int[][]
            {
                new int[] { -5, -6, -7 },
                new int[] { -2, -1, 0 },
                new int[] { 0, -3, -4 }
            }
        };

        yield return new object[]
        {
            new int[][] { new int[] { int.MaxValue } },
            new int[][] { new int[] { int.MaxValue } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { int.MinValue } },
            new int[][] { new int[] { int.MinValue } }
        };

        yield return new object[]
        {
            new int[][] { new int[] { int.MinValue, int.MaxValue } },
            new int[][] { new int[] { int.MinValue, int.MaxValue } }
        };

        // Add more test cases if needed
    }

    [Theory]
    [MemberData(nameof(SortJaggedArrayByRowSum_TestData))]
    public void SortJaggedArrayByRowSum_SortsArrayByRowSum(int[][] arr, int[][] expectedSortedArray)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        solution.SortJaggedArrayByRowSum(arr);

        // Assert
        Assert.Equal(expectedSortedArray, arr);
    }

    public static IEnumerable<object[]> FindMaxSumSubarray_TestData()
    {
        yield return new object[]
        {
            new int[,]
            {
                { 1 }
            },
            new int[,]
            {
                { 1 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            },
            new int[,]
            {
                { 3, 4 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { -1, -2, -3 },
                { -4, -5, -6 },
                { -7, -8, -9 }
            },
            new int[,]
            {
                { -1, -2, -3 },
                { -4, -5, -6 },
                { -7, -8, -9 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 10, 20, 30, 40 },
                { 50, 60, 70, 80 },
                { 90, 100, 110, 120 }
            },
            new int[,]
            {
                { 90, 100, 110, 120 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 5, 12, 9 },
                { 15, 8, 6 },
                { 3, 7, 11 }
            },
            new int[,]
            {
                { 5, 12, 9 },
                { 15, 8, 6 },
                { 3, 7, 11 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 2 }
            },
            new int[,]
            {
                { 2 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { -2, -1, 0 },
                { 0, -3, -4 },
                { -5, -6, -7 }
            },
            new int[,]
            {
                { 0, -3, -4 },
                { -5, -6, -7 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MaxValue }
            },
            new int[,]
            {
                { int.MaxValue }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MinValue }
            },
            new int[,]
            {
                { int.MinValue }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { int.MinValue, int.MaxValue }
            },
            new int[,]
            {
                { int.MinValue, int.MaxValue }
            }
        };

        // Add more test cases if needed
    }

    [Theory]
    [MemberData(nameof(FindMaxSumSubarray_TestData))]
    public void FindMaxSumSubarray_ReturnsMaxSumSubarray(int[,] array, int[,] expectedMaxSubarray)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int[,] maxSubarray = solution.FindMaxSumSubarray(array);

        // Assert
        Assert.Equal(expectedMaxSubarray, maxSubarray);
    }

    public static IEnumerable<object[]> RotateSquareArrayClockwise_TestData()
    {
        yield return new object[]
        {
            new int[,]
            {
                { 1 }
            },
            new int[,]
            {
                { 1 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            },
            new int[,]
            {
                { 3, 1 },
                { 4, 2 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            },
            new int[,]
            {
                { 7, 4, 1 },
                { 8, 5, 2 },
                { 9, 6, 3 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new int[,]
            {
                { 13, 9, 5, 1 },
                { 14, 10, 6, 2 },
                { 15, 11, 7, 3 },
                { 16, 12, 8, 4 }
            }
        };

        // Additional test cases for edge cases and special scenarios
        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            },
            new int[,]
            {
                { 21, 16, 11, 6, 1 },
                { 22, 17, 12, 7, 2 },
                { 23, 18, 13, 8, 3 },
                { 24, 19, 14, 9, 4 },
                { 25, 20, 15, 10, 5 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3, 4, 5, 6 },
                { 7, 8, 9, 10, 11, 12 },
                { 13, 14, 15, 16, 17, 18 },
                { 19, 20, 21, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30 },
                { 31, 32, 33, 34, 35, 36 }
            },
            new int[,]
            {
                { 31, 25, 19, 13, 7, 1 },
                { 32, 26, 20, 14, 8, 2 },
                { 33, 27, 21, 15, 9, 3 },
                { 34, 28, 22, 16, 10, 4 },
                { 35, 29, 23, 17, 11, 5 },
                { 36, 30, 24, 18, 12, 6 }
            }
        };

        yield return new object[]
        {
            new int[,]
            {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 8, 9, 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19, 20, 21 },
                { 22, 23, 24, 25, 26, 27, 28 },
                { 29, 30, 31, 32, 33, 34, 35 },
                { 36, 37, 38, 39, 40, 41, 42 },
                { 43, 44, 45, 46, 47, 48, 49 }
            },
            new int[,]
            {
                { 43, 36, 29, 22, 15, 8, 1 },
                { 44, 37, 30, 23, 16, 9, 2 },
                { 45, 38, 31, 24, 17, 10, 3 },
                { 46, 39, 32, 25, 18, 11, 4 },
                { 47, 40, 33, 26, 19, 12, 5 },
                { 48, 41, 34, 27, 20, 13, 6 },
                { 49, 42, 35, 28, 21, 14, 7 }
            }
        };

        // Add more test cases if needed
    }

    [Theory]
    [MemberData(nameof(RotateSquareArrayClockwise_TestData))]
    public void RotateSquareArrayClockwise_RotatesArrayClockwise(
        int[,] array,
        int[,] expectedRotatedArray
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        solution.RotateSquareArrayClockwise(array);

        // Assert
        Assert.Equal(expectedRotatedArray, array);
    }

    public static IEnumerable<object[]> FindRowWithHighestSum_TestData()
    {
        yield return new object[] { new int[][] { new int[] { 1 } }, 0 };

        yield return new object[] { new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }, 1 };

        yield return new object[]
        {
            new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
            2
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 }
            },
            3
        };

        // Additional test cases for edge cases and special scenarios
        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 6, 7, 8, 9, 10 },
                new int[] { 11, 12, 13, 14, 15 },
                new int[] { 16, 17, 18, 19, 20 },
                new int[] { 21, 22, 23, 24, 25 }
            },
            4
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6 },
                new int[] { 7, 8, 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16, 17, 18 },
                new int[] { 19, 20, 21, 22, 23, 24 },
                new int[] { 25, 26, 27, 28, 29, 30 },
                new int[] { 31, 32, 33, 34, 35, 36 }
            },
            5
        };

        yield return new object[]
        {
            new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 8, 9, 10, 11, 12, 13, 14 },
                new int[] { 15, 16, 17, 18, 19, 20, 21 },
                new int[] { 22, 23, 24, 25, 26, 27, 28 },
                new int[] { 29, 30, 31, 32, 33, 34, 35 },
                new int[] { 36, 37, 38, 39, 40, 41, 42 },
                new int[] { 43, 44, 45, 46, 47, 48, 49 }
            },
            6
        };

        // Add more test cases if needed
    }

    [Theory]
    [MemberData(nameof(FindRowWithHighestSum_TestData))]
    public void FindRowWithHighestSum_ReturnsRowWithHighestSum(int[][] arr, int expectedRowIndex)
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int rowIndex = solution.FindRowWithHighestSum(arr);

        // Assert
        Assert.Equal(expectedRowIndex, rowIndex);
    }

    public static IEnumerable<object[]> CountOccurrencesIn2DArray_TestData()
    {
        yield return new object[]
        {
            new char[,]
            {
                { 'a' }
            },
            'a',
            1
        };

        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'b' },
                { 'c', 'd' }
            },
            'a',
            1
        };

        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'b', 'c' },
                { 'd', 'e', 'f' },
                { 'g', 'h', 'i' }
            },
            'c',
            1
        };

        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a' }
            },
            'a',
            16
        };

        // Additional test cases for edge cases and special scenarios
        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'b', 'c', 'd', 'e' },
                { 'f', 'g', 'h', 'i', 'j' },
                { 'k', 'l', 'm', 'n', 'o' },
                { 'p', 'q', 'r', 's', 't' },
                { 'u', 'v', 'w', 'x', 'y' }
            },
            'z',
            0
        };

        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'b', 'c' },
                { 'a', 'b', 'c' },
                { 'a', 'b', 'c' }
            },
            'b',
            3
        };

        yield return new object[]
        {
            new char[,]
            {
                { 'a', 'a', 'a' },
                { 'b', 'b', 'b' },
                { 'c', 'c', 'c' }
            },
            'c',
            3
        };

        // Add more test cases if needed
    }

    [Theory]
    [MemberData(nameof(CountOccurrencesIn2DArray_TestData))]
    public void CountOccurrencesIn2DArray_ReturnsCorrectCount(
        char[,] array,
        char target,
        int expectedCount
    )
    {
        // Arrange
        Solution solution = new Solution();

        // Act
        int count = solution.CountOccurrencesIn2DArray(array, target);

        // Assert
        Assert.Equal(expectedCount, count);
    }
}