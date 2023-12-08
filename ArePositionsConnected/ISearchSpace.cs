namespace ArePositionsConnected;

public interface ISearchSpace<TPOS> where TPOS : IEquatable<TPOS>
{
    public IEnumerable<TPOS> GetNeighbors(TPOS pos);
}

