namespace ArePositionsConnected;

public interface IConnectionCheck<TPOS> where TPOS : IEquatable<TPOS>
{
    public bool AreStartAndGoalConnected(ISearchSpace<TPOS> searchSpace, TPOS startPosition, TPOS goal);
}

