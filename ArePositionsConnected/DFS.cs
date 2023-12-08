namespace ArePositionsConnected;

public class DFS<TPOS> : IConnectionCheck<TPOS> where TPOS : IEquatable<TPOS>
{
    public bool AreStartAndGoalConnected(ISearchSpace<TPOS> searchSpace, TPOS startPosition, TPOS goal)
    {
        return DFSrec(startPosition, searchSpace, goal, new());
    }

    private static bool DFSrec(TPOS currentPos, ISearchSpace<TPOS> searchSpace, TPOS goal, HashSet<TPOS> discovered)
    {
        if (currentPos.Equals(goal)) return true;
        discovered.Add(currentPos);
        foreach (var neighbor in searchSpace.GetNeighbors(currentPos))
        {
            if (discovered.Contains(neighbor)) continue;
            if (DFSrec(neighbor, searchSpace, goal, discovered)) return true;
        }
        return false;
    }
}