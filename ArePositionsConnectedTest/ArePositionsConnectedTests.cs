using ArePositionsConnected;

namespace ArePositionsConnectedTest;

public class SimpleTestSearchSpace(Dictionary<int, List<int>> neighbors) : ISearchSpace<int>
{
    public Dictionary<int, List<int>> Neighbors { get; set; } = neighbors;

    public IEnumerable<int> GetNeighbors(int pos)
    {
        return Neighbors[pos];
    }
}

public class ArePositionsConnectedTests
{
    private static SimpleTestSearchSpace ArrangeConnectedSearchSpace()
    {
        var neighbors = new Dictionary<int, List<int>>
        {
            { 1, [2, 5] },
            { 2, [1, 3, 5] },
            { 3, [2, 4, 6, 8] },
            { 4, [3, 8] },
            { 5, [1, 2] },
            { 6, [3, 7] },
            { 7, [6, 8] },
            { 8, [3, 4, 7] }
        };
        var searchSpace = new SimpleTestSearchSpace(neighbors);
        return searchSpace;
    }

    [Fact]
    public void DfsTestConnected()
    {
        // Arrange
        var searchSpace = ArrangeConnectedSearchSpace();

        // Act
        var dfs = new DFS<int>();
        var result = dfs.AreStartAndGoalConnected(searchSpace, 1, 8);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DfsTestNotConnected()
    {
        // Arrange
        var searchSpace = ArrangeConnectedSearchSpace();
        searchSpace.Neighbors[2].Remove(3);

        // Act
        var dfs = new DFS<int>();
        var result = dfs.AreStartAndGoalConnected(searchSpace, 1, 8);

        // Assert
        Assert.False(result);
    }
}